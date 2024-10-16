# AI Microservice Template

This template provides a foundation for building microservices using .NET 8 and C# 12. It includes a basic project structure, API versioning, Swagger integration, and other best practices for microservice development.

## Features

- .NET 8 and C# 12
- API versioning
- Swagger/OpenAPI documentation
- Entity Framework Core with PostgreSQL
- Serilog for structured logging
- FluentValidation for request validation
- Feature flags with Microsoft.FeatureManagement
- Unit and integration tests with xUnit
- Docker support

## Prerequisites

- .NET 8 SDK
- PostgreSQL database server

## Getting Started

### Installing from NuGet

1. Install the template:
   ```
   dotnet new --install AI.Microservice.Template
   ```

### Installing from local .nupkg file

If you have a local .nupkg file of the template, you can install it using the following steps:

1. Navigate to the directory containing the .nupkg file
2. Run the following command:
   ```
   dotnet new install ./AI.Microservice.Template.0.1.0.nupkg --force
   ```
   Replace `1.0.0` with the actual version number of your .nupkg file.

### Creating a new project

After installing the template (either from NuGet or local .nupkg), you can create a new project:

1. Create a new project:
   ```
   dotnet new ai-template --projectName Project --aggregateName Aggregate
   ```

2. Navigate to the project directory:
   ```
   cd YourProjectName
   ```

3. Update the connection string in `appsettings.Development.json` with your PostgreSQL database details.

4. Apply database migrations:
   ```
   dotnet ef database update --project Src/AI.ProjectName.Migrations
   ```

5. Run the project:
   ```
   dotnet run --project Src/AI.ProjectName.Host
   ```

## Project Structure

- `AI.ProjectName`: Core business logic and domain models
- `AI.ProjectName.Entities`: Database entities and DbContext
- `AI.ProjectName.Host`: API host project
- `AI.ProjectName.Http.Contracts`: API contracts (DTOs and interfaces)
- `AI.ProjectName.Migrations`: Database migrations
- `AI.ProjectName.Tests`: Unit and integration tests

## Configuration

- Database connection string is configured in `appsettings.Development.json`
- Logging configuration can be found in `appsettings.json`
- Feature flags are managed through the `FeatureManagement` section in `appsettings.json`

## Adding New Features

1. Create new entities in the `AI.ProjectName.Entities` project
2. Add corresponding DTOs in `AI.ProjectName.Http.Contracts`
3. Implement business logic in `AI.ProjectName`
4. Create new controllers in `AI.ProjectName.Host`
5. Add integration tests in `AI.ProjectName.Tests`

## Running Tests

```
dotnet test
```

## Docker Support

A Dockerfile is provided for containerization. To build and run the Docker image:

```
docker build -t ai-microservice .
docker run -p 8080:80 ai-microservice
```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This template is open-source and available under the MIT License.