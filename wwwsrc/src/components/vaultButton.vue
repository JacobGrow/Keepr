<template>
  <div class="vaultButton">
    
     <button class="btn btn-secondary form-control my-1">{{vaultButton.name}}</button>
    
  </div>
</template>


<script>
export default {
   name: "VaultButton",
  props: ["vaultButton"],
  methods: {
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