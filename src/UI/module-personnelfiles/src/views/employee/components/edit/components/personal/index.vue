<template>
  <nm-form-page ref="form" v-bind="form" v-on="on">
    <el-row>
      <el-col :span="12">
        <el-form-item label="出生日期：" prop="birthday">
          <el-date-picker v-model="form.model.birthday" type="date" format="yyyy-MM-dd" value-format="yyyy-MM-dd" placeholder="出生日期"></el-date-picker>
        </el-form-item>
        <el-form-item label="籍贯：" prop="native">
          <el-input v-model="form.model.native" clearable />
        </el-form-item>
        <el-form-item label="身份证号：" prop="idCard">
          <el-input v-model="form.model.idCard" clearable />
        </el-form-item>
        <el-form-item label="政治面貌：" prop="politicsStatus">
          <el-input v-model="form.model.politicsStatus" clearable />
        </el-form-item>
        <el-form-item label="学历：" prop="educationLevel">
          <nm-dict-select v-model="form.model.educationLevel" group="PersonnelFiles" code="EducationLevel" @change="onEducationLevelChange" />
        </el-form-item>
        <el-form-item label="身高：" prop="height">
          <el-input v-model.number="form.model.height" clearable>
            <template slot="append">cm</template>
          </el-input>
        </el-form-item>
      </el-col>
      <el-col :span="12">
        <el-form-item label="民族：" prop="nation">
          <el-input v-model="form.model.nation" clearable />
        </el-form-item>
        <el-form-item label="户口：" prop="registerPlace">
          <el-input v-model="form.model.registerPlace" clearable />
        </el-form-item>
        <el-form-item label="婚姻状况：" prop="maritalStatus">
          <nm-enum-select v-model="form.model.maritalStatus" module-code="personnelfiles" enum-name="MaritalStatus" />
        </el-form-item>
        <el-form-item label="健康状况：" prop="healthStatus">
          <nm-enum-select v-model="form.model.healthStatus" module-code="personnelfiles" enum-name="HealthStatus" />
        </el-form-item>
        <el-form-item label="学位：" prop="degree">
          <el-input v-model="form.model.degree" clearable />
        </el-form-item>
        <el-form-item label="体重：" prop="weight">
          <el-input v-model.number="form.model.weight" clearable>
            <template slot="append">kg</template>
          </el-input>
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-page>
</template>

<script>
import mixins from '../mixins'

const { editPersonal, updatePersonal } = $api.personnelFiles.employee

export default {
  mixins: [mixins],
  data() {
    return {
      actions: { edit: editPersonal },
      form: {
        action: updatePersonal,
        model: {
          employeeId: '',
          //出生日期
          birthday: '',
          //民族
          nation: '',
          //籍贯
          native: '',
          //户口
          registerPlace: '',
          //身份证号
          idCard: '',
          //婚姻状况
          maritalStatus: 0,
          //政治面貌
          politicsStatus: '',
          //学历
          educationLevel: '',
          //学历名称
          educationLevelName: '',
          //学位
          degree: '',
          //健康状况
          healthStatus: '',
          //身高
          height: '',
          //体重
          weight: ''
        },
        rules: {
          employeeId: [{ required: true, message: '请选择人员', trigger: 'blur' }],
          idCard: [
            {
              type: 'string',
              pattern: $const.pattern.idCard,
              message: '身份证号格式有误',
              trigger: 'blur'
            }
          ],
          height: [{ type: 'number', min: 10, max: 500, message: '身高在 10cm 到 500cm之间', trigger: 'blur' }]
        }
      }
    }
  },
  methods: {
    onEducationLevelChange(val, selection) {
      this.form.model.educationLevelName = selection.label
    }
  }
}
</script>
