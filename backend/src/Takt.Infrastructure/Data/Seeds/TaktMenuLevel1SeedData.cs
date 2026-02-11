// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：Takt.Infrastructure.Data.Seeds
// 文件名称：TaktMenuLevel1SeedData.cs
// 创建时间：2025-01-20
// 创建人：Takt365(Cursor AI)
// 功能描述：Takt顶级菜单种子数据，初始化顶级菜单（ParentId = 0）
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using Microsoft.Extensions.DependencyInjection;
using Takt.Domain.Entities.Identity;
using Takt.Domain.Repositories;

namespace Takt.Infrastructure.Data.Seeds;

/// <summary>
/// Takt顶级菜单种子数据
/// </summary>
public class TaktMenuLevel1SeedData
{
    /// <summary>
    /// 初始化顶级菜单种子数据
    /// </summary>
    /// <param name="serviceProvider">服务提供者</param>
    /// <param name="configId">当前数据库配置ID</param>
    /// <returns>返回插入和更新的记录数（插入数, 更新数）</returns>
    public static async Task<(int InsertCount, int UpdateCount)> SeedAsync(IServiceProvider serviceProvider, string configId)
    {
        var menuRepository = serviceProvider.GetRequiredService<ITaktRepository<TaktMenu>>();

        int insertCount = 0;
        int updateCount = 0;

        // 1. 主页 (MenuType=1, ParentId=0)
        var homeMenu = await menuRepository.GetAsync(m => m.MenuCode == "HOME");
        if (homeMenu == null)
        {
            homeMenu = new TaktMenu
            {
                MenuName = "主页",
                MenuCode = "HOME",
                MenuL10nKey = "menu.home._self",
                MenuIcon = "HomeOutlined",
                ParentId = 0,
                MenuType = 1,
                Permission = "takt:home:list",
                Path = "/home",
                Component = "home/index",
                OrderNum = 1,
                MenuStatus = 0,
                IsVisible = 1,
                IsCache = 0,
                IsExternal = 1,
                IsDeleted = 0
            };
            await menuRepository.CreateAsync(homeMenu);
            insertCount++;
        }
        else
        {
            homeMenu.MenuName = "主页";
            homeMenu.MenuL10nKey = "menu.home._self";
            homeMenu.MenuIcon = "HomeOutlined";
            homeMenu.ParentId = 0;
            homeMenu.MenuType = 1;
            homeMenu.Permission = "takt:home:list";
            homeMenu.Path = "/home";
            homeMenu.Component = "home/index";
            homeMenu.OrderNum = 1;
            homeMenu.MenuStatus = 0;
            homeMenu.IsVisible = 1;
            homeMenu.IsCache = 0;
            homeMenu.IsExternal = 1;
            await menuRepository.UpdateAsync(homeMenu);
            updateCount++;
        }

        // 2. 仪表盘 (MenuType=0, ParentId=0)
        var dashboardMenu = await menuRepository.GetAsync(m => m.MenuCode == "DASHBOARD");
        if (dashboardMenu == null)
        {
            dashboardMenu = new TaktMenu
            {
                MenuName = "仪表盘",
                MenuCode = "DASHBOARD",
                MenuL10nKey = "menu.dashboard._self",
                MenuIcon = "AppstoreOutlined",
                ParentId = 0,
                MenuType = 0,
                Path = "/dashboard",
                Component = null,
                OrderNum = 2,
                MenuStatus = 0,
                IsVisible = 0,
                IsCache = 1,
                IsExternal = 1,
                IsDeleted = 0
            };
            await menuRepository.CreateAsync(dashboardMenu);
            insertCount++;
        }
        else
        {
            dashboardMenu.MenuName = "仪表盘";
            dashboardMenu.MenuL10nKey = "menu.dashboard._self";
            dashboardMenu.MenuIcon = "AppstoreOutlined";
            dashboardMenu.ParentId = 0;
            dashboardMenu.MenuType = 0;
            dashboardMenu.Path = "/dashboard";
            dashboardMenu.Component = null;
            dashboardMenu.OrderNum = 2;
            dashboardMenu.MenuStatus = 0;
            dashboardMenu.IsVisible = 0;
            dashboardMenu.IsCache = 1;
            dashboardMenu.IsExternal = 1;
            await menuRepository.UpdateAsync(dashboardMenu);
            updateCount++;
        }

        // 3. 工作流 (MenuType=0, ParentId=0)
        var workflowMenu = await menuRepository.GetAsync(m => m.MenuCode == "WORKFLOW");
        if (workflowMenu == null)
        {
            workflowMenu = new TaktMenu
            {
                MenuName = "工作流",
                MenuCode = "WORKFLOW",
                MenuL10nKey = "menu.workflow._self",
                MenuIcon = "PartitionOutlined",
                ParentId = 0,
                MenuType = 0,
                Path = "/workflow",
                Component = null,
                OrderNum = 3,
                MenuStatus = 0,
                IsVisible = 0,
                IsCache = 1,
                IsExternal = 1,
                IsDeleted = 0
            };
            await menuRepository.CreateAsync(workflowMenu);
            insertCount++;
        }
        else
        {
            workflowMenu.MenuName = "工作流";
            workflowMenu.MenuL10nKey = "menu.workflow._self";
            workflowMenu.MenuIcon = "PartitionOutlined";
            workflowMenu.ParentId = 0;
            workflowMenu.MenuType = 0;
            workflowMenu.Path = "/workflow";
            workflowMenu.Component = null;
            workflowMenu.OrderNum = 3;
            workflowMenu.MenuStatus = 0;
            workflowMenu.IsVisible = 0;
            workflowMenu.IsCache = 1;
            workflowMenu.IsExternal = 1;
            await menuRepository.UpdateAsync(workflowMenu);
            updateCount++;
        }

        // 4. 日常事务 (MenuType=0, ParentId=0)
        var routineMenu = await menuRepository.GetAsync(m => m.MenuCode == "ROUTINE");
        if (routineMenu == null)
        {
            routineMenu = new TaktMenu
            {
                MenuName = "日常事务",
                MenuCode = "ROUTINE",
                MenuL10nKey = "menu.routine._self",
                MenuIcon = "ScheduleOutlined",
                ParentId = 0,
                MenuType = 0,
                Path = "/routine",
                Component = null,
                OrderNum = 4,
                MenuStatus = 0,
                IsVisible = 0,
                IsCache = 1,
                IsExternal = 1,
                IsDeleted = 0
            };
            await menuRepository.CreateAsync(routineMenu);
            insertCount++;
        }
        else
        {
            routineMenu.MenuName = "日常事务";
            routineMenu.MenuL10nKey = "menu.routine._self";
            routineMenu.MenuIcon = "ScheduleOutlined";
            routineMenu.ParentId = 0;
            routineMenu.MenuType = 0;
            routineMenu.Path = "/routine";
            routineMenu.Component = null;
            routineMenu.OrderNum = 4;
            routineMenu.MenuStatus = 0;
            routineMenu.IsVisible = 0;
            routineMenu.IsCache = 1;
            routineMenu.IsExternal = 1;
            await menuRepository.UpdateAsync(routineMenu);
            updateCount++;
        }

        // 5. 财务核算 (MenuType=0, ParentId=0)
        var accountingMenu = await menuRepository.GetAsync(m => m.MenuCode == "ACCOUNTING");
        if (accountingMenu == null)
        {
            accountingMenu = new TaktMenu
            {
                MenuName = "财务核算",
                MenuCode = "ACCOUNTING",
                MenuL10nKey = "menu.accounting._self",
                MenuIcon = "AccountBookOutlined",
                ParentId = 0,
                MenuType = 0,
                Path = "/accounting",
                Component = null,
                OrderNum = 5,
                MenuStatus = 0,
                IsVisible = 0,
                IsCache = 1,
                IsExternal = 1,
                IsDeleted = 0
            };
            await menuRepository.CreateAsync(accountingMenu);
            insertCount++;
        }
        else
        {
            accountingMenu.MenuName = "财务核算";
            accountingMenu.MenuL10nKey = "menu.accounting._self";
            accountingMenu.MenuIcon = "AccountBookOutlined";
            accountingMenu.ParentId = 0;
            accountingMenu.MenuType = 0;
            accountingMenu.Path = "/accounting";
            accountingMenu.Component = null;
            accountingMenu.OrderNum = 5;
            accountingMenu.MenuStatus = 0;
            accountingMenu.IsVisible = 0;
            accountingMenu.IsCache = 1;
            accountingMenu.IsExternal = 1;
            await menuRepository.UpdateAsync(accountingMenu);
            updateCount++;
        }

        // 6. 后勤管理 (MenuType=0, ParentId=0)
        var logisticsMenu = await menuRepository.GetAsync(m => m.MenuCode == "LOGISTICS");
        if (logisticsMenu == null)
        {
            logisticsMenu = new TaktMenu
            {
                MenuName = "后勤管理",
                MenuCode = "LOGISTICS",
                MenuL10nKey = "menu.logistics._self",
                MenuIcon = "CarOutlined",
                ParentId = 0,
                MenuType = 0,
                Path = "/logistics",
                Component = null,
                OrderNum = 6,
                MenuStatus = 0,
                IsVisible = 0,
                IsCache = 1,
                IsExternal = 1,
                IsDeleted = 0
            };
            await menuRepository.CreateAsync(logisticsMenu);
            insertCount++;
        }
        else
        {
            logisticsMenu.MenuName = "后勤管理";
            logisticsMenu.MenuL10nKey = "menu.logistics._self";
            logisticsMenu.MenuIcon = "CarOutlined";
            logisticsMenu.ParentId = 0;
            logisticsMenu.MenuType = 0;
            logisticsMenu.Path = "/logistics";
            logisticsMenu.Component = null;
            logisticsMenu.OrderNum = 6;
            logisticsMenu.MenuStatus = 0;
            logisticsMenu.IsVisible = 0;
            logisticsMenu.IsCache = 1;
            logisticsMenu.IsExternal = 1;
            await menuRepository.UpdateAsync(logisticsMenu);
            updateCount++;
        }

        // 7. 身份认证 (MenuType=0, ParentId=0)
        var identityMenu = await menuRepository.GetAsync(m => m.MenuCode == "IDENTITY");
        if (identityMenu == null)
        {
            identityMenu = new TaktMenu
            {
                MenuName = "身份认证",
                MenuCode = "IDENTITY",
                MenuL10nKey = "menu.identity._self",
                MenuIcon = "UserOutlined",
                ParentId = 0,
                MenuType = 0,
                Path = "/identity",
                Component = null,
                OrderNum = 7,
                MenuStatus = 0,
                IsVisible = 0,
                IsCache = 1,
                IsExternal = 1,
                IsDeleted = 0
            };
            await menuRepository.CreateAsync(identityMenu);
            insertCount++;
        }
        else
        {
            identityMenu.MenuName = "身份认证";
            identityMenu.MenuL10nKey = "menu.identity._self";
            identityMenu.MenuIcon = "UserOutlined";
            identityMenu.ParentId = 0;
            identityMenu.MenuType = 0;
            identityMenu.Path = "/identity";
            identityMenu.Component = null;
            identityMenu.OrderNum = 7;
            identityMenu.MenuStatus = 0;
            identityMenu.IsVisible = 0;
            identityMenu.IsCache = 1;
            identityMenu.IsExternal = 1;
            await menuRepository.UpdateAsync(identityMenu);
            updateCount++;
        }

        // 8. 人力资源 (MenuType=0, ParentId=0)（组织管理已迁移至本菜单下二级）
        var humanResourceMenu = await menuRepository.GetAsync(m => m.MenuCode == "HUMAN_RESOURCE");
        if (humanResourceMenu == null)
        {
            humanResourceMenu = new TaktMenu
            {
                MenuName = "人力资源",
                MenuCode = "HUMAN_RESOURCE",
                MenuL10nKey = "menu.humanresource._self",
                MenuIcon = "SolutionOutlined",
                ParentId = 0,
                MenuType = 0,
                Path = "/humanresource",
                Component = null,
                OrderNum = 8,
                MenuStatus = 0,
                IsVisible = 0,
                IsCache = 1,
                IsExternal = 1,
                IsDeleted = 0
            };
            await menuRepository.CreateAsync(humanResourceMenu);
            insertCount++;
        }
        else
        {
            humanResourceMenu.MenuName = "人力资源";
            humanResourceMenu.MenuL10nKey = "menu.humanresource._self";
            humanResourceMenu.MenuIcon = "SolutionOutlined";
            humanResourceMenu.ParentId = 0;
            humanResourceMenu.MenuType = 0;
            humanResourceMenu.Path = "/humanresource";
            humanResourceMenu.Component = null;
            humanResourceMenu.OrderNum = 8;
            humanResourceMenu.MenuStatus = 0;
            humanResourceMenu.IsVisible = 0;
            humanResourceMenu.IsCache = 1;
            humanResourceMenu.IsExternal = 1;
            await menuRepository.UpdateAsync(humanResourceMenu);
            updateCount++;
        }

        // 9. 代码管理 (MenuType=0, ParentId=0)
        var codeMenu = await menuRepository.GetAsync(m => m.MenuCode == "CODE");
        if (codeMenu == null)
        {
            codeMenu = new TaktMenu
            {
                MenuName = "代码管理",
                MenuCode = "CODE",
                MenuL10nKey = "menu.code._self",
                MenuIcon = "CodepenOutlined",
                ParentId = 0,
                MenuType = 0,
                Path = "/code",
                Component = null,
                OrderNum = 9,
                MenuStatus = 0,
                IsVisible = 0,
                IsCache = 1,
                IsExternal = 1,
                IsDeleted = 0
            };
            await menuRepository.CreateAsync(codeMenu);
            insertCount++;
        }
        else
        {
            codeMenu.MenuName = "代码管理";
            codeMenu.MenuL10nKey = "menu.code._self";
            codeMenu.MenuIcon = "CodepenOutlined";
            codeMenu.ParentId = 0;
            codeMenu.MenuType = 0;
            codeMenu.Path = "/code";
            codeMenu.Component = null;
            codeMenu.OrderNum = 9;
            codeMenu.MenuStatus = 0;
            codeMenu.IsVisible = 0;
            codeMenu.IsCache = 1;
            codeMenu.IsExternal = 1;
            await menuRepository.UpdateAsync(codeMenu);
            updateCount++;
        }

        // 10. 统计看板 (MenuType=0, ParentId=0)
        var statisticsMenu = await menuRepository.GetAsync(m => m.MenuCode == "STATISTICS");
        if (statisticsMenu == null)
        {
            statisticsMenu = new TaktMenu
            {
                MenuName = "统计看板",
                MenuCode = "STATISTICS",
                MenuL10nKey = "menu.statistics._self",
                MenuIcon = "BarChartOutlined",
                ParentId = 0,
                MenuType = 0,
                Path = "/statistics",
                Component = null,
                OrderNum = 10,
                MenuStatus = 0,
                IsVisible = 0,
                IsCache = 1,
                IsExternal = 1,
                IsDeleted = 0
            };
            await menuRepository.CreateAsync(statisticsMenu);
            insertCount++;
        }
        else
        {
            statisticsMenu.MenuName = "统计看板";
            statisticsMenu.MenuL10nKey = "menu.statistics._self";
            statisticsMenu.MenuIcon = "BarChartOutlined";
            statisticsMenu.ParentId = 0;
            statisticsMenu.MenuType = 0;
            statisticsMenu.Path = "/statistics";
            statisticsMenu.Component = null;
            statisticsMenu.OrderNum = 10;
            statisticsMenu.MenuStatus = 0;
            statisticsMenu.IsVisible = 0;
            statisticsMenu.IsCache = 1;
            statisticsMenu.IsExternal = 1;
            await menuRepository.UpdateAsync(statisticsMenu);
            updateCount++;
        }

        // 11. 关于 (MenuType=1, ParentId=0)
        var aboutMenu = await menuRepository.GetAsync(m => m.MenuCode == "ABOUT");
        if (aboutMenu == null)
        {
            aboutMenu = new TaktMenu
            {
                MenuName = "关于",
                MenuCode = "ABOUT",
                MenuL10nKey = "menu.about._self",
                MenuIcon = "InfoCircleOutlined",
                ParentId = 0,
                MenuType = 1,
                Permission = "takt:about:list",
                Path = "/about",
                Component = "about/index",
                OrderNum = 11,
                MenuStatus = 0,
                IsVisible = 0,
                IsCache = 0,
                IsExternal = 1,
                IsDeleted = 0
            };
            await menuRepository.CreateAsync(aboutMenu);
            insertCount++;
        }
        else
        {
            aboutMenu.MenuName = "关于";
            aboutMenu.MenuL10nKey = "menu.about._self";
            aboutMenu.MenuIcon = "InfoCircleOutlined";
            aboutMenu.ParentId = 0;
            aboutMenu.MenuType = 1;
            aboutMenu.Permission = "takt:about:list";
            aboutMenu.Path = "/about";
            aboutMenu.Component = "about/index";
            aboutMenu.OrderNum = 11;
            aboutMenu.MenuStatus = 0;
            aboutMenu.IsVisible = 0;
            aboutMenu.IsCache = 0;
            aboutMenu.IsExternal = 1;
            await menuRepository.UpdateAsync(aboutMenu);
            updateCount++;
        }

        return (insertCount, updateCount);
    }
}
