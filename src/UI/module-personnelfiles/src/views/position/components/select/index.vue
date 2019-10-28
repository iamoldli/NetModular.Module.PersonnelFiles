<script>
import { mixins } from 'netmodular-ui'

const api = $api.personnelFiles.position

export default {
  mixins: [mixins.select],
  data() {
    return {
      action: this.query
    }
  },
  props: {
    departmentId: {
      type: String,
      required: true
    }
  },
  methods: {
    query() {
      if (this.departmentId) {
        return api.select(this.departmentId)
      } else {
        return new Promise(resolve => {
          resolve([])
        })
      }
    }
  },
  watch: {
    departmentId() {
      this.refresh()
    }
  }
}
</script>
