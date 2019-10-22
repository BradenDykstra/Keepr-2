import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/vaults',
      name: 'vaults',
      component: function () {
        // @ts-ignore
        return import(/* webpackChunkName: "vaults" */ './views/MyVaults.vue')
      }
    },
    {
      path: '/vault/:id',
      name: 'vault',
      component: function () {
        // @ts-ignore
        return import(/* webpackChunkName: "vault" */ './views/OneVault.vue')
      }
    },
    {
      path: '/myKeeps',
      name: 'myKeeps',
      component: function () {
        // @ts-ignore
        return import(/* webpackChunkName: "myKeeps" */ './views/MyKeeps.vue')
      }
    }
  ]
})
