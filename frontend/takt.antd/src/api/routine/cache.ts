import request from '../request'

/** 缓存配置信息（不含敏感信息） */
export interface CacheInfoDto {
  provider: string
  defaultExpirationMinutes: number
  enableSlidingExpiration: boolean
  enableMultiLevelCache: boolean
  redisEnabled: boolean
  redisInstanceName: string
}

/** 缓存键存在检查结果 */
export interface CacheExistsDto {
  key: string
  exists: boolean
}

/** 缓存统计信息（仅 Memory 支持） */
export interface CacheStatisticsDto {
  supported: boolean
  message?: string
  totalHits?: number
  totalMisses?: number
  currentEntryCount?: number
  currentEstimatedSizeBytes?: number | null
  hitRate?: number | null
}

/** 获取缓存配置信息 */
export function getCacheInfo() {
  return request({
    url: '/api/TaktCache/info',
    method: 'get'
  })
}

/** 检查指定缓存键是否存在 */
export function existsCacheKey(key: string) {
  return request({
    url: '/api/TaktCache/exists',
    method: 'get',
    params: { key }
  })
}

/** 移除指定缓存键 */
export function removeCacheKey(key: string) {
  return request({
    url: '/api/TaktCache',
    method: 'delete',
    params: { key }
  })
}

/** 获取缓存统计信息（总数、命中率等，仅 Memory 提供者支持） */
export function getCacheStatistics() {
  return request({
    url: '/api/TaktCache/statistics',
    method: 'get'
  })
}
