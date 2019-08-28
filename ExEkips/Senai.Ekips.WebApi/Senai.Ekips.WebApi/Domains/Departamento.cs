using System;
using System.Collections.Generic;

namespace Senai.Ekips.WebApi.Domains
{
    public partial class Departamento
    {
        public Departamento()
        {
            Funcionario = new HashSet<Funcionario>();
        }

        public int IdDepartamento { get; set; }
        public string Nome { get; set; }
        public bool? Ativo { get; set; }

        public ICollection<Funcionario> Funcionario { get; set; }
    }
}
