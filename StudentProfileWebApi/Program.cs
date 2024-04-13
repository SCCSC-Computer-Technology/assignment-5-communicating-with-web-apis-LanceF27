using Microsoft.EntityFrameworkCore;
using StudentProfileWebApi.Models;
using Microsoft.AspNetCore.HttpLogging; //HttpLoggingFields

var builder = WebApplication.CreateBuilder(args);

//Tell it where

builder.WebHost.UseUrls("https://localhost:5002/");
// Add services to the container.


builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = HttpLoggingFields.All;
    options.RequestBodyLogLimit = 4096; //default is 32k
    options.ResponseBodyLogLimit = 4096; //default is 32k
});
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddRazorComponents();
builder.Services.AddDbContext<StudentProfileContext>(x => x.UseInMemoryDatabase("StudentProfiles"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseHttpLogging();
    app.UseHealthChecks(path: "/howdoyoufeel");
    app.UseCors(configurePolicy: options =>
    {
        options.WithMethods("GET", "POST", "PUT", "DELETE");
        options.WithOrigins(
            "https://localhost:7103");
    });
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();