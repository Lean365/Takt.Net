// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：Takt.Domain.Entities.Logistics
// 文件名称：TaktPlant.cs
// 创建时间：2025-01-20
// 创建人：Takt365(Cursor AI)
// 功能描述：Takt工厂实体，定义工厂领域模型
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using SqlSugar;
using Takt.Domain.Entities;

namespace Takt.Domain.Entities.Logistics.Materials;

/// <summary>
/// Takt工厂实体
/// </summary>
[SugarTable("takt_logistics_materials_plant", "工厂表")]
[SugarIndex("ix_takt_logistics_materials_plant_plant_code", nameof(PlantCode), OrderByType.Asc, true)]
[SugarIndex("ix_takt_logistics_materials_plant_company_code", nameof(CompanyCode), OrderByType.Asc)]
[SugarIndex("ix_takt_logistics_materials_plant_config_id", nameof(ConfigId), OrderByType.Asc)]
[SugarIndex("ix_takt_logistics_materials_plant_is_deleted", nameof(IsDeleted), OrderByType.Asc)]
[SugarIndex("ix_takt_logistics_materials_plant_plant_status", nameof(PlantStatus), OrderByType.Asc)]
public class TaktPlant : TaktEntityBase
{
    /// <summary>
    /// 公司代码
    /// </summary>
    [SugarColumn(ColumnName = "company_code", ColumnDescription = "公司代码", ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
    public string? CompanyCode { get; set; }

    /// <summary>
    /// 工厂代码（唯一索引）
    /// </summary>
    [SugarColumn(ColumnName = "plant_code", ColumnDescription = "工厂代码", ColumnDataType = "nvarchar", Length = 50, IsNullable = false)]
    public string PlantCode { get; set; } = string.Empty;

    /// <summary>
    /// 工厂名称
    /// </summary>
    [SugarColumn(ColumnName = "plant_name", ColumnDescription = "工厂名称", ColumnDataType = "nvarchar", Length = 200, IsNullable = false)]
    public string PlantName { get; set; } = string.Empty;

    /// <summary>
    /// 工厂简称
    /// </summary>
    [SugarColumn(ColumnName = "plant_short_name", ColumnDescription = "工厂简称", ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
    public string? PlantShortName { get; set; }

    /// <summary>
    /// 工厂地址
    /// </summary>
    [SugarColumn(ColumnName = "plant_address", ColumnDescription = "工厂地址", ColumnDataType = "nvarchar", Length = 500, IsNullable = true)]
    public string? PlantAddress { get; set; }

    /// <summary>
    /// 工厂电话
    /// </summary>
    [SugarColumn(ColumnName = "plant_phone", ColumnDescription = "工厂电话", ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
    public string? PlantPhone { get; set; }

    /// <summary>
    /// 工厂邮箱
    /// </summary>
    [SugarColumn(ColumnName = "plant_email", ColumnDescription = "工厂邮箱", ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
    public string? PlantEmail { get; set; }

    /// <summary>
    /// 工厂负责人
    /// </summary>
    [SugarColumn(ColumnName = "plant_manager", ColumnDescription = "工厂负责人", ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
    public string? PlantManager { get; set; }

    /// <summary>
    /// 工厂状态（0=启用，1=禁用）
    /// </summary>
    [SugarColumn(ColumnName = "plant_status", ColumnDescription = "工厂状态", ColumnDataType = "int", IsNullable = false, DefaultValue = "0")]
    public int PlantStatus { get; set; } = 0;

    /// <summary>
    /// 排序号（越小越靠前）
    /// </summary>
    [SugarColumn(ColumnName = "order_num", ColumnDescription = "排序号", ColumnDataType = "int", IsNullable = false, DefaultValue = "0")]
    public int OrderNum { get; set; } = 0;
}
