FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Src/AI.ProjectName.Host/AI.ProjectName.Host.csproj", "Src/AI.ProjectName.Host/"]
COPY ["Src/AI.ProjectName/AI.ProjectName.csproj", "Src/AI.ProjectName/"]
COPY ["Src/AI.ProjectName.Http.Contracts/AI.ProjectName.Http.Contracts.csproj", "Src/AI.ProjectName.Http.Contracts/"]
COPY ["Src/AI.ProjectName.Entities/AI.ProjectName.Entities.csproj", "Src/AI.ProjectName.Entities/"]
RUN dotnet restore "Src/AI.ProjectName.Host/AI.ProjectName.Host.csproj"
COPY . .
WORKDIR "/src/Src/AI.ProjectName.Host"
RUN dotnet build "AI.ProjectName.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AI.ProjectName.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AI.ProjectName.Host.dll"]
