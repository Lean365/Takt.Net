// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：Takt.Infrastructure.Extensions
// 文件名称：TaktSeedsCollectionExtensions.cs
// 创建时间：2025-01-20
// 创建人：Takt365(Cursor AI)
// 功能描述：种子数据配置扩展方法，用于注册种子数据提供者
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险.
// ========================================

using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Takt.Infrastructure.Data.Seeds;

namespace Takt.Infrastructure.Extensions;

/// <summary>
/// 种子数据配置扩展方法
/// </summary>
public static class TaktSeedsCollectionExtensions
{
    /// <summary>
    /// 添加所有默认的种子数据提供者（用于Autofac容器注册）
    /// </summary>
    /// <param name="builder">Autofac容器构建器</param>
    /// <returns>容器构建器</returns>
    public static ContainerBuilder AddTaktSeeds(this ContainerBuilder builder)
    {
        // 注册所有种子数据提供者
        builder.RegisterType<TaktTenantSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktUserSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktMenuSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktRoleSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktDeptSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktPostSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktRbacSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktDictTypeSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktDictDataSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktLanguageSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktMenuL10nSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktDeptI18nSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktGreetingsI18nSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktQuotesI18nSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktUserEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktMenuEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktPostEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktRoleEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktDeptEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktRoleMenuEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktUserRoleEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktTenantEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktUserTenantEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktRoleDeptEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktUserDeptEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktUserPostEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktGenTableEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktGenTableColumnEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktDictDataEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktDictTypeEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktLanguageEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktTranslationEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktSettingsEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktMessageEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktOnlineEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktAopLogEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktLoginLogEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktOperLogEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktQuartzLogEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        builder.RegisterType<TaktFileEntitiesSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();

        return builder;
    }

    /// <summary>
    /// 添加种子数据提供者（用于Autofac容器注册）
    /// </summary>
    /// <typeparam name="TSeedData">种子数据提供者类型</typeparam>
    /// <param name="builder">Autofac容器构建器</param>
    /// <returns>容器构建器</returns>
    public static ContainerBuilder AddTaktSeed<TSeedData>(this ContainerBuilder builder)
        where TSeedData : class, ITaktSeedData
    {
        builder.RegisterType<TSeedData>().As<ITaktSeedData>().InstancePerLifetimeScope();
        return builder;
    }

    /// <summary>
    /// 添加种子数据提供者（用于Microsoft.Extensions.DependencyInjection）
    /// </summary>
    /// <typeparam name="TSeedData">种子数据提供者类型</typeparam>
    /// <param name="services">服务集合</param>
    /// <returns>服务集合</returns>
    public static IServiceCollection AddTaktSeed<TSeedData>(this IServiceCollection services)
        where TSeedData : class, ITaktSeedData
    {
        services.AddScoped<ITaktSeedData, TSeedData>();
        return services;
    }

    /// <summary>
    /// 添加所有默认的种子数据提供者（用于Microsoft.Extensions.DependencyInjection）
    /// </summary>
    /// <param name="services">服务集合</param>
    /// <returns>服务集合</returns>
    public static IServiceCollection AddTaktSeeds(this IServiceCollection services)
    {
        // 注册所有种子数据提供者
        services.AddScoped<ITaktSeedData, TaktTenantSeedData>();
        services.AddScoped<ITaktSeedData, TaktUserSeedData>();
        services.AddScoped<ITaktSeedData, TaktMenuSeedData>();
        services.AddScoped<ITaktSeedData, TaktRoleSeedData>();
        services.AddScoped<ITaktSeedData, TaktDeptSeedData>();
        services.AddScoped<ITaktSeedData, TaktPostSeedData>();
        services.AddScoped<ITaktSeedData, TaktRbacSeedData>();
        services.AddScoped<ITaktSeedData, TaktDictTypeSeedData>();
        services.AddScoped<ITaktSeedData, TaktDictDataSeedData>();
        services.AddScoped<ITaktSeedData, TaktLanguageSeedData>();
        services.AddScoped<ITaktSeedData, TaktMenuL10nSeedData>();
        services.AddScoped<ITaktSeedData, TaktDeptI18nSeedData>();
        services.AddScoped<ITaktSeedData, TaktGreetingsI18nSeedData>();
        services.AddScoped<ITaktSeedData, TaktQuotesI18nSeedData>();
        services.AddScoped<ITaktSeedData, TaktUserEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktMenuEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktPostEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktRoleEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktDeptEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktRoleMenuEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktUserRoleEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktTenantEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktUserTenantEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktRoleDeptEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktUserDeptEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktUserPostEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktGenTableEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktGenTableColumnEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktDictDataEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktDictTypeEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktLanguageEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktTranslationEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktSettingsEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktMessageEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktOnlineEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktAopLogEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktLoginLogEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktOperLogEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktQuartzLogEntitiesSeedData>();
        services.AddScoped<ITaktSeedData, TaktFileEntitiesSeedData>();

        return services;
    }
}
