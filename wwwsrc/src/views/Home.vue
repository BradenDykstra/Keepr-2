<template>
  <div class="home">
    <div class="row justify-content-center">
      <h1 class="text-light mt-3" v-if="user.id">Welcome Home, {{user.username}}</h1>
    </div>
    <div class="row justify-content-center">
      <button class="btn-danger badge-pill" v-if="user.id" @click="logout">logout</button>
      <button class="btn-primary badge-pill" v-else @click="login">Login</button>
    </div>
    <div class="row justify-content-around mt-2">
      <keepComp class="col-3" v-for="keep in keeps" :key="keep.id" :keepProp="keep" />
    </div>
  </div>
</template>

<script>
import keepComp from "../components/KeepComp.vue";
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
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    login() {
      this.$router.push("/login");
    }
  },
  components: { keepComp }
};
</script>

<style>
</style>