<template>
  <nm-form-page v-bind="form">
    <el-row :gutter="20">
      <el-col :span="10" :offset="1">
        <el-form-item label="公司单位名称：" prop="companyName">
          <el-input v-model="form.model.companyName" />
        </el-form-item>
      </el-col>
      <el-col :span="10">
        <el-form-item label="公司单位地址：" prop="companyAddress">
          <el-input v-model="form.model.companyAddress" />
        </el-form-item>
      </el-col>
      <el-col :span="10" :offset="1">
        <el-form-item label="公司单位联系人：" prop="companyContact">
          <el-input v-model="form.model.companyContact" />
        </el-form-item>
      </el-col>
      <el-col :span="10">
        <el-form-item label="公司单位电话：" prop="companyPhone">
          <el-input v-model="form.model.companyPhone" />
        </el-form-item>
      </el-col>
      <el-col :span="10" :offset="1">
        <el-form-item label="公司单位传真：" prop="companyFax">
          <el-input v-model="form.model.companyFax" />
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-page>
</template>
<script>
import module from '../../module'
const { edit, update } = $api.admin.config
export default {
  data() {
    return {
      code: module.code,
      type: 1,
      form: {
        header: false,
        action: this.update,
        labelWidth: '200px',
        model: {
          companyName: '',
          companyAddress: '',
          companyContact: '',
          companyPhone: '',
          companyFax: ''
        }
      }
    }
  },
  methods: {
    update() {
      return update({ type: this.type, code: this.code, json: JSON.stringify(this.form.model) })
    }
  },
  created() {
    edit({ type: this.type, code: this.code }).then(data => {
      this.form.model = data
    })
  }
}
</script>
