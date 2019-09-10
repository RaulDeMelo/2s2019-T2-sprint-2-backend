using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Opflix.WebApi.Domains;
using Senai.Opflix.WebApi.Repositories;
using Senai.Opflix.WebApi.ViewModel;

namespace Senai.Opflix.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // INSTANCIANDO OBJETO DE REPOSITÓRIO
        UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();

        /// <summary>
        /// Método para captura de dados de usuário insertos no banco de dados e a (não) autenticação do mesmo - inerente ao escopo de permissão admitido pelo identificador numérico.
        /// </summary>
        /// <param name="autenticador"></param>
        /// <returns>Bearer Token inerente ao escopo de autenticação-permissão admitido pelo identificador numérico de tipo de usuário.</returns>
        [HttpPost]
        public IActionResult Autenticar(Autenticador autenticador)
        {
            try
            {
                Usuario usuario = usuarioRepositorio.AutenticarPorBusca(autenticador);
                if (usuario == null)
                return NotFound(new { mensagem = "A inspeção do usuário não fora efetivada com sucesso; depure as possíveis falhas de inscrição. " });
                  
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuario.IdTipoUsuario.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("opflix-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Opflix.WebApi",
                    audience: "Opflix.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            } catch(Exception ex)
            {
                return BadRequest(new
                {
                    Mensagem = "A autenticação não fora efetivada com sucesso; depure a existência de um mesmo item para a consignação inequívoca. " + ex.Message
                });
            }
        }
    }
}