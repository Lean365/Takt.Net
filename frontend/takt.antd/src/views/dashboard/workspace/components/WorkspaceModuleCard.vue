<template>
  <a-card class="workspace-module-card" :body-style="bodyStyle">
    <template #title>
      <span class="workspace-module-card-drag-handle" title="拖动排序">
        <RiDraggable />
      </span>
      <span class="workspace-module-card-title-text">{{ displayTitle }}</span>
    </template>
    <template #extra>
      <a-space>
        <slot name="headActions" />
        <a-tooltip v-if="showRemoveButton" :title="t('dashboard.workspace.removeModule')">
          <a-button type="text" size="small" danger @click="onRemove">
            <template #icon><RiDeleteBinLine /></template>
          </a-button>
        </a-tooltip>
      </a-space>
    </template>
    <slot />
  </a-card>
</template>

<script setup lang="ts">
import { computed } from 'vue'
import { useI18n } from 'vue-i18n'
import { RiDeleteBinLine, RiDraggable } from '@remixicon/vue'
import type { WorkspaceModuleItem } from '@/types/dashboard/workspace'
import { WORKSPACE_AVAILABLE_MODULES } from '../config'

const props = defineProps<{
  module: WorkspaceModuleItem
}>()

const emit = defineEmits<{
  remove: []
}>()

const { t } = useI18n()

const displayTitle = computed(() => {
  if (props.module.moduleKey === 'custom' && props.module.customTitle) {
    return props.module.customTitle
  }
  const meta = WORKSPACE_AVAILABLE_MODULES.find(m => m.key === props.module.moduleKey)
  return meta ? t(meta.titleKey) : props.module.moduleKey
})

/** welcome、shortcut 不允许删除 */
const showRemoveButton = computed(() => {
  const key = props.module.moduleKey
  return key !== 'welcome' && key !== 'shortcut'
})

const bodyStyle = computed(() => ({
  minHeight: '128px',
  padding: '16px 24px'
}))

function onRemove() {
  emit('remove')
}
</script>

<style scoped lang="less">
.workspace-module-card {
  height: 100%;
  :deep(.ant-card-head) {
    min-height: 32px !important;
    height: 32px !important;
    padding: 0 16px;
    .ant-card-head-title,
    .ant-card-extra {
      padding: 0;
      line-height: 32px !important;
    }
    .ant-card-head-title {
      display: flex;
      align-items: center;
      gap: 6px;
    }
  }
}
.workspace-module-card-drag-handle {
  cursor: move;
  color: var(--ant-color-text-tertiary);
  display: inline-flex;
  user-select: none;
  &:hover {
    color: var(--ant-color-text-secondary);
  }
}
.workspace-module-card-title-text {
  flex: 1;
  min-width: 0;
}
</style>
