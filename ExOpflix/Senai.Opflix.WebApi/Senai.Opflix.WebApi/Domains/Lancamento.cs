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
        public int? IdPlataforma { get; set; }

        public Categoria IdCategoriaNavigation { get; set; }
        public Plataforma IdPlataformaNavigation { get; set; }
        public TipoMetragem IdTipoMetragemNavigation { get; set; }
        public List<LancamentoFavoritado> LancamentoFavoritado { get; set; }
    }
}
