<template>
  <div class="oneVault">
    <button class="btn-danger badge-pill" @click="backToVaults">Back to Vaults</button>
    <i class="fas fa-trash text-danger m-5" @click="deleteVault"></i>
    <div class="row justify-content-around mt-2">
      <keepComp class="col-3" v-for="keep in keeps" :key="keep.id" :keepProp="keep" />
    </div>
  </div>
</template>


<script>
import swal from "sweetalert2";
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
  components: { keepComp }
};
</script>


<style scoped>
</style>