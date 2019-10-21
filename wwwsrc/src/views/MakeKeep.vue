<template>
  <div class="makeKeep">
    <div class="row justify-content-center">
      <div class="col-2"></div>
      <h1 class="text-light mt-5 col-8">Post a Keep</h1>
      <div class="col-2 mt-5">
        <dropDown />
      </div>
    </div>
    <hr class="bg-light mt-2" />
    <form class="row justify-content-center mt-5" @submit.prevent="createKeep">
      <input class="form-control col-3 m-2" type="text" v-model="newKeep.name" placeholder="Title" />
      <input
        class="form-control col-3 m-2"
        type="text"
        v-model="newKeep.img"
        placeholder="Image URL"
      />
      <input
        class="form-control col-3 m-2"
        type="text"
        v-model="newKeep.description"
        placeholder="Description"
      />
      <button type="submit" class="btn-success badge-pill m-2">Create</button>
    </form>
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
      this.$store.dispatch("createKeep", this.newKeep).then(res => {
        this.$router.push("/");
      });
    }
  },
  components: { dropDown }
};
</script>


<style scoped>
</style>