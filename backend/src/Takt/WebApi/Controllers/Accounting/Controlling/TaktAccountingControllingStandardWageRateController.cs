// ========================================
// 项目名称：节拍数字工厂 · Takt Digital Factory (TDF)
// 命名空间：Takt.WebApi.Controllers.Accounting.Controlling
// 文件名称：TaktAccountingControllingStandardWageRateController.cs
// 创建时间：2025-02-02
// 创建人：Takt365
// 功能描述：标准工资率表控制器，根据 GenFunction 生成
//
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using Microsoft.AspNetCore.Mvc;
using Takt.Application.Dtos.Accounting.Controlling;
using Takt.Application.Services.Accounting.Controlling;
using Takt.Domain.Interfaces;
using Takt.Infrastructure.Attributes;
using Takt.Shared.Exceptions;
using Takt.Shared.Models;
using Takt.WebApi.Controllers;

namespace Takt.WebApi.Controllers.Accounting.Controlling;

/// <summary>
/// 标准工资率表控制器
/// </summary>
[Route("api/[controller]", Name = "AccountingControllingStandardWageRate")]
[ApiModule("Accounting.Controlling", "AccountingControllingStandardWageRate")]
[TaktPermission("accounting:controlling:accounting:controlling:standard:wage:rate:takt_accounting_controlling_standard_wage_rate", "AccountingControllingStandardWageRate管理")]
public class TaktAccountingControllingStandardWageRateController : TaktControllerBase
{
    private readonly ITaktAccountingControllingStandardWageRateService _service;

    /// <summary>
    /// 构造函数
    /// </summary>
    public TaktAccountingControllingStandardWageRateController(
        ITaktAccountingControllingStandardWageRateService service,
        ITaktUserContext? userContext = null,
        ITaktTenantContext? tenantContext = null,
        ITaktLocalizer? localizer = null)
        : base(userContext, tenantContext, localizer)
    {
        _service = service;
    }


    /// <summary>
    /// 获取标准工资率表列表（分页）
    /// </summary>
    [HttpGet("list")]
    [TaktPermission("accounting:controlling:accounting:controlling:standard:wage:rate:list", "查询列表")]

    public async Task<ActionResult<TaktPagedResult<TaktAccountingControllingStandardWageRateDto>>> GetListAsync([FromQuery] TaktAccountingControllingStandardWageRateQueryDto queryDto)

    {
        var result = await _service.GetListAsync(queryDto);
                return Ok(result);
    }

    /// <summary>
    /// 根据ID获取标准工资率表
    /// </summary>
    [HttpGet("{id}")]
    [TaktPermission("accounting:controlling:accounting:controlling:standard:wage:rate:query", "查询详情")]

    public async Task<ActionResult<TaktAccountingControllingStandardWageRateDto>> GetByIdAsync(long id)

    {
        var dto = await _service.GetByIdAsync(id);
                if (dto == null) return NotFound();
                return Ok(dto);
    }

    /// <summary>
    /// 创建标准工资率表
    /// </summary>
    [HttpPost]
    [TaktPermission("accounting:controlling:accounting:controlling:standard:wage:rate:create", "创建")]

    public async Task<ActionResult<TaktAccountingControllingStandardWageRateDto>> CreateAsync([FromBody] TaktAccountingControllingStandardWageRateCreateDto dto)

    {
        var result = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = result.AccountingControllingStandardWageRateId }, result);
    }

    /// <summary>
    /// 更新标准工资率表
    /// </summary>
    [HttpPut("{id}")]
    [TaktPermission("accounting:controlling:accounting:controlling:standard:wage:rate:update", "更新")]

    public async Task<ActionResult<TaktAccountingControllingStandardWageRateDto>> UpdateAsync(long id, [FromBody] TaktAccountingControllingStandardWageRateUpdateDto dto)

    {
        try
                {
                    var result = await _service.UpdateAsync(id, dto);
                    return Ok(result);
                }
                catch (TaktBusinessException ex)
                {
                    return BadRequest(ex.Message);
                }
    }

    /// <summary>
    /// 删除标准工资率表
    /// </summary>
    [HttpDelete("{id}")]
    [TaktPermission("accounting:controlling:accounting:controlling:standard:wage:rate:delete", "删除")]

    public async Task<IActionResult> DeleteAsync(long id)

    {
        await _service.DeleteAsync(id);
                return NoContent();
    }

    /// <summary>
    /// 批量删除标准工资率表
    /// </summary>
    [HttpDelete("batch")]
    [TaktPermission("accounting:controlling:accounting:controlling:standard:wage:rate:delete", "批量删除")]

    public async Task<IActionResult> DeleteBatchAsync([FromBody] IEnumerable<long> ids)

    {
        await _service.DeleteAsync(ids);
                return NoContent();
    }

    /// <summary>
    /// 下载标准工资率表导入模板
    /// </summary>
    [HttpGet("template")]
    [TaktPermission("accounting:controlling:accounting:controlling:standard:wage:rate:template", "下载模板")]

    public async Task<IActionResult> GetTemplateAsync()

    {
        var (stream, fileName) = await _service.GetTemplateAsync();
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
    }

    /// <summary>
    /// 导入标准工资率表
    /// </summary>
    [HttpPost("import")]
    [TaktPermission("accounting:controlling:accounting:controlling:standard:wage:rate:import", "导入")]

    public async Task<IActionResult> ImportAsync([FromBody] IEnumerable<TaktAccountingControllingStandardWageRateImportDto> list)

    {
        await _service.ImportAsync(list);
                return Ok();
    }

    /// <summary>
    /// 导出标准工资率表
    /// </summary>
    [HttpPost("export")]
    [TaktPermission("accounting:controlling:accounting:controlling:standard:wage:rate:export", "导出")]

    public async Task<IActionResult> ExportAsync([FromBody] TaktAccountingControllingStandardWageRateExportDto queryDto)

    {
        var (stream, fileName) = await _service.ExportAsync(queryDto);
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
    }
}
