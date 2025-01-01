using ApiCursoEntityFrameworkCore.ApplicationDb;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseNpgsql(ConnectionString, sql => sql.UseNetTopologySuite());
    //La siguiente linea hace que el AsNoTracking funcione de forma global y no es necesario ponerlo en la query
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    //La siguiente linea hace que el LazyLoading funcione de forma global
    //options.UseLazyLoadingProxies();
});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers()
    //Esto se usa para evitar los problemas con EagerLoading (Include)
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options => 
    {
        options
        .WithTitle("Curso entity framework core")
        .WithTheme(ScalarTheme.Default)
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
        .WithModels(false)
        .WithDefaultOpenAllTags(false);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
