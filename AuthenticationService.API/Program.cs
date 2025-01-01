using System.Text;
using AuthenticationService.Application.Interfaces;
using AuthenticationService.Application.UseCases;
using AuthenticationService.Application.UseCases.DeleteUser;
using AuthenticationService.Application.UseCases.EditUser;
using AuthenticationService.Application.UseCases.GetUser;
using AuthenticationService.Application.UseCases.Login;
using AuthenticationService.Domain.Interfaces;
using AuthenticationService.Infrastructure.Configurations;
using AuthenticationService.Infrastructure.Repositories;
using AuthenticationService.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// ******Add services to the container.******
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

// Access the Configuration object
var configuration = builder.Configuration;
//DbContext
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Get Auth0 configuration
//var auth0Settings = builder.Configuration.GetSection("Auth0");
//var jwtSettings = builder.Configuration.GetSection("Jwt");

//JWT Authentication
/*builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        //options.Authority = $"https://{auth0Settings["Domain"]}";
        //options.Audience = auth0Settings["Audience"];
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            //ValidIssuer = $"https://{auth0Settings["Domain"]}",
            ValidIssuer = "GreenhouseAuthenticationService",
            //ValidAudience = auth0Settings["Audience"]
        };
    });*/

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Allow frontend origin
            .AllowAnyHeader()                    // Allow all headers
            .AllowAnyMethod();                   // Allow all HTTP methods
    });
});
// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"], 
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
        };
    });

// Repositories and Services
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

// Use Cases
builder.Services.AddScoped<RegisterUserUseCase>();
builder.Services.AddScoped<LoginUserUseCase>();
builder.Services.AddScoped<GetUserUseCase>();
builder.Services.AddScoped<EditUserUseCase>();
builder.Services.AddScoped<DeleteUserUseCase>();

builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Authentication API v1");
        c.RoutePrefix = string.Empty; // Root path
    });
}
app.UseCors("AllowSpecificOrigins");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
