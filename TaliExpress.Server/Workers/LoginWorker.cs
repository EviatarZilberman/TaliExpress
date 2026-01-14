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
        public async Task<(ReturnCode result, User user)> Login(string email, string password, HttpContext httpContext, bool stayLoggedIn = false)
        {
            ClaimsPrincipal claimUser = httpContext.User;

            if (claimUser.Identity!.IsAuthenticated)
            {
                //return RedirectToAction("Index", "Home");
            }
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) return (ReturnCode.No_parameters_entered, new User());
            UsersManager usersManager = new UsersManager();
            if (usersManager.Get(email, out User? user) != Enums.ReturnCode.Success) return (ReturnCode.No_user_found, new User());
            if (user != null)
            {
                if (user.Password != password)
                {
                    user.LoginTries++;//TODO = BLOCK USERS AFTERS SOME FAILED LOGINS.
                    usersManager.Update(user);
                    return (ReturnCode.Incorrect_password, new User());
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

                return (ReturnCode.Success, user);
            }
            return (ReturnCode.No_user_found, new User());
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