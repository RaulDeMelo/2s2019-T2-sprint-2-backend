using Senai.Opflix.WebAPII.Domains;
using Senai.Opflix.WebAPII.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebAPII.Repositories
{
    public class UsuarioRepositorio
    {
        // MÉTODO PARA BUSCA E AUTENTICAÇÃO DE USUÁRIOS
        /// <summary>
        /// Compara o usuário-objeto-instanciado com o banco de dados SQL, retornando a (não) autenticação do mesmo.
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Usuário (não) autenticado</returns>
        public Usuario AutenticarPorBusca(Autenticador login)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (usuarioBuscado == null)
                {
                    return null;
                }
                return usuarioBuscado;
            }
        }
    }
}
