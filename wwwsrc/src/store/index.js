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
    vaults: []
  },
  mutations: {
    setKeeps(state, keeps) {
      state.publicKeeps = keeps;
    },
    setUserKeeps(state, keeps){
      state.userKeeps = keeps;
    },
    setVaults(state, vaults){
      state.vaults = vaults;
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
    async  addKeep({ dispatch }, newKeep) {
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

    async getVaults({ commit, dispatch }){
      try {
        let res = await api.get("vaults");
        commit("setVaults", res.data)
      } catch (error) {
        console.error(error)
      }
    },

    async  addVault({ dispatch }, newVault) {
      try {
        let res = await api.post("vaults", newVault)
        dispatch('getVaults')
      } catch (error) {
        console.error(error)
      }
  },
  async deleteVault({dispatch}, id){
    try {
      let res = await api.delete("vaults/" + id)
      dispatch("getVaults")
      console.log("DELORTED")
    } catch (error) {
      console.error(error)
    }
  }
}
})
