<template>
  <div class="oneVault">
    <div class="row justify-content-center">
      <div class="col-2"></div>
      <h1 class="text-light mt-5 mb-3 col-8">{{vault.name}}</h1>
      <div class="col-2 mt-5">
        <dropDown />
      </div>
    </div>
    <hr class="bg-light" />
    <button class="btn-danger badge-pill" @click="backToVaults">Back to Vaults</button>
    <i
      class="fas fa-trash text-danger m-5"
      @click="deleteVault"
      data-toggle="tooltip"
      title="Delete this vault"
    ></i>
    <div class="row justify-content-around mt-2">
      <keepComp class="col-3" v-for="keep in keeps" :key="keep.id" :keepProp="keep" />
    </div>
  </div>
</template>


<script>
import swal from "sweetalert2";
import keepComp from "../components/KeepComp.vue";
import dropDown from "../components/DropDown.vue";
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
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    },
    vault() {
      return this.$store.state.vault;
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
  components: { keepComp, dropDown }
};
</script>


<style scoped>
</style>