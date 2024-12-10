using MongoNet.Contracts.Interfaces;
using MongoNet.Contracts.Interfaces.Services;
using MongoNet.Contracts.Models;
using MongoNet.Infra.DataBase;
using MongoNet.Infra.Implementation;
using MongoNet.Infra.Implementation.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dataBaseSetting = new DatabaseSettings();
var configuration = builder.Configuration;

configuration.GetSection(DatabaseSettings.ConfigSection).Bind(dataBaseSetting);
builder.Services.Configure<DatabaseSettings>(
    configuration.GetSection(DatabaseSettings.ConfigSection)
);

builder.Services.AddSingleton<IMongoDbContext, MongoDbContext>();
builder.Services.AddSingleton<IWeatherForeCastRepository, WeatherForeCastRepository>();
builder.Services.AddSingleton<IWeatherForeCastService,WeatherForeCastService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
