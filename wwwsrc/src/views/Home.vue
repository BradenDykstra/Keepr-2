<template>
  <div class="home">
    <topBar />
    <div class="row justify-content-center">
      <button class="red-btn badge-pill" v-if="user.id" @click="logout">Logout</button>
      <button class="blue-btn badge-pill" v-else data-toggle="modal" data-target="#loginModal">Login</button>
      <login />
    </div>
    <hr class="light-bg" />
    <Stack :column-min-width="200" :monitor-images-loaded="true">
      <StackItem v-for="keep in keeps" :key="keep.id" style="transition: transform 300ms">
        <keepComp :keepProp="keep" />
      </StackItem>
    </Stack>
    <KeepView v-for="keep in keeps" :key="keep.id" :keepProp="keep" />
  </div>
</template>

<script>
import login from "./Login.vue";
import keepComp from "../components/KeepComp.vue";
import topBar from "../components/TopBar.vue";
import { Stack, StackItem } from "vue-stack-grid";
import KeepView from "./KeepView.vue";
export default {
  name: "home",
  computed: {
    user() {
      return this.$store.state.user;
    },
    keeps() {
      this.$store.state.keeps.forEach(keep => {
        keep.height = Math.floor(Math.random() * 1000);
      });
      return this.$store.state.keeps;
    }
  },
  mounted() {
    this.$store.dispatch("getKeeps");
    this.$store.dispatch("getVaults");
    $(function() {
      $('[data-toggle="tooltip"]').tooltip();
    });
    // this.$nextTick(() => {
    //   window.dispatchEvent(new Event("resize"));
    // });
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
  components: {
    keepComp,
    login,
    topBar,
    Stack,
    StackItem,
    KeepView
  }
};
</script>

<style scoped>
</style>