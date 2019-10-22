<template>
  <div class="home">
    <div class="row justify-content-center">
      <div class="col-2"></div>
      <h1 class="text-light mt-3 col-8" v-if="user.id">Welcome Home, {{user.username}}!</h1>
      <h1 class="text-light mt-3 col-8" v-else>Welcome to ToastKeepr!</h1>
      <div class="col-2 mt-5">
        <dropDown v-if="user.id" />
      </div>
    </div>
    <div class="row justify-content-center">
      <button class="btn-danger badge-pill" v-if="user.id" @click="logout">logout</button>
      <button
        class="btn-primary badge-pill"
        v-else
        data-toggle="modal"
        data-target="#loginModal"
      >Login</button>
      <login />
    </div>
    <hr class="bg-light" />
    <div class="row justify-content-around mt-2">
      <keepComp class="col-3" v-for="keep in keeps" :key="keep.id" :keepProp="keep" />
    </div>
  </div>
</template>

<script>
import login from "./Login.vue";
import keepComp from "../components/KeepComp.vue";
import dropDown from "../components/DropDown.vue";
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
  components: { keepComp, dropDown, login }
};
</script>

<style>
.fa-bars {
  cursor: pointer;
}
</style>