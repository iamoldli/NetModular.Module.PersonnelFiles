<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <el-row>
      <el-col :span="20" :offset="1">
        <el-form-item label="姓名：" prop="name">
          <el-input ref="name" v-model="form.model.name" clearable />
        </el-form-item>
        <el-form-item label="关系：" prop="relation">
          <el-input v-model="form.model.relation" clearable />
        </el-form-item>
        <el-form-item label="工作单位：" prop="unit">
          <el-input v-model="form.model.unit" clearable />
        </el-form-item>
        <el-form-item label="职务：" prop="post">
          <el-input v-model="form.model.post" clearable />
        </el-form-item>
        <el-form-item label="联系电话：" prop="phone">
          <el-input v-model="form.model.phone" clearable />
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'

const { familyAdd, familyEdit, familyUpdate } = $api.personnelFiles.employee

export default {
  mixins: [mixins.formSave],
  data() {
    return {
      title: '家庭情况',
      actions: {
        add: familyAdd,
        edit: familyEdit,
        update: familyUpdate
      },
      form: {
        width: '600px',
        model: {
          employeeId: '',
          /** 姓名 */
          name: '',
          /** 关系 */
          relation: '',
          /** 工作单位 */
          unit: '',
          /** 职务 */
          post: '',
          /** 联系电话 */
          phone: ''
        },
        rules: {
          employeeId: [{ required: true, message: '请选择人员', trigger: 'blur' }],
          name: [{ required: true, message: '请输入姓名' }],
          relation: [{ required: true, message: '请填写关系' }]
        }
      },
      on: {
        reset: this.onReset
      }
    }
  },
  props: {
    employeeId: Number
  },
  methods: {
    onReset() {
      this.form.model.employeeId = this.employeeId
      this.$refs.name.focus()
    }
  }
}
</script>
