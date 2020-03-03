<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <el-row>
      <el-col :span="20" :offset="1">
        <el-form-item label="姓名：">
          <el-input v-model="name" disabled />
        </el-form-item>
        <el-form-item label="离职类型：" prop="type">
          <nm-dict-select group="PersonnelFiles" code="EmployeeLeaveType" @change="onTypeChange" />
        </el-form-item>
        <el-form-item label="申请日期：" prop="applyDate">
          <el-date-picker v-model="form.model.applyDate" type="date" format="yyyy 年 MM 月 dd 日" value-format="yyyy-MM-dd"></el-date-picker>
        </el-form-item>
        <el-form-item label="离岗日期：" prop="leaveDate">
          <el-date-picker v-model="form.model.leaveDate" type="date" format="yyyy 年 MM 月 dd 日" value-format="yyyy-MM-dd"></el-date-picker>
        </el-form-item>
        <el-form-item label="离职原因：" prop="reason">
          <el-input type="textarea" v-model="form.model.reason" clearable />
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'

const { leave } = $api.personnelFiles.employee

export default {
  mixins: [mixins.visible],
  data() {
    let today = this.$dayjs().format('YYYY-MM-DD')

    return {
      form: {
        title: '人员离职办理',
        icon: 'edit',
        width: '450px',
        action: leave,
        model: {
          employeeId: '',
          /** 离职类型 */
          type: 1,
          /** 离职原因 */
          reason: '',
          /** 申请日期 */
          applyDate: today,
          /** 离岗日期 */
          leaveDate: today
        },
        rules: {
          employeeId: [{ required: true, message: '请选择人员' }],
          type: [{ required: true, message: '请选择离职类型' }],
          applyDate: [{ required: true, message: '请选择申请日期' }],
          leaveDate: [{ required: true, message: '请选择离岗日期' }]
        }
      },
      on: {
        open: this.onOpen,
        reset: this.onReset,
        success: this.onSuccess
      }
    }
  },
  props: {
    id: {
      type: Number,
      required: true
    },
    name: String
  },
  methods: {
    onOpen() {
      this.$refs.form.reset()
    },
    onReset() {
      this.form.model.employeeId = this.id
    },
    onSuccess() {
      this.$emit('success')
    },
    onTypeChange(val) {
      this.form.model.type = val
    }
  }
}
</script>
