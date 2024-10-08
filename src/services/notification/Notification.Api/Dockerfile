#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
RUN apk add tzdata
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["src/services/notification/Notification.Api/Notification.Api.csproj", "services/notification/Notification.Api/Notification.Api.csproj"]
COPY ["src/services/notification/Notification.Application/Notification.Application.csproj", "services/notification/Notification.Application/Notification.Application.csproj"]
COPY ["src/services/notification/Notification.Application.Read/Notification.Application.Read.csproj", "services/notification/Notification.Application.Read/Notification.Application.Read.csproj"]
COPY ["src/services/notification/Notification.Application.Write/Notification.Application.Write.csproj", "services/notification/Notification.Application.Write/Notification.Application.Write.csproj"]
COPY ["src/services/notification/Notification.Domain/Notification.Domain.csproj", "services/notification/Notification.Domain/Notification.Domain.csproj"]
COPY ["src/services/notification/Notification.Infrastructure/Notification.Infrastructure.csproj", "services/notification/Notification.Infrastructure/Notification.Infrastructure.csproj"]
COPY ["src/services/notification/Notification.Services/Notification.Services.csproj", "services/notification/Notification.Services/Notification.Services.csproj"]
COPY ["src/shared/ECommerce.Shared/ECommerce.Shared.csproj", "shared/ECommerce.Shared/ECommerce.Shared.csproj"]
COPY ["src/shared/Integration.Events/Integration.Events/Integration.Events.csproj", "shared/Integration.Events/Integration.Events/Integration.Events.csproj"]
COPY ["src/buildingBlocks/EventBusRabbitMQ/EventBusRabbitMQ.csproj", "buildingBlocks/EventBusRabbitMQ/EventBusRabbitMQ.csproj"]
COPY ["src/buildingBlocks/EventBus/EventBus.csproj", "buildingBlocks/EventBus/EventBus.csproj"]
RUN dotnet restore "services/notification/Notification.Api/Notification.Api.csproj"

COPY ["src/", "."]
WORKDIR "/src/services/notification/Notification.Api"
RUN dotnet build "Notification.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Notification.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=publish /usr/share/zoneinfo /usr/share/zoneinfo
ENTRYPOINT ["dotnet", "Notification.Api.dll"]