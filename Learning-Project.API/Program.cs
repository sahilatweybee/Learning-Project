using Learning_Project.API.Filters;
using Learning_Project.Data;
using Learning_Project.GraphQL;
using Learning_Project.Repository;
using Learning_Project.Service;
using GraphQL.Server.Ui.GraphiQL;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(config =>
{
    config.Filters.Add<AuthorizationFilter>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddGraphQL();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opt =>
    {
        opt.DocumentTitle = "Learning-Project";
        opt.DocExpansion(DocExpansion.None);
        opt.EnableTryItOutByDefault();
        opt.EnableFilter();
    });
}

app.UseHttpsRedirection();
app.UseGraphQLGraphiQL("/UI/GraphQL");

app.UseGraphQLAPIs();

app.UseAuthorization();

app.MapControllers();

app.Run();
