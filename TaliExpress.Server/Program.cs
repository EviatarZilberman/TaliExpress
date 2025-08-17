using ConfigApp.Classes;
using System.Configuration;
using TaliExpress.Server.Controllers.Interfaces;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUser, User>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy(ConfigurationsKeeper.Instance().GetValue(ConfigurationsKeys.Allow_frontend.ToString()), builder =>
    {
        builder.WithOrigins(ConfigurationsKeeper.Instance().GetValue(ConfigurationsKeys.client_location.ToString()))
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors(ConfigurationsKeeper.Instance().GetValue(ConfigurationsKeys.Allow_frontend.ToString()));

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
