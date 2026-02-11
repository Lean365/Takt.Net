// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF)
// 命名空间：Takt.Domain.Entities.Logistics.Manufacturing.Ecn
// 文件名称：TaktEcnManufacturingControl.cs
// 创建时间：2025-02-02
// 创建人：Takt365(Cursor AI)
// 功能描述：设变-生管课实体
//
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using SqlSugar;

namespace Takt.Domain.Entities.Logistics.Manufacturing.EngineeringChange;

/// <summary>
/// 设变-生管课实体
/// </summary>
[SugarTable("takt_logistics_manufacturing_ecn_pmc", "设变生管课表")]
[SugarIndex("ix_takt_logistics_manufacturing_ecn_pmc_ecn_detail_id", nameof(EcnDetailId), OrderByType.Asc)]
[SugarIndex("ix_takt_logistics_manufacturing_ecn_pmc_config_id", nameof(ConfigId), OrderByType.Asc)]
[SugarIndex("ix_takt_logistics_manufacturing_ecn_pmc_is_deleted", nameof(IsDeleted), OrderByType.Asc)]
public class TaktEcPmc : TaktEntityBase
{
    /// <summary>
    /// 设变明细ID（TaktEcnDetail 主键，序列化为string以避免Javascript精度问题）
    /// </summary>
    [SugarColumn(ColumnName = "ecn_detail_id", ColumnDescription = "设变明细ID", ColumnDataType = "bigint", IsNullable = false)]
    [JsonConverter(typeof(ValueToStringConverter))]
    public long EcnDetailId { get; set; }

    /// <summary>
    /// 是否实施（0=否 1=是）
    /// </summary>
    [SugarColumn(ColumnName = "is_implemented", ColumnDescription = "是否实施", ColumnDataType = "int", IsNullable = false, DefaultValue = "0")]
    public int IsImplemented { get; set; } = 0;

    /// <summary>
    /// 预计生产日期
    /// </summary>
    [SugarColumn(ColumnName = "scheduled_production_date", ColumnDescription = "预计生产日期", ColumnDataType = "date", IsNullable = true)]
    public DateTime? ScheduledProductionDate { get; set; }

    /// <summary>
    /// 预定批次
    /// </summary>
    [SugarColumn(ColumnName = "scheduled_batch", ColumnDescription = "预定批次", Length = 100, ColumnDataType = "nvarchar", IsNullable = true)]
    public string? ScheduledBatch { get; set; }

    /// <summary>
    /// Po残（采购订单残）
    /// </summary>
    [SugarColumn(ColumnName = "po_remainder", ColumnDescription = "Po残", Length = 200, ColumnDataType = "nvarchar", IsNullable = true)]
    public string? PoRemainder { get; set; }

    /// <summary>
    /// 结余
    /// </summary>
    [SugarColumn(ColumnName = "balance", ColumnDescription = "结余", Length = 200, ColumnDataType = "nvarchar", IsNullable = true)]
    public string? Balance { get; set; }

    /// <summary>
    /// 旧品处理
    /// </summary>
    [SugarColumn(ColumnName = "old_product_handling", ColumnDescription = "旧品处理", Length = 500, ColumnDataType = "nvarchar", IsNullable = true)]
    public string? OldProductHandling { get; set; }

    /// <summary>
    /// 内容
    /// </summary>
    [SugarColumn(ColumnName = "content", ColumnDescription = "内容", Length = 2000, ColumnDataType = "nvarchar", IsNullable = true)]
    public string? Content { get; set; }

    /// <summary>
    /// 设变明细（部门设变均为本子表的子表）
    /// </summary>
    [Navigate(NavigateType.ManyToOne, nameof(EcnDetailId))]
    public TaktEcDetail? EcnDetail { get; set; }
}
