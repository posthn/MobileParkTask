using MobileParkTask.Executable.Extensions;

var builder = WebApplication.CreateBuilder();

builder.Services.AddAppServices(builder.Configuration);

var app = builder.Build();

app.ConfigureAppServices();

app.Run();