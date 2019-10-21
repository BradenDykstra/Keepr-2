<template>
  <div class="myVaults">
    <div class="row justify-content-center">
      <div class="col-2"></div>
      <h1 class="text-light mt-5 mb-3 col-8" v-if="user.id">Welcome Home, {{user.username}}</h1>
      <div class="col-2 mt-5">
        <dropDown />
      </div>
    </div>
    <hr class="bg-light" />
    <div class="row justify-content-around">
      <div
        class="card col-3 mx-2 my-3"
        v-for="vault in vaults"
        :key="vault.id"
        @click="viewVault(vault.id)"
      >
        <div class="card-body">
          <h2>{{vault.name}}</h2>
          <h4>{{vault.description}}</h4>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import dropDown from "../components/DropDown.vue";
export default {
  name: "myVaults",
  data() {
    return {};
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    },
    user() {
      return this.$store.state.user;
    }
  },
  mounted() {
    this.$store.dispatch("getVaults");
  },
  methods: {
    viewVault(id) {
      this.$router.push("/vault/" + id);
    }
  },
  components: { dropDown }
};
</script>


<style scoped>
</style>