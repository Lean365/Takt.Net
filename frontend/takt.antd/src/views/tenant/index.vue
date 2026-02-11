<template>
  <div class="tenant">
    <a-card>
      <template #title>租户管理</template>
      <a-table :columns="columns" :data-source="dataSource" />
    </a-card>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'

const columns = [
  {
    title: '租户名称',
    dataIndex: 'tenantName',
    key: 'tenantName'
  },
  {
    title: '租户编码',
    dataIndex: 'tenantCode',
    key: 'tenantCode'
  }
]

const dataSource = ref([])
</script>

<style scoped lang="less">
.tenant {
  // 租户管理样式
}
</style>
