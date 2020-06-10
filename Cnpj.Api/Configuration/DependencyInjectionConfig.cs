using Cnpj.Business.Interface;
using Cnpj.Business.Notificacoes;
using Cnpj.Business.Services;
using Cnpj.Data.Context;
using Cnpj.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Cnpj.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApiDbContext>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IEmpresaService, EmpresaService>();

            return services;
        }
    }
}
