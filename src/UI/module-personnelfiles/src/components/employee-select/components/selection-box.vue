<template>
  <nm-box class="nm-mpest-selection" page header no-padding :loading="loading">
    <template v-slot:title>
      <el-row>
        <el-col :span="18">
          <el-input v-model="keyword" placeholder="请输入姓名" clearable suffix-icon="el-icon-search"> </el-input>
        </el-col>
        <el-col :span="6">
          <p class="nm-size-12 nm-text-right nm-text-warning">已选{{ options.rows.length }}位</p>
        </el-col>
      </el-row>
    </template>

    <employee-list :options="options" :show-post="showPost" />
  </nm-box>
</template>
<script>
import EmployeeList from './employee-list'
export default {
  components: { EmployeeList },
  data() {
    return {
      keyword: '',
      filterTimer: null,
      loading: false
    }
  },
  props: {
    options: Object,
    //显示岗位
    showPost: {
      type: Boolean,
      default: true
    }
  },
  methods: {
    search() {
      const { keyword, options } = this
      if (this.filterTimer) {
        clearTimeout(this.filterTimer)
      }
      this.filterTimer = setTimeout(() => {
        this.loading = true
        if (keyword) {
          options.rows.map(m => {
            m.show = m.name.indexOf(keyword) > -1
          })
        } else {
          options.rows.map(m => {
            m.show = true
          })
        }
        this.loading = false
      }, 500)
    }
  },
  watch: {
    keyword: {
      immediate: true,
      handler() {
        this.search()
      }
    }
  }
}
</script>
<style lang="scss">
.nm-mpest-selection {
  .nm-box-header-title {
    .el-input {
      top: -2px;
    }
  }
}
</style>
