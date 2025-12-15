using Eviatar.Zilberman.JsonHandler.Classes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Managers;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Workers
{
    public class LoginWorker : ILogin
    {
        public async Task<(ReturnCode result, string user)> Login(string email, string password, HttpContext httpContext, bool stayLoggedIn = false)
        {
            ClaimsPrincipal claimUser = httpContext.User;

            if (claimUser.Identity!.IsAuthenticated)
            {
                //return RedirectToAction("Index", "Home");
            }
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) return (ReturnCode.No_parameters_entered, string.Empty);
            UsersManager usersManager = new UsersManager();
            if (usersManager.Get(email, out User? user) != Enums.ReturnCode.Success) return (ReturnCode.No_user_found, string.Empty);
            if (user != null)
            {
                if (user.Password != password)
                {
                    user.LoginTries++;
                    usersManager.Update(user);
                    return (ReturnCode.Incorrect_password, string.Empty);
                }
                user.LoginTries = 0;
                user.LastLogin = DateTime.Now;
                usersManager.Update(user);

                List<Claim> claims = new List<Claim>() {
                    new Claim(CookiesKeys.Email.ToString(),user.Email)
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {

                    AllowRefresh = true,
                    IsPersistent = stayLoggedIn
                };

                await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);

                string jsonUser = SerializeHandler<User>.Serialize(user);
                return (ReturnCode.Success, jsonUser);
            }
            return (ReturnCode.No_user_found, string.Empty);
        }

        public async Task<ReturnCode> LogOut(HttpContext httpContext)
        {
            try
            {
                await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return ReturnCode.Success;
            }
            catch
            {
                return ReturnCode.General_Error;
            }
        }
    }
}