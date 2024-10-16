using AI.Project.Entities;
using AI.Project.Http.Contracts;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestEase;
using Xunit;

namespace AI.Project.Tests;

public class AggregateIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly IAggregateV1Controller _client;

    internal AggregateIntegrationTests(WebApplicationFactory<Program> factory)
    {
        var testFactory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<ProjectDbContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<ProjectDbContext>(options =>
                {
                    options.UseInMemoryDatabase("TestDatabase");
                });
            });
        });

        var httpClient = testFactory.CreateClient();
        _client = RestClient.For<IAggregateV1Controller>(httpClient);
    }

    [Fact]
    public async Task CreateAndGetAggregate_ShouldSucceed()
    {
        var command = new CreateAggregateCommand
        {
            Name = "Test Aggregate"
        };

        var id = await _client.CreateAggregate(command);
        var aggregate = await _client.GetAggregate(id);

        Assert.NotEqual(0, id);
        Assert.Equal(id, aggregate.Id);
        Assert.Equal(command.Name, aggregate.Name);
    }
}