<template>
  <div class="keepComp row justify-content-center mt-5">
    <div class="card col-6">
      <img class="card-img-top" :src="keep.img" />
      <div class="card-body">
        <h1 class="card-title">{{keep.name}}</h1>
        <h4>{{keep.description}}</h4>
        <i class="far fa-eye fa-2x bg-primary badge-pill py-2">{{keep.views}}</i>
        <i class="fas fa-save fa-2x btn-success badge-pill py-2">{{keep.stores}}</i>
      </div>
    </div>
    <div class="col-12 mt-2">
      <button class="btn btn-warning badge-pill" @click="goHome()">Home</button>
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
  methods: {
    goHome() {
      this.$router.push("/");
    }
  },
  components: {}
};
</script>


<style scoped>
i {
  font-size: 1.75em;
}
</style>