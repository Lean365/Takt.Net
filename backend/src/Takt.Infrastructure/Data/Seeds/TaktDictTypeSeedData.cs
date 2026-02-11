// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：Takt.Infrastructure.Data.Seeds
// 文件名称：TaktDictTypeSeedData.cs
// 创建时间：2025-01-20
// 创建人：Takt365(Cursor AI)
// 功能描述：Takt字典类型种子数据，初始化系统内置字典类型
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using Microsoft.Extensions.DependencyInjection;
using Takt.Domain.Entities.Routine.Dict;
using Takt.Domain.Repositories;

namespace Takt.Infrastructure.Data.Seeds;

/// <summary>
/// Takt字典类型种子数据
/// </summary>
public class TaktDictTypeSeedData : ITaktSeedData
{
    /// <summary>
    /// 执行顺序（字典类型应该在字典数据之前初始化）
    /// </summary>
    public int Order => 100;

    /// <summary>
    /// 初始化字典类型种子数据
    /// </summary>
    /// <param name="serviceProvider">服务提供者</param>
    /// <param name="configId">当前数据库配置ID</param>
    /// <returns>返回插入和更新的记录数（插入数, 更新数）</returns>
    public async Task<(int InsertCount, int UpdateCount)> SeedAsync(IServiceProvider serviceProvider, string configId)
    {
        var dictTypeRepository = serviceProvider.GetRequiredService<ITaktRepository<TaktDictType>>();

        int insertCount = 0;
        int updateCount = 0;

        // 定义系统内置字典类型
        var dictTypes = new[]
        {
            new { Code = "sys_normal_disable", Name = "正常状态", Remark = "用户状态。0=启用，1=禁用，3=锁定", OrderNum = 1 },
            new { Code = "sys_yes_no", Name = "是否", Remark = "通用布尔标志。0=是/启用，1=否/禁用", OrderNum = 2 },
            new { Code = "sys_is_default", Name = "是否默认", Remark = "通用默认标志。0=是/默认，1=否/非默认", OrderNum = 3 },
            new { Code = "sys_is_public", Name = "是否公开", Remark = "是否公开标志。0=公开，1=私有", OrderNum = 4 },
            new { Code = "sys_oper_type", Name = "操作类型", Remark = "系统操作类型。1=新增，2=修改，3=删除，4=查询，5=导出，6=导入，7=授权，8=强退，9=生成代码，10=清空数据", OrderNum = 5 },
            new { Code = "sys_user_gender", Name = "用户性别", Remark = "用户性别。0=未知，1=男，2=女", OrderNum = 6 },
            new { Code = "sys_user_type", Name = "用户类型", Remark = "用户类型。0=普通用户，1=管理员，2=超级管理员", OrderNum = 7 },
            new { Code = "sys_data_scope", Name = "数据权限", Remark = "数据范围。0=全部数据，1=本部门数据，2=本部门及以下数据，3=仅本人数据，4=自定义数据范围", OrderNum = 8 },
            new { Code = "sys_menu_type", Name = "菜单类型", Remark = "菜单类型。0=目录，1=菜单，2=按钮", OrderNum = 9 },
            new { Code = "sys_dept_type", Name = "部门类型", Remark = "部门类型。0=直接，1=间接", OrderNum = 10 },
            new { Code = "sys_post_category", Name = "岗位类别", Remark = "岗位类别。管理类、技术类、业务类、支持类", OrderNum = 11 },
            new { Code = "sys_post_level", Name = "岗位级别", Remark = "岗位级别。1=初级，2=中级，3=高级，4=专家，5=资深", OrderNum = 12 },
            new { Code = "sys_notice_type", Name = "公告类型", Remark = "公告类型。0=通知，1=公告，2=新闻，3=活动", OrderNum = 13 },
            new { Code = "sys_publish_scope", Name = "发布范围", Remark = "发布范围。0=全部，1=指定部门，2=指定用户，3=指定角色", OrderNum = 14 },
            new { Code = "sys_urgency_level", Name = "紧急程度", Remark = "是否紧急。0=一般，1=紧急，2=非常紧急", OrderNum = 15 },
            new { Code = "sys_notice_status", Name = "公告状态", Remark = "公告状态。0=草稿，1=已发布，2=已撤回，3=已过期", OrderNum = 16 },
            new { Code = "sys_list_class", Name = "列表类名", Remark = "列表类名。用于前端样式控制", OrderNum = 17 },
            new { Code = "sys_storage_type", Name = "存储方式", Remark = "存储方式。0=本地存储，1=OSS对象存储，2=FTP，3=其他", OrderNum = 18 },
            new { Code = "sys_file_category", Name = "文件分类", Remark = "文件分类。0=文档，1=图片，2=视频，3=音频，4=压缩包，5=其他", OrderNum = 19 },
            new { Code = "sys_file_status", Name = "文件状态", Remark = "文件状态。0=正常，1=已锁定，2=已归档，3=已删除", OrderNum = 20 },
            new { Code = "sys_language_code", Name = "语言编码", Remark = "语言编码。ISO 639-1/639-2，如：zh-CN、en-US", OrderNum = 21 },
            new { Code = "sys_resource_type", Name = "资源类型", Remark = "资源类型。Frontend=前端，Backend=后端", OrderNum = 22 },
            new { Code = "sys_mail_type", Name = "邮件类型", Remark = "邮件类型。0=普通邮件，1=系统邮件，2=通知邮件，3=提醒邮件", OrderNum = 23 },
            new { Code = "sys_mail_status", Name = "邮件状态", Remark = "邮件状态。0=草稿，1=已发送，2=发送失败，3=已撤回，4=定时发送中", OrderNum = 24 },
            new { Code = "sys_news_category", Name = "新闻分类", Remark = "新闻分类。0=公司新闻，1=行业动态，2=技术分享，3=产品发布，4=活动资讯，5=其他", OrderNum = 25 },
            new { Code = "sys_news_status", Name = "新闻状态", Remark = "新闻状态。0=草稿，1=已发布，2=已撤回，3=已过期", OrderNum = 26 },
            new { Code = "sys_setting_group", Name = "设置分组", Remark = "设置分组。backend=后端，frontend=前端", OrderNum = 27 },
            new { Code = "sys_message_type", Name = "消息类型", Remark = "消息类型。Text=文本，Image=图片，File=文件，System=系统消息", OrderNum = 28 },
            new { Code = "sys_message_group", Name = "消息分组", Remark = "消息分组。Chat=聊天，Notification=通知，Alert=提醒", OrderNum = 29 },
            new { Code = "sys_read_status", Name = "读取状态", Remark = "读取状态。0=未读，1=已读", OrderNum = 30 },
            new { Code = "sys_online_status", Name = "在线状态", Remark = "在线状态。0=在线，1=离线，2=离开", OrderNum = 31 },
            new { Code = "sys_form_category", Name = "表单分类", Remark = "表单分类。0=通用表单，1=业务表单，2=系统表单", OrderNum = 32 },
            new { Code = "sys_form_type", Name = "表单类型", Remark = "表单类型。0=动态表单，1=静态表单，2=自定义表单", OrderNum = 33 },
            new { Code = "sys_priority", Name = "优先级", Remark = "优先级。0=低，1=中，2=高，3=紧急", OrderNum = 34 },
            new { Code = "sys_flow_category", Name = "流程分类", Remark = "流程分类。0=通用流程，1=业务流程，2=系统流程", OrderNum = 35 },
            new { Code = "sys_gen_template_type", Name = "生成模板类型", Remark = "生成模板类型。crud=单表操作，tree=树表操作，sub=主子表操作", OrderNum = 36 },
            new { Code = "sys_gen_method", Name = "生成方式", Remark = "代码生成方式。0=zip 压缩包，1=自定义路径，2=当前项目", OrderNum = 36 },
            new { Code = "sys_sort_type", Name = "排序类型", Remark = "排序类型。asc=升序，desc=降序", OrderNum = 36 },
            new { Code = "sys_dto_category", Name = "传输对象类别", Remark = "传输对象Dto类别。Dto,QueryDto,CreateDto,UpdateDto,TemplateDto,ImportDto,ExportDto等", OrderNum = 37 },
            new { Code = "sys_gen_function", Name = "生成功能", Remark = "生成功能。查询，新增，更新，删除，模板，导入，导出", OrderNum = 38 },
            new { Code = "sys_frontend_template", Name = "前端模板", Remark = "前端模板。1=element plus，2=ant design vue", OrderNum = 39 },
            new { Code = "sys_frontend_style", Name = "前端样式", Remark = "前端样式。12=一行一列，24=一行两列", OrderNum = 40 },
            new { Code = "sys_button_style", Name = "操作按钮样式", Remark = "操作按钮样式。0=文本，1=标准", OrderNum = 41 },
            new { Code = "sys_csharp_type", Name = "C#类型", Remark = "C#类型。对应C#数据类型，如：string、int、long、DateTime、decimal、bool、Guid等", OrderNum = 42 },
            new { Code = "sys_db_type", Name = "数据库数据类型", Remark = "数据库数据类型。如：varchar、int、datetime、decimal等", OrderNum = 43 },
            new { Code = "sys_query_type", Name = "查询方式", Remark = "查询方式。EQ=等于，NE=不等于，GT=大于，GTE=大于等于，LT=小于，LTE=小于等于，LIKE=模糊，BETWEEN=范围", OrderNum = 44 },
            new { Code = "sys_display_type", Name = "显示类型", Remark = "显示类型。input=文本框，InputNumber=数字输入框，select=下拉框，checkbox=复选框，radio=单选框，date=日期控件，time=时间控件，image=图片上传，file=文件上传，slider=滑块，switch=开关，Rate=评分，textarea=文本域，editor=富文本编辑器", OrderNum = 45 },
            new { Code = "sys_storage_naming", Name = "存储命名规则", Remark = "存储命名规则。0=原文件+哈希值，1=自动生成，2=自定义", OrderNum = 46 },
            new { Code = "sys_storage_directory", Name = "存储目录", Remark = "存储目录。用于文件分类存储", OrderNum = 47 },
            new { Code = "sys_oss_provider", Name = "OSS提供商类型", Remark = "OSS对象存储提供商类型。aliyun=阿里云OSS，tencent=腾讯云COS，huawei=华为云OBS，aws=AWS S3", OrderNum = 48 },
            new { Code = "sys_ftp_provider", Name = "FTP服务提供商", Remark = "FTP服务提供商类型。teac_cn=TEAC FTP中国（ftp.teac.com.cn），teac_jp=TEAC FTP日本（rosu2.teac.co.jp）", OrderNum = 49 }
        };

        // 初始化每个字典类型
        foreach (var dictType in dictTypes)
        {
            var existing = await dictTypeRepository.GetAsync(t => t.DictTypeCode == dictType.Code);

            if (existing == null)
            {
                // 不存在则插入
                var newDictType = new TaktDictType
                {
                    DictTypeCode = dictType.Code,
                    DictTypeName = dictType.Name,
                    Remark = dictType.Remark,
                    DataSource = 0, // 0=系统表
                    IsBuiltIn = 0, // 0=是（内置）
                    OrderNum = dictType.OrderNum,
                    DictTypeStatus = 0, // 0=启用
                    IsDeleted = 0
                };
                await dictTypeRepository.CreateAsync(newDictType);
                insertCount++;
            }
            else
            {
                // 存在则更新
                existing.DictTypeName = dictType.Name;
                existing.Remark = dictType.Remark;
                existing.OrderNum = dictType.OrderNum;
                existing.DictTypeStatus = 0;
                await dictTypeRepository.UpdateAsync(existing);
                updateCount++;
            }
        }

        return (insertCount, updateCount);
    }
}
