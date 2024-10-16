using Microsoft.Extensions.DependencyInjection;
using AI.ProjectName.Aggregate;

namespace AI.ProjectName
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