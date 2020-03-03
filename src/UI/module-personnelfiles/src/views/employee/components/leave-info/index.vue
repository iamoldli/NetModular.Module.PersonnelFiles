<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <el-row>
      <el-col :span="20" :offset="1">
        <el-form-item label="姓名：">
          <el-input v-model="name" disabled />
        </el-form-item>
        <el-form-item label="离职类型：" prop="type">
          <nm-dict-select v-model="form.model.type" group="PersonnelFiles" code="EmployeeLeaveType" />
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

const { getLeaveInfo } = $api.personnelFiles.employee

export default {
  mixins: [mixins.visible, mixins.formReadonly],
  data() {
    return {
      action: getLeaveInfo,
      form: {
        title: '人员离职信息',
        icon: 'edit',
        width: '450px',
        model: {
          employeeId: '',
          /** 离职类型 */
          type: '',
          /** 离职原因 */
          reason: '',
          /** 申请日期 */
          applyDate: '',
          /** 离岗日期 */
          leaveDate: ''
        }
      }
    }
  },
  props: {
    name: String
  }
}
</script>
