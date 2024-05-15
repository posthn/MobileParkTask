namespace MobileParkTask.Executable.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication ConfigureAppServices(this WebApplication app)
    {
        app.MapControllers();

        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}