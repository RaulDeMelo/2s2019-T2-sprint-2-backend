﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebAPII.ViewModel
{
    public class Autenticador
    {
        [Required]
        public string Email { get; set; }
        public string Senha { get; set; }
        
    }
}

