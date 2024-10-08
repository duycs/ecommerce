#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["src/services/order/Order.Api/Order.Api.csproj", "services/order/Order.Api/Order.Api.csproj"]
COPY ["src/services/order/Order.Application/Order.Application.csproj", "services/order/Order.Application/Order.Application.csproj"]
COPY ["src/services/order/Order.Application.Read/Order.Application.Read.csproj", "services/order/Order.Application.Read/Order.Application.Read.csproj"]
COPY ["src/services/order/Order.Application.Write/Order.Application.Write.csproj", "services/order/Order.Application.Write/Order.Application.Write.csproj"]
COPY ["src/services/order/Order.Domain/Order.Domain.csproj", "services/order/Order.Domain/Order.Domain.csproj"]
COPY ["src/services/order/Order.Infrastructure/Order.Infrastructure.csproj", "services/order/Order.Infrastructure/Order.Infrastructure.csproj"]
COPY ["src/services/order/Order.Services/Order.Services.csproj", "services/order/Order.Services/Order.Services.csproj"]
COPY ["src/shared/ECommerce.Shared/ECommerce.Shared.csproj", "shared/ECommerce.Shared/ECommerce.Shared.csproj"]
COPY ["src/shared/Integration.Events/Integration.Events/Integration.Events.csproj", "shared/Integration.Events/Integration.Events/Integration.Events.csproj"]
COPY ["src/buildingBlocks/EventBusRabbitMQ/EventBusRabbitMQ.csproj", "buildingBlocks/EventBusRabbitMQ/EventBusRabbitMQ.csproj"]
COPY ["src/buildingBlocks/EventBus/EventBus.csproj", "buildingBlocks/EventBus/EventBus.csproj"]
RUN dotnet restore "services/order/Order.Api/Order.Api.csproj"

COPY ["src/", "."]
WORKDIR "/src/services/order/Order.Api"
RUN dotnet build "Order.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Order.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Order.Api.dll"]