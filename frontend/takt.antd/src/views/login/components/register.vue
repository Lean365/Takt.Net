<!-- ======================================== -->
<!-- 项目名称：节拍数字工厂 ·Takt Digital Factory (TDF)  -->
<!-- 命名空间：@/views/login -->
<!-- 文件名称：register.vue -->
<!-- 创建时间：2025-01-22 -->
<!-- 创建人：Takt365(Cursor AI) -->
<!-- 功能描述：用户注册页面 -->
<!--  -->
<!-- 版权信息：Copyright (c) 2025 Takt  All rights reserved. -->
<!-- 免责声明：此软件使用 MIT License，作者不承担任何使用风险。 -->
<!-- ======================================== -->

<template>
  <div class="login-page" :class="[`position-${layoutPosition}`, `theme-${themeStore.themeMode}`]">
    <!-- 背景层 -->
    <div class="login-background" :style="{ background: backgroundGradient }"></div>
    <!-- 左上角 Logo -->
    <div class="login-logo">
      <img :src="appLogo" :alt="$t('common.app.name')" />
      <div class="login-app-info">
        <a-typography-text class="login-app-name">{{ $t('common.app.name') }}</a-typography-text>
        <a-typography-text class="login-product-code">{{ productCodeWithVersion }}</a-typography-text>
      </div>
    </div>
    <!-- 右上角按钮组 -->
    <div class="button-group-wrapper">
      <a-button-group size="small">
        <!-- 颜色切换 -->
        <a-radio-button size="small"> <TaktColorToggle type="icon" /></a-radio-button>
        <!-- 表单位置切换 -->
        <a-radio-button size="small"> <TaktLayoutToggle v-model:position="layoutPosition" /></a-radio-button>        
        <!-- 语言切换 -->        
        <a-radio-button size="small"> <TaktLocaleToggle type="icon" /></a-radio-button>
        <!-- 主题切换 -->        
        <a-radio-button size="small"> <TaktThemeToggle type="icon" /></a-radio-button>
      </a-button-group>
    </div>
    <!-- 登录容器 -->
    <div class="login-container">
      <!-- 左侧内容区（仅在非居中模式下显示） -->
      <div v-if="layoutPosition !== 'center'" class="login-left-panel">
        <div class="login-illustration">
          <div class="login-icon-wrapper">
            <i class="fa-solid fa-robot login-icon"></i>
          </div>
          <div class="login-slogan">
            <a-typography-text class="login-slogan-text">{{ $t('common.app.slogan') }}</a-typography-text>
            <a-typography-text class="login-tagline">{{ $t('common.app.tagline') }}</a-typography-text>
          </div>
        </div>
      </div>
      <!-- 右侧表单区 -->
      <div class="login-right-panel" :class="`panel-${layoutPosition}`" :style="{ background: panelBackgroundGradient }">
        <div class="login-box">
          <div class="login-header">
            <a-typography-title :level="3">{{ t('login.sign.title') }}</a-typography-title>
            <a-typography-text class="login-subtitle">{{ t('login.sign.subtitle') }}</a-typography-text>
          </div>
          <a-form
            ref="formRef"
            :model="formState"
            :rules="rules"
            @finish="handleSubmit"
            class="login-form"
          >
            <a-form-item name="userName">
              <a-input
                v-model:value="formState.userName"
                :placeholder="t('login.fields.username.placeholder')"
                size="large"
                autocomplete="username"
              >
                <template #prefix>
                  <RiUserLine />
                </template>
              </a-input>
            </a-form-item>
            <a-form-item name="userEmail">
              <a-input
                v-model:value="formState.userEmail"
                :placeholder="t('login.fields.userEmail.placeholder')"
                size="large"
                autocomplete="email"
              >
                <template #prefix>
                  <RiMailLine />
                </template>
              </a-input>
            </a-form-item>
            <a-form-item name="userPhone">
              <a-input
                v-model:value="formState.userPhone"
                :placeholder="t('login.fields.userPhone.placeholder')"
                size="large"
                autocomplete="tel"
              >
                <template #prefix>
                  <RiPhoneLine />
                </template>
              </a-input>
            </a-form-item>
            <a-form-item>
              <a-button type="primary" html-type="submit" block size="large" :loading="loading">
                <template #icon>
                  <RiUserAddLine />
                </template>
                {{ t('login.sign.title') }}
              </a-button>
            </a-form-item>
            <a-form-item>
              <div class="login-footer-links">
                <a @click="goToLogin">{{ t('login.sign.hasAccount') }}</a>
              </div>
            </a-form-item>
          </a-form>
        </div>
      </div>
    </div>

    <!-- 验证码弹窗：点提交且后端启用验证码时弹出，验证成功后再注册；位置跟随表单，500x250 -->
    <a-modal
      v-model:open="captchaModalVisible"
      :title="$t('login.fields.captcha.validation.required')"
      :footer="null"
      :closable="true"
      :maskClosable="false"
      :width="500"
      centered
      :wrap-class-name="captchaModalWrapClassName"
      :body-style="captchaModalBodyStyle"
      @cancel="captchaModalVisible = false"
    >
      <div class="login-captcha-modal-body" style="width: 100%; height: 100%; display: flex; align-items: center; justify-content: center;">
        <component
          v-if="captchaModalData && captchaModalVisible"
          :is="captchaModalComponent"
          :initial-data="captchaModalData"
          :auto-generate="false"
          @success="onCaptchaModalSuccess"
          @fail="onCaptchaModalFail"
        />
      </div>
    </a-modal>
  </div>
