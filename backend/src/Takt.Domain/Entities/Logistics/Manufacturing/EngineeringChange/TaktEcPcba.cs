// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF)
// 命名空间：Takt.Domain.Entities.Logistics.Manufacturing.Ecn
// 文件名称：TaktEcnManufacturing2.cs
// 创建时间：2025-02-02
// 创建人：Takt365(Cursor AI)
// 功能描述：设变-制造二课实体
//
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using SqlSugar;
using Takt.Domain.Entities;

namespace Takt.Domain.Entities.Logistics.Manufacturing.EngineeringChange;

/// <summary>
/// 设变-制造二课实体
/// </summary>
[SugarTable("takt_logistics_manufacturing_ecn_pcba", "设变制造二课表")]
[SugarIndex("ix_takt_logistics_manufacturing_ecn_pcba_ecn_detail_id", nameof(EcnDetailId), OrderByType.Asc)]
[SugarIndex("ix_takt_logistics_manufacturing_ecn_pcba_config_id", nameof(ConfigId), OrderByType.Asc)]
[SugarIndex("ix_takt_logistics_manufacturing_ecn_pcba_is_deleted", nameof(IsDeleted), OrderByType.Asc)]
public class TaktEcPcba : TaktEntityBase
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
    /// 生产日期
    /// </summary>
    [SugarColumn(ColumnName = "production_date", ColumnDescription = "生产日期", ColumnDataType = "date", IsNullable = true)]
    public DateTime? ProductionDate { get; set; }

    /// <summary>
    /// 生产批次
    /// </summary>
    [SugarColumn(ColumnName = "production_batch", ColumnDescription = "生产批次", Length = 100, ColumnDataType = "nvarchar", IsNullable = true)]
    public string? ProductionBatch { get; set; }

    /// <summary>
    /// 出库单号
    /// </summary>
    [SugarColumn(ColumnName = "outbound_order_no", ColumnDescription = "出库单号", Length = 100, ColumnDataType = "nvarchar", IsNullable = true)]
    public string? OutboundOrderNo { get; set; }

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
