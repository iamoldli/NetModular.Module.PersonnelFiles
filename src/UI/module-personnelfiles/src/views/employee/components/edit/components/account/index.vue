<template>
  <nm-form-page ref="form" v-bind="form" v-on="on">
    <el-row>
      <el-col :span="10" :offset="1">
        <el-form-item label="用户名：" prop="userName">
          <el-input v-model="form.model.userName" clearable placeholder="系统登录用户名">
            <nm-icon name="user" slot="prefix" />
          </el-input>
        </el-form-item>
        <el-form-item label="密码：" prop="password">
          <el-input v-model="form.model.password" clearable>
            <nm-icon name="password" slot="prefix" />
          </el-input>
        </el-form-item>
      </el-col>
      <el-col :span="10">
        <el-form-item label="角色：" prop="roles">
          <nm-role-select v-model="form.model.roles" multiple />
        </el-form-item>
        <el-form-item label="确认密码：" prop="confirmPassword">
          <el-input v-model="form.model.confirmPassword" clearable>
            <nm-icon name="password" slot="prefix" />
          </el-input>
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-page>
</template>

<script>
import mixins from '../mixins'

const { editAccount, updateAccount } = $api.personnelFiles.employee

export default {
  mixins: [mixins],
  data() {
    return {
      actions: { edit: editAccount },
      form: {
        header: false,
        action: updateAccount,
        model: {
          /** 用户名 */
          userName: '',
          /**角色 */
          roles: [],
          /** 密码 */
          password: '',
          /** 确认密码 */
          confirmPassword: ''
        },
        rules: {
          userName: [{ required: true, message: '请输入用户名', trigger: 'blur' }],
          password: [{ min: 6, max: 30, message: '密码长度不能小于6位获大于30位', trigger: 'blur' }],
          confirmPassword: [
            {
              validator: (rule, value, callback) => {
                let pass = this.form.model.password
                if (pass !== '' && value !== pass) {
                  callback(new Error('两次输入密码不一致!'))
                } else {
                  callback()
                }
              },
              trigger: 'blur'
            }
          ]
        }
      }
    }
  }
}
</script>
