// ========================================
// 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF) 
// 命名空间：Takt.Domain.Entities.Workflow
// 文件名称：TaktFlowHistory.cs
// 创建时间：2025-01-20
// 创建人：Takt365(Cursor AI)
// 功能描述：Takt流程流转历史实体，记录流程节点流转历史
// 
// 版权信息：Copyright (c) 2025 Takt  All rights reserved.
// 免责声明：此软件使用 MIT License，作者不承担任何使用风险。
// ========================================

using SqlSugar;
using Takt.Domain.Entities;

namespace Takt.Domain.Entities.Workflow;

/// <summary>
/// Takt流程流转历史实体
/// </summary>
[SugarTable("takt_workflow_history", "流程流转历史表")]
[SugarIndex("ix_takt_workflow_history_instance_id", nameof(InstanceId), OrderByType.Asc)]
[SugarIndex("ix_takt_workflow_history_from_node_id", nameof(FromNodeId), OrderByType.Asc)]
[SugarIndex("ix_takt_workflow_history_to_node_id", nameof(ToNodeId), OrderByType.Asc)]
[SugarIndex("ix_takt_workflow_history_transition_time", nameof(TransitionTime), OrderByType.Desc)]
[SugarIndex("ix_takt_workflow_history_config_id", nameof(ConfigId), OrderByType.Asc)]
[SugarIndex("ix_takt_workflow_history_is_deleted", nameof(IsDeleted), OrderByType.Asc)]
public class TaktFlowHistory : TaktEntityBase
{
    /// <summary>
    /// 流程实例ID（序列化为string以避免Javascript精度问题）
    /// </summary>
    [SugarColumn(ColumnName = "instance_id", ColumnDescription = "流程实例ID", ColumnDataType = "bigint", IsNullable = false)]
    [JsonConverter(typeof(ValueToStringConverter))]
    public long InstanceId { get; set; }

    /// <summary>
    /// 流程实例编码
    /// </summary>
    [SugarColumn(ColumnName = "instance_code", ColumnDescription = "流程实例编码", ColumnDataType = "nvarchar", Length = 50, IsNullable = false)]
    public string InstanceCode { get; set; } = string.Empty;

    /// <summary>
    /// 流程Key
    /// </summary>
    [SugarColumn(ColumnName = "process_key", ColumnDescription = "流程Key", ColumnDataType = "nvarchar", Length = 100, IsNullable = false)]
    public string ProcessKey { get; set; } = string.Empty;

    /// <summary>
    /// 流程名称
    /// </summary>
    [SugarColumn(ColumnName = "process_name", ColumnDescription = "流程名称", ColumnDataType = "nvarchar", Length = 200, IsNullable = false)]
    public string ProcessName { get; set; } = string.Empty;

    /// <summary>
    /// 源节点ID（序列化为string以避免Javascript精度问题）
    /// </summary>
    [SugarColumn(ColumnName = "from_node_id", ColumnDescription = "源节点ID", ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
    public string? FromNodeId { get; set; }

    /// <summary>
    /// 源节点名称
    /// </summary>
    [SugarColumn(ColumnName = "from_node_name", ColumnDescription = "源节点名称", ColumnDataType = "nvarchar", Length = 200, IsNullable = true)]
    public string? FromNodeName { get; set; }

    /// <summary>
    /// 目标节点ID（序列化为string以避免Javascript精度问题）
    /// </summary>
    [SugarColumn(ColumnName = "to_node_id", ColumnDescription = "目标节点ID", ColumnDataType = "nvarchar", Length = 100, IsNullable = false)]
    public string ToNodeId { get; set; } = string.Empty;

    /// <summary>
    /// 目标节点名称
    /// </summary>
    [SugarColumn(ColumnName = "to_node_name", ColumnDescription = "目标节点名称", ColumnDataType = "nvarchar", Length = 200, IsNullable = false)]
    public string ToNodeName { get; set; } = string.Empty;

    /// <summary>
    /// 流转类型（0=正常流转，1=退回，2=转办，3=加签，4=减签，5=撤回）
    /// </summary>
    [SugarColumn(ColumnName = "transition_type", ColumnDescription = "流转类型", ColumnDataType = "int", IsNullable = false, DefaultValue = "0")]
    public int TransitionType { get; set; } = 0;

    /// <summary>
    /// 流转时间
    /// </summary>
    [SugarColumn(ColumnName = "transition_time", ColumnDescription = "流转时间", ColumnDataType = "datetime", IsNullable = false)]
    public DateTime TransitionTime { get; set; } = DateTime.Now;

    /// <summary>
    /// 流转人ID（序列化为string以避免Javascript精度问题）
    /// </summary>
    [SugarColumn(ColumnName = "transition_user_id", ColumnDescription = "流转人ID", ColumnDataType = "bigint", IsNullable = false)]
    [JsonConverter(typeof(ValueToStringConverter))]
    public long TransitionUserId { get; set; }

    /// <summary>
    /// 流转人姓名
    /// </summary>
    [SugarColumn(ColumnName = "transition_user_name", ColumnDescription = "流转人姓名", ColumnDataType = "nvarchar", Length = 50, IsNullable = false)]
    public string TransitionUserName { get; set; } = string.Empty;

    /// <summary>
    /// 流转部门ID（序列化为string以避免Javascript精度问题）
    /// </summary>
    [SugarColumn(ColumnName = "transition_dept_id", ColumnDescription = "流转部门ID", ColumnDataType = "bigint", IsNullable = true)]
    [JsonConverter(typeof(ValueToStringConverter))]
    public long? TransitionDeptId { get; set; }

    /// <summary>
    /// 流转部门名称
    /// </summary>
    [SugarColumn(ColumnName = "transition_dept_name", ColumnDescription = "流转部门名称", ColumnDataType = "nvarchar", Length = 100, IsNullable = true)]
    public string? TransitionDeptName { get; set; }

    /// <summary>
    /// 流转意见
    /// </summary>
    [SugarColumn(ColumnName = "transition_comment", ColumnDescription = "流转意见", ColumnDataType = "nvarchar", Length = 2000, IsNullable = true)]
    public string? TransitionComment { get; set; }

    /// <summary>
    /// 流转附件（JSON格式，存储附件ID列表）
    /// </summary>
    [SugarColumn(ColumnName = "transition_attachments", ColumnDescription = "流转附件", ColumnDataType = "nvarchar", Length = 2000, IsNullable = true)]
    public string? TransitionAttachments { get; set; }

    /// <summary>
    /// 流转耗时（毫秒）
    /// </summary>
    [SugarColumn(ColumnName = "elapsed_milliseconds", ColumnDescription = "流转耗时（毫秒）", ColumnDataType = "int", IsNullable = false, DefaultValue = "0")]
    public int ElapsedMilliseconds { get; set; } = 0;
}
