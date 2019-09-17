using Senai.Opflix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Opflix.WebApi.Interface
{
    interface ICategoriaRepositorio
    {
        List<Categoria> Listar();
        Categoria BuscarPorId(int id);
        void Cadastrar(Categoria categoria);
        void Atualizar(Categoria categoria);
    }
}
