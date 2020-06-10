using Cnpj.Business.Interface;
using Cnpj.Business.Models;
using Cnpj.Business.Utils;
using Cnpj.Business.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cnpj.Business.Services
{
    public class EmpresaService : BaseService, IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository, INotificador notificador) : base(notificador)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task<IEnumerable<Empresa>> ObterTodos()
        {
            return await _empresaRepository.ObterTodos();
        }

        public async Task<bool> Adicionar(Empresa empresa)
        {
            empresa.cnpj = empresa.cnpj.ApenasNumeros();
            empresa.cep = empresa.cep.ApenasNumeros();
            empresa.telefone = empresa.telefone.Trim();

            if (!ExecutarValidacao(new EmpresaValidation(), empresa)) return false;

            if (_empresaRepository.Buscar(f => f.cnpj == empresa.cnpj).Result.Any())
            {
                Notificar("Já existe um empresa com este documento infomado.");
                return false;
            }

            await _empresaRepository.Adicionar(empresa);
            return true;
        }

        public async Task<Empresa> Obter(Guid id)
        {
            var empresa = await _empresaRepository.ObterPorId(id);

            if(empresa == null)
            {
                Notificar("Empresa informada não encontrada");
                return null;
            }

            return empresa;
        }

        public async Task<IEnumerable<Empresa>> ObterPorCep(string cep)
        {
            var empresasDoCep = await _empresaRepository.ObterPorCep(cep.ApenasNumeros());

            if (!empresasDoCep.Any())
            {
                Notificar("Não foram encontrado empresas no cep informado em nossa base!");
                return null;
            }

            return empresasDoCep;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _empresaRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _empresaRepository?.Dispose();
        }
    }
}
