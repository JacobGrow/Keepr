<template>
  <div class="keep">
    <div class="card-columns">

      <div class="card">
        {{keepData.name}}
       <img :src = "keepData.img" >
        {{keepData.description}}
      </div>
    </div>
    </div>
</template>

<script>
export default {
  name: "Keep",
  props: ["keepData"]
};
</script>

<style scoped>


</style>