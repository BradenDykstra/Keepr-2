<template>
  <div class="home">
    <div class="row justify-content-center">
      <h1 class="text-light" v-if="user.id">Welcome Home, {{user.username}}</h1>
    </div>
    <div class="row justify-content-center">
      <button class="btn-danger badge-pill" v-if="user.id" @click="logout">logout</button>
      <router-link v-else :to="{name: 'login'}">Login</router-link>
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
    }
  },
  components: { keepComp }
};
</script>

<style>
</style>