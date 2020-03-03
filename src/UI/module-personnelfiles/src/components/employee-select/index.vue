<template>
  <section :class="['nm-mpest', disabled ? 'disabled' : '']">
    <!--展示-->
    <div class="nm-mpest-input-wrapper" :style="{ maxHeight }">
      <div class="nm-mpest-input-wrapper-item" v-for="item in selection" :key="item.id" @click="onTagClick(item.id, item)">{{ item.name }}</div>
      <nm-icon name="search" class="nm-mpest-input-search" @click.native="open" />
    </div>
    <nm-dialog v-bind="dialog" :visible.sync="visible" @opened="onOpened">
      <nm-flex fix="40px">
        <template v-slot:top>
          <el-tabs class="nm-mpest-tabs" v-model="tabActive">
            <el-tab-pane label="最近" name="latest"> </el-tab-pane>
            <el-tab-pane label="同部门" name="samedep"></el-tab-pane>
            <el-tab-pane label="组织架构" name="department"></el-tab-pane>
          </el-tabs>
        </template>
        <template v-slot:bottom>
          <section class="nm-mpest-main">
            <div class="nm-mpest-main-left">
              <!--最近-->
              <latest-box ref="latest" v-show="tabActive === 'latest'" :selection="selectBox.rows" :options="tabs.latest" />
              <!--同部门-->
              <samedep-box ref="samedep" v-show="tabActive === 'samedep'" :selection="selectBox.rows" :options="tabs.samedep" />
              <!--组织机构-->
              <department-box ref="department" v-show="tabActive === 'department'" :selection="selectBox.rows" :options="tabs.department" />
            </div>
            <div class="nm-mpest-main-center">
              <nm-button type="primary" icon="angle-right" circle :disabled="disabledAdd" @click="add" />
              <nm-button type="primary" icon="angle-left" circle :disabled="disabledRemove" @click="remove" />
              <nm-button type="primary" icon="angle-double-right" circle :disabled="disabledAddAll" @click="addAll" />
              <nm-button type="primary" icon="angle-double-left" circle :disabled="disabledRemoveAll" @click="removeAll" />
            </div>
            <div class="nm-mpest-main-right">
              <selection-box ref="selection" :options="selectBox" />
            </div>
          </section>
        </template>
      </nm-flex>
      <template v-slot:footer>
        <nm-button type="success" text="确认" @click="save" />
        <nm-button type="warning" text="重置" @click="reset" />
        <nm-button type="info" text="关闭" @click="close" />
      </template>
    </nm-dialog>
  </section>
</template>
<script>
import LatestBox from './components/latest-box'
import SamedepBox from './components/samedep-box'
import DepartmentBox from './components/department-box'
import SelectionBox from './components/selection-box'

const { saveLatestSelect, getBaseInfoList } = $api.personnelFiles.employee

