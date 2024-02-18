using Indivis.Infrastructure.Persistence;
using Indivis.Core.Application;
using Serilog;
using Microsoft.Extensions.Configuration;
using Indivis.Presentation.WebUI.System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services
    .AddPersistence(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddWebUISystem();


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

app.AddSystemWebUIApplication();
app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
