using ASoftware.Enterprise.Servicios.WebApi.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ASoftware.Enterprise.Servicios.WebApi.Modules.Authentication {
    /// <summary>
    /// Clase que crea la configuracion para JWT con el Service Collector para ID
    /// </summary>
    public static class JwtConfiguration
    {

        /// <summary>
        /// Configuracion para JWT
        /// </summary>
        /// <param name="services"> Service Collector </param>
        /// <param name="configuration"> appsettings.json para informacion de la key</param>
        /// <returns></returns>
        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {

            var appSettingSection = configuration.GetSection("Config");
            services.Configure<AppSettings>(appSettingSection);
            var appSettings = appSettingSection.Get<AppSettings>();

            var key = Encoding.ASCII.GetBytes(appSettings!.Secret);
            var Issuer = appSettings.Issuer;
            var Audience = appSettings.Audience;

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            int.TryParse(context.Principal?.Identity?.Name, out int usedId);
                            return Task.CompletedTask;
                        },

                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Append("Token-Expired", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = false;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = Audience,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = appSettings.Issuer
                    };
                });
            return services;
        }
    }
}
