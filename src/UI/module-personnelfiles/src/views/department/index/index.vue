<template>
  <nm-container>
    <nm-split v-model="split">
      <template v-slot:left>
        <tree-page ref="tree" @change="onTreeChange" />
      </template>
      <template v-slot:right>
        <list-page ref="list" :parent="parent" @save-success="onSaveSuccess" @remove-success="onRemoveSuccess" />
      </template>
    </nm-split>
  </nm-container>
</template>
<script>
import page from './page'
import TreePage from '../components/tree'
import ListPage from '../components/list'

export default {
  name: page.name,
  components: { TreePage, ListPage },
  data() {
    return {
      split: 0.2,
      parent: {}
    }
  },
  computed: {},
  methods: {
    refreshList() {
      this.$refs.list.refresh()
    },
    onTreeChange({ id, label, item }) {
      this.parent.id = id
      this.parent.name = label
      this.parent.path = item.fullPath
      this.refreshList()
    },
    onSaveSuccess(model, data, isAdd) {
      const nodeData = { id: model.id, label: model.name, item: model }
      if (isAdd) {
        this.$refs.tree.insert(nodeData)
      } else {
        this.$refs.tree.update(nodeData)
      }
      this.refreshList()
    },
    onRemoveSuccess(id) {
      this.$refs.tree.remove(id)
      this.refreshList()
    }
  }
}
</script>
