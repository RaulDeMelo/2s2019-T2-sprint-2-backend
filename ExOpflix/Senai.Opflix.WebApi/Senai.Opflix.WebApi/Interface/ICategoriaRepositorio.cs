using Senai.Opflix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebApi.Interface
{
    interface ILancamentoRepositorio
    {
      void Cadastrar(Categoria categoria);
    }
