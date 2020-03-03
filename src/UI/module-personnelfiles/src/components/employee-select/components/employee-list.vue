<template>
  <ul class="nm-mpest-employee-list">
    <li v-for="item in options.rows" :key="item.id" v-show="item.show" :class="['nm-mpest-employee-item', item.checked ? 'checked' : '']" @click="onClick(item)">
      <div :class="['nm-mpest-employee-avatar', item.sex === 0 ? 'boy' : 'girl']">
        <nm-icon :name="item.sex === 0 ? 'boy' : 'girl'" />
      </div>
      <div class="nm-mpest-employee-label">
        <div class="employee-name">
          {{ item.name }}<span class="post-name" v-if="showPost && item.postName">{{ item.postName }}</span>
        </div>
        <div class="department-path">{{ item.departmentPath }}</div>
      </div>
      <i class="el-icon-check"></i>
    </li>
  </ul>
</template>
<script>
export default {
  props: {
    options: Object,
    //显示岗位
    showPost: {
      type: Boolean,
      default: true
    }
  },
  methods: {
    onClick(item) {
      if (item.checked) {
        const index = this.options.selection.findIndex(m => m.id === item.id)
        this.options.selection.splice(index, 1)
        item.checked = false
      } else {
        this.options.selection.push(item)
        item.checked = true
      }
    }
  }
}
</script>
<style lang="scss">
.nm-mpest-employee-list {
  .nm-mpest-employee-item {
    position: relative;
    padding: 6px 0 6px 50px;
    border-bottom: 1px solid #f2f6fc;
    cursor: pointer;

    .el-icon-check {
      display: none;
      position: absolute;
      top: 0;
      right: 1px;
      font-size: 11px;
      color: #fff;
      width: 0;
      height: 0;
      border-top: 25px solid #409eff;
      border-left: 25px solid transparent;

      &::before {
        position: absolute;
        top: -23px;
        left: -15px;
        font-size: 15px;
      }
    }

    &:hover,
    &.checked {
      background-color: #eaf8fe;
    }

    &.checked {
      .el-icon-check {
        display: inline-block;
      }
    }

    .nm-mpest-employee-avatar {
      position: absolute;
      top: 0;
      left: 2px;
      font-size: 43px;

      &.boy {
        color: #409eff;
      }
      &.girl {
        color: #e6a23c;
      }
    }

    .nm-mpest-employee-label {
      .employee-name {
        margin-bottom: 7px;
        font-size: 12px;
      }

      .post-name {
        padding-left: 8px;
        font-size: 10px;
        color: #909399;
      }

      .department-path {
        font-size: 10px;
        color: #909399;
      }
    }
  }
}
</style>
