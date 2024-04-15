using Asp.Versioning;

namespace ASoftware.Enterprise.Servicios.WebApi.Modules.Versioning {

    /// <summary>
    /// Class for Versioning API
    /// </summary>
    public static class VersioningConfiguration {

        /// <summary>
        /// Method Builder for Add Versioning with Asp.Versioning.MVC
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <returns></returns>
        public static IServiceCollection AddVersioningConfiguration(this IServiceCollection services) {
            services.AddApiVersioning(o => {
                o.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.ReportApiVersions = true;
                o.ApiVersionReader = new QueryStringApiVersionReader("api-version");
            }).AddApiExplorer(options => {
                options.GroupNameFormat = "'v'VVV";
            });

            return services;
        }
    }
}
