using Indivis.Infrastructure.Persistence;
using Indivis.Core.Application;
using Indivis.Presentation.WebUI.System;
using Indivis.Presentation.WebUI.Controllers;
using Indivis.Presentation.WebUI.Widgets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services
    .AddPersistence(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddWebUIController();




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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.WebUIDynamicUseEndpoints();


app.Run();
