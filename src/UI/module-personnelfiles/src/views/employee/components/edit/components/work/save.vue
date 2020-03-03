<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <el-row>
      <el-col :span="20" :offset="1">
        <el-form-item label="公司名称：" prop="companyName">
          <el-input v-model="form.model.companyName" clearable />
        </el-form-item>
        <el-form-item label="职务：" prop="post">
          <el-input v-model="form.model.post" clearable />
        </el-form-item>
        <el-form-item label="开始日期：" prop="startDate">
          <el-date-picker v-model="form.model.startDate" type="date" format="yyyy-MM-dd" value-format="yyyy-MM-dd"></el-date-picker>
        </el-form-item>
        <el-form-item label="结束日期：" prop="endDate">
          <el-date-picker v-model="form.model.endDate" type="date" format="yyyy-MM-dd" value-format="yyyy-MM-dd"></el-date-picker>
        </el-form-item>
        <el-form-item label="联系人：" prop="contact">
          <el-input v-model="form.model.contact" clearable />
        </el-form-item>
        <el-form-item label="联系人电话：" prop="contactPhone">
          <el-input v-model="form.model.contactPhone" clearable />
        </el-form-item>
        <el-form-item label="离开原因：" prop="leaveReason">
          <el-input type="textarea" :rows="5" v-model="form.model.leaveReason" clearable />
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'

const { workAdd, workEdit, workUpdate } = $api.personnelFiles.employee

export default {
  mixins: [mixins.formSave],
  data() {
    return {
      title: '教育背景',
      actions: {
        add: workAdd,
        edit: workEdit,
        update: workUpdate
      },
      form: {
        width: '600px',
        model: {
          employeeId: '',
          companyName: '',
          post: '',
          startDate: '',
          endDate: '',
          contact: '',
          leaveReason: ''
        },
        rules: {
          employeeId: [{ required: true, message: '请选择人员', trigger: 'blur' }],
          companyName: [{ required: true, message: '请填写公司名称' }]
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
