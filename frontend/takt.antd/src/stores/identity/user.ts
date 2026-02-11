import { defineStore } from 'pinia'
import { ref } from 'vue'
import { login, getUserInfo, logout as logoutApi } from '@/api/identity/auth'
import type { LoginParams, UserInfo } from '@/types/identity/auth'

export const useUserStore = defineStore('user', () => {
  const token = ref<string | null>(localStorage.getItem('token'))
  const refreshToken = ref<string | null>(localStorage.getItem('refreshToken'))
  const userInfo = ref<UserInfo | null>(null)

  // 登录
  const loginAction = async (params: LoginParams) => {
    try {
      logger.info('[User Store] 开始登录，用户名:', params.username)
      const data = await login(params)
      token.value = data.token
      if (data.refreshToken) {
        refreshToken.value = data.refreshToken
        localStorage.setItem('refreshToken', data.refreshToken)
      }
      localStorage.setItem('token', data.token)
      
      // 保存 token 过期时间（用于定时刷新）
      if (data.expiresIn) {
        const expiresAt = Date.now() + data.expiresIn * 1000
        localStorage.setItem('tokenExpiresAt', expiresAt.toString())
        logger.debug('[User Store] Token 过期时间已保存:', new Date(expiresAt).toLocaleString())
      }
      
      // 启动 token 自动刷新定时器
      if (typeof window !== 'undefined') {
        // 动态导入 request.ts 以启动定时器
        import('@/api/request').then(() => {
          logger.debug('[User Store] Token 刷新定时器已启动')
        })
      }
      
      logger.info('[User Store] 登录成功，用户名:', params.username, '用户ID:', data.userInfo?.userId)
      return data
    } catch (error: any) {
      logger.error('[User Store] 登录失败，用户名:', params.username, '错误:', error.message || error)
      throw error
    }
  }

  // 获取用户信息
  const getUserInfoAction = async () => {
    if (!token.value) {
      throw new Error('未登录')
    }
    const info = await getUserInfo()
    userInfo.value = info
    if (import.meta.env.DEV) {
      logger.debug('[User Store] 获取用户信息成功:', {
        userId: info.userId,
        userName: info.userName,
        roles: info.roles,
        permissions: info.permissions,
        permissionsCount: info.permissions?.length || 0
      })
    }
    return info
  }

  // 登出
  const logout = async () => {
    const currentUser = userInfo.value?.userName || '未知用户'
    logger.info('[User Store] 开始退出登录，用户:', currentUser)
    
    try {
      // 发送 refreshToken 给后端（如果存在）
      if (refreshToken.value) {
        try {
          await logoutApi(refreshToken.value)
          logger.info('[User Store] 退出登录成功，用户:', currentUser, '后端已处理登出请求')
        } catch (error: any) {
          logger.error('[User Store] 退出登录失败，用户:', currentUser, '后端登出失败:', error.message || error)
          // 即使后端登出失败，也继续清理本地状态
        }
      } else {
        logger.warn('[User Store] 退出登录，用户:', currentUser, '没有 refreshToken，跳过后端登出')
      }
    } catch (error: any) {
      logger.error('[User Store] 退出登录异常，用户:', currentUser, '错误:', error.message || error)
      // 即使后端登出失败，也继续清理本地状态
    } finally {
      // 先清除路由（需要在清除 store 之前）
      try {
        const { clearDynamicRoutes } = await import('@/router')
        clearDynamicRoutes()
        if (import.meta.env.DEV) {
          logger.debug('[User Store] 退出登录：已清除动态路由')
        }
      } catch (error) {
        logger.error('[User Store] 清除路由失败:', error)
      }
      
      // 清除用户信息
      token.value = null
      refreshToken.value = null
      userInfo.value = null
      localStorage.removeItem('token')
      localStorage.removeItem('refreshToken')
      
      // 重置菜单路由（清除菜单和路由状态）
      const { useMenuStore } = await import('./menu')
      const menuStore = useMenuStore()
      menuStore.reset()
      
      // 重置权限状态
      const { usePermissionStore } = await import('./permission')
      const permissionStore = usePermissionStore()
      permissionStore.reset()
      
      // 断开 SignalR 连接
      try {
        const { useSignalRStore } = await import('./signalr')
        const signalRStore = useSignalRStore()
        if (signalRStore.isConnected) {
          await signalRStore.disconnect()
          logger.info('[User Store] 退出登录：已断开 SignalR 连接')
        }
      } catch (error: any) {
        logger.error('[User Store] 断开 SignalR 连接失败:', error.message || error)
        // SignalR 断开失败不影响退出登录流程
      }
    }
  }

  return {
    token,
    refreshToken,
    userInfo,
    login: loginAction,
    getUserInfo: getUserInfoAction,
    logout
  }
})
