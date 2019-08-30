using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        // INSTANCIAR OBJETO FUNCIONÁRIO DE REPOSITÓRIO
        FuncionarioRepositorio funcionarioRepositorio = new FuncionarioRepositorio();

        /// <summary>
        /// Método para a listagem de funcionários, a partir da tabela do SQL
        /// </summary>
        /// <returns>Lista completa de funcionários</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(funcionarioRepositorio.Listar());
        }

        /// <summary>
        /// Método para cadastrar individualmente um funcionário
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns>Lista de funcionários atual ou advertência sobre a funcionalidade do método</returns>
        [HttpPost]
        public IActionResult Cadastrar(Funcionario funcionario)
        {
            try
            {
                funcionarioRepositorio.Cadastrar(funcionario);
                return Ok(funcionarioRepositorio.Listar());
            }
            catch (Exception exception)
            {
                return BadRequest(new
                {
                    mensagem = "Não fora possível inserir o objeto de funcionário desejado; depure as possíveis falhas de inscrição." + exception.Message
                });
            }
        }

        /// <summary>
        /// Método para deletar um funcionário estrito
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Advertência sobre a funcionalidade do método</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                funcionarioRepositorio.Deletar(id);
                return Ok(new
                {
                    mensagem = "Seu funcionário estrito foi inspecionado e deletado com sucesso."
                });
            }
            catch (Exception exception)
            {
                return BadRequest(new
                {
                    mensagem = "Seu funcionário não foi inpecionado e/ou retirado com sucesso em nosso sistema; verifique a existência do identificador numérico inserto." + exception.Message
                });
            }
        }

        /// <summary>
        /// Método para inspeção por identificador numérico e atualização de dado por funcionário estrito
        /// </summary>
        /// <param name="funcionario"></param>
        /// <returns>Advertência sobre a funcionalidade do método</returns>
        [HttpPut]
        public IActionResult Atualizar(Funcionario funcionario)
        {
            try
            {
                Funcionario funcionarioPesquisado = funcionarioRepositorio.ListarPorId(funcionario.IdFuncionario);
                if (funcionarioPesquisado == null)
                    return NotFound(new
                    {
                        mensagem = "Seu funcionário não foi inpecionado com sucesso em nosso sistema; verifique a existência do identificador numérico inserto"
                    });

                funcionarioRepositorio.Atualizar(funcionario);

                return Ok(new
                {
                    messagem = "Seu funcionário foi inspecionado e atualizado com sucesso."
                });
            }
            catch (Exception exception)
            {
                return BadRequest(new
                {
                    mensagem = "Um erro inesperado ao atualizar foi identificado; certifique-se se os parâmetros são correspondidos inerentemente aos valores insertos" + exception.Message
                });
            }
        }

        [HttpGet("AdminList")]
        [Authorize(Roles = "2")]
        public IActionResult ListarCorrelacao()
        {
            return Ok(funcionarioRepositorio.ListarCorrelacao());
        }
    }
}