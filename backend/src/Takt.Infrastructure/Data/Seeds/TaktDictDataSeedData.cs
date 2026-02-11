// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：Takt.Infrastructure.Data.Seeds
// 文件名称：TaktDictDataSeedData.cs
// 创建时间：2025-01-20
// 创建人：Takt365(Cursor AI)
// 功能描述：Takt字典数据种子数据，初始化系统内置字典数据
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using Microsoft.Extensions.DependencyInjection;
using Takt.Domain.Entities.Routine.Dict;
using Takt.Domain.Repositories;

namespace Takt.Infrastructure.Data.Seeds;

/// <summary>
/// Takt字典数据种子数据
/// </summary>
public class TaktDictDataSeedData : ITaktSeedData
{
    /// <summary>
    /// 执行顺序（字典数据应该在字典类型之后初始化）
    /// </summary>
    public int Order => 101;

    /// <summary>
    /// 初始化字典数据种子数据
    /// </summary>
    /// <param name="serviceProvider">服务提供者</param>
    /// <param name="configId">当前数据库配置ID</param>
    /// <returns>返回插入和更新的记录数（插入数, 更新数）</returns>
    public async Task<(int InsertCount, int UpdateCount)> SeedAsync(IServiceProvider serviceProvider, string configId)
    {
        var dictDataRepository = serviceProvider.GetRequiredService<ITaktRepository<TaktDictData>>();
        var dictTypeRepository = serviceProvider.GetRequiredService<ITaktRepository<TaktDictType>>();

        int insertCount = 0;
        int updateCount = 0;

        // 定义系统内置字典数据（按字典类型顺序）
        var dictDataList = new[]
        {
            // sys_normal_disable - 用户状态：0=启用，1=禁用，3=锁定
            new { DictTypeCode = "sys_normal_disable", DictLabel = "启用", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "启用状态" },
            new { DictTypeCode = "sys_normal_disable", DictLabel = "禁用", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "禁用状态" },
            new { DictTypeCode = "sys_normal_disable", DictLabel = "锁定", DictValue = "3", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "锁定状态" },
            
            // sys_yes_no - 是否：0=是/启用，1=否/禁用
            new { DictTypeCode = "sys_yes_no", DictLabel = "是", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "是" },
            new { DictTypeCode = "sys_yes_no", DictLabel = "否", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "否" },
            
            // sys_is_default - 是否默认：0=是/默认，1=否/非默认
            new { DictTypeCode = "sys_is_default", DictLabel = "是", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "是默认" },
            new { DictTypeCode = "sys_is_default", DictLabel = "否", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "非默认" },
            
            // sys_is_public - 是否公开：0=公开，1=私有
            new { DictTypeCode = "sys_is_public", DictLabel = "公开", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "公开" },
            new { DictTypeCode = "sys_is_public", DictLabel = "私有", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "私有" },
            
            // sys_oper_type - 操作类型：1=新增，2=修改，3=删除，4=查询，5=导出，6=导入，7=授权，8=强退，9=生成代码，10=清空数据
            new { DictTypeCode = "sys_oper_type", DictLabel = "新增", DictValue = "1", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "新增操作" },
            new { DictTypeCode = "sys_oper_type", DictLabel = "修改", DictValue = "2", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "修改操作" },
            new { DictTypeCode = "sys_oper_type", DictLabel = "删除", DictValue = "3", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "删除操作" },
            new { DictTypeCode = "sys_oper_type", DictLabel = "查询", DictValue = "4", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "查询操作" },
            new { DictTypeCode = "sys_oper_type", DictLabel = "导出", DictValue = "5", OrderNum = 5, CssClass = 5, ListClass = 5, Remark = "导出操作" },
            new { DictTypeCode = "sys_oper_type", DictLabel = "导入", DictValue = "6", OrderNum = 6, CssClass = 6, ListClass = 6, Remark = "导入操作" },
            new { DictTypeCode = "sys_oper_type", DictLabel = "授权", DictValue = "7", OrderNum = 7, CssClass = 7, ListClass = 7, Remark = "授权操作" },
            new { DictTypeCode = "sys_oper_type", DictLabel = "强退", DictValue = "8", OrderNum = 8, CssClass = 8, ListClass = 8, Remark = "强退操作" },
            new { DictTypeCode = "sys_oper_type", DictLabel = "生成代码", DictValue = "9", OrderNum = 9, CssClass = 9, ListClass = 9, Remark = "生成代码操作" },
            new { DictTypeCode = "sys_oper_type", DictLabel = "清空数据", DictValue = "10", OrderNum = 10, CssClass = 10, ListClass = 10, Remark = "清空数据操作" },
            
            // sys_user_gender - 用户性别：0=未知，1=男，2=女
            new { DictTypeCode = "sys_user_gender", DictLabel = "未知", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "未知性别" },
            new { DictTypeCode = "sys_user_gender", DictLabel = "男", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "男性" },
            new { DictTypeCode = "sys_user_gender", DictLabel = "女", DictValue = "2", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "女性" },
            
            // sys_user_type - 用户类型：0=普通用户，1=管理员，2=超级管理员
            new { DictTypeCode = "sys_user_type", DictLabel = "普通用户", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "普通用户" },
            new { DictTypeCode = "sys_user_type", DictLabel = "管理员", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "管理员" },
            new { DictTypeCode = "sys_user_type", DictLabel = "超级管理员", DictValue = "2", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "超级管理员" },
            
            // sys_data_scope - 数据范围：0=全部数据，1=本部门数据，2=本部门及以下数据，3=仅本人数据，4=自定义数据范围
            new { DictTypeCode = "sys_data_scope", DictLabel = "全部数据", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "全部数据" },
            new { DictTypeCode = "sys_data_scope", DictLabel = "本部门数据", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "本部门数据" },
            new { DictTypeCode = "sys_data_scope", DictLabel = "本部门及以下数据", DictValue = "2", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "本部门及以下数据" },
            new { DictTypeCode = "sys_data_scope", DictLabel = "仅本人数据", DictValue = "3", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "仅本人数据" },
            new { DictTypeCode = "sys_data_scope", DictLabel = "自定义数据范围", DictValue = "4", OrderNum = 5, CssClass = 5, ListClass = 5, Remark = "自定义数据范围" },
            
            // sys_menu_type - 菜单类型：0=目录，1=菜单，2=按钮
            new { DictTypeCode = "sys_menu_type", DictLabel = "目录", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "目录" },
            new { DictTypeCode = "sys_menu_type", DictLabel = "菜单", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "菜单" },
            new { DictTypeCode = "sys_menu_type", DictLabel = "按钮", DictValue = "2", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "按钮" },
            
            // sys_dept_type - 部门类型：0=直接，1=间接
            new { DictTypeCode = "sys_dept_type", DictLabel = "直接", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "直接" },
            new { DictTypeCode = "sys_dept_type", DictLabel = "间接", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "间接" },
            
            // sys_post_category - 岗位类别：管理类、技术类、业务类、支持类
            new { DictTypeCode = "sys_post_category", DictLabel = "管理类", DictValue = "management", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "管理类岗位" },
            new { DictTypeCode = "sys_post_category", DictLabel = "技术类", DictValue = "technical", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "技术类岗位" },
            new { DictTypeCode = "sys_post_category", DictLabel = "业务类", DictValue = "business", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "业务类岗位" },
            new { DictTypeCode = "sys_post_category", DictLabel = "支持类", DictValue = "support", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "支持类岗位" },
            
            // sys_post_level - 岗位级别：1=初级，2=中级，3=高级，4=专家，5=资深
            new { DictTypeCode = "sys_post_level", DictLabel = "初级", DictValue = "1", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "初级岗位" },
            new { DictTypeCode = "sys_post_level", DictLabel = "中级", DictValue = "2", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "中级岗位" },
            new { DictTypeCode = "sys_post_level", DictLabel = "高级", DictValue = "3", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "高级岗位" },
            new { DictTypeCode = "sys_post_level", DictLabel = "专家", DictValue = "4", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "专家岗位" },
            new { DictTypeCode = "sys_post_level", DictLabel = "资深", DictValue = "5", OrderNum = 5, CssClass = 5, ListClass = 5, Remark = "资深岗位" },
            
            // sys_notice_type - 公告类型：0=通知，1=公告，2=新闻，3=活动
            new { DictTypeCode = "sys_notice_type", DictLabel = "通知", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "通知" },
            new { DictTypeCode = "sys_notice_type", DictLabel = "公告", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "公告" },
            new { DictTypeCode = "sys_notice_type", DictLabel = "新闻", DictValue = "2", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "新闻" },
            new { DictTypeCode = "sys_notice_type", DictLabel = "活动", DictValue = "3", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "活动" },
            
            // sys_publish_scope - 发布范围：0=全部，1=指定部门，2=指定用户，3=指定角色
            new { DictTypeCode = "sys_publish_scope", DictLabel = "全部", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "全部" },
            new { DictTypeCode = "sys_publish_scope", DictLabel = "指定部门", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "指定部门" },
            new { DictTypeCode = "sys_publish_scope", DictLabel = "指定用户", DictValue = "2", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "指定用户" },
            new { DictTypeCode = "sys_publish_scope", DictLabel = "指定角色", DictValue = "3", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "指定角色" },
            
            // sys_urgency_level - 是否紧急：0=一般，1=紧急，2=非常紧急
            new { DictTypeCode = "sys_urgency_level", DictLabel = "一般", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "一般" },
            new { DictTypeCode = "sys_urgency_level", DictLabel = "紧急", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "紧急" },
            new { DictTypeCode = "sys_urgency_level", DictLabel = "非常紧急", DictValue = "2", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "非常紧急" },
            
            // sys_notice_status - 公告状态：0=草稿，1=已发布，2=已撤回，3=已过期
            new { DictTypeCode = "sys_notice_status", DictLabel = "草稿", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "草稿" },
            new { DictTypeCode = "sys_notice_status", DictLabel = "已发布", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "已发布" },
            new { DictTypeCode = "sys_notice_status", DictLabel = "已撤回", DictValue = "2", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "已撤回" },
            new { DictTypeCode = "sys_notice_status", DictLabel = "已过期", DictValue = "3", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "已过期" },
            
            // sys_list_class - 列表类名（用于前端样式控制，这里不预设具体值，由业务系统动态管理）
            
            // sys_storage_type - 存储方式：0=本地存储，1=OSS对象存储，2=FTP
            new { DictTypeCode = "sys_storage_type", DictLabel = "本地存储", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "本地存储" },
            new { DictTypeCode = "sys_storage_type", DictLabel = "OSS对象存储", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "OSS对象存储" },
            new { DictTypeCode = "sys_storage_type", DictLabel = "FTP", DictValue = "2", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "FTP" },
            
            // sys_file_category - 文件分类：0=文档，1=图片，2=视频，3=音频，4=压缩包，5=其他
            new { DictTypeCode = "sys_file_category", DictLabel = "文档", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "文档" },
            new { DictTypeCode = "sys_file_category", DictLabel = "图片", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "图片" },
            new { DictTypeCode = "sys_file_category", DictLabel = "视频", DictValue = "2", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "视频" },
            new { DictTypeCode = "sys_file_category", DictLabel = "音频", DictValue = "3", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "音频" },
            new { DictTypeCode = "sys_file_category", DictLabel = "压缩包", DictValue = "4", OrderNum = 5, CssClass = 5, ListClass = 5, Remark = "压缩包" },
            new { DictTypeCode = "sys_file_category", DictLabel = "其他", DictValue = "5", OrderNum = 6, CssClass = 6, ListClass = 6, Remark = "其他" },
            
            // sys_file_status - 文件状态：0=正常，1=已锁定，2=已归档，3=已删除
            new { DictTypeCode = "sys_file_status", DictLabel = "正常", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "正常" },
            new { DictTypeCode = "sys_file_status", DictLabel = "已锁定", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "已锁定" },
            new { DictTypeCode = "sys_file_status", DictLabel = "已归档", DictValue = "2", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "已归档" },
            new { DictTypeCode = "sys_file_status", DictLabel = "已删除", DictValue = "3", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "已删除" },
            
            // sys_language_code - 语言编码：ISO 639-1/639-2，按 DictValue 字母排序（联合国6种官方语言+日语+韩语）
            new { DictTypeCode = "sys_language_code", DictLabel = "العربية", DictValue = "ar-SA", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "阿拉伯语" },
            new { DictTypeCode = "sys_language_code", DictLabel = "English", DictValue = "en-US", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "英语" },
            new { DictTypeCode = "sys_language_code", DictLabel = "Español", DictValue = "es-ES", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "西班牙语" },
            new { DictTypeCode = "sys_language_code", DictLabel = "Français", DictValue = "fr-FR", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "法语" },
            new { DictTypeCode = "sys_language_code", DictLabel = "日本語", DictValue = "ja-JP", OrderNum = 5, CssClass = 5, ListClass = 5, Remark = "日语" },
            new { DictTypeCode = "sys_language_code", DictLabel = "한국어", DictValue = "ko-KR", OrderNum = 6, CssClass = 6, ListClass = 6, Remark = "韩语" },
            new { DictTypeCode = "sys_language_code", DictLabel = "Русский", DictValue = "ru-RU", OrderNum = 7, CssClass = 7, ListClass = 7, Remark = "俄语" },
            new { DictTypeCode = "sys_language_code", DictLabel = "简体中文", DictValue = "zh-CN", OrderNum = 8, CssClass = 8, ListClass = 8, Remark = "中文（简体）" },
            new { DictTypeCode = "sys_language_code", DictLabel = "繁體中文", DictValue = "zh-TW", OrderNum = 9, CssClass = 9, ListClass = 9, Remark = "中文（繁体）" },
            
            // sys_resource_type - 资源类型：Frontend=前端，Backend=后端
            new { DictTypeCode = "sys_resource_type", DictLabel = "前端", DictValue = "Frontend", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "前端" },
            new { DictTypeCode = "sys_resource_type", DictLabel = "后端", DictValue = "Backend", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "后端" },
            
            // sys_mail_type - 邮件类型：0=普通邮件，1=系统邮件，2=通知邮件，3=提醒邮件
            new { DictTypeCode = "sys_mail_type", DictLabel = "普通邮件", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "普通邮件" },
            new { DictTypeCode = "sys_mail_type", DictLabel = "系统邮件", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "系统邮件" },
            new { DictTypeCode = "sys_mail_type", DictLabel = "通知邮件", DictValue = "2", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "通知邮件" },
            new { DictTypeCode = "sys_mail_type", DictLabel = "提醒邮件", DictValue = "3", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "提醒邮件" },
            
            // sys_mail_status - 邮件状态：0=草稿，1=已发送，2=发送失败，3=已撤回，4=定时发送中
            new { DictTypeCode = "sys_mail_status", DictLabel = "草稿", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "草稿" },
            new { DictTypeCode = "sys_mail_status", DictLabel = "已发送", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "已发送" },
            new { DictTypeCode = "sys_mail_status", DictLabel = "发送失败", DictValue = "2", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "发送失败" },
            new { DictTypeCode = "sys_mail_status", DictLabel = "已撤回", DictValue = "3", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "已撤回" },
            new { DictTypeCode = "sys_mail_status", DictLabel = "定时发送中", DictValue = "4", OrderNum = 5, CssClass = 5, ListClass = 5, Remark = "定时发送中" },
            
            // sys_news_category - 新闻分类：0=公司新闻，1=行业动态，2=技术分享，3=产品发布，4=活动资讯，5=其他
            new { DictTypeCode = "sys_news_category", DictLabel = "公司新闻", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "公司新闻" },
            new { DictTypeCode = "sys_news_category", DictLabel = "行业动态", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "行业动态" },
            new { DictTypeCode = "sys_news_category", DictLabel = "技术分享", DictValue = "2", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "技术分享" },
            new { DictTypeCode = "sys_news_category", DictLabel = "产品发布", DictValue = "3", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "产品发布" },
            new { DictTypeCode = "sys_news_category", DictLabel = "活动资讯", DictValue = "4", OrderNum = 5, CssClass = 5, ListClass = 5, Remark = "活动资讯" },
            new { DictTypeCode = "sys_news_category", DictLabel = "其他", DictValue = "5", OrderNum = 6, CssClass = 6, ListClass = 6, Remark = "其他" },
            
            // sys_news_status - 新闻状态：0=草稿，1=已发布，2=已撤回，3=已过期
            new { DictTypeCode = "sys_news_status", DictLabel = "草稿", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "草稿" },
            new { DictTypeCode = "sys_news_status", DictLabel = "已发布", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "已发布" },
            new { DictTypeCode = "sys_news_status", DictLabel = "已撤回", DictValue = "2", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "已撤回" },
            new { DictTypeCode = "sys_news_status", DictLabel = "已过期", DictValue = "3", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "已过期" },
            
            // sys_setting_group - 设置分组：backend=后端，frontend=前端
            new { DictTypeCode = "sys_setting_group", DictLabel = "后端", DictValue = "backend", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "后端" },
            new { DictTypeCode = "sys_setting_group", DictLabel = "前端", DictValue = "frontend", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "前端" },
            
            // sys_message_type - 消息类型：Text=文本，Image=图片，File=文件，System=系统消息
            new { DictTypeCode = "sys_message_type", DictLabel = "文本", DictValue = "Text", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "文本" },
            new { DictTypeCode = "sys_message_type", DictLabel = "图片", DictValue = "Image", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "图片" },
            new { DictTypeCode = "sys_message_type", DictLabel = "文件", DictValue = "File", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "文件" },
            new { DictTypeCode = "sys_message_type", DictLabel = "系统消息", DictValue = "Takt365", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "系统消息" },
            
            // sys_message_group - 消息分组：Chat=聊天，Notification=通知，Alert=提醒
            new { DictTypeCode = "sys_message_group", DictLabel = "聊天", DictValue = "Chat", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "聊天" },
            new { DictTypeCode = "sys_message_group", DictLabel = "通知", DictValue = "Notification", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "通知" },
            new { DictTypeCode = "sys_message_group", DictLabel = "提醒", DictValue = "Alert", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "提醒" },
            
            // sys_read_status - 读取状态：0=未读，1=已读
            new { DictTypeCode = "sys_read_status", DictLabel = "未读", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "未读" },
            new { DictTypeCode = "sys_read_status", DictLabel = "已读", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "已读" },
            
            // sys_online_status - 在线状态：0=在线，1=离线，2=离开
            new { DictTypeCode = "sys_online_status", DictLabel = "在线", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "在线" },
            new { DictTypeCode = "sys_online_status", DictLabel = "离线", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "离线" },
            new { DictTypeCode = "sys_online_status", DictLabel = "离开", DictValue = "2", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "离开" },
            
            // sys_form_category - 表单分类：0=通用表单，1=业务表单，2=系统表单
            new { DictTypeCode = "sys_form_category", DictLabel = "通用表单", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "通用表单" },
            new { DictTypeCode = "sys_form_category", DictLabel = "业务表单", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "业务表单" },
            new { DictTypeCode = "sys_form_category", DictLabel = "系统表单", DictValue = "2", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "系统表单" },
            
            // sys_form_type - 表单类型：0=动态表单，1=静态表单，2=自定义表单
            new { DictTypeCode = "sys_form_type", DictLabel = "动态表单", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "动态表单" },
            new { DictTypeCode = "sys_form_type", DictLabel = "静态表单", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "静态表单" },
            new { DictTypeCode = "sys_form_type", DictLabel = "自定义表单", DictValue = "2", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "自定义表单" },
            
            // sys_priority - 优先级：0=低，1=中，2=高，3=紧急
            new { DictTypeCode = "sys_priority", DictLabel = "低", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "低" },
            new { DictTypeCode = "sys_priority", DictLabel = "中", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "中" },
            new { DictTypeCode = "sys_priority", DictLabel = "高", DictValue = "2", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "高" },
            new { DictTypeCode = "sys_priority", DictLabel = "紧急", DictValue = "3", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "紧急" },
            
            // sys_flow_category - 流程分类：0=通用流程，1=业务流程，2=系统流程
            new { DictTypeCode = "sys_flow_category", DictLabel = "通用流程", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "通用流程" },
            new { DictTypeCode = "sys_flow_category", DictLabel = "业务流程", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "业务流程" },
            new { DictTypeCode = "sys_flow_category", DictLabel = "系统流程", DictValue = "2", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "系统流程" },
            
            // sys_gen_template_type - 生成模板类型：crud=单表操作，tree=树表操作，sub=主子表操作
            new { DictTypeCode = "sys_gen_template_type", DictLabel = "单表操作", DictValue = "crud", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "单表操作" },
            new { DictTypeCode = "sys_gen_template_type", DictLabel = "树表操作", DictValue = "tree", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "树表操作" },
            new { DictTypeCode = "sys_gen_template_type", DictLabel = "主子表操作", DictValue = "sub", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "主子表操作" },

            // sys_gen_method - 生成方式：0=zip 压缩包，1=自定义路径，2=当前项目
            new { DictTypeCode = "sys_gen_method", DictLabel = "zip 压缩包", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "zip 压缩包" },
            new { DictTypeCode = "sys_gen_method", DictLabel = "自定义路径", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "自定义路径" },
            new { DictTypeCode = "sys_gen_method", DictLabel = "当前项目", DictValue = "2", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "当前项目" },

            // sys_sort_type - 排序类型：asc=升序，desc=降序
            new { DictTypeCode = "sys_sort_type", DictLabel = "升序", DictValue = "asc", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "升序" },
            new { DictTypeCode = "sys_sort_type", DictLabel = "降序", DictValue = "desc", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "降序" },

            // sys_dto_category - 传输对象类别：Dto,QueryDto,CreateDto,UpdateDto,TemplateDto,ImportDto,ExportDto等
            new { DictTypeCode = "sys_dto_category", DictLabel = "Dto", DictValue = "Dto", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "Dto" },
            new { DictTypeCode = "sys_dto_category", DictLabel = "QueryDto", DictValue = "QueryDto", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "QueryDto" },
            new { DictTypeCode = "sys_dto_category", DictLabel = "CreateDto", DictValue = "CreateDto", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "CreateDto" },
            new { DictTypeCode = "sys_dto_category", DictLabel = "UpdateDto", DictValue = "UpdateDto", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "UpdateDto" },
            new { DictTypeCode = "sys_dto_category", DictLabel = "TemplateDto", DictValue = "TemplateDto", OrderNum = 5, CssClass = 5, ListClass = 5, Remark = "TemplateDto" },
            new { DictTypeCode = "sys_dto_category", DictLabel = "ImportDto", DictValue = "ImportDto", OrderNum = 6, CssClass = 6, ListClass = 6, Remark = "ImportDto" },
            new { DictTypeCode = "sys_dto_category", DictLabel = "ExportDto", DictValue = "ExportDto", OrderNum = 7, CssClass = 7, ListClass = 7, Remark = "ExportDto" },
            
            // sys_gen_function - 生成功能：查询，新增，更新，删除，模板，导入，导出（DictValue 与后端 ParseGenFunctionKeys 期望的中文键一致）
            new { DictTypeCode = "sys_gen_function", DictLabel = "查询", DictValue = "查询", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "查询" },
            new { DictTypeCode = "sys_gen_function", DictLabel = "新增", DictValue = "新增", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "新增" },
            new { DictTypeCode = "sys_gen_function", DictLabel = "更新", DictValue = "更新", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "更新" },
            new { DictTypeCode = "sys_gen_function", DictLabel = "删除", DictValue = "删除", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "删除" },
            new { DictTypeCode = "sys_gen_function", DictLabel = "模板", DictValue = "模板", OrderNum = 5, CssClass = 5, ListClass = 5, Remark = "模板" },
            new { DictTypeCode = "sys_gen_function", DictLabel = "导入", DictValue = "导入", OrderNum = 6, CssClass = 6, ListClass = 6, Remark = "导入" },
            new { DictTypeCode = "sys_gen_function", DictLabel = "导出", DictValue = "导出", OrderNum = 7, CssClass = 7, ListClass = 7, Remark = "导出" },
            
            // sys_frontend_template - 前端模板：1=element plus，2=ant design vue
            new { DictTypeCode = "sys_frontend_template", DictLabel = "element plus", DictValue = "1", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "element plus" },
            new { DictTypeCode = "sys_frontend_template", DictLabel = "ant design vue", DictValue = "2", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "ant design vue" },
            
            // sys_frontend_style - 前端样式：12=一行一列，24=一行两列
            new { DictTypeCode = "sys_frontend_style", DictLabel = "一行一列", DictValue = "12", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "一行一列" },
            new { DictTypeCode = "sys_frontend_style", DictLabel = "一行两列", DictValue = "24", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "一行两列" },
            
            // sys_button_style - 操作按钮样式：0=文本，1=标准
            new { DictTypeCode = "sys_button_style", DictLabel = "文本", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "文本" },
            new { DictTypeCode = "sys_button_style", DictLabel = "标准", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "标准" },
            
            // sys_csharp_type - C#类型：对应C#数据类型，按 DictValue 字母排序
            new { DictTypeCode = "sys_csharp_type", DictLabel = "bool", DictValue = "bool", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "bool" },
            new { DictTypeCode = "sys_csharp_type", DictLabel = "byte", DictValue = "byte", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "byte" },
            new { DictTypeCode = "sys_csharp_type", DictLabel = "DateTime", DictValue = "DateTime", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "DateTime" },
            new { DictTypeCode = "sys_csharp_type", DictLabel = "decimal", DictValue = "decimal", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "decimal" },
            new { DictTypeCode = "sys_csharp_type", DictLabel = "double", DictValue = "double", OrderNum = 5, CssClass = 5, ListClass = 5, Remark = "double" },
            new { DictTypeCode = "sys_csharp_type", DictLabel = "float", DictValue = "float", OrderNum = 6, CssClass = 6, ListClass = 6, Remark = "float" },
            new { DictTypeCode = "sys_csharp_type", DictLabel = "Guid", DictValue = "Guid", OrderNum = 7, CssClass = 7, ListClass = 7, Remark = "Guid" },
            new { DictTypeCode = "sys_csharp_type", DictLabel = "int", DictValue = "int", OrderNum = 8, CssClass = 8, ListClass = 8, Remark = "int" },
            new { DictTypeCode = "sys_csharp_type", DictLabel = "long", DictValue = "long", OrderNum = 9, CssClass = 9, ListClass = 9, Remark = "long" },
            new { DictTypeCode = "sys_csharp_type", DictLabel = "string", DictValue = "string", OrderNum = 10, CssClass = 10, ListClass = 10, Remark = "string" },
            
            // sys_db_type - 数据库数据类型：按 DictValue 字母排序
            new { DictTypeCode = "sys_db_type", DictLabel = "bigint", DictValue = "bigint", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "bigint" },
            new { DictTypeCode = "sys_db_type", DictLabel = "bit", DictValue = "bit", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "bit" },
            new { DictTypeCode = "sys_db_type", DictLabel = "datetime", DictValue = "datetime", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "datetime" },
            new { DictTypeCode = "sys_db_type", DictLabel = "decimal", DictValue = "decimal", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "decimal" },
            new { DictTypeCode = "sys_db_type", DictLabel = "int", DictValue = "int", OrderNum = 5, CssClass = 5, ListClass = 5, Remark = "int" },
            new { DictTypeCode = "sys_db_type", DictLabel = "ntext", DictValue = "ntext", OrderNum = 6, CssClass = 6, ListClass = 6, Remark = "ntext" },
            new { DictTypeCode = "sys_db_type", DictLabel = "nvarchar", DictValue = "nvarchar", OrderNum = 7, CssClass = 7, ListClass = 7, Remark = "nvarchar" },
            new { DictTypeCode = "sys_db_type", DictLabel = "text", DictValue = "text", OrderNum = 8, CssClass = 8, ListClass = 8, Remark = "text" },
            new { DictTypeCode = "sys_db_type", DictLabel = "uniqueidentifier", DictValue = "uniqueidentifier", OrderNum = 9, CssClass = 9, ListClass = 9, Remark = "uniqueidentifier" },
            new { DictTypeCode = "sys_db_type", DictLabel = "varchar", DictValue = "varchar", OrderNum = 10, CssClass = 10, ListClass = 10, Remark = "varchar" },
            
            // sys_query_type - 查询方式：EQ=等于，NE=不等于，GT=大于，GTE=大于等于，LT=小于，LTE=小于等于，LIKE=模糊，BETWEEN=范围
            new { DictTypeCode = "sys_query_type", DictLabel = "等于", DictValue = "EQ", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "等于" },
            new { DictTypeCode = "sys_query_type", DictLabel = "不等于", DictValue = "NE", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "不等于" },
            new { DictTypeCode = "sys_query_type", DictLabel = "大于", DictValue = "GT", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "大于" },
            new { DictTypeCode = "sys_query_type", DictLabel = "大于等于", DictValue = "GTE", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "大于等于" },
            new { DictTypeCode = "sys_query_type", DictLabel = "小于", DictValue = "LT", OrderNum = 5, CssClass = 5, ListClass = 5, Remark = "小于" },
            new { DictTypeCode = "sys_query_type", DictLabel = "小于等于", DictValue = "LTE", OrderNum = 6, CssClass = 6, ListClass = 6, Remark = "小于等于" },
            new { DictTypeCode = "sys_query_type", DictLabel = "模糊", DictValue = "LIKE", OrderNum = 7, CssClass = 7, ListClass = 7, Remark = "模糊" },
            new { DictTypeCode = "sys_query_type", DictLabel = "范围", DictValue = "BETWEEN", OrderNum = 8, CssClass = 8, ListClass = 8, Remark = "范围" },
            
            // sys_display_type - 显示类型：input=文本框，InputNumber=数字输入框，select=下拉框，checkbox=复选框，radio=单选框，date=日期控件，time=时间控件，image=图片上传，file=文件上传，slider=滑块，switch=开关，Rate=评分，textarea=文本域，editor=富文本编辑器
            new { DictTypeCode = "sys_display_type", DictLabel = "文本框", DictValue = "input", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "文本框" },
            new { DictTypeCode = "sys_display_type", DictLabel = "数字输入框", DictValue = "InputNumber", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "数字输入框" },
            new { DictTypeCode = "sys_display_type", DictLabel = "下拉框", DictValue = "select", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "下拉框" },
            new { DictTypeCode = "sys_display_type", DictLabel = "复选框", DictValue = "checkbox", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "复选框" },
            new { DictTypeCode = "sys_display_type", DictLabel = "单选框", DictValue = "radio", OrderNum = 5, CssClass = 5, ListClass = 5, Remark = "单选框" },
            new { DictTypeCode = "sys_display_type", DictLabel = "日期控件", DictValue = "date", OrderNum = 6, CssClass = 6, ListClass = 6, Remark = "日期控件" },
            new { DictTypeCode = "sys_display_type", DictLabel = "时间控件", DictValue = "time", OrderNum = 7, CssClass = 7, ListClass = 7, Remark = "时间控件" },
            new { DictTypeCode = "sys_display_type", DictLabel = "图片上传", DictValue = "image", OrderNum = 8, CssClass = 8, ListClass = 8, Remark = "图片上传" },
            new { DictTypeCode = "sys_display_type", DictLabel = "文件上传", DictValue = "file", OrderNum = 9, CssClass = 9, ListClass = 9, Remark = "文件上传" },
            new { DictTypeCode = "sys_display_type", DictLabel = "滑块", DictValue = "slider", OrderNum = 10, CssClass = 10, ListClass = 10, Remark = "滑块" },
            new { DictTypeCode = "sys_display_type", DictLabel = "开关", DictValue = "switch", OrderNum = 11, CssClass = 11, ListClass = 11, Remark = "开关" },
            new { DictTypeCode = "sys_display_type", DictLabel = "评分", DictValue = "Rate", OrderNum = 12, CssClass = 12, ListClass = 12, Remark = "评分" },
            new { DictTypeCode = "sys_display_type", DictLabel = "文本域", DictValue = "textarea", OrderNum = 13, CssClass = 13, ListClass = 13, Remark = "文本域" },
            new { DictTypeCode = "sys_display_type", DictLabel = "富文本编辑器", DictValue = "editor", OrderNum = 14, CssClass = 14, ListClass = 14, Remark = "富文本编辑器" },
            
            // sys_storage_naming - 存储命名规则：0=原文件+哈希值，1=自动生成，2=自定义
            new { DictTypeCode = "sys_storage_naming", DictLabel = "原文件+哈希值", DictValue = "0", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "原文件+哈希值" },
            new { DictTypeCode = "sys_storage_naming", DictLabel = "自动生成", DictValue = "1", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "自动生成" },
            new { DictTypeCode = "sys_storage_naming", DictLabel = "自定义", DictValue = "2", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "自定义" },
            
            // sys_storage_directory - 存储目录：用于文件分类存储
            new { DictTypeCode = "sys_storage_directory", DictLabel = "默认目录", DictValue = "default", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "默认存储目录" },
            new { DictTypeCode = "sys_storage_directory", DictLabel = "文档目录", DictValue = "documents", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "文档存储目录" },
            new { DictTypeCode = "sys_storage_directory", DictLabel = "图片目录", DictValue = "images", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "图片存储目录" },
            new { DictTypeCode = "sys_storage_directory", DictLabel = "视频目录", DictValue = "videos", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "视频存储目录" },
            new { DictTypeCode = "sys_storage_directory", DictLabel = "音频目录", DictValue = "audios", OrderNum = 5, CssClass = 5, ListClass = 5, Remark = "音频存储目录" },
            new { DictTypeCode = "sys_storage_directory", DictLabel = "压缩包目录", DictValue = "archives", OrderNum = 6, CssClass = 6, ListClass = 6, Remark = "压缩包存储目录" },
            new { DictTypeCode = "sys_storage_directory", DictLabel = "临时目录", DictValue = "temp", OrderNum = 7, CssClass = 7, ListClass = 7, Remark = "临时文件存储目录" },
            
            // sys_oss_provider - OSS提供商类型：aliyun=阿里云OSS，tencent=腾讯云COS，huawei=华为云OBS，aws=AWS S3
            new { DictTypeCode = "sys_oss_provider", DictLabel = "阿里云OSS", DictValue = "aliyun", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "阿里云对象存储OSS" },
            new { DictTypeCode = "sys_oss_provider", DictLabel = "腾讯云COS", DictValue = "tencent", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "腾讯云对象存储COS" },
            new { DictTypeCode = "sys_oss_provider", DictLabel = "华为云OBS", DictValue = "huawei", OrderNum = 3, CssClass = 3, ListClass = 3, Remark = "华为云对象存储OBS" },
            new { DictTypeCode = "sys_oss_provider", DictLabel = "AWS S3", DictValue = "aws", OrderNum = 4, CssClass = 4, ListClass = 4, Remark = "亚马逊云对象存储S3" },
            
            // sys_ftp_provider - FTP服务提供商：teac_cn=TEAC FTP中国（ftp.teac.com.cn），teac_jp=TEAC FTP日本（rosu2.teac.co.jp）
            new { DictTypeCode = "sys_ftp_provider", DictLabel = "TEAC FTP中国", DictValue = "teac_cn", OrderNum = 1, CssClass = 1, ListClass = 1, Remark = "TEAC FTP服务（ftp.teac.com.cn）" },
            new { DictTypeCode = "sys_ftp_provider", DictLabel = "TEAC FTP日本", DictValue = "teac_jp", OrderNum = 2, CssClass = 2, ListClass = 2, Remark = "TEAC FTP服务（rosu2.teac.co.jp）" }
        };

        // 初始化每个字典数据项
        foreach (var dictData in dictDataList)
        {
            // 检查字典类型是否存在
            var dictType = await dictTypeRepository.GetAsync(dt => dt.DictTypeCode == dictData.DictTypeCode);
            if (dictType == null)
            {
                continue;
            }

            var existing = await dictDataRepository.GetAsync(dd => dd.DictTypeCode == dictData.DictTypeCode && dd.DictLabel == dictData.DictLabel);

            // 生成本地化键：dict.{DictTypeCode}.{DictValue}（必须为小写）
            var dictL10nKey = $"dict.{dictData.DictTypeCode.ToLower()}.{dictData.DictValue.ToLower()}";

            if (existing == null)
            {
                // 不存在则插入
                var newDictData = new TaktDictData
                {
                    DictTypeId = dictType.Id, // 设置字典类型ID（外键）
                    DictTypeCode = dictData.DictTypeCode,
                    DictLabel = dictData.DictLabel,
                    DictValue = dictData.DictValue,
                    DictL10nKey = dictL10nKey, // 设置本地化键
                    OrderNum = dictData.OrderNum,
                    CssClass = dictData.CssClass,
                    ListClass = dictData.ListClass,
                    ExtLabel = dictData.Remark, // 使用ExtLabel存储备注
                    IsDeleted = 0
                };
                await dictDataRepository.CreateAsync(newDictData);
                insertCount++;
            }
            else
            {
                // 存在则更新
                existing.DictTypeId = dictType.Id; // 确保DictTypeId正确（外键）
                existing.DictValue = dictData.DictValue;
                existing.DictL10nKey = dictL10nKey; // 更新本地化键
                existing.OrderNum = dictData.OrderNum;
                existing.CssClass = dictData.CssClass;
                existing.ListClass = dictData.ListClass;
                existing.ExtLabel = dictData.Remark;
                await dictDataRepository.UpdateAsync(existing);
                updateCount++;
            }
        }

        return (insertCount, updateCount);
    }
}
