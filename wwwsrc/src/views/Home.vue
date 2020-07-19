<template>
  <div class="home">
    <div class="container-fluid">
      <div class="row">
<div class="col text-center">
    <h1 class="text-center mt-5">Welcome to Hell</h1>

<button type="button" class="btn btn-primary" @click="showForm=!showForm"> Make a Keep
</button>
<div class="row justify-content-center">
  <div class="col-6">


<div class="card shadow" v-if="showForm">
    <div class="row justify-content-center">
      <div class="col-10">
<form action="submit">
  <div class="row ml-3 my-1">
  <input class="form-control form-inline" type="text" placeholder="Title">
  </div>
  <div class="row ml-3 my-1">
  <input class="form-control" type="text" placeholder="Image URL">
  </div>
  <div class="row ml-3 my-1">
 <input type="text" class="form-control" placeholder="Description...">
  </div>
 
  
  <button type="button" class="btn btn-primary">Submit Keep</button>
  <button type="button" class="btn btn-danger">Cancel</button>
</form>
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
export default {
  name: "home",
  data()
  {
    return {
      showForm: false
    }
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  }
};
</script>

<style scoped>
textarea{
  height: auto;
}
</style>
