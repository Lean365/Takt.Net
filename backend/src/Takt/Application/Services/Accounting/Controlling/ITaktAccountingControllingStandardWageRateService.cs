// ========================================
// 项目名称：节拍数字工厂 · Takt Digital Factory (TDF)
// 命名空间：Takt.Application.Services.Accounting.Controlling
// 文件名称：ITaktAccountingControllingStandardWageRateService.cs
// 创建时间：2025-02-02
// 创建人：Takt365
// 功能描述：标准工资率表应用服务接口，根据 GenFunction 生成
//
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using Takt.Application.Dtos.Accounting.Controlling;
using Takt.Shared.Models;

namespace Takt.Application.Services.Accounting.Controlling;

/// <summary>
/// 标准工资率表应用服务接口
/// </summary>
public interface ITaktAccountingControllingStandardWageRateService
{

    /// <summary>
    /// 获取AccountingControllingStandardWageRate列表（分页）
    /// </summary>
    /// <param name="queryDto">查询DTO</param>
    /// <returns>分页结果</returns>
    Task<TaktPagedResult<TaktAccountingControllingStandardWageRateDto>> GetListAsync(TaktAccountingControllingStandardWageRateQueryDto queryDto);

    /// <summary>
    /// 根据ID获取AccountingControllingStandardWageRate
    /// </summary>
    /// <param name="id">主键ID</param>
    /// <returns>AccountingControllingStandardWageRateDTO</returns>
    Task<TaktAccountingControllingStandardWageRateDto?> GetByIdAsync(long id);

    /// <summary>
    /// 创建AccountingControllingStandardWageRate
    /// </summary>
    /// <param name="dto">创建DTO</param>
    /// <returns>AccountingControllingStandardWageRateDTO</returns>
    Task<TaktAccountingControllingStandardWageRateDto> CreateAsync(TaktAccountingControllingStandardWageRateCreateDto dto);

    /// <summary>
    /// 更新AccountingControllingStandardWageRate
    /// </summary>
    /// <param name="id">主键ID</param>
    /// <param name="dto">更新DTO</param>
    /// <returns>AccountingControllingStandardWageRateDTO</returns>
    Task<TaktAccountingControllingStandardWageRateDto> UpdateAsync(long id, TaktAccountingControllingStandardWageRateUpdateDto dto);

    /// <summary>
    /// 删除AccountingControllingStandardWageRate
    /// </summary>
    /// <param name="id">主键ID</param>
    /// <returns>任务</returns>
    Task DeleteAsync(long id);

    /// <summary>
    /// 批量删除AccountingControllingStandardWageRate
    /// </summary>
    /// <param name="ids">主键ID列表</param>
    /// <returns>任务</returns>
    Task DeleteAsync(IEnumerable<long> ids);

    /// <summary>
    /// 获取AccountingControllingStandardWageRate导入模板
    /// </summary>
    /// <returns>文件流与文件名</returns>
    Task<(Stream stream, string fileName)> GetTemplateAsync();

    /// <summary>
    /// 导入AccountingControllingStandardWageRate
    /// </summary>
    /// <param name="list">导入数据列表</param>
    /// <returns>任务</returns>
    Task ImportAsync(IEnumerable<TaktAccountingControllingStandardWageRateImportDto> list);

    /// <summary>
    /// 导出AccountingControllingStandardWageRate
    /// </summary>
    /// <param name="queryDto">导出查询条件</param>
    /// <returns>文件流与文件名</returns>
    Task<(Stream stream, string fileName)> ExportAsync(TaktAccountingControllingStandardWageRateExportDto queryDto);
}
