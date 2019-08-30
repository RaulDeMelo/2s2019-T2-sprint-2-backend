using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtivoController : ControllerBase
    {
        // INSTANCIAR OBJETO CARGO DE REPOSITÓRIO
        CargoRepositorio cargoRepositorio = new CargoRepositorio();

        /// <summary>
        /// Invoca método para listagem de cargos ativos
        /// </summary>
        /// <returns>Lista de cargos ativos</returns>
        [HttpGet]
        public IActionResult ListarAtivos()
        {
            return Ok(cargoRepositorio.ListarAtivos());
        }
    }
}