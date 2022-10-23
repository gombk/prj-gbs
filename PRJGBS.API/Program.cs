using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PRJGBS.API;
using PRJGBS.Data;
using PRJGBS.Data.Repository;
using PRJGBS.Data.Repository.IRepository;
using PRJGBS.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddResponseCaching();

// configure db
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Dev"));
});

builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

// configure automapper
builder.Services.AddAutoMapper(typeof(MappingConfig));

// add api versioning
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

// configure caching profiles
builder.Services.AddControllers(options =>
{
    options.CacheProfiles.Add(SD.Caching30Sec,
    new CacheProfile()
    {
        Duration = 30
    });

    options.CacheProfiles.Add(SD.Caching60Sec,
    new CacheProfile()
    {
        Duration = 60
    });

    options.CacheProfiles.Add(SD.CachingNoStore,
    new CacheProfile()
    {
        NoStore = true,
        Location = ResponseCacheLocation.None
    });
});

// configure swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1.0",
        Title = "PRJ-GBS V1",
        Description = "API to manage Game Requests",
        //TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Lucas Zenaro",
            Email = "lucas_zenaro@hotmail.com"
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
