<template>
  <div class="vaultButton">
    
     <button class="btn btn-primary form-control my-1" @click="addKeepToVault()">{{vaultButton.name}}</button>
    
  </div>
</template>


<script>
import Keep from "@/components/keepComponent.vue"

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
        keepId: this.$store.state.activeKeep.id
      }
      this.$store.dispatch("addKeepToVault", this.newVaultKeep) 
    }
  },
  mounted() {
    this.$store.dispatch("getActiveKeep", this.$route.params.keepId)
    this.$store.dispatch(("getUserVaults"))
  },
  computed: {
    vaults() {
      return this.$store.state.userVaults;
    },
    keep() {
      return this.$store.state.activeKeep;
  },
  },
  components: {
    Keep
  }
}
</script>
<style scoped>

</style>