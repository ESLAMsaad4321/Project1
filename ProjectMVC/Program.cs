using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.Options;
using Project.Models;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

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
app.UseSession();

//Authorization Middleware
// Add header:
app.Use((context, next) =>
{
    context.Request.Headers["Authorization"] = context.Session.GetString("Authorization") == null ? "" : context.Session.GetString("Authorization");
    return next.Invoke();
}); 
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
