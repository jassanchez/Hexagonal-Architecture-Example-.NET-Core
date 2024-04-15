namespace ASoftware.Enterprise.Servicios.WebApi.Modules.Feature {
    /// <summary>
    /// Class for CORS Feature in Service Web API
    /// </summary>
    public static class FeatureExtension {
        /// <summary>
        /// Builder Method For Add 'policyApi' With Cors Configuration from AppSettings
        /// </summary>
        /// <param name="services">ServiceCollection</param>
        /// <param name="configuration">Interface for Read AppSettings Cors Configuration</param>
        /// <returns></returns>
        public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration) {
            string policyCors = "policyApi";

            services.AddCors(CorsSettings => {
                CorsSettings.AddPolicy(policyCors, b => b.WithOrigins(configuration["Config:OriginCors"]!)
                .AllowAnyHeader()
                .AllowAnyMethod());
            });
            services.AddMvc();

            return services;
        }
    }
}
