<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <el-row>
      <el-col :span="20" :offset="1">
        <el-form-item label="学校名称：" prop="schoolName">
          <el-input v-model="form.model.schoolName" clearable />
        </el-form-item>
        <el-form-item label="学历：" prop="level">
          <el-input v-model="form.model.level" clearable />
        </el-form-item>
        <el-form-item label="专业：" prop="profession">
          <el-input v-model="form.model.profession" clearable />
        </el-form-item>
        <el-form-item label="开始日期：" prop="startDate">
          <el-date-picker v-model="form.model.startDate" type="date" format="yyyy-MM-dd" value-format="yyyy-MM-dd"></el-date-picker>
        </el-form-item>
        <el-form-item label="结束日期：" prop="endDate">
          <el-date-picker v-model="form.model.endDate" type="date" format="yyyy-MM-dd" value-format="yyyy-MM-dd"></el-date-picker>
        </el-form-item>
        <el-form-item label="备注：" prop="remarks">
          <el-input type="textarea" :rows="5" v-model="form.model.remarks" clearable />
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'

const { educationAdd, educationEdit, educationUpdate } = $api.personnelFiles.employee

export default {
  mixins: [mixins.formSave],
  data() {
    return {
      title: '教育背景',
      actions: {
        add: educationAdd,
        edit: educationEdit,
        update: educationUpdate
      },
      form: {
        width: '600px',
        model: {
          employeeId: '',
          schoolName: '',
          level: '',
          profession: '',
          startDate: '',
          endDate: '',
          remarks: ''
        },
        rules: {
          employeeId: [{ required: true, message: '请选择人员', trigger: 'blur' }],
          schoolName: [{ required: true, message: '请填写学校名称' }]
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
