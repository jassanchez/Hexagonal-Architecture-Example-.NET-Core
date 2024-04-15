using ASoftware.Enterprise.Servicios.WebApi.Modules.Authentication;
using ASoftware.Enterprise.Servicios.WebApi.Modules.Swagger;
using ASoftware.Enterprise.Servicios.WebApi.Modules.Validator;
using ASoftware.Enterprise.Servicios.WebApi.Modules.Injection;
using ASoftware.Enterprise.Servicios.WebApi.Modules.Mapper;
using Asp.Versioning.ApiExplorer;
using ASoftware.Enterprise.Servicios.WebApi.Modules.Feature;
using ASoftware.Enterprise.Servicios.WebApi.Modules.Versioning;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMvc(opc => {
    opc.SuppressAsyncSuffixInActionNames = false;
});

builder.Services.AddMapperConfiguration();
builder.Services.AddFeature(builder.Configuration);
builder.Services.AddDependencyInjection(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddVersioningConfiguration();
builder.Services.AddSwagger();
builder.Services.AddValidator();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions) {
            c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

/// <summary>
/// Extension para ser usado en Proyecto de Pruebas
/// </summary>
public partial class Program{ }