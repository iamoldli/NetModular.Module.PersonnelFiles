import WebHost from 'netmodular-module-admin'
import Common from 'netmodular-module-common'
import PersonnelFiles from './index'
import config from './config'

// 注入模块
WebHost.registerModule(PersonnelFiles)

// 注入通用模块
WebHost.registerModule(Common)

// 启动
WebHost.start(config)
