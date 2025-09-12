
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /app

# Copiar todo el código fuente desde la raíz del proyecto
COPY . .
WORKDIR /app/src/api/server
RUN dotnet restore Server.csproj
RUN dotnet publish Server.csproj -c Release -o /app/output

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build-env /app/output .

EXPOSE 5000
ENTRYPOINT ["dotnet", "FSH.Starter.WebApi.Host.dll"]
