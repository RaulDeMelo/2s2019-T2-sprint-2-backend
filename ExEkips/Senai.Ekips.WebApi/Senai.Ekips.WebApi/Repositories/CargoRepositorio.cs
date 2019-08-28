using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class CargoRepositorio
    {
        /// <summary>
        /// Método para listagem da tabela Cargo do SQL server por EFCore
        /// </summary>
        /// <returns>Lista de cargos</returns>
        public List<Cargo> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Cargo.ToList();
            }
        }

        /// <summary>
        /// Captura o cargo estrito por identificador numérico
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Cargo estrito capturado por identificador numérico</returns>
        public Cargo ListarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext()){
                return ctx.Cargo.FirstOrDefault(x => x.IdCargo == id);
            }
        }

        /// <summary>
        /// Insere um cargo a partir do escopo 'CargoDomain' - (Nome, Ativo)
        /// </summary>
        /// <param name="cargo"></param>
        public void Cadastrar(Cargo cargo)
        {
            using(EkipsContext ctx = new EkipsContext())
            {
                ctx.Cargo.Add(cargo);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Realiza a inspeção por identificador numérico, por conseguinte a deleção do cargo estrito 
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using(EkipsContext ctx = new EkipsContext())
            {
                Cargo cargoPesquisado = ctx.Cargo.Find(id);
                ctx.Cargo.Remove(cargoPesquisado);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Realiza a inspeção por identificador numérico, por conseguinte a atualização do cargo estrito
        /// </summary>
        /// <param name="cargo"></param>
        public void Atualizar(Cargo cargo)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Cargo cargoPesquisado = ctx.Cargo.FirstOrDefault(x => x.IdCargo == cargo.IdCargo);
                cargoPesquisado.Nome = cargo.Nome;
                ctx.Cargo.Update(cargoPesquisado);
                ctx.SaveChanges();
            }
        }
    }
}
