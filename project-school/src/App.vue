<template>
  <div id="app">
    <Nav></Nav>
    <div class="marginPrincipal">
      <router-view :key="$route.fullPath"></router-view>
    </div>
  </div>
</template>

<script>
import Nav from "./components/_nav/Nav.vue";
export default {
  name: "app",
  components: {
    Nav
  },
};
</script>

<style>
@import url("https://fonts.googleapis.com/css?family=Montserrat:400,700");

#app {
  width: 100%;
}
.marginPrincipal {
  width: 50%;
  margin: auto;
}
body {
  background-color: #eee;
  font-family: "Montserrat", sans-serif;
  display: grid;
  /* justify-content: center; */ /*Alinhamento central de todos os componentes*/
}
body,
html {
  margin: 0;
  height: 100%;
}
.btn {
  padding: 10px 20px;
  border: 1px solid black;
  cursor: pointer;
  color: white;
  font-weight: bold;
  border-radius: 5px;
  border-bottom: 3px solid black;
}
.btn:hover {
  text-shadow: 1px 1px 1px black;
  margin-top: 3px;
  border-bottom: 1px solid black;
}
.btnRemover {
  font-size: 0.7em;
  margin-right: 10px;
  background-color: #fa4430;
}
.btnEditar {
  font-size: 0.7em;
  background-color: #3066fa;
}
.btnMaisDetalhes {
  display: flex;
  justify-content: center;
  background-color: #dce9f0;
}
table {
  margin: 0px;
  padding: 0px;
  list-style-type: none;
  width: 100%;
}
table tr td {
  padding: 20px;
  font-size: 1.3em;
  background-color: #dce9f0;
  margin-bottom: 2px;
  color: #303f3f;
}
table thead th {
  background-color: rgb(240, 147, 60) !important;
  font-size: 1.2em;
  padding: 10px 0px;
  text-align: center !important;
}
.colPequeno {
  width: 5%;
  text-align: center;
  font-weight: bold;
}
</style>
