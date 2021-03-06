import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'
import swal from 'sweetalert2'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? 'https://localhost:5001/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    keep: {},
    vaults: [],
    vault: {}
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
      state.vaults = []
      state.vault = {}
    },
    setKeeps(state, keeps) {
      state.keeps = keeps.reverse();
    },
    setVault(state, vault) {
      state.vault = vault
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    }
  },
  actions: {
    //SECTION -- AUTH STUFF --
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
      } catch (e) {
        console.warn(e.message)
      }
    },
    //!SECTION 

    //SECTION --KEEPS--
    async getKeeps({ commit, dispatch }) {
      try {
        let keeps = await api.get('keeps');
        commit('setKeeps', keeps.data)
      } catch (e) {
        console.error(e)
      }
    },
    async getOneKeep({ commit, dispatch }, payload) {
      try {
        let keep = await api.get('keeps/' + payload.id)
        commit('setKeep', keep.data)
      } catch (e) {
        console.error(e)
      }
    },
    async addToKeep({ commit, dispatch }, payload) {
      try {
        await api.put('keeps/' + payload.id, payload)
      } catch (e) {
        console.error(e)
      }
    },
    async getKeepsByUser({ commit, dispatch }, payload) {
      try {
        let keeps = await api.get('keeps/user');
        commit('setKeeps', keeps.data)
      } catch (error) {
        console.error(error)
      }
    },
    async createKeep({ commit, dispatch }, payload) {
      try {
        await api.post('keeps', payload)
        dispatch('getKeepsByUser')
      } catch (error) {
        console.error(error)
      }
    },
    async deleteKeep({ commit, dispatch }, payload) {
      try {
        await api.delete('keeps/' + payload)
      } catch (error) {
        console.error(error)
      }
    },
    //!SECTION 

    //SECTION --VAULTS--
    async getVaults({ commit, dispatch }) {
      try {
        let vaults = await api.get('vaults')
        commit('setVaults', vaults.data)
      } catch (e) {
        console.error(e)
      }
    },
    async getVault({ commit, dispatch }, payload) {
      try {
        let vault = await api.get('vaults/' + payload)
        commit('setVault', vault.data)
        dispatch('getVaultKeeps', payload)
      } catch (error) {
        console.error(error)
      }
    },
    async createVault({ commit, dispatch }, payload) {
      try {
        await api.post('vaults', payload)
        dispatch('getVaults')
      } catch (error) {
        console.error(error)
      }
    },
    async deleteVault({ commit, dispatch }, payload) {
      try {
        await api.delete('vaults/' + payload)
      } catch (error) {
        console.error(error)
      }
    },
    //!SECTION 

    //SECTION --VAULTKEEPS--
    async getVaultKeeps({ commit, dispatch }, payload) {
      try {
        let vaultKeeps = await api.get('vaultkeeps/' + payload)
        commit('setKeeps', vaultKeeps.data)
      } catch (error) {
        console.error(error)
      }
    },
    async storeKeep({ commit, dispatch }, payload) {
      try {
        await api.post('vaultkeeps', payload)
        let keep = await api.get('keeps/' + payload.keepId)
          .then(res => {
            swal.fire({
              type: "success",
              text: "Stored in Vault!",
              toast: true,
              timer: 3000,
              showConfirmButton: false,
              position: "top-right"
            });
          });
      } catch (error) {
        console.error(error)
      }
    },
    async removeKeep({ commit, dispatch }, payload) {
      try {
        await api.put('vaultkeeps', payload)
        dispatch('getVaults')
      } catch (error) {
        console.error(error)
      }
    }
    //!SECTION 
  }
})
