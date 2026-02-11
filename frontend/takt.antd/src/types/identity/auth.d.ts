// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：@/types/identity/auth
// 文件名称：auth.d.ts
// 创建时间：2025-01-20
// 创建人：Takt365(Cursor AI)
// 功能描述：认证相关类型定义，对应后端 Takt.Application.Dtos.Identity.TaktAuthDtos
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

/**
 * 登录参数（对应后端 Takt.Application.Dtos.Identity.TaktLoginDto）
 */
export interface LoginParams {
  /** 用户名（对应后端 UserName） */
  username: string
  /** 密码（对应后端 Password） */
  password: string
  /** 记住我（对应后端 RememberMe） */
  rememberMe?: boolean
}

/**
 * 登录响应（对应后端 Takt.Application.Dtos.Identity.TaktLoginResponseDto）
 */
export interface LoginResponse {
  /** 访问令牌（对应后端 AccessToken） */
  token: string
  /** 刷新令牌（对应后端 RefreshToken） */
  refreshToken?: string
  /** 令牌类型（对应后端 TokenType，通常为 "Bearer"） */
  tokenType?: string
  /** 过期时间（秒，对应后端 ExpiresIn） */
  expiresIn?: number
  /** 用户信息（对应后端 UserInfo） */
  userInfo: UserInfo
}

/**
 * 用户信息（对应后端 Takt.Application.Dtos.Identity.TaktUserInfoDto）
 */
export interface UserInfo {
  /** 用户ID（对应后端 UserId，序列化为string以避免Javascript精度问题） */
  userId: string
  /** 用户名（对应后端 UserName） */
  userName: string
  /** 真实姓名（对应后端 RealName） */
  realName: string
  /** 头像（对应后端 Avatar） */
  avatar: string
  /** 角色列表（对应后端 Roles） */
  roles: string[]
  /** 权限列表（对应后端 Permissions） */
  permissions: string[]
}

/**
 * 刷新令牌参数（对应后端 Takt.Application.Dtos.Identity.TaktRefreshTokenDto）
 */
export interface RefreshTokenParams {
  /** 刷新令牌（对应后端 RefreshToken） */
  refreshToken: string
}
