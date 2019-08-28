using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class UsuarioRepositorio
    {
        // MÉTODO PARA BUSCA E AUTENTICAÇÃO DE USUÁRIOS
        /// <summary>
        /// Compara o usuário-objeto-instanciado com o banco de dados SQL, retornando a (não) autenticação do mesmo.
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Usuário (não) autenticado</returns>
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Usuarios usuarioBuscado = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (usuarioBuscado == null)
                {
                    return null;
                }
                return usuarioBuscado;
            }
        }
    }
}