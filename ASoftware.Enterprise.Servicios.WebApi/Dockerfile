#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ASoftware.Enterprise.Servicios.WebApi/ASoftware.Enterprise.Servicios.WebApi.csproj", "ASoftware.Enterprise.Servicios.WebApi/"]
COPY ["ASoftware.Enterpise.Transversal/ASoftware.Enterprise.Transversal.Common.csproj", "ASoftware.Enterpise.Transversal/"]
COPY ["ASoftware.Enterprise.Aplicacion.DTO/ASoftware.Enterprise.Aplicacion.DTO.csproj", "ASoftware.Enterprise.Aplicacion.DTO/"]
COPY ["ASoftware.Enterprise.Aplicacion.Interfaz/ASoftware.Enterprise.Aplicacion.Interfaz.csproj", "ASoftware.Enterprise.Aplicacion.Interfaz/"]
COPY ["ASoftware.Enterprise.Aplicacion.Main/ASoftware.Enterprise.Aplicacion.Main.csproj", "ASoftware.Enterprise.Aplicacion.Main/"]
COPY ["ASoftware.Enterprise.Dominio.Entity/ASoftware.Enterprise.Dominio.Entity.csproj", "ASoftware.Enterprise.Dominio.Entity/"]
COPY ["ASoftware.Enterprise.Dominio.Interfaz/ASoftware.Enterprise.Dominio.Interfaz.csproj", "ASoftware.Enterprise.Dominio.Interfaz/"]
COPY ["ASoftware.Enterprise.Dominio.Core/ASoftware.Enterprise.Dominio.Core.csproj", "ASoftware.Enterprise.Dominio.Core/"]
COPY ["ASoftware.Enterprise.Infraestructura.Interfaz/ASoftware.Enterprise.Infraestructura.Interfaz.csproj", "ASoftware.Enterprise.Infraestructura.Interfaz/"]
COPY ["ASoftware.Enterprise.Infraestructura.Repositorio/ASoftware.Enterprise.Infraestructura.Repositorio.csproj", "ASoftware.Enterprise.Infraestructura.Repositorio/"]
COPY ["ASoftware.Enterprise.Infraestructura/ASoftware.Enterprise.Infraestructura.Data.csproj", "ASoftware.Enterprise.Infraestructura/"]
COPY ["ASoftware.Enterprise.Transversal.Logging/ASoftware.Enterprise.Transversal.Logging.csproj", "ASoftware.Enterprise.Transversal.Logging/"]
COPY ["ASoftware.Enterprise.Transversal.Mapper/ASoftware.Enterprise.Transversal.Mapper.csproj", "ASoftware.Enterprise.Transversal.Mapper/"]
RUN dotnet restore "./ASoftware.Enterprise.Servicios.WebApi/ASoftware.Enterprise.Servicios.WebApi.csproj"
COPY . .
WORKDIR "/src/ASoftware.Enterprise.Servicios.WebApi"
RUN dotnet build "./ASoftware.Enterprise.Servicios.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ASoftware.Enterprise.Servicios.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ASoftware.Enterprise.Servicios.WebApi.dll"]