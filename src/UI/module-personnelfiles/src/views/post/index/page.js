/** 页面信息 */
const page = new (function() {
  this.title = '岗位管理'
  this.icon = 'post'
  this.name = 'personnelfiles_post'
  this.path = '/personnelfiles/post'

  // 关联权限
  this.permissions = [`${this.name}_query_get`]

  // 按钮
  this.buttons = {
    add: {
      text: '添加',
      type: 'success',
      icon: 'add',
      code: `${this.name}_add`,
      permissions: [`${this.name}_add_post`, 'personnelfiles_position_query_get', 'personnelfiles_position_get_get']
    },
    edit: {
      text: '编辑',
      type: 'text',
      icon: 'edit',
      code: `${this.name}_edit`,
      permissions: [`${this.name}_edit_get`, `${this.name}_update_post`]
    },
    del: {
      text: '删除',
      type: 'text',
      icon: 'delete',
      code: `${this.name}_del`,
      permissions: [`${this.name}_delete_delete`, 'personnelfiles_position_query_get', 'personnelfiles_position_get_get']
    }
  }
})()

/** 路由信息 */
export const route = {
  page,
  component: () => import(/* webpackChunkName: "PersonnelFiles.Post" */ './index')
}

export default page
