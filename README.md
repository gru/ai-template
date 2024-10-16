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

## Usage

### Installing from NuGet

To install the template from NuGet, run the following command:

```bash
dotnet new --install AI.Microservice.Template
```

### Installing from local .nupkg file

If you have a local .nupkg file, you can install the template using:

```bash
dotnet new --install path/to/AI.Microservice.Template.1.0.0.nupkg
```

### Creating a new project

Once installed, you can create a new project using the template:

```bash
dotnet new ai-template -n YourProjectName
```

This will create a new solution with the specified name, ready for you to start developing your microservice.

## Customization

After creating your project, you may want to:

1. Update the connection string in `appsettings.json` for your database.
2. Modify the `AggregateEntity` and related classes to fit your domain model.
3. Add additional controllers, services, and entities as needed for your microservice.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This template is open-source and available under the MIT License.