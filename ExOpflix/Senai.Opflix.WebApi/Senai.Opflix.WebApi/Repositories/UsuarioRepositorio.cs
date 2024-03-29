﻿using Senai.Opflix.WebApi.Domains;
using Senai.Opflix.WebApi.Interface;
using Senai.Opflix.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebApi.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        /// MÉTODO PARA BUSCA E AUTENTICAÇÃO DE USUÁRIOS
        /// <summary>
        /// Compara o usuário-objeto-instanciado com o banco de dados SQL, retornando a (não) autenticação do mesmo.
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Usuário (não) autenticado</returns>
        public Usuario AutenticarPorBusca(Autenticador login)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                Usuario usuarioInspecionado = ctx.Usuario.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (usuarioInspecionado == null)
                {
                    return null;
                }
                return usuarioInspecionado;
            }
        }

        /// MÉTODO PARA CADASTRO DE USUÁRIO
        /// <summary>
        /// Captura o item-usuário e opera a inserção do dado dentro do banco de dados [As respectivas autorizações são validadas no espectro do Controller respectivo].
        /// </summary>
        /// <param name="usuario"></param>
        public void Cadastrar(Usuario usuario)
        {
            using(OpflixContext ctx = new OpflixContext())
            {
                ctx.Usuario.Add(usuario);
                ctx.SaveChanges();
            }
        }
    }
}
