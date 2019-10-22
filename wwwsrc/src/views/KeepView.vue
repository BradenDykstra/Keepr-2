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
            <i
              v-if="user.id == keepProp.userId"
              class="fas fa-trash text-danger m-5"
              @click="deleteKeep"
              data-dismiss="modal"
            ></i>
            <i
              v-if="this.$route.params.id"
              class="fas fa-ban text-danger m-5"
              @click="removeKeep"
              data-dismiss="modal"
            ></i>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import swal from "sweetalert2";
export default {
  name: "keepView",
  data() {
    return {
      keep: {}
    };
  },
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  mounted() {},
  methods: {
    deleteKeep() {
      swal
        .fire({
          title: "Do you want to delete this keep?",
          text: "This can't be undone!",
          type: "warning",
          showCancelButton: true,
          confirmButtonColor: "#3085d6",
          cancelButtonColor: "#d33",
          confirmButtonText: "Yes, delete it!"
        })
        .then(result => {
          if (result.value) {
            this.$store.dispatch("deleteKeep", this.keepProp.id);
          }
        });
    },
    removeKeep() {
      swal
        .fire({
          title: "Are you sure you want to remove this keep from this vault?",
          type: "warning",
          showCancelButton: true,
          confirmButtonColor: "#3085d6",
          cancelButtonColor: "#d33",
          confirmButtonText: "Yes, remove it!"
        })
        .then(result => {
          if (result.value) {
            this.$store.dispatch("removeKeep", {
              keepId: this.keepProp.id,
              vaultId: parseInt(this.$route.params.id)
            });
          }
        });
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