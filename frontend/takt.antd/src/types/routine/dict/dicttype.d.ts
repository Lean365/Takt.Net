// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：@/types/routine/dict/dicttype
// 文件名称：dicttype.d.ts
// 创建时间：2025-01-20
// 创建人：Takt365(Cursor AI)
// 功能描述：字典类型类型定义，对应后端 Takt.Application.Dtos.Routine.DataDict.TaktDictTypeDtos
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

import type { TaktEntityBase, TaktPagedQuery } from '@/types/common'
import type { DictData } from './dictdata'

/**
 * 字典类型（对应后端 Takt.Application.Dtos.Routine.DataDict.TaktDictTypeDto）
 */
export interface DictType extends TaktEntityBase {
  /** 字典类型ID（对应后端 DictTypeId，序列化为string以避免Javascript精度问题） */
  dictTypeId: string
  /** 字典类型编码（唯一索引，对应后端 DictTypeCode） */
  dictTypeCode: string
  /** 字典类型名称（对应后端 DictTypeName） */
  dictTypeName: string
  /** 数据源（0=系统表，1=SQL查询，对应后端 DataSource） */
  dataSource: number
  /** 数据库配置ID（当数据源为SQL查询时，指定在哪个数据库连接上执行SQL脚本，对应后端 DataConfigId） */
  dataConfigId?: string
  /** SQL脚本（当数据源为SQL查询时使用，对应后端 SqlScript） */
  sqlScript?: string
  /** 是否内置（0=是，1=否，对应后端 IsBuiltIn） */
  isBuiltIn: number
  /** 排序号（越小越靠前，对应后端 OrderNum） */
  orderNum: number
  /** 类型状态（0=启用，1=禁用，对应后端 DictTypeStatus） */
  dictTypeStatus: number
  /** 字典数据列表（主子表关系，对应后端 DictDataList） */
  dictDataList?: DictData[]
}

/**
 * 字典类型查询（对应后端 Takt.Application.Dtos.Routine.DataDict.TaktDictTypeQueryDto）
 */
export interface DictTypeQuery extends TaktPagedQuery {
  /** 关键词（在字典类型名称、字典类型编码中模糊查询，对应后端 KeyWords） */
  keyWords?: string
  /** 字典类型名称（对应后端 DictTypeName） */
  dictTypeName?: string
  /** 字典类型编码（对应后端 DictTypeCode） */
  dictTypeCode?: string
  /** 类型状态（0=启用，1=禁用，对应后端 DictTypeStatus） */
  dictTypeStatus?: number
}

/**
 * 字典类型创建（对应后端 Takt.Application.Dtos.Routine.DataDict.TaktDictTypeCreateDto）
 */
export interface DictTypeCreate {
  /** 字典类型编码（唯一索引，对应后端 DictTypeCode） */
  dictTypeCode: string
  /** 字典类型名称（对应后端 DictTypeName） */
  dictTypeName: string
  /** 数据源（0=系统表，1=SQL查询，对应后端 DataSource） */
  dataSource: number
  /** 数据库配置ID（当数据源为SQL查询时，指定在哪个数据库连接上执行SQL脚本，对应后端 DataConfigId） */
  dataConfigId?: string
  /** SQL脚本（当数据源为SQL查询时使用，对应后端 SqlScript） */
  sqlScript?: string
  /** 是否内置（0=是，1=否，对应后端 IsBuiltIn） */
  isBuiltIn: number
  /** 排序号（越小越靠前，对应后端 OrderNum） */
  orderNum: number
  /** 备注（对应后端 Remark） */
  remark?: string
  /** 字典数据列表（主子表关系，对应后端 DictDataList） */
  dictDataList?: import('./dictdata').DictDataCreate[]
}

/**
 * 字典类型更新（对应后端 Takt.Application.Dtos.Routine.DataDict.TaktDictTypeUpdateDto）
 */
export interface DictTypeUpdate extends DictTypeCreate {
  /** 字典类型ID（对应后端 DictTypeId，序列化为string以避免Javascript精度问题） */
  dictTypeId: string
}

/**
 * 字典类型状态（对应后端 Takt.Application.Dtos.Routine.DataDict.TaktDictTypeStatusDto）
 */
export interface DictTypeStatus {
  /** 字典类型ID（对应后端 DictTypeId，序列化为string以避免Javascript精度问题） */
  dictTypeId: string
  /** 类型状态（0=启用，1=禁用，对应后端 DictTypeStatus） */
  dictTypeStatus: number
}
