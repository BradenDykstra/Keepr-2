<template>
  <div class="myKeeps">
    <top-bar />
    <hr class="light-bg" />
    <button class="badge-pill blue-btn" data-toggle="modal" data-target="#makeKeepModal">New Keep</button>
    <make-keep-modal />
    <div class="row justify-content-around">
      <Stack :column-min-width="200" :gutter-width="8" :monitor-images-loaded="true">
        <StackItem v-for="keep in keeps" :key="keep.id" style="transition: transform 300ms">
          <keepComp :keepProp="keep" />
        </StackItem>
      </Stack>
      <KeepView v-for="keep in keeps" :key="keep.id" :keepProp="keep" />
    </div>
  </div>
</template>


<script>
import topBar from "../components/TopBar.vue";
import keepComp from "../components/KeepComp.vue";
import makeKeepModal from "./MakeKeep.vue";
import { Stack, StackItem } from "vue-stack-grid";
import KeepView from "./KeepView.vue";
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
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  mounted() {
    this.$store.dispatch("getKeepsByUser");
    this.$store.dispatch("getVaults");
  },
  methods: {
    goToMakeKeep() {
      this.$router.push("/makeKeep");
    }
  },
  components: { topBar, keepComp, makeKeepModal, Stack, StackItem, KeepView }
};
</script>


<style scoped>
</style>