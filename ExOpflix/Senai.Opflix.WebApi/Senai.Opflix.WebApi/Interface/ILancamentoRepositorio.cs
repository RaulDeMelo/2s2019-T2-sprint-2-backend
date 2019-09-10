using Senai.Opflix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebApi.Interface
{
    interface ILancamentoRepositorio
    {
        List<Lancamento> Listar();
        void Cadastrar(Lancamento lancamento);
        Lancamento BuscarPorId(int id);
        void Atualizar(Lancamento lancamento);
    }
}
