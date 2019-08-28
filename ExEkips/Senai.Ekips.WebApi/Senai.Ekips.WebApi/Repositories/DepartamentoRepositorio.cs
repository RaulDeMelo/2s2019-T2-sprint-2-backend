using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class DepartamentoRepositorio
    {
        /// <summary>
        /// Método para listagem da tabela Departamento do SQL server por EFCore
        /// </summary>
        /// <returns>Lista de departamentos</returns>
        public List<Departamento> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Departamento.ToList();
            }
        }

        /// <summary>
        /// Captura o departamento estrito por identificador numérico
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Departamento estrito capturado por identificador numérico</returns>
        public Departamento ListarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Departamento.FirstOrDefault(x => x.IdDepartamento == id);
            }
        }

        /// <summary>
        /// Insere um departamento a partir do escopo 'DepartamentoDomain' - (Nome)
        /// </summary>
        /// <param name="departamento"></param>
        public void Cadastrar(Departamento departamento)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Departamento.Add(departamento);
                ctx.SaveChanges();
            }
        }
    }
}
