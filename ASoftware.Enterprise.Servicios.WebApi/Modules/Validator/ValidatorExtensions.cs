using ASoftware.Enterprise.Aplicacion.Validator;

namespace ASoftware.Enterprise.Servicios.WebApi.Modules.Validator
{

    /// <summary>
    /// Clase para incluir clases para validacion de datos con Fluent Validation
    /// </summary>
    public static class ValidatorExtensions
    {
        /// <summary>
        /// Extension of Service Collection to add ClassValidator
        /// </summary>
        /// <param name="services"> ServiceCollector </param>
        /// <returns> Service Collector</returns>
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<UsersDtoValidator>();
            return services;
        }
    }
}
