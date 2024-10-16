FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Src/AI.Project.Host/AI.Project.Host.csproj", "Src/AI.Project.Host/"]
COPY ["Src/AI.Project/AI.Project.csproj", "Src/AI.Project/"]
COPY ["Src/AI.Project.Http.Contracts/AI.Project.Http.Contracts.csproj", "Src/AI.Project.Http.Contracts/"]
COPY ["Src/AI.Project.Entities/AI.Project.Entities.csproj", "Src/AI.Project.Entities/"]
RUN dotnet restore "Src/AI.Project.Host/AI.Project.Host.csproj"
COPY . .
WORKDIR "/src/Src/AI.Project.Host"
RUN dotnet build "AI.Project.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AI.Project.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AI.Project.Host.dll"]
