<template>
  <nm-dialog v-bind="dialog" @open="onOpened" :visible.sync="visible_">
    <nm-tabs :fullscreen="false">
      <el-tabs v-model="tab" type="card" @tab-click="onTabClick">
        <el-tab-pane name="base">
          <span slot="label"> <nm-icon name="entity" />基本信息 </span>
          <base-page ref="base" :id="id_" :readonly="readonly" @success="refreshList" />
        </el-tab-pane>
        <el-tab-pane name="personal" lazy>
          <span slot="label"> <nm-icon name="user" />个人信息 </span>
          <personal-page ref="personal" :id="id_" :readonly="readonly" />
        </el-tab-pane>
        <el-tab-pane name="contact" lazy>
          <span slot="label"> <nm-icon name="phone" />通讯信息 </span>
          <contact-page ref="contact" :id="id_" :readonly="readonly" />
        </el-tab-pane>
        <el-tab-pane name="family" lazy>
          <span slot="label"> <nm-icon name="family" />家庭情况 </span>
          <family-page ref="family" :id="id_" :readonly_="readonly" />
        </el-tab-pane>
        <el-tab-pane name="education" lazy>
          <span slot="label"> <nm-icon name="education" />教育背景 </span>
          <education-page ref="education" :id="id_" :readonly_="readonly" />
        </el-tab-pane>
        <el-tab-pane name="work" lazy>
          <span slot="label"> <nm-icon name="work" />工作经历 </span>
          <work-page ref="work" :id="id_" :readonly_="readonly" />
        </el-tab-pane>
        <el-tab-pane name="account" lazy>
          <span slot="label"> <nm-icon name="verifycode" />账户信息 </span>
          <account-page ref="account" :id="id_" :readonly="readonly" />
        </el-tab-pane>
      </el-tabs>
    </nm-tabs>
  </nm-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'
import BasePage from './components/base'
import PersonalPage from './components/personal'
import ContactPage from './components/contact'
import FamilyPage from './components/family'
import EducationPage from './components/education'
import WorkPage from './components/work'
import AccountPage from './components/account'

export default {
  mixins: [mixins.visible],
  components: { BasePage, PersonalPage, ContactPage, FamilyPage, EducationPage, WorkPage, AccountPage },
  data() {
    return {
      id_: 0,
      tab: 'base'
    }
  },
  props: {
    id: {
      type: Number,
      required: true
    },
    readonly: Boolean
  },
  computed: {
    dialog() {
      return {
        title: `${this.readonly ? '预览' : '编辑'}人员信息`,
        icon: this.readonly ? 'preview' : 'edit',
        height: '470px',
        noScrollbar: true,
        fullscreen: true
      }
    }
  },
  methods: {
    refresh() {
      this.$nextTick(() => {
        this.$refs[this.tab].refresh()
      })
    },
    refreshList() {
      this.$emit('success')
    },
    onOpened() {
      if (this.id_ !== this.id) {
        this.id_ = this.id
        this.tab = 'base'
        this.refresh()
      }
    },
    onTabClick() {
      this.refresh()
    }
  }
}
</script>
