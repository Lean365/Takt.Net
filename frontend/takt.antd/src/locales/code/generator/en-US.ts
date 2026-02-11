/**
 * Code generator · English
 * - Page title, delete confirm, success/fail: use common.confirm, common.msg, common.button + this module entity
 * - Here: only entity name, search keyword, modal titles, column names, module-specific actions
 */
export default {
  tableConfig: 'Table Config',

  keyword: 'Table name, entity class or business name',

  importFromDb: 'Import tables from database',
  saveAs: 'Save As',
  saveAsPathHint: 'Enter output path (overrides path in table config):',
  saveAsPathPlaceholder: 'e.g. D:\\Projects\\Takt.Net',
  genPath: 'Output path',
  advancedQuery: 'Advanced query',
  searchKeywordLabel: 'Table / entity / business name',
  placeholderFuzzy: 'Fuzzy search',

  tableName: 'Table name',
  tableComment: 'Table comment',
  entityClassName: 'Entity class',
  genModuleName: 'Module',
  genBusinessName: 'Business name',
  genTemplate: 'Template',

  generate: 'Generate',
  sync: 'Sync',
  initialize: 'Initialize',

  overwriteConfirmTitle: 'Overwrite confirm',
  overwriteConfirmContent: 'The following files already exist. Overwrite?',
  overwrite: 'Overwrite',
  saveAsCancel: 'Save As',

  noTableIdSync: 'No table ID, cannot sync',
  noTableIdInit: 'No table ID, cannot initialize',
  syncFormHint: 'Save in the edit dialog to refresh fields from data source.',
  cloneSuccess: 'Cloned as new; change table name and save.',
  noDataToExport: 'No data to export',
  codeGeneratedDownload: 'Code generated and downloaded',
  genSuccessCount: ', {count} file(s)',
  existingFilesSuffix: '... {count} file(s) in total'
}
