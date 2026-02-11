// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：Takt.Domain.Entities.Workflow
// 文件名称：TaktFlowForm.cs
// 创建时间：2025-01-20
// 创建人：Takt365(Cursor AI)
// 功能描述：Takt流程表单实体，定义工作流表单领域模型
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using SqlSugar;
using Takt.Domain.Entities;

namespace Takt.Domain.Entities.Workflow;

/// <summary>
/// Takt流程表单实体
/// </summary>
[SugarTable("takt_workflow_form", "流程表单表")]
[SugarIndex("ix_takt_workflow_form_form_code", nameof(FormCode), OrderByType.Asc, true)]
[SugarIndex("ix_takt_workflow_form_form_category", nameof(FormCategory), OrderByType.Asc)]
[SugarIndex("ix_takt_workflow_form_config_id", nameof(ConfigId), OrderByType.Asc)]
[SugarIndex("ix_takt_workflow_form_is_deleted", nameof(IsDeleted), OrderByType.Asc)]
[SugarIndex("ix_takt_workflow_form_form_status", nameof(FormStatus), OrderByType.Asc)]
public class TaktFlowForm : TaktEntityBase
{
    /// <summary>
    /// 表单编码（唯一索引）
    /// </summary>
    [SugarColumn(ColumnName = "form_code", ColumnDescription = "表单编码", ColumnDataType = "nvarchar", Length = 50, IsNullable = false)]
    public string FormCode { get; set; } = string.Empty;

    /// <summary>
    /// 表单名称
    /// </summary>
    [SugarColumn(ColumnName = "form_name", ColumnDescription = "表单名称", ColumnDataType = "nvarchar", Length = 200, IsNullable = false)]
    public string FormName { get; set; } = string.Empty;

    /// <summary>
    /// 表单分类（0=通用表单，1=业务表单，2=系统表单）
    /// </summary>
    [SugarColumn(ColumnName = "form_category", ColumnDescription = "表单分类", ColumnDataType = "int", IsNullable = false, DefaultValue = "0")]
    public int FormCategory { get; set; } = 0;

    /// <summary>
    /// 表单类型（0=动态表单，1=静态表单，2=自定义表单）
    /// </summary>
    [SugarColumn(ColumnName = "form_type", ColumnDescription = "表单类型", ColumnDataType = "int", IsNullable = false, DefaultValue = "0")]
    public int FormType { get; set; } = 0;

    /// <summary>
    /// 表单配置（JSON格式，存储表单设计配置、字段定义等）
    /// </summary>
    [SugarColumn(ColumnName = "form_config", ColumnDescription = "表单配置", ColumnDataType = "nvarchar", Length = -1, IsNullable = true)]
    public string? FormConfig { get; set; }

    /// <summary>
    /// 表单模板（HTML模板或JSON模板）
    /// </summary>
    [SugarColumn(ColumnName = "form_template", ColumnDescription = "表单模板", ColumnDataType = "nvarchar", Length = -1, IsNullable = true)]
    public string? FormTemplate { get; set; }

    /// <summary>
    /// 表单版本号
    /// </summary>
    [SugarColumn(ColumnName = "form_version", ColumnDescription = "表单版本号", ColumnDataType = "nvarchar", Length = 20, IsNullable = false, DefaultValue = "1.0.0")]
    public string FormVersion { get; set; } = "1.0.0";

    /// <summary>
    /// 是否启用验证（0=否，1=是）
    /// </summary>
    [SugarColumn(ColumnName = "is_validation_enabled", ColumnDescription = "是否启用验证", ColumnDataType = "int", IsNullable = false, DefaultValue = "1")]
    public int IsValidationEnabled { get; set; } = 1;

    /// <summary>
    /// 验证规则（JSON格式，存储字段验证规则）
    /// </summary>
    [SugarColumn(ColumnName = "validation_rules", ColumnDescription = "验证规则", ColumnDataType = "nvarchar", Length = 4000, IsNullable = true)]
    public string? ValidationRules { get; set; }

    /// <summary>
    /// 是否启用权限控制（0=否，1=是）
    /// </summary>
    [SugarColumn(ColumnName = "is_permission_enabled", ColumnDescription = "是否启用权限控制", ColumnDataType = "int", IsNullable = false, DefaultValue = "0")]
    public int IsPermissionEnabled { get; set; } = 0;

    /// <summary>
    /// 权限配置（JSON格式，存储字段权限配置）
    /// </summary>
    [SugarColumn(ColumnName = "permission_config", ColumnDescription = "权限配置", ColumnDataType = "nvarchar", Length = 4000, IsNullable = true)]
    public string? PermissionConfig { get; set; }

    /// <summary>
    /// 是否启用数据源（0=否，1=是）
    /// </summary>
    [SugarColumn(ColumnName = "is_datasource_enabled", ColumnDescription = "是否启用数据源", ColumnDataType = "int", IsNullable = false, DefaultValue = "0")]
    public int IsDatasourceEnabled { get; set; } = 0;

    /// <summary>
    /// 数据源配置（JSON格式，存储数据源配置）
    /// </summary>
    [SugarColumn(ColumnName = "datasource_config", ColumnDescription = "数据源配置", ColumnDataType = "nvarchar", Length = 4000, IsNullable = true)]
    public string? DatasourceConfig { get; set; }

    /// <summary>
    /// 表单主题（JSON格式，存储表单样式主题配置）
    /// </summary>
    [SugarColumn(ColumnName = "form_theme", ColumnDescription = "表单主题", ColumnDataType = "nvarchar", Length = 2000, IsNullable = true)]
    public string? FormTheme { get; set; }

    /// <summary>
    /// 排序号（越小越靠前）
    /// </summary>
    [SugarColumn(ColumnName = "order_num", ColumnDescription = "排序号", ColumnDataType = "int", IsNullable = false, DefaultValue = "0")]
    public int OrderNum { get; set; } = 0;

    /// <summary>
    /// 表单状态（0=草稿，1=已发布，2=已停用）
    /// </summary>
    [SugarColumn(ColumnName = "form_status", ColumnDescription = "表单状态", ColumnDataType = "int", IsNullable = false, DefaultValue = "0")]
    public int FormStatus { get; set; } = 0;
}
