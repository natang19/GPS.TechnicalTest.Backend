using Cnpj.Business.Models;
using FluentValidation;
using System;

namespace Cnpj.Business.Validacoes
{
    public class EmpresaValidation : AbstractValidator<Empresa>
    {
        private string ErroStringVazia = "O campo {PropertyName} precisa ser fornecido";
        private string ErroStringTamanhoInvalido = "O campo {PropertyName} precisa ser fornecido";

        public EmpresaValidation()
        {
            //RuleFor(e => e.data_situacao == default).Equals(true).WithMessage("A data da situação da empresa é inválido.");

            RuleFor(e => e.data_situacao).GreaterThan(DateTime.Today).WithMessage("A data da situação da empresa é inválida, pois é maior que a data de hoje.");

            RuleFor(e => e.nome)
                .NotEmpty().WithMessage(ErroStringVazia)
                .Length(2, 200).WithMessage(ErroStringTamanhoInvalido);

            RuleFor(e => e.uf)
                .NotEmpty().WithMessage(ErroStringVazia)
                .Length(2).WithMessage(ErroStringTamanhoInvalido);

            RuleFor(e => e.telefone)
                .NotEmpty().WithMessage(ErroStringVazia)
                .Length(14, 1000).WithMessage(ErroStringTamanhoInvalido);

            RuleFor(e => e.situacao)
                .NotEmpty().WithMessage(ErroStringVazia)
                .Length(1, 200).WithMessage(ErroStringTamanhoInvalido);

            RuleFor(e => e.bairro)
                .NotEmpty().WithMessage(ErroStringVazia)
                .Length(1, 200).WithMessage(ErroStringTamanhoInvalido);

            RuleFor(e => e.logradouro)
                .NotEmpty().WithMessage(ErroStringVazia)
                .Length(1, 200).WithMessage(ErroStringTamanhoInvalido);

            RuleFor(e => e.numero)
                .LessThanOrEqualTo(0).WithMessage("O campo {PropertyName} possui um valor negativo ou igual a 0 e por isso é inválido");

            RuleFor(e => e.cep)
                .NotEmpty().WithMessage(ErroStringVazia)
                .Length(8).WithMessage("O campo {PropertyName} precisa ter {MaxLength} caracteres");

            RuleFor(e => e.municipio)
                .NotEmpty().WithMessage(ErroStringVazia)
                .Length(1, 200).WithMessage(ErroStringTamanhoInvalido);

            RuleFor(e => e.porte)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(1, 15).WithMessage(ErroStringTamanhoInvalido);

            //RuleFor(e => e.abertura == default).Equals(true).WithMessage("A data da situação da empresa é inválido.");

            RuleFor(e => e.abertura).GreaterThanOrEqualTo(DateTime.Today).WithMessage("A data de abertura da empresa é inválida, pois é maior que a data de hoje.");

            RuleFor(e => e.natureza_juridica)
                .NotEmpty().WithMessage(ErroStringVazia)
                .Length(5, 100).WithMessage(ErroStringTamanhoInvalido);

            RuleFor(e => e.fantasia)
                .NotEmpty().WithMessage(ErroStringVazia)
                .Length(2, 250).WithMessage(ErroStringTamanhoInvalido);

            RuleFor(e => e.cnpj.Length).Equal(ValidacaoCnpj.TamanhoCnpj)
                .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

            RuleFor(e => ValidacaoCnpj.Validar(e.cnpj)).Equal(true)
                .WithMessage("O documento fornecido é inválido.");

            RuleFor(e => e.ultima_atualizacao).GreaterThan(DateTime.Today).WithMessage("A data da ultima atualização da empresa é inválida, pois é maior que a data de hoje.");

            RuleFor(e => e.tipo)
                .NotEmpty().WithMessage(ErroStringVazia)
                .Length(6).WithMessage("O campo {PropertyName} precisa ter {MaxLength} caracteres");

            RuleFor(e => e.capital_social)
                .LessThan(0).WithMessage("O capital social da empresa é inválido pois seu valor é negativo.");
        }
    }
}
