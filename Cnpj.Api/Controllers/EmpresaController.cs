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

        /// <summary>
        /// Obtém todos as empresas cadastradas na base de dados local.
        /// </summary>
        /// <returns>Array de empresas</returns>
        [HttpGet("obter-todos")]
        public async Task<IEnumerable<EmpresaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<EmpresaViewModel>>(await _empresaService.ObterTodos());
        }

        /// <summary>
        /// Obtém os detalhes da empresa do Id.
        /// </summary>
        /// <param name="id">Id da empresa.</param>
        /// <returns>Model com as informações da empresa do Id.</returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EmpresaViewModel>> ObterPorId(Guid id)
        {
            var empresaDetalhe = _mapper.Map<EmpresaViewModel>(await _empresaService.Obter(id));

            if(empresaDetalhe == null)
            {
                return NotFound();
            }

            return Ok(empresaDetalhe);
        }

        /// <summary>
        /// Obtém as empresas que possuem o cep informado em seu cadastro.
        /// </summary>
        /// <param name="cep">String representando o cep de um endereço.</param>
        /// <returns>Array de empresas</returns>
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

        /// <summary>
        /// Adiciona um empresa na base de dados.
        /// </summary>
        /// <param name="empresaViewModel">Model da empresa a ser adicionado no banco de dados.</param>
        /// <returns>Model da empresa adicionada no banco de dados.</returns>
        [HttpPost]
        public async Task<ActionResult<EmpresaViewModel>> Adicionar(EmpresaViewModel empresaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _empresaService.Adicionar(_mapper.Map<Empresa>(empresaViewModel));

            return CustomResponse(empresaViewModel);
        }

        /// <summary>
        /// Remove a empresa do Id
        /// </summary>
        /// <param name="id">Id da empresa a ser removida.</param>
        /// <returns>Model da empresa removida do banco de dados.</returns>
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