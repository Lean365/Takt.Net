/**
 * 代码生成 · 中文
 * - 页面标题、删除确认、成功/失败提示等用 common.confirm、common.msg、common.button + 本模块 entity 拼接
 * - 此处仅保留：实体名、搜索 keyword、弹窗标题、列名、本模块专有操作名等无法拼接的
 */
export default {
  /** 实体名（用于 common.confirm.deleteEntity、formTitle = common.button.create/edit + 此值） */
  tableConfig: '表配置',

  /** 搜索占位用 common.form.placeholder.search + keyword */
  keyword: '表名、实体类名或业务名',

  /** 弹窗/抽屉标题等 */
  importFromDb: '从数据库导入表',
  saveAs: '另存为',
  saveAsPathHint: '请输入生成路径（将覆盖表配置中的路径）：',
  saveAsPathPlaceholder: '如：D:\\Projects\\Takt.Net',
  genPath: '生成路径',
  advancedQuery: '高级查询',
  searchKeywordLabel: '表名/实体类名/业务名',
  placeholderFuzzy: '支持模糊搜索',

  /** 列头（表格/导出） */
  tableName: '表名',
  tableComment: '表描述',
  entityClassName: '实体类名',
  genModuleName: '模块名',
  genBusinessName: '业务名',
  genTemplate: '模板',

  /** 行内操作（common 无的） */
  generate: '生成',
  sync: '同步',
  initialize: '初始化',

  /** 覆盖确认 */
  overwriteConfirmTitle: '覆盖确认',
  overwriteConfirmContent: '目标路径下已存在以下文件，是否覆盖？',
  overwrite: '覆盖',
  saveAsCancel: '另存为',

  /** 无法用 common 拼接的提示 */
  noTableIdSync: '该记录无表 ID，无法同步',
  noTableIdInit: '该记录无表 ID，无法初始化',
  syncFormHint: '请在编辑弹窗中保存以从数据源刷新字段配置；完整同步需后端提供接口',
  cloneSuccess: '已复制为新建，请修改表名后保存',
  noDataToExport: '暂无数据可导出',
  codeGeneratedDownload: '代码已生成并下载',
  genSuccessCount: '，共 {count} 个文件',
  existingFilesSuffix: '等共 {count} 个文件'
}
