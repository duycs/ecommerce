#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
RUN apk update && apk add tzdata
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["src/services/synchronize/Synchronize.Api/Synchronize.Api.csproj", "services/synchronize/Synchronize.Api/Synchronize.Api.csproj"]
COPY ["src/services/synchronize/Synchronize.BackgroundTasks/Synchronize.BackgroundTasks.csproj", "services/synchronize/Synchronize.BackgroundTasks/Synchronize.BackgroundTasks.csproj"]
COPY ["src/services/synchronize/Synchronize.Domain/Synchronize.Domain.csproj", "services/synchronize/Synchronize.Domain/Synchronize.Domain.csproj"]
COPY ["src/services/synchronize/Synchronize.Infrastructure/Synchronize.Infrastructure.csproj", "services/synchronize/Synchronize.Infrastructure/Synchronize.Infrastructure.csproj"]
COPY ["src/shared/ECommerce.Shared/ECommerce.Shared.csproj", "shared/ECommerce.Shared/ECommerce.Shared.csproj"]
COPY ["src/shared/Integration.Events/Integration.Events/Integration.Events.csproj", "shared/Integration.Events/Integration.Events/Integration.Events.csproj"]
COPY ["src/shared/Scheduler.Jobs/Scheduler.Jobs.csproj", "shared/Scheduler.Jobs/Scheduler.Jobs.csproj"]
COPY ["src/buildingBlocks/EventBusRabbitMQ/EventBusRabbitMQ.csproj", "buildingBlocks/EventBusRabbitMQ/EventBusRabbitMQ.csproj"]
COPY ["src/buildingBlocks/EventBus/EventBus.csproj", "buildingBlocks/EventBus/EventBus.csproj"]
RUN dotnet restore "services/synchronize/Synchronize.Api/Synchronize.Api.csproj"

COPY ["src/", "."]
WORKDIR "/src/services/synchronize/Synchronize.Api"
RUN dotnet build "Synchronize.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Synchronize.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Synchronize.Api.dll"]