using Microsoft.AspNetCore.Identity;
using Ryder.Api.Configurations;
using Ryder.Application;
using Ryder.Domain.Entities;
using Ryder.Domain.SeedData;
using Ryder.Infrastructure;
using Ryder.Infrastructure.Implementation;
using Ryder.Infrastructure.Interface;
using MediatR;
using Ryder.Application.User.Query.ResendConfirmationEmail;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserService, UserService>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();

builder.Services.ConfigureIdentity();
builder.Services.ConfigureJwtAuthentication(builder.Configuration);
builder.Services.AddDbContextAndConfigurations(builder.Environment, builder.Configuration);
builder.Services.ApplicationDependencyInjection();
builder.Services.InjectInfrastructure(builder.Configuration);

// Add configuration settings from appsettings.json
builder.WebHost.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<AppUser>>();

    SeedData.Initialize(userManager);
}

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