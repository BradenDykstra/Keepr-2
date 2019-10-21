<template>
  <div class="keepComp row justify-content-center">
    <div class="card col-6">
      <img class="card-img-top" :src="keep.img" />
      <div class="card-body">
        <h1 class="card-title">{{keep.name}}</h1>
        <h4>{{keep.description}}</h4>
        <button class="btn-primary badge-pill">{{keep.views}}</button>
        <button class="btn-success badge-pill">{{keep.stores}}</button>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "keepView",
  data() {
    return {};
  },
  computed: {
    keep() {
      return this.$store.state.keep;
    }
  },
  mounted() {
    this.$store.dispatch("getOneKeep", this.$route.params);
  },
  methods: {},
  components: {}
};
</script>


<style scoped>
</style>