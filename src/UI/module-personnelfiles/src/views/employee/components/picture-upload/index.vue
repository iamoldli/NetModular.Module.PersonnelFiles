<template>
  <div class="nm-employee-picture-upload">
    <nm-attachment-upload-img v-model="value_" v-bind="options" :disabled="disabled">
      <template v-slot:text>请选择文件</template>
    </nm-attachment-upload-img>
  </div>
</template>
<script>
export default {
  data() {
    return {
      value_: '',
      options: {
        module: 'PersonnelFiles',
        group: 'EmployeePicture',
        maxSize: '500kb',
        width: '100px',
        height: '120px',
        iconSize: '3em'
      }
    }
  },
  props: {
    value: String,
    disabled: Boolean
  },
  watch: {
    value(val) {
      if (this.value_ != val) this.value_ = val
    },
    value_(val) {
      if (this.value != val) this.$emit('input', val)
    }
  }
}
</script>

<style lang="scss" scoped>
.nm-employee-picture-upload {
  height: 133px;

  .nm-attachment-upload-img {
    position: absolute;
    height: 100% !important;
    width: 100% !important;
  }
}
</style>
