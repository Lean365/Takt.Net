// ========================================
// 项目名称：节拍数字工厂 · Takt Digital Factory (TDF)
// 命名空间：Takt.Application.Dtos.Accounting.Controlling
// 文件名称：TaktAccountingControllingStandardWageRateDtos.cs
// 创建时间：2025-02-02
// 创建人：Takt365
// 功能描述：标准工资率表DTO，由 DtoCategory 配置驱动，按 type 判断输出
//
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using SqlSugar;
using Takt.Shared.Models;

namespace Takt.Application.Dtos.Accounting.Controlling;



/// <summary>
/// 标准工资率表Dto
/// </summary>
public class TaktAccountingControllingStandardWageRateDto
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public TaktAccountingControllingStandardWageRateDto()
    {





























    }

    /// <summary>
    /// 标准工资率表ID（适配字段，序列化为string以避免Javascript精度问题）
    /// </summary>
    [AdaptMember("Id")][JsonConverter(typeof(SqlSugar.ValueToStringConverter))]
    public long AccountingControllingStandardWageRateId { get; set; }



    /// <summary>
    /// 工厂代码
    /// </summary>
    public string PlantCode { get; set; } = string.Empty;


    /// <summary>
    /// 年月
    /// </summary>
    public string YearMonth { get; set; } = string.Empty;


    /// <summary>
    /// 工作天数
    /// </summary>
    public decimal WorkingDays { get; set; }


    /// <summary>
    /// 销售额
    /// </summary>
    public decimal SalesAmount { get; set; }


    /// <summary>
    /// 直接人数
    /// </summary>
    public int DirectLaborCount { get; set; }


    /// <summary>
    /// 直接工资
    /// </summary>
    public decimal DirectLaborWage { get; set; }


    /// <summary>
    /// 直接加班小时
    /// </summary>
    public decimal DirectOvertimeHours { get; set; }


    /// <summary>
    /// 直接加班总额
    /// </summary>
    public decimal DirectOvertimeTotal { get; set; }


    /// <summary>
    /// 直接工资率
    /// </summary>
    public decimal DirectWageRate { get; set; }


    /// <summary>
    /// 间接人数
    /// </summary>
    public int IndirectLaborCount { get; set; }


    /// <summary>
    /// 间接工资
    /// </summary>
    public decimal IndirectLaborWage { get; set; }


    /// <summary>
    /// 间接加班小时
    /// </summary>
    public decimal IndirectOvertimeHours { get; set; }


    /// <summary>
    /// 间接加班总额
    /// </summary>
    public decimal IndirectOvertimeTotal { get; set; }


    /// <summary>
    /// 间接工资率
    /// </summary>
    public decimal IndirectWageRate { get; set; }

    /// <summary>
    /// 租户配置ID（ConfigId）
    /// </summary>
    public string ConfigId { get; set; } = "0";

    /// <summary>
    /// 扩展字段JSON
    /// </summary>
    public string? ExtFieldJson { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; }

    /// <summary>
    /// 创建人（用户名）
    /// </summary>
    public string? CreateBy { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 更新人（用户名）
    /// </summary>
    public string? UpdateBy { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    public DateTime? UpdateTime { get; set; }

    /// <summary>
    /// 是否删除（软删除标记，0=未删除，1=已删除）
    /// </summary>
    public int IsDeleted { get; set; }

    /// <summary>
    /// 删除人（用户名）
    /// </summary>
    public string? DeletedBy { get; set; }

    /// <summary>
    /// 删除时间
    /// </summary>
    public DateTime? DeletedTime { get; set; }
}



/// <summary>
/// 标准工资率表QueryDto
/// </summary>
public class TaktAccountingControllingStandardWageRateQueryDto : TaktPagedQuery
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public TaktAccountingControllingStandardWageRateQueryDto()
    {





























    }

    // KeyWords 属性已从基类 TaktPagedQuery 继承，用于模糊查询















}



/// <summary>
/// 标准工资率表CreateDto
/// </summary>
public class TaktAccountingControllingStandardWageRateCreateDto
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public TaktAccountingControllingStandardWageRateCreateDto()
    {





























    }



    /// <summary>
    /// 工厂代码
    /// </summary>
    public string PlantCode { get; set; } = string.Empty;


    /// <summary>
    /// 年月
    /// </summary>
    public string YearMonth { get; set; } = string.Empty;


    /// <summary>
    /// 工作天数
    /// </summary>
    public decimal WorkingDays { get; set; }


    /// <summary>
    /// 销售额
    /// </summary>
    public decimal SalesAmount { get; set; }


    /// <summary>
    /// 直接人数
    /// </summary>
    public int DirectLaborCount { get; set; }


    /// <summary>
    /// 直接工资
    /// </summary>
    public decimal DirectLaborWage { get; set; }


    /// <summary>
    /// 直接加班小时
    /// </summary>
    public decimal DirectOvertimeHours { get; set; }


    /// <summary>
    /// 直接加班总额
    /// </summary>
    public decimal DirectOvertimeTotal { get; set; }


    /// <summary>
    /// 直接工资率
    /// </summary>
    public decimal DirectWageRate { get; set; }


    /// <summary>
    /// 间接人数
    /// </summary>
    public int IndirectLaborCount { get; set; }


    /// <summary>
    /// 间接工资
    /// </summary>
    public decimal IndirectLaborWage { get; set; }


    /// <summary>
    /// 间接加班小时
    /// </summary>
    public decimal IndirectOvertimeHours { get; set; }


    /// <summary>
    /// 间接加班总额
    /// </summary>
    public decimal IndirectOvertimeTotal { get; set; }


    /// <summary>
    /// 间接工资率
    /// </summary>
    public decimal IndirectWageRate { get; set; }
}



