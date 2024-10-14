using Learning_Project.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDependencies(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureBuilder();
app.ConfigureSwagger(app.Environment);

app.MapControllers();
app.MapHub<ChatHub>("/Chat");

app.Run();
