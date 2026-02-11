import request from '../request'

// 会计科目相关 API
export function getAccountingTitleList(params: any) {
  return request({
    url: '/api/TaktAccountingTitles/list',
    method: 'get',
    params
  })
}

export function getAccountingTitleById(id: string) {
  return request({
    url: `/api/TaktAccountingTitles/${id}`,
    method: 'get'
  })
}

export function createAccountingTitle(data: any) {
  return request({
    url: '/api/TaktAccountingTitles',
    method: 'post',
    data
  })
}

export function updateAccountingTitle(id: string, data: any) {
  return request({
    url: `/api/TaktAccountingTitles/${id}`,
    method: 'put',
    data
  })
}

export function deleteAccountingTitle(id: string) {
  return request({
    url: `/api/TaktAccountingTitles/${id}`,
    method: 'delete'
  })
}
