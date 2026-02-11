// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：Takt.Domain.Entities.Logistics.Sales
// 文件名称：TaktSalesPriceHistory.cs
// 创建时间：2025-01-20
// 创建人：Takt365(Cursor AI)
// 功能描述：Takt销售价格变更记录实体，定义销售价格变更记录领域模型
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using SqlSugar;
using Takt.Domain.Entities;

namespace Takt.Domain.Entities.Logistics.Sales;

/// <summary>
/// Takt销售价格变更记录实体
/// </summary>
[SugarTable("takt_logistics_sales_price_history", "销售价格变更记录表")]
[SugarIndex("ix_takt_logistics_sales_price_history_price_id", nameof(PriceId), OrderByType.Asc)]
[SugarIndex("ix_takt_logistics_sales_price_history_change_time", nameof(ChangeTime), OrderByType.Desc)]
[SugarIndex("ix_takt_logistics_sales_price_history_change_user_id", nameof(ChangeUserId), OrderByType.Asc)]
[SugarIndex("ix_takt_logistics_sales_price_history_config_id", nameof(ConfigId), OrderByType.Asc)]
[SugarIndex("ix_takt_logistics_sales_price_history_is_deleted", nameof(IsDeleted), OrderByType.Asc)]
public class TaktSalesPriceHistory : TaktEntityBase
{
    /// <summary>
    /// 价格ID（关联销售价格表，序列化为string以避免Javascript精度问题）
    /// </summary>
    [SugarColumn(ColumnName = "price_id", ColumnDescription = "价格ID", ColumnDataType = "bigint", IsNullable = false)]
    [JsonConverter(typeof(ValueToStringConverter))]
    public long PriceId { get; set; }

    /// <summary>
    /// 原价格（精确到分，存储为整数，单位为分）
    /// </summary>
    [SugarColumn(ColumnName = "old_price", ColumnDescription = "原价格", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, IsNullable = false, DefaultValue = "0")]
    public decimal OldPrice { get; set; } = 0;

    /// <summary>
    /// 新价格（精确到分，存储为整数，单位为分）
    /// </summary>
    [SugarColumn(ColumnName = "new_price", ColumnDescription = "新价格", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, IsNullable = false, DefaultValue = "0")]
    public decimal NewPrice { get; set; } = 0;

    /// <summary>
    /// 变更时间
    /// </summary>
    [SugarColumn(ColumnName = "change_time", ColumnDescription = "变更时间", ColumnDataType = "datetime", IsNullable = false)]
    public DateTime ChangeTime { get; set; } = DateTime.Now;

    /// <summary>
    /// 变更人ID（序列化为string以避免Javascript精度问题）
    /// </summary>
    [SugarColumn(ColumnName = "change_user_id", ColumnDescription = "变更人ID", ColumnDataType = "bigint", IsNullable = false)]
    [JsonConverter(typeof(ValueToStringConverter))]
    public long ChangeUserId { get; set; }

    /// <summary>
    /// 变更人姓名
    /// </summary>
    [SugarColumn(ColumnName = "change_user_name", ColumnDescription = "变更人姓名", ColumnDataType = "nvarchar", Length = 50, IsNullable = false)]
    public string ChangeUserName { get; set; } = string.Empty;

    /// <summary>
    /// 变更原因
    /// </summary>
    [SugarColumn(ColumnName = "change_reason", ColumnDescription = "变更原因", ColumnDataType = "nvarchar", Length = 500, IsNullable = true)]
    public string? ChangeReason { get; set; }
}
