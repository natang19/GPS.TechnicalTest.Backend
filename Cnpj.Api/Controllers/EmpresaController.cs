using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Cnpj.Api.ViewModels;
using Cnpj.Business.Interface;
using Cnpj.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cnpj.Api.Controllers
{
    [Route("api/empresa")]
    public class EmpresaController : MainController
    {
        private readonly IEmpresaService _empresaService;
        private readonly IMapper _mapper;

        public EmpresaController(IEmpresaService empresaService, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _empresaService = empresaService;
            _mapper = mapper;
        }

        [HttpGet("obter-todos")]
        public async Task<IEnumerable<EmpresaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<EmpresaViewModel>>(await _empresaService.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EmpresaViewModel>> ObterPorId(Guid id)
        {
            var empresaDetalhe = _mapper.Map<IEnumerable<EmpresaViewModel>>(await _empresaService.Obter(id));

            if(empresaDetalhe == null)
            {
                return NotFound();
            }

            return Ok(empresaDetalhe);
        }

        [HttpGet("obter-pelo-cep/{cep}")]
        public async Task<ActionResult<IEnumerable<EmpresaViewModel>>> ObterPeloCep(string cep)
        {
            var empresasDetalhes = _mapper.Map<IEnumerable<EmpresaViewModel>>(await _empresaService.ObterPorCep(cep));

            if (empresasDetalhes == null)
            {
                return NotFound();
            }

            return Ok(empresasDetalhes);
        }

        [HttpPost]
        public async Task<ActionResult<EmpresaViewModel>> Adicionar(EmpresaViewModel empresaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _empresaService.Adicionar(_mapper.Map<Empresa>(empresaViewModel));

            return CustomResponse(empresaViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<EmpresaViewModel>> RemoverEmpresa(Guid id)
        {
            var empresaDetalhe = _mapper.Map<IEnumerable<EmpresaViewModel>>(await _empresaService.Remover(id));

            if (empresaDetalhe == null)
            {
                return NotFound();
            }

            return Ok(empresaDetalhe);
        }
    }
}