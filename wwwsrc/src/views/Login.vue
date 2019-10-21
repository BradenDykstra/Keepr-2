<template>
  <div class="login">
    <h1 class="text-light my-5">Welcome to ToastKeepr</h1>
    <form class="row justify-content-center mt-5" v-if="loginForm" @submit.prevent="loginUser">
      <input class="form-control col-4" type="email" v-model="creds.email" placeholder="email" />
      <input
        class="form-control col-4"
        type="password"
        v-model="creds.password"
        placeholder="password"
      />
      <button type="submit" class="btn-success btn">Login</button>
    </form>
    <form class="row justify-content-center mt-5" v-else @submit.prevent="register">
      <input class="form-control col-3" type="text" v-model="newUser.username" placeholder="name" />
      <input class="form-control col-3" type="email" v-model="newUser.email" placeholder="email" />
      <input
        class="form-control col-3"
        type="password"
        v-model="newUser.password"
        placeholder="password"
      />
      <button type="submit" class="btn-warning btn">Create Account</button>
    </form>
    <div @click="loginForm = !loginForm">
      <p v-if="loginForm" class="text-light">No account? Click to Register</p>
      <p v-else class="text-light">Already have an account? Click to Login</p>
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
      this.$store.dispatch("login", this.creds);
    }
  }
};
</script>