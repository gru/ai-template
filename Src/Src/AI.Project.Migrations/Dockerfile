FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Src/AI.Project.Migrations/AI.Project.Migrations.csproj", "Src/AI.Project.Migrations/"]
COPY ["Src/AI.Project.Entities/AI.Project.Entities.csproj", "Src/AI.Project.Entities/"]
RUN dotnet restore "Src/AI.Project.Migrations/AI.Project.Migrations.csproj"
COPY . .
WORKDIR "/src/Src/AI.Project.Migrations"
RUN dotnet build "AI.Project.Migrations.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AI.Project.Migrations.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AI.Project.Migrations.dll"]
