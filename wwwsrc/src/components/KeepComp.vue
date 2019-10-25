<template>
  <div
    class="keepComp card mx-2 my-2 light-bg dark-text"
    @click="viewKeep"
    data-toggle="modal"
    :data-target="'#keepView'+keepProp.id"
  >
    <img class="card-img-top mt-2" :src="keepProp.img" />
    <div class="card-body">
      <h3 class="card-title">{{keepProp.name}}</h3>
      <span data-toggle="tooltip" title="Views">
        <i class="far fa-eye fa-2x blue-btn badge-pill py-1">{{keepProp.views}}</i>
      </span>
      <span data-toggle="tooltip" title="Keeps">
        <i class="ra ra-toast fa-2x dark-btn badge-pill py-1">{{keepProp.stores}}</i>
      </span>
    </div>
  </div>
</template>


<script>
import KeepView from "../views/KeepView.vue";
import swal from "sweetalert2";
export default {
  name: "keepComp",
  data() {
    return {};
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  mounted() {
    $(function() {
      $('[data-toggle="tooltip"]').tooltip();
    });
  },
  methods: {
    viewKeep() {
      this.$store
        .dispatch("addToKeep", {
          id: this.keepProp.id,
          views: this.keepProp.views + 1,
          stores: this.keepProp.stores
        })
        .then(res => {
          if (this.$route.name == "myKeeps") {
            this.$store.dispatch("getKeepsByUser");
          } else if (this.$route.name == "home") {
            this.$store.dispatch("getKeeps");
          } else {
            this.$store.dispatch("getVaultKeeps");
          }
        });
    },
    storeKeep(vaultId) {
      this.$store.dispatch("storeKeep", {
        keepId: this.keepProp.id,
        vaultId: vaultId
      });
      this.$store
        .dispatch("addToKeep", {
          id: this.keepProp.id,
          stores: this.keepProp.stores + 1,
          views: this.keepProp.views
        })
        .then(res => {
          if (this.$route.name == "myKeeps") {
            this.$store.dispatch("getKeepsByUser");
          } else if (this.$route.name == "home") {
            this.$store.dispatch("getKeeps");
          } else {
            this.$store.dispatch("getVaultKeeps", this.$route.params.id);
          }
        });
    }
  },
  components: { KeepView },
  props: ["keepProp"]
};
</script>


<style scoped>
i {
  font-size: 1.25em;
}
.btn-success {
  cursor: pointer;
}
img {
  cursor: pointer;
}
</style>