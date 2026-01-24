using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Workers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option => {
        option.LoginPath = "/Login/Login";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        option.Cookie.Name = "TaliExpressAuth";
        option.Cookie.HttpOnly = true;
        option.Cookie.SameSite = SameSiteMode.None;
        option.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        option.SlidingExpiration = true;
    });

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials();
    });
});

builder.Services.AddScoped<IRegister, RegistrationWorker>();
builder.Services.AddScoped<ILogin, LoginWorker>();
builder.Services.AddScoped<IAccount, AccountWorker>();
builder.Services.AddScoped<IStore, StoreWorker>();

var app = builder.Build();
app.UseCookiePolicy();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("AllowAngular");

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();