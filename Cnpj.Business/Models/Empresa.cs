using System;
using System.Collections.Generic;
using System.Text;

namespace Cnpj.Business.Models
{
    public class Empresa : Entity
    {
        public DateTime data_situacao { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }
        public string telefone { get; set; }
        public string situacao { get; set; }
        public string bairro { get; set; }
        public string logradouro { get; set; }
        public int numero { get; set; }
        public string cep { get; set; }
        public string municipio { get; set; }
        public string porte { get; set; }
        public DateTime abertura { get; set; }
        public string natureza_juridica { get; set; }
        public string fantasia { get; set; }
        public string cnpj { get; set; }
        public DateTime ultima_atualizacao { get; set; }
        public string tipo { get; set; }
        public string complemento { get; set; }
        public string email { get; set; }
        public string efr { get; set; }
        public string motivo_situacao { get; set; }
        public string situacao_especial { get; set; }
        public string data_situacao_especial { get; set; }
        public double capital_social { get; set; }
    }

    //public class AtividadePrincipal
    //{
    //    public string text { get; set; }
    //    public string code { get; set; }
    //}

    //public class AtividadesSecundaria
    //{
    //    public string text { get; set; }
    //    public string code { get; set; }
    //}

    //public class Qsa
    //{
    //    public string qual { get; set; }
    //    public string nome { get; set; }
    //}
}
