using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using XPAND.Server;
using XPAND.Server.MappingProfiles;
using XPAND.Server.Models;
using XPAND.Server.Mongo.Configuration;
using XPAND.Server.Mongo.Repository;
using XPAND.Server.Mongo.SeedData;
using XPAND.Server.Mongo.SeedData.PathConfig;
using XPAND.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.ClearProviders();

builder.Services.AddAutoMapper(typeof(PlanetProfile));

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.Configure<DataSeedSettings>(builder.Configuration.GetSection("DataSeedSettings"));

builder.Services.AddSingleton<IMongoDbSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
builder.Services.AddSingleton<IDataSeedSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<DataSeedSettings>>().Value);

builder.Services.AddSingleton<IMongoRepository<Planet>, MongoRepository<Planet>>();

builder.Services.AddScoped<IPlanetService, PlanetService>();
builder.Services.AddTransient<IDataSeeder, DataSeeder>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EXPAND.Server", Version = "v1" });
    c.SchemaFilter<EnumSchemaFilter>();
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

using (var scope = app.Services.CreateScope())
{
    var dataSeeder = scope.ServiceProvider.GetRequiredService<IDataSeeder>();
    dataSeeder.SeedAsync().Wait();
}

app.Run();
