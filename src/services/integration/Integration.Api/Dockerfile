#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["src/services/integration/Integration.Api/Integration.Api.csproj", "services/integration/Integration.Api/Integration.Api.csproj"]
COPY ["src/services/integration/Integration.Application/Integration.Application.csproj", "services/integration/Integration.Application/Integration.Application.csproj"]
COPY ["src/services/integration/Integration.Application.Write/Integration.Application.Write.csproj", "services/integration/Integration.Application.Write/Integration.Application.Write.csproj"]
COPY ["src/services/integration/Integration.Domain/Integration.Domain.csproj", "services/integration/Integration.Domain/Integration.Domain.csproj"]
COPY ["src/services/integration/Integration.Infrastructure/Integration.Infrastructure.csproj", "services/integration/Integration.Infrastructure/Integration.Infrastructure.csproj"]
COPY ["src/services/integration/Integration.Services/Integration.Services.csproj", "services/integration/Integration.Services/Integration.Services.csproj"]
COPY ["src/shared/ECommerce.Shared/ECommerce.Shared.csproj", "shared/ECommerce.Shared/ECommerce.Shared.csproj"]
COPY ["src/shared/Integration.Events/Integration.Events/Integration.Events.csproj", "shared/Integration.Events/Integration.Events/Integration.Events.csproj"]
COPY ["src/buildingBlocks/EventBusRabbitMQ/EventBusRabbitMQ.csproj", "buildingBlocks/EventBusRabbitMQ/EventBusRabbitMQ.csproj"]
COPY ["src/buildingBlocks/EventBus/EventBus.csproj", "buildingBlocks/EventBus/EventBus.csproj"]
RUN dotnet restore "services/integration/Integration.Api/Integration.Api.csproj"

COPY ["src/", "."]
WORKDIR "/src/services/integration/Integration.Api"
RUN dotnet build "Integration.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Integration.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Integration.Api.dll"]