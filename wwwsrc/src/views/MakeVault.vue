<template>
  <div class="makeVault">
    <div class="row justify-content-center">
      <div class="col-2"></div>
      <h1 class="text-light mt-5 col-8">Make a New Vault</h1>
      <div class="col-2 mt-5">
        <dropDown />
      </div>
    </div>
    <hr class="bg-light mt-2" />
    <form class="row justify-content-center mt-5" @submit.prevent="createVault">
      <input class="form-control col-4 m-2" type="text" v-model="newVault.name" placeholder="Title" />

      <input
        class="form-control col-4 m-2"
        type="text"
        v-model="newVault.description"
        placeholder="Description"
      />
      <button type="submit" class="btn-success badge-pill m-2">Create</button>
    </form>
  </div>
</template>


<script>
import dropDown from "../components/DropDown.vue";
export default {
  name: "makeVault",
  data() {
    return {
      newVault: {}
    };
  },
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    createVault() {
      this.$store.dispatch("createVault", this.newVault).then(res => {
        this.$router.push("/vaults");
      });
    }
  },
  components: { dropDown }
};
</script>


<style scoped>
</style>