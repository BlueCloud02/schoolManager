import Vue from 'vue'
import Router from 'vue-router'
import Hello from '@/components/Hello'
import AssociationsList from '@/components/AssociationsList'
import AssociationEdit from '@/components/AssociationEdit'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Hello',
      component: Hello
    },
    {
      path: '/associations',
      name: 'AssociationsList',
      component: AssociationsList
    },
    {
      path: '/association/edit/:id?',
      name: 'AssociationEdit',
      component: AssociationEdit
    }
  ]
})
