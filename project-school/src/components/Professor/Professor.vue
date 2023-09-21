<template>
  <div>
    <titulo texto="Professores" btn-voltar="true"/>
    <div>
      <!-- <input
        type="text"
        placeholder="Nome do professor"
        v-model="nome"
        @keyup.enter="addprofessor()"
      />
      <button class="btn btnInput" @click="addprofessor()">Adicionar</button> -->
    </div>
    <br />
    <table>
      <thead>
        <th>Cód.</th>
        <th style="width: 35%;">Nome</th>
        <th style="width: 20%;">Alunos</th>
      </thead>
      <tbody v-if="Professores.length">
        <tr v-for="(professor, index) in Professores" :key="index">
          <td class="colPequeno" style="width: 5%;">{{ professor.id }}</td>
          <td>{{ professor.nome }} {{ professor.sobrenome }}</td>
          <td style="display: flex; justify-content: center;">
          <router-link :to="`/alunos/${ professor.id }`" tag="button" class="btn btnDetalhes">
            Mais detalhes
          </router-link>
        </td>
        </tr>
      </tbody>
      <tfoot v-else>
        <tr>
          <td colspan="3" style="text-align: center;">
            <h4>Nenhum professor encontrado</h4>
          </td>
        </tr>
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo.vue";
export default {
  components: { Titulo },
  data() {
    return {
      Professores: [],
      Alunos: []
    };
  },
  created() {
    this.$http.get('http://localhost:5000/api/aluno')
    .then(res => res.json())
    .then(alunos => {
      this.Alunos = alunos;
      this.carregarProfessores();
    })
  },
  props: {

  }, 
  methods: {
    // pegarQtdAlunosPorProfessor() {
    //   this.Professores.forEach((professor, index) => {
    //     professor = {
    //       id: professor.id,
    //       nome: professor.nome,
    //       qtdAlunos: this.Alunos.filter(aluno => 
    //         aluno.professor.id == professor.id
    //       ).length
    //     }
    //     this.Professores[index] = professor;
    //   });
    // },
      carregarProfessores() {
        this.$http
        .get("http://localhost:5000/api/professor")
        .then(res => res.json())
        .then(professor => {
          this.Professores = professor
          // this.pegarQtdAlunosPorProfessor();
        }) 
      }
    },
  }
</script>

<style scoped>
input {
  width: calc(100% - 195px);
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  color: #687f7f;
  display: inline;
}
.btnDetalhes {
  font-size: 0.7em;
  background-color: hsla(283, 100%, 50%, 0.992);
}
.btnInput {
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
</style>