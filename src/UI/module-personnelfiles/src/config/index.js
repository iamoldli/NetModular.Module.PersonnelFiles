const isDev = process.env.NODE_ENV !== 'production'

const config = {
  baseUrl: '/api/',
  /** 账户类型 */
  accountTypes: [
    { label: '员工', value: 1 },
    { label: '管理员', value: 0 }
  ]
}

// 开发模式
if (isDev) {
  config.baseUrl = 'https://api.demo.17mkh.com/api/'
}
export default config
