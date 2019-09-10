using System;
using System.Collections.Generic;

namespace Senai.Opflix.WebApi.Domains
{
    public partial class Lancamento
    {
        public int IdLancamento { get; set; }
        public string Nome { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdTipoMetragem { get; set; }
        public TimeSpan? TempDuracao { get; set; }
        public DateTime? DataLancamento { get; set; }
        public string Sinopse { get; set; }

        public Categoria IdCategoriaNavigation { get; set; }
        public TipoMetragem IdTipoMetragemNavigation { get; set; }
    }
}
