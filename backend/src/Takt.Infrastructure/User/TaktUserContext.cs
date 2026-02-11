// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：Takt.Infrastructure.User
// 文件名称：TaktUserContext.cs
// 创建时间：2025-01-20
// 创建人：Takt365(Cursor AI)
// 功能描述：Takt用户上下文，存储当前请求的用户信息
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using Takt.Domain.Entities.Identity;
using Takt.Shared.Helpers;

namespace Takt.Infrastructure.User;

/// <summary>
/// Takt用户上下文
/// </summary>
public class TaktUserContext
{
    private static readonly AsyncLocal<TaktUser?> _currentUser = new();

    /// <summary>
    /// 当前用户实体（完整数据）
    /// </summary>
    public static TaktUser? CurrentUser
    {
        get => _currentUser.Value;
        set
        {
            var oldUser = _currentUser.Value;
            _currentUser.Value = value;
            
            // 输出日志：用户上下文变更
            if (value != null && (oldUser == null || oldUser.Id != value.Id))
            {
                TaktLogger.Information("用户上下文已设置: UserId: {UserId}, UserName: {UserName}, RealName: {RealName}, UserType: {UserType}", 
                    value.Id, value.UserName, value.RealName, value.UserType);
            }
            else if (value == null && oldUser != null)
            {
                TaktLogger.Information("用户上下文已清除: UserId: {UserId}, UserName: {UserName}", 
                    oldUser.Id, oldUser.UserName);
            }
        }
    }

    /// <summary>
    /// 当前用户ID
    /// </summary>
    public static long? CurrentUserId => CurrentUser?.Id;

    /// <summary>
    /// 当前用户名
    /// </summary>
    public static string? CurrentUserName => CurrentUser?.UserName;

    /// <summary>
    /// 当前用户真实姓名
    /// </summary>
    public static string? CurrentRealName => CurrentUser?.RealName;

    /// <summary>
    /// 当前用户昵称
    /// </summary>
    public static string? CurrentNickName => CurrentUser?.NickName;

    /// <summary>
    /// 当前用户头像
    /// </summary>
    public static string? CurrentAvatar => CurrentUser?.Avatar;

    /// <summary>
    /// 当前用户性别（0=未知，1=男，2=女）
    /// </summary>
    public static int? CurrentGender => CurrentUser?.Gender;

    /// <summary>
    /// 当前用户类型（0=普通用户，1=管理员，2=超级管理员）
    /// </summary>
    public static int? CurrentUserType => CurrentUser?.UserType;

    /// <summary>
    /// 当前用户邮箱
    /// </summary>
    public static string? CurrentUserEmail => CurrentUser?.UserEmail;

    /// <summary>
    /// 当前用户手机号
    /// </summary>
    public static string? CurrentUserPhone => CurrentUser?.UserPhone;

    /// <summary>
    /// 当前用户状态（0=启用，1=禁用，3=锁定）
    /// </summary>
    public static int? CurrentUserStatus => CurrentUser?.UserStatus;

    /// <summary>
    /// 是否已登录
    /// </summary>
    public static bool IsAuthenticated => CurrentUser != null && CurrentUser.Id > 0;
}
