using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;

namespace Senai.Optus.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstiloController : ControllerBase
    {
        EstiloRepositorio estiloRepositorio = new EstiloRepositorio();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(estiloRepositorio.Listar());
        }
        [HttpPost]
        public IActionResult Cadastrar(Estilos estilo)
        {
            try
            {
                estiloRepositorio.Cadastrar(estilo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "deu bosta." + ex.Message });
            }
        }
    }
}