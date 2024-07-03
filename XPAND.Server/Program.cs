using AspNetCore.Identity.Mongo;
using AspNetCore.Identity.Mongo.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using System.Text;
using XPAND.Server;
using XPAND.Server.MappingProfiles;
using XPAND.Server.Models;
using XPAND.Server.Models.DataSeed;
using XPAND.Server.Models.Jwt;
using XPAND.Server.Models.Mongo;
using XPAND.Server.Mongo.Repository;
using XPAND.Server.Mongo.Repository.Implementation;
using XPAND.Server.Mongo.SeedData;
using XPAND.Server.Services;
using XPAND.Server.Services.Implementation;

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
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

builder.Services.AddSingleton<IMongoDbSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
builder.Services.AddSingleton<IDataSeedSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<DataSeedSettings>>().Value);
builder.Services.AddSingleton<IJwtSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<JwtSettings>>().Value);

builder.Services.AddSingleton<IMongoRepository<Planet>, MongoRepository<Planet>>();
builder.Services.AddSingleton<IMongoRepository<Team>, MongoRepository<Team>>();
builder.Services.AddSingleton<IMongoRepository<Captain>, MongoRepository<Captain>>();
builder.Services.AddSingleton<IMongoRepository<Robot>, MongoRepository<Robot>>();

builder.Services.AddScoped<IPlanetService, PlanetService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IUserService, UserService>();
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

builder.Services.AddIdentity<AppUser, MongoRole>()
    .AddMongoDbStores<AppUser, MongoRole, ObjectId>(mongoOptions =>
    {
        var mongoDbSettings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
        mongoOptions.ConnectionString = $"{mongoDbSettings.ConnectionString}/{mongoDbSettings.DatabaseName}";
    })

    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
       {
           var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
           options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = true,
               ValidateAudience = true,
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true,
               ValidIssuer = jwtSettings.Issuer,
               ValidAudience = jwtSettings.Issuer,
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
           };
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

using (var scope = app.Services.CreateScope())
{
    var dataSeeder = scope.ServiceProvider.GetRequiredService<IDataSeeder>();
    dataSeeder.SeedPlanetsAsync().Wait();
    dataSeeder.SeedTeamsAsync().Wait();
    dataSeeder.SeedUsersAsync().Wait();
}

app.Run();
