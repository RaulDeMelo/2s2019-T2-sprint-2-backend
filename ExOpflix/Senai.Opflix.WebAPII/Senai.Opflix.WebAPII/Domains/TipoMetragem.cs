using System;
using System.Collections.Generic;

namespace Senai.Opflix.WebAPII.Domains
{
    public partial class TipoMetragem
    {
        public TipoMetragem()
        {
            Lancamento = new HashSet<Lancamento>();
        }

        public int IdTipoMetragem { get; set; }
        public string Nome { get; set; }

        public ICollection<Lancamento> Lancamento { get; set; }
    }
}
