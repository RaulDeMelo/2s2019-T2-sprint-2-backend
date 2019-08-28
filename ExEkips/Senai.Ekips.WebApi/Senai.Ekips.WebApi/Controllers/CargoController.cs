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
    public class CargoController : ControllerBase
    {
        // INSTANCIAR OBJETO CARGO DE REPOSITÓRIO
        CargoRepositorio cargoRepositorio = new CargoRepositorio();
           
        /// <summary>
        /// Método para a listagem de cargos, a partir da tabela do SQL
        /// </summary>
        /// <returns>Lista completa de cargos</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(cargoRepositorio.Listar());
        }

        /// <summary>
        /// Método para listagem individual de cargo por identificador numérico
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Cargo estrito por Id</returns>
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            Cargo cargoPesquisado = cargoRepositorio.ListarPorId(id);
            if (cargoPesquisado == null)
            return NotFound(new { mensagem = "Seu cargo não foi inspecionado com sucesso; verifique a existência do identificador numérico inserto." });
            return Ok(cargoPesquisado);
        }

        /// <summary>
        /// Método para cadastrar individualmente um cargo
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns>Lista de cargos atual ou advertência sobre a funcionalidade do método</returns>
        [HttpPost]
        public IActionResult Cadastrar(Cargo cargo)
        {
            try
            { 
                cargoRepositorio.Cadastrar(cargo);
                return Ok(cargoRepositorio.Listar());
            } catch(Exception exception)
            {
                return BadRequest(new
                {
                    mensagem = "Não fora possível inserir o objeto de cargo desejado; depure as possíveis falhas de inscrição." + exception.Message
                });
            }
        }

        /// <summary>
        /// Método para deletar um cargo estrito
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Advertência sobre a funcionalidade do método</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                cargoRepositorio.Deletar(id);
                return Ok(new {
                    mensagem = "Seu cargo estrito foi inspecionado e deletado com sucesso."
                });
            } catch(Exception exception)
            {
                return BadRequest(new
                {
                    mensagem = "Seu cargo não foi inpecionado e/ou retirado com sucesso em nosso sistema; verifique a existência do identificador numérico inserto." + exception.Message
                });
            }
        }

        /// <summary>
        /// Método para inspeção por identificador numérico e atualização de dado por cargo estrito
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns>Advertência sobre a funcionalidade do método</returns>
        [HttpPut]
        public IActionResult Atualizar(Cargo cargo)
        {
            try
            {
                Cargo cargoPesquisado = cargoRepositorio.ListarPorId(cargo.IdCargo);
                if (cargoPesquisado == null)
                    return NotFound(new
                    {
                        mensagem = "Seu cargo não foi inpecionado com sucesso em nosso sistema; verifique a existência do identificador numérico inserto"
                    });

                cargoRepositorio.Atualizar(cargo);

                return Ok(new
                {
                    messagem = "Seu cargo foi inspecionado e atualizado com sucesso."
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
    }
}
