using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using TaskFlow.Context;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using TaskFlow.Entities.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.Configure<DbConnection>(builder.Configuration.GetSection("MyDatabaseConnection"));

builder.Services.AddSingleton<DbConnection>();


//builder.Services.AddSingleton<IDbConnection>(options =>
//{
//    var configuration = options.GetRequiredService<IConfiguration>();
//    var connectionString = configuration.GetConnectionString("MyDatabaseConnection");
//    return new NpgsqlConnection(connectionString);
//});

// Add services to the container.

builder.Services.AddControllersWithViews();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); //http portu olan çalýþýrsa https olana zorla demek.

app.UseStaticFiles();  //projeyi gerçek dünyaya açtýðýnda stil dosyalarýný (html css vs) eriþime aç, eriþilebilir hale getir demek. Bu olmazsa stilleri gerçek kullanýcýlar göremez.

app.UseRouting(); //localhost:7216/employee/login gibi geçiþleri yapmamýzý saðlayan yapý.

app.UseAuthorization();

app.MapDefaultControllerRoute();
app.Run();
