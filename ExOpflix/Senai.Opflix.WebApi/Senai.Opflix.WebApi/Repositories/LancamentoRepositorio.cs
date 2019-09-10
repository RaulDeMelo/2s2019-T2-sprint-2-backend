using Microsoft.EntityFrameworkCore;
using Senai.Opflix.WebApi.Domains;
using Senai.Opflix.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebApi.Repositories
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
            using (OpflixContext ctx = new OpflixContext())
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

        /// <summary>
        /// Inpeciona por identificador numérico e atualiza, a partir da comparação-insertiva de dados, o lançamento estrito. 
        /// </summary>
        /// <param name="id"></param>
        public void Atualizar(Lancamento lancamento)
        {
            using(OpflixContext ctx = new OpflixContext())
            {
                Lancamento LancamentoInspecionado = ctx.Lancamento.FirstOrDefault(x => x.IdLancamento == lancamento.IdLancamento);
                LancamentoInspecionado.Nome = lancamento.Nome;
                ctx.Lancamento.Update(LancamentoInspecionado);
                ctx.SaveChanges();

            }
        }


    }
}
