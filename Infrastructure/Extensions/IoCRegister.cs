using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;

namespace Infrastructure.Extensions
{
    public static class IoCRegister
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration Configuration)
        {

            //Contexts
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Repositories
            services.AddRegisterRepositories();

            //Services
            services.AddRegisterServices();
        }

        private static IServiceCollection AddRegisterRepositories(this IServiceCollection services)
        {
            services
                .AddTransient<IPersonaRepository, PersonaRepository>()
                .AddTransient<IDocumentoRepository, DocumentoRepository>()
                .AddTransient<IDocumentoTipoRepository, DocumentoTipoRepository>()
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }

        private static IServiceCollection AddRegisterServices(this IServiceCollection services)
        {
            services
                .AddTransient<IDocumentoService, DocumentoService>()
                .AddTransient<IDocumentoTipoService, DocumentoTipoService>()
                .AddTransient<IPersonaService, PersonaService>()
                .AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }

        //private static IServiceCollection AddRegisterValidation(this IServiceCollection services)
        //{
        //    //services
        //    //    .AddTransient<IValidator<GenderInsertDto>, GenderInsertDtoValidator>()
        //    //    .AddTransient<IValidator<GenderDto>, GenderDtoValidator>();
        //    return services;
        //}
    }
}
