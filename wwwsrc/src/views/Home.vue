<template>
  <div class="home">
    <div class="row justify-content-center">
      <div class="col-2"></div>
      <h1 class="text-light mt-3 col-8" v-if="user.id">Welcome Home, {{user.username}}</h1>
      <div class="col-2 mt-5">
        <i class="fas fa-bars text-light fa-3x" data-toggle="dropdown"></i>
        <div class="dropdown-menu">
          <p class="dropdown-item" @click="goToKeeps()">The Keeps</p>
          <p class="dropdown-item" @click="goToVaults()">My Vaults</p>
        </div>
      </div>
    </div>
    <div class="row justify-content-center">
      <button class="btn-danger badge-pill" v-if="user.id" @click="logout">logout</button>
      <button class="btn-primary badge-pill" v-else @click="login">Login</button>
    </div>
    <hr class="bg-light" />
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
    },
    goToKeeps() {
      this.$router.push("/");
    },
    goToVaults() {
      this.$router.push("/vaults");
    }
  },
  components: { keepComp }
};
</script>

<style>
.fa-bars {
  cursor: pointer;
}
</style>