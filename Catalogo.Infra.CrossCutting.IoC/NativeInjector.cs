using Catalogo.Application.CatalogoService.Service;
using Catalogo.Infra.CrossCutting.IoC.Settings;
using Catalogo.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalogo.Infra.CrossCutting.IoC
{
    public class NativeInjector
    {
        public static void Setup(IServiceCollection services, IConfiguration configuration)
        {
            RegisterServices(services, configuration);
        }

        private static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {

        }
    }
}
