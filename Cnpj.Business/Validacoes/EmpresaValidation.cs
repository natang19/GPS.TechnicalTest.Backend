using Cnpj.Business.Models;
using FluentValidation;
using System;

namespace Cnpj.Business.Validacoes
{
    public class EmpresaValidation : AbstractValidator<Empresa>
    {
        private string ErroStringVazia = "O campo {PropertyName} precisa ser fornecido";
        private string ErroStringTamanhoInvalido = "O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres";

        public EmpresaValidation()
        {
            RuleFor(e => e.data_situacao).LessThan(DateTime.Today).WithMessage("A data da situação da empresa é inválida, pois é maior que a data de hoje.");

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
                .GreaterThan(0).WithMessage("O campo {PropertyName} possui um valor negativo ou igual a 0 e por isso é inválido");

            RuleFor(e => e.cep)
                .NotEmpty().WithMessage(ErroStringVazia)
                .Length(8).WithMessage("O campo {PropertyName} precisa ter {MaxLength} caracteres");

            RuleFor(e => e.municipio)
                .NotEmpty().WithMessage(ErroStringVazia)
                .Length(1, 200).WithMessage(ErroStringTamanhoInvalido);

            RuleFor(e => e.porte)
                .NotEmpty().WithMessage(ErroStringVazia)
                .Length(1, 15).WithMessage(ErroStringTamanhoInvalido);

            RuleFor(e => e.abertura).LessThanOrEqualTo(DateTime.Today).WithMessage("A data de abertura da empresa é inválida, pois é maior que a data de hoje.");

            RuleFor(e => e.natureza_juridica)
                .NotEmpty().WithMessage(ErroStringVazia)
                .Length(5, 100).WithMessage(ErroStringTamanhoInvalido);

            RuleFor(e => e.cnpj.Length).Equal(ValidacaoCnpj.TamanhoCnpj)
                .WithMessage("O campo Cnpj precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");

            RuleFor(e => ValidacaoCnpj.Validar(e.cnpj)).Equal(true)
                .WithMessage("O Cnpj fornecido é inválido.");

            RuleFor(e => e.ultima_atualizacao).LessThan(DateTime.Today).WithMessage("A data da ultima atualização da empresa é inválida, pois é maior que a data de hoje.");

            RuleFor(e => e.tipo)
                .NotEmpty().WithMessage(ErroStringVazia)
                .Length(6).WithMessage(ErroStringTamanhoInvalido);

            RuleFor(e => e.capital_social)
                .GreaterThan(0).WithMessage("O capital social da empresa é inválido pois seu valor é negativo.");
        }
    }
}
