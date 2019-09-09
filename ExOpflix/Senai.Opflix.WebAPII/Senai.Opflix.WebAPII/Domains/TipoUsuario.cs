﻿using System;
using System.Collections.Generic;

namespace Senai.Opflix.WebAPII.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        public string Nome { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
