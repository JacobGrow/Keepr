<template>
  <div class="keepDetails container-fluid">
    <div class="row">
      <div class="col">
        <div class="row justify-content-center">
          <h1 class="text-light">{{ keep.name }}</h1>
        </div>
        <div class="row justify-content-center">
          <div class="col-3">
            <div class="card card-color mt-2 p-2 text-center shadow">
              <img :src="keep.img" class="movie-size align-self-center" />
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "KeepDetails",
  mounted() {
    this.$store.dispatch("getActiveKeep", this.$route.params.keepId);
  },
  computed: {
    keep() {
      return this.$store.state.activeKeep;
      console.log(this.activeKeep);
    }
  },
  methods: {}
};
</script>

<style scoped>

</style> 