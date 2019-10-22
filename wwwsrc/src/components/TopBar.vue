<template>
  <div class="topBar">
    <div class="row justify-content-center">
      <div class="col-2">
        <img src="../assets/toastkeepr.png" class="logo mt-3 mx-auto" @click="goHome()" />
      </div>
      <h1
        class="light-text mt-5 col-8"
        v-if="user.id && this.$route.name == 'home'"
      >Welcome Home, {{user.username}}!</h1>
      <h1
        class="light-text mt-5 mb-3 col-8"
        v-else-if="user.id && this.$route.name == 'vaults'"
      >{{user.username}}'s Vaults</h1>
      <h1 class="light-text mt-5 mb-3 col-8" v-else-if="this.$route.name == 'vault'">{{vault.name}}</h1>
      <h1
        class="light-text mt-5 mb-3 col-8"
        v-else-if="user.id && this.$route.name == 'myKeeps'"
      >{{user.username}}'s Keeps</h1>
      <h1 class="light-text mt-5 col-8" v-else>Welcome to ToastKeepr!</h1>
      <div class="col-2 mt-5">
        <dropDown v-if="user.id" />
      </div>
    </div>
  </div>
</template>


<script>
import dropDown from "./DropDown.vue";
export default {
  name: "topBar",
  data() {
    return {};
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    vault() {
      return this.$store.state.vault;
    }
  },
  methods: {
    goHome() {
      this.$router.push("/");
    }
  },
  components: { dropDown }
};
</script>


<style scoped>
</style>