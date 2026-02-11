// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：Takt.Infrastructure.Data.Seeds
// 文件名称：TaktRbacSeedData.cs
// 创建时间：2025-01-20
// 创建人：Takt365(Cursor AI)
// 功能描述：Takt RBAC关联种子数据，初始化用户-角色、角色-菜单、用户-部门、用户-岗位关联关系
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using Takt.Domain.Entities.HumanResource.Organization;
using Takt.Domain.Entities.Identity;
using Takt.Infrastructure.Data;

namespace Takt.Infrastructure.Data.Seeds;

/// <summary>
/// Takt RBAC关联种子数据
/// </summary>
public class TaktRbacSeedData : ITaktSeedData
{
    /// <summary>
    /// 执行顺序（RBAC关联应该在用户、角色、部门、岗位、菜单之后初始化）
    /// </summary>
    public int Order => 7;

    /// <summary>
    /// 初始化RBAC关联种子数据
    /// </summary>
    /// <param name="serviceProvider">服务提供者</param>
    /// <param name="configId">当前数据库配置ID</param>
    /// <returns>返回插入和更新的记录数（插入数, 更新数）</returns>
    public async Task<(int InsertCount, int UpdateCount)> SeedAsync(IServiceProvider serviceProvider, string configId)
    {
        var dbContext = serviceProvider.GetRequiredService<TaktSqlSugarDbContext>();
        var db = dbContext.GetClientByConfigId(configId);
        // User、Role 在 ConfigId 0；ConfigId 2 时需从 Identity 库查用户
        var dbIdentity = configId == "2" ? dbContext.GetClientByConfigId("0") : db;
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();

        int insertCount = 0;
        int updateCount = 0;

        var snowflakeSection = configuration.GetSection("Snowflake");
        var snowflakeId = snowflakeSection.GetValue<bool>("Enabled", true);

        // User、Role 始终从 Identity 库（ConfigId 0）查
        var adminUser = await dbIdentity.Queryable<TaktUser>()
            .Where(u => u.UserName == "admin" && u.IsDeleted == 0)
            .FirstAsync();
        var guestUser = await dbIdentity.Queryable<TaktUser>()
            .Where(u => u.UserName == "guest" && u.IsDeleted == 0)
            .FirstAsync();
        var superAdminRole = await dbIdentity.Queryable<TaktRole>()
            .Where(r => r.RoleCode == "SUPER_ADMIN" && r.IsDeleted == 0)
            .FirstAsync();
        var guestRole = await dbIdentity.Queryable<TaktRole>()
            .Where(r => r.RoleCode == "GUEST" && r.IsDeleted == 0)
            .FirstAsync();

        // 部门、岗位在 ConfigId 2；仅当当前为 ConfigId 2 时查询，否则不访问该表避免 ConfigId 0 报“对象名无效”
        TaktDept? headOffice = null;
        TaktDept? generalOffice = null;
        TaktPost? chairmanPost = null;
        TaktPost? employeePost = null;
        if (configId == "2")
        {
            headOffice = await db.Queryable<TaktDept>()
                .Where(d => d.DeptCode == "HEAD_OFFICE" && d.IsDeleted == 0)
                .FirstAsync();
            generalOffice = await db.Queryable<TaktDept>()
                .Where(d => d.DeptCode == "GENERAL_OFFICE" && d.IsDeleted == 0)
                .FirstAsync();
            chairmanPost = await db.Queryable<TaktPost>()
                .Where(p => p.PostCode == "CHAIRMAN" && p.IsDeleted == 0)
                .FirstAsync();
            employeePost = await db.Queryable<TaktPost>()
                .Where(p => p.PostCode == "EMPLOYEE" && p.IsDeleted == 0)
                .FirstAsync();
        }

        // 如果基础数据不存在，无法创建关联，直接返回
        if (adminUser == null || guestUser == null || superAdminRole == null || guestRole == null)
        {
            return (0, 0);
        }

        // ========== 用户-角色、角色-菜单（仅 ConfigId 0，Identity 库）==========
        if (configId == "0")
        {
        // admin 用户 -> SUPER_ADMIN 角色 - 简单判断：存在则跳过，不存在则插入
        if (adminUser != null && superAdminRole != null)
        {
            var adminUserRole = await db.Queryable<TaktUserRole>()
                .Where(ur => ur.UserId == adminUser.Id && ur.RoleId == superAdminRole.Id && ur.IsDeleted == 0)
                .FirstAsync();

            if (adminUserRole == null)
            {
                adminUserRole = new TaktUserRole
                {
                    ConfigId = configId,
                    UserId = adminUser.Id,
                    RoleId = superAdminRole.Id,
                    CreateTime = DateTime.Now,
                    IsDeleted = 0
                };
                // 根据配置决定使用雪花ID还是自增ID
                long id;
                if (snowflakeId)
                {
                    id = db.Insertable(adminUserRole).ExecuteReturnSnowflakeId();
                }
                else
                {
                    id = db.Insertable(adminUserRole).ExecuteReturnIdentity();
                }
                adminUserRole.Id = id;
                insertCount++;
            }
        }

        // guest 用户 -> GUEST 角色
        if (guestUser != null && guestRole != null)
        {
            var guestUserRole = await db.Queryable<TaktUserRole>()
                .Where(ur => ur.UserId == guestUser.Id && ur.RoleId == guestRole.Id && ur.IsDeleted == 0)
                .FirstAsync();

            if (guestUserRole == null)
            {
                guestUserRole = new TaktUserRole
                {
                    ConfigId = configId,
                    UserId = guestUser.Id,
                    RoleId = guestRole.Id,
                    CreateTime = DateTime.Now,
                    IsDeleted = 0
                };
                // 根据配置决定使用雪花ID还是自增ID
                long id;
                if (snowflakeId)
                {
                    id = db.Insertable(guestUserRole).ExecuteReturnSnowflakeId();
                }
                else
                {
                    id = db.Insertable(guestUserRole).ExecuteReturnIdentity();
                }
                guestUserRole.Id = id;
                insertCount++;
            }
        }

        // ========== 角色-菜单关联 ==========
        var allMenus = await db.Queryable<TaktMenu>()
            .Where(m => m.IsDeleted == 0)
            .ToListAsync();
        if (superAdminRole != null && allMenus != null && allMenus.Any())
        {
            foreach (var menu in allMenus)
            {
                var roleMenu = await db.Queryable<TaktRoleMenu>()
                    .Where(rm => rm.RoleId == superAdminRole.Id && rm.MenuId == menu.Id && rm.IsDeleted == 0)
                    .FirstAsync();
                if (roleMenu == null)
                {
                    roleMenu = new TaktRoleMenu
                    {
                        ConfigId = configId,
                        RoleId = superAdminRole.Id,
                        MenuId = menu.Id,
                        CreateTime = DateTime.Now,
                        IsDeleted = 0
                    };
                    long id;
                    if (snowflakeId)
                        id = db.Insertable(roleMenu).ExecuteReturnSnowflakeId();
                    else
                        id = db.Insertable(roleMenu).ExecuteReturnIdentity();
                    roleMenu.Id = id;
                    insertCount++;
                }
            }
        }
        } // end if (configId == "0")

        // ========== 用户-部门、用户-岗位（仅 ConfigId 2，HumanResource 库）==========
        if (configId == "2")
        {
        // admin 用户 -> 总公司
        if (adminUser != null && headOffice != null)
        {
            var adminDeptUser = await db.Queryable<TaktUserDept>()
                .Where(du => du.UserId == adminUser.Id && du.DeptId == headOffice.Id && du.IsDeleted == 0)
                .FirstAsync();

            if (adminDeptUser == null)
            {
                adminDeptUser = new TaktUserDept
                {
                    ConfigId = configId,
                    UserId = adminUser.Id,
                    DeptId = headOffice.Id,
                    CreateTime = DateTime.Now,
                    IsDeleted = 0
                };
                // 根据配置决定使用雪花ID还是自增ID
                long id;
                if (snowflakeId)
                {
                    id = db.Insertable(adminDeptUser).ExecuteReturnSnowflakeId();
                }
                else
                {
                    id = db.Insertable(adminDeptUser).ExecuteReturnIdentity();
                }
                adminDeptUser.Id = id;
                insertCount++;
            }
        }

        // guest 用户 -> 总经室
        if (guestUser != null && generalOffice != null)
        {
            var guestDeptUser = await db.Queryable<TaktUserDept>()
                .Where(du => du.UserId == guestUser.Id && du.DeptId == generalOffice.Id && du.IsDeleted == 0)
                .FirstAsync();

            if (guestDeptUser == null)
            {
                guestDeptUser = new TaktUserDept
                {
                    ConfigId = configId,
                    UserId = guestUser.Id,
                    DeptId = generalOffice.Id,
                    CreateTime = DateTime.Now,
                    IsDeleted = 0
                };
                // 根据配置决定使用雪花ID还是自增ID
                long id;
                if (snowflakeId)
                {
                    id = db.Insertable(guestDeptUser).ExecuteReturnSnowflakeId();
                }
                else
                {
                    id = db.Insertable(guestDeptUser).ExecuteReturnIdentity();
                }
                guestDeptUser.Id = id;
                insertCount++;
            }
        }

        // ========== 用户-岗位关联 ==========

        // admin 用户 -> 董事长岗位
        if (adminUser != null && chairmanPost != null)
        {
            var adminPostUser = await db.Queryable<TaktUserPost>()
                .Where(pu => pu.UserId == adminUser.Id && pu.PostId == chairmanPost.Id && pu.IsDeleted == 0)
                .FirstAsync();

            if (adminPostUser == null)
            {
                adminPostUser = new TaktUserPost
                {
                    ConfigId = configId,
                    UserId = adminUser.Id,
                    PostId = chairmanPost.Id,
                    CreateTime = DateTime.Now,
                    IsDeleted = 0
                };
                // 根据配置决定使用雪花ID还是自增ID
                long id;
                if (snowflakeId)
                {
                    id = db.Insertable(adminPostUser).ExecuteReturnSnowflakeId();
                }
                else
                {
                    id = db.Insertable(adminPostUser).ExecuteReturnIdentity();
                }
                adminPostUser.Id = id;
                insertCount++;
            }
        }

        // guest 用户 -> 员工岗位
        if (guestUser != null && employeePost != null)
        {
            var guestPostUser = await db.Queryable<TaktUserPost>()
                .Where(pu => pu.UserId == guestUser.Id && pu.PostId == employeePost.Id && pu.IsDeleted == 0)
                .FirstAsync();

            if (guestPostUser == null)
            {
                guestPostUser = new TaktUserPost
                {
                    ConfigId = configId,
                    UserId = guestUser.Id,
                    PostId = employeePost.Id,
                    CreateTime = DateTime.Now,
                    IsDeleted = 0
                };
                // 根据配置决定使用雪花ID还是自增ID
                long id;
                if (snowflakeId)
                {
                    id = db.Insertable(guestPostUser).ExecuteReturnSnowflakeId();
                }
                else
                {
                    id = db.Insertable(guestPostUser).ExecuteReturnIdentity();
                }
                guestPostUser.Id = id;
                insertCount++;
            }
        }
        } // end if (configId == "2")

        return (insertCount, updateCount);
    }
}
