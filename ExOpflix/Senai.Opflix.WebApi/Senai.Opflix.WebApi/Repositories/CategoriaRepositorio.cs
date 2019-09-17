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
        /// MÉTODO PARA LISTAGEM DE ITENS DE CATEGORIA
        /// <summary>
        /// Evoca, a partir do Framework, a tabela de Categoria do banco de dados do SQL
        /// </summary>
        /// <returns>Lista de categorias</returns>
        public List<Categoria> Listar()
        {
            using(OpflixContext ctx = new OpflixContext())
            {
                return ctx.Categoria.ToList();
            }
        }

        /// MÉTODO DE INSPEÇÃO POR IDENTIFICADOR NUMÉRICO E CAPTURA DE ITEM-CATEGORIA ESTRITO
        /// <summary>
        /// Inspeciona por identificador numérico e retorna, porventura capture, o item-categoria estrito no banco de dados do SQL.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Item-categoria estrito</returns>
        public Categoria BuscarPorId(int id)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                return ctx.Categoria.FirstOrDefault(x => x.IdCategoria == id);
            }
        }

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

        /// MÉTODO PARA INSPEÇÃO DE IDENTIFICADOR NUMÉRICO E ATUALIZAÇÃO DE ITEM-CATEGORIA ESTRITO
        /// <summary>
        /// Inpeciona por identificador numérico e atualiza, a partir da comparação-insertiva de dados, o item-categoria estrito. 
        /// </summary>
        /// <param name="id"></param>
        public void Atualizar(Categoria categoria)
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                Categoria categoriaInspecionada = ctx.Categoria.FirstOrDefault(x => x.IdCategoria == categoria.IdCategoria);
                categoriaInspecionada.Nome = categoria.Nome;
                ctx.Categoria.Update(categoriaInspecionada);
                ctx.SaveChanges();
            }
        }


    }
}
