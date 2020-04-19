<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <el-divider content-position="left">基本信息</el-divider>
    <el-row>
      <el-col :span="13" :offset="1">
        <el-form-item label="部门：" prop="departmentId">
          <el-input :value="department.path" disabled />
        </el-form-item>
        <el-form-item label="姓名：" prop="name">
          <el-input ref="name" v-model="form.model.name" clearable />
        </el-form-item>
        <el-form-item label="性别：" prop="sex">
          <el-select v-model="form.model.sex">
            <el-option label="男" :value="0"></el-option>
            <el-option label="女" :value="1"></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="岗位：" prop="postId">
          <nm-post-select v-model="form.model.postId" />
        </el-form-item>
        <el-form-item label="入职日期：" prop="joinDate">
          <el-date-picker v-model="form.model.joinDate" type="date" format="yyyy 年 MM 月 dd 日" value-format="yyyy-MM-dd" placeholder="入职日期"></el-date-picker>
        </el-form-item>
      </el-col>
      <el-col :span="7">
        <el-form-item label="照片：" prop="picture">
          <picture-upload v-model="form.model.picture" />
        </el-form-item>
        <el-form-item label="性质：" prop="nature">
          <nm-enum-select v-model="form.model.nature" module-code="personnelfiles" enum-name="EmployeeNature" />
        </el-form-item>
        <el-form-item label="排序：" prop="sort">
          <el-input v-model.number="form.model.sort" clearable />
        </el-form-item>
      </el-col>
    </el-row>
    <el-divider content-position="left">账户信息</el-divider>
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
  </nm-form-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'
import PictureUpload from '../picture-upload'

const api = $api.personnelFiles.employee

export default {
  mixins: [mixins.visible],
  components: { PictureUpload },
  data() {
    return {
      form: {
        title: '新建人员',
        icon: 'add',
        width: '700px',
        action: api.add,
        model: {
          /** 姓名 */
          name: '',
          /** 性别 */
          sex: 0,
          /** 性质 */
          nature: 0,
          /** 部门编号 */
          departmentId: '',
          /** 岗位编号 */
          postId: '',
          /** 照片 */
          picture: '',
          /** 入职日期 */
          joinDate: this.$dayjs().format('YYYY-MM-DD'),
          /** 排序 */
          sort: 0,
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
          name: [{ required: true, message: '请输入姓名', trigger: 'blur' }],
          sex: [{ required: true, message: '请选择性别', trigger: 'blur' }],
          nature: [{ required: true, message: '请选择性质', trigger: 'blur' }],
          departmentId: [{ required: true, message: '请选择部门', trigger: 'blur' }],
          joinDate: [{ required: true, message: '请选择加入日期', trigger: 'blur' }],
          sort: [{ required: true, message: '请输入序号', trigger: 'blur' }],
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
      },
      on: {
        open: this.onOpen,
        reset: this.onReset,
        success: this.onSuccess
      },
      pictureUpload: {
        module: 'PersonnelFiles',
        group: 'UserPicture',
        maxSize: '500kb',
        width: '100px',
        height: '120px',
        iconSize: '3em'
      }
    }
  },
  props: {
    department: Object
  },
  methods: {
    onSuccess() {
      this.$emit('success')
    },
    onOpen() {
      this.$refs.form.reset()
    },
    onReset() {
      this.form.model.departmentId = this.department.id
      this.$refs.name.focus()
    }
  }
}
</script>
