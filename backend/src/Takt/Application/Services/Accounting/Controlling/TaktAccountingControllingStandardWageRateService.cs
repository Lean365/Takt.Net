// ========================================
// 项目名称：节拍数字工厂 · Takt Digital Factory (TDF)
// 命名空间：Takt.Application.Services.Accounting.Controlling
// 文件名称：TaktAccountingControllingStandardWageRateService.cs
// 创建时间：2025-02-02
// 创建人：Takt365
// 功能描述：标准工资率表应用服务，根据 GenFunction 生成
//
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using Mapster;
using SqlSugar;
using Takt.Application.Dtos.Accounting.Controlling;
using Takt.Domain.Entities.Accounting.Controlling;
using Takt.Application.Services;
using Takt.Domain.Interfaces;
using Takt.Domain.Repositories;
using Takt.Domain.Validation;
using Takt.Shared.Exceptions;
using Takt.Shared.Models;

namespace Takt.Application.Services.Accounting.Controlling;

/// <summary>
/// 标准工资率表应用服务
/// </summary>
public class TaktAccountingControllingStandardWageRateService : TaktServiceBase, ITaktAccountingControllingStandardWageRateService
{
    private readonly ITaktRepository<TaktAccountingControllingStandardWageRate> _repository;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="repository">仓储</param>
    /// <param name="userContext">用户上下文（可选）</param>
    /// <param name="tenantContext">租户上下文（可选）</param>
    /// <param name="localizer">本地化器（可选）</param>
    public TaktAccountingControllingStandardWageRateService(
        ITaktRepository<TaktAccountingControllingStandardWageRate> repository,
        ITaktUserContext? userContext = null,
        ITaktTenantContext? tenantContext = null,
        ITaktLocalizer? localizer = null)
        : base(userContext, tenantContext, localizer)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }


    /// <inheritdoc />
    public async Task<TaktPagedResult<TaktAccountingControllingStandardWageRateDto>> GetListAsync(TaktAccountingControllingStandardWageRateQueryDto queryDto)
    {
        var predicate = QueryExpression(queryDto);
                var (data, total) = await _repository.GetPagedAsync(queryDto.PageIndex, queryDto.PageSize, predicate);
                return TaktPagedResult<TaktAccountingControllingStandardWageRateDto>.Create(
                    data.Adapt<List<TaktAccountingControllingStandardWageRateDto>>(),
                    total,
                    queryDto.PageIndex,
                    queryDto.PageSize);
    }

    /// <inheritdoc />
    public async Task<TaktAccountingControllingStandardWageRateDto?> GetByIdAsync(long id)
    {
        var entity = await _repository.GetByIdAsync(id);
                return entity?.Adapt<TaktAccountingControllingStandardWageRateDto>();
    }

    /// <inheritdoc />
    public async Task<TaktAccountingControllingStandardWageRateDto> CreateAsync(TaktAccountingControllingStandardWageRateCreateDto dto)
    {
        var entity = dto.Adapt<TaktAccountingControllingStandardWageRate>();
                entity = await _repository.CreateAsync(entity);
                return entity.Adapt<TaktAccountingControllingStandardWageRateDto>();
    }

    /// <inheritdoc />
    public async Task<TaktAccountingControllingStandardWageRateDto> UpdateAsync(long id, TaktAccountingControllingStandardWageRateUpdateDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                    throw new TaktBusinessException("AccountingControllingStandardWageRate不存在");
                dto.Adapt(entity, typeof(TaktAccountingControllingStandardWageRateUpdateDto), typeof(TaktAccountingControllingStandardWageRate));
                entity.UpdateTime = DateTime.Now;
                await _repository.UpdateAsync(entity);
                return entity.Adapt<TaktAccountingControllingStandardWageRateDto>();
    }

    /// <inheritdoc />
    public async Task DeleteAsync(long id)
    {
        await _repository.DeleteAsync(id);
    }

    /// <inheritdoc />
    public async Task DeleteAsync(IEnumerable<long> ids)
    {
        var idList = ids.ToList();
                if (idList.Count == 0) return;
                await _repository.DeleteAsync(idList);
    }

    /// <inheritdoc />
    public async Task<(Stream stream, string fileName)> GetTemplateAsync()
    {
        // TODO: 根据 TaktAccountingControllingStandardWageRateTemplateDto 生成 Excel 模板流
                await Task.CompletedTask;
                var ms = new MemoryStream();
                return (ms, "AccountingControllingStandardWageRate导入模板.xlsx");
    }

    /// <inheritdoc />
    public async Task ImportAsync(IEnumerable<TaktAccountingControllingStandardWageRateImportDto> list)
    {
        var entities = list.Adapt<List<TaktAccountingControllingStandardWageRate>>();
                foreach (var e in entities)
                    await _repository.CreateAsync(e);
    }

    /// <inheritdoc />
    public async Task<(Stream stream, string fileName)> ExportAsync(TaktAccountingControllingStandardWageRateExportDto queryDto)
    {
        var data = await _repository.GetListAsync();
                var dtos = data.Adapt<List<TaktAccountingControllingStandardWageRateDto>>();
                // TODO: 根据 queryDto 条件过滤并按列导出，将 dtos 转为 Excel 流
                await Task.CompletedTask;
                var ms = new MemoryStream();
                return (ms, "AccountingControllingStandardWageRate导出.xlsx");
    }

    private static System.Linq.Expressions.Expression<Func<TaktAccountingControllingStandardWageRate, bool>> QueryExpression(TaktAccountingControllingStandardWageRateQueryDto queryDto)
    {
        var exp = Expressionable.Create<TaktAccountingControllingStandardWageRate>();
                if (!string.IsNullOrEmpty(queryDto?.KeyWords))
                {
                    exp = exp.And(x => x.Remark != null && x.Remark.Contains(queryDto.KeyWords));
                }
                return exp.ToExpression();
    }
}
