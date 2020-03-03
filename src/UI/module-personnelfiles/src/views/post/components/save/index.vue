<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <el-row>
      <el-col :span="20" :offset="1">
        <el-form-item label="职位：" prop="positionId">
          <position-select v-model="form.model.positionId" clearable />
        </el-form-item>
        <el-form-item label="全称：" prop="name">
          <el-input v-model="form.model.name" clearable />
        </el-form-item>
        <el-form-item label="简称：" prop="shortName">
          <el-input v-model="form.model.shortName" clearable />
        </el-form-item>
        <el-form-item label="职责：" prop="responsibility">
          <el-input type="textarea" v-model="form.model.responsibility" clearable />
        </el-form-item>
        <el-form-item label="备注：" prop="remarks">
          <el-input type="textarea" v-model="form.model.remarks" clearable />
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'
import PositionSelect from '../../../position/components/select'

const { add, edit, update } = $api.personnelFiles.post

export default {
  mixins: [mixins.formSave],
  components: { PositionSelect },
  data() {
    return {
      title: '岗位',
      actions: { add, edit, update },
      form: {
        width: '400px',
        model: {
          /** 职位编号 */
          positionId: '',
          /** 名称 */
          name: '',
          /** 简称 */
          shortName: '',
          /** 职责 */
          responsibility: '',
          /** 备注 */
          remarks: ''
        },
        rules: {}
      }
    }
  }
}
</script>
