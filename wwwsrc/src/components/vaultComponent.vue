<template>
  <div class="vault">
    <router-link :to="{name: 'vaultDetails', params: {vaultId: vaultData.id}}">
    <div class="card shadow card-size">
      <h5>{{vaultData.name}}</h5>
      <button class="btn btn-danger" @click="deleteVault(vaultData.id)">DELORT</button>
    </div>
    </router-link>
  </div>
</template>


<script>
import vaultDetails from "@/views/VaultDetails.vue"
export default {
   name: "Vault",
  props: ["vaultData"],
  methods: {
    deleteVault(vaultId) {
      this.$store.dispatch("deleteVault", vaultId);
    }
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  components: {
  }
}
</script>
<style scoped>

</style>