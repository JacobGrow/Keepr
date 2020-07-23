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
          <div class="col-3">
            <keep v-for="keep in keeps" :key="keep.id" :keepData="keep"/>
         
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Vault from "@/components/vaultComponent.vue"
import Keep from "@/components/keepComponent.vue"
export default {
  name: "VaultDetails",
  props: ["vaultDetails"],
  mounted() {
    this.$store.dispatch("getActiveVault", this.$route.params.vaultId);
  },
  computed: {
    vault() {
      return this.$store.state.activeVault;
      console.log(this.activeVault);
    },
     keeps() {
      return this.$store.state.userKeeps;
     }
  },
  methods: {},
  components: {
    Vault
  }
};
</script>

<style scoped>

</style> 