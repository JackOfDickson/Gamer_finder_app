using Microsoft.AspNetCore.Identity;
using webapi.Models;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<GamerFinderDatabaseSettings>()
    .AddDefaultTokenProviders();

// Add services to the container.

builder.Services.Configure<GamerFinderDatabaseSettings>(
    builder.Configuration.GetSection("GamerFinderDatabase"));

builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<UserCredentialsService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
