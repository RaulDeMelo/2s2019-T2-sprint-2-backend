using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Opflix.WebApi.Domains;
using Senai.Opflix.WebApi.Repositories;

namespace Senai.Opflix.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentoController : ControllerBase
    {
        // INSTANCIANDO OBJETO DE REPOSITÓRIO
        LancamentoRepositorio lancamentoRepositorio = new LancamentoRepositorio();
        LancamentoFavoritadoRepositorio lancamentoFavoritadoRepositorio = new LancamentoFavoritadoRepositorio();

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

        /// REQUISIÇÃO PARA O MÉTODO DE CADASTRO DE ITEM-LANÇAMENTO [ROTA DE ADMINISTRADOR]
        /// <summary>
        /// Captura e insere os dados inerentes ao item-lançamento [dentro do escopo de usuário-administrador].
        /// </summary>
        /// <param name="lancamento"></param>
        /// <returns>Lista de lançamentos atualizada com inserção de item-lançamento</returns>
        [Authorize(Roles = "2")]
        [HttpPost]
        [Route("adminCad")]
        public IActionResult Cadastrar(Lancamento lancamento)
        {
            try
            {
                lancamentoRepositorio.Cadastrar(lancamento);
                return Ok(lancamentoRepositorio.Listar());
            }
            catch (Exception exe)
            {
                return BadRequest(new
                {
                    mensagem = "Não fora possível inserir o objeto de lançamento desejado; depure as possíveis falhas de inscrição. " + exe.Message
                });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Saída de resposta para confirmação da efetividade/bloqueio do código</returns>
        [Route("delecao")]
        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try { 
            lancamentoRepositorio.Deletar(id);
            return Ok(new {
                mensagem = "Seu cargo estrito foi inspecionado e deletado com sucesso."
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Seu lançamento não foi inpecionado e/ou retirado com sucesso em nosso sistema; verifique a existência do identificador numérico inserto. " + ex.Message
                });
            }
        }

        /// REQUISIÇÃO
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Lista de favoritos</returns>
        [Route("favoritos")]
        [HttpGet]
        public IActionResult ExibirFavoritos()
        {
            try
            {
                return Ok(lancamentoFavoritadoRepositorio.Listar());
            }
            catch(Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Não fora possível efetivar a exibição dos favoritos. " + ex.Message
                });
            }
        }

        ///
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("addfavor")]
        [HttpPost]
        [Authorize]
        public IActionResult CadastrarFavoritos(LancamentoFavoritado lancamentoFavoritado)
        {
            try
            {
                lancamentoFavoritadoRepositorio.Cadastrar(lancamentoFavoritado);
                return Ok(new
                {
                    mensagem = ""
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new {
                    mensagem = "" + ex.Message
                });
            }
        }
    }
}