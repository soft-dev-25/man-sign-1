using api.DBContext;
using api.ExceptionHandlers;
using api.Repositories;
using api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPersonsService, PersonsService>();
builder.Services.AddScoped<IPersonsRepository, PersonsRepository>();
builder.Services.AddScoped<IJsonService, JsonService>();
builder.Services.AddDbContext<DataContext>();

// Custom ExceptionHandlers
builder.Services.AddExceptionHandler<BadRequestExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
        policy.WithOrigins("http://localhost:8080")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseCors("AllowFrontend");


app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

var httpsPort = app.Configuration["ASPNETCORE_HTTPS_PORT"];
if (!string.IsNullOrEmpty(httpsPort))
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

// Run Migration
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    await dbContext.Database.MigrateAsync();
}

await app.RunAsync();
