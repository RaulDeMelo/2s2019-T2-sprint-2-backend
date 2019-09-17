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
    public class CategoriaController : ControllerBase
    {
        // INSTANCIANDO OBJETO DE REPOSITÓRIO
        CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>Saída de resposta para confirmação da efetividade[lista de categorias]/bloqueio do código</returns>
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Categoria categoria)
        {
            try
            {
                categoriaRepositorio.Cadastrar(categoria);
                return Ok(categoriaRepositorio.Listar());
            }
            catch (Exception exe)
            {
                return BadRequest(new
                {
                    mensagem = "Não fora possível inserir o objeto de categoria desejado; depure as possíveis falhas de inscrição. " + exe.Message
                });
            }
        }

        ///
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Lista de categorias</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            try{ 
            return Ok(categoriaRepositorio.Listar());
            }
            catch(Exception ex)
            {
                return BadRequest(new {
                    mensagem = "Não fora possível efetuar a listagem dos itens correspondentes. " + ex.Message
                });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>Saída de resposta para confirmação da efetividade/bloqueio do código</returns>
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(Categoria categoria){
            try
            {
                Categoria categoriaInspecionada = categoriaRepositorio.BuscarPorId(categoria.IdCategoria);
                if (categoriaInspecionada == null)
                    return NotFound(new
                    {
                        mensagem = "Sua categoria não foi inpecionada com sucesso em nosso sistema; verifique a existência do identificador numérico inserto"
                    });

                categoriaRepositorio.Atualizar(categoria);

                return Ok(new
                {
                    messagem = "Sua categoria foi inspecionada e atualizada com sucesso."
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Um erro inesperado ao atualizar foi identificado; certifique-se se os parâmetros são correspondidos inerentemente aos valores insertos" + ex.Message
                });
            }
        }
        
    }
}
