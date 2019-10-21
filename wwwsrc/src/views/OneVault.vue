<template>
  <div class="oneVault">
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
  methods: {},
  components: { keepComp }
};
</script>


<style scoped>
</style>