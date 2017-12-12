using Controle.Imobilizado.Application.Interfaces;
using Controle.Imobilizado.Application.Services;
using Controle.Imobilizado.Domain.Interfaces;
using Controle.Imobilizado.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Controle.Imobilizado.Infra.Ioc
{
    public class SimpleInjectorBootStrapper
    {
        public static void RegisterService(IServiceCollection services)
        {
            //Application - Domain
            services.AddScoped<IImmobilizedAppService, ImmobilizedAppService>();
            //Domain - Data
            services.AddScoped<IImmobilizedRepository, ImmobilizedRepository>();
        }
    }
}