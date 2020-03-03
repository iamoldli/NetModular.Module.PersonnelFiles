/** 页面信息 */
const page = new (function() {
  this.title = '组件演示'
  this.icon = 'develop'
  this.name = 'personnelfiles_employee_demo'
  this.path = '/personnelfiles/employee/demo'

  // 关联权限
  this.permissions = []

  // 按钮
  this.buttons = {}
})()

/** 路由信息 */
export const route = {
  page,
  component: () => import(/* webpackChunkName: "PersonnelFiles.User" */ './index')
}

export default page
