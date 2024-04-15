using ASoftware.Enterprise.Transversal.Mapper;

namespace ASoftware.Enterprise.Servicios.WebApi.Modules.Mapper {

    /// <summary>
    /// Class for Mapping Configuration
    /// </summary>
    public static class MapperConfiguration {

        /// <summary>
        /// Method Builder for Add Mapping Configuration.
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <returns></returns>
        public static IServiceCollection AddMapperConfiguration(this IServiceCollection services) {
            services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

            return services;
        }
    }
}
