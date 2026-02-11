<!-- ======================================== -->
<!-- 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF)  -->
<!-- 命名空间：@/views/identity/user/components -->
<!-- 文件名称：user-change-password.vue -->
<!-- 创建时间：2025-01-22 -->
<!-- 创建人：Takt365(Cursor AI) -->
<!-- 功能描述：修改用户密码组件 -->
<!--  -->
<!-- 版权信息：Copyright (c) 2025 Takt  All rights reserved. -->
<!-- 免责声明：此软件使用 MIT License，作者不承担任何使用风险。 -->
<!-- ======================================== -->

<template>
  <a-form
    ref="formRef"
    :model="formState"
    :rules="rules"
    :label-col="{ span: 6 }"
    :wrapper-col="{ span: 18 }"
    layout="horizontal"
  >
    <a-form-item :label="t('entity.user.username')">
      <a-input
        :value="userName"
        disabled
      />
    </a-form-item>
    <a-form-item :label="t('identity.user.password.old.label')" name="oldPassword">
      <a-input-password
        v-model:value="formState.oldPassword"
        :placeholder="t('common.form.placeholder.required', { field: t('identity.user.password.old.label') })"
        :disabled="loading"
        show-count
        :maxlength="20"
      />
    </a-form-item>
    <a-form-item :label="t('identity.user.password.new.label')" name="newPassword">
      <a-input-password
        v-model:value="formState.newPassword"
        :placeholder="t('common.form.placeholder.required', { field: t('identity.user.password.new.label') })"
        :disabled="loading"
        show-count
        :maxlength="20"
      />
    </a-form-item>
    <a-form-item :label="t('identity.user.password.confirm.label')" name="confirmPassword">
      <a-input-password
        v-model:value="formState.confirmPassword"
        :placeholder="t('common.form.placeholder.requiredAgain', { field: t('identity.user.password.new.label') })"
        :disabled="loading"
        show-count
        :maxlength="20"
      />
    </a-form-item>
  </a-form>
</template>

<script setup lang="ts">
import { ref, reactive, watch } from 'vue'
import { useI18n } from 'vue-i18n'
import type { FormInstance } from 'ant-design-vue'
import type { Rule } from 'ant-design-vue/es/form'
import type { UserChangePwd } from '@/types/identity/user'
import { isValidPassword } from '@/utils/regex'

const props = defineProps<{
  userName: string
  loading?: boolean
}>()

const emit = defineEmits<{
  submit: [values: UserChangePwd]
}>()

const { t } = useI18n()
const formRef = ref<FormInstance>()

interface FormState {
  oldPassword: string
  newPassword: string
  confirmPassword: string
}

const formState = reactive<FormState>({
  oldPassword: '',
  newPassword: '',
  confirmPassword: ''
})

// 验证确认密码
const validateConfirmPassword = (_rule: Rule, value: string) => {
  if (!value) {
    return Promise.reject(t('common.form.placeholder.requiredAgain', { field: t('identity.user.password.new.label') }))
  }
  if (value !== formState.newPassword) {
    return Promise.reject(t('identity.user.password.confirm.validation.mismatch'))
  }
  return Promise.resolve()
}

const rules: Record<string, Rule[]> = {
  oldPassword: [
    { required: true, message: t('common.form.placeholder.required', { field: t('identity.user.password.old.label') }), trigger: 'blur' }
  ],
  newPassword: [
    { required: true, message: t('common.form.placeholder.required', { field: t('identity.user.password.new.label') }), trigger: 'blur' },
    {
      validator: (_rule: Rule, value: string) => {
        if (!value) {
          return Promise.resolve()
        }
        if (!isValidPassword(value)) {
          return Promise.reject(t('identity.user.password.new.validation.format'))
        }
        return Promise.resolve()
      },
      trigger: 'blur'
    }
  ],
  confirmPassword: [
    { required: true, message: t('common.form.placeholder.requiredAgain', { field: t('identity.user.password.new.label') }), trigger: 'blur' },
    { validator: validateConfirmPassword, trigger: 'blur' }
  ]
}

// 验证表单
const validate = async (): Promise<void> => {
  if (!formRef.value) {
    return Promise.reject(new Error(t('common.form.validation.notFound', { target: t('identity.user.fields.formRef.label') })))
  }
  await formRef.value.validate()
}

// 获取表单值
const getValues = (): UserChangePwd => {
  return {
    oldPassword: formState.oldPassword,
    newPassword: formState.newPassword
  }
}

// 重置表单
const resetFields = () => {
  formRef.value?.resetFields()
  formState.oldPassword = ''
  formState.newPassword = ''
  formState.confirmPassword = ''
}

// 监听 loading 变化，重置表单
watch(() => props.loading, (newVal, oldVal) => {
  if (oldVal && !newVal) {
    // loading 从 true 变为 false，说明操作完成，重置表单
    resetFields()
  }
})

defineExpose({
  validate,
  getValues,
  resetFields
})
</script>

<style scoped lang="less">
</style>
