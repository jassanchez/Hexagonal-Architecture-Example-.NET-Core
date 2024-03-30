using ASoftware.Enterprise.Aplicacion.Validator;
using ASoftware.Enterprise.Servicios.WebApi.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ASoftware.Enterprise.Servicios.WebApi.Configuration {
    /// <summary>
    /// Clase que crea la configuracion para JWT con el Service Collector para ID
    /// </summary>
    public static class JwtConfiguration {

        /// <summary>
        /// Configuracion para JWT
        /// </summary>
        /// <param name="services"> Service Collector </param>
        /// <param name="appSettings"> appsettings.json para informacion de la key</param>
        /// <returns></returns>
        public static IServiceCollection ConfigureJwt(this IServiceCollection services, AppSettings appSettings) {

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var Issuer = appSettings.Issuer;
            var Audience = appSettings.Audience;

            services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x => {
                    x.Events = new JwtBearerEvents {
                        OnTokenValidated = context => {
                            int usedId = 0;
                            int.TryParse(context.Principal?.Identity?.Name, out usedId);
                            return Task.CompletedTask;
                        },

                        OnAuthenticationFailed = context => {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException)) {
                                context.Response.Headers.Append("Token-Expired", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = false;
                    x.TokenValidationParameters = new TokenValidationParameters {
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
