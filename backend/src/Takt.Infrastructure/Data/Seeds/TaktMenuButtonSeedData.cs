// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：Takt.Infrastructure.Data.Seeds
// 文件名称：TaktMenuButtonSeedData.cs
// 创建时间：2025-01-20
// 创建人：Takt365(Cursor AI)
// 功能描述：Takt按钮种子数据，初始化按钮菜单（MenuType = 2），只有 MenuType=1 的菜单才有按钮
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using Microsoft.Extensions.DependencyInjection;
using Takt.Domain.Entities.Identity;
using Takt.Domain.Repositories;

namespace Takt.Infrastructure.Data.Seeds;

/// <summary>
/// Takt按钮种子数据
/// </summary>
public class TaktMenuButtonSeedData
{
    /// <summary>
    /// 初始化按钮种子数据
    /// </summary>
    /// <param name="serviceProvider">服务提供者</param>
    /// <param name="configId">当前数据库配置ID</param>
    /// <returns>返回插入和更新的记录数（插入数, 更新数）</returns>
    public static async Task<(int InsertCount, int UpdateCount)> SeedAsync(IServiceProvider serviceProvider, string configId)
    {
        var menuRepository = serviceProvider.GetRequiredService<ITaktRepository<TaktMenu>>();

        int insertCount = 0;
        int updateCount = 0;

        // 获取所有 MenuType=1 的菜单（所有 MenuType=1 的菜单都需要按钮）
        var menus = await menuRepository.FindAsync(m => m.MenuType == 1 && m.IsDeleted == 0);

        foreach (var menu in menus)
        {
            // MenuType=1 的菜单必须有权限，且权限必须以 "list" 结尾
            if (string.IsNullOrEmpty(menu.Permission))
            {
                throw new InvalidOperationException(
                    $"菜单 {menu.MenuCode} ({menu.MenuName}) 的 MenuType=1，但 Permission 为空。MenuType=1 的菜单必须设置 Permission，且 Permission 必须以 'list' 结尾。");
            }

            if (!menu.Permission.EndsWith(":list", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    $"菜单 {menu.MenuCode} ({menu.MenuName}) 的 Permission={menu.Permission} 必须以 ':list' 结尾。");
            }

            // 从菜单的权限标识中获取模块前缀
            var modulePrefix = GetModulePrefix(menu.Permission);
            // 如果 modulePrefix 为空（如 takt: 开头），使用默认按钮组（空字符串）

            // 为菜单创建按钮（所有 MenuType=1 的菜单都需要按钮）
            var (insert, update) = await CreateButtonsForMenuAsync(menuRepository, menu, modulePrefix);
            insertCount += insert;
            updateCount += update;
        }

        return (insertCount, updateCount);
    }

