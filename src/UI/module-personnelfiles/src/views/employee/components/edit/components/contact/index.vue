<template>
  <nm-form-page ref="form" v-bind="form" v-on="on">
    <el-row>
      <el-col :span="12">
        <el-form-item label="移动电话：" prop="phone">
          <el-input ref="phone" v-model="form.model.phone" clearable />
        </el-form-item>
        <el-form-item label="其它电话：" prop="otherPhone">
          <el-input v-model="form.model.otherPhone" clearable />
        </el-form-item>
        <el-form-item label="QQ：" prop="qq">
          <el-input v-model="form.model.qq" clearable />
        </el-form-item>
        <el-form-item label="钉钉：" prop="dingDing">
          <el-input v-model="form.model.dingDing" clearable />
        </el-form-item>
        <el-form-item label="电子邮件：" prop="email">
          <el-input v-model="form.model.email" clearable />
        </el-form-item>
      </el-col>
      <el-col :span="12">
        <el-form-item label="办公电话：" prop="officePhone">
          <el-input v-model="form.model.officePhone" clearable />
        </el-form-item>
        <el-form-item label="传真：" prop="fax">
          <el-input v-model="form.model.fax" clearable />
        </el-form-item>
        <el-form-item label="微信：" prop="weChat">
          <el-input v-model="form.model.weChat" clearable />
        </el-form-item>
        <el-form-item label="支付宝：" prop="alipay">
          <el-input v-model="form.model.alipay" clearable />
        </el-form-item>
      </el-col>
    </el-row>
    <el-row>
      <el-col :span="24">
        <el-form-item label="居住地址：">
          <nm-area-select v-model="form.model.area" />
        </el-form-item>
        <el-form-item label="详细地址：" prop="address">
          <el-input v-model="form.model.address" clearable />
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-page>
</template>

<script>
import mixins from '../mixins'

const { editContact, updateContact } = $api.personnelFiles.employee

export default {
  mixins: [mixins],
  data() {
    return {
      actions: { edit: editContact },
      form: {
        action: updateContact,
        model: {
          employeeId: '',
          phone: '',
          officePhone: '',
          otherPhone: '',
          fax: '',
          email: '',
          qq: '',
          weChat: '',
          dingDing: '',
          alipay: '',
          area: {},
          address: ''
        },
        rules: {
          employeeId: [{ required: true, message: '请选择人员', trigger: 'blur' }],
          phone: [
            {
              type: 'string',
              pattern: $const.pattern.phone,
              message: '手机号格式有误',
              trigger: 'blur'
            }
          ],
          email: [
            {
              type: 'email',
              message: '电子邮件格式有误',
              trigger: 'blur'
            }
          ]
        }
      }
    }
  },
  mounted() {
    this.$nextTick(() => {
      this.$refs.phone.focus()
    })
  }
}
</script>
