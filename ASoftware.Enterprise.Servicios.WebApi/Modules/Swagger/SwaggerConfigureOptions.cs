using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ASoftware.Enterprise.Servicios.WebApi.Modules.Swagger {
    /// <summary>
    /// Class for Swagger configure works with Asp.Versioning.Mvc
    /// </summary>
    public class SwaggerConfigureOptions : IConfigureOptions<SwaggerGenOptions> {

        readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;

        /// <summary>
        /// Constructor for Configure API Versioning 
        /// </summary>
        /// <param name="apiVersionDescriptionProvider">DI ApiVersionDescriptionProvider</param>
        public SwaggerConfigureOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider) {
                _apiVersionDescriptionProvider = apiVersionDescriptionProvider;
        }

        static OpenApiInfo CreateInfoFroApiVersion(ApiVersionDescription description) {
            var info = new OpenApiInfo {
                Version = description.ApiVersion.ToString(),
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
            };

            return info;
        }

        /// <summary>
        /// Method for Configuration Versioning in Swagger
        /// </summary>
        /// <param name="options">Options for Swagger Configure</param>
        public void Configure(SwaggerGenOptions options) {
            foreach (var description in _apiVersionDescriptionProvider.ApiVersionDescriptions) {
                options.SwaggerDoc(description.GroupName, CreateInfoFroApiVersion(description));    
            }
        }
    }
}
