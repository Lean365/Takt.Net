// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：@/types/routine/i18n/translation
// 文件名称：translation.d.ts
// 创建时间：2025-01-20
// 创建人：Takt365(Cursor AI)
// 功能描述：翻译类型定义，对应后端 Takt.Application.Dtos.Routine.i18n.TaktTranslationDtos
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

import type { TaktEntityBase, TaktPagedQuery, TaktPagedResult, TaktSelectOption } from '@/types/common'

/**
 * 翻译（对应后端 TaktTranslationDto，主表）
 */
export interface Translation extends TaktEntityBase {
  /** 翻译ID */
  translationId: string
  /** 资源键（如：UserNotFound、OperationSuccess） */
  resourceKey: string
  /** 语言ID（外键，关联语言/子表，对应后端 LanguageId，序列化为string以避免Javascript精度问题） */
  languageId: string
  /** 语言编码（ISO 639-1/639-2，如：zh-CN、en-US） */
  cultureCode: string
  /** 翻译值（该语言下的文本内容） */
  translationValue: string
  /** 资源类型（Frontend=前端，Backend=后端） */
  resourceType: string
  /** 资源分组（如：Validation、Error、Success，用于进一步分类） */
  resourceGroup?: string
  /** 排序号（越小越靠前） */
  orderNum: number
}

/**
 * 翻译查询（对应后端 TaktTranslationQueryDto）
 */
export interface TranslationQuery extends TaktPagedQuery {
  /** 关键词（在资源键、翻译值中模糊查询） */
  keyWords?: string
  /** 语言ID（外键，关联语言，对应后端 LanguageId，序列化为string以避免Javascript精度问题） */
  languageId?: string
  /** 资源键 */
  resourceKey?: string
  /** 语言编码 */
  cultureCode?: string
  /** 资源类型（Frontend=前端，Backend=后端） */
  resourceType?: string
  /** 资源分组 */
  resourceGroup?: string
}

/**
 * 翻译创建（对应后端 TaktTranslationCreateDto）
 */
export interface TranslationCreate {
  /** 资源键（如：UserNotFound、OperationSuccess） */
  resourceKey: string
  /** 语言ID（外键，关联语言，对应后端 LanguageId，序列化为string以避免Javascript精度问题） */
  languageId: string
  /** 语言编码（ISO 639-1/639-2，如：zh-CN、en-US） */
  cultureCode: string
  /** 翻译值（该语言下的文本内容） */
  translationValue: string
  /** 资源类型（Frontend=前端，Backend=后端） */
  resourceType: string
  /** 资源分组（如：Validation、Error、Success，用于进一步分类） */
  resourceGroup?: string
  /** 排序号（越小越靠前） */
  orderNum: number
  /** 备注 */
  remark?: string
}

/**
 * 翻译更新（对应后端 TaktTranslationUpdateDto）
 */
export interface TranslationUpdate extends TranslationCreate {
  /** 翻译ID */
  translationId: string
}

/**
 * 翻译转置行（对应后端 TaktTranslationTransposedDto）
 */
export interface TranslationTransposed {
  /** 资源键 */
  resourceKey: string
  /** 资源类型 */
  resourceType: string
  /** 资源分组 */
  resourceGroup?: string
  /** 排序号 */
  orderNum: number
  /** 各语言翻译值，key 为 CultureCode，value 为 TranslationValue */
  translations: Record<string, string>
}

/**
 * 翻译转置接口结果（对应后端 TaktTranslationTransposedResult）
 */
export interface TranslationTransposedResult {
  /** 分页数据 */
  paged: TaktPagedResult<TranslationTransposed>
  /** 语言列顺序（表头从左到右） */
  cultureCodeOrder: string[]
}
