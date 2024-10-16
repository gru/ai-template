FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Src/AI.ProjectName.Migrations/AI.ProjectName.Migrations.csproj", "Src/AI.ProjectName.Migrations/"]
COPY ["Src/AI.ProjectName.Entities/AI.ProjectName.Entities.csproj", "Src/AI.ProjectName.Entities/"]
RUN dotnet restore "Src/AI.ProjectName.Migrations/AI.ProjectName.Migrations.csproj"
COPY . .
WORKDIR "/src/Src/AI.ProjectName.Migrations"
RUN dotnet build "AI.ProjectName.Migrations.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AI.ProjectName.Migrations.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AI.ProjectName.Migrations.dll"]
