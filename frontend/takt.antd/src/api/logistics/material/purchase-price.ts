import request from '../../request'

// 采购价格相关 API
export function getPurchasePriceList(params: any) {
  return request({
    url: '/api/TaktPurchasePrices/list',
    method: 'get',
    params
  })
}

export function getPurchasePriceById(id: string) {
  return request({
    url: `/api/TaktPurchasePrices/${id}`,
    method: 'get'
  })
}

export function createPurchasePrice(data: any) {
  return request({
    url: '/api/TaktPurchasePrices',
    method: 'post',
    data
  })
}

export function updatePurchasePrice(id: string, data: any) {
  return request({
    url: `/api/TaktPurchasePrices/${id}`,
    method: 'put',
    data
  })
}

export function deletePurchasePrice(id: string) {
  return request({
    url: `/api/TaktPurchasePrices/${id}`,
    method: 'delete'
  })
}

export function getPurchasePriceTemplate(sheetName?: string, fileName?: string) {
  return request({
    url: '/api/TaktPurchasePrices/template',
    method: 'get',
    params: { sheetName, fileName },
    responseType: 'blob'
  })
}

export function importPurchasePrice(file: File, sheetName?: string) {
  const formData = new FormData()
  formData.append('file', file)
  if (sheetName) {
    formData.append('sheetName', sheetName)
  }
  return request({
    url: '/api/TaktPurchasePrices/import',
    method: 'post',
    data: formData,
    headers: {
      'Content-Type': 'multipart/form-data'
    }
  })
}

export function exportPurchasePrice(query: any, sheetName?: string, fileName?: string): Promise<Blob> {
  return request({
    url: '/api/TaktPurchasePrices/export',
    method: 'post',
    data: query,
    params: { sheetName, fileName },
    responseType: 'blob'
  })
}
