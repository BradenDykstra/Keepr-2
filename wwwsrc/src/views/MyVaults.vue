<template>
  <div class="myVaults">
    <top-bar />
    <hr class="light-bg" />
    <button class="badge-pill blue-btn" data-toggle="modal" data-target="#makeVaultModal">New Vault</button>
    <make-vault-modal />
    <div class="row justify-content-around">
      <div
        class="card col-3 mx-2 my-3 light-bg dark-text"
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
import topBar from "../components/TopBar.vue";
import makeVaultModal from "./MakeVault.vue";
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
  components: { makeVaultModal, topBar }
};
</script>


<style scoped>
</style>