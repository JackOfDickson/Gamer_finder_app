using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using webapi.Models;
using webapi.Models.AppSettings;
using webapi.Services;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);
var AllowedSpecificOrigins = "_allowedSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowedSpecificOrigins,
                        policy  =>
                        {
                            policy.WithOrigins("http://localhost:3000")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                        });
});


// Add services to the container.

builder.Services.Configure<GamerFinderDatabaseSettings>(
    builder.Configuration.GetSection("GamerFinderDatabase"));
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JwtSettings"));

var jwtSettings = new JwtSettings();
builder.Configuration.GetSection("JwtSettings").Bind(jwtSettings);

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = jwtSettings.Issuer,
//            ValidAudience = jwtSettings.Audience,
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
//            ClockSkew = TimeSpan.Zero // Set the clock skew to zero to account for any time differences
//        };
//    });

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
app.UseRouting();
app.UseCors(AllowedSpecificOrigins);
app.UseHttpsRedirection();

//app.UseAuthentication();
//app.UseAuthorization();


app.MapControllers();

app.Run();
