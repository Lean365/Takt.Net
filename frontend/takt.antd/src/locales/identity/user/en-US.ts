/**
 * User module · English
 * - Page title: entity.user + common.action.management
 * - Here: only profile, change password, tabs, validation messages
 */
export default {
  profile: 'Profile',
  changePasswordTitle: 'Change Password',

  /** Password (change password dialog) */
  password: {
    old: {
      label: 'Old password',
      placeholder: 'Enter old password',
      validation: {
        required: 'Old password is required'
      }
    },
    new: {
      label: 'New password',
      placeholder: 'Enter new password',
      validation: {
        required: 'New password is required',
        format: 'Password must be 8-20 characters with letters and numbers'
      }
    },
    confirm: {
      label: 'Confirm new password',
      placeholder: 'Enter new password again',
      validation: {
        required: 'Confirm password is required',
        mismatch: 'Passwords do not match'
      }
    }
  },

  /** Tab labels (user form tabs) */
  tabs: {
    basicInfo: 'Basic Info',
    permission: 'Permission',
    avatar: 'Avatar'
  },

  /** Module-specific fields (entity fields use entity.user.xxx) */
  fields: {
    password: {
      label: 'Password'
    },
    formRef: {
      label: 'Form reference'
    },
    userName: {
      validation: {
        format: 'Username must start with lowercase letter, 4-20 chars, letters and numbers only'
      }
    },
    realName: {
      validation: {
        format: 'Real name must be 2-10 Chinese characters'
      }
    },
    fullName: {
      validation: {
        format: 'Invalid full name. Chinese, English, digits, space, dot, hyphen, 2-50 chars. English in PascalCase.'
      }
    },
    nickName: {
      validation: {
        format: 'Invalid nickname. Chinese, English, digits, underscore, hyphen, dot, 1-20 chars. English in PascalCase.'
      }
    },
    englishName: {
      validation: {
        format: 'Invalid. Letters, digits, space, hyphen, dot, quote, 2-30 chars, PascalCase.'
      }
    }
  }
}
