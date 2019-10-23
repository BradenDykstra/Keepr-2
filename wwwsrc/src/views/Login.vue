<template>
  <div id="loginModal" class="login modal fade" tabindex="-1" role="dialog">
    <div class="modal-dialog modal-lg" role="document">
      <div class="modal-content light-bg">
        <h1 class="dark-text my-5">Welcome to ToastKeepr!</h1>
        <form class="justify-content-center" v-if="loginForm" @submit.prevent="loginUser">
          <div class="row">
            <input
              class="form-control col-8 offset-2 my-2"
              type="email"
              v-model="creds.email"
              placeholder="email"
            />
            <input
              class="form-control col-8 offset-2 my-2"
              type="password"
              v-model="creds.password"
              placeholder="password"
            />
          </div>
          <div class="row">
            <button
              type="submit"
              class="blue-btn badge-pill col-2 offset-5 my-3"
              @click="close"
            >Login</button>
          </div>
        </form>
        <form class="justify-content-center" v-else @submit.prevent="register">
          <div class="row">
            <input
              class="form-control col-8 offset-2 my-2"
              type="text"
              v-model="newUser.username"
              placeholder="name"
            />
            <input
              class="form-control col-8 offset-2 my-2"
              type="email"
              v-model="newUser.email"
              placeholder="email"
            />
            <input
              class="form-control col-8 offset-2 my-2"
              type="password"
              v-model="newUser.password"
              placeholder="password"
            />
          </div>
          <div class="row">
            <button
              type="submit"
              class="yellow-btn badge-pill col-2 offset-5 my-3"
              @click="close"
            >Create Account</button>
          </div>
        </form>
        <div @click="loginForm = !loginForm" class="dark-text">
          <p v-if="loginForm">No account? Click to Register</p>
          <p v-else>Already have an account? Click to Login</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "login",
  data() {
    return {
      loginForm: true,
      creds: {
        email: "",
        password: ""
      },
      newUser: {
        email: "",
        password: "",
        username: ""
      }
    };
  },
  beforeCreate() {
    if (this.$store.state.user.id) {
      this.$router.push({ name: "home" });
    }
  },
  methods: {
    register() {
      this.$store.dispatch("register", this.newUser);
    },
    loginUser() {
      this.$store.dispatch("login", this.creds).then(res => {
        this.$store.dispatch("getVaults");
      });
    },
    close() {
      $("#loginModal").modal("hide");
    }
  }
};
</script>