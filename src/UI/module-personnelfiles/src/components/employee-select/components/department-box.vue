<template>
  <nm-box class="nm-mpest-department" page header :loading="loading">
    <template v-slot:title>
      <el-input v-model="keyword" placeholder="请输入关键字" clearable suffix-icon="el-icon-search"> </el-input>
    </template>

    <el-tree ref="tree" v-bind="tree" @check="onCheck">
      <span slot-scope="{ data }">
        <nm-icon v-if="data.item.type === 0" name="attachment" />
        <nm-icon v-else-if="data.item.type === 1 && data.item.sex === 0" name="boy" class="nm-mpest-department-icon boy" />
        <nm-icon v-else-if="data.item.type === 1 && data.item.sex === 1" name="girl" class="nm-mpest-department-icon girl" />
        <span :class="data.item.type === 1 ? 'nm-mpest-department-name' : ''"
          >{{ data.label }}<span class="nm-size-10 nm-text-info" v-if="showPost && data.item.type === 1 && data.item.postName"> {{ data.item.postName }}</span></span
        >
      </span>
    </el-tree>
  </nm-box>
</template>
<script>
const { getTree } = $api.personnelFiles.employee

export default {
  data() {
    return {
      tree: {
        data: [],
        nodeKey: 'id',
        highlightCurrent: true,
        showCheckbox: true,
        props: { children: 'children', label: 'label' },
        currentNodeKey: 0,
        defaultExpandedKeys: [0],
        defaultCheckedKeys: [],
        filterNodeMethod: this.filter
      },
      keyword: '',
      loading: false
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
      this.loading = true
      getTree().then(data => {
        this.tree.data = [data]
        this.options.selection = []
        this.refresh()
        this.loading = false
      })
    },
    search() {
      this.query()
    },
    refresh() {
      let root = this.tree.data[0]
      if (!root) return

      let checkedKeys = []
      this.refreshChildren(root.children, checkedKeys)
      this.$refs.tree.setCheckedKeys(checkedKeys)
    },
    refreshChildren(children, checkedKeys) {
      if (!children) return

      children.forEach(m => {
        let item = m.item
        if (item.type === 1) {
          if (this.selection.findIndex(n => n.id == item.sourceId) > -1) {
            m.disabled = true
            checkedKeys.push(m.id)
          } else {
            m.disabled = false
          }
        } else {
          this.refreshChildren(m.children, checkedKeys)
        }
      })
    },
    onCheck(data, { checkedNodes }) {
      this.options.selection = []
      checkedNodes.forEach(m => {
        if (m.item.type === 1 && !m.disabled) {
          const { sourceId, name, sex, postName, departmentPath } = m.item
          this.options.selection.push({
            id: parseInt(sourceId),
            name,
            sex,
            postName,
            departmentPath
          })
        }
      })
    },
    filter(value, data) {
      if (!value) return true
      return data.label.indexOf(value) !== -1
    }
  },
  watch: {
    selection() {
      this.refresh()
    },
    keyword(val) {
      this.$refs.tree.filter(val)
    }
  }
}
</script>
<style lang="scss">
.nm-mpest-department {
  .nm-box-header-title {
    .el-input {
      top: -2px;
    }
  }

  .el-tree-node__content {
    font-size: 12px;
  }

  .nm-icon {
    margin-right: 5px;
  }
  &-icon {
    margin-left: -6px;
    font-size: 30px;

    &.boy {
      color: #409eff;
    }
    &.girl {
      color: #e6a23c;
    }
  }

  &-name {
    position: relative;
    top: -6px;
  }
}
</style>
