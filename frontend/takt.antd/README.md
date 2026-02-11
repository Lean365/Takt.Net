# Takt Digital Factory (TDF)  Frontend - Ant Design Vue

基于 Vue3 + Vite + TypeScript + Ant Design Vue 的前端项目

## 技术栈

- Vue 3.4+
- Vite 5.0+
- TypeScript 5.3+
- Ant Design Vue 4.2+
- Vue Router 4.3+
- Pinia 2.1+
- Vue I18n 9.9+
- Axios 1.6+

## 功能特性

- ✅ Vue3 Composition API
- ✅ TypeScript 支持
- ✅ 国际化（i18n）支持（中文/英文）
- ✅ 多主题切换（亮色/暗色）
- ✅ 权限验证系统
- ✅ 路由守卫
- ✅ 状态管理（Pinia）
- ✅ 自动导入组件
- ✅ 代码规范（ESLint）

## 开发

```bash
# 安装依赖
npm install

# 启动开发服务器
npm run dev

# 构建生产版本
npm run build

# 预览生产构建
npm run preview
```

## 项目结构

```
src/
  ├── api/           # API 请求
  ├── assets/        # 静态资源
  ├── components/    # 公共组件
  ├── layouts/       # 布局组件
  ├── locales/       # 国际化
  ├── permission/    # 权限相关
  ├── router/        # 路由配置
  ├── stores/        # Pinia stores
  ├── styles/        # 全局样式
  ├── theme/         # 主题配置
  ├── types/         # TypeScript 类型定义
  ├── utils/         # 工具函数
  ├── views/         # 页面组件
  ├── App.vue        # 根组件
  └── main.ts        # 入口文件
```
