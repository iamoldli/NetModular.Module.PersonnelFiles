import module from '../../module'

export default name => {
  const root = `${module.code}/${name}/`
  const crud = $http.crud(root)
  const urls = {
    leave: root + 'Leave',
    leaveInfo: root + 'LeaveInfo',
    editContact: root + 'EditContact',
    updateContact: root + 'updateContact',
    editPersonal: root + 'EditPersonal',
    updatePersonal: root + 'updatePersonal',
    familyQuery: root + 'familyQuery',
    familyAdd: root + 'familyAdd',
    familyEdit: root + 'familyEdit',
    familyUpdate: root + 'familyUpdate',
    familyDelete: root + 'familyDelete',
    educationQuery: root + 'educationQuery',
    educationAdd: root + 'educationAdd',
    educationEdit: root + 'educationEdit',
    educationUpdate: root + 'educationUpdate',
    educationDelete: root + 'educationDelete',
    workQuery: root + 'workQuery',
    workAdd: root + 'workAdd',
    workEdit: root + 'workEdit',
    workUpdate: root + 'workUpdate',
    workDelete: root + 'workDelete',
    editAccount: root + 'EditAccount',
    updateAccount: root + 'updateAccount',
    queryWithSameDepartment: root + 'QueryWithSameDepartment',
    queryLatestSelect: root + 'QueryLatestSelect',
    saveLatestSelect: root + 'SaveLatestSelect',
    getTree: root + 'Tree',
    getBaseInfoList: root + 'BaseInfoList'
  }

  const leave = params => {
    return $http.post(urls.leave, params)
  }

  const getLeaveInfo = id => {
    return $http.get(urls.leaveInfo, { id })
  }

  const editContact = id => {
    return $http.get(urls.editContact, { id })
  }

  const updateContact = params => {
    return $http.post(urls.updateContact, params)
  }

  const editPersonal = id => {
    return $http.get(urls.editPersonal, { id })
  }

  const updatePersonal = params => {
    return $http.post(urls.updatePersonal, params)
  }

  const familyQuery = employeeId => {
    return $http.get(urls.familyQuery, { employeeId })
  }

  const familyAdd = params => {
    return $http.post(urls.familyAdd, params)
  }

  const familyDelete = id => {
    return $http.delete(urls.familyDelete, { id })
  }

  const familyEdit = id => {
    return $http.get(urls.familyEdit, { id })
  }

  const familyUpdate = params => {
    return $http.post(urls.familyUpdate, params)
  }

  const educationQuery = employeeId => {
    return $http.get(urls.educationQuery, { employeeId })
  }

  const educationAdd = params => {
    return $http.post(urls.educationAdd, params)
  }

  const educationDelete = id => {
    return $http.delete(urls.educationDelete, { id })
  }

  const educationEdit = id => {
    return $http.get(urls.educationEdit, { id })
  }

  const educationUpdate = params => {
    return $http.post(urls.educationUpdate, params)
  }

  const workQuery = employeeId => {
    return $http.get(urls.workQuery, { employeeId })
  }

  const workAdd = params => {
    return $http.post(urls.workAdd, params)
  }

  const workDelete = id => {
    return $http.delete(urls.workDelete, { id })
  }

  const workEdit = id => {
    return $http.get(urls.workEdit, { id })
  }

  const workUpdate = params => {
    return $http.post(urls.workUpdate, params)
  }

  const editAccount = id => {
    return $http.get(urls.editAccount, { id })
  }

  const updateAccount = params => {
    return $http.post(urls.updateAccount, params)
  }
  const queryWithSameDepartment = params => {
    return $http.get(urls.queryWithSameDepartment, params)
  }

  const queryLatestSelect = params => {
    return $http.get(urls.queryLatestSelect, params)
  }

  const saveLatestSelect = ids => {
    return $http.post(urls.saveLatestSelect, ids)
  }

  const getTree = () => {
    return $http.get(urls.getTree)
  }

  const getBaseInfoList = ids => {
    return $http.get(urls.getBaseInfoList, { ids })
  }

  return {
    ...crud,
    leave,
    getLeaveInfo,
    editContact,
    updateContact,
    editPersonal,
    updatePersonal,
    familyQuery,
    familyAdd,
    familyDelete,
    familyEdit,
    familyUpdate,
    educationQuery,
    educationAdd,
    educationDelete,
    educationEdit,
    educationUpdate,
    workQuery,
    workAdd,
    workDelete,
    workEdit,
    workUpdate,
    editAccount,
    updateAccount,
    queryWithSameDepartment,
    queryLatestSelect,
    saveLatestSelect,
    getTree,
    getBaseInfoList
  }
}
