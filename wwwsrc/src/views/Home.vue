<template>
  <div class="home">
    <topBar />
    <div class="row justify-content-center">
      <button class="red-btn badge-pill" v-if="user.id" @click="logout">Logout</button>
      <button class="blue-btn badge-pill" v-else data-toggle="modal" data-target="#loginModal">Login</button>
      <login />
    </div>
    <hr class="light-bg" />
    <div class="row justify-content-around mt-2">
      <keepComp class="col-md-2 col-6" v-for="keep in keeps" :key="keep.id" :keepProp="keep" />
    </div>
  </div>
</template>

<script>
import login from "./Login.vue";
import keepComp from "../components/KeepComp.vue";
import topBar from "../components/TopBar.vue";
export default {
  name: "home",
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.keeps;
    }
  },
  mounted() {
    this.$store.dispatch("getKeeps");
    this.$store.dispatch("getVaults");
    $(function() {
      $('[data-toggle="tooltip"]').tooltip();
    });
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    goToKeeps() {
      this.$router.push("/");
    },
    goToVaults() {
      this.$router.push("/vaults");
    }
  },
  components: { keepComp, login, topBar }
};
</script>

<style scoped>
</style>