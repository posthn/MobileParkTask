using Microsoft.Extensions.DependencyInjection;
using MobileParkTask.News.Clients;

namespace MobileParkTask.News.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNewsServices(this IServiceCollection services, string newsUrl, string newsApiKey)
    {
        services.AddTransient(_ => new NewsClient(newsApiKey, newsUrl));

        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

        return services;
    }
}