using Cnpj.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cnpj.Business.Interface
{
    public interface IEmpresaRepository : IRepository<Empresa>
    {
        Task<IEnumerable<Empresa>> ObterPorCep(string cep);
    }
}
