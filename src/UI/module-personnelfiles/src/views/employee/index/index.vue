<template>
  <nm-container>
    <nm-split v-model="split">
      <template v-slot:left>
        <department-tree ref="tree" @change="onTreeChange" />
      </template>
      <template v-slot:right>
        <nm-list ref="list" v-bind="list">
          <!--查询条件-->
          <template v-slot:querybar>
            <el-form-item label="姓名：" prop="name">
              <el-input v-model="list.model.name" clearable />
            </el-form-item>
            <el-form-item label="工号：" prop="jobNo">
              <el-input v-model.number="list.model.jobNo" clearable />
            </el-form-item>
          </template>

          <!--按钮-->
          <template v-slot:querybar-buttons>
            <nm-button v-bind="buttons.add" @click="add" />
          </template>

          <template v-slot:col-name="{ row }">
            <el-tooltip v-if="_hasButton(buttons.preview)" effect="dark" content="详情预览" placement="top">
              <nm-button type="text" :text="row.name" @click="preview(row)" />
            </el-tooltip>
            <span v-else>{{ row.name }}</span>
          </template>

          <template v-slot:col-statusName="{ row }">
            <el-tag v-if="row.status === 0" size="mini" type="success">在职</el-tag>
            <el-tooltip v-else-if="row.status === 1 && _hasButton(buttons.leave)" effect="dark" content="离职信息" placement="top">
              <nm-button type="text" text="离职" @click="openLeaveInfo(row)" />
            </el-tooltip>
            <el-tag v-else size="mini" type="info">离职</el-tag>
          </template>

          <!--操作列-->
          <template v-slot:col-operation="{ row }">
            <el-dropdown>
              <span class="el-dropdown-link"> 操作<i class="el-icon-arrow-down el-icon--right"></i> </span>
              <el-dropdown-menu slot="dropdown">
                <el-dropdown-item>
                  <nm-button v-if="row.status === 0" v-bind="buttons.edit" @click="edit(row)" />
                </el-dropdown-item>
                <el-dropdown-item>
                  <nm-button v-if="row.status === 0" v-bind="buttons.leave" @click="leave(row)" @success="refresh" />
                </el-dropdown-item>
                <el-dropdown-item>
                  <nm-button-delete v-bind="buttons.del" :action="removeAction" :id="row.id" @success="refresh" />
                </el-dropdown-item>
              </el-dropdown-menu>
            </el-dropdown>
          </template>
        </nm-list>
      </template>
    </nm-split>

    <!--添加-->
    <add-page :department="department" :visible.sync="dialog.add" @success="refresh" />
    <!--编辑-->
    <edit-page :id="curr.id" :readonly="readonly" :visible.sync="dialog.edit" @success="refresh" />
    <!--离职办理-->
    <leave-page :id="curr.id" :name="curr.name" :visible.sync="dialog.leave" @success="refresh" />
    <!--离职办理信息预览-->
    <leave-info-page :id="curr.id" :name="curr.name" :visible.sync="dialog.leaveInfo" />
  </nm-container>
</template>
<script>
import { mixins } from 'netmodular-ui'
import page from './page'
import cols from './cols'
import DepartmentTree from '../../department/components/tree'
import AddPage from '../components/add'
import EditPage from '../components/edit'
import LeavePage from '../components/leave'
import LeaveInfoPage from '../components/leave-info'

const api = $api.personnelFiles.employee

export default {
  mixins: [mixins.button],
  name: page.name,
  components: { DepartmentTree, AddPage, EditPage, LeavePage, LeaveInfoPage },
  data() {
    return {
      split: 0.2,
      department: {},
      curr: { id: 0, name: '' },
      list: {
        title: page.title,
        icon: 'user',
        operationWidth: '150',
        cols,
        action: api.query,
        model: {
          //部门编码
          departmentId: '',
          /** 姓名 */
          name: '',
          /** 工号 */
          jobNo: ''
        }
      },
      removeAction: api.remove,
      dialog: {
        add: false,
        edit: false,
        leave: false,
        leaveInfo: false
      },
      buttons: page.buttons,
      readonly: false
    }
  },
  methods: {
    refresh() {
      this.$refs.list.refresh()
    },
    add() {
      let departmentId = this.list.model.departmentId
      if (!departmentId || departmentId === $const.emptyGuid) {
        this._warning('请选择部门')
        return
      }
      this.dialog.add = true
    },
    edit(row) {
      this.readonly = false
      this.curr = row
      this.dialog.edit = true
    },
    preview(row) {
      this.readonly = true
      this.curr = row
      this.dialog.edit = true
    },
    leave(row) {
      this.curr = row
      this.dialog.leave = true
    },
    openLeaveInfo(row) {
      this.curr = row
      this.dialog.leaveInfo = true
    },
    onTreeChange({ id, item }) {
      this.list.model.departmentId = id
      this.department.id = id
      this.department.path = item.fullPath
      this.refresh()
    }
  }
}
</script>
