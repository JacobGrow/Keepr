<template>
  <div class="keep">
    <div class="card shadow card-size">
         <router-link :to="{name: 'keepDetails', params: {keepId: keepData.id}}">
      <img :src="keepData.img" />
         </router-link>
      <h5>{{keepData.name}}</h5>
      <h5>{{keepData.description}}</h5>
       
<div class="dropdown">
  <button class="btn btn-success dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
    Keep!
  </button>
  <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
    <vaultButton v-for="vault in vaults" :key="vault.id" :vaultButton="vault" />
  
   
  </div>
</div>
      <button class="btn btn-danger" @click="deleteKeep(keepData.id)">DELORT</button>
    </div>
  </div>
</template>

<script>
import keepDetails from "@/views/KeepDetails.vue"
import VaultButton from "@/components/vaultButton.vue"
export default {
  name: "Keep",
  props: ["keepData"],
  methods: {
    deleteKeep(keepId) {
      this.$store.dispatch("deleteKeep", keepId);
    }
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.publicKeeps;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
    mounted() {
      // this.$store.dispatch("getVaults");
    },
  components: {
    VaultButton
  }
};
</script>

<style scoped>
.card-size {
  padding: 5px;
}

img {
  width: 100%;
  height: 100%;
}
</style>