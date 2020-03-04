<template>
  <div class="nm-mpf-position-select">
    <el-input placeholder="请选择职位" :value="name" :clearable="clearable" readonly>
      <i class="el-icon-search el-input__icon" style="cursor: pointer;" slot="suffix" @click="onInputClick"> </i>
    </el-input>
    <nm-list-dialog class="nm-mpf-position-select-dialog" v-bind="dialog" :visible.sync="showDialog" @opened="onOpened">
      <span slot="title"> 选择职位<label class="nm-p-l-7 nm-size-12 nm-text-warning">(双击选择)</label> </span>
      <nm-list ref="list" v-bind="list" @row-dblclick="onRowDblclick">
        <template v-slot:querybar>
          <el-form-item label="名称：" prop="name">
            <el-input v-model="list.model.name" placeholder="请输入名称或简称" clearable />
          </el-form-item>
          <el-form-item label="编码：" prop="code">
            <el-input v-model="list.model.code" clearable />
          </el-form-item>
        </template>
      </nm-list>
    </nm-list-dialog>
  </div>
</template>
<script>
import cols from '../../index/cols'

const api = $api.personnelFiles.position

export default {
  data() {
    return {
      value_: '',
      name: '',
      dialog: {
        icon: 'position',
        width: '700px',
        height: '550px',
        draggable: true
      },
      list: {
        noHeader: true,
        noOperation: true,
        cols,
        action: api.query,
        model: {
          /** 名称 */
          name: '',
          /** 编码 */
          code: ''
        }
      },
      showDialog: false
    }
  },
  props: {
    value: [Number, String],
    clearable: Boolean
  },
  methods: {
    reset() {
      this.value_ = ''
      this.name = ''
    },
    onOpened() {
      this.$refs.list.refresh()
    },
    onInputClick() {
      this.showDialog = true
    },
    onRowDblclick(row) {
      this.value_ = row.id
      this.$emit('input', row.id)
      this.name = row.name
      this.showDialog = false
    }
  },
  watch: {
    value: {
      immediate: true,
      handler() {
        if (this.value_ !== this.value && !this.name) {
          api.get(this.value).then(data => {
            this.name = data.name
          })
        }
      }
    }
  }
}
</script>
<style lang="scss">
.nm-mpf-position-select-dialog {
  .el-table__row {
    cursor: pointer;
  }
}
</style>
