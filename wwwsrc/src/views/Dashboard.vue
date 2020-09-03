<template>
  <div class="dashboard container-fluid">
    <div class="container-fluid">
      <div class="row">
<div class="col text-center">
    <h1 class="text-center mt-5">Here are your Vaults!</h1>

<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#vaultModal" > Create a Vault
</button>
<div class="row justify-content-center">
  <div class="col-6">


<!-- <div class="card shadow">
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
  </div> -->

   <div class="modal fade" id="vaultModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLongTitle">Modal title</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body justify-content-center">
       <form @submit.prevent="addVault">
  <div class="row my-1 justify-content-center">
  <input class="form-control form-inline" type="text" placeholder="Title" v-model="newVault.name" style="width: 93%">
  </div>

  <div class="row justify-content-center my-1">
 <input type="text" class="form-control" placeholder="Description..." v-model="newVault.description" style="width: 93%">
  </div>
 
      <!-- <div class="modal-footer"> -->
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="submit" class="btn btn-primary">Post</button>
</form>
      </div>
      <!-- </div> -->
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
        <div class="row">
<div class="col text-center">
    <h1 class="text-center mt-5">Here are your Keeps</h1>



  </div>
</div>
<div class="row mt-3">
  <div class="col-12">

<div class="card-columns">

    <keep v-for="keep in keeps" :key="keep.id" :keepData="keep"/>
  </div>
</div>
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
import Keep from "@/components/keepComponent.vue"
export default {
   name: "Dashboard",
  data()
  {
    return {
      newVault: {
        name: "",
        description:""
      }
    }
  },
  mounted() {
    this.$store.dispatch("getUserVaults");
    this.$store.dispatch("getUserKeeps");
  },
  computed: {
      user() {
      return this.$store.state.user;
    },
    vaults() {
      return this.$store.state.userVaults;
    },
     keeps() {
      return this.$store.state.userKeeps;
     }
  },
  methods: {
       logout() {
      this.$store.dispatch("logout");
    },
    addVault(){
      this.$store.dispatch("addVault", this.newVault);
      newVault = {};
      $("#vaultModal").modal("hide");
    }
  },
  components: {
   Vault,
   Keep
  }
}
</script>

<style scoped>
.card-columns{ column-count: 4; }
</style>