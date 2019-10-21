<template>
  <div class="keepComp card mx-2 my-2" @click="viewKeep">
    <img class="card-img-top" :src="keepProp.img" />
    <div class="card-body">
      <h3 class="card-title">{{keepProp.name}}</h3>
      <button class="btn-primary badge-pill">{{keepProp.views}}</button>
      <button class="btn-success badge-pill">{{keepProp.stores}}</button>
    </div>
  </div>
</template>


<script>
export default {
  name: "keepComp",
  data() {
    return {};
  },
  computed: {},
  methods: {
    viewKeep() {
      console.log(this.keepProp.id);
      this.$router.push("keep/" + this.keepProp.id);
    }
  },
  components: {},
  props: ["keepProp"]
};
</script>


<style scoped>
</style>