using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Opflix.WebAPII.Domains;
using Senai.Opflix.WebAPII.Repositories;

namespace Senai.Opflix.WebAPII.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentoController : ControllerBase
    {
        // INSTANCIANDO OBJETO DE REPOSITÓRIO
        LancamentoRepositorio lancamentoRepositorio = new LancamentoRepositorio();

        // REQUISIÇÃO PARA O MÉTODO DE LISTAGEM DE ITENS DE LANÇAMENTO
        /// <summary>
        /// Evoca o método presente no repositório para listagem da tabela Lancamento.
        /// </summary>
        /// <returns>Lista de lançamentos</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(lancamentoRepositorio.Listar());
        }

        // [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Lancamento lancamento)
        {
            try
            {
                lancamentoRepositorio.Cadastrar(lancamento);
                return Ok(lancamentoRepositorio.Listar());
            } catch (Exception exe)
            {
                return BadRequest(new { mensagem = "Não fora possível inserir o objeto de lançamento desejado; depure as possíveis falhas de inscrição. " + exe.Message });
            }
        }

    }
}