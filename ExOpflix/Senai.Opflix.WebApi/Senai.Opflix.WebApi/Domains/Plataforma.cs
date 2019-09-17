using System;
using System.Collections.Generic;

namespace Senai.Opflix.WebApi.Domains
{
    public partial class Plataforma
    {
        public Plataforma()
        {
            Lancamento = new HashSet<Lancamento>();
        }

        public int IdPlataforma { get; set; }
        public string Nome { get; set; }

        public ICollection<Lancamento> Lancamento { get; set; }
    }
}
