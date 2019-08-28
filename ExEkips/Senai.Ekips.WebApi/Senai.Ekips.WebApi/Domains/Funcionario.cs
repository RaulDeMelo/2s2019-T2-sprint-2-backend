using System;
using System.Collections.Generic;

namespace Senai.Ekips.WebApi.Domains
{
    public partial class Funcionario
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public decimal Salario { get; set; }
        public int? IdCargo { get; set; }
        public int? IdDepartamento { get; set; }
        public int? IdPermissao { get; set; }

        public Cargo IdCargoNavigation { get; set; }
        public Departamento IdDepartamentoNavigation { get; set; }
        public Permissao IdPermissaoNavigation { get; set; }
    }
}
