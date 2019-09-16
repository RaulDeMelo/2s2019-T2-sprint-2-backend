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
        //
        CategoriaRepositorio categoriaRepositorio = new CategoriaRepositorio();
        
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
    }
}
