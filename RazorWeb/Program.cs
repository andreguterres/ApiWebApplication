﻿using RazorWeb.Interfaces;
using RazorWeb.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorWeb.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RazorWebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorWebContext") ?? throw new InvalidOperationException("Connection string 'RazorWebContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ICliente, ServiceCliente>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Clientes}/{action=Index}/{id?}");

app.Run();
