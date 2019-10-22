<template>
  <div class="keepComp card mx-2 my-2 light-bg dark-text">
    <img
      class="card-img-top mt-2"
      :src="keepProp.img"
      data-toggle="modal"
      :data-target="'#keepView'+keepProp.id"
      @click="viewKeep"
    />
    <div class="card-body">
      <h3
        class="card-title"
        data-toggle="modal"
        :data-target="'#keepView'+keepProp.id"
        @click="viewKeep"
      >{{keepProp.name}}</h3>
      <i
        class="far fa-eye fa-2x blue-btn badge-pill py-1"
        data-toggle="modal"
        title="Views"
        @click="viewKeep"
        :data-target="'#keepView'+keepProp.id"
      >{{keepProp.views}}</i>
      <span data-toggle="tooltip" title="Store this keep in a vault">
        <i
          class="fas fa-save fa-2x dark-btn badge-pill py-1"
          data-toggle="dropdown"
        >{{keepProp.stores}}</i>
        <div class="dropdown-menu blue-bg">
          <p
            v-for="vault in vaults"
            :key="vault.id"
            class="dropdown-item light-text"
            @click="storeKeep(vault.id)"
          >{{vault.name}}</p>
        </div>
      </span>
    </div>
    <KeepView :keepProp="keepProp" />
  </div>
</template>


<script>
import KeepView from "../views/KeepView.vue";
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
      this.$store
        .dispatch("storeKeep", {
          keepId: this.keepProp.id,
          vaultId: vaultId
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