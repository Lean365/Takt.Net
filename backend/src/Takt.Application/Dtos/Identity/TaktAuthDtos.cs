// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：Takt.Application.Dtos.Identity
// 文件名称：TaktAuthDtos.cs
// 创建时间：2025-01-20
// 创建人：Takt365(Cursor AI)
// 功能描述：Takt认证相关DTO，包括登录、刷新token等
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using Newtonsoft.Json;

namespace Takt.Application.Dtos.Identity;

/// <summary>
/// 登录请求DTO
/// </summary>
public class TaktLoginDto
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public TaktLoginDto()
    {
        UserName = string.Empty;
        Password = string.Empty;
    }

    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// 记住我
    /// </summary>
    public bool RememberMe { get; set; } = false;
}

/// <summary>
/// 登录响应DTO
/// </summary>
public class TaktLoginResponseDto
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public TaktLoginResponseDto()
    {
        AccessToken = string.Empty;
        RefreshToken = string.Empty;
        TokenType = "Bearer";
    }

    /// <summary>
    /// 访问令牌
    /// </summary>
    public string AccessToken { get; set; }

    /// <summary>
    /// 刷新令牌
    /// </summary>
    public string RefreshToken { get; set; }

    /// <summary>
    /// 令牌类型
    /// </summary>
    public string TokenType { get; set; }

    /// <summary>
    /// 过期时间（秒）
    /// </summary>
    public int ExpiresIn { get; set; }

    /// <summary>
    /// 用户信息
    /// </summary>
    public TaktUserInfoDto? UserInfo { get; set; }
}

/// <summary>
/// 刷新令牌请求DTO
/// </summary>
public class TaktRefreshTokenDto
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public TaktRefreshTokenDto()
    {
        RefreshToken = string.Empty;
    }

    /// <summary>
    /// 刷新令牌
    /// </summary>
    public string RefreshToken { get; set; }
}

/// <summary>
/// 用户信息DTO
/// </summary>
public class TaktUserInfoDto
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public TaktUserInfoDto()
    {
        UserId = string.Empty;
        UserName = string.Empty;
        RealName = string.Empty;
        Avatar = string.Empty;
    }

    /// <summary>
    /// 用户ID
    /// </summary>
    [JsonConverter(typeof(SqlSugar.ValueToStringConverter))]
    public string UserId { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// 真实姓名
    /// </summary>
    public string RealName { get; set; }

    /// <summary>
    /// 头像
    /// </summary>
    public string Avatar { get; set; }

    /// <summary>
    /// 角色列表
    /// </summary>
    public List<string> Roles { get; set; } = new();

    /// <summary>
    /// 权限列表
    /// </summary>
    public List<string> Permissions { get; set; } = new();
}
