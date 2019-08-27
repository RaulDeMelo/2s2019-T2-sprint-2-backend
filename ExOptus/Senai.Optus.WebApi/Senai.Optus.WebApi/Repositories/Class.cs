using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class ArtistaRepositorio
    {
        // MÉTODO PARA LISTAGEM DE ARTISTAS
        /// <summary>
        /// Invoca a tabela de artistas do SQL
        /// </summary>
        /// <returns>Lista de artistas</returns>
        public List<Artistas> Listar()
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Artistas.ToList();
            }
        }

        // MÉTODO DE CADASTRO DE ARTISTAS
        /// <summary>
        /// Cadastra um artista a partir do escopo "ArtistasDomain"
        /// </summary>
        /// <param name="artista"></param>
        /// <returns>Estilo cadastrado</returns>
        public void Cadastrar(Artistas artista)
        {
            using (OptusContext ctx = new OptusContext())
            {
                ctx.Artistas.Add(artista);
                ctx.SaveChanges();
            }
        }

    }
}
