using Microsoft.Extensions.DependencyInjection;
using AI.Project.Aggregate;

namespace AI.Project
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<AggregateHandler>();

            return services;
        }
    }
}