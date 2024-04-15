using ASoftware.Enterprise.Aplicacion.Interfaz;
using ASoftware.Enterprise.Aplicacion.Main;
using ASoftware.Enterprise.Dominio.Core;
using ASoftware.Enterprise.Dominio.Interfaz;
using ASoftware.Enterprise.Infraestructura;
using ASoftware.Enterprise.Infraestructura.Interfaz;
using ASoftware.Enterprise.Infraestructura.Repositorio;
using ASoftware.Enterprise.Servicios.WebApi.Helpers;
using ASoftware.Enterprise.Transversal.Common;
using ASoftware.Enterprise.Transversal.Logging;

namespace ASoftware.Enterprise.Servicios.WebApi.Modules.Injection {

    /// <summary>
    /// Class for manage DI
    /// </summary>
    public static class InjectionConfiguration {

        /// <summary>
        /// Builder methos to add DI
        /// </summary>
        /// <param name="services">Service Collector</param>
        /// <returns></returns>
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration) {

            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<ICustomerApplication, CustomerApplication>();
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<ICustomersRepository, CustomerRepository>();

            services.AddScoped<AppSettings, AppSettings>();

            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IUsersDomain, UsersDomain>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
