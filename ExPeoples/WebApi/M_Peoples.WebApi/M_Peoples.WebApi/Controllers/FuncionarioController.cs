using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M_Peoples.WebApi.Domains;
using M_Peoples.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M_Peoples.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        FuncionarioRepositorio funcionarioRepositorio = new FuncionarioRepositorio();

        [HttpGet]
        public IEnumerable<FuncionarioDomain> ListarTodos()
        {
            return funcionarioRepositorio.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FuncionarioDomain funcionarioDomain = funcionarioRepositorio.BuscarPorId(id);
            if (funcionarioDomain == null)
                return NotFound();
            return Ok(funcionarioDomain);
        }
        
        [HttpPost]
        public IActionResult Inserir(FuncionarioDomain funcionarioDomain){ 
            funcionarioRepositorio.Inserir(funcionarioDomain);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            funcionarioRepositorio.Deletar(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar(FuncionarioDomain funcionarioDomain)
        {
            funcionarioRepositorio.Atualizar(funcionarioDomain);
            return Ok();
        }
    }
}