</template>

<script setup lang="ts">
import { reactive, ref, onMounted, computed, onBeforeUnmount, nextTick } from 'vue'
import { useRouter } from 'vue-router'
import { useI18n } from 'vue-i18n'
import { storeToRefs } from 'pinia'
import { useThemeStore } from '@/stores/theme'
import { useSettingStore, getThemeColorValue } from '@/stores/setting'
import { message } from 'ant-design-vue'
import { RiUserLine, RiUserAddLine, RiMailLine, RiPhoneLine } from '@remixicon/vue'
import type { Rule } from 'ant-design-vue/es/form'
import logoSvg from '@/assets/images/takt.svg'
import TaktCaptchaSlider from '@/components/common/takt-captcha-slider/index.vue'
import TaktCaptchaBehavior from '@/components/common/takt-captcha-behavior/index.vue'
import { generateCaptcha as generateCaptchaApi, type CaptchaGenerateResult } from '@/api/identity/captcha'
import { create } from '@/api/identity/user'
import { logger } from '@/utils/logger'
import { appVersion } from '@/utils/appMeta'

const props = defineProps<{ embedded?: boolean }>()
const emit = defineEmits<{ (e: 'back'): void }>()

const router = useRouter()
const themeStore = useThemeStore()
const settingStore = useSettingStore()
const { setting } = storeToRefs(settingStore)
const { t } = useI18n()

const themeColor = computed(() => getThemeColorValue(setting.value?.themeColor ?? { type: 'blue' }))

// 计算背景径向渐变样式
const backgroundGradient = computed(() => {
  const color = themeColor.value
  if (themeStore.themeMode === 'dark') {
    return `radial-gradient(circle at 750% 50%, ${color} 0%, #000000 100%)`
  } else {
    return `radial-gradient(circle at 750% 50%, ${color} 0%, #ffffff 100%)`
  }
})

// 计算表单区域背景径向渐变样式
const panelBackgroundGradient = computed(() => {
  const color = themeColor.value
  if (themeStore.themeMode === 'dark') {
    return `radial-gradient(circle at 750% 50%, ${color} 0%, #000000 100%)`
  } else {
    return `radial-gradient(circle at 750% 50%, ${color} 0%, #ffffff 100%)`
  }
})

// Logo 路径
const appLogo = computed(() => logoSvg)

// 拼接 productcode 和 version（版本号来自 package.json，构建时注入）
const productCodeWithVersion = computed(() => {
  return `${t('common.app.productcode')} V${appVersion}`
})

// 登录表单在页面中的位置
const savedLayoutPosition = localStorage.getItem('loginLayoutPosition') as
  | 'left'
  | 'center'
  | 'right'
  | null
const layoutPosition = ref<'left' | 'center' | 'right'>(
  savedLayoutPosition || 'right'
)

const formState = reactive({
  userName: '',
  userEmail: '',
  userPhone: ''
})

// 验证码弹窗：点提交后若后端启用验证码则弹出，验证成功后再注册
const captchaModalVisible = ref(false)
const captchaModalData = ref<CaptchaGenerateResult | null>(null)
const captchaModalType = ref<'Slider' | 'Behavior'>('Behavior')
const captchaModalComponent = computed(() =>
  captchaModalType.value === 'Slider' ? TaktCaptchaSlider : TaktCaptchaBehavior
)
const captchaModalBodyStyle = {
  width: '500px',
  height: '250px',
  display: 'flex',
  alignItems: 'center',
  justifyContent: 'center',
  margin: 0
}
const captchaModalWrapClassName = computed(() => `login-captcha-modal-wrap login-captcha-modal--${layoutPosition.value}`)

// 加载状态
const loading = ref(false)

const formRef = ref()

