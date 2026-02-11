// ========================================
// 项目名称：节拍数字工厂 · Takt Digital Factory (TDF)
// 命名空间：Takt.Domain.Entities.Accounting.Controlling
// 文件名称：TaktAccountingControllingStandardWageRate.cs
// 创建时间：2025-02-02
// 创建人：Takt365
// 功能描述：标准工资率表实体
//
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using SqlSugar;
using Takt.Domain.Entities;

namespace Takt.Domain.Entities.Accounting.Controlling;

/// <summary>
/// 标准工资率表实体
/// </summary>
[SugarTable("takt_accounting_controlling_standard_wage_rate", "标准工资率表")]
public class TaktAccountingControllingStandardWageRate : TaktEntityBase
{


    /// <summary>
    /// 工厂代码
    /// </summary>
    [SugarColumn(ColumnName = "plant_code", ColumnDescription = "工厂代码", ColumnDataType = "nvarchar", Length = 8, IsNullable = false)]
    public string PlantCode { get; set; }


    /// <summary>
    /// 年月
    /// </summary>
    [SugarColumn(ColumnName = "year_month", ColumnDescription = "年月", ColumnDataType = "nvarchar", Length = 6, IsNullable = false)]
    public string YearMonth { get; set; }


    /// <summary>
    /// 工作天数
    /// </summary>
    [SugarColumn(ColumnName = "working_days", ColumnDescription = "工作天数", ColumnDataType = "decimal", Length = 8, DecimalDigits = 2, IsNullable = false)]
    public decimal WorkingDays { get; set; }


    /// <summary>
    /// 销售额
    /// </summary>
    [SugarColumn(ColumnName = "sales_amount", ColumnDescription = "销售额", ColumnDataType = "decimal", Length = 18, DecimalDigits = 4, IsNullable = false)]
    public decimal SalesAmount { get; set; }


    /// <summary>
    /// 直接人数
    /// </summary>
    [SugarColumn(ColumnName = "direct_labor_count", ColumnDescription = "直接人数", ColumnDataType = "int", Length = 10, IsNullable = false)]
    public int DirectLaborCount { get; set; }


    /// <summary>
    /// 直接工资
    /// </summary>
    [SugarColumn(ColumnName = "direct_labor_wage", ColumnDescription = "直接工资", ColumnDataType = "decimal", Length = 18, DecimalDigits = 4, IsNullable = false)]
    public decimal DirectLaborWage { get; set; }


    /// <summary>
    /// 直接加班小时
    /// </summary>
    [SugarColumn(ColumnName = "direct_overtime_hours", ColumnDescription = "直接加班小时", ColumnDataType = "decimal", Length = 18, DecimalDigits = 4, IsNullable = false)]
    public decimal DirectOvertimeHours { get; set; }


    /// <summary>
    /// 直接加班总额
    /// </summary>
    [SugarColumn(ColumnName = "direct_overtime_total", ColumnDescription = "直接加班总额", ColumnDataType = "decimal", Length = 18, DecimalDigits = 4, IsNullable = false)]
    public decimal DirectOvertimeTotal { get; set; }


    /// <summary>
    /// 直接工资率
    /// </summary>
    [SugarColumn(ColumnName = "direct_wage_rate", ColumnDescription = "直接工资率", ColumnDataType = "decimal", Length = 18, DecimalDigits = 4, IsNullable = false)]
    public decimal DirectWageRate { get; set; }


    /// <summary>
    /// 间接人数
    /// </summary>
    [SugarColumn(ColumnName = "indirect_labor_count", ColumnDescription = "间接人数", ColumnDataType = "int", Length = 10, IsNullable = false)]
    public int IndirectLaborCount { get; set; }


    /// <summary>
    /// 间接工资
    /// </summary>
    [SugarColumn(ColumnName = "indirect_labor_wage", ColumnDescription = "间接工资", ColumnDataType = "decimal", Length = 18, DecimalDigits = 4, IsNullable = false)]
    public decimal IndirectLaborWage { get; set; }


    /// <summary>
    /// 间接加班小时
    /// </summary>
    [SugarColumn(ColumnName = "indirect_overtime_hours", ColumnDescription = "间接加班小时", ColumnDataType = "decimal", Length = 18, DecimalDigits = 4, IsNullable = false)]
    public decimal IndirectOvertimeHours { get; set; }


    /// <summary>
    /// 间接加班总额
    /// </summary>
    [SugarColumn(ColumnName = "indirect_overtime_total", ColumnDescription = "间接加班总额", ColumnDataType = "decimal", Length = 18, DecimalDigits = 4, IsNullable = false)]
    public decimal IndirectOvertimeTotal { get; set; }


    /// <summary>
    /// 间接工资率
    /// </summary>
    [SugarColumn(ColumnName = "indirect_wage_rate", ColumnDescription = "间接工资率", ColumnDataType = "decimal", Length = 18, DecimalDigits = 4, IsNullable = false)]
    public decimal IndirectWageRate { get; set; }
}
