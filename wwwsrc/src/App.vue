<template>
  <div id="app">
    <router-view />
  </div>
</template>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #42b983;
}

#nav a.router-link-exact-active {
  color: #42b983;
}

* {
  font-family: "Baloo Bhai", cursive;
}

.light-bg {
  background-color: #d4d6d4;
}

.red-bg {
  background-color: #f71735;
}

.blue-bg {
  background-color: #3095ba;
}

.dark-bg {
  background-color: #030b1e;
}

.yellow-bg {
  background-color: #ffaa32;
}

.light-text {
  color: #d4d6d4;
}

.red-text {
  color: #f71735;
}

.blue-text {
  color: #3095ba;
}

.dark-text {
  color: #030b1e;
}

.yellow-text {
  color: #ffaa32;
}

.light-btn {
  color: #030b1e;
  background-color: #d4d6d4;
  border-color: #d4d6d4;
}
.red-btn {
  color: #030b1e;
  background-color: #f71735;
  border-color: #f71735;
}
.blue-btn {
  color: #030b1e;
  background-color: #3095ba;
  border-color: #3095ba;
}
.dark-btn {
  color: #d4d6d4;
  background-color: #030b1e;
  border-color: #030b1e;
}
.yellow-btn {
  color: #030b1e;
  background-color: #ffaa32;
  border-color: #ffaa32;
}
</style>