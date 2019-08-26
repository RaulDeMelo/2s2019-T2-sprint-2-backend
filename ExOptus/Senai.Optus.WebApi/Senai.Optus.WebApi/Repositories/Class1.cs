using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class EstiloRepositorio
    {
        public List<Estilos> Listar()
        {
            using(OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.ToList();
            }
        }
        
        // MÉTODO DE CADASTRO
        public void Cadastrar(Estilos estilo)
        {
            using (OptusContext ctx = new OptusContext())
            {
                ctx.Estilos.Add(estilo);
                ctx.SaveChanges();
            }
        }
        public Estilos BuscarPorId(int id)
        {
            using(OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.FirstOrDefault(x => x.IdEstilo == id);

            }
        }

    }
}
