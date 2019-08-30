using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;
using Senai.Ekips.WebApi.ViewModel;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase{ 

            FuncionarioRepositorio funcionarioRepositorio = new FuncionarioRepositorio();

            [HttpPost]
            public IActionResult Login(LoginViewModel login)
            {
                try
                {
                    Funcionario funcionario = funcionarioRepositorio.BuscarPorEmailESenha(login);
                    if (funcionario == null)
                        return NotFound(new { mensagem = "Email ou senha inválidos." });

                    var claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Email, funcionario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, funcionario.IdFuncionario.ToString()),
                    new Claim(ClaimTypes.Role, funcionario.IdPermissao.ToString()),
                };

                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("ekips-autenticacao"));

                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: "Ekips.WebApi",
                        audience: "Ekips.WebApi",
                        claims: claims,
                        expires: DateTime.Now.AddDays(30),
                        signingCredentials: creds);

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });

                }
                catch (Exception ex)
                {
                    return BadRequest(new { mensagem = "Erro." + ex.Message });
                }
            }
        }
    }
