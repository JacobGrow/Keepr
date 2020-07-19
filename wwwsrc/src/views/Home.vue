<template>
  <div class="home">
    <div class="container-fluid">
      <div class="row">
<div class="col text-center">
    <h1 class="text-center mt-5">Welcome to Hell</h1>

<button type="button" class="btn btn-primary" @click="showForm=!showForm"> Make a Keep
</button>
<div class="row justify-content-center"  v-if="showForm">
  <div class="col-6">


<div class="card shadow">
    <div class="row justify-content-center">
      <div class="col-10">
<form action="submit" @submit.prevent="addKeep">
  <div class="row ml-3 my-1">
  <input class="form-control form-inline" type="text" placeholder="Title" v-model="newKeep.name">
  </div>
  <div class="row ml-3 my-1">
  <input class="form-control" type="text" placeholder="Image URL" v-model="newKeep.img"> 
  </div>
  <div class="row ml-3 my-1">
 <input type="text" class="form-control" placeholder="Description..." v-model="newKeep.description">
  </div>
 
  
  <button type="submit" class="btn btn-primary">Submit Keep</button>
  <button type="button" class="btn btn-danger">Cancel</button>
</form>
      </div>
    </div>
  </div>
  </div>
</div>
  <div class="row">
    

    <keep v-for="keep in keeps" :key="keep.id" :keepData="keep"/>
   
    
  </div>
</div>
</div>
</div>
      </div>
</template>

<script>
import Keep from "@/components/keepComponent.vue"
export default {
  name: "Home",
  data()
  {
    return {
      showForm: false,
      newKeep: {}
    }
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.publicKeeps;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    addKeep(){
      this.$store.dispatch("addKeep", this.newKeep);
    }
  },
  mounted(){
    this.$store.dispatch("getKeeps");
  },
  components: {
   Keep
  }
};
</script>

