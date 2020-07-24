<template>
  <div class="keepDetails container-fluid">
    <div class="row justify-content-center">
      <div class="col-10">

              
            <div class="card card-size mt-5 p-2 text-center shadow">

        
          <h1 class="text-dark">{{ keep.name }}</h1>
              <img :src="keep.img" class="align-self-center" />
        <div class="dropdown">
  <button class="btn btn-primary dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" >
    Keep!
  </button>
  <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
    <vaultButton v-for="vault in vaults" :key="vault.id" :vaultButton="vault" />
  
   
  </div>
</div>
       
              
        </div>
      </div>
    </div>
      </div>
</template>

<script>
import VaultButton from "@/components/vaultButton.vue"
export default {
  name: "KeepDetails",
  mounted() {
    this.$store.dispatch("getActiveKeep", this.$route.params.keepId);
    this.$store.dispatch("getUserVaults")
  },
  computed: {
    keep() {
      return this.$store.state.activeKeep;
    },
      vaults() {
        return this.$store.state.userVaults;
      },
    },
  
  methods: {
  },
  components: {
    VaultButton
  }
};
</script>

<style scoped>
.card-size {
  padding: 5px;
  height: auto;
}

img {
 max-width: 95%;
}
</style> 