using Learning_Project.API;
using Learning_Project.API.GRPC.Services;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc(opt =>
{
    opt.EnableDetailedErrors = true;
    opt.IgnoreUnknownServices = true;
    opt.ResponseCompressionLevel = System.IO.Compression.CompressionLevel.Optimal;
    //opt.ResponseCompressionAlgorithm = CompressionAlgorithms.Deflate;
});

builder.Services.AddResponseCompression(opt => opt.EnableForHttps = true);

builder.Services.AddDependencies(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureBuilder();
app.ConfigureSwagger(app.Environment);

app.MapControllers();
app.MapHub<ChatHub>("/Chat");

app.MapGrpcService<HelloGRPCService>();
app.MapGet("/grpc", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");


app.Run();
