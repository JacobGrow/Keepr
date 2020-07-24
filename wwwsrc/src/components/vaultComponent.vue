<template>
  <div class="vault">
    <div class="card shadow card-size">
      <div class="row">
        <div class="col text-center">
    <router-link :to="{name: 'vaultDetails', params: {vaultId: vaultData.id}}">
      <h5>{{vaultData.name}}</h5>
    </router-link>
        </div>
      </div>
      <button class="btn btn-danger" @click="deleteVault(vaultData.id)">DELORT</button>
    </div>
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