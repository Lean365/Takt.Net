// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：Takt.Infrastructure.Data.Seeds
// 文件名称：TaktMenuLevel3SeedData.cs
// 创建时间：2025-01-20
// 创建人：Takt365(Cursor AI)
// 功能描述：Takt三级菜单种子数据，初始化三级菜单（依赖二级菜单）
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using Microsoft.Extensions.DependencyInjection;
using Takt.Domain.Entities.Identity;
using Takt.Domain.Repositories;

namespace Takt.Infrastructure.Data.Seeds;

/// <summary>
/// Takt三级菜单种子数据
/// </summary>
public class TaktMenuLevel3SeedData
{
    /// <summary>
    /// 初始化三级菜单种子数据
    /// </summary>
    /// <param name="serviceProvider">服务提供者</param>
    /// <param name="configId">当前数据库配置ID</param>
    /// <returns>返回插入和更新的记录数（插入数, 更新数）</returns>
    public static async Task<(int InsertCount, int UpdateCount)> SeedAsync(IServiceProvider serviceProvider, string configId)
    {
        var menuRepository = serviceProvider.GetRequiredService<ITaktRepository<TaktMenu>>();

        int insertCount = 0;
        int updateCount = 0;

        // 获取父级菜单（二级菜单，严格按 Level1 顺序：5 财务 6 后勤 8 人力资源 10 统计；同级内按 Level2 OrderNum）
        var accountingFinancialMenu = await menuRepository.GetAsync(m => m.MenuCode == "ACCOUNTING_FINANCIAL");   // 5.财务-财务会计
        var accountingControllingMenu = await menuRepository.GetAsync(m => m.MenuCode == "ACCOUNTING_CONTROLLING"); // 5.财务-控制会计
        var logisticsMaterialMenu = await menuRepository.GetAsync(m => m.MenuCode == "LOGISTICS_MATERIAL");         // 6.后勤-物料
        var logisticsSalesMenu = await menuRepository.GetAsync(m => m.MenuCode == "LOGISTICS_SALES");              // 6.后勤-销售
        var productionMenu = await menuRepository.GetAsync(m => m.MenuCode == "MANUFACTURING");                     // 6.后勤-生产
        var logisticsQualityMenu = await menuRepository.GetAsync(m => m.MenuCode == "LOGISTICS_QUALITY");          // 6.后勤-质量
        var organizationMenu = await menuRepository.GetAsync(m => m.MenuCode == "HR_ORGANIZATION");               // 8.人力资源-组织
        var employeeMenu = await menuRepository.GetAsync(m => m.MenuCode == "HR_PERSONNEL");                        // 8.人力资源-人事
        var statisticsLoggingMenu = await menuRepository.GetAsync(m => m.MenuCode == "STATISTICS_LOGGING");        // 10.统计-日志
        var statisticsReportMenu = await menuRepository.GetAsync(m => m.MenuCode == "STATISTICS_REPORT");          // 10.统计-报表
        var statisticsBoardMenu = await menuRepository.GetAsync(m => m.MenuCode == "KANBAN");                       // 10.统计-看板管理(Kanban)

        // ========== 财务会计下的三级菜单（5.财务核算） ==========
        if (accountingFinancialMenu != null)
        {
            // 公司信息
            var (insert6, update6) = await CreateOrUpdateMenuAsync(menuRepository, "ACCOUNTING_FINANCIAL_COMPANY", menu =>
            {
                menu.MenuName = "公司信息";
                menu.MenuCode = "ACCOUNTING_FINANCIAL_COMPANY";
                menu.MenuL10nKey = "menu.accounting.financial.company";
                menu.MenuIcon = "BankOutlined";
                menu.ParentId = accountingFinancialMenu.Id;
                menu.MenuType = 1; // 菜单
                menu.Permission = "accounting:financial:company:list";
                menu.Path = "/accounting/financial/company";
                menu.Component = "accounting/financial/company/index";
                menu.OrderNum = 1;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insert6;
            updateCount += update6;
        }

        // ========== 控制会计下的三级菜单（5.财务核算） ==========
        if (accountingControllingMenu != null)
        {
            // 成本中心
            var (insert7, update7) = await CreateOrUpdateMenuAsync(menuRepository, "ACCOUNTING_CONTROLLING_COST_CENTER", menu =>
            {
                menu.MenuName = "成本中心";
                menu.MenuCode = "ACCOUNTING_CONTROLLING_COST_CENTER";
                menu.MenuL10nKey = "menu.accounting.controlling.costcenter";
                menu.MenuIcon = "DollarOutlined";
                menu.ParentId = accountingControllingMenu.Id;
                menu.MenuType = 1; // 菜单
                menu.Permission = "accounting:controlling:costcenter:list";
                menu.Path = "/accounting/controlling/cost-center";
                menu.Component = "accounting/controlling/cost-center/index";
                menu.OrderNum = 1;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insert7;
            updateCount += update7;
        }

        // ========== 物料管理下的三级菜单（6.后勤-物料） ==========
        if (logisticsMaterialMenu != null)
        {
            // 工厂信息
            var (insert8, update8) = await CreateOrUpdateMenuAsync(menuRepository, "LOGISTICS_MATERIAL_PLANT", menu =>
            {
                menu.MenuName = "工厂信息";
                menu.MenuCode = "LOGISTICS_MATERIAL_PLANT";
                menu.MenuL10nKey = "menu.logistics.material.plant";
                menu.MenuIcon = "HomeOutlined";
                menu.ParentId = logisticsMaterialMenu.Id;
                menu.MenuType = 1; // 菜单
                menu.Permission = "logistics:material:plant:list";
                menu.Path = "/logistics/material/plant";
                menu.Component = "logistics/material/plant/index";
                menu.OrderNum = 1;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insert8;
            updateCount += update8;

            // 工厂物料
            var (insert81, update81) = await CreateOrUpdateMenuAsync(menuRepository, "LOGISTICS_MATERIAL_PLANT_MATERIAL", menu =>
            {
                menu.MenuName = "工厂物料";
                menu.MenuCode = "LOGISTICS_MATERIAL_PLANT_MATERIAL";
                menu.MenuL10nKey = "menu.logistics.material.plantmaterial";
                menu.MenuIcon = "DatabaseOutlined";
                menu.ParentId = logisticsMaterialMenu.Id;
                menu.MenuType = 1; // 菜单
                menu.Permission = "logistics:material:plantmaterial:list";
                menu.Path = "/logistics/material/plant-material";
                menu.Component = "logistics/material/plant-material/index";
                menu.OrderNum = 2;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insert81;
            updateCount += update81;

            // 采购管理
            var (insert82, update82) = await CreateOrUpdateMenuAsync(menuRepository, "LOGISTICS_MATERIAL_PURCHASING", menu =>
            {
                menu.MenuName = "采购管理";
                menu.MenuCode = "LOGISTICS_MATERIAL_PURCHASING";
                menu.MenuL10nKey = "menu.logistics.material.purchasing._self";
                menu.MenuIcon = "ShoppingCartOutlined";
                menu.ParentId = logisticsMaterialMenu.Id;
                menu.MenuType = 0; // 目录
                menu.Path = "/logistics/material/purchasing";
                menu.Component = null;
                menu.OrderNum = 3;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 1;
                menu.IsExternal = 1;
            });
            insertCount += insert82;
            updateCount += update82;
        }

        // ========== 销售管理下的三级菜单（6.后勤-销售） ==========
        if (logisticsSalesMenu != null)
        {
            // 客户信息Customer
            var (insert10, update10) = await CreateOrUpdateMenuAsync(menuRepository, "LOGISTICS_SALES_CUSTOMER", menu =>
            {
                menu.MenuName = "客户信息";
                menu.MenuCode = "LOGISTICS_SALES_CUSTOMER";
                menu.MenuL10nKey = "menu.logistics.sales.customer";
                menu.MenuIcon = "UserOutlined";
                menu.ParentId = logisticsSalesMenu.Id;
                menu.MenuType = 1; // 菜单
                menu.Permission = "logistics:sales:customer:list";
                menu.Path = "/logistics/sales/customer";
                menu.Component = "logistics/sales/customer/index";
                menu.OrderNum = 1;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insert10;
            updateCount += update10;

            // 顾客信息Client
            var (insert101, update101) = await CreateOrUpdateMenuAsync(menuRepository, "LOGISTICS_SALES_CLIENT", menu =>
            {
                menu.MenuName = "顾客信息";
                menu.MenuCode = "LOGISTICS_SALES_CLIENT";
                menu.MenuL10nKey = "menu.logistics.sales.client";
                menu.MenuIcon = "TeamOutlined";
                menu.ParentId = logisticsSalesMenu.Id;
                menu.MenuType = 1; // 菜单
                menu.Permission = "logistics:sales:client:list";
                menu.Path = "/logistics/sales/client";
                menu.Component = "logistics/sales/client/index";
                menu.OrderNum = 2;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insert101;
            updateCount += update101;

            // 客户服务
            var (insert102, update102) = await CreateOrUpdateMenuAsync(menuRepository, "LOGISTICS_SALES_SERVICE", menu =>
            {
                menu.MenuName = "客户服务";
                menu.MenuCode = "LOGISTICS_SALES_SERVICE";
                menu.MenuL10nKey = "menu.logistics.sales.service";
                menu.MenuIcon = "CustomerServiceOutlined";
                menu.ParentId = logisticsSalesMenu.Id;
                menu.MenuType = 1; // 菜单
                menu.Permission = "logistics:sales:service:list";
                menu.Path = "/logistics/sales/service";
                menu.Component = "logistics/sales/service/index";
                menu.OrderNum = 3;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insert102;
            updateCount += update102;

            // 销售报价
            var (insert103, update103) = await CreateOrUpdateMenuAsync(menuRepository, "LOGISTICS_SALES_QUOTATION", menu =>
            {
                menu.MenuName = "销售报价";
                menu.MenuCode = "LOGISTICS_SALES_QUOTATION";
                menu.MenuL10nKey = "menu.logistics.sales.quotation";
                menu.MenuIcon = "DollarOutlined";
                menu.ParentId = logisticsSalesMenu.Id;
                menu.MenuType = 1; // 菜单
                menu.Permission = "logistics:sales:quotation:list";
                menu.Path = "/logistics/sales/quotation";
                menu.Component = "logistics/sales/quotation/index";
                menu.OrderNum = 4;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insert103;
            updateCount += update103;

            // 销售价格
            var (insert104, update104) = await CreateOrUpdateMenuAsync(menuRepository, "LOGISTICS_SALES_PRICE", menu =>
            {
                menu.MenuName = "销售价格";
                menu.MenuCode = "LOGISTICS_SALES_PRICE";
                menu.MenuL10nKey = "menu.logistics.sales.price";
                menu.MenuIcon = "MoneyCollectOutlined";
                menu.ParentId = logisticsSalesMenu.Id;
                menu.MenuType = 1; // 菜单
                menu.Permission = "logistics:sales:price:list";
                menu.Path = "/logistics/sales/price";
                menu.Component = "logistics/sales/price/index";
                menu.OrderNum = 5;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insert104;
            updateCount += update104;

            // 销售订单
            var (insert11, update11) = await CreateOrUpdateMenuAsync(menuRepository, "LOGISTICS_SALES_ORDER", menu =>
            {
                menu.MenuName = "销售订单";
                menu.MenuCode = "LOGISTICS_SALES_ORDER";
                menu.MenuL10nKey = "menu.logistics.sales.order";
                menu.MenuIcon = "ShoppingOutlined";
                menu.ParentId = logisticsSalesMenu.Id;
                menu.MenuType = 1; // 菜单
                menu.Permission = "logistics:sales:order:list";
                menu.Path = "/logistics/sales/order";
                menu.Component = "logistics/sales/order/index";
                menu.OrderNum = 6;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insert11;
            updateCount += update11;

            // 销售发票
            var (insert105, update105) = await CreateOrUpdateMenuAsync(menuRepository, "LOGISTICS_SALES_INVOICE", menu =>
            {
                menu.MenuName = "销售发票";
                menu.MenuCode = "LOGISTICS_SALES_INVOICE";
                menu.MenuL10nKey = "menu.logistics.sales.invoice";
                menu.MenuIcon = "FileTextOutlined";
                menu.ParentId = logisticsSalesMenu.Id;
                menu.MenuType = 1; // 菜单
                menu.Permission = "logistics:sales:invoice:list";
                menu.Path = "/logistics/sales/invoice";
                menu.Component = "logistics/sales/invoice/index";
                menu.OrderNum = 7;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insert105;
            updateCount += update105;

            // 销售预测
            var (insert106, update106) = await CreateOrUpdateMenuAsync(menuRepository, "LOGISTICS_SALES_FORECAST", menu =>
            {
                menu.MenuName = "销售预测";
                menu.MenuCode = "LOGISTICS_SALES_FORECAST";
                menu.MenuL10nKey = "menu.logistics.sales.forecast";
                menu.MenuIcon = "LineChartOutlined";
                menu.ParentId = logisticsSalesMenu.Id;
                menu.MenuType = 1; // 菜单
                menu.Permission = "logistics:sales:forecast:list";
                menu.Path = "/logistics/sales/forecast";
                menu.Component = "logistics/sales/forecast/index";
                menu.OrderNum = 8;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insert106;
            updateCount += update106;
        }

        // ========== 生产管理下的三级菜单（6.后勤-生产） ==========
        if (productionMenu != null)
        {
            // BOM
            var (insert1, update1) = await CreateOrUpdateMenuAsync(menuRepository, "MANUFACTURING_BOM", menu =>
            {
                menu.MenuName = "BOM";
                menu.MenuCode = "MANUFACTURING_BOM";
                menu.MenuL10nKey = "menu.logistics.manufacturing.bom._self";
                menu.MenuIcon = "FileTextOutlined";
                menu.ParentId = productionMenu.Id;
                menu.MenuType = 0; // 目录
                menu.Path = "/manufacturing/bom";
                menu.Component = null;
                menu.OrderNum = 1;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 1;
                menu.IsExternal = 1;
            });
            insertCount += insert1;
            updateCount += update1;

            // 工单管理
            var (insert2, update2) = await CreateOrUpdateMenuAsync(menuRepository, "MANUFACTURING_WORK_ORDER", menu =>
            {
                menu.MenuName = "工单管理";
                menu.MenuCode = "MANUFACTURING_WORK_ORDER";
                menu.MenuL10nKey = "menu.logistics.manufacturing.workorder";
                menu.MenuIcon = "FileOutlined";
                menu.ParentId = productionMenu.Id;
                menu.MenuType = 1; // 菜单
                menu.Permission = "manufacturing:workorder:list";
                menu.Path = "/manufacturing/work-order";
                menu.Component = "manufacturing/work-order/index";
                menu.OrderNum = 2;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insert2;
            updateCount += update2;

            // 生产排程
            var (insert3, update3) = await CreateOrUpdateMenuAsync(menuRepository, "MANUFACTURING_SCHEDULING", menu =>
            {
                menu.MenuName = "生产排程";
                menu.MenuCode = "MANUFACTURING_SCHEDULING";
                menu.MenuL10nKey = "menu.logistics.manufacturing.scheduling._self";
                menu.MenuIcon = "CalendarOutlined";
                menu.ParentId = productionMenu.Id;
                menu.MenuType = 0; // 目录
                menu.Path = "/manufacturing/scheduling";
                menu.Component = null;
                menu.OrderNum = 3;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 1;
                menu.IsExternal = 1;
            });
            insertCount += insert3;
            updateCount += update3;

            // 设变
            var (insert4, update4) = await CreateOrUpdateMenuAsync(menuRepository, "MANUFACTURING_ECN", menu =>
            {
                menu.MenuName = "设变";
                menu.MenuCode = "MANUFACTURING_ECN";
                menu.MenuL10nKey = "menu.logistics.manufacturing.ecn._self";
                menu.MenuIcon = "EditOutlined";
                menu.ParentId = productionMenu.Id;
                menu.MenuType = 0; // 目录
                menu.Path = "/manufacturing/ecn";
                menu.Component = null;
                menu.OrderNum = 4;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 1;
                menu.IsExternal = 1;
            });
            insertCount += insert4;
            updateCount += update4;

            // OPH
            var (insert5, update5) = await CreateOrUpdateMenuAsync(menuRepository, "MANUFACTURING_OPH", menu =>
            {
                menu.MenuName = "OPH";
                menu.MenuCode = "MANUFACTURING_OPH";
                menu.MenuL10nKey = "menu.logistics.manufacturing.oph._self";
                menu.MenuIcon = "DashboardOutlined";
                menu.ParentId = productionMenu.Id;
                menu.MenuType = 0; // 目录
                menu.Path = "/manufacturing/oph";
                menu.Component = null;
                menu.OrderNum = 5;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 1;
                menu.IsExternal = 1;
            });
            insertCount += insert5;
            updateCount += update5;

            // 不良
            var (insert6, update6) = await CreateOrUpdateMenuAsync(menuRepository, "MANUFACTURING_DEFECT", menu =>
            {
                menu.MenuName = "不良";
                menu.MenuCode = "MANUFACTURING_DEFECT";
                menu.MenuL10nKey = "menu.logistics.manufacturing.defect._self";
                menu.MenuIcon = "WarningOutlined";
                menu.ParentId = productionMenu.Id;
                menu.MenuType = 0; // 目录
                menu.Path = "/manufacturing/defect";
                menu.Component = null;
                menu.OrderNum = 6;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 1;
                menu.IsExternal = 1;
            });
            insertCount += insert6;
            updateCount += update6;
        }

        // ========== 质量管理下的三级菜单（6.后勤-质量） ==========
        if (logisticsQualityMenu != null)
        {
            // 抽样方案
            var (insert10, update10) = await CreateOrUpdateMenuAsync(menuRepository, "LOGISTICS_QUALITY_SAMPLING_SCHEME", menu =>
            {
                menu.MenuName = "抽样方案";
                menu.MenuCode = "LOGISTICS_QUALITY_SAMPLING_SCHEME";
                menu.MenuL10nKey = "menu.logistics.quality.samplingscheme";
                menu.MenuIcon = "ExperimentOutlined";
                menu.ParentId = logisticsQualityMenu.Id;
                menu.MenuType = 1; // 菜单
                menu.Permission = "logistics:quality:samplingscheme:list";
                menu.Path = "/logistics/quality/sampling-scheme";
                menu.Component = "logistics/quality/sampling-scheme/index";
                menu.OrderNum = 1;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insert10;
            updateCount += update10;
        }

        // ========== 组织管理下的三级菜单（8.人力资源-组织） ==========
        if (organizationMenu != null)
        {
            var (insertDept, updateDept) = await CreateOrUpdateMenuAsync(menuRepository, "HR_ORGANIZATION_DEPT", menu =>
            {
                menu.MenuName = "部门管理";
                menu.MenuCode = "HR_ORGANIZATION_DEPT";
                menu.MenuL10nKey = "menu.humanresource.organization.dept";
                menu.MenuIcon = "ApartmentOutlined";
                menu.ParentId = organizationMenu.Id;
                menu.MenuType = 1;
                menu.Permission = "humanresource:organization:dept:list";
                menu.Path = "/humanresource/organization/dept";
                menu.Component = "humanresource/organization/dept/index";
                menu.OrderNum = 1;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insertDept;
            updateCount += updateDept;

            var (insertPost, updatePost) = await CreateOrUpdateMenuAsync(menuRepository, "HR_ORGANIZATION_POST", menu =>
            {
                menu.MenuName = "岗位管理";
                menu.MenuCode = "HR_ORGANIZATION_POST";
                menu.MenuL10nKey = "menu.humanresource.organization.post";
                menu.MenuIcon = "IdcardOutlined";
                menu.ParentId = organizationMenu.Id;
                menu.MenuType = 1;
                menu.Permission = "humanresource:organization:post:list";
                menu.Path = "/humanresource/organization/post";
                menu.Component = "humanresource/organization/post/index";
                menu.OrderNum = 2;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insertPost;
            updateCount += updatePost;
        }

        // ========== 人事管理下的三级菜单（8.人力资源-人事） ==========
        if (employeeMenu != null)
        {
            var (insert9, update9) = await CreateOrUpdateMenuAsync(menuRepository, "HR_EMPLOYEE_RECORD", menu =>
            {
                menu.MenuName = "员工档案";
                menu.MenuCode = "HR_EMPLOYEE_RECORD";
                menu.MenuL10nKey = "menu.humanresource.employee.record";
                menu.MenuIcon = "FileTextOutlined";
                menu.ParentId = employeeMenu.Id;
                menu.MenuType = 1;
                menu.Permission = "humanresource:employee:record:list";
                menu.Path = "/humanresource/employee/record";
                menu.Component = "humanresource/employee/record/index";
                menu.OrderNum = 1;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insert9;
            updateCount += update9;
        }

        // ========== 日志管理下的三级菜单（10.统计-日志） ==========
        if (statisticsLoggingMenu != null)
        {
            var (insertLoginLog, updateLoginLog) = await CreateOrUpdateMenuAsync(menuRepository, "LOGGING_LOGIN_LOG", menu =>
            {
                menu.MenuName = "登录日志";
                menu.MenuCode = "LOGGING_LOGIN_LOG";
                menu.MenuL10nKey = "menu.statistics.logging.loginlog";
                menu.MenuIcon = "LoginOutlined";
                menu.ParentId = statisticsLoggingMenu.Id;
                menu.MenuType = 1;
                menu.Permission = "logging:loginlog:list";
                menu.Path = "/statistics/logging/login-log";
                menu.Component = "logging/login-log/index";
                menu.OrderNum = 1;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insertLoginLog;
            updateCount += updateLoginLog;

            var (insertOperLog, updateOperLog) = await CreateOrUpdateMenuAsync(menuRepository, "LOGGING_OPER_LOG", menu =>
            {
                menu.MenuName = "操作日志";
                menu.MenuCode = "LOGGING_OPER_LOG";
                menu.MenuL10nKey = "menu.statistics.logging.operlog";
                menu.MenuIcon = "FormOutlined";
                menu.ParentId = statisticsLoggingMenu.Id;
                menu.MenuType = 1;
                menu.Permission = "logging:operlog:list";
                menu.Path = "/statistics/logging/oper-log";
                menu.Component = "logging/oper-log/index";
                menu.OrderNum = 2;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insertOperLog;
            updateCount += updateOperLog;

            var (insertAopLog, updateAopLog) = await CreateOrUpdateMenuAsync(menuRepository, "LOGGING_AOP_LOG", menu =>
            {
                menu.MenuName = "AOP日志";
                menu.MenuCode = "LOGGING_AOP_LOG";
                menu.MenuL10nKey = "menu.statistics.logging.aoplog";
                menu.MenuIcon = "CodeOutlined";
                menu.ParentId = statisticsLoggingMenu.Id;
                menu.MenuType = 1;
                menu.Permission = "logging:aoplog:list";
                menu.Path = "/statistics/logging/aop-log";
                menu.Component = "logging/aop-log/index";
                menu.OrderNum = 3;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insertAopLog;
            updateCount += updateAopLog;

            var (insertQuartzLog, updateQuartzLog) = await CreateOrUpdateMenuAsync(menuRepository, "LOGGING_QUARTZ_LOG", menu =>
            {
                menu.MenuName = "任务日志";
                menu.MenuCode = "LOGGING_QUARTZ_LOG";
                menu.MenuL10nKey = "menu.statistics.logging.quartzlog";
                menu.MenuIcon = "ScheduleOutlined";
                menu.ParentId = statisticsLoggingMenu.Id;
                menu.MenuType = 1;
                menu.Permission = "logging:quartzlog:list";
                menu.Path = "/statistics/logging/quartz-log";
                menu.Component = "logging/quartz-log/index";
                menu.OrderNum = 4;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insertQuartzLog;
            updateCount += updateQuartzLog;
        }

        // ========== 统计报表下的三级菜单（10.统计-报表） ==========
        if (statisticsReportMenu != null)
        {
            // 后勤
            var (insert12, update12) = await CreateOrUpdateMenuAsync(menuRepository, "STATISTICS_REPORT_LOGISTICS", menu =>
            {
                menu.MenuName = "后勤";
                menu.MenuCode = "STATISTICS_REPORT_LOGISTICS";
                menu.MenuL10nKey = "menu.statistics.report.logistics";
                menu.MenuIcon = "CarOutlined";
                menu.ParentId = statisticsReportMenu.Id;
                menu.MenuType = 1; // 菜单
                menu.Permission = "statistics:report:logistics:list";
                menu.Path = "/statistics/report/logistics";
                menu.Component = "statistics/report/logistics/index";
                menu.OrderNum = 1;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insert12;
            updateCount += update12;

            // 财务
            var (insert13, update13) = await CreateOrUpdateMenuAsync(menuRepository, "STATISTICS_REPORT_FINANCIAL", menu =>
            {
                menu.MenuName = "财务";
                menu.MenuCode = "STATISTICS_REPORT_FINANCIAL";
                menu.MenuL10nKey = "menu.statistics.report.financial";
                menu.MenuIcon = "AccountBookOutlined";
                menu.ParentId = statisticsReportMenu.Id;
                menu.MenuType = 1; // 菜单
                menu.Permission = "statistics:report:financial:list";
                menu.Path = "/statistics/report/financial";
                menu.Component = "statistics/report/financial/index";
                menu.OrderNum = 2;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insert13;
            updateCount += update13;

            // 人力资源
            var (insert14, update14) = await CreateOrUpdateMenuAsync(menuRepository, "STATISTICS_REPORT_HR", menu =>
            {
                menu.MenuName = "人力资源";
                menu.MenuCode = "STATISTICS_REPORT_HR";
                menu.MenuL10nKey = "menu.statistics.report.hr";
                menu.MenuIcon = "SolutionOutlined";
                menu.ParentId = statisticsReportMenu.Id;
                menu.MenuType = 1; // 菜单
                menu.Permission = "statistics:report:hr:list";
                menu.Path = "/statistics/report/hr";
                menu.Component = "statistics/report/hr/index";
                menu.OrderNum = 3;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insert14;
            updateCount += update14;
        }

        // ========== 看板管理下的三级菜单（10.统计-Kanban） ==========
        if (statisticsBoardMenu != null)
        {
            // 后勤
            var (insert15, update15) = await CreateOrUpdateMenuAsync(menuRepository, "STATISTICS_KANBAN_LOGISTICS", menu =>
            {
                menu.MenuName = "后勤";
                menu.MenuCode = "STATISTICS_KANBAN_LOGISTICS";
                menu.MenuL10nKey = "menu.statistics.kanban.logistics";
                menu.MenuIcon = "CarOutlined";
                menu.ParentId = statisticsBoardMenu.Id;
                menu.MenuType = 1; // 菜单
                menu.Permission = "statistics:kanban:logistics:list";
                menu.Path = "/statistics/kanban/logistics";
                menu.Component = "statistics/kanban/logistics/index";
                menu.OrderNum = 1;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insert15;
            updateCount += update15;

            // 财务
            var (insert16, update16) = await CreateOrUpdateMenuAsync(menuRepository, "STATISTICS_KANBAN_FINANCIAL", menu =>
            {
                menu.MenuName = "财务";
                menu.MenuCode = "STATISTICS_KANBAN_FINANCIAL";
                menu.MenuL10nKey = "menu.statistics.kanban.financial";
                menu.MenuIcon = "AccountBookOutlined";
                menu.ParentId = statisticsBoardMenu.Id;
                menu.MenuType = 1; // 菜单
                menu.Permission = "statistics:kanban:financial:list";
                menu.Path = "/statistics/kanban/financial";
                menu.Component = "statistics/kanban/financial/index";
                menu.OrderNum = 2;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insert16;
            updateCount += update16;

            // 人力资源
            var (insert17, update17) = await CreateOrUpdateMenuAsync(menuRepository, "STATISTICS_KANBAN_HR", menu =>
            {
                menu.MenuName = "人力资源";
                menu.MenuCode = "STATISTICS_KANBAN_HR";
                menu.MenuL10nKey = "menu.statistics.kanban.hr";
                menu.MenuIcon = "SolutionOutlined";
                menu.ParentId = statisticsBoardMenu.Id;
                menu.MenuType = 1; // 菜单
                menu.Permission = "statistics:kanban:hr:list";
                menu.Path = "/statistics/kanban/hr";
                menu.Component = "statistics/kanban/hr/index";
                menu.OrderNum = 3;
                menu.MenuStatus = 0;
                menu.IsVisible = 0;
                menu.IsCache = 0;
                menu.IsExternal = 1;
            });
            insertCount += insert17;
            updateCount += update17;
        }

        return (insertCount, updateCount);
    }

    /// <summary>
    /// 创建或更新菜单（辅助方法）
    /// </summary>
    /// <param name="menuRepository">菜单仓储</param>
    /// <param name="menuCode">菜单代码</param>
    /// <param name="setupAction">设置菜单属性的操作</param>
    /// <returns>返回插入和更新的记录数（插入数, 更新数）</returns>
    private static async Task<(int InsertCount, int UpdateCount)> CreateOrUpdateMenuAsync(
        ITaktRepository<TaktMenu> menuRepository,
        string menuCode,
        Action<TaktMenu> setupAction)
    {
        var menu = await menuRepository.GetAsync(m => m.MenuCode == menuCode);

        if (menu == null)
        {
            // 不存在则插入
            menu = new TaktMenu
            {
                MenuCode = menuCode,
                IsDeleted = 0
            };
            setupAction(menu);
            await menuRepository.CreateAsync(menu);
            return (1, 0);
        }
        else
        {
            // 存在则更新
            setupAction(menu);
            await menuRepository.UpdateAsync(menu);
            return (0, 1);
        }
    }
}
