<template>
  <div class="myKeeps">
    <top-bar />
    <hr class="light-bg" />
    <button class="badge-pill blue-btn" data-toggle="modal" data-target="#makeKeepModal">New Keep</button>
    <make-keep-modal />
    <div class="row justify-content-around">
      <keepComp class="col-md-2 col-6" v-for="keep in keeps" :key="keep.id" :keepProp="keep" />
    </div>
  </div>
</template>


<script>
import topBar from "../components/TopBar.vue";
import keepComp from "../components/KeepComp.vue";
import makeKeepModal from "./MakeKeep.vue";
export default {
  name: "myKeeps",
  data() {
    return {};
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    },
    user() {
      return this.$store.state.user;
    }
  },
  mounted() {
    this.$store.dispatch("getKeepsByUser");
  },
  methods: {
    goToMakeKeep() {
      this.$router.push("/makeKeep");
    }
  },
  components: { topBar, keepComp, makeKeepModal }
};
</script>


<style scoped>
</style>