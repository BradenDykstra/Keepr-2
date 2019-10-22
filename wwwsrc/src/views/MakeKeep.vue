<template>
  <div id="makeKeepModal" class="makeKeep modal fade" tabindex="-1" role="dialog">
    <div class="modal-dialog modal-xl" role="document">
      <div class="modal-content">
        <div class="row justify-content-center">
          <div class="col-2"></div>
          <h1 class="mt-5 col-8">Post a Keep</h1>
          <div class="col-2 mt-5">
            <dropDown />
          </div>
        </div>
        <hr class="bg-light mt-2" />
        <form class="justify-content-center mt-5" @submit.prevent="createKeep">
          <div class="row">
            <input
              class="form-control col-8 offset-2 my-2"
              type="text"
              v-model="newKeep.name"
              placeholder="Title"
            />
            <input
              class="form-control col-8 offset-2 my-2"
              type="text"
              v-model="newKeep.img"
              placeholder="Image URL"
            />
            <input
              class="form-control col-8 offset-2 my-2"
              type="text"
              v-model="newKeep.description"
              placeholder="Description"
            />
          </div>
          <div class="row">
            <button type="submit" class="btn-success badge-pill col-2 offset-5 my-3">Create</button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>


<script>
import dropDown from "../components/DropDown.vue";
export default {
  name: "makeKeep",
  data() {
    return {
      newKeep: {}
    };
  },
  computed: {},
  methods: {
    createKeep() {
      this.$store.dispatch("createKeep", this.newKeep);
    },
    close() {
      $("#makeKeepModal").modal("hide");
    }
  },
  components: { dropDown }
};
</script>


<style scoped>
</style>