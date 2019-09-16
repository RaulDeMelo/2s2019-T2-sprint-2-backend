using Senai.Opflix.WebApi.Domains;
using Senai.Opflix.WebApi.Interface;
using Senai.Opflix.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebApi.Repositories
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        /// MÉTODO PARA INSERÇÃO DE ITEM-CATEGORIA NO BANCO DE DADOS
        /// <summary>
        /// Captura os dados externos inerentes ao categoria-objeto os insere no banco de dados do SQL.
        /// </summary>
        /// <param name="categoria"></param>
        public void Cadastrar(Categoria categoria)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                ctx.Categoria.Add(categoria);
                ctx.SaveChanges();
            }
        }
     }
}
