<template>
  <object
    type="image/svg+xml"
    :aria-label="ariaLabel"
    :width="width"
    :height="height"
    :data="objectData"
    class="svgator-object"
  >
    <img :alt="ariaLabel" :src="objectData" class="svgator-fallback" />
  </object>
</template>

<script setup lang="ts">
import { ref, watch, onMounted, onBeforeUnmount } from 'vue'
import taktSmartSvg from '@/assets/images/takt-smart.svg'

const props = withDefaults(
  defineProps<{
    /** SVG 地址，支持本地或远程 SVGator 等动效 SVG */
    src?: string
    /** 宽度 */
    width?: number | string
    /** 高度 */
    height?: number | string
    /** 无障碍标签 */
    ariaLabel?: string
  }>(),
  {
    src: taktSmartSvg,
    width: 800,
    height: 256,
    ariaLabel: 'Onboarding app explainer animation'
  }
)

const objectData = ref(props.src)
let blobUrlToRevoke: string | null = null

async function loadSvgWithTransparentBackground(url: string): Promise<string> {
  const res = await fetch(url)
  const text = await res.text()
  const transparent = text.replace(
    /style="background-color:#edf2ff"/i,
    'style="background-color:transparent"'
  )
  const blob = new Blob([transparent], { type: 'image/svg+xml' })
  const blobUrl = URL.createObjectURL(blob)
  blobUrlToRevoke = blobUrl
  return blobUrl
}

function ensureObjectData() {
  const url = props.src ?? taktSmartSvg
  if (url === taktSmartSvg) {
    loadSvgWithTransparentBackground(url).then((blobUrl) => {
      objectData.value = blobUrl
    })
  } else {
    if (blobUrlToRevoke) {
      URL.revokeObjectURL(blobUrlToRevoke)
      blobUrlToRevoke = null
    }
    objectData.value = url
  }
}

watch(() => props.src, ensureObjectData)

onMounted(ensureObjectData)

onBeforeUnmount(() => {
  if (blobUrlToRevoke) {
    URL.revokeObjectURL(blobUrlToRevoke)
    blobUrlToRevoke = null
  }
})
</script>

<style scoped lang="less">
.svgator-object {
  display: block;
  object-fit: contain;
}

.svgator-fallback {
  max-width: 100%;
  height: auto;
  object-fit: contain;
}
</style>
