// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：@/api/routine/i18n/translation
// 文件名称：translation.ts
// 创建时间：2025-01-20
// 创建人：Takt365(Cursor AI)
// 功能描述：翻译管理 API，对应后端 TaktTranslationsController
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

import request from '../../request'
import type { TaktPagedResult, TaktSelectOption } from '@/types/common'
import type {
  Translation,
  TranslationQuery,
  TranslationCreate,
  TranslationUpdate,
  TranslationTransposedResult
} from '@/types/routine/i18n/translation'

/**
 * 获取翻译列表（分页）
 * @param params 查询参数
 * @returns 分页结果
 */
export function getList(params: TranslationQuery): Promise<TaktPagedResult<Translation>> {
  return request({
    url: '/api/TaktTranslations/list',
    method: 'get',
    params
  })
}

/**
 * 获取翻译列表（转置：按资源键分组，各语言为列，分页）
 * @param params 查询参数
 * @returns 分页结果与语言列顺序
 */
export function getListTransposed(params: TranslationQuery): Promise<TranslationTransposedResult> {
  return request({
    url: '/api/TaktTranslations/list/transposed',
    method: 'get',
    params
  })
}

/**
 * 根据ID获取翻译
 * @param id 翻译ID
 * @returns 翻译信息
 */
export function getById(id: string): Promise<Translation> {
  return request({
    url: `/api/TaktTranslations/${id}`,
    method: 'get'
  })
}

/**
 * 获取翻译选项列表（用于下拉框等）
 * @returns 翻译选项列表
 */
export function getOptions(): Promise<TaktSelectOption[]> {
  return request({
    url: '/api/TaktTranslations/options',
    method: 'get'
  })
}

/**
 * 创建翻译
 * @param data 创建翻译数据
 * @returns 翻译信息
 */
export function create(data: TranslationCreate): Promise<Translation> {
  return request({
    url: '/api/TaktTranslations',
    method: 'post',
    data
  })
}

/**
 * 更新翻译
 * @param id 翻译ID
 * @param data 更新翻译数据
 * @returns 翻译信息
 */
export function update(id: string, data: TranslationUpdate): Promise<Translation> {
  return request({
    url: `/api/TaktTranslations/${id}`,
    method: 'put',
    data
  })
}

/**
 * 删除翻译
 * @param id 翻译ID
 * @returns 无内容
 */
export function remove(id: string): Promise<void> {
  return request({
    url: `/api/TaktTranslations/${id}`,
    method: 'delete'
  })
}

/**
 * 获取导入模板
 * @param sheetName 工作表名称
 * @param fileName 文件名
 * @returns Excel模板文件（Blob）
 */
export function getTemplate(sheetName?: string, fileName?: string): Promise<Blob> {
  return request({
    url: '/api/TaktTranslations/template',
    method: 'get',
    params: { sheetName, fileName },
    responseType: 'blob'
  })
}

/**
 * 导入翻译
 * @param file Excel文件
 * @param sheetName 工作表名称
 * @returns 导入结果
 */
export function importTranslation(
  file: File,
  sheetName?: string
): Promise<{ success: number; fail: number; errors: string[] }> {
  const formData = new FormData()
  formData.append('file', file)
  if (sheetName) {
    formData.append('sheetName', sheetName)
  }
  return request({
    url: '/api/TaktTranslations/import',
    method: 'post',
    data: formData,
    headers: {
      'Content-Type': 'multipart/form-data'
    }
  })
}

/**
 * 导出翻译
 * @param query 翻译查询条件
 * @param sheetName 工作表名称
 * @param fileName 文件名
 * @returns Excel文件（Blob）
 */
export function exportTranslation(
  query: TranslationQuery,
  sheetName?: string,
  fileName?: string
): Promise<Blob> {
  return request({
    url: '/api/TaktTranslations/export',
    method: 'post',
    data: query,
    params: { sheetName, fileName },
    responseType: 'blob'
  })
}
