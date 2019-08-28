using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class FuncionarioRepositorio
    {
        /// <summary>
        /// Método para listagem da tabela Funcionario do SQL server por EFCore
        /// </summary>
        /// <returns>Lista de funcionários</returns>
        public List<Funcionario> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Funcionario.ToList();
            }
        }

        /// <summary>
        /// Insere um funcionario a partir do escopo 'FuncionarioDomain' - (Nome, Email, Senha, Cpf, Salario, IdCargo, IdDepartamento, IdPermissao)
        /// </summary>
        /// <param name="funcionario"></param>
        public void Cadastrar(Funcionario funcionario)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Funcionario.Add(funcionario);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Realiza a inspeção por identificador numérico, por conseguinte a deleção do funcionario estrito 
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionario funcionarioPesquisado = ctx.Funcionario.Find(id);
                ctx.Funcionario.Remove(funcionarioPesquisado);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Realiza a inspeção por identificador numérico, por conseguinte a atualização do funcionario estrito
        /// </summary>
        /// <param name="funcionario"></param>
        public void Atualizar(Funcionario funcionario)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionario funcionarioPesquisado = ctx.Funcionario.FirstOrDefault(x => x.IdFuncionario == funcionario.IdFuncionario);
                funcionarioPesquisado.Nome = funcionario.Nome;
                ctx.Funcionario.Update(funcionarioPesquisado);
                ctx.SaveChanges();
            }
        }
    }
}