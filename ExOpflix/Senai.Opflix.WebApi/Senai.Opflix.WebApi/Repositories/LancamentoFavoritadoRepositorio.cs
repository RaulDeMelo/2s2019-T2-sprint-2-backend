using Senai.Opflix.WebApi.Domains;
using Senai.Opflix.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebApi.Repositories
{
    public class LancamentoFavoritadoRepositorio : ILancamentoFavoritadoRepositorio
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Lista de favoritos</returns>
        public List<LancamentoFavoritado> Listar()
        {
            using(OpflixContext ctx = new OpflixContext())
            {
                return ctx.LancamentoFavoritado.ToList();
            }
        }

        ///
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lancamentoFavoritado"></param>
        public void Cadastrar(LancamentoFavoritado lancamentoFavoritado)
        {
            using(OpflixContext ctx = new OpflixContext())
            {
                ctx.LancamentoFavoritado.Add(lancamentoFavoritado);
                ctx.SaveChanges();
            }
        }
    }
}
