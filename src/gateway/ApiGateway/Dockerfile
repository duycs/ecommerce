#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["src/gateway/ApiGateway/ApiGateway.csproj", "gateway/ApiGateway/ApiGateway.csproj"]
COPY ["src/shared/ECommerce.Shared/ECommerce.Shared.csproj", "shared/ECommerce.Shared/ECommerce.Shared.csproj"]
RUN dotnet restore "gateway/ApiGateway/ApiGateway.csproj"

COPY ["src/gateway/", "gateway/"]
WORKDIR "/src/gateway/ApiGateway"
RUN dotnet build "ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiGateway.dll"]