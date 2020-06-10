using Cnpj.Business.Interface;
using Cnpj.Business.Models;
using Cnpj.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cnpj.Data.Repository
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(ApiDbContext context) : base(context) { }

        public async Task<IEnumerable<Empresa>> ObterPorCep(string cep)
        {
            return await Buscar(e => e.cep == cep);
        }
    }
}
