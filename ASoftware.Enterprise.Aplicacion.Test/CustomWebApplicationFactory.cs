using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace ASoftware.Enterprise.Aplicacion.Test {
    public class CustomWebApplicationFactory : WebApplicationFactory<Program> {

        protected override void ConfigureWebHost(IWebHostBuilder builder) {
            builder.ConfigureAppConfiguration(configurationBuilder => {
                var integrationBuilder = new ConfigurationBuilder()
                                            .AddJsonFile("appsettings.json")
                                            .SetBasePath(Directory.GetCurrentDirectory())
                                            .AddEnvironmentVariables()
                                            .Build();

                configurationBuilder.AddConfiguration(integrationBuilder);
            });
        }

    }
}
