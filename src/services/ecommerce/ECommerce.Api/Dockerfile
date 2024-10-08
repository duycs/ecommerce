#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["src/services/ecommerce/ECommerce.Api/ECommerce.Api.csproj", "services/ecommerce/ECommerce.Api/ECommerce.Api.csproj"]
COPY ["src/services/ecommerce/ECommerce.Application/ECommerce.Application.csproj", "services/ecommerce/ECommerce.Application/ECommerce.Application.csproj"]
COPY ["src/services/ecommerce/ECommerce.Application.Read/ECommerce.Application.Read.csproj", "services/ecommerce/ECommerce.Application.Read/ECommerce.Application.Read.csproj"]
COPY ["src/services/ecommerce/ECommerce.Application.Write/ECommerce.Application.Write.csproj", "services/ecommerce/ECommerce.Application.Write/ECommerce.Application.Write.csproj"]
COPY ["src/services/ecommerce/ECommerce.Domain/ECommerce.Domain.csproj", "services/ecommerce/ECommerce.Domain/ECommerce.Domain.csproj"]
COPY ["src/services/ecommerce/ECommerce.Infrastructure/ECommerce.Infrastructure.csproj", "services/ecommerce/ECommerce.Infrastructure/ECommerce.Infrastructure.csproj"]
COPY ["src/services/ecommerce/ECommerce.Services/ECommerce.Services.csproj", "services/ecommerce/ECommerce.Services/ECommerce.Services.csproj"]
COPY ["src/services/ecommerce/ECommerce.Services.Interfaces/ECommerce.Services.Interfaces.csproj", "services/ecommerce/ECommerce.Services.Interfaces/ECommerce.Services.Interfaces.csproj"]
COPY ["src/shared/ECommerce.Shared/ECommerce.Shared.csproj", "shared/ECommerce.Shared/ECommerce.Shared.csproj"]
COPY ["src/shared/Integration.Events/Integration.Events/Integration.Events.csproj", "shared/Integration.Events/Integration.Events/Integration.Events.csproj"]
COPY ["src/buildingBlocks/EventBusRabbitMQ/EventBusRabbitMQ.csproj", "buildingBlocks/EventBusRabbitMQ/EventBusRabbitMQ.csproj"]
COPY ["src/buildingBlocks/EventBus/EventBus.csproj", "buildingBlocks/EventBus/EventBus.csproj"]
RUN dotnet restore "services/ecommerce/ECommerce.Api/ECommerce.Api.csproj"

COPY ["src/", "."]
WORKDIR "/src/services/ecommerce/ECommerce.Api"
RUN dotnet build "ECommerce.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECommerce.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.Api.dll"]