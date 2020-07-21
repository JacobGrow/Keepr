<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-red">
    <router-link class="navbar-brand" :to="{ name: 'home' }">
      <h1 class="d-flex mt-3">
      K
      </h1>
      </router-link>
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav mr-auto">
        <li class="nav-item" :class="{ active: $route.name == 'home' }">
          <router-link :to="{ name: 'home' }" class="nav-link mt-3 ml-3"
            >Home</router-link
          >
        </li>
        <li
          class="nav-item"
          v-if="$auth.isAuthenticated"
          :class="{ active: $route.name == 'dashboard' }"
        >
          <router-link class="nav-link mt-3 ml-3" :to="{ name: 'dashboard' }"
            >My Vaults</router-link
          >
        </li>
      </ul>
      <span class="navbar-text">
        <button
          class="btn btn-primary"
          @click="login"
          v-if="!$auth.isAuthenticated"
        >
          Login
        </button>
        <button class="btn btn-danger" @click="logout" v-else>logout</button>
      </span>
    </div>
  </nav>
</template>

<script>
import axios from "axios";

let _api = axios.create({
  baseURL: "https://localhost:5001",
  withCredentials: true
});
export default {
  name: "Navbar",
  methods: {
    async login() {
      await this.$auth.loginWithPopup();
      this.$store.dispatch("setBearer", this.$auth.bearer);
      console.log("this.$auth.user: ");
      console.log(this.$auth.user);
    },
    async logout() {
      this.$store.dispatch("resetBearer");
      await this.$auth.logout({ returnTo: window.location.origin });
    }
  }
};
</script>

<style>
.bg-red{
  background-color: #ac5061;
}

nav {
  font-family: 'Old Standard TT', serif;
  font-size: large;
}


</style>
