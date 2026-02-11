import request from '../../request'

// 采购订单相关 API
export function getPurchaseOrderList(params: any) {
  return request({
    url: '/api/TaktPurchaseOrders/list',
    method: 'get',
    params
  })
}

export function getPurchaseOrderById(id: string) {
  return request({
    url: `/api/TaktPurchaseOrders/${id}`,
    method: 'get'
  })
}

export function createPurchaseOrder(data: any) {
  return request({
    url: '/api/TaktPurchaseOrders',
    method: 'post',
    data
  })
}

export function updatePurchaseOrder(id: string, data: any) {
  return request({
    url: `/api/TaktPurchaseOrders/${id}`,
    method: 'put',
    data
  })
}

export function deletePurchaseOrder(id: string) {
  return request({
    url: `/api/TaktPurchaseOrders/${id}`,
    method: 'delete'
  })
}

export function getPurchaseOrderTemplate(sheetName?: string, fileName?: string) {
  return request({
    url: '/api/TaktPurchaseOrders/template',
    method: 'get',
    params: { sheetName, fileName },
    responseType: 'blob'
  })
}

export function importPurchaseOrder(file: File, sheetName?: string) {
  const formData = new FormData()
  formData.append('file', file)
  if (sheetName) {
    formData.append('sheetName', sheetName)
  }
  return request({
    url: '/api/TaktPurchaseOrders/import',
    method: 'post',
    data: formData,
    headers: {
      'Content-Type': 'multipart/form-data'
    }
  })
}

export function exportPurchaseOrder(query: any, sheetName?: string, fileName?: string): Promise<Blob> {
  return request({
    url: '/api/TaktPurchaseOrders/export',
    method: 'post',
    data: query,
    params: { sheetName, fileName },
    responseType: 'blob'
  })
}
