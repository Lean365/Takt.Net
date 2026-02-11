// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：Takt.Infrastructure.Localization
// 文件名称：TaktLocalizer.cs
// 创建时间：2025-01-20
// 创建人：Takt365(Cursor AI)
// 功能描述：本地化帮助类，提供便捷的本地化字符串获取方法，支持从数据库动态获取翻译
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险.
// ========================================

using System.Globalization;
using System.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;
using Takt.Domain.Entities.Routine.I18n;
using Takt.Domain.Interfaces;
using Takt.Domain.Repositories;
using Takt.Infrastructure.Resources;
using Takt.Infrastructure.Tenant;
using Takt.Shared.Helpers;

namespace Takt.Infrastructure.Localization;

/// <summary>
/// 本地化帮助类
/// </summary>
/// <remarks>
/// 使用方式：
/// 1. 在控制器或服务中注入 ITaktLocalizer
/// 2. 支持从数据库动态获取翻译，如果数据库没有则回退到资源文件
/// </remarks>
public class TaktLocalizer : ITaktLocalizer
{
    /// <summary>资源类型：邮件模板（使用 Infrastructure/Resources/EmailResources.*.resx）</summary>
    public const string ResourceTypeEmail = "Email";

    private readonly IStringLocalizer<SharedResources> _localizer;
    private readonly IStringLocalizer<EmailResources> _emailLocalizer;
    private readonly ITaktRepository<TaktTranslation> _translationRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMemoryCache _memoryCache;
    private const string CacheKeyPrefix = "TaktTranslation_";
    private static readonly TimeSpan CacheExpiration = TimeSpan.FromMinutes(30);
    private static readonly ResourceManager? EmailResourceManager = new ResourceManager("Takt.Infrastructure.Resources.EmailResources", typeof(EmailResources).Assembly);

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="localizer">字符串本地化器（SharedResources）</param>
    /// <param name="emailLocalizer">邮件模板本地化器（EmailResources，与 SharedResources 同目录）</param>
    /// <param name="translationRepository">翻译仓储</param>
    /// <param name="httpContextAccessor">HTTP上下文访问器</param>
    /// <param name="memoryCache">内存缓存</param>
    public TaktLocalizer(
        IStringLocalizer<SharedResources> localizer,
        IStringLocalizer<EmailResources> emailLocalizer,
        ITaktRepository<TaktTranslation> translationRepository,
        IHttpContextAccessor httpContextAccessor,
        IMemoryCache memoryCache)
    {
        _localizer = localizer;
        _emailLocalizer = emailLocalizer;
        _translationRepository = translationRepository;
        _httpContextAccessor = httpContextAccessor;
        _memoryCache = memoryCache;
    }

    /// <summary>
    /// 获取本地化字符串
    /// </summary>
    /// <param name="name">资源键名</param>
    /// <param name="resourceType">资源类型（Frontend=前端，Backend=后端，Email=邮件模板），默认为Backend</param>
    /// <returns>本地化字符串</returns>
    public string GetString(string name, string resourceType = "Backend")
    {
        if (resourceType == ResourceTypeEmail)
        {
            var value = _emailLocalizer[name].Value ?? name;
            if (value == name && EmailResourceManager != null)
                value = GetEmailStringFromResourceManager(name, GetCurrentCultureInfo()) ?? name;
            return value;
        }

        // 1. 优先从数据库获取翻译
        var translation = GetTranslationFromDatabase(name, resourceType);
        if (!string.IsNullOrEmpty(translation))
        {
            return translation;
        }

        // 2. 回退到资源文件
        return _localizer[name].Value ?? name;
    }

    /// <summary>
    /// 获取本地化字符串（带参数）
    /// </summary>
    /// <param name="name">资源键名</param>
    /// <param name="resourceType">资源类型（Frontend=前端，Backend=后端，Email=邮件模板），默认为Backend</param>
    /// <param name="arguments">参数数组</param>
    /// <returns>本地化字符串</returns>
    public string GetString(string name, string resourceType, params object[] arguments)
    {
        if (resourceType == ResourceTypeEmail)
        {
            var value = _emailLocalizer[name, arguments].Value ?? name;
            if (value == name && EmailResourceManager != null)
            {
                var format = GetEmailStringFromResourceManager(name, GetCurrentCultureInfo());
                if (!string.IsNullOrEmpty(format))
                {
                    try { value = string.Format(format, arguments); }
                    catch { value = format; }
                }
            }
            return value;
        }

        // 1. 优先从数据库获取翻译
        var translation = GetTranslationFromDatabase(name, resourceType);
        if (!string.IsNullOrEmpty(translation))
        {
            try
            {
                return string.Format(translation, arguments);
            }
            catch
            {
                return translation;
            }
        }

        // 2. 回退到资源文件
        return _localizer[name, arguments].Value ?? name;
    }