/// <summary>
/// 标准工资率表UpdateDto
/// </summary>
public class TaktAccountingControllingStandardWageRateUpdateDto : TaktAccountingControllingStandardWageRateCreateDto
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public TaktAccountingControllingStandardWageRateUpdateDto()
    {
    }

    /// <summary>
    /// 标准工资率表ID（适配字段，序列化为string以避免Javascript精度问题）
    /// </summary>
    [AdaptMember("Id")][JsonConverter(typeof(SqlSugar.ValueToStringConverter))]
    public long AccountingControllingStandardWageRateId { get; set; }
}



/// <summary>
/// 标准工资率表TemplateDto
/// </summary>
public class TaktAccountingControllingStandardWageRateTemplateDto
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public TaktAccountingControllingStandardWageRateTemplateDto()
    {





























    }



    /// <summary>
    /// 工厂代码
    /// </summary>
    public string PlantCode { get; set; } = string.Empty;


    /// <summary>
    /// 年月
    /// </summary>
    public string YearMonth { get; set; } = string.Empty;


    /// <summary>
    /// 工作天数
    /// </summary>
    public decimal WorkingDays { get; set; }


    /// <summary>
    /// 销售额
    /// </summary>
    public decimal SalesAmount { get; set; }


    /// <summary>
    /// 直接人数
    /// </summary>
    public int DirectLaborCount { get; set; }


    /// <summary>
    /// 直接工资
    /// </summary>
    public decimal DirectLaborWage { get; set; }


    /// <summary>
    /// 直接加班小时
    /// </summary>
    public decimal DirectOvertimeHours { get; set; }


    /// <summary>
    /// 直接加班总额
    /// </summary>
    public decimal DirectOvertimeTotal { get; set; }


    /// <summary>
    /// 直接工资率
    /// </summary>
    public decimal DirectWageRate { get; set; }


    /// <summary>
    /// 间接人数
    /// </summary>
    public int IndirectLaborCount { get; set; }


    /// <summary>
    /// 间接工资
    /// </summary>
    public decimal IndirectLaborWage { get; set; }


    /// <summary>
    /// 间接加班小时
    /// </summary>
    public decimal IndirectOvertimeHours { get; set; }


    /// <summary>
    /// 间接加班总额
    /// </summary>
    public decimal IndirectOvertimeTotal { get; set; }


    /// <summary>
    /// 间接工资率
    /// </summary>
    public decimal IndirectWageRate { get; set; }
}



/// <summary>
/// 标准工资率表ImportDto
/// </summary>
public class TaktAccountingControllingStandardWageRateImportDto
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public TaktAccountingControllingStandardWageRateImportDto()
    {





























    }



    /// <summary>
    /// 工厂代码
    /// </summary>
    public string PlantCode { get; set; } = string.Empty;


    /// <summary>
    /// 年月
    /// </summary>
    public string YearMonth { get; set; } = string.Empty;


    /// <summary>
    /// 工作天数
    /// </summary>
    public decimal WorkingDays { get; set; }


    /// <summary>
    /// 销售额
    /// </summary>
    public decimal SalesAmount { get; set; }


    /// <summary>
    /// 直接人数
    /// </summary>
    public int DirectLaborCount { get; set; }


    /// <summary>
    /// 直接工资
    /// </summary>
    public decimal DirectLaborWage { get; set; }


    /// <summary>
    /// 直接加班小时
    /// </summary>
    public decimal DirectOvertimeHours { get; set; }


    /// <summary>
    /// 直接加班总额
    /// </summary>
    public decimal DirectOvertimeTotal { get; set; }


    /// <summary>
    /// 直接工资率
    /// </summary>
    public decimal DirectWageRate { get; set; }


    /// <summary>
    /// 间接人数
    /// </summary>
    public int IndirectLaborCount { get; set; }


    /// <summary>
    /// 间接工资
    /// </summary>
    public decimal IndirectLaborWage { get; set; }


    /// <summary>
    /// 间接加班小时
    /// </summary>
    public decimal IndirectOvertimeHours { get; set; }


    /// <summary>
    /// 间接加班总额
    /// </summary>
    public decimal IndirectOvertimeTotal { get; set; }


    /// <summary>
    /// 间接工资率
    /// </summary>
    public decimal IndirectWageRate { get; set; }
}



/// <summary>
/// 标准工资率表ExportDto
/// </summary>
public class TaktAccountingControllingStandardWageRateExportDto
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public TaktAccountingControllingStandardWageRateExportDto()
    {





























    }















}