    /// <summary>
    /// 为菜单创建按钮组
    /// </summary>
    /// <param name="menuRepository">菜单仓储</param>
    /// <param name="menu">菜单实体</param>
    /// <param name="modulePrefix">模块前缀</param>
    /// <returns>返回插入和更新的记录数（插入数, 更新数）</returns>
    private static async Task<(int InsertCount, int UpdateCount)> CreateButtonsForMenuAsync(
        ITaktRepository<TaktMenu> menuRepository,
        TaktMenu menu,
        string modulePrefix)
    {
        int insertCount = 0;
        int updateCount = 0;

        // 获取按钮配置
        var (buttonNames, buttonPerms) = GetButtonConfig(modulePrefix);
        if (buttonNames == null || buttonPerms == null)
            return (0, 0);

        // 从菜单的权限标识中获取菜单标识（如果 Permission 为空，使用 MenuCode 的小写形式）
        var menuPerm = GetMenuPerm(menu.Permission);
        if (string.IsNullOrEmpty(menuPerm) && !string.IsNullOrEmpty(menu.MenuCode))
        {
            menuPerm = menu.MenuCode.ToLowerInvariant();
        }

        // 生成按钮
        for (int i = 0; i < buttonNames.Length; i++)
        {
            var buttonName = buttonNames[i];
            var buttonPerm = buttonPerms[i];

            // 生成按钮代码：使用 MenuCode_buttonPerm 格式，确保唯一性
            var buttonCode = string.IsNullOrEmpty(menu.MenuCode) 
                ? buttonPerm.ToLowerInvariant() 
                : $"{menu.MenuCode.ToLowerInvariant()}_{buttonPerm.ToLowerInvariant()}";

            // 生成权限：(顶级目录+1级目录...5级目录)+业务实体+操作
            // 格式：modulePrefix:menuPerm:buttonPerm
            // 如果 modulePrefix 为空，格式为：menuPerm:buttonPerm
            // 如果 menuPerm 也为空，格式为：buttonPerm
            var permission = string.IsNullOrEmpty(modulePrefix)
                ? (string.IsNullOrEmpty(menuPerm) 
                    ? buttonPerm.ToLowerInvariant() 
                    : $"{menuPerm}:{buttonPerm.ToLowerInvariant()}")
                : $"{modulePrefix.ToLower()}:{menuPerm}:{buttonPerm.ToLowerInvariant()}";

            // 生成本地化键：common.button.buttonPerm
            var menuL10nKey = $"common.button.{buttonPerm.ToLowerInvariant()}";

            var (insert, update) = await CreateOrUpdateButtonAsync(menuRepository, menu.Id, buttonCode, buttonName, permission, menuL10nKey, i + 1);
            insertCount += insert;
            updateCount += update;
        }

        return (insertCount, updateCount);
    }

    /// <summary>
    /// 从菜单的权限标识中获取模块前缀
    /// </summary>
    /// <param name="permission">权限字符串</param>
    /// <returns>模块前缀</returns>
    private static string GetModulePrefix(string permission)
    {
        if (string.IsNullOrEmpty(permission))
            return string.Empty;

        var parts = permission.Split(':');
        if (parts.Length == 0)
            return string.Empty;

        // 如果以 takt: 开头，返回空（使用默认按钮组）
        if (parts[0].Equals("takt", StringComparison.OrdinalIgnoreCase))
            return string.Empty;

        // 返回第一部分作为模块前缀
        return parts[0].ToLower();
    }

    /// <summary>
    /// 从菜单的权限标识中获取菜单标识
    /// </summary>
    /// <param name="permission">权限字符串</param>
    /// <returns>菜单标识</returns>
    private static string GetMenuPerm(string? permission)
    {
        if (string.IsNullOrEmpty(permission))
            return string.Empty;

        var parts = permission.Split(':');
        if (parts.Length > 2)
        {
            // 截取第一个冒号之后到最后一个冒号之前的部分
            return string.Join(":", parts[1..^1]).ToLower();
        }
        else if (parts.Length == 2)
        {
            // 只有一个冒号的情况，取第一部分（如果以takt:开头）或第二部分
            if (parts[0].Equals("takt", StringComparison.OrdinalIgnoreCase))
                return parts[1].ToLower();
            return parts[1].ToLower();
        }
        else if (parts.Length == 1)
        {
            return parts[0].ToLower();
        }

        return string.Empty;
    }

