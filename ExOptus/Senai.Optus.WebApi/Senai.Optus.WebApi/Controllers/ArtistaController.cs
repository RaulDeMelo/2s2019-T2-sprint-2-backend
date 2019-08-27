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
    public class ArtistaController : ControllerBase
    {
        ArtistaRepositorio artistaRepositorio = new ArtistaRepositorio();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(artistaRepositorio.Listar());
        }
        [HttpPost]
        public IActionResult Cadastrar(Artistas artista)
        {
            try
            {
                artistaRepositorio.Cadastrar(artista);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Não fora possível inserir o objeto de artista desejado; depure as possíveis falhas de inscrição." + ex.Message });
            }
        }
    }
}