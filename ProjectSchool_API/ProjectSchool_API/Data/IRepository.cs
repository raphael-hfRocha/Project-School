using ProjectSchool_API.Models;
using System.Threading.Tasks;

namespace ProjectSchool_API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //ALUNO
        Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor);

        Task<Aluno[]> GetAlunoAsyncByProfessorId(int ProfessorId, bool includeProfessor);
        
        Task<Aluno> GetAlunoAsyncById(int AlunoId, bool includeProfessor);


        //PROFESSOR

        Task<Professor[]> GetAllProfessoresAsync(bool includeAluno);

        Task<Professor> GetProfessorAsyncById(int ProfessorId, bool includeAluno);
    }
}
