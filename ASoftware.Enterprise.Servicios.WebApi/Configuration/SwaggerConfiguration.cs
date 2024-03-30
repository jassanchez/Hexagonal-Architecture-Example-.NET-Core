using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ASoftware.Enterprise.Servicios.WebApi.Configuration {
    /// <summary>
    /// Clase de configuracion de Swagger para la API
    /// </summary>
    public static class SwaggerConfiguration {

        /// <summary>
        /// Metodo para genear la configuracion de Swagger del API
        /// </summary>
        /// <param name="services"> Service Collector </param>
        /// <returns></returns>
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services) {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo {
                    Version = "v1",
                    Title = "Customers API",
                    Description = "An ASP.NET Core Web API for managing Customers",
                    TermsOfService = new Uri(@"https://example.com/terms"),
                    Contact = new OpenApiContact {
                        Name = "Example Contact",
                        Url = new Uri(@"https://example.com/contact")
                    },
                    License = new OpenApiLicense {
                        Name = "Example License",
                        Url = new Uri(@"https://example.com/license")
                    }
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                    Description = "Authorization by API key",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            return services;
        }
    }
}
