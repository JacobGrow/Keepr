<template>
  <div class="dashboard container-fluid">
    <div class="container-fluid">
      <div class="row">
<div class="col text-center">
    <h1 class="text-center mt-5">Here are your Vaults!</h1>

<button type="button" class="btn btn-primary" @click="showForm=!showForm"> Create a Vault
</button>
<div class="row justify-content-center"  v-if="showForm">
  <div class="col-6">


<div class="card shadow">
    <div class="row justify-content-center">
      <div class="col-10">
<form action="submit" @submit.prevent="addVault">
  <div class="row ml-3 my-1">
  <input class="form-control form-inline" type="text" placeholder="Title" v-model="newVault.name">
  </div>
  <div class="row ml-3 my-1">
 <input type="text" class="form-control" placeholder="Description..." v-model="newVault.description">
  </div>
 
  
  <button type="submit" class="btn btn-primary">Submit Vault</button>
  <button type="button" class="btn btn-danger">Cancel</button>
</form>
      </div>
    </div>
  </div>
  </div>
</div>
<div class="row mt-3">
  <div class="col-12">

<div class="card-columns">

    <vault v-for="vault in vaults" :key="vault.id" :vaultData="vault"/>
  </div>
</div>
</div>
    
  </div>

   
    
  
</div>
</div>
  </div>
</template>

<script>
import Vault from "@/components/vaultComponent.vue"
export default {
   name: "Dashboard",
  data()
  {
    return {
      showForm: false,
      newVault: {
        name: "",
        description:""
      }
    }
  },
  mounted() {
    this.$store.dispatch("getVaults");
  },
  computed: {
      user() {
      return this.$store.state.user;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
       logout() {
      this.$store.dispatch("logout");
    },
    addVault(){
      this.$store.dispatch("addVault", this.newVault);
      newVault = {};
    }
  },
  components: {
   Vault
  }
};
</script>

<style></style>
