export default {
  data() {
    return {
      id_: 0,
      // 备份数据，重置时使用
      model_: {},
      form: {
        header: false,
        model: {
          id: null
        },
        disabled: this.readonly,
        noFooter: this.readonly,
        loading: true
      },
      on: {
        success: this.onSuccess
      },
      actions: {}
    }
  },
  props: {
    id: Number,
    readonly: Boolean
  },
  methods: {
    refresh() {
      if (this.id !== this.id_) {
        const { form, actions } = this
        form.loading = true
        actions
          .edit(this.id)
          .then(data => {
            this.model_ = this.$_.merge({}, data)
            this.form.model = data
            form.loading = false
          })
          .catch(() => {
            form.loading = false
          })

        this.id_ = this.id
      }
    },
    reset() {
      this.form.model = this.$_.merge({}, this.model_)
    },
    onSuccess() {
      this.$emit('success')
    }
  },
  watch: {
    readonly(val) {
      this.form.disabled = val
      this.form.noFooter = val
    }
  }
}
