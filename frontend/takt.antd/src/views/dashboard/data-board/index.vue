<template>
  <div class="dashboard-data-board">
    <a-card>
      <template #title>
        <a-typography-title :level="2">数据看板</a-typography-title>
      </template>
      <a-row :gutter="16">
        <a-col :span="24">
          <a-typography-paragraph>
            这是数据看板页面，您可以在这里查看系统数据可视化图表。
          </a-typography-paragraph>
        </a-col>
      </a-row>
    </a-card>
  </div>
</template>

<script setup lang="ts">
// 数据看板组件
</script>

<style scoped lang="less">
.dashboard-data-board {
  padding: 24px;
}
</style>
