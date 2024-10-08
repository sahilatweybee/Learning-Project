using Learning_Project.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDependencies(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureSwagger(app.Environment);
app.ConfigureBuilder();

app.MapControllers();
app.MapHub<ChatHub>("/Chat", opt =>
{
    opt.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets;
});

app.Run();
