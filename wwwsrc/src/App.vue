<template>
  <div id="app">
    <router-view />
  </div>
</template>

<style>
#app {
  font-family: "Indie Flower", cursive;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

.modal::-webkit-scrollbar {
  display: none;
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

.fa-bars {
  cursor: pointer;
}

.logo {
  cursor: pointer;
  width: 85%;
}

.light-bg {
  background-color: #f3ffb9;
}

.red-bg {
  background-color: #c42021;
}

.blue-bg {
  background-color: #561643;
}

.dark-bg {
  background-color: #030b1e;
}

.yellow-bg {
  background-color: #db995a;
}

.light-text {
  color: #f3ffb9;
}

.red-text {
  color: #c42021;
}

.blue-text {
  color: #561643;
}

.dark-text {
  color: #3c1742;
}

.yellow-text {
  color: #db995a;
}

.light-btn {
  color: #3c1742;
  background-color: #f3ffb9;
  border-color: #f3ffb9;
}
.red-btn {
  color: #f3ffb9;
  background-color: #c42021;
  border-color: #c42021;
}
.blue-btn {
  color: #f3ffb9;
  background-color: #561643;
  border-color: #561643;
}
.dark-btn {
  color: #f3ffb9;
  background-color: #3c1742;
  border-color: #3c1742;
}
.yellow-btn {
  color: #3c1742;
  background-color: #db995a;
  border-color: #db995a;
}
</style>