<template>
  <div class="home">
    <div class="container-fluid">
      <div class="row">
<div class="col text-center">
    <h1 class="text-center mt-5">Welcome to Keepr</h1>

<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalCenter"> Make a Keep
</button>
<div class="row justify-content-center">
  <div class="col-6">


<!-- <div class="card p-3 bg-info shadow mt-2">
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
  <div class="form-check">
  <input class="form-check-input pb-0" type="checkbox" value="" id="defaultCheck1" v-model="newKeep.isPrivate">
  <label class="form-check-label" for="defaultCheck1">
    <p class="mb-0">Private?</p>
  </label>
</div>
 
  
  <button type="submit" class="btn btn-primary">Submit Keep</button>
  <button type="button" class="btn btn-danger">Cancel</button>
</form>
      </div>
    </div>
  </div> -->
  <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLongTitle">Modal title</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body justify-content-center">
       <form action="submit" @submit.prevent="addKeep">
  <div class="row my-1 justify-content-center">
  <input class="form-control form-inline" type="text" placeholder="Title" v-model="newKeep.name" style="width: 93%">
  </div>
  <div class="row justify-content-center my-1">
  <input class="form-control" type="text" placeholder="Image URL" v-model="newKeep.img" style="width: 93%"> 
  </div>
  <div class="row justify-content-center my-1">
 <input type="text" class="form-control" placeholder="Description..." v-model="newKeep.description" style="width: 93%">
  </div>
  <div class="form-check">
  <input class="form-check-input pb-0" type="checkbox" value="" id="defaultCheck1" v-model="newKeep.isPrivate">
  <label class="form-check-label" for="defaultCheck1">
    <p class="mb-0">Private?</p>
  </label>
</div>
 
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="submit" class="btn btn-primary">Post</button>
      </div>
</form>
      </div>
    </div>
  </div>
</div>
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
</template>

<script>
import Keep from "@/components/keepComponent.vue"
export default {
  name: "Home",
  data()
  {
    return {
      showForm: false,
      newKeep: {
      
      }
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
      $('#exampleModalCenter').modal('hide');
      this.$store.dispatch("addKeep", this.newKeep);
      newKeep = {};
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

<style scoped>
.card-columns{ column-count: 5; }
</style>

