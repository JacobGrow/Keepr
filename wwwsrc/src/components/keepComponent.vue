<template>
  <div class="keep">
    <div class="card shadow card-size" @click="makeActive">
         <router-link :to="{name: 'keepDetails', params: {keepId: keepData.id}}">
      <img :src="keepData.img" />
         </router-link>
      <h5>{{keepData.name}}</h5>
      <p>{{keepData.description}}</p>
       

      <button class="btn btn-danger" @click="deleteKeep(keepData.id)">Delete</button>
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
    },
    makeActive(){
      this.$store.dispatch("getActiveKeep")
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
      return this.$store.state.userVaults;
    }
  },
    mounted() {
      this.$store.dispatch("getUserVaults");
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