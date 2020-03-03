<template>
  <nm-form-page ref="form" v-bind="form" v-on="on">
    <el-row>
      <el-col :span="15">
        <el-form-item label="部门：" prop="departmentId">
          <nm-department-select v-model="form.model.departmentId" />
        </el-form-item>
        <el-form-item label="姓名：" prop="name">
          <el-input ref="name" v-model="form.model.name" clearable />
        </el-form-item>
        <el-form-item label="性别：" prop="sex">
          <el-select v-model="form.model.sex">
            <el-option label="男" :value="0"></el-option>
            <el-option label="女" :value="1"></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="岗位：" prop="postId">
          <nm-post-select v-model="form.model.postId" />
        </el-form-item>
        <el-form-item label="入职日期：" prop="joinDate">
          <el-date-picker v-model="form.model.joinDate" type="date" format="yyyy 年 MM 月 dd 日" value-format="yyyy-MM-dd" placeholder="入职日期"></el-date-picker>
        </el-form-item>
      </el-col>
      <el-col :span="7">
        <el-form-item label="照片：" prop="picture">
          <picture-upload v-model="form.model.picture" :disabled="readonly" />
        </el-form-item>
        <el-form-item label="性质：" prop="nature">
          <nm-enum-select v-model="form.model.nature" module-code="personnelfiles" enum-name="EmployeeNature" />
        </el-form-item>
        <el-form-item label="序号：" prop="sort">
          <el-input v-model="form.model.sort" clearable />
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-page>
</template>

<script>
import mixins from '../mixins'
import PictureUpload from '../../../picture-upload'

const { edit, update } = $api.personnelFiles.employee

export default {
  mixins: [mixins],
  components: { PictureUpload },
  data() {
    return {
      actions: { edit },
      form: {
        header: false,
        action: update,
        model: {
          /** 姓名 */
          name: '',
          /** 性别 */
          sex: 0,
          /** 性质 */
          nature: 0,
          /** 部门编号 */
          departmentId: '',
          /** 岗位编号 */
          postId: '',
          /** 照片 */
          picture: '',
          /** 入职日期 */
          joinDate: this.$dayjs().format('YYYY-MM-DD'),
          sort: 0
        },
        rules: {
          name: [{ required: true, message: '请输入姓名', trigger: 'blur' }],
          sex: [{ required: true, message: '请选择性别', trigger: 'blur' }],
          nature: [{ required: true, message: '请选择性质', trigger: 'blur' }],
          departmentId: [{ required: true, message: '请选择部门', trigger: 'blur' }],
          joinDate: [{ required: true, message: '请选择加入日期', trigger: 'blur' }],
          sort: [{ required: true, message: '请输入序号', trigger: 'blur' }]
        }
      }
    }
  }
}
</script>
