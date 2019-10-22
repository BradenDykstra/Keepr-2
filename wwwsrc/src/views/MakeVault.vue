<template>
  <div id="makeVaultModal" class="makeVault modal fade" tabindex="-1" role="dialog">
    <div class="modal-dialog modal-xl" role="document">
      <div class="modal-content">
        <div class="row justify-content-center">
          <h1 class="mt-5 col-12">Make a New Vault</h1>
        </div>
        <hr class="bg-light mt-2" />
        <form class="justify-content-center mt-5" @submit.prevent="createVault">
          <div class="row">
            <input
              class="form-control col-8 offset-2 my-2"
              type="text"
              v-model="newVault.name"
              placeholder="Title"
            />

            <input
              class="form-control col-8 offset-2 my-2"
              type="text"
              v-model="newVault.description"
              placeholder="Description"
            />
          </div>
          <div class="row">
            <button
              type="submit"
              class="btn-success badge-pill my-3 col-2 offset-5"
              @click="close"
            >Create</button>
          </div>
        </form>
      </div>
    </div>
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
      this.$store.dispatch("createVault", this.newVault);
    },
    close() {
      $("#makeVaultModal").modal("hide");
    }
  },
  components: { dropDown }
};
</script>


<style scoped>
</style>