// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：Takt.Infrastructure.Extensions
// 文件名称：TaktSwaggerCollectionExtensions.cs
// 创建时间：2025-01-09
// 创建人：Takt365(Cursor AI)
// 功能描述：Takt Swagger配置扩展方法，用于配置Swagger文档分组
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Takt.Infrastructure.Extensions;

/// <summary>
/// Takt Swagger配置扩展方法
/// </summary>
public static class TaktSwaggerCollectionExtensions
{
    /// <summary>
    /// 添加Swagger服务
    /// </summary>
    /// <param name="services">服务集合</param>
    /// <param name="assemblyName">程序集名称，用于加载XML注释</param>
    /// <returns>服务集合</returns>
    public static IServiceCollection AddTaktSwagger(this IServiceCollection services, string? assemblyName = null)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            // 按模块分组
            c.SwaggerDoc("Identity", new OpenApiInfo
            {
                Title = "Identity - 身份认证和管理",
                Version = "v1",
                Description = "身份认证、用户管理等API"
            });

            c.SwaggerDoc("Connect", new OpenApiInfo
            {
                Title = "Connect - OAuth2/OIDC连接",
                Version = "v1",
                Description = "OAuth2/OIDC令牌端点等API"
            });

            c.SwaggerDoc("Routine", new OpenApiInfo
            {
                Title = "Routine - 日常事务",
                Version = "v1",
                Description = "日常事务、常规管理等API"
            });

            c.SwaggerDoc("Logistics", new OpenApiInfo
            {
                Title = "Logistics - 后勤管理",
                Version = "v1",
                Description = "后勤管理相关API"
            });

            c.SwaggerDoc("Accounting", new OpenApiInfo
            {
                Title = "Accounting - 财务管理",
                Version = "v1",
                Description = "财务管理相关API"
            });

            c.SwaggerDoc("Organization", new OpenApiInfo
            {
                Title = "Organization - 组织管理",
                Version = "v1",
                Description = "组织管理相关API"
            });

            c.SwaggerDoc("Generator", new OpenApiInfo
            {
                Title = "Generator - 代码生成",
                Version = "v1",
                Description = "代码生成相关API"
            });

            c.SwaggerDoc("Tenant", new OpenApiInfo
            {
                Title = "Tenant - 租户管理",
                Version = "v1",
                Description = "租户管理相关API"
            });

            c.SwaggerDoc("SignalR", new OpenApiInfo
            {
                Title = "SignalR - SignalR管理",
                Version = "v1",
                Description = "SignalR管理相关API"
            });

            c.SwaggerDoc("Logging", new OpenApiInfo
            {
                Title = "Logging - 日志管理",
                Version = "v1",
                Description = "日志管理相关API"
            });

            // 根据ApiExplorerSettings的GroupName将API分配到不同的文档
            // 注意：DocInclusionPredicate 会对每个文档和每个API描述进行调用
            // 只有当返回 true 时，该API才会被包含在该文档中
            c.DocInclusionPredicate((docName, apiDesc) =>
            {
                // 获取控制器的 GroupName（从 ApiExplorerSettingsAttribute）
                // GroupName 是通过 ApiModuleAttribute 设置的，它继承自 ApiExplorerSettingsAttribute
                var groupName = apiDesc.GroupName;

                // 判断是否应该包含在当前文档中
                if (string.IsNullOrEmpty(groupName))
                {
                    // 如果没有 GroupName，默认包含在 Identity 文档中
                    return docName == "Identity";
                }
                else
                {
                    // 根据 GroupName 匹配文档（使用不区分大小写的比较）
                    return string.Equals(docName, groupName, StringComparison.OrdinalIgnoreCase);
                }
            });

            // 添加文档过滤器
            c.DocumentFilter<SwaggerDocumentStatsFilter>();

            // 自定义 Schema ID 生成器，避免类型名称冲突
            c.CustomSchemaIds(type => type.FullName);

            // 确保所有控制器都被发现（即使没有 ApiExplorerSettings）
            // 这可以确保所有控制器都能被 Swagger 发现和分组
            c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

            // 确保所有操作都被包含（即使没有 ApiExplorerSettings）
            // 这可以确保所有操作都能被 Swagger 发现
            c.IgnoreObsoleteActions();

            // 包含XML注释（如果有）
            if (!string.IsNullOrEmpty(assemblyName))
            {
                var xmlFile = $"{assemblyName}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                {
                    c.IncludeXmlComments(xmlPath);
                }
            }
        });

        return services;
    }

    /// <summary>
    /// 使用Swagger UI
    /// </summary>
    /// <param name="app">应用程序构建器</param>
    /// <returns>应用程序构建器</returns>
    public static IApplicationBuilder UseTaktSwaggerUI(this IApplicationBuilder app)
    {
        // 先配置 Swagger JSON 端点
        app.UseSwagger(c =>
        {
            c.RouteTemplate = "swagger/{documentName}/swagger.json";
            // Swashbuckle 10.1.0 默认生成 OpenAPI 3.x 格式，无需额外配置
        });

        // 再配置 Swagger UI
        app.UseSwaggerUI(c =>
        {
            // 设置Swagger UI路径为 /swagger（避免拦截 SignalR 请求）
            c.RoutePrefix = "swagger";

            // 配置默认文档
            c.DefaultModelsExpandDepth(-1);
            c.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);

            // 显示多个Swagger文档（按模块分组）
            // 注意：必须按照 SwaggerDoc 中定义的顺序注册，确保所有文档都被正确加载
            var endpoints = new[]
            {
                ("Identity", "Identity - 身份认证和管理"),
                ("Connect", "Connect - OAuth2/OIDC连接"),
                ("Routine", "Routine - 日常事务"),
                ("Logistics", "Logistics - 后勤管理"),
                ("Accounting", "Accounting - 财务管理"),
                ("Organization", "Organization - 组织管理"),
                ("Generator", "Generator - 代码生成"),
                ("Tenant", "Tenant - 租户管理"),
                ("SignalR", "SignalR - SignalR管理"),
                ("Logging", "Logging - 日志管理")
            };

            // 使用 SwaggerEndpoint 注册所有文档（这是 Swashbuckle 推荐的方式）
            // 注意：必须确保每个文档的路径都正确，且文档名称与 SwaggerDoc 中定义的名称完全匹配
            // 重要：即使文档为空，也应该注册，这样 Swagger UI 才会在下拉列表中显示
            foreach (var (docName, docTitle) in endpoints)
            {
                var endpointUrl = $"/swagger/{docName}/swagger.json";
                c.SwaggerEndpoint(endpointUrl, docTitle);
            }

            // 设置 Swagger UI 配置
            c.ConfigObject.DefaultModelExpandDepth = 1;
            c.ConfigObject.DocExpansion = Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List;
            c.ConfigObject.DeepLinking = true;
            c.ConfigObject.DisplayRequestDuration = true;

        });

        return app;
    }
}

/// <summary>
/// Swagger 文档统计过滤器
/// </summary>
internal class SwaggerDocumentStatsFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        // Swashbuckle 10.1.0 默认生成 OpenAPI 3.0.4，会自动包含 "openapi": "3.0.4" 字段
        // 此过滤器保留用于未来可能的文档修改需求
    }
}
