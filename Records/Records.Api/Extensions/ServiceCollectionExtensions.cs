using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MobileParkTask.Records.Data;

namespace MobileParkTask.Records.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRecordsServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<RecordsDbContext>(opt => opt.UseNpgsql(connectionString));

        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

        return services;
    }
}