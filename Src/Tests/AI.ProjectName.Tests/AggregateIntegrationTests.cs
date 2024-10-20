﻿using AI.ProjectName.Entities;
using AI.ProjectName.Http.Contracts;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestEase;
using Xunit;

namespace AI.ProjectName.Tests;

public class AggregateIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly IAggregateV1Controller _client;

    public AggregateIntegrationTests(WebApplicationFactory<Program> factory)
    {
        var testFactory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<ProjectNameDbContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContextPool<ProjectNameDbContext>(options =>
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