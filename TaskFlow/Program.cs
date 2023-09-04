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

app.UseHttpsRedirection(); //http portu olan �al���rsa https olana zorla demek.

app.UseStaticFiles();  //projeyi ger�ek d�nyaya a�t���nda stil dosyalar�n� (html css vs) eri�ime a�, eri�ilebilir hale getir demek. Bu olmazsa stilleri ger�ek kullan�c�lar g�remez.

app.UseRouting(); //localhost:7216/employee/login gibi ge�i�leri yapmam�z� sa�layan yap�.

app.UseAuthorization();

app.MapDefaultControllerRoute();
app.Run();
