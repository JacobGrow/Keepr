<template>
  <div class="keep">
  
      <div class="card shadow card-size">
       <img :src = "keepData.img" >
        <h5> {{keepData.name}} </h5>
       <h5> {{keepData.description}} </h5>
    
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
.card-size{
  max-height: 200px;
  max-width: 200px;
  padding: 5px;
}


img{
  width: 100%;
  height: 100%;
}
</style>