    /// <summary>
    /// 根据模块前缀获取按钮配置
    /// </summary>
    /// <param name="modulePrefix">模块前缀</param>
    /// <returns>按钮名称和权限数组</returns>
    private static (string[]? names, string[]? perms) GetButtonConfig(string modulePrefix)
    {
        // 通用按钮
        var buttonNames = new[] { "查询", "新增", "修改", "删除", "详情", "预览", "打印", "导入", "导出", "模板", "审批", "撤销" };
        var buttonPerms = new[] { "query", "create", "update", "delete", "detail", "preview", "print", "import", "export", "template", "approve", "revoke" };

        // 认证通用按钮
        var buttonIdNames = new[] { "查询", "新增", "修改", "删除", "详情", "预览", "打印", "导入", "导出", "模板", "审批", "撤销", "授权", "分配", "重置密码", "变更密码", "清空", "截断" ,"解锁","禁用"};
        var buttonIdPerms = new[] { "query", "create", "update", "delete", "detail", "preview", "print", "import", "export", "template", "approve", "revoke", "authorize", "allocate", "resetpwd", "changepwd", "empty", "truncate" ,"unlock","disable"};

        // 代码生成按钮（含克隆）
        var buttonGenNames = new[] { "查询", "新增", "修改", "删除", "生成", "预览", "下载", "同步", "导入", "导出", "模板", "字段", "表", "数据库", "初始化", "克隆", "清空", "截断" };
        var buttonGenPerms = new[] { "query", "create", "update", "delete", "generate", "preview", "download", "sync", "import", "export", "template", "columns", "tables", "databases", "initialize", "clone", "empty", "truncate" };

        // 工作流按钮
        var buttonFlowNames = new[] {
            // 通用操作按钮
            "查询", "新增", "修改", "删除", "详情", "预览", "打印", "导入", "导出", "模板", "审批", "撤销", "复制", "克隆",
            // 流程通用操作
            "暂停", "恢复", "提交", "撤回", "转办", "委托", "退回", "催办", "加签", "减签", "进度", "历史",
            // TaktScheme 流程定义专用操作
            "发布", "停用", "启用", "版本", "设计", "配置", "验证",
            // TaktInstance 流程实例专用操作
            "启动", "终止",
            // TaktForm 表单操作
            "字段管理", "权限设置", "数据源配置", "主题设置", "表单数据",
            // TaktInstanceTrans 流转历史管理
            "流转归档", "流转清理"
        };
        var buttonFlowPerms = new[] {
            // 通用操作权限
            "query", "create", "update", "delete", "detail", "preview", "print", "import", "export", "template", "approve", "revoke", "copy", "clone",
            // 流程通用权限
            "suspend", "resume", "submit", "withdraw", "transfer", "delegate", "return", "urge", "addsign", "subsign", "progress", "history",
            // TaktScheme 流程定义专用权限
            "publish", "disable", "enable", "version", "design", "config", "validate",
            // TaktInstance 流程实例专用权限
            "start", "terminate",
            // TaktForm 表单权限
            "field", "permission", "datasource", "theme", "data",
            // TaktInstanceTrans 流转历史权限
            "archive", "clean"
        };

        // 日常事务通用按钮
        var buttonRoutineNames = new[] {
            // 基础操作按钮
            "查询", "新增", "修改", "删除", "详情", "预览", "打印", "导入", "导出", "模板", "审批", "撤销",
            // 克隆操作按钮
            "克隆", "复制",
            // 文档操作按钮
            "保存草稿", "删除草稿", "发送", "撤回", "转发", "回复", "已读", "未读", "传阅", "签收", "催办", "确认",
            // 社交互动按钮
            "点赞", "取消点赞", "收藏", "取消收藏", "分享", "取消分享", "评论", "取消评论", "举报", "取消举报", "关注", "取消关注",
            // 文件操作按钮
            "上传", "下载", "归档", "销毁", "版本",
            // 系统操作按钮
            "运行", "停止", "重启", "刷新", "重置", "清空"
        };
        var buttonRoutinePerms = new[] {
            // 基础操作权限
            "query", "create", "update", "delete", "detail", "preview", "print", "import", "export", "template", "approve", "revoke",
            // 克隆操作权限
            "clone", "copy",
            // 文档操作权限
            "draft", "deletedraft", "send", "withdraw", "forward", "reply", "read", "unread", "circulate", "sign", "urge", "confirm",
            // 社交互动权限
            "like", "unlike", "favorite", "unfavorite", "share", "unshare", "comment", "uncomment", "flagging", "unflagging", "follow", "unfollow",
            // 文件操作权限
            "upload", "download", "archive", "destroy", "version",
            // 系统操作权限
            "run", "stop", "restart", "refresh", "reset", "empty"
        };

        // 人力资源通用按钮
        var buttonHrmNames = new[] {
            // 基础操作按钮
            "查询", "新增", "修改", "删除", "详情", "预览", "打印", "导入", "导出", "模板", "审批", "撤销", "核算"
        };
        var buttonHrmPerms = new[] {
            // 基础操作权限
            "query", "create", "update", "delete", "detail", "preview", "print", "import", "export", "template", "approve", "revoke", "calculate"
        };

        // 会计通用按钮
        var buttonAccountingNames = new[] {
            // 基础操作按钮
            "查询", "新增", "修改", "删除", "详情", "预览", "打印", "导入", "导出", "模板", "审批", "撤销", "核算",
            "记账", "结账", "对账", "支付", "折旧", "报销", "冲销", "计提", "账期", "结转", "作废"
        };
        var buttonAccountingPerms = new[] {
            // 基础操作权限
            "query", "create", "update", "delete", "detail", "preview", "print", "import", "export", "template", "approve", "revoke", "calculate",
            "book", "closing", "reconcile", "payment", "depreciation", "reimburse", "reversal", "accrual", "period", "carryforward", "cancel"
        };

        // 根据模块前缀选择对应的按钮配置（modulePrefix 为菜单 Permission 的第一段，如 identity、code、workflow、routine 等）
        switch (modulePrefix.ToLowerInvariant())
        {
            case "identity":
                return (buttonIdNames, buttonIdPerms);

            case "code":
                return (buttonGenNames, buttonGenPerms);

            case "workflow":
                return (buttonFlowNames, buttonFlowPerms);

            case "routine":
                return (buttonRoutineNames, buttonRoutinePerms);

            case "humanresource":
                return (buttonHrmNames, buttonHrmPerms);

            case "accounting":
                return (buttonAccountingNames, buttonAccountingPerms);

            default:
                return (buttonNames, buttonPerms);
        }
    }

