using libraly.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var allowOriginConfig = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowOriginConfig,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:4200")
                                                .AllowAnyHeader()
                                                .AllowAnyMethod();

                      });
});
var connectionString = builder.Configuration.GetConnectionString("DevConnection");
builder.Services.AddDbContext<libraryContext>(x => x.UseSqlServer(connectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(allowOriginConfig);

app.UseAuthorization();

app.MapControllers();

app.Run();