const rules = computed<Record<string, Rule[]>>(() => ({
  userName: [
    { required: true, message: t('login.fields.username.validation.required'), trigger: 'blur' },
    { min: 3, message: t('login.fields.username.validation.min'), trigger: 'blur' },
    { max: 20, message: t('login.fields.username.validation.max'), trigger: 'blur' }
  ],
  userEmail: [
    { required: true, message: t('login.fields.userEmail.validation.required'), trigger: 'blur' },
    { type: 'email', message: t('login.fields.userEmail.validation.format'), trigger: 'blur' }
  ],
  userPhone: [
    { required: true, message: t('login.fields.userPhone.validation.required'), trigger: 'blur' },
    { pattern: /^1[3-9]\d{9}$/, message: t('login.fields.userPhone.validation.format'), trigger: 'blur' }
  ]
}))

// 实际提交注册（验证码已通过或未启用时调用）
async function doRegister() {
  try {
    loading.value = true
    const userName = formState.userName.trim()
    const registerData = {
      userName,
      realName: userName,
      fullName: userName,
      nickName: userName,
      englishName: userName,
      avatar: '',
      gender: 0,
      userType: 0,
      userEmail: formState.userEmail.trim(),
      userPhone: formState.userPhone.trim(),
      passwordHash: '',
      userStatus: 0,
      roleIds: [],
      deptIds: [],
      postIds: [],
      tenantIds: []
    }
    await create(registerData)
    message.success(t('login.sign.successInitialPassword'))
    setTimeout(() => {
      if (props.embedded) emit('back')
      else router.push('/login')
    }, 1500)
  } catch (error: any) {
    logger.error('[Register] 注册失败:', error)
    message.error(error.message || t('login.sign.fail'))
    captchaModalVisible.value = false
  } finally {
    loading.value = false
  }
}

function onCaptchaModalSuccess() {
  captchaModalVisible.value = false
  doRegister()
}

function onCaptchaModalFail(msg: string) {
  message.error(msg || t('login.fields.captcha.validation.required'))
}

const handleSubmit = async () => {
  try {
    await formRef.value?.validateFields(['userName', 'userEmail', 'userPhone'])
  } catch {
    return
  }

  try {
    loading.value = true
    const result = await generateCaptchaApi() as CaptchaGenerateResult
    if (!result) {
      message.error(t('login.fields.captcha.validation.required'))
      loading.value = false
      return
    }

    if (result.enabled === false || result.enabled === undefined) {
      loading.value = false
      await doRegister()
      return
    }

    if (result.type !== 'Slider' && result.type !== 'Behavior') {
      message.error(t('login.fields.captcha.validation.typeRequired'))
      loading.value = false
      return
    }
    captchaModalType.value = result.type
    captchaModalData.value = result
    captchaModalVisible.value = true
    loading.value = false
  } catch (error: any) {
    logger.error('[Register] 获取验证码配置失败', error)
    message.error(error?.message || t('login.fields.captcha.validation.required'))
    loading.value = false
  }
}

// 返回登录（内嵌时 emit，否则路由跳转）
const goToLogin = () => {
  if (props.embedded) emit('back')
  else router.push('/login')
}

// 窗口大小变化处理函数
// 组件卸载时清理资源
onBeforeUnmount(() => {})

onMounted(async () => {
  try {
    const axios = (await import('axios')).default
    await axios.get('/api/TaktHealth', { baseURL: '', withCredentials: true })
  } catch (error: any) {
    logger.warn('[CSRF] 获取 CSRF Token 失败:', error)
  }
})
</script>

<style scoped lang="less">
@import '../login.less';
</style>
<style lang="less">
/* 验证码弹窗位置跟随表单（与 login/index.vue 一致） */
.login-captcha-modal-wrap.ant-modal-wrap .ant-modal {
  position: fixed !important;
  top: 50% !important;
  margin: 0 !important;
  padding-bottom: 0;
  display: block !important;
  vertical-align: unset !important;
  transform: translate(-50%, -50%) !important;
}
.login-captcha-modal--left.ant-modal-wrap .ant-modal { left: 16.666% !important; }
.login-captcha-modal--center.ant-modal-wrap .ant-modal { left: 50% !important; }
.login-captcha-modal--right.ant-modal-wrap .ant-modal { left: 83.333% !important; }
</style>
<style scoped lang="less">
/* login-header 与 a-form 之间间隔 64px */
.login-box {
  gap: 64px;
}

.login-subtitle {
  display: block;
  margin-top: 8px;
  font-size: 14px;
  color: rgba(0, 0, 0, 0.45);
  
  .theme-dark & {
    color: rgba(255, 255, 255, 0.65);
  }
}

.login-footer-links {
  width: 100%;
  text-align: center;
  
  a {
    color: var(--ant-primary-color);
    text-decoration: none;
    
    &:hover {
      text-decoration: underline;
    }
  }
}
</style>
