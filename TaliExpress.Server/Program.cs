using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using MongoDBService.Classes;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.SecuritySettings.Managers;
using TaliExpress.Server.SecuritySettings.SecuritySettingsModels;
using TaliExpress.Server.Workers;

MongoDBServiceManager.Initialize("mongodb://localhost:27017/", "TaliExpress");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
     {
         option.LoginPath = "/Login/Login";
         option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
         option.Cookie.Name = "TaliExpressAuth";
         option.Cookie.HttpOnly = true;
         //option.Cookie.SameSite = SameSiteMode.None;
         option.Cookie.SameSite = SameSiteMode.Lax; //-- For development only
         option.Cookie.SecurePolicy = CookieSecurePolicy.Always;
         option.SlidingExpiration = true;
         option.Events.OnRedirectToLogin = context => // Handle the 401/403 for API endpoints
         {
             context.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
             return Task.CompletedTask;
         };
     });

//     builder.Services.AddAuthentication(x =>
//{
//    x.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    x.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    x.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//}).AddJwtBearer(x =>
//{
//    SecuritySettingsManager securitySettingsManager = new SecuritySettingsManager();
//    securitySettingsManager.FindBySubjectId("Issuer", out SecuritySettingsDbModel securitySettingsDbModel1);
//    securitySettingsManager.FindBySubjectId("Audience", out SecuritySettingsDbModel securitySettingsDbModel2);
//    securitySettingsManager.FindBySubjectId("Key", out SecuritySettingsDbModel securitySettingsDbModel3);
//    x.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidIssuer = securitySettingsDbModel1.Value,
//        ValidAudience = securitySettingsDbModel2.Value,
//        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(securitySettingsDbModel3.Value)),
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true
//    };
//}).AddCookie(option =>
//{
//    option.LoginPath = "/Login/Login";
//    option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
//    option.Cookie.Name = "TaliExpressAuth";
//    option.Cookie.HttpOnly = true;
//    option.Cookie.SameSite = SameSiteMode.Lax; //-- For development only
//    option.Cookie.SecurePolicy = CookieSecurePolicy.Always;
//    option.SlidingExpiration = true;
//    option.Events.OnRedirectToLogin = context => // Handle the 401/403 for API endpoints
//    {
//        context.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
//        return Task.CompletedTask;
//    };
//});
builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", builder =>
    {
        builder.WithOrigins("https://localhost:4200")
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