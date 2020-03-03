<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <el-row>
      <el-col :span="20" :offset="1">
        <el-form-item label="路径：">
          <el-input v-model="parent.path" disabled />
        </el-form-item>
        <el-form-item label="名称：" prop="name">
          <el-input ref="name" v-model="form.model.name" clearable />
        </el-form-item>
        <el-form-item label="排序：" prop="sort">
          <el-input v-model="form.model.sort" clearable />
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

const { add, edit, update } = $api.personnelFiles.department

export default {
  mixins: [mixins.formSave],
  data() {
    return {
      title: '部门',
      actions: {
        add,
        edit,
        update
      },
      form: {
        width: '600px',
        model: {
          parentId: '',
          /** 名称 */
          name: '',
          /** 唯一编码 */
          code: '',
          /** 负责人 */
          leader: '',
          /** 排序 */
          sort: 0
        },
        rules: {
          name: [{ required: true, message: '请输入名称' }],
          sort: [{ required: true, message: '请输入序号' }]
        }
      },
      on: {
        reset: this.onReset
      }
    }
  },
  props: ['parent', 'total'],
  methods: {
    onReset() {
      this.form.model.parentId = this.parent.id
      this.form.model.sort = this.total
      this.$refs.name.focus()
    }
  }
}
</script>
