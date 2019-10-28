import WebHost from 'netmodular-module-admin'
import Common from 'netmodular-module-common'
import config from './config'
import PersonnelFiles from './index'

// 注入模块
WebHost.registerModule(PersonnelFiles)

// 注入通用模块
WebHost.registerModule(Common)

// 启动
WebHost.start(config)
