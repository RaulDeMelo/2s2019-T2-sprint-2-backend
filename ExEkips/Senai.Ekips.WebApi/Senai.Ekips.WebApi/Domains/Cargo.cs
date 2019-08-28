using System;
using System.Collections.Generic;

namespace Senai.Ekips.WebApi.Domains
{
    public partial class Cargo
    {
        public Cargo()
        {
            Funcionario = new HashSet<Funcionario>();
        }

        public int IdCargo { get; set; }
        public string Nome { get; set; }
        public bool? Ativo { get; set; }

        public ICollection<Funcionario> Funcionario { get; set; }
    }
}
