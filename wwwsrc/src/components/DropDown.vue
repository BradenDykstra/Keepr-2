<template>
  <div class="dropdown">
    <i class="fas fa-bars text-light fa-3x" data-toggle="dropdown"></i>
    <div class="dropdown-menu">
      <p class="dropdown-item" @click="goToKeeps()">The Keeps</p>
      <p class="dropdown-item" @click="goToVaults()">My Vaults</p>
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
    }
  },
  components: {}
};
</script>


<style scoped>
</style>