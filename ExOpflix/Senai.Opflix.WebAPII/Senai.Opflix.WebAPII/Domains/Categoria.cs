using System;
using System.Collections.Generic;

namespace Senai.Opflix.WebAPII.Domains
{
    public partial class Categoria
    {
        public Categoria()
        {
            Lancamento = new HashSet<Lancamento>();
        }

        public int IdCategoria { get; set; }
        public string Nome { get; set; }

        public ICollection<Lancamento> Lancamento { get; set; }
    }
}
