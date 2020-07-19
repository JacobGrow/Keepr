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
    publicKeeps: []
  },
  mutations: {
    setKeeps(state, keeps) {
      state.publicKeeps = keeps;
    },
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    async getKeeps({ commit, dispatch }) {
      api.get('keeps')
       try {
         let res = await api.get("keeps");
         commit("setKeeps", res.data)
       } catch (error){
         console.error(error)
    }
    },
    async  addKeep({ dispatch }, keepData) {
      try {
        let res = await api.post("keeps", keepData)
        dispatch('getKeeps')
      } catch (error) {
        console.error(error)
      }
    
      
    },
  }
});
