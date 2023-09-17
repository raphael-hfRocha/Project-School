<template>
  <div class="barraTop">
    <nav class="marginPrincipal">
      <router-link to="/professores">Professores</router-link>
      <router-link to="/todosalunos">Alunos</router-link>
      <router-link to="/sobre">Sobre</router-link> 
    </nav>
  </div>
</template>

<script>
export default {};
</script>

<style scoped>
.barraTop {
  background-color: rgb(230, 230, 230);
}
nav {
    padding: 20px 20px 20px 0px;
}
nav a {
    padding: 10px;
    text-decoration: none;
    background-color: #fff;
    border-radius: 3px;
    color: black;
    font-weight: bold;
    margin-right: 15px;
}
/* nav a:hover {
    background-color: rgb(240, 147, 60);
} */
nav .router-link-exact-active {
    background-color: rgb(240, 147, 60);
}
</style>