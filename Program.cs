using Microsoft.EntityFrameworkCore;
using TestApp.Data;


var builder = WebApplication.CreateBuilder(args);

var connectString = builder.Configuration.GetConnectionString("CosmosDB")
    ?? throw new InvalidOperationException("Connection string 'CosmosDB' not found.");

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseCosmos(connectString, "TestDB"));

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// https://cosmosrgeastus802fdafb-398d-4861-910adb.documents.azure.com:443/
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run();

