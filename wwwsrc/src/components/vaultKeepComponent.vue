<template>
  <div class="vaultKeep">


    <div class="card shadow card-size my-5">
         <h1> {{vaultKeepData.name}} </h1>
           <img :src= "vaultKeepData.img"/>
            <h5> {{vaultKeepData.description}} </h5>
       
      <button class="btn btn-danger" @click="removeVaultKeep(vaultKeepData.vaultKeepId)">Remove</button>
         </div>
             </div>
</template>

<script>
import Keep from "@/components/keepComponent.vue"
export default {
  name: "VaultKeep",
  props: ["vaultKeepData"],
  data(){
    return {
      // vaultKeepId: 
    }
  },
  methods: {
    removeVaultKeep(vaultKeepId){
      event.stopPropagation();
      this.$store.dispatch("removeVaultKeep", vaultKeepId)
    }
    },
  mounted() {
    this.$store.dispatch("getKeepsByVault", this.$route.params.vaultId);
  },
  computed: {
    vaultkeeps() {
      return this.$store.state.vaultKeeps;
    }
  },
  components: {
    Keep
  }
}
  
</script>

<style scoped>
.card-size {
  padding: 5px;
}

img {
  width: 95%;
  height: 95%;
}
</style>