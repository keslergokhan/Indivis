using Indivis.Core.Application;
using Indivis.Infrastructure.Persistence;
using Indivis.Presentation.WebUI.Controllers;
using Indivis.Presentation.WebUI.Widgets;
using Indivis.Presentation.WebUICms.Middleware;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services
    .AddPersistence(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddWebUIController();


builder.Services.AddScoped<CmsLanguageControlMiddleware>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseMiddleware<CmsLanguageControlMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AccountCms}/{action=Login}");

app.MapDefaultControllerRoute();

app.WebCmsUIDynamicUseEndpoints();
app.Run();
