using ASoftware.Enterprise.Aplicacion.Interfaz;
using ASoftware.Enterprise.Aplicacion.Main;
using ASoftware.Enterprise.Dominio.Core;
using ASoftware.Enterprise.Dominio.Interfaz;
using ASoftware.Enterprise.Infraestructura;
using ASoftware.Enterprise.Infraestructura.Interfaz;
using ASoftware.Enterprise.Infraestructura.Repositorio;
using ASoftware.Enterprise.Servicios.WebApi.Helpers;
using ASoftware.Enterprise.Transversal.Common;
using ASoftware.Enterprise.Transversal.Mapper;
using ASoftware.Enterprise.Transversal.Logging;
using Newtonsoft.Json.Serialization;
using ASoftware.Enterprise.Servicios.WebApi.Validator;
using ASoftware.Enterprise.Servicios.WebApi.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc(opc => {
    opc.SuppressAsyncSuffixInActionNames = false;
});


/* Configurando y seteado CORS*/
string policyCors = "policyApi";
builder.Services.AddCors(CorsSettings => {
    CorsSettings.AddPolicy(policyCors, b => b.WithOrigins(builder.Configuration["Config:OriginCors"])
    .AllowAnyHeader()
    .AllowAnyMethod());
});

builder.Services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));
builder.Services.AddMvc().AddNewtonsoftJson(opc => { opc.SerializerSettings.ContractResolver = new DefaultContractResolver(); });

/*Usando JWT*/
var appSettingSection = builder.Configuration.GetSection("Config");
builder.Services.Configure<AppSettings>(appSettingSection);

var appSettings = appSettingSection.Get<AppSettings>();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();
builder.Services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
builder.Services.AddScoped<ICustomerApplication, CustomerApplication>();
builder.Services.AddScoped<ICustomersDomain, CustomersDomain>();
builder.Services.AddScoped<ICustomersRepository, CustomerRepository>();

builder.Services.AddScoped<AppSettings, AppSettings>();

builder.Services.AddScoped<IUsersApplication, UsersApplication>();
builder.Services.AddScoped<IUsersDomain, UsersDomain>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//ValidatorExtensions.AddValidator(builder.Services);
//JwtConfiguration.ConfigureJwt(builder.Services, appSettings);
//SwaggerConfiguration.ConfigureSwagger(builder.Services);
builder.Services.AddValidator();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureJwt(appSettings);


var app = builder.Build();
app.UseCors(policyCors);
app.UseAuthentication();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();

public partial class Program{ }