// ========================================
// 项目名称：节拍数字工厂 · Takt Digital Factory (TDF)
// 命名空间：Takt.Application.Services.Accounting.Financial
// 文件名称：true.cs
// 创建时间：2025-02-02
// 创建人：系统管理员
// 功能描述：测试应用服务接口，根据 GenFunction 生成
//
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using Takt.Application.Dtos.Accounting.Financial;
using Takt.Shared.Models;

namespace Takt.Application.Services.Accounting.Financial;

/// <summary>
/// 测试应用服务接口
/// </summary>
public interface true
{

    /// <summary>
    /// 获取TestCs3列表（分页）
    /// </summary>
    /// <param name="queryDto">查询DTO</param>
    /// <returns>分页结果</returns>
    Task<TaktPagedResult<TaktTestCs3Dto>> GetListAsync(TaktTestCs3QueryDto queryDto);


    /// <summary>
    /// 根据ID获取TestCs3
    /// </summary>
    /// <param name="id">主键ID</param>
    /// <returns>TestCs3DTO</returns>
    Task<TaktTestCs3Dto?> GetByIdAsync(long id);


    /// <summary>
    /// 创建TestCs3
    /// </summary>
    /// <param name="dto">创建DTO</param>
    /// <returns>TestCs3DTO</returns>
    Task<TaktTestCs3Dto> CreateAsync(TaktTestCs3CreateDto dto);


    /// <summary>
    /// 更新TestCs3
    /// </summary>
    /// <param name="id">主键ID</param>
    /// <param name="dto">更新DTO</param>
    /// <returns>TestCs3DTO</returns>
    Task<TaktTestCs3Dto> UpdateAsync(long id, TaktTestCs3UpdateDto dto);


    /// <summary>
    /// 删除TestCs3
    /// </summary>
    /// <param name="id">主键ID</param>
    /// <returns>任务</returns>
    Task DeleteAsync(long id);


    /// <summary>
    /// 批量删除TestCs3
    /// </summary>
    /// <param name="ids">主键ID列表</param>
    /// <returns>任务</returns>
    Task DeleteAsync(IEnumerable<long> ids);


    /// <summary>
    /// 获取TestCs3导入模板
    /// </summary>
    /// <returns>文件流与文件名</returns>
    Task<(Stream stream, string fileName)> GetTemplateAsync();


    /// <summary>
    /// 导入TestCs3
    /// </summary>
    /// <param name="list">导入数据列表</param>
    /// <returns>任务</returns>
    Task ImportAsync(IEnumerable<TaktTestCs3ImportDto> list);


    /// <summary>
    /// 导出TestCs3
    /// </summary>
    /// <param name="queryDto">导出查询条件</param>
    /// <returns>文件流与文件名</returns>
    Task<(Stream stream, string fileName)> ExportAsync(TaktTestCs3ExportDto queryDto);


}
