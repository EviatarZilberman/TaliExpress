using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using TaliExpress.Server.Classes.AngularObjects;
using TaliExpress.Server.Classes.API.Responses;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Managers;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Workers
{
    public class LoginWorker : ILogin
    {
        public async Task<LoginResponse> Login(string email, string password, bool stayLoggedIn, HttpContext httpContext)
        {
            ClaimsPrincipal claimUser = httpContext.User;

            if (claimUser.Identity!.IsAuthenticated)
            {
                //return RedirectToAction("Index", "Home");
            }
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return new LoginResponse()
                {
                    Code = (int)ReturnCode.Parameter_is_null_or_empty,
                    Message = "Email or password is invalid"
                };
            }
            UsersManager usersManager = new UsersManager();
            if (!usersManager.FindByEmail(email, out UserDbModel? user))
            {
                return new LoginResponse()
                {
                    Code = (int)ReturnCode.No_user_found,
                    Message = "Email or password is invalid"
                };
            }
            if (user != null)
            {
                if (user.Password != password)
                {
                    user.LoginTries++;//TODO = BLOCK USERS AFTER SOME FAILED LOGINS.
                    usersManager.Update(user);
                    return new LoginResponse()
                    {
                        Code = (int)ReturnCode.Invalid_parameters,
                        Message = "Email or password is invalid"
                    };
                }
                user.LoginTries = 0;
                user.LastLogin = DateTime.Now;
                usersManager.Update(user);

                List<Claim> claims = new List<Claim>() {
                    new Claim(CookiesKeys.Email.ToString(),user.Email),
                    new Claim(CookiesKeys.ID.ToString() ,user.Id.ToString())
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

                StoresManager storesManager = new StoresManager();
                storesManager.GetByUserId(user.Id.ToString(), out StoreDbModel? store);
                CartManager cartsManager = new CartManager();
                cartsManager.GetByUserId(user.Id.ToString(), out CartDbModel? cart);
                //JwtRequest jwtRequest = new JwtRequest()
                //{
                //    ExpireInSeconds = 3600,
                //    JwtPairs = new Dictionary<string, string>()
                //    {
                //        { CookiesKeys.Email.ToString(), user.Email },
                //        { CookiesKeys.ID.ToString(), user.Id.ToString() }
                //    }
                //};
                //JWTCreationHandler.CreateJwt(jwtRequest);
                UserAng userAng = new UserAng();
                if (userAng != null) userAng.Adapt(user);
                StoreDataAng storeDataAng = new StoreDataAng();
                if (store != null) storeDataAng.Adapt(store);
                CartDataAng cartDataAng = new CartDataAng();
                if (cart != null) cartDataAng.Adapt(cart);
                return new LoginResponse()
                {
                    User = userAng!,
                    StoreData = storeDataAng,
                    CartData = cartDataAng,
                    Code = (int)ReturnCode.Success,
                    Message = "Login successful"
                };
            }
            return new LoginResponse()
            {
                Message = "User was not found",
                Code = (int)ReturnCode.No_user_found
            };
        }

        public async Task<LogoutResponse> LogOut(HttpContext httpContext)
        {
            try
            {
                await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return new LogoutResponse
                {
                    Code = (int)ReturnCode.Success
                };
            }
            catch
            {
                return new LogoutResponse
                {
                    Code = (int)ReturnCode.General_Error
                };
            }
        }
    }
}