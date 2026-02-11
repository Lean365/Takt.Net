// ========================================
// 项目名称：节拍数字工厂 · Takt Digital Factory (TDF)
// 命名空间：Takt.Domain.Entities.Accounting.Financial
// 文件名称：TaktTestCs3.cs
// 创建时间：2025-02-02
// 创建人：系统管理员
// 功能描述：测试实体
//
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using SqlSugar;
using Takt.Domain.Entities;

namespace Takt.Domain.Entities.Accounting.Financial;

/// <summary>
/// 测试实体
/// </summary>
[SugarTable("takt_test_cs3", "测试")]
public class TaktTestCs3 : TaktEntityBase
{


    /// <summary>
    /// Column1
    /// </summary>
    [SugarColumn(ColumnName = "column_1", ColumnDescription = "Column1", ColumnDataType = "nvarchar", Length = 64, IsNullable = false)]
    public string Column1 { get; set; }



    /// <summary>
    /// Column2
    /// </summary>
    [SugarColumn(ColumnName = "column_2", ColumnDescription = "Column2", ColumnDataType = "nvarchar", Length = 64, IsNullable = false)]
    public string Column2 { get; set; }



    /// <summary>
    /// Column3
    /// </summary>
    [SugarColumn(ColumnName = "column_3", ColumnDescription = "Column3", ColumnDataType = "nvarchar", Length = 64, IsNullable = false)]
    public string Column3 { get; set; }



    /// <summary>
    /// Column4
    /// </summary>
    [SugarColumn(ColumnName = "column_4", ColumnDescription = "Column4", ColumnDataType = "nvarchar", Length = 64, IsNullable = false)]
    public string Column4 { get; set; }



    /// <summary>
    /// Column5
    /// </summary>
    [SugarColumn(ColumnName = "column_5", ColumnDescription = "Column5", ColumnDataType = "nvarchar", Length = 64, IsNullable = false)]
    public string Column5 { get; set; }



    /// <summary>
    /// Column6
    /// </summary>
    [SugarColumn(ColumnName = "column_6", ColumnDescription = "Column6", ColumnDataType = "int", Length = 0, IsNullable = false)]
    public int Column6 { get; set; }



    /// <summary>
    /// Column7
    /// </summary>
    [SugarColumn(ColumnName = "column_7", ColumnDescription = "Column7", ColumnDataType = "nvarchar", Length = 64, IsNullable = false)]
    public string Column7 { get; set; }



    /// <summary>
    /// Column8
    /// </summary>
    [SugarColumn(ColumnName = "column_8", ColumnDescription = "Column8", ColumnDataType = "nvarchar", Length = 64, IsNullable = false)]
    public string Column8 { get; set; }


}
