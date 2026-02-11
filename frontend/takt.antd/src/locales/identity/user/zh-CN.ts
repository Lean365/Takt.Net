/**
 * 用户模块 · 中文
 * - 页面标题用 entity.user + common.action.management 拼接
 * - 此处仅保留：个人信息/修改密码、Tab、校验文案等无法拼接的
 */
export default {
  profile: '个人信息',
  changePasswordTitle: '修改密码',

  /** 密码相关（修改密码弹窗） */
  password: {
    old: {
      label: '旧密码',
      placeholder: '请输入旧密码',
      validation: {
        required: '旧密码不能为空'
      }
    },
    new: {
      label: '新密码',
      placeholder: '请输入新密码',
      validation: {
        required: '新密码不能为空',
        format: '密码必须为8-20位，且包含字母和数字'
      }
    },
    confirm: {
      label: '确认新密码',
      placeholder: '请再次输入新密码',
      validation: {
        required: '确认新密码不能为空',
        mismatch: '两次输入的密码不一致'
      }
    }
  },

  /** Tab 标签（用户表单内 Tab） */
  tabs: {
    basicInfo: '基本资料',
    permission: '权限',
    avatar: '头像设置'
  },

  /** 本模块专用字段/标签（实体字段用 entity.user.xxx） */
  fields: {
    password: {
      label: '密码'
    },
    formRef: {
      label: '表单引用'
    },
    userName: {
      validation: {
        format: '用户名必须以小写字母开头，允许小写字母和数字，不允许特殊符号，4-20位'
      }
    },
    realName: {
      validation: {
        format: '真实姓名必须为2-10个汉字'
      }
    },
    fullName: {
      validation: {
        format: '全名格式不正确，允许中文、英文、数字、空格、点、横线，2-50位。英文部分必须使用帕斯卡命名（首字母大写）'
      }
    },
    nickName: {
      validation: {
        format: '昵称格式不正确，允许中文、英文、数字、下划线、横线、点，1-20位。英文部分必须使用帕斯卡命名（首字母大写）'
      }
    },
    englishName: {
      validation: {
        format: '英文名格式不正确，必须为英文字母、数字、空格、横线、点、单引号，2-30位，必须以字母开头和结尾，且必须使用帕斯卡命名（首字母大写）'
      }
    }
  }
}
