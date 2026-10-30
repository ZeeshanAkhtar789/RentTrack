using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using RentTrack.Api.Data;
using RentTrack.Api.Repositories;
using RentTrack.Api.Services;

//adding logger
var logger = LogManager.Setup().LoadConfigurationFromFile("NLog.config").GetCurrentClassLogger();
logger.Info("Rent api code started");

var builder = WebApplication.CreateBuilder(args);

//Remove default Logging of asp.net and using Nlog
builder.Logging.ClearProviders();
builder.UseNLog();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

//adding swagger UI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RentTrackDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("RentTrackDb")));

// Register Repository layer
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();

// Register Service layer
builder.Services.AddScoped<IPropertyService, PropertyService>();

var app = builder.Build();

var appLogger = app.Services.GetRequiredService<ILogger<Program>>();

app.Lifetime.ApplicationStarted.Register(() =>
    appLogger.LogInformation("RentTrack API started successfully."));

app.Lifetime.ApplicationStopping.Register(() =>
    appLogger.LogInformation("RentTrack API is shutting down."));

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
