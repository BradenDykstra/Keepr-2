<template>
  <div class="keepComp card mx-2 my-2">
    <img
      class="card-img-top"
      :src="keepProp.img"
      data-toggle="modal"
      :data-target="'#keepView'+keepProp.id"
    />
    <div class="card-body">
      <h3 class="card-title">{{keepProp.name}}</h3>
      <i class="far fa-eye fa-2x bg-primary badge-pill py-1">{{keepProp.views}}</i>
      <i class="fas fa-save fa-2x btn-success badge-pill py-1">{{keepProp.stores}}</i>
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
  computed: {},
  methods: {
    viewKeep() {
      this.$router.push("keep/" + this.keepProp.id);
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