<template>
  <nm-box class="nm-mpest-samedep" page header footer footer-align="center" no-padding>
    <template v-slot:title>
      <el-input v-model="keyword" placeholder="请输入姓名" clearable @clear="search">
        <el-button slot="append" icon="el-icon-search" @click="search"></el-button>
      </el-input>
    </template>

    <employee-list :options="options" :show-post="showPost" />

    <template v-slot:footer>
      共{{ total }}条
      <el-pagination small background layout="prev, pager, next" :total="total" :page-size="page.size" :current-page.sync="page.index" @current-change="onCurrentChange"> </el-pagination>
    </template>
  </nm-box>
</template>
<script>
import EmployeeList from './employee-list'
const { queryWithSameDepartment } = $api.personnelFiles.employee
export default {
  components: { EmployeeList },
  data() {
    return {
      page: {
        index: 1,
        size: 15
      },
      rows_: [],
      total: 0,
      keyword: ''
    }
  },
  props: {
    options: Object,
    //已选择的人员列表
    selection: Array,
    //显示岗位
    showPost: {
      type: Boolean,
      default: true
    }
  },
  methods: {
    query() {
      queryWithSameDepartment({ page: this.page, name: this.keyword }).then(data => {
        this.rows_ = data.rows.map(m => {
          m.checked = false
          return m
        })
        this.total = data.total
        this.refresh()
      })
    },
    search() {
      this.page.index = 1
      this.query()
    },
    refresh() {
      this.options.rows = this.rows_.map(m => {
        m.show = this.selection.findIndex(n => n.id === m.id) < 0
        return m
      })
    },
    onCurrentChange() {
      this.query()
    }
  },
  watch: {
    selection() {
      this.refresh()
    }
  }
}
</script>
<style lang="scss">
.nm-mpest-samedep {
  .nm-box-header-title {
    .el-input {
      top: -2px;
    }
  }

  .el-pagination {
    position: relative;
    display: inline-block;
    top: 8px;
  }
}
</style>
