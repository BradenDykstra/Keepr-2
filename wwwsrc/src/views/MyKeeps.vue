<template>
  <div class="myKeeps">
    <div class="row justify-content-center">
      <div class="col-2"></div>
      <h1 class="text-light mt-5 mb-3 col-8" v-if="user.id">{{user.username}}'s Keeps</h1>
      <div class="col-2 mt-5">
        <dropDown />
      </div>
    </div>
    <hr class="bg-light" />
    <button class="btn btn-primary" @click="goToMakeKeep">New Keep</button>
    <div class="row justify-content-around">
      <keepComp class="col-3" v-for="keep in keeps" :key="keep.id" :keepProp="keep" />
    </div>
  </div>
</template>


<script>
import dropDown from "../components/DropDown.vue";
import keepComp from "../components/KeepComp.vue";
export default {
  name: "myKeeps",
  data() {
    return {};
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    },
    user() {
      return this.$store.state.user;
    }
  },
  mounted() {
    this.$store.dispatch("getKeepsByUser");
  },
  methods: {
    goToMakeKeep() {
      this.$router.push("/makeKeep");
    }
  },
  components: { dropDown, keepComp }
};
</script>


<style scoped>
</style>