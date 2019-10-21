<template>
  <div
    :id="'keepView' + keepProp.id"
    class="keepView modal fade row justify-content-center mt-5"
    tabindex="-1"
    role="dialog"
  >
    <div class="modal-dialog modal-lg" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <div class="card col-12">
            <img class="card-img-top mt-2" :src="keepProp.img" />
            <div class="card-body">
              <h1 class="card-title">{{keepProp.name}}</h1>
              <h4>{{keepProp.description}}</h4>
              <i class="far fa-eye fa-2x bg-primary badge-pill py-2">{{keepProp.views}}</i>
              <i class="fas fa-save fa-2x btn-success badge-pill py-2">{{keepProp.stores}}</i>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  name: "keepView",
  data() {
    return {
      keep: {}
    };
  },
  computed: {},
  mounted() {},
  methods: {
    goHome() {
      this.$router.push("/");
    }
  },
  components: {},
  props: ["keepProp"]
};
</script>


<style scoped>
i {
  font-size: 1.75em;
}
</style>