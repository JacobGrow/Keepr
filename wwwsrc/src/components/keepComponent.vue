<template>
  <div class="keep">
  
      <div class="card shadow card-size">
       <img :src = "keepData.img" >
        <h5> {{keepData.name}} </h5>
       <h5> {{keepData.description}} </h5>
       <i class="fa fa-trash text-danger" aria-hidden="true"></i>
    
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
  padding: 5px;
}


img{
  width: 100%;
  height: 100%;
}
</style>