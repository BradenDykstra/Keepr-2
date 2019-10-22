<template>
  <div class="dropdown">
    <i class="fas fa-bars light-text fa-3x" data-toggle="dropdown"></i>
    <div class="dropdown-menu blue-bg">
      <p class="dropdown-item light-text" @click="goToKeeps()">The Keeps</p>
      <p class="dropdown-item light-text" @click="goToVaults()">My Vaults</p>
      <p class="dropdown-item light-text" @click="goToMyKeeps()">My Keeps</p>
    </div>
  </div>
</template>


<script>
export default {
  name: "dropdown",
  data() {
    return {};
  },
  computed: {},
  methods: {
    goToKeeps() {
      this.$router.push("/");
    },
    goToVaults() {
      this.$router.push("/vaults");
    },
    goToMyKeeps() {
      this.$router.push("/myKeeps");
    }
  },
  components: {}
};
</script>


<style scoped>
</style>