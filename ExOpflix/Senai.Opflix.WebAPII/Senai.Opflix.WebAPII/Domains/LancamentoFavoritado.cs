using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebAPII.Domains
{
    public class LancamentoFavoritado
    {
        public int? IdUsuario { get; set; }
        public int? IdLancamento { get; set; }

        public Usuario IdUsuarioNavigation { get; set; }
        public Lancamento IdLancamentoNavigation { get; set; }
    }
}
