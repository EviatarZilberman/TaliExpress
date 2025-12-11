using ConfigApp.Classes;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Workers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    //options.AddPolicy(ConfigurationsKeeper.Instance().GetValue(ConfigurationsKeys.Allow_frontend.ToString()), builder =>
    options.AddPolicy("AllowAngular", builder =>
    {
        //builder.WithOrigins(ConfigurationsKeeper.Instance().GetValue(ConfigurationsKeys.client_location.ToString()))
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
builder.Services.AddScoped<IRegister, RegistrationWorker>();
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("AllowAngular");
//app.UseCors(ConfigurationsKeeper.Instance().GetValue(ConfigurationsKeys.Allow_frontend.ToString()));

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();