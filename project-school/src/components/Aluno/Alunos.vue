<template>
  <div>
    <titulo :texto="professorid != undefined ? `Professor(a): ${professor.nome}` : 'Todos os alunos'" btnVoltar="true" />
    <div v-if="professorid != undefined">
      <input type="text" placeholder="Nome do Aluno" v-model="nome" @keyup.enter="addAluno()">
      <button class="btn btnInput" @click="addAluno()">Adicionar</button>
    </div>
    <br>
    <table>
    <thead>
      <th style="width: 7%;">Matr.</th>
      <th style="width: 25%;">Nome</th>
      <th style="width: 17%;">Opções</th>
    </thead>
    <tbody v-if="alunos.length">
      <tr v-for="(aluno, index) in alunos" :key="index">
        <td class="colPequeno" style="text-align: center;">{{ aluno.id }}</td>
        <td>{{ aluno.nome }} {{ aluno.sobrenome }}</td>
        <td>
          <div class="botoesDelUp">
            <button class="btn btnRemover" @click="remover(aluno)">Remover</button>
          <router-link :to="`/alunoDetalhe/${aluno.id}`" tag="button" class="btn btnEditar">
            Editar
          </router-link>
          </div>
        </td>
      </tr>
    </tbody>
    <tfoot v-else>
        <tr>
          <td colspan="3" style="text-align: center;">
            <h4>Nenhum aluno encontrado</h4>
          </td>
        </tr>
      </tfoot>
  </table>
</div>
</template>

<script>
import Titulo from '../_share/Titulo.vue';

export default {
  components: {
    Titulo
  },
  data() {
    return {
      titulo: "Aluno",
      professorid: this.$route.params.prof_id,
      professor: {},
      nome: "",
      alunos: [],
    }
  },
  created() {
    if(this.professorid) {
      this.carregarProfessores();
      this.$http.get(`http://localhost:5000/api/aluno/ByProfessor/${this.professorid}`)
      .then(res => res.json())
      .then(alunos => this.alunos = alunos)
    } 
    else {
      this.$http.get('http://localhost:5000/api/aluno')
      .then(res => res.json())
      .then(alunos => this.alunos = alunos)
    }
  },
  props: {},
  methods: {
    addAluno() {
      let _aluno = { 
        nome: this.nome,
        sobrenome: "",
        dataNasc: "",
        professorid: this.professor.id,        
      }

      this.$http.post('http://localhost:5000/api/aluno', _aluno)
      .then(res => res.json())
      .then(aluno => {
        this.alunos.push(aluno);
        this.nome = "";
      })

    },
    // editar(aluno) {
    //   this.$http
    //   .update(`http://localhost:5000/alunoDetalhe/${aluno.id}`)
    //   .then(() => {
    //     let indice = this.alunos.indexOf(aluno);
    //     this.alunos.splice(indice, 1);
    //   })
    //  },
     remover(aluno) {
      this.$http
      .delete(`http://localhost:5000/api/aluno/${aluno.id}`)
      .then(() => {
        let indice = this.alunos.indexOf(aluno);
        this.alunos.splice(indice, 1);
      })
     },
     carregarProfessores() {
        this.$http
        .get("http://localhost:5000/api/professor/" + this.professorid)
        .then(res => res.json())
        .then(professor => {
          this.professor = professor
        }) 
    }
  }
};
</script>
<style scoped>
input {
  width: calc(100% - 195px);
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  color: #687f7f;
  display: inline;
}.btnInput {
  width: 150px;
  border: 0px;
  padding: 20px;
  font-size: 1.3em;
  display: inline;
  background-color: rgb(116, 115, 115);
}
.btnInput:hover {
  padding: 20px;
  margin: 0px;
  border: 0px;
}
.botoesDelUp {
  display: flex;
  justify-content: center;
}
</style>