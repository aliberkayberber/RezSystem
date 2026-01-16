using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RezSystem.Business.DataProtection;
using RezSystem.Business.Operations.User;
using RezSystem.Data.Context;
using RezSystem.Data.Repositories;
using RezSystem.Data.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDataProtection, DataProtection>();

var keysDirectory = new DirectoryInfo(Path.Combine(builder.Environment.ContentRootPath,"App_Data", "Keys"));

builder.Services.AddDataProtection()
    .SetApplicationName("RezSystemApp")
    .PersistKeysToFileSystem(keysDirectory);




var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<RezSystemDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<IUnitOfWork , UnitOfWork>();

builder.Services.AddScoped<IUserService, UserManager>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
