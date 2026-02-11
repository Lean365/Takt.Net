<!-- ======================================== -->
<!-- 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF)  -->
<!-- 命名空间：@/components/business/takt-modal -->
<!-- 文件名称：index.vue -->
<!-- 创建时间：2025-01-21 -->
<!-- 创建人：Takt365(Cursor AI) -->
<!-- 功能描述：Takt 对话框组件，封装 a-modal，统一设置中文按钮文本 -->
<!--  -->
<!-- 版权信息：Copyright (c) 2025 Takt  All rights reserved. -->
<!-- 免责声明：此软件使用 MIT License，作者不承担任何使用风险。 -->
<!-- ======================================== -->

<template>
  <a-modal
    v-model:open="internalOpen"
    v-bind="modalProps"
    @cancel="handleCancel"
  >
    <template v-if="$slots.default" #default>
      <slot />
    </template>
    <template v-if="$slots.title" #title>
      <slot name="title" />
    </template>
    <template #footer>
      <slot name="footer">
        <div class="takt-modal-footer-default">
          <a-button @click="handleCancel" class="takt-modal-btn-cancel">
            <template #icon>
              <RiCloseLine />
            </template>
            {{ cancelTextDisplay }}
          </a-button>
          <a-button type="primary" @click="handleOk" class="takt-modal-btn-ok">
            <template #icon>
              <RiCheckLine />
            </template>
            {{ okTextDisplay }}
          </a-button>
        </div>
      </slot>
    </template>
    <template v-if="$slots.closeIcon" #closeIcon>
      <slot name="closeIcon" />
    </template>
  </a-modal>
</template>

<script setup lang="ts">
import { computed, useAttrs } from 'vue'
import { RiCloseLine, RiCheckLine } from '@remixicon/vue'
import { useI18n } from 'vue-i18n'

const { t } = useI18n()

interface Props {
  /** 确定按钮文本，默认为"提交" */
  okText?: string
  /** 取消按钮文本，默认为"取消" */
  cancelText?: string
  /** 是否显示对话框 */
  open?: boolean
}

const props = withDefaults(defineProps<Props>(), {
  okText: undefined,
  cancelText: undefined,
  open: false
})

const okTextDisplay = computed(() => props.okText ?? t('common.button.submit'))
const cancelTextDisplay = computed(() => props.cancelText ?? t('common.button.cancel'))

const emit = defineEmits<{
  'update:open': [open: boolean]
  'ok': [e: MouseEvent]
  'cancel': [e: MouseEvent]
}>()

const attrs = useAttrs()

// 内部 open 状态
const internalOpen = computed({
  get: () => props.open,
  set: (value: boolean) => {
    emit('update:open', value)
  }
})

// 计算 modal 的所有属性，排除已定义的 props
const modalProps = computed(() => {
  const { okText, cancelText, open, ...rest } = attrs
  return rest
})

// 处理确定按钮点击
const handleOk = (e: MouseEvent) => {
  emit('ok', e)
}

// 处理取消按钮点击
const handleCancel = (e: MouseEvent) => {
  emit('cancel', e)
  emit('update:open', false)
}
</script>

<style scoped lang="less">
.takt-modal-footer-default {
  display: flex;
  justify-content: flex-end;
  gap: 8px;

  :deep(.ant-btn) {
    display: inline-flex;
    align-items: center;
    gap: 4px;

    .anticon {
      margin-inline-end: 0 !important;
    }
  }
}
</style>
