<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <el-row>
      <el-col :span="20" :offset="1">
        <el-form-item label="全称：" prop="name">
          <el-input v-model="form.model.name" clearable />
        </el-form-item>
        <el-form-item label="简称：" prop="shortName">
          <el-input v-model="form.model.shortName" clearable />
        </el-form-item>
        <el-form-item label="编码：" prop="code">
          <el-input v-model="form.model.code" clearable />
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'

export default {
  mixins: [mixins.formSave],
  data() {
    return {
      title: '职位',
      actions: $api.personnelFiles.position,
      form: {
        width: '500px',
        model: {
          /** 名称 */
          name: '',
          /** 简称 */
          shortName: '',
          /** 备注 */
          code: ''
        },
        rules: {
          name: [{ required: true, message: '请输入名称' }]
        }
      }
    }
  }
}
</script>
