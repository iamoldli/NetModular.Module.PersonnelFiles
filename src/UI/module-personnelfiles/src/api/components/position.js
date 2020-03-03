import module from '../../module'

export default name => {
  const root = `${module.code}/${name}/`
  const crud = $http.crud(root)
  const urls = {
    get: root + 'Get'
  }

  const get = id => {
    return $http.get(urls.get, { id })
  }

  return {
    ...crud,
    get
  }
}
