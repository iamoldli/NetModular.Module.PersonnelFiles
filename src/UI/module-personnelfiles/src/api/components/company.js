import module from '../../module'

export default name => {
  const root = `${module.code}/${name}/`
  const urls = {
    get: root + 'Get'
  }

  const get = () => {
    return $http.get(urls.get)
  }

  return {
    get
  }
}
