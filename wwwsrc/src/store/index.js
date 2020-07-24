import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    userKeeps: [],
    activeKeep: {},
    userVaults: [],
    vaultKeeps: [],
    activeVault: {},
    activeVaultKeep: {}
  },
  mutations: {
    setKeeps(state, keeps) {
      state.publicKeeps = keeps;
    },
    setUserKeeps(state, keeps){
      state.userKeeps = keeps;
    },
    setUserVaults(state, vaults){
      state.userVaults = vaults;
    },
    setActiveKeep(state, keep){
      state.activeKeep = keep;
    },
    setVaultKeeps(state, vaultKeeps){
      state.vaultKeeps = vaultKeeps
    },
    setActiveVault(state, vault){
      state.activeVault = vault;
    },
    setActiveVaultKeep(state, vaultKeep){
      state.activeVault = vaultKeep;
    }
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    async getKeeps({ commit, dispatch }) {
       try {
         let res = await api.get("keeps");
         commit("setKeeps", res.data)
       } catch (error){
         console.error(error)
    }
    },

    async getUserKeeps ({commit, dispatch}) {
      try {
        let res = await api.get("keeps/user" )
        commit("setUserKeeps", res.data)
      } catch (error) {
        console.error(error)
      }
    },    

    async getActiveKeep ({ commit }, keepId){
      try{
      let res = await api.get("keeps/" + keepId);
      console.log("getActiveKeep:", res.data)
      commit("setActiveKeep", res.data)
      }
      catch (error){
        console.error(error)
      }
    },

    async getKeepsByVault({ commit }, vaultId) {
      try {
       
        let res = await api.get('vaults/' + vaultId + '/keeps');
        commit("setVaultKeeps", res.data)
      } catch (error) {
        console.error(error)
      }
     },
     async removeVaultKeep({dispatch}, vaultKeepId){
       try {
         let res = await api.delete("/vaultkeeps/" + vaultKeepId)
        //  dispatch("getKeepsByVault")
       } catch (error) {
         console.error(error)
       }
     },

     async getActiveVaultKeep({ commit }, vaultKeepId){
       try {
         let res = await api.get("vaultsKeeps/" + vaultKeepId);
         commit("setActiveVaultKeep", res.data)
       } catch (error) {
         
       }
     },

    async addKeep({ dispatch }, newKeep) {
      try {
        let res = await api.post("keeps", newKeep)
        dispatch('getKeeps')
      } catch (error) {
        console.error(error)
      }
    },
    async deleteKeep({dispatch}, id){
      try {
        let res = await api.delete("keeps/" + id)
        dispatch("getKeeps")
        console.log("DELORTED")
      } catch (error) {
        console.error(error)
      }
    },

    async addKeepToVault({ commit, dispatch }, newVaultKeep) {
      try {
          let res = await api.post('vaultkeeps', newVaultKeep)
          // dispatch("getKeepsByVault")
      } catch (error) {
          console.error(error)
      }
    },


    async getUserVaults({ commit, dispatch }){
      try {
        let res = await api.get("vaults/user");
        commit("setUserVaults", res.data)
      } catch (error) {
        console.error(error)
      }
    },

    async  addVault({ dispatch }, newVault) {
      try {
        let res = await api.post("vaults", newVault)
        dispatch('getUserVaults')
      } catch (error) {
        console.error(error)
      }
  },
  async deleteVault({dispatch}, id){
    try {
      let res = await api.delete("vaults/" + id)
      dispatch("getUserVaults")
      console.log("DELORTED")
    } catch (error) {
      console.error(error)
    }
  },
  async getActiveVault ({ commit, dispatch }, vaultId){
    try{
    let res = await api.get("vaults/" + vaultId);
    commit("setActiveVault", res.data)
    }
    catch (error){
      console.error(error)
    }
  },
}
})
