<!-- ======================================== -->
<!-- 项目名称：节拍数字工厂 · Takt Digital Factory (TDF)  -->
<!-- 命名空间：@/views/code/generator/components -->
<!-- 文件名称：code-preview.vue -->
<!-- 功能描述：生成代码预览（文件列表 + 内容） -->
<!-- ======================================== -->

<template>
  <TaktModal
    v-model:open="open"
    title="代码预览"
    width="80%"
    :centered="true"
    :body-style="{ height: '75vh', overflow: 'auto' }"
    :footer="null"
    destroy-on-close
    @cancel="handleCancel"
  >
    <div v-if="!files || files.length === 0" class="code-preview-empty">
      <a-empty description="暂无预览内容">
        <template #description>
          <span>请选择一条记录后点击「生成代码」下载 ZIP；</span>
          <span>预览功能需后端支持返回文件列表与内容。</span>
        </template>
      </a-empty>
    </div>
    <div v-else class="code-preview-body">
      <div class="file-list">
        <div
          v-for="(f, i) in files"
          :key="f.name"
          class="file-item"
          :class="{ active: selectedIndex === i }"
          @click="selectedIndex = i"
        >
          {{ f.name }}
        </div>
      </div>
      <div class="file-content">
        <pre><code>{{ selectedContent }}</code></pre>
      </div>
    </div>
  </TaktModal>
</template>

<script setup lang="ts">
import { ref, computed, watch } from 'vue'
import TaktModal from '@/components/business/takt-modal/index.vue'

export interface PreviewFile {
  name: string
  content: string
}

const props = withDefaults(
  defineProps<{
    modelValue?: boolean
    files?: PreviewFile[]
  }>(),
  { modelValue: false, files: () => [] }
)

const emit = defineEmits<{
  (e: 'update:modelValue', value: boolean): void
}>()

const open = computed({
  get: () => props.modelValue,
  set: (v) => emit('update:modelValue', v)
})

const selectedIndex = ref(0)

watch(
  () => props.files,
  (list) => {
    selectedIndex.value = list?.length ? 0 : -1
  },
  { immediate: true }
)

const selectedContent = computed(() => {
  const list = props.files
  if (!list?.length || selectedIndex.value < 0) return ''
  const f = list[selectedIndex.value]
  return f ? f.content : ''
})

function handleCancel() {
  emit('update:modelValue', false)
}
</script>

<style scoped lang="less">
.code-preview-empty {
  padding: 24px 0;
  text-align: center;
}

.code-preview-body {
  display: flex;
  height: 100%;
  min-height: 300px;
  border: 1px solid rgba(0, 0, 0, 0.06);
  border-radius: 4px;

  .file-list {
    width: 220px;
    border-right: 1px solid rgba(0, 0, 0, 0.06);
    overflow-y: auto;
    background: #fafafa;

    .file-item {
      padding: 8px 12px;
      font-size: 12px;
      cursor: pointer;
      word-break: break-all;

      &:hover {
        background: #f0f0f0;
      }

      &.active {
        background: #e6f7ff;
        color: #1890ff;
      }
    }
  }

  .file-content {
    flex: 1;
    overflow: auto;
    padding: 12px;
    background: #fff;

    pre {
      margin: 0;
      font-size: 12px;
      line-height: 1.5;
      white-space: pre-wrap;
      word-break: break-all;
    }

    code {
      font-family: 'Consolas', 'Monaco', monospace;
    }
  }
}
</style>
