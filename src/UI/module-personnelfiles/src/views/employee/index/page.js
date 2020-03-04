/** 页面信息 */
const page = new (function() {
  this.title = '员工档案'
  this.icon = 'user'
  this.name = 'personnelfiles_employee'
  this.path = '/personnelfiles/employee'

  // 关联权限
  this.permissions = [`${this.name}_query_get`]

  // 按钮
  this.buttons = {
    add: {
      text: '添加',
      type: 'success',
      icon: 'add',
      code: `${this.name}_add`,
      permissions: [`${this.name}_add_post`]
    },
    edit: {
      text: '编辑',
      type: 'text',
      icon: 'edit',
      code: `${this.name}_edit`,
      permissions: [
        `${this.name}_edit_get`,
        `${this.name}_update_post`,
        `${this.name}_editcontact_get`,
        `${this.name}_updatecontact_post`,
        `${this.name}_editpersonal_get`,
        `${this.name}_updatepersonal_post`,
        `${this.name}_familyquery_get`,
        `${this.name}_familyadd_post`,
        `${this.name}_familyedit_get`,
        `${this.name}_familyupdate_post`,
        `${this.name}_familydelete_delete`,
        `${this.name}_educationquery_get`,
        `${this.name}_educationadd_post`,
        `${this.name}_educationedit_get`,
        `${this.name}_educationupdate_post`,
        `${this.name}_educationdelete_delete`,
        `${this.name}_workquery_get`,
        `${this.name}_workadd_post`,
        `${this.name}_workedit_get`,
        `${this.name}_workupdate_post`,
        `${this.name}_workdelete_delete`,
        `${this.name}_editaccount_get`,
        `${this.name}_updateaccount_post`
      ]
    },
    del: {
      text: '删除',
      type: 'text',
      icon: 'delete',
      code: `${this.name}_del`,
      permissions: [`${this.name}_delete_delete`]
    },
    leave: {
      text: '离职',
      type: 'text',
      icon: 'edit',
      code: `${this.name}_leave`,
      permissions: [`${this.name}_leave_post`, `${this.name}_leaveinfo_get`]
    },
    preview: {
      text: '预览',
      type: 'text',
      icon: 'preview',
      code: `${this.name}_preview`,
      permissions: [
        `${this.name}_edit_get`,
        `${this.name}_editcontact_get`,
        `${this.name}_editpersonal_get`,
        `${this.name}_familyquery_get`,
        `${this.name}_educationquery_get`,
        `${this.name}_workquery_get`,
        `${this.name}_workedit_get`,
        `${this.name}_editaccount_get`
      ]
    }
  }
})()

/** 路由信息 */
export const route = {
  page,
  component: () => import(/* webpackChunkName: "PersonnelFiles.User" */ './index')
}

export default page
