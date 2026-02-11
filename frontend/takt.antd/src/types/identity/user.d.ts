// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：@/types/identity/user
// 文件名称：user.d.ts
// 创建时间：2025-01-20
// 创建人：Takt365(Cursor AI)
// 功能描述：用户相关类型定义，对应后端 Takt.Application.Dtos.Identity.TaktUserDtos
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

import type { TaktEntityBase, TaktPagedQuery } from '@/types/common'

/**
 * 用户类型（对应后端 Takt.Application.Dtos.Identity.TaktUserDto）
 */
export interface User extends TaktEntityBase {
  /** 用户ID（对应后端 UserId，序列化为string以避免Javascript精度问题） */
  userId: string
  /** 用户名 */
  userName: string
  /** 真实姓名 */
  realName: string
  /** 全名 */
  fullName: string
  /** 昵称 */
  nickName: string
  /** 英文名称 */
  englishName: string
  /** 头像 */
  avatar?: string
  /** 性别（0=未知，1=男，2=女） */
  gender: number
  /** 用户类型（0=普通用户，1=管理员，2=超级管理员） */
  userType: number
  /** 用户邮箱 */
  userEmail: string
  /** 用户手机号 */
  userPhone: string
  /** 登录次数 */
  loginCount: number
  /** 锁定原因 */
  lockReason?: string
  /** 锁定时间 */
  lockTime?: string
  /** 锁定人（用户名） */
  lockBy?: string
  /** 错误次数限制（登录错误次数上限，超过则锁定） */
  errorLimit: number
  /** 用户状态（0=启用，1=禁用，3=锁定） */
  userStatus: number
  /** 角色ID列表 */
  roleIds?: string[]
  /** 部门ID列表 */
  deptIds?: string[]
  /** 岗位ID列表 */
  postIds?: string[]
  /** 租户ID列表 */
  tenantIds?: string[]
}

/**
 * 用户查询类型（对应后端 Takt.Application.Dtos.Identity.TaktUserQueryDto）
 */
export interface UserQuery extends TaktPagedQuery {
  /** 关键词（在用户名、真实姓名、邮箱、手机号中模糊查询） */
  keyWords?: string
  /** 用户名 */
  userName?: string
  /** 真实姓名 */
  realName?: string
  /** 用户邮箱 */
  userEmail?: string
  /** 用户手机号 */
  userPhone?: string
  /** 用户状态（0=启用，1=禁用，3=锁定） */
  userStatus?: number
}

/**
 * 创建用户类型（对应后端 Takt.Application.Dtos.Identity.TaktUserCreateDto）
 */
export interface UserCreate {
  /** 用户名 */
  userName: string
  /** 真实姓名 */
  realName: string
  /** 全名 */
  fullName: string
  /** 昵称 */
  nickName: string
  /** 英文名称 */
  englishName: string
  /** 头像 */
  avatar?: string
  /** 性别（0=未知，1=男，2=女） */
  gender: number
  /** 用户类型（0=普通用户，1=管理员，2=超级管理员） */
  userType: number
  /** 用户邮箱 */
  userEmail: string
  /** 用户手机号 */
  userPhone: string
  /** 密码哈希 */
  passwordHash: string
  /** 用户状态（0=启用，1=禁用，3=锁定，默认值为0=启用） */
  userStatus?: number
  /** 角色ID列表 */
  roleIds?: string[]
  /** 部门ID列表 */
  deptIds?: string[]
  /** 岗位ID列表 */
  postIds?: string[]
  /** 租户ID列表 */
  tenantIds?: string[]
  /** 备注 */
  remark?: string
}

/**
 * 更新用户类型（对应后端 Takt.Application.Dtos.Identity.TaktUserUpdateDto）
 */
export interface UserUpdate extends UserCreate {
  /** 用户ID（对应后端 UserId，序列化为string以避免Javascript精度问题） */
  userId: string
}

/**
 * 用户状态类型（对应后端 Takt.Application.Dtos.Identity.TaktUserStatusDto）
 */
export interface UserStatus {
  /** 用户ID（对应后端 UserId，序列化为string以避免Javascript精度问题） */
  userId: string
  /** 用户状态（0=启用，1=禁用，3=锁定） */
  userStatus: number
}

/**
 * 重置密码类型（对应后端 Takt.Application.Dtos.Identity.TaktUserResetPwdDto）
 * 注意：重置密码功能只使用配置中的默认密码（PasswordPolicy:DefaultPassword），
 * 前端不需要传递 newPassword 参数，后端会忽略该参数并从配置中读取默认密码
 */
export interface UserResetPwd {
  /** 用户ID（对应后端 UserId，序列化为string以避免Javascript精度问题） */
  userId: string
  /** 新密码（可选，重置密码功能不使用此参数，后端会从配置中读取默认密码） */
  newPassword?: string
}

/**
 * 修改密码类型（对应后端 Takt.Application.Dtos.Identity.TaktUserChangePwdDto）
 */
export interface UserChangePwd {
  /** 旧密码 */
  oldPassword: string
  /** 新密码 */
  newPassword: string
}

/**
 * 忘记密码类型（对应后端 Takt.Application.Dtos.Identity.TaktUserForgotPasswordDto）
 */
export interface UserForgotPassword {
  /** 用户邮箱 */
  userEmail: string
}

/**
 * 解锁用户类型（对应后端 Takt.Application.Dtos.Identity.TaktUserUnlockDto）
 */
export interface UserUnlock {
  /** 用户ID（对应后端 UserId，序列化为string以避免Javascript精度问题） */
  userId: string
  /** 用户状态（0=禁用，1=启用，3=锁定，解锁时设置为0） */
  userStatus: number
}

/**
 * 用户头像更新类型（对应后端 Takt.Application.Dtos.Identity.TaktUserAvatarUpdateDto）
 */
export interface UserAvatarUpdate {
  /** 用户ID（对应后端 UserId，序列化为string以避免Javascript精度问题） */
  userId: string
  /** 头像 */
  avatar?: string
}

/**
 * 用户分配角色类型（对应后端 Takt.Application.Dtos.Identity.TaktUserAssignRolesDto）
 */
export interface UserAssignRoles {
  /** 用户ID（对应后端 UserId，序列化为string以避免Javascript精度问题） */
  userId: string
  /** 角色ID列表 */
  roleIds: string[]
}

/**
 * 用户分配部门类型（对应后端 Takt.Application.Dtos.Identity.TaktUserAssignDeptsDto）
 */
export interface UserAssignDepts {
  /** 用户ID（对应后端 UserId，序列化为string以避免Javascript精度问题） */
  userId: string
  /** 部门ID列表 */
  deptIds: string[]
}

/**
 * 用户分配岗位类型（对应后端 Takt.Application.Dtos.Identity.TaktUserAssignPostsDto）
 */
export interface UserAssignPosts {
  /** 用户ID（对应后端 UserId，序列化为string以避免Javascript精度问题） */
  userId: string
  /** 岗位ID列表 */
  postIds: string[]
}

/**
 * 用户分配租户类型（对应后端 Takt.Application.Dtos.Identity.TaktUserAssignTenantsDto）
 */
export interface UserAssignTenants {
  /** 用户ID（对应后端 UserId，序列化为string以避免Javascript精度问题） */
  userId: string
  /** 租户ID列表 */
  tenantIds: string[]
}