export default {
  components: { LatestBox, SamedepBox, DepartmentBox, SelectionBox },
  data() {
    return {
      visible: false,
      selection: [],
      dialog: {
        header: true,
        footer: true,
        title: '人员选择',
        icon: 'user',
        width: '700px',
        height: '550px',
        noScrollbar: true
      },
      tabActive: 'latest',
      tabs: {
        latest: {
          rows: [],
          selection: []
        },
        samedep: {
          rows: [],
          selection: []
        },
        department: {
          selection: []
        }
      },
      selectBox: {
        rows: [],
        selection: []
      }
    }
  },
  props: {
    value: Array,
    placeholder: String,
    disabled: Boolean,
    //是否显示岗位
    showPost: {
      type: Boolean,
      default: true
    },
    //组件最大高度，超出显示滚动条
    maxHeight: {
      type: String,
      default: '120px'
    },
    //选择数量限制，0表示不限制
    limit: {
      type: Number,
      default: 0
    }
  },
  computed: {
    disabledAdd() {
      return this.tabs[this.tabActive].selection.length < 1
    },
    disabledRemove() {
      return this.selectBox.selection.length < 1
    },
    disabledAddAll() {
      if (this.tabActive !== 'department') {
        return this.tabs[this.tabActive].rows.every(m => !m.show)
      }
      return true
    },
    disabledRemoveAll() {
      return this.selectBox.rows.length < 1
    }
  },
  methods: {
    open() {
      if (this.disabled) return

      this.visible = !this.visible
      this.$emit('open')
    },
    close() {
      this.visible = false
      this.$emit('close')
    },
    add() {
      this.tabs[this.tabActive].selection.map(m => {
        m.show = false
        m.checked = false
        let n = Object.assign({}, m)
        n.show = true
        this.selectBox.rows.push(n)
      })
      this.tabs[this.tabActive].selection = []
    },
    remove() {
      this.selectBox.selection.map(m => {
        let index = this.selectBox.rows.findIndex(n => n.id === m.id)
        this.selectBox.rows.splice(index, 1)
      })
      this.selectBox.selection = []
    },
    addAll() {
      this.tabs[this.tabActive].rows.map(m => {
        if (m.show) {
          m.show = false
          m.checked = false
          let n = Object.assign({}, m)
          n.show = true
          this.selectBox.rows.push(n)
        }
      })
    },
    removeAll() {
      this.selectBox.rows = []
      this.selectBox.selection = []
    },
    save() {
      let ids = []
      if (this.selectBox.rows.length > 0) {
        ids = this.selectBox.rows.map(m => m.id)
        saveLatestSelect(ids)
      }
      if (this.limit && this.limit > 0 && ids.length > this.limit) {
        this._warning(`人员选择最多不能超过${this.limit}位`)
        return
      }
      this.visible = false
      this.$emit('input', ids)
      this.$emit('change', ids, this.selectBox.rows)
    },
    reset() {
      this.refreshBaseInfo()
      this.$emit('reset')
    },
    //刷新基本信息
    refreshBaseInfo() {
      const { value } = this
      this.selection = []
      if (value && value.length > 0) {
        getBaseInfoList(value).then(data => {
          this.selection = data

          //清除右侧已选中的数据
          this.selectBox.selection = []
          //刷新右侧已选择列
          this.selectBox.rows = data.map(m => {
            return {
              id: m.id,
              name: m.name,
              sex: m.sex,
              postName: m.postName,
              departmentPath: m.departmentPath,
              checked: false,
              show: true
            }
          })

          if (this.visible) {
            //执行一次过滤
            this.$refs.selection.search()
          }
        })
      }
    },
    onOpened() {
      this.$refs.latest.search()
      this.$emit('opened')
    },
    //点击已选择人员事件
    onTagClick(id, item) {
      this.$emit('tag-click', id, item)
    }
  },
  watch: {
    tabActive(val) {
      this.$nextTick(() => {
        this.$refs[val].search()
      })
    },
    value: {
      immediate: true,
      handler() {
        this.refreshBaseInfo()
      }
    }
  }
}
</script>
<style lang="scss">
.nm-mpest {
  position: relative;
  line-height: 0;

  &-tabs {
    &.el-tabs--top {
      .el-tabs__item.is-top:nth-child(2) {
        padding-left: 20px;
      }
    }
  }

  &-input-box {
    .el-input__inner {
      border: none;
    }
  }

  &-input-wrapper {
    position: relative;
    padding: 5px 25px 5px 5px;
    width: 100%;
    height: auto;
    min-height: 32px;
    background-color: #fff;
    background-image: none;
    border-radius: 4px;
    border: 1px solid #dcdfe6;
    box-sizing: border-box;
    color: #606266;
    display: inline-block;
    font-size: inherit;
    outline: 0;
    -webkit-transition: border-color 0.2s cubic-bezier(0.645, 0.045, 0.355, 1);
    transition: border-color 0.2s cubic-bezier(0.645, 0.045, 0.355, 1);
    line-height: 1.5;
    overflow-y: auto;

    &:hover {
      border-color: #c0c4cc;
    }
    &:focus {
      border-color: #409eff;
      outline: 0;
    }

    &-item {
      display: inline-block;
      margin: 0 5px 2px 0;
      padding: 0 3px;
      transition: all 0.2s;
      font-size: 12px;
      cursor: pointer;
      box-sizing: border-box;
      color: #409eff;
      line-height: 100%;

      &:hover {
        color: #e6a23c;
      }
    }
  }

  &-input-search {
    position: absolute;
    top: 4px;
    right: 4px;
    font-size: 20px;
    cursor: pointer;
    color: #c0c4cc;
    transition: all 0.2s;

    &:hover {
      color: #606266;
    }
  }

  &-main {
    position: relative;
    height: 100%;

    &-left {
      position: absolute;
      display: inline-block;
      padding: 10px;
      box-sizing: border-box;
      width: 334px;
      height: 100%;
    }

    &-center {
      display: inline-block;
      padding: 100px 334px 0 334px;
      width: 32px;
      height: 100%;
      text-align: center;
      box-sizing: border-box;

      .nm-button {
        margin-top: 20px;
        margin-left: 0 !important;
      }
    }

    &-right {
      position: absolute;
      right: 0;
      display: inline-block;
      padding: 10px;
      box-sizing: border-box;
      width: 334px;
      height: 100%;
    }
  }

  &.disabled {
    background-color: #f5f7fa;
    border-color: #e4e7ed;
    color: #c0c4cc;
    cursor: not-allowed;

    .nm-mpest-input-search {
      cursor: not-allowed;
      &:hover {
        color: #c0c4cc;
      }
    }

    .nm-mpest-input-wrapper {
      background-color: #f5f7fa;
    }
  }
}
</style>
