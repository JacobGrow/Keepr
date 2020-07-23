<template>
  <div class="vaultDetails container-fluid">
     
    <div class="row">
      <div class="col">
        <div class="row justify-content-center">
          <div class="col text-center">
          <h1>{{vault.name}}</h1>
          <h5>{{vault.description}}</h5>
          </div>
        </div>
        <div class="row justify-content-center">
          <div class="card-columns">
            <vaultKeep v-for="vaultkeep in vaultKeeps" :key="vaultkeep.id" :vaultKeepData="vaultkeep"/>
          </div>
         
          
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Vault from "@/components/vaultComponent.vue"
import VaultKeep from "@/components/vaultKeepComponent.vue"

export default {
  name: "VaultDetails",
  props: ["vaultDetails"],
  mounted() {
    this.$store.dispatch("getActiveVault", this.$route.params.vaultId);
    this.$store.dispatch("getKeepsByVault", this.$route.params.vaultId);
  },
  computed: {
    vault() {
      return this.$store.state.activeVault;
      console.log(this.activeVault);
    },
     vaultKeeps() {
      return this.$store.state.vaultKeeps;
     }
  },
  methods: {},
  components: {
    Vault,
    VaultKeep
  }
};
</script>

<style scoped>
.card-columns{ column-count: 5; }
</style> 