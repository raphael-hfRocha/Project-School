<template>
  <div v-if="!loading">
    <titulo :texto="`Aluno(a): ${aluno.nome} ${aluno.sobrenome}`" :btnVoltar="!visualizando">
      <button v-show="visualizando" class="btn btnEditar2" @click="editar()">Editar</button>
    </titulo>
    <table>
      <tbody>
        <tr>
          <td class="colPequeno">Matrícula:</td>
          <td>
            <label>{{ aluno.id }}</label>
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Nome:</td>
          <td>
            <label v-if="visualizando">{{ aluno.nome }}</label>
            <input v-else v-model="aluno.nome" type="text">
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Sobrenome:</td>
          <td>
            <label v-if="visualizando">{{ aluno.sobrenome }}</label>
            <input v-else v-model="aluno.sobrenome" type="text">
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Data de nascimento:</td>
          <td>
            <label v-if="visualizando">{{ aluno.dataNasc }}</label>
            <input v-else v-model="aluno.dataNasc" type="text">
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Professor:</td>
          <td>
            <label v-if="visualizando">{{ aluno.professor.nome }}</label>
            <select v-else v-model="aluno.professor.id">
              <option v-for="(professor, index) in professores" :key="index" v-bind:value="professor.id">
                {{professor.nome}}
              </option>
            </select>
          </td>
        </tr> 
      </tbody>
    </table>

    <div style="margin-top: 10px;">
      <div v-if="!visualizando">
        <button class="btn btnSalvar" @click="salvar(aluno)">Salvar</button>
        <button class="btn btnCancelar" @click="cancelar()">Cancelar</button>
      </div>
    </div>

  </div>
</template>

<script>
import Titulo from "./../_share/Titulo.vue";
export default {
  components: {
    Titulo,
  },
  data() {
    return {
      professores: [],
      aluno: {},
      idAluno: this.$route.params.id,
      visualizando: true,
      loading: true
    };
  },
  created() {
    this.carregarProfessor();
  },
  methods: {
    carregarProfessor() {
      this.$http
        .get("http://localhost:5000/api/professor")
        .then(res => res.json())
        .then(professor => {
          this.professores = professor;
          this.carregarAluno();
        });
    },
    carregarAluno() {
      this.$http
        .get(`http://localhost:5000/api/aluno/${this.idAluno}`)
        .then(res => res.json())
        .then(aluno => {
          this.aluno = aluno;
          this.loading = false;
        });
    },
    editar() {
      this.visualizando = !this.visualizando;
    },
    salvar(_aluno) {
      let _alunoEditar = {
        id: _aluno.id,
        nome: _aluno.nome,
        sobrenome: _aluno.sobrenome,
        dataNasc: _aluno.dataNasc,
        professorid: _aluno.professor.id
      }
      this.$http
        .put(`http://localhost:5000/api/aluno/${_alunoEditar.id}`, _alunoEditar)
        .then(res => res.json())
        .then(aluno => this.aluno = aluno)
        .then(() => this.visualizando = true);

      this.visualizando = !this.visualizando;
    },
    cancelar() {
      this.visualizando = !this.visualizando;
    }
  },
};
</script>

<style scoped>
.btnEditar2 {
  font-size: 0.8em;
  float: right;
  background-color: rgb(49, 166, 233);
}
.btnSalvar {
  font-size: 1.2em;
  float: right;
  margin-left: 10px;
  background-color: rgb(79, 196, 68);
}
.btnCancelar {
  font-size: 1.2em;
  float: right;
  background-color: rgb(255, 157, 77);
}
.colPequeno {
  width: 20%;
  text-align: right;
  background-color: rgb(101, 213, 247);
  font-weight: bold;
}
input, select {
  margin: 0px;
  padding: 5px 10px;
  font-size: 0.9em;
  border: 1px solid silver;
  border-radius: 5px;
  font-family: Montserrat;
  width: 95%;
  background-color: rgb(245, 245, 245);
}
select {
  height: 38px;
  width: 100%;
}
</style>
