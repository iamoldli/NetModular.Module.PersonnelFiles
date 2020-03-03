<template>
  <nm-container>
    <nm-form-page ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
      <el-divider content-position="left">人员选择器</el-divider>
      <el-row>
        <el-col :span="20" :offset="1">
          <el-form-item label="参与人员：" prop="users">
            <nm-employee-select v-model="form.model.users" />
          </el-form-item>
          <el-form-item label="限制人数：" prop="users1">
            <nm-employee-select v-model="form.model.users1" :limit="3" />
          </el-form-item>
          <el-form-item label="禁用：" prop="users2">
            <nm-employee-select v-model="form.model.users2" disabled />
          </el-form-item>
          <el-form-item label="点击事件：" prop="users3">
            <nm-employee-select v-model="form.model.users3" @tag-click="onTagClick" />
          </el-form-item>
        </el-col>
      </el-row>
    </nm-form-page>
  </nm-container>
</template>
<script>
export default {
  data() {
    return {
      form: {
        title: '组件演示Demo',
        icon: 'edit',
        model: {
          users: [],
          users1: [],
          users2: [],
          users3: [1, 2, 3]
        },
        rules: {}
      }
    }
  },
  methods: {
    onTagClick(id, item) {
      this.$alert(`您点击了《${item.name}》，Id为${id}`, '人员点击事件', {
        confirmButtonText: '确定'
      })
    }
  }
}
</script>
