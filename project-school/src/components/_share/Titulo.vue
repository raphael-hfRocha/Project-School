<template>
  <div>
    <div style="display: flex; width: 100%; justify-content: space-between; ">
      <h1>{{ texto }}</h1>
      <div class="voltar">
        <slot></slot>
        <button v-show="btnVoltar" class="btn btnVoltar" @click="voltar()">Voltar</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    texto: String,
    btnVoltar: Boolean
  },
  methods: {
    voltar() {
        this.$router.back();
    }
  }
};
</script>

<style>
.Voltar {
  width: 50%;
  position: relative;
  margin-top: 15px;
  bottom: 15px;
}
.btnVoltar {
  font-size: 1.2em;
  float: right;
  background-color: rgb(175, 175, 175);
}
</style>