using Microsoft.AspNetCore.Mvc;
using ProjectSchool_API.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : Controller
    {

        public ProfessorController()
        {
            
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public int Get(int AlunoId)
        {
            Aluno aluno = new Aluno();
            aluno.Id = AlunoId;
            return aluno.Id;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        /*
        */
    }
}
