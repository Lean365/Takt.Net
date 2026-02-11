// ========================================
// 项目名称：节拍数字工厂 · Takt Digital Factory (TDF)
// 命名空间：Takt.Application.Dtos.Accounting.Financial
// 文件名称：TaktTestCs3Dtos.cs
// 创建时间：2025-02-02
// 创建人：系统管理员
// 功能描述：测试DTO，由 DtoCategory 配置驱动，按 type 判断输出
//
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using SqlSugar;
using Takt.Shared.Models;

namespace Takt.Application.Dtos.Accounting.Financial;



/// <summary>
/// 测试Dto
/// </summary>
public class TaktTestCs3Dto
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public TaktTestCs3Dto()
    {
    }

    /// <summary>
    /// 测试ID（适配字段，序列化为string以避免Javascript精度问题）
    /// </summary>
    [AdaptMember("Id")][JsonConverter(typeof(SqlSugar.ValueToStringConverter))]
    public long TestCs3Id { get; set; }



    /// <summary>
    /// Column1
    /// </summary>
    public string Column1 { get; set; } = string.Empty;




    /// <summary>
    /// Column2
    /// </summary>
    public string Column2 { get; set; } = string.Empty;




    /// <summary>
    /// Column3
    /// </summary>
    public string Column3 { get; set; } = string.Empty;




    /// <summary>
    /// Column4
    /// </summary>
    public string Column4 { get; set; } = string.Empty;




    /// <summary>
    /// Column5
    /// </summary>
    public string Column5 { get; set; } = string.Empty;




    /// <summary>
    /// Column6
    /// </summary>
    public int Column6 { get; set; }




    /// <summary>
    /// Column7
    /// </summary>
    public string Column7 { get; set; } = string.Empty;




    /// <summary>
    /// Column8
    /// </summary>
    public string Column8 { get; set; } = string.Empty;



}



/// <summary>
/// 测试QueryDto
/// </summary>
public class TaktTestCs3QueryDto : TaktPagedQuery
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public TaktTestCs3QueryDto()
    {
    }

    // KeyWords 属性已从基类 TaktPagedQuery 继承，用于模糊查询


















}



/// <summary>
/// 测试CreateDto
/// </summary>
public class TaktTestCs3CreateDto
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public TaktTestCs3CreateDto()
    {
    }



    /// <summary>
    /// Column1
    /// </summary>
    public string Column1 { get; set; } = string.Empty;




    /// <summary>
    /// Column2
    /// </summary>
    public string Column2 { get; set; } = string.Empty;




    /// <summary>
    /// Column3
    /// </summary>
    public string Column3 { get; set; } = string.Empty;




    /// <summary>
    /// Column4
    /// </summary>
    public string Column4 { get; set; } = string.Empty;




    /// <summary>
    /// Column5
    /// </summary>
    public string Column5 { get; set; } = string.Empty;




    /// <summary>
    /// Column6
    /// </summary>
    public int Column6 { get; set; }




    /// <summary>
    /// Column7
    /// </summary>
    public string Column7 { get; set; } = string.Empty;




    /// <summary>
    /// Column8
    /// </summary>
    public string Column8 { get; set; } = string.Empty;



}



/// <summary>
/// 测试UpdateDto
/// </summary>
public class TaktTestCs3UpdateDto : TaktTestCs3CreateDto
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public TaktTestCs3UpdateDto()
    {
    }

    /// <summary>
    /// 测试ID（适配字段，序列化为string以避免Javascript精度问题）
    /// </summary>
    [AdaptMember("Id")][JsonConverter(typeof(SqlSugar.ValueToStringConverter))]
    public long TestCs3Id { get; set; }
}



/// <summary>
/// 测试TemplateDto
/// </summary>
public class TaktTestCs3TemplateDto
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public TaktTestCs3TemplateDto()
    {
    }



    /// <summary>
    /// Column1
    /// </summary>
    public string Column1 { get; set; } = string.Empty;




    /// <summary>
    /// Column2
    /// </summary>
    public string Column2 { get; set; } = string.Empty;




    /// <summary>
    /// Column3
    /// </summary>
    public string Column3 { get; set; } = string.Empty;




    /// <summary>
    /// Column4
    /// </summary>
    public string Column4 { get; set; } = string.Empty;




    /// <summary>
    /// Column5
    /// </summary>
    public string Column5 { get; set; } = string.Empty;




    /// <summary>
    /// Column6
    /// </summary>
    public int Column6 { get; set; }




    /// <summary>
    /// Column7
    /// </summary>
    public string Column7 { get; set; } = string.Empty;




    /// <summary>
    /// Column8
    /// </summary>
    public string Column8 { get; set; } = string.Empty;



}



/// <summary>
/// 测试ImportDto
/// </summary>
public class TaktTestCs3ImportDto
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public TaktTestCs3ImportDto()
    {
    }



    /// <summary>
    /// Column1
    /// </summary>
    public string Column1 { get; set; } = string.Empty;




    /// <summary>
    /// Column2
    /// </summary>
    public string Column2 { get; set; } = string.Empty;




    /// <summary>
    /// Column3
    /// </summary>
    public string Column3 { get; set; } = string.Empty;




    /// <summary>
    /// Column4
    /// </summary>
    public string Column4 { get; set; } = string.Empty;




    /// <summary>
    /// Column5
    /// </summary>
    public string Column5 { get; set; } = string.Empty;




    /// <summary>
    /// Column6
    /// </summary>
    public int Column6 { get; set; }




    /// <summary>
    /// Column7
    /// </summary>
    public string Column7 { get; set; } = string.Empty;




    /// <summary>
    /// Column8
    /// </summary>
    public string Column8 { get; set; } = string.Empty;



}



/// <summary>
/// 测试ExportDto
/// </summary>
public class TaktTestCs3ExportDto
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public TaktTestCs3ExportDto()
    {
    }



    /// <summary>
    /// Column1
    /// </summary>
    public string Column1 { get; set; } = string.Empty;




    /// <summary>
    /// Column2
    /// </summary>
    public string Column2 { get; set; } = string.Empty;




    /// <summary>
    /// Column3
    /// </summary>
    public string Column3 { get; set; } = string.Empty;




    /// <summary>
    /// Column4
    /// </summary>
    public string Column4 { get; set; } = string.Empty;




    /// <summary>
    /// Column5
    /// </summary>
    public string Column5 { get; set; } = string.Empty;




    /// <summary>
    /// Column6
    /// </summary>
    public int Column6 { get; set; }




    /// <summary>
    /// Column7
    /// </summary>
    public string Column7 { get; set; } = string.Empty;




    /// <summary>
    /// Column8
    /// </summary>
    public string Column8 { get; set; } = string.Empty;



}


