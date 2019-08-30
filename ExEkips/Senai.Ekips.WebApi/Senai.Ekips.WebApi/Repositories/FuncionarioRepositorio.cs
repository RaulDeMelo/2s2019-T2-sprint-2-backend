using Microsoft.EntityFrameworkCore;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class FuncionarioRepositorio
    {
        /// <summary>
        /// Captura o funcionário estrito por identificador numérico
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Funcionário estrito capturado por identificador numérico</returns>
        public Funcionario ListarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Funcionario.FirstOrDefault(x => x.IdFuncionario == id);
            }
        }

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

        /// <summary>
        /// Inspeciona e compara, ante os dados de Email e senha do usuário/funcionário, sua respectiva autenticação e autorização concebida.
        /// </summary>
        /// <param name="login"></param>
        /// <returns>Usuario autenticado/autorizado</returns>
        public Funcionario BuscarPorEmailESenha(LoginViewModel login)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionario UsuarioBuscado = ctx.Funcionario.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (UsuarioBuscado == null)
                {
                    return null;
                }
                return UsuarioBuscado;
            }
        }
        public List<Funcionario> ListarCorrelacao()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Funcionario.Include(x => x.IdFuncionario).FromSql("select F.Nome as NomeDoFuncionario, C.Nome as Cargo, D.Nome as Departamento from Funcionario as F inner join Cargo as C on C.IdCargo = F.IdCargo join Departamento as D on D.IdDepartamento = F.IdDepartamento").ToList();
            }
        }
    }
}