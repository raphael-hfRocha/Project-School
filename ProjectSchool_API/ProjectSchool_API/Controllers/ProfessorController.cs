using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSchool_API.Data;
using ProjectSchool_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectSchool_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : Controller
    {
        public IRepository _repo { get; }
        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllProfessoresAsync(true);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de banco de dados");
            }
            return BadRequest();
        }

        [HttpGet("{ProfessorId}")]
        public async Task<IActionResult> GetByProfessorId(int ProfessorId)
        {
            try
            {
                var result = await _repo.GetProfessorAsyncById(ProfessorId, true);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de banco de dados");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Professor model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/professor/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de banco de dados");
            }
            return BadRequest();
        }

        [HttpPut("{ProfessorId}")]
        public async Task<IActionResult> Put(int ProfessorId, Professor model)
        {
            try
            {
                var Professor = await _repo.GetProfessorAsyncById(ProfessorId, false);
                if (Professor == null)
                {
                    return NotFound();
                }

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/api/professor/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de banco de dados");
            }
            return BadRequest();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{ProfessorId}")]
        public async Task<IActionResult> Delete(int ProfessorId)
        {
            try
            {
                var Professor = await _repo.GetProfessorAsyncById(ProfessorId, false);
                if (Professor == null)
                {
                    return NotFound();
                }

                _repo.Delete(Professor);


                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro de banco de dados");
            }
            return BadRequest();
        }
    }
}
