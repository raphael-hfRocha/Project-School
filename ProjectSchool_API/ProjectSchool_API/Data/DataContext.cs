using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Models;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ProjectSchool_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            List<Professor> professores = new List<Professor>()
                        {
                            new Professor()
                            {
                                Id = 1,
                                Nome = "Vinicius"
                            },
                            new Professor()
                            {
                                Id = 2,
                                Nome = "Paula"
                            },
                            new Professor()
                            {
                                Id = 3,
                                Nome = "Luna"
                            },
                        };



            builder.Entity<Professor>()

                    .HasData(professores.ToArray()

                    );


            List<Aluno> alunos = new List<Aluno>()
                        {
                            new Aluno()
                            {
                                Id = 1,
                                Nome = "Maria",
                                Sobrenome = "José",
                                DataNasc = "01/01/2000",
                                ProfessorId = 1
                            },
                            new Aluno()
                            {
                                Id = 2,
                                Nome = "João",
                                Sobrenome = "Paulo",
                                DataNasc = "20/01/1980",
                                ProfessorId = 2
                            },
                            new Aluno()
                            {
                                Id = 3,
                                Nome = "Alex",
                                Sobrenome = "Ferraz",
                                DataNasc = "25/06/1981",
                                ProfessorId = 3
                            },
                        };
                   

            builder.Entity<Aluno>()

                    .HasData(alunos.ToArray() );
                      
                
        }

    }
}
