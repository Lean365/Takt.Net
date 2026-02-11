// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：Takt.Infrastructure.Data
// 文件名称：TaktEntityDatabaseMapping.cs
// 创建时间：2025-01-20
// 创建人：Takt365(Cursor AI)
// 功能描述：实体和种子数据到数据库的映射配置，根据业务领域自动分配
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

namespace Takt.Infrastructure.Data;

/// <summary>
/// 实体和种子数据到数据库的映射配置
/// </summary>
public static class TaktEntityDatabaseMapping
{
    /// <summary>
    /// 根据实体命名空间获取对应的 ConfigId
    /// </summary>
    /// <param name="entityNamespace">实体命名空间</param>
    /// <returns>ConfigId，如果未找到映射则返回 "0"（主库）</returns>
    public static string GetConfigIdByEntityNamespace(string entityNamespace)
    {
        // 映射规则：根据实体命名空间确定所属数据库
        // ConfigId="0" - Takt_Identity_Dev: Identity, Tenant, Logging
        // ConfigId="1" - Takt_Accounting_Dev: Accounting
        // ConfigId="2" - Takt_HumanResource_Dev: HumanResource（含组织、岗位、人事等）
        // ConfigId="3" - Takt_Logistics_Dev: Logistics, Statistics
        // ConfigId="4" - Takt_Building_Dev: Generator, Workflow
        // ConfigId="5" - Takt_Routine_Dev: Routine

        if (string.IsNullOrEmpty(entityNamespace))
            return "0";

        // 转换为小写以便匹配
        var ns = entityNamespace.ToLowerInvariant();

        // 按优先级顺序检查（从最具体到最通用）
        // 1. Generator/Workflow 相关实体 -> ConfigId="4"
        if (ns.Contains(".generator") || ns.Contains(".workflow") || ns.Contains(".code"))
        {
            return "4";
        }

        // 2. HumanResource（组织、岗位、人事等）统一 -> ConfigId="2"
        if (ns.Contains(".humanresource") || ns.Contains(".hrm"))
        {
            return "2";
        }

        // 4. Logistics、Statistics 相关实体 -> ConfigId="3"
        if (ns.Contains(".logistics") || ns.Contains(".statistics"))
        {
            return "3";
        }

        // 5. Accounting 相关实体 -> ConfigId="1"
        if (ns.Contains(".accounting"))
        {
            return "1";
        }

        // 6. Routine 相关实体 -> ConfigId="5"
        if (ns.Contains(".routine"))
        {
            return "5";
        }

        // 未匹配上述任何命名空间（如 Identity、Tenant、Logging 或其它未配置领域）-> ConfigId="0"（主库）
        return "0";
    }

    /// <summary>
    /// 根据种子数据类名获取对应的 ConfigId
    /// </summary>
    /// <param name="seedDataClassName">种子数据类名</param>
    /// <returns>ConfigId，如果未找到映射则返回 "0"（主库）</returns>
    public static string GetConfigIdBySeedDataClassName(string seedDataClassName)
    {
        var configIds = GetConfigIdsForSeedDataClassName(seedDataClassName);
        return configIds.FirstOrDefault() ?? "0";
    }

    /// <summary>
    /// 根据种子数据类名获取对应的 ConfigId 列表（支持一个种子在多个库执行，如 TaktRbacSeedData）
    /// </summary>
    /// <param name="seedDataClassName">种子数据类名</param>
    /// <returns>ConfigId 列表</returns>
    public static IEnumerable<string> GetConfigIdsForSeedDataClassName(string seedDataClassName)
    {
        if (string.IsNullOrEmpty(seedDataClassName))
        {
            yield return "0";
            yield break;
        }

        var className = seedDataClassName.ToLowerInvariant();

        // RBAC 关联：ConfigId 0 写 UserRole/RoleMenu，ConfigId 2 写 UserDept/UserPost
        if (className.Contains("rbacseeddata"))
        {
            yield return "0";
            yield return "2";
            yield break;
        }

        // Routine 相关种子数据 -> ConfigId="5"（领域关键字 routine + 具体种子类名；翻译/i18n 归 Routine）
        if (className.Contains("routine")
            || className.Contains("dictdataseeddata") || className.Contains("dicttypeseeddata") || className.Contains("languageseeddata")
            || className.Contains("depti18nseeddata") || className.Contains("menui18nseeddata"))
        {
            yield return "5";
            yield break;
        }

        // Accounting 相关种子数据 -> ConfigId="1"
        if (className.Contains("accounting"))
        {
            yield return "1";
            yield break;
        }

        // HumanResource 相关种子数据 -> ConfigId="2"
        if (className.Contains("humanresource") || className.Contains("hrm")
            || className.Contains("deptseeddata") || className.Contains("postseeddata"))
        {
            yield return "2";
            yield break;
        }

        // Logistics、Statistics 相关种子数据 -> ConfigId="3"
        if (className.Contains("logistics") || className.Contains("statistics"))
        {
            yield return "3";
            yield break;
        }

        // Generator/Workflow 相关种子数据 -> ConfigId="4"
        if (className.Contains("generator") || className.Contains("workflow") || className.Contains("code"))
        {
            yield return "4";
            yield break;
        }

        yield return "0";
    }
}