    /// <summary>
    /// 创建或更新按钮
    /// </summary>
    /// <param name="menuRepository">菜单仓储</param>
    /// <param name="parentId">父菜单ID</param>
    /// <param name="menuCode">菜单代码</param>
    /// <param name="menuName">菜单名称</param>
    /// <param name="permission">权限标识</param>
    /// <param name="menuL10nKey">本地化键</param>
    /// <param name="orderNum">排序号</param>
    /// <returns>返回插入和更新的记录数（插入数, 更新数）</returns>
    private static async Task<(int InsertCount, int UpdateCount)> CreateOrUpdateButtonAsync(
        ITaktRepository<TaktMenu> menuRepository,
        long parentId,
        string menuCode,
        string menuName,
        string permission,
        string menuL10nKey,
        int orderNum)
    {
        var button = await menuRepository.GetAsync(m => m.MenuCode == menuCode);

        if (button == null)
        {
            // 不存在则插入
            button = new TaktMenu
            {
                MenuName = menuName,
                MenuCode = menuCode,
                MenuL10nKey = menuL10nKey,
                ParentId = parentId,
                MenuType = 2,
                Permission = permission,
                OrderNum = orderNum,
                MenuStatus = 0,
                IsVisible = 1,
                IsCache = 1,
                IsExternal = 1,
                IsDeleted = 0
            };
            await menuRepository.CreateAsync(button);
            return (1, 0);
        }
        else
        {
            // 存在则更新
            button.MenuName = menuName;
            button.MenuL10nKey = menuL10nKey;
            button.ParentId = parentId;
            button.MenuType = 2;
            button.Permission = permission;
            button.OrderNum = orderNum;
            button.MenuStatus = 0;
            button.IsVisible = 1;
            button.IsCache = 1;
            button.IsExternal = 1;
            await menuRepository.UpdateAsync(button);
            return (0, 1);
        }
    }
}
