<template>
  <div class="myKeeps container-fluid">
    <div class="container-fluid">
      <div class="row">
<div class="col text-center">
    <h1 class="text-center mt-5">Keeps </h1>



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

</template>

<script>
import Keep from "@/components/keepComponent.vue"
export default {
   name: "MyKeeps",
  data()
  {
    return {

    }
  },
  mounted() {
    this.$store.dispatch("getUserKeeps");
  },
  computed: {
      user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.userKeeps;
    }
  },
  methods: {
       logout() {
      this.$store.dispatch("logout");
    },
  },
  components: {
   Keep
  }
};
</script>

<style></style>
