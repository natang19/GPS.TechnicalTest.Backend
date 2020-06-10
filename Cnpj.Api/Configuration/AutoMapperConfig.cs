using AutoMapper;
using Cnpj.Api.ViewModels;
using Cnpj.Business.Models;

namespace Cnpj.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<EmpresaViewModel, Empresa>().ReverseMap();
        }
    }
}
