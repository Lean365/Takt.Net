// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：Takt.Domain.Entities.Accounting.Financial
// 文件名称：TaktCompany.cs
// 创建时间：2025-01-20
// 创建人：Takt365(Cursor AI)
// 功能描述：Takt公司实体，定义公司领域模型
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using SqlSugar;
using Takt.Domain.Entities;

namespace Takt.Domain.Entities.Accounting.Financial;

/// <summary>
/// Takt公司实体
/// </summary>
[SugarTable("takt_accounting_financial_company", "公司表")]
[SugarIndex("ix_takt_accounting_financial_company_company_code", nameof(CompanyCode), OrderByType.Asc, true)]
[SugarIndex("ix_takt_accounting_financial_company_config_id", nameof(ConfigId), OrderByType.Asc)]
[SugarIndex("ix_takt_accounting_financial_company_is_deleted", nameof(IsDeleted), OrderByType.Asc)]
[SugarIndex("ix_takt_accounting_financial_company_company_status", nameof(CompanyStatus), OrderByType.Asc)]
public class TaktCompany : TaktEntityBase
{
    /// <summary>
    /// 公司代码（唯一索引）
    /// </summary>
    [SugarColumn(ColumnName = "company_code", ColumnDescription = "公司代码", ColumnDataType = "nvarchar", Length = 50, IsNullable = false)]
    public string CompanyCode { get; set; } = string.Empty;

    /// <summary>
    /// 公司名称
    /// </summary>
    [SugarColumn(ColumnName = "company_name", ColumnDescription = "公司名称", ColumnDataType = "nvarchar", Length = 200, IsNullable = false)]
    public string CompanyName { get; set; } = string.Empty;

    /// <summary>
    /// 公司简称
    /// </summary>
    [SugarColumn(ColumnName = "company_short_name", ColumnDescription = "公司简称", ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
    public string? CompanyShortName { get; set; }

    /// <summary>
    /// 公司地址
    /// </summary>
    [SugarColumn(ColumnName = "company_address", ColumnDescription = "公司地址", ColumnDataType = "nvarchar", Length = 500, IsNullable = true)]
    public string? CompanyAddress { get; set; }

    /// <summary>
    /// 公司电话
    /// </summary>
    [SugarColumn(ColumnName = "company_phone", ColumnDescription = "公司电话", ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
    public string? CompanyPhone { get; set; }

    /// <summary>
    /// 公司邮箱
    /// </summary>
    [SugarColumn(ColumnName = "company_email", ColumnDescription = "公司邮箱", ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
    public string? CompanyEmail { get; set; }

    /// <summary>
    /// 公司传真
    /// </summary>
    [SugarColumn(ColumnName = "company_fax", ColumnDescription = "公司传真", ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
    public string? CompanyFax { get; set; }

    /// <summary>
    /// 公司网站
    /// </summary>
    [SugarColumn(ColumnName = "company_website", ColumnDescription = "公司网站", ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
    public string? CompanyWebsite { get; set; }

    /// <summary>
    /// 统一社会信用代码
    /// </summary>
    [SugarColumn(ColumnName = "unified_social_credit_code", ColumnDescription = "统一社会信用代码", ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
    public string? UnifiedSocialCreditCode { get; set; }

    /// <summary>
    /// 税务登记号
    /// </summary>
    [SugarColumn(ColumnName = "tax_registration_number", ColumnDescription = "税务登记号", ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
    public string? TaxRegistrationNumber { get; set; }

    /// <summary>
    /// 法定代表人
    /// </summary>
    [SugarColumn(ColumnName = "legal_representative", ColumnDescription = "法定代表人", ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
    public string? LegalRepresentative { get; set; }

    /// <summary>
    /// 公司负责人
    /// </summary>
    [SugarColumn(ColumnName = "company_manager", ColumnDescription = "公司负责人", ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
    public string? CompanyManager { get; set; }

    /// <summary>
    /// 注册资本（精确到分，存储为整数，单位为分）
    /// </summary>
    [SugarColumn(ColumnName = "registered_capital", ColumnDescription = "注册资本", ColumnDataType = "decimal", Length = 18, DecimalDigits = 2, IsNullable = false, DefaultValue = "0")]
    public decimal RegisteredCapital { get; set; } = 0;

    /// <summary>
    /// 成立日期
    /// </summary>
    [SugarColumn(ColumnName = "establishment_date", ColumnDescription = "成立日期", ColumnDataType = "datetime", IsNullable = true)]
    public DateTime? EstablishmentDate { get; set; }

    /// <summary>
    /// 公司状态（0=启用，1=禁用）
    /// </summary>
    [SugarColumn(ColumnName = "company_status", ColumnDescription = "公司状态", ColumnDataType = "int", IsNullable = false, DefaultValue = "0")]
    public int CompanyStatus { get; set; } = 0;

    /// <summary>
    /// 排序号（越小越靠前）
    /// </summary>
    [SugarColumn(ColumnName = "order_num", ColumnDescription = "排序号", ColumnDataType = "int", IsNullable = false, DefaultValue = "0")]
    public int OrderNum { get; set; } = 0;
}
