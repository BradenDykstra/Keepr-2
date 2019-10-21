<template>
  <div class="oneVault">
    <button class="btn-danger badge-pill" @click="backToVaults">Back to Vaults</button>
    <div class="row justify-content-around mt-2">
      <keepComp class="col-3" v-for="keep in keeps" :key="keep.id" :keepProp="keep" />
    </div>
  </div>
</template>


<script>
import keepComp from "../components/KeepComp.vue";
export default {
  name: "oneVault",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getVault", this.$route.params.id);
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    }
  },
  methods: {
    backToVaults() {
      this.$router.push("/vaults");
    }
  },
  components: { keepComp }
};
</script>


<style scoped>
</style>