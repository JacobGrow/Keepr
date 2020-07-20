<template>
  <div class="keep">
    <div class="card shadow card-size">
      <img :src="keepData.img" />
      <h5>{{keepData.name}}</h5>
      <h5>{{keepData.description}}</h5>
      <button class="btn btn-danger" @click="deleteKeep(keepData.id)">DELORT</button>
    </div>
  </div>
</template>

<script>
export default {
  name: "Keep",
  props: ["keepData"],
  methods: {
    deleteKeep(keepId) {
      this.$store.dispatch("deleteKeep", keepId);
    }
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.publicKeeps;
    }
  }
};
</script>

<style scoped>
.card-size {
  padding: 5px;
}

img {
  width: 100%;
  height: 100%;
}
</style>