namespace ASoftware.Enterprise.Servicios.WebApi.Modules.Feature {
    public static class FeatureExtension {
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
