using Cnpj.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnpj.Business.Interface
{
    public interface IEmpresaService : IDisposable
    {
        Task<IEnumerable<Empresa>> ObterTodos();
        Task<Empresa> Obter(Guid id);
        Task<IEnumerable<Empresa>> ObterPorCep(string cep);
        Task<bool> Adicionar(Empresa empresa);
        Task<bool> Remover(Guid id);
    }
}