    /// <summary>
    /// 当 IStringLocalizer 返回键名时，从程序集内嵌的 EmailResources 按「当前请求文化 → zh-CN → 中性」顺序回退取字符串（保证邮件内容始终能本地化且与请求语言一致）
    /// </summary>
    /// <param name="name">资源键</param>
    /// <param name="preferredCulture">优先使用的文化（通常为当前请求文化），为 null 时仅按 zh-CN、InvariantCulture 回退</param>
    private static string? GetEmailStringFromResourceManager(string name, CultureInfo? preferredCulture)
    {
        if (EmailResourceManager == null) return null;
        try
        {
            if (preferredCulture != null)
            {
                var value = EmailResourceManager.GetString(name, preferredCulture);
                if (!string.IsNullOrEmpty(value)) return value;
            }
            var valueZhCn = EmailResourceManager.GetString(name, CultureInfo.GetCultureInfo("zh-CN"));
            if (!string.IsNullOrEmpty(valueZhCn)) return valueZhCn;
            return EmailResourceManager.GetString(name, CultureInfo.InvariantCulture);
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// 获取当前请求对应的 CultureInfo（与 GetCurrentCultureCode 一致，供 Email 回退使用）
    /// </summary>
    private CultureInfo? GetCurrentCultureInfo()
    {
        var code = GetCurrentCultureCode();
        if (string.IsNullOrEmpty(code)) return null;
        try
        {
            return CultureInfo.GetCultureInfo(code);
        }
        catch
        {
            return null;
        }
    }

    /// <summary>
    /// 从数据库获取翻译
    /// </summary>
    /// <param name="resourceKey">资源键</param>
    /// <param name="resourceType">资源类型</param>
    /// <returns>翻译值，如果不存在则返回null</returns>
    private string? GetTranslationFromDatabase(string resourceKey, string resourceType)
    {
        try
        {
            // 获取当前语言（优先从请求上下文获取，回退到操作系统语言）
            var cultureCode = GetCurrentCultureCode();
            
            // 如果无法获取，使用操作系统默认语言
            if (string.IsNullOrEmpty(cultureCode))
            {
                cultureCode = GetDefaultCultureFromOperatingSystem();
            }
            
            // 如果仍然为空，直接返回null
            if (string.IsNullOrEmpty(cultureCode))
            {
                return null;
            }

            // 构建缓存键
            var cacheKey = $"{CacheKeyPrefix}{cultureCode}_{resourceType}_{resourceKey}";

            // 从缓存获取
            if (_memoryCache.TryGetValue(cacheKey, out string? cachedTranslation) && !string.IsNullOrEmpty(cachedTranslation))
            {
                return cachedTranslation;
            }

            // 从数据库查询（使用同步方式以避免异步上下文问题）
            TaktTranslation? translation = null;
            try
            {
                translation = _translationRepository.GetAsync(t =>
                    t.ResourceKey == resourceKey &&
                    t.CultureCode == cultureCode &&
                    t.ResourceType == resourceType &&
                    t.IsDeleted == 0).GetAwaiter().GetResult();
            }
            catch
            {
                // 查询失败时忽略，回退到资源文件
                return null;
            }

            if (translation == null || string.IsNullOrEmpty(translation.TranslationValue))
            {
                return null;
            }

            _memoryCache.Set(cacheKey, translation.TranslationValue, CacheExpiration);
            return translation.TranslationValue;
        }
        catch
        {
            // 查询失败时返回null，回退到资源文件
            return null;
        }
    }

    /// <summary>
    /// 获取当前请求的语言编码
    /// </summary>
    /// <returns>语言编码（如：zh-CN），如果无法获取则返回默认语言</returns>
    private string GetCurrentCultureCode()
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext != null)
        {
            // 从请求特征中获取
            var requestCulture = httpContext.Features.Get<Microsoft.AspNetCore.Localization.IRequestCultureFeature>();
            if (requestCulture?.RequestCulture?.UICulture != null)
            {
                return requestCulture.RequestCulture.UICulture.Name;
            }
        }

        // 回退到当前线程的UI文化
        var currentCulture = CultureInfo.CurrentUICulture.Name;
        if (!string.IsNullOrEmpty(currentCulture))
        {
            return currentCulture;
        }

        // 最后回退到操作系统默认语言
        return GetDefaultCultureFromOperatingSystem();
    }

    /// <summary>
    /// 从操作系统获取默认语言
    /// </summary>
    /// <returns>默认语言编码（如：zh-CN）</returns>
    private string GetDefaultCultureFromOperatingSystem()
    {
        try
        {
            // 使用 TaktServHelper 获取操作系统语言信息
            var osLanguage = TaktServHelper.GetOperatingSystemLanguage();
            
            // 优先使用当前UI文化
            if (!string.IsNullOrEmpty(osLanguage.CurrentUICulture))
            {
                return osLanguage.CurrentUICulture;
            }
            
            // 其次使用当前文化
            if (!string.IsNullOrEmpty(osLanguage.CurrentCulture))
            {
                return osLanguage.CurrentCulture;
            }
            
            // 使用系统默认语言
            if (!string.IsNullOrEmpty(osLanguage.SystemDefaultLanguage))
            {
                return osLanguage.SystemDefaultLanguage;
            }
        }
        catch
        {
            // 如果获取失败，使用备用方案
        }

        // 最后回退到 .NET 默认文化或 "zh-CN"
        try
        {
            return CultureInfo.InstalledUICulture.Name;
        }
        catch
        {
            return "zh-CN"; // 最终回退值
        }
    }

    /// <summary>
    /// 清除翻译缓存（当翻译更新时调用）
    /// </summary>
    /// <param name="cultureCode">语言编码，如果为null则清除所有语言的缓存</param>
    /// <param name="resourceType">资源类型，如果为null则清除所有类型的缓存</param>
    public void ClearCache(string? cultureCode = null, string? resourceType = null)
    {
        // 注意：IMemoryCache 没有提供直接清除所有键的功能
        // 这里只是提供一个接口，实际使用时需要记录缓存键或使用其他缓存方案
        // 对于简单场景，可以重启应用或等待缓存过期
    }
}
