// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：@/api/routine/wordfilter
// 文件名称：wordfilter.ts
// 创建时间：2025-01-22
// 创建人：Takt365(Cursor AI)
// 功能描述：敏感词过滤相关 API，对应后端 TaktWordFiltersController
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

import request from '../request'
import type {
  CheckTextDto,
  CheckTextResultDto,
  FindWordsDto,
  FindWordsResultDto,
  ReplaceWordsDto,
  ReplaceWordsResultDto,
  HighlightWordsDto,
  HighlightWordsResultDto,
  AddWordsDto,
  AddWordsResultDto,
  RemoveWordsDto,
  RemoveWordsResultDto,
  WordFilterStatsDto,
  WordLibraryFileDto
} from '@/types/routine/wordfilter'

// ========================================
// 敏感词过滤相关 API（按后端控制器顺序）
// ========================================

/**
 * 检查文本是否包含敏感词
 * 对应后端：CheckText
 */
export function checkText(data: CheckTextDto): Promise<CheckTextResultDto> {
  return request({
    url: '/api/TaktWordFilters/check',
    method: 'post',
    data
  })
}

/**
 * 查找文本中的所有敏感词
 * 对应后端：FindWords
 */
export function findWords(data: FindWordsDto): Promise<FindWordsResultDto> {
  return request({
    url: '/api/TaktWordFilters/find',
    method: 'post',
    data
  })
}

/**
 * 替换文本中的敏感词
 * 对应后端：ReplaceWords
 */
export function replaceWords(data: ReplaceWordsDto): Promise<ReplaceWordsResultDto> {
  return request({
    url: '/api/TaktWordFilters/replace',
    method: 'post',
    data
  })
}

/**
 * 高亮文本中的敏感词
 * 对应后端：HighlightWords
 */
export function highlightWords(data: HighlightWordsDto): Promise<HighlightWordsResultDto> {
  return request({
    url: '/api/TaktWordFilters/highlight',
    method: 'post',
    data
  })
}

/**
 * 获取敏感词统计信息
 * 对应后端：GetStats
 */
export function getStats(): Promise<WordFilterStatsDto> {
  return request({
    url: '/api/TaktWordFilters/stats',
    method: 'get'
  })
}

/**
 * 获取词库文件列表（组列表）
 * 对应后端：GetWordLibraryFiles
 */
export function getWordLibraryFiles(): Promise<WordLibraryFileDto[]> {
  return request({
    url: '/api/TaktWordFilters/groups',
    method: 'get'
  })
}

/**
 * 获取所有敏感词列表
 * 对应后端：GetAllWords
 */
export function getAllWords(): Promise<string[]> {
  return request({
    url: '/api/TaktWordFilters/words',
    method: 'get'
  })
}

/**
 * 添加敏感词
 * 对应后端：AddWords
 */
export function addWords(data: AddWordsDto): Promise<AddWordsResultDto> {
  return request({
    url: '/api/TaktWordFilters/words',
    method: 'post',
    data
  })
}

/**
 * 移除敏感词
 * 对应后端：RemoveWords
 */
export function removeWords(data: RemoveWordsDto): Promise<RemoveWordsResultDto> {
  return request({
    url: '/api/TaktWordFilters/words',
    method: 'delete',
    data
  })
}

/**
 * 清空敏感词库
 * 对应后端：ClearWords
 */
export function clearWords(): Promise<void> {
  return request({
    url: '/api/TaktWordFilters/clear',
    method: 'delete'
  })
}
