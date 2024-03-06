using ASoftware.Enterprise.Aplicacion.Validator;

namespace ASoftware.Enterprise.Servicios.WebApi.Validator {
    public static class ValidatorExtensions {
        public static IServiceCollection AddValidator(this IServiceCollection services) {
            services.AddTransient<UsersDtoValidator>();
            return services;
        }
    }
}
