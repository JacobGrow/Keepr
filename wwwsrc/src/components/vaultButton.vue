<template>
  <div class="vaultButton">
    
     <button class="btn btn-primary form-control my-1" @click="addKeepToVault()">{{vaultButton.name}}</button>
    
  </div>
</template>


<script>

export default {
   name: "VaultButton",
  props: ["vaultButton"],
  data(){
    return {
      newVaultKeep: {
        vaultId: this.vaultButton.id,
        userId: this.vaultButton.userId,
        keepId: this.$store.state.activeKeep.id

      }
    }
  },
  methods: {
    addKeepToVault(){
      this.newVaultKeep = {
        vaultId: this.vaultButton.id,
        userId: this.vaultButton.userId,
        keepId: this.activeKeep.id
      }
      this.$store.dispatch("addKeepToVault", this.newVaultKeep) 
    }
  },
  mounted() {
  },
  computed: {
    vaults() {
      return this.$store.state.userVaults;
    },
    activeKeep() {
      return this.$store.state.activeKeep
    }
  },
  components: {
  }
}
</script>
<style scoped>

</style>