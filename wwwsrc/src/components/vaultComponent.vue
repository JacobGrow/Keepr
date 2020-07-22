<template>
  <div class="vault">
    <div class="card shadow card-size">
      <h5>{{vaultData.name}}</h5>
      <h5>{{vaultData.description}}</h5>
      <button class="btn btn-danger" @click="deleteVault(vaultData.id)">DELORT</button>
    </div>
  </div>
</template>


<script>
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
  }
}
</script>
<style scoped>

</style>