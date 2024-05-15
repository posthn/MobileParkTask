using MobileParkTask.News.Api.Extensions;
using MobileParkTask.Records.Api.Extensions;

namespace MobileParkTask.Executable.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();

        services.AddNewsServices(configuration["NewsApiUrl"], configuration["NewsApiKey"]);
        services.AddRecordsServices(configuration["RecordsDbConnectionString"]);

        return services;
    }
}