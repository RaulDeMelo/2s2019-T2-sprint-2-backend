using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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
                return BadRequest(new { mensagem = "Não fora possível inserir o objeto de estilo desejado; depure as possíveis falhas de inscrição." + ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Estilos estilo = estiloRepositorio.BuscarPorId(id);
            if (estilo == null)
            return NotFound(new {
                mensagem = "Seu estilo não foi inpecionado com sucesso em nosso sistema; depure as possíveis falhas de inscrição, doravante a existência digital do ID respectivo."
            });
            return Ok(estilo);
        }

        [HttpPut]
        public IActionResult Atualizar(Estilos estilo)
        {
            try
            {
                Estilos estiloBuscado = estiloRepositorio.BuscarPorId(estilo.IdEstilo);
                if (estiloBuscado == null)
                    return NotFound( new {
                    mensagem = "Seu estilo não foi inpecionado com sucesso em nosso sistema; verifique a existência do identificador numérico inserto"
                    });

                estiloRepositorio.Atualizar(estilo);

                return Ok(new
                {
                    messagem = "Show de bola!"
                });
            }
            catch ( Exception ex )
            {
                return BadRequest(new
                {
                    mensagem = "Um erro inesperado ao atualizar foi identificado; certifique-se se os parâmetros são correspondidos inerentemente aos valores insertos" + ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            estiloRepositorio.Deletar(id);
            return Ok();
        }

    }
}