using Senai.Opflix.WebApi.Domains;
using Senai.Opflix.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebApi.Interface
{
    interface IUsuarioRepositorio
    {
        Usuario AutenticarPorBusca(Autenticador login);
    }
}