using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebApi.Domains
{
    public class LancamentoFavoritado
    {
        public int? IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        public int? IdLancamento { get; set; }
        public Lancamento Lancamento { get; set; }
    }
}
