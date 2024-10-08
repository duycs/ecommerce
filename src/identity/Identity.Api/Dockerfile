#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["src/identity/Identity.Api/Identity.Api.csproj", "identity/Identity.Api/Identity.Api.csproj"]
COPY ["src/identity/Identity.Application/Identity.Application.csproj", "identity/Identity.Application/Identity.Application.csproj"]
COPY ["src/identity/Identity.Application.Read/Identity.Application.Read.csproj", "identity/Identity.Application.Read/Identity.Application.Read.csproj"]
COPY ["src/identity/Identity.Application.Write/Identity.Application.Write.csproj", "identity/Identity.Application.Write/Identity.Application.Write.csproj"]
COPY ["src/identity/Identity.Domain/Identity.Domain.csproj", "identity/Identity.Domain/Identity.Domain.csproj"]
COPY ["src/identity/Identity.Infrastructure/Identity.Infrastructure.csproj", "identity/Identity.Infrastructure/Identity.Infrastructure.csproj"]
COPY ["src/identity/Identity.Services/Identity.Services.csproj", "identity/Identity.Services/Identity.Services.csproj"]
COPY ["src/shared/ECommerce.Shared/ECommerce.Shared.csproj", "shared/ECommerce.Shared/ECommerce.Shared.csproj"]
COPY ["src/shared/Integration.Events/Integration.Events/Integration.Events.csproj", "shared/Integration.Events/Integration.Events/Integration.Events.csproj"]
COPY ["src/buildingBlocks/EventBusRabbitMQ/EventBusRabbitMQ.csproj", "buildingBlocks/EventBusRabbitMQ/EventBusRabbitMQ.csproj"]
COPY ["src/buildingBlocks/EventBus/EventBus.csproj", "buildingBlocks/EventBus/EventBus.csproj"]
RUN dotnet restore "identity/Identity.Api/Identity.Api.csproj"

COPY ["src/", "."]
WORKDIR "/src/identity/Identity.Api"
RUN dotnet build "Identity.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Identity.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity.Api.dll"]