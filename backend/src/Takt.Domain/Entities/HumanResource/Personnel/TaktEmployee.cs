// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：Takt.Domain.Entities.HumanResource
// 文件名称：TaktEmployee.cs
// 创建时间：2025-01-20
// 创建人：Takt365(Cursor AI)
// 功能描述：Takt员工实体，定义员工基本信息领域模型
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险.
// ========================================

using SqlSugar;

namespace Takt.Domain.Entities.HumanResource.Personnel;

/// <summary>
/// Takt员工实体
/// </summary>
[SugarTable("takt_humanresource_employee", "员工表")]
[SugarIndex("ix_takt_humanresource_employee_employee_code", nameof(EmployeeCode), OrderByType.Asc, true)]
[SugarIndex("ix_takt_humanresource_employee_id_card", nameof(IdCard), OrderByType.Asc)]
[SugarIndex("ix_takt_humanresource_employee_phone", nameof(Phone), OrderByType.Asc)]
[SugarIndex("ix_takt_humanresource_employee_email", nameof(Email), OrderByType.Asc)]
[SugarIndex("ix_takt_humanresource_employee_user_id", nameof(UserId), OrderByType.Asc)]
[SugarIndex("ix_takt_humanresource_employee_config_id", nameof(ConfigId), OrderByType.Asc)]
[SugarIndex("ix_takt_humanresource_employee_is_deleted", nameof(IsDeleted), OrderByType.Asc)]
[SugarIndex("ix_takt_humanresource_employee_employee_status", nameof(EmployeeStatus), OrderByType.Asc)]
public class TaktEmployee : TaktEntityBase
{
    /// <summary>
    /// 员工编码（唯一索引）
    /// </summary>
    [SugarColumn(ColumnName = "employee_code", ColumnDescription = "员工编码", ColumnDataType = "nvarchar", Length = 50, IsNullable = false)]
    public string EmployeeCode { get; set; } = string.Empty;

    /// <summary>
    /// 关联用户ID（序列化为string以避免Javascript精度问题）
    /// </summary>
    [SugarColumn(ColumnName = "user_id", ColumnDescription = "关联用户ID", ColumnDataType = "bigint", IsNullable = true)]
    [JsonConverter(typeof(ValueToStringConverter))]
    public long? UserId { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    [SugarColumn(ColumnName = "name", ColumnDescription = "姓名", ColumnDataType = "nvarchar", Length = 50, IsNullable = false)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 英文名
    /// </summary>
    [SugarColumn(ColumnName = "english_name", ColumnDescription = "英文名", ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
    public string? EnglishName { get; set; }

    /// <summary>
    /// 性别（0=未知，1=男，2=女）
    /// </summary>
    [SugarColumn(ColumnName = "gender", ColumnDescription = "性别", ColumnDataType = "int", IsNullable = false, DefaultValue = "0")]
    public int Gender { get; set; } = 0;

    /// <summary>
    /// 出生日期
    /// </summary>
    [SugarColumn(ColumnName = "birth_date", ColumnDescription = "出生日期", ColumnDataType = "date", IsNullable = true)]
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// 年龄
    /// </summary>
    [SugarColumn(ColumnName = "age", ColumnDescription = "年龄", ColumnDataType = "int", IsNullable = true)]
    public int? Age { get; set; }

    /// <summary>
    /// 身份证号（索引）
    /// </summary>
    [SugarColumn(ColumnName = "id_card", ColumnDescription = "身份证号", ColumnDataType = "nvarchar", Length = 18, IsNullable = true)]
    public string? IdCard { get; set; }

    /// <summary>
    /// 手机号（索引）
    /// </summary>
    [SugarColumn(ColumnName = "phone", ColumnDescription = "手机号", ColumnDataType = "nvarchar", Length = 20, IsNullable = true)]
    public string? Phone { get; set; }

    /// <summary>
    /// 邮箱（索引）
    /// </summary>
    [SugarColumn(ColumnName = "email", ColumnDescription = "邮箱", ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
    public string? Email { get; set; }

    /// <summary>
    /// 头像
    /// </summary>
    [SugarColumn(ColumnName = "avatar", ColumnDescription = "头像", ColumnDataType = "nvarchar", Length = 500, IsNullable = true)]
    public string? Avatar { get; set; }

    /// <summary>
    /// 民族
    /// </summary>
    [SugarColumn(ColumnName = "nationality", ColumnDescription = "民族", ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
    public string? Nationality { get; set; }

    /// <summary>
    /// 政治面貌（0=群众，1=团员，2=党员，3=其他）
    /// </summary>
    [SugarColumn(ColumnName = "political_status", ColumnDescription = "政治面貌", ColumnDataType = "int", IsNullable = false, DefaultValue = "0")]
    public int PoliticalStatus { get; set; } = 0;

    /// <summary>
    /// 婚姻状况（0=未婚，1=已婚，2=离异，3=丧偶）
    /// </summary>
    [SugarColumn(ColumnName = "marital_status", ColumnDescription = "婚姻状况", ColumnDataType = "int", IsNullable = false, DefaultValue = "0")]
    public int MaritalStatus { get; set; } = 0;

    /// <summary>
    /// 籍贯
    /// </summary>
    [SugarColumn(ColumnName = "native_place", ColumnDescription = "籍贯", ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
    public string? NativePlace { get; set; }

    /// <summary>
    /// 现居住地址
    /// </summary>
    [SugarColumn(ColumnName = "current_address", ColumnDescription = "现居住地址", ColumnDataType = "nvarchar", Length = 500, IsNullable = true)]
    public string? CurrentAddress { get; set; }

    /// <summary>
    /// 户籍地址
    /// </summary>
    [SugarColumn(ColumnName = "registered_address", ColumnDescription = "户籍地址", ColumnDataType = "nvarchar", Length = 500, IsNullable = true)]
    public string? RegisteredAddress { get; set; }

    /// <summary>
    /// 紧急联系人
    /// </summary>
    [SugarColumn(ColumnName = "emergency_contact", ColumnDescription = "紧急联系人", ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
    public string? EmergencyContact { get; set; }

    /// <summary>
    /// 紧急联系人电话
    /// </summary>
    [SugarColumn(ColumnName = "emergency_contact_phone", ColumnDescription = "紧急联系人电话", ColumnDataType = "nvarchar", Length = 20, IsNullable = true)]
    public string? EmergencyContactPhone { get; set; }

    /// <summary>
    /// 紧急联系人关系
    /// </summary>
    [SugarColumn(ColumnName = "emergency_contact_relation", ColumnDescription = "紧急联系人关系", ColumnDataType = "nvarchar", Length = 50, IsNullable = true)]
    public string? EmergencyContactRelation { get; set; }

    /// <summary>
    /// 员工状态（0=在职，1=离职，2=停薪留职，3=退休）
    /// </summary>
    [SugarColumn(ColumnName = "employee_status", ColumnDescription = "员工状态", ColumnDataType = "int", IsNullable = false, DefaultValue = "0")]
    public int EmployeeStatus { get; set; } = 0;
}
