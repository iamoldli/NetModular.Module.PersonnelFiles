<script>
import { mixins } from 'netmodular-ui'
const { getTree } = $api.personnelFiles.department

export default {
  mixins: [mixins.treeSelect],
  data() {
    return {
      action: getTree
    }
  },
  props: {
    title: {
      type: String,
      default: '部门选择'
    },
    icon: {
      type: String,
      default: 'department'
    },
    collapseAll: {
      type: Boolean,
      default: true
    }
  }
}
</script>
