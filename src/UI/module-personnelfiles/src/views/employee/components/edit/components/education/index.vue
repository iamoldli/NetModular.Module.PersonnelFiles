<template>
  <nm-list ref="list" v-bind="list">
    <!--按钮-->
    <template v-slot:querybar-buttons>
      <nm-button type="success" icon="add" text="添加" @click="add" />
    </template>

    <!--操作列-->
    <template v-slot:col-operation="{ row }">
      <nm-button type="text" icon="edit" text="编辑" @click="edit(row)" />
      <nm-button-delete type="text" icon="delete" text="删除" :id="row.id" :action="removeAction" @success="refresh" />
    </template>

    <save-page :id="curr.id" :employee-id="id" :visible.sync="dialog.save" @success="refresh" />
  </nm-list>
</template>
<script>
import { mixins } from 'netmodular-ui'
import SavePage from './save'

const api = $api.personnelFiles.employee

export default {
  mixins: [mixins.list],
  components: { SavePage },
  data() {
    return {
      list: {
        cols: [
          {
            name: 'schoolName',
            label: '学校名称'
          },
          {
            name: 'level',
            label: '学历'
          },
          {
            name: 'profession',
            label: '专业'
          },
          {
            name: 'startDate',
            label: '开始日期',
            format: 'YYYY-MM-DD'
          },
          {
            name: 'endDate',
            label: '结束日期',
            format: 'YYYY-MM-DD'
          },
          {
            name: 'remarks',
            label: '备注'
          }
        ],
        operationWidth: '150px',
        action: this.query,
        noReset: true,
        noHeader: true,
        noFooter: true,
        noQuerybar: this.readonly,
        noOperation: this.readonly
      },
      removeAction: api.educationDelete
    }
  },
  props: {
    id: Number,
    readonly_: Boolean
  },
  methods: {
    query() {
      return api.educationQuery(this.id)
    },
    refresh() {
      this.$refs.list.refresh()
    }
  },
  watch: {
    readonly_: {
      immediate: true,
      handler(val) {
        this.list.noQuerybar = val
        this.list.noOperation = val
      }
    }
  }
}
</script>
