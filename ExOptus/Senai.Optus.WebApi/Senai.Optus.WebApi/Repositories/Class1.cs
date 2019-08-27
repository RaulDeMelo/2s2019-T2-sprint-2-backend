using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class EstiloRepositorio
    {
        // MÉTODO PARA LISTAGEM DE ESTILOS
        /// <summary>
        /// Invoca a tabela de estilos do SQL
        /// </summary>
        /// <returns>Lista de estilos</returns>
        public List<Estilos> Listar()
        {
            using(OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.ToList();
            }
        }

        // MÉTODO DE CADASTRO DE ESTILOS
        /// <summary>
        /// Cadastra um estilo a partir do escopo "EstilosDomain"
        /// </summary>
        /// <param name="estilo"></param>
        /// <returns>Estilo cadastrado</returns>
        public void Cadastrar(Estilos estilo)
        {
            using (OptusContext ctx = new OptusContext())
            {
                ctx.Estilos.Add(estilo);
                ctx.SaveChanges();
            }
        }

        // MÉTODO DE BUSCA POR ID DE ESTILOS
        /// <summary>
        /// Faz a busca por identificador numérico, retornando todos os dados de determinado usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Estilo estrito</returns>
        public Estilos BuscarPorId(int id)
        {
            using(OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.FirstOrDefault(x => x.IdEstilo == id);

            }
        }

        // MÉTODO PARA DELETAR UM ESTILO POR BUSCA DE ID
        /// <summary>
        /// Deleta determinado estilo pelo identificador numérico
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using(OptusContext ctx = new OptusContext())
            {
                Estilos estiloBuscado = ctx.Estilos.Find(id);
                ctx.Estilos.Remove(estiloBuscado);
                ctx.SaveChanges();
            }
        }

        // MÉTODO PARA ATUALIZAÇÃO DE ESTILOS
        /// <summary>
        /// Busca pelo identificador numérico e atualiza, a partir do escopo "EstilosDomain", o objeto estrito. 
        /// </summary>
        /// <param name="estilo"></param>
        public void Atualizar(Estilos estilo)
        {
            using(OptusContext ctx = new OptusContext())
            {
                Estilos estiloBuscado = ctx.Estilos.FirstOrDefault(x => x.IdEstilo == estilo.IdEstilo);
                estiloBuscado.Nome = estilo.Nome;
                ctx.Estilos.Update(estiloBuscado);
                ctx.SaveChanges();
            }
        }
    }
}
