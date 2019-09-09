using Microsoft.EntityFrameworkCore;
using Senai.Opflix.WebAPII.Domains;
using Senai.Opflix.WebAPII.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebAPII.Repositories
{
    public class LancamentoRepositorio : ILancamentoRepositorio
    {
        // MÉTODO PARA LISTAGEM DE ITENS DE LANÇAMENTO
        /// <summary>
        /// Evoca, a partir do Framework, a tabela de Lancamento do banco de dados do SQL
        /// </summary>
        /// <returns>Lista de lançamentos</returns>
        public List<Lancamento> Listar()
        {
            using (OpflixContext ctx = new OpflixContext())
            {
                return ctx.Lancamento.ToList();
            }
        }

        /// MÉTODO PARA INSERÇÃO DE ITEM-LANÇAMENTO NO BANCO DE DADOS
        /// <summary>
        /// Captura os dados externos inerentes ao objeto de lançamento os insere no banco de dados do SQL.
        /// </summary>
        /// <param name="lancamento"></param>
        public void Cadastrar(Lancamento lancamento)
        {
            using(OpflixContext ctx = new OpflixContext())
            {
                ctx.Lancamento.Add(lancamento);
                ctx.SaveChanges();
            }
        }

        /// MÉTODO DE INSPEÇÃO POR IDENTIFICADOR NUMÉRICO E CAPTURA DE ITEM-LANÇAMENTO ESTRITO
        /// <summary>
        /// Inspeciona por identificador numérico e retorna, porventura capture, o item-lançamento estrito no banco de dados do SQL.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Item-lançamento estrito</returns>
        public Lancamento BuscarPorId(int id)
        {
            using(OpflixContext ctx = new OpflixContext())
            {
                return ctx.Lancamento.FirstOrDefault(x => x.IdLancamento == id);
            }
        }


    }
}
