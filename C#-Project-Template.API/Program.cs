using C__Project_Template.API.Filters;
using C__Project_Template.Data;
using C__Project_Template.GraphQL;
using C__Project_Template.Repository;
using C__Project_Template.Service;
using GraphQL;
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
        opt.DocumentTitle = "C#-Project-Template";
        opt.DocExpansion(DocExpansion.None);
        opt.EnableTryItOutByDefault();
        opt.EnableFilter();
    });
}

app.UseHttpsRedirection();

app.UseGraphQLGraphiQL("/UI/GraphQL", new GraphiQLOptions()
{
    ExplorerExtensionEnabled = true,
    HeaderEditorEnabled = true,
});

app.UseGraphQL();

app.UseAuthorization();

app.MapControllers();

app.Run();
