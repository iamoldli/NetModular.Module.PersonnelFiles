<template>
  <nm-list ref="list" v-bind="list">
    <!--查询条件-->
    <template v-slot:querybar>
      <el-form-item label="名称：" prop="name">
        <el-input v-model="list.model.name" clearable />
      </el-form-item>
      <el-form-item label="编码：" prop="code">
        <el-input v-model="list.model.code" clearable />
      </el-form-item>
    </template>

    <!--按钮-->
    <template v-slot:querybar-buttons="{ total }">
      <nm-button v-bind="buttons.add" @click="add(total)" />
    </template>

    <template v-slot:col-leaderName="{ row }">
      {{ row.leaderName || '-' }}
    </template>

    <!--操作列-->
    <template v-slot:col-operation="{ row }">
      <nm-button v-bind="buttons.edit" @click="edit(row)" />
      <nm-button-delete v-bind="buttons.del" :action="removeAction" :id="row.id" @success="onRemoveSuccess(row.id)" />
    </template>

    <!--保存页-->
    <save-page :id="curr.id" :total="total" :parent="parent" :visible.sync="dialog.save" @success="onSaveSuccess" />
  </nm-list>
</template>
<script>
import { mixins } from 'netmodular-ui'
import page from '../../index/page'
import cols from './cols'
import SavePage from '../save'

const { query, remove } = $api.personnelFiles.department
export default {
  mixins: [mixins.list],
  components: { SavePage },
  data() {
    return {
      list: {
        title: '部门列表',
        queryOnCreated: false,
        cols,
        action: query,
        model: {
          parentId: '',
          /** 名称 */
          name: '',
          /**编码 */
          code: ''
        }
      },
      removeAction: remove,
      buttons: page.buttons
    }
  },
  props: ['parent'],
  methods: {
    refresh() {
      this.$nextTick(() => {
        this.list.model.parentId = this.parent.id
        this.$refs.list.refresh()
      })
    },
    onSaveSuccess(model, data, isAdd) {
      if (isAdd) {
        model.id = data.id
      }
      this.$emit('save-success', model, data, isAdd)
    },
    onRemoveSuccess(id) {
      this.$emit('remove-success', id)
    }
  }
}
</script>
