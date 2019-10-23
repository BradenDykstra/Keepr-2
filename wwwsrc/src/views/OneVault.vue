<template>
  <div class="oneVault">
    <top-bar />
    <hr class="light-bg" />
    <button class="red-btn badge-pill" @click="backToVaults">Back to Vaults</button>
    <i
      class="fas fa-trash red-text m-5"
      @click="deleteVault"
      data-toggle="tooltip"
      title="Delete this vault"
    ></i>
    <Stack :column-min-width="200" :monitor-images-loaded="true">
      <StackItem v-for="keep in keeps" :key="keep.id" style="transition: transform 300ms">
        <keepComp :keepProp="keep" />
      </StackItem>
    </Stack>
    <KeepView v-for="keep in keeps" :key="keep.id" :keepProp="keep" />
  </div>
</template>


<script>
import topBar from "../components/TopBar.vue";
import swal from "sweetalert2";
import keepComp from "../components/KeepComp.vue";
import { Stack, StackItem } from "vue-stack-grid";
import KeepView from "./KeepView.vue";
export default {
  name: "oneVault",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getVault", this.$route.params.id);
    $(function() {
      $('[data-toggle="tooltip"]').tooltip();
    });
    this.$store.dispatch("getVaults");
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    },
    vault() {
      return this.$store.state.vault;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    backToVaults() {
      this.$router.push("/vaults");
    },
    deleteVault() {
      swal
        .fire({
          title: "Do you want to delete this vault?",
          text: "This can't be undone!",
          type: "warning",
          showCancelButton: true,
          confirmButtonColor: "#3085d6",
          cancelButtonColor: "#d33",
          confirmButtonText: "Yes, delete it!"
        })
        .then(result => {
          if (result.value) {
            this.$store
              .dispatch("deleteVault", this.$route.params.id)
              .then(res => {
                this.$router.push("/vaults");
              });
          }
        });
    }
  },
  components: { keepComp, topBar, Stack, StackItem, KeepView }
};
</script>


<style scoped>
</style>