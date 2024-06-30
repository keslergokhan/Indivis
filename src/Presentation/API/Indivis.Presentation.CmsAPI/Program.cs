using Indivis.Core.Application;
using Indivis.Infrastructure.Persistence;
using Indivis.Infrastructure.Persistence.Identities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPersistence(builder.Configuration).AddApplication(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "IndivisCors",
    builder =>
    {
        builder.WithOrigins("https://localhost:7060").AllowCredentials().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.UseCors("IndivisCors");

app.UseAuthentication();
app.UseAuthorization();


app.Run();
