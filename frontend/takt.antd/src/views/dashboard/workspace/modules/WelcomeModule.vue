<template>
  <div class="welcome-module">
    <a-row class="welcome-row" :gutter="16">
      <a-col :span="12" class="welcome-greeting-col">{{ greetingText }}</a-col>
      <a-col :span="12" class="welcome-date-col">
        <a-tooltip :title="dateTooltip">
          <span>{{ t('dashboard.workspace.currentTimeLabel') }} {{ dateText }}</span>
        </a-tooltip>
      </a-col>
    </a-row>
    <div class="welcome-quote">{{ quoteText }}</div>
  </div>
</template>

<script setup lang="ts">
import { computed, onBeforeUnmount, onMounted, ref } from 'vue'
import { useI18n } from 'vue-i18n'
import dayjs from 'dayjs'
import utc from 'dayjs/plugin/utc'
import timezone from 'dayjs/plugin/timezone'
import dayOfYear from 'dayjs/plugin/dayOfYear'
import weekOfYear from 'dayjs/plugin/weekOfYear'
import quarterOfYear from 'dayjs/plugin/quarterOfYear'
import { useUserStore } from '@/stores/identity/user'

dayjs.extend(utc)
dayjs.extend(timezone)
dayjs.extend(dayOfYear)
dayjs.extend(weekOfYear)
dayjs.extend(quarterOfYear)

const { t, locale } = useI18n()
const userStore = useUserStore()

const now = ref(new Date())
let timer: number | null = null

const updateNow = () => {
  now.value = new Date()
}

onMounted(() => {
  updateNow()
  timer = window.setInterval(updateNow, 1000)
})

onBeforeUnmount(() => {
  if (timer !== null) {
    clearInterval(timer)
    timer = null
  }
})

const localeTimeZoneMap: Record<string, string> = {
  'zh-CN': 'Asia/Shanghai',
  'zh-TW': 'Asia/Taipei',
  'en-US': 'America/New_York',
  'fr-FR': 'Europe/Paris',
  'es-ES': 'Europe/Madrid',
  'ja-JP': 'Asia/Tokyo',
  'ko-KR': 'Asia/Seoul',
  'ru-RU': 'Europe/Moscow',
  'ar-SA': 'Asia/Riyadh'
}

const timeZone = computed(() => {
  return localeTimeZoneMap[locale.value] || dayjs.tz.guess()
})

const dateText = computed(() =>
  dayjs(now.value).tz(timeZone.value).format('YYYY-MM-DD HH:mm:ss')
)

const dateTooltip = computed(() => {
  const d = dayjs(now.value).tz(timeZone.value)
  const year = d.year()
  const month = d.month() + 1
  const day = d.date()
  const dayOfYearValue = d.dayOfYear()
  const quarter = d.quarter()
  const week = d.week()
  const weekdayName = d.format('dddd')

  if (locale.value.startsWith('zh')) {
    return `今天是${year}年${month}月${day}日，第${dayOfYearValue}天，第${quarter}季度，第${week}周，${weekdayName}`
  }

  return `Today is ${d.format('YYYY-MM-DD')}, day ${dayOfYearValue} of the year, Q${quarter}, week ${week}, ${weekdayName}`
})

const greetingText = computed(() => {
  const hour = now.value.getHours()
  let key: string
  if (hour < 9) key = 'common.greeting.morning'
  else if (hour < 12) key = 'common.greeting.forenoon'
  else if (hour < 14) key = 'common.greeting.noon'
  else if (hour < 18) key = 'common.greeting.afternoon'
  else key = 'common.greeting.night'
  const greeting = t(key)
  const name = userStore.userInfo?.realName || userStore.userInfo?.userName || ''
  return name ? `${greeting}${name}` : greeting
})

const quoteText = computed(() => {
  const letters = 'abcdefghijklmnopqrstuvwxyz'
  const idx = now.value.getDate() % 26
  const key = `common.quote.${letters[idx]}`
  return t(key)
})
</script>

<style scoped lang="less">
.welcome-module {
  padding: 16px 0;
  min-height: 128px;
  .welcome-row {
    margin-bottom: 12px;
  }
  .welcome-greeting-col {
    font-size: 18px;
    font-weight: 500;
  }
  .welcome-date-col {
    font-size: 14px;
    color: var(--ant-color-text-tertiary);
    text-align: right;
  }
  .welcome-quote {
    color: var(--ant-color-text-secondary);
    font-size: 14px;
    line-height: 1.6;
  }
}
</style>
