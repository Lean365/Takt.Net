// ========================================
// 项目名称：节拍数字工厂 · Takt Digital Factory (TDF)
// 命名空间：Takt.Application.Services.Accounting.Financial
// 文件名称：true.cs
// 创建时间：2025-02-02
// 创建人：系统管理员
// 功能描述：测试应用服务，根据 GenFunction 生成
//
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using Mapster;
using SqlSugar;
using Takt.Application.Dtos.Accounting.Financial;
using Takt.Domain.Entities.Accounting.Financial;
using Takt.Application.Services;
using Takt.Domain.Interfaces;
using Takt.Domain.Repositories;
using Takt.Domain.Validation;
using Takt.Shared.Exceptions;
using Takt.Shared.Models;

namespace Takt.Application.Services.Accounting.Financial;

/// <summary>
/// 测试应用服务
/// </summary>
public class true : TaktServiceBase, true
{
    private readonly ITaktRepository<TaktTestCs3> _repository;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="repository">仓储</param>
    /// <param name="userContext">用户上下文（可选）</param>
    /// <param name="tenantContext">租户上下文（可选）</param>
    /// <param name="localizer">本地化器（可选）</param>
    public true(
        ITaktRepository<TaktTestCs3> repository,
        ITaktUserContext? userContext = null,
        ITaktTenantContext? tenantContext = null,
        ITaktLocalizer? localizer = null)
        : base(userContext, tenantContext, localizer)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }


    /// <inheritdoc />
    public async Task<TaktPagedResult<TaktTestCs3Dto>> GetListAsync(TaktTestCs3QueryDto queryDto)
    {
        var predicate = QueryExpression(queryDto);
                var (data, total) = await _repository.GetPagedAsync(queryDto.PageIndex, queryDto.PageSize, predicate);
                return TaktPagedResult<TaktTestCs3Dto>.Create(
                    data.Adapt<List<TaktTestCs3Dto>>(),
                    total,
                    queryDto.PageIndex,
                    queryDto.PageSize);
    }


    /// <inheritdoc />
    public async Task<TaktTestCs3Dto?> GetByIdAsync(long id)
    {
        var entity = await _repository.GetByIdAsync(id);
                return entity?.Adapt<TaktTestCs3Dto>();
    }


    /// <inheritdoc />
    public async Task<TaktTestCs3Dto> CreateAsync(TaktTestCs3CreateDto dto)
    {
        var entity = dto.Adapt<TaktTestCs3>();
                entity = await _repository.CreateAsync(entity);
                return entity.Adapt<TaktTestCs3Dto>();
    }


    /// <inheritdoc />
    public async Task<TaktTestCs3Dto> UpdateAsync(long id, TaktTestCs3UpdateDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                    throw new TaktBusinessException("TestCs3不存在");
                dto.Adapt(entity, typeof(TaktTestCs3UpdateDto), typeof(TaktTestCs3));
                entity.UpdateTime = DateTime.Now;
                await _repository.UpdateAsync(entity);
                return entity.Adapt<TaktTestCs3Dto>();
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
        // TODO: 根据 TaktTestCs3TemplateDto 生成 Excel 模板流
                await Task.CompletedTask;
                var ms = new MemoryStream();
                return (ms, "TestCs3导入模板.xlsx");
    }


    /// <inheritdoc />
    public async Task ImportAsync(IEnumerable<TaktTestCs3ImportDto> list)
    {
        var entities = list.Adapt<List<TaktTestCs3>>();
                foreach (var e in entities)
                    await _repository.CreateAsync(e);
    }


    /// <inheritdoc />
    public async Task<(Stream stream, string fileName)> ExportAsync(TaktTestCs3ExportDto queryDto)
    {
        var data = await _repository.GetListAsync();
                var dtos = data.Adapt<List<TaktTestCs3Dto>>();
                // TODO: 根据 queryDto 条件过滤并按列导出，将 dtos 转为 Excel 流
                await Task.CompletedTask;
                var ms = new MemoryStream();
                return (ms, "TestCs3导出.xlsx");
    }



    private static System.Linq.Expressions.Expression<Func<TaktTestCs3, bool>> QueryExpression(TaktTestCs3QueryDto queryDto)
    {
        var exp = Expressionable.Create<TaktTestCs3>();
                if (!string.IsNullOrEmpty(queryDto?.KeyWords))
                {
                    exp = exp.And(x => x.Remark != null && x.Remark.Contains(queryDto.KeyWords));
                }
                return exp.ToExpression();
    }


}
