using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        // INSTANCIAR OBJETO DEPARTAMENTO DE REPOSITÓRIO
        DepartamentoRepositorio departamentoRepositorio = new DepartamentoRepositorio();

        /// <summary>
        /// Método para a listagem de departamentos, a partir da tabela do SQL
        /// </summary>
        /// <returns>Lista completa de departamentos</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(departamentoRepositorio.Listar());
        }

        /// <summary>
        /// Método para listagem individual de departamento por identificador numérico
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Departamento estrito por Id</returns>
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            Departamento departamentoPesquisado = departamentoRepositorio.ListarPorId(id);
            if (departamentoPesquisado == null)
                return NotFound(new { mensagem = "Seu departamento não foi inspecionado com sucesso; verifique a existência do identificador numérico inserto." });
            return Ok(departamentoPesquisado);
        }

        /// <summary>
        /// Método para cadastrar individualmente um departamento
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns>Lista de departamento atual ou advertência sobre a funcionalidade do método</returns>
        [HttpPost]
        public IActionResult Cadastrar(Departamento departamento)
        {
            try
            {
                departamentoRepositorio.Cadastrar(departamento);
                return Ok(departamentoRepositorio.Listar());
            }
            catch (Exception exception)
            {
                return BadRequest(new
                {
                    mensagem = "Não fora possível inserir o objeto de departamento desejado; depure as possíveis falhas de inscrição." + exception.Message
                });
            }
        }
    }
}