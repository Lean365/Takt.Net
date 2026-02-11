// ========================================
// 项目名称：节拍数字工厂 · Takt Digital Factory (TDF)
// 命名空间：Takt.WebApi.Controllers.Accounting.Financial
// 文件名称：true.cs
// 创建时间：2025-02-02
// 创建人：系统管理员
// 功能描述：测试控制器，根据 GenFunction 生成
//
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using Microsoft.AspNetCore.Mvc;
using Takt.Application.Dtos.Accounting.Financial;
using Takt.Application.Services.Accounting.Financial;
using Takt.Domain.Interfaces;
using Takt.Infrastructure.Attributes;
using Takt.Shared.Exceptions;
using Takt.Shared.Models;
using Takt.WebApi.Controllers;

namespace Takt.WebApi.Controllers.Accounting.Financial;

/// <summary>
/// 测试控制器
/// </summary>
[Route("api/[controller]", Name = "TestCs3")]
[ApiModule("true", "TestCs3")]
[TaktPermission("true:takt_test_cs3", "TestCs3管理")]
public class true : TaktControllerBase
{
    private readonly true _service;

    /// <summary>
    /// 构造函数
    /// </summary>
    public true(
        true service,
        ITaktUserContext? userContext = null,
        ITaktTenantContext? tenantContext = null,
        ITaktLocalizer? localizer = null)
        : base(userContext, tenantContext, localizer)
    {
        _service = service;
    }


    /// <summary>
    /// 获取测试列表（分页）
    /// </summary>
    [HttpGet("list")]
    [TaktPermission("accounting:financial:test:cs3:list", "查询列表")]

    public async Task<ActionResult<TaktPagedResult<TaktTestCs3Dto>>> GetListAsync([FromQuery] TaktTestCs3QueryDto queryDto)

    {
        var result = await _service.GetListAsync(queryDto);
                return Ok(result);
    }


    /// <summary>
    /// 根据ID获取测试
    /// </summary>
    [HttpGet("{id}")]
    [TaktPermission("accounting:financial:test:cs3:query", "查询详情")]

    public async Task<ActionResult<TaktTestCs3Dto>> GetByIdAsync(long id)

    {
        var dto = await _service.GetByIdAsync(id);
                if (dto == null) return NotFound();
                return Ok(dto);
    }


    /// <summary>
    /// 创建测试
    /// </summary>
    [HttpPost]
    [TaktPermission("accounting:financial:test:cs3:create", "创建")]

    public async Task<ActionResult<TaktTestCs3Dto>> CreateAsync([FromBody] TaktTestCs3CreateDto dto)

    {
        var result = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetByIdAsync), new { id = result.TestCs3Id }, result);
    }


    /// <summary>
    /// 更新测试
    /// </summary>
    [HttpPut("{id}")]
    [TaktPermission("accounting:financial:test:cs3:update", "更新")]

    public async Task<ActionResult<TaktTestCs3Dto>> UpdateAsync(long id, [FromBody] TaktTestCs3UpdateDto dto)

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
    /// 删除测试
    /// </summary>
    [HttpDelete("{id}")]
    [TaktPermission("accounting:financial:test:cs3:delete", "删除")]

    public async Task<IActionResult> DeleteAsync(long id)

    {
        await _service.DeleteAsync(id);
                return NoContent();
    }


    /// <summary>
    /// 批量删除测试
    /// </summary>
    [HttpDelete("batch")]
    [TaktPermission("accounting:financial:test:cs3:delete", "批量删除")]

    public async Task<IActionResult> DeleteBatchAsync([FromBody] IEnumerable<long> ids)

    {
        await _service.DeleteAsync(ids);
                return NoContent();
    }


    /// <summary>
    /// 下载测试导入模板
    /// </summary>
    [HttpGet("template")]
    [TaktPermission("accounting:financial:test:cs3:template", "下载模板")]

    public async Task<IActionResult> GetTemplateAsync()

    {
        var (stream, fileName) = await _service.GetTemplateAsync();
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
    }


    /// <summary>
    /// 导入测试
    /// </summary>
    [HttpPost("import")]
    [TaktPermission("accounting:financial:test:cs3:import", "导入")]

    public async Task<IActionResult> ImportAsync([FromBody] IEnumerable<TaktTestCs3ImportDto> list)

    {
        await _service.ImportAsync(list);
                return Ok();
    }


    /// <summary>
    /// 导出测试
    /// </summary>
    [HttpPost("export")]
    [TaktPermission("accounting:financial:test:cs3:export", "导出")]

    public async Task<IActionResult> ExportAsync([FromBody] TaktTestCs3ExportDto queryDto)

    {
        var (stream, fileName) = await _service.ExportAsync(queryDto);
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
    }


}
