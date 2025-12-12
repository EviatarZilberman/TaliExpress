using Eviatar.Zilberman.JsonHandler.Classes;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Managers;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Workers
{
    public class LoginWorker : ILogin
    {
        public (ReturnCode result, string user) Login(string email, string password)
        {
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
                //-- TODO- ADD COOKIES!
                user.LoginTries = 0;
                user.LastLogin = DateTime.Now;
                usersManager.Update(user);
                string jsonUser = SerializeHandler<User>.Serialize(user);
                return (ReturnCode.Success, jsonUser);
            }
            return (ReturnCode.No_user_found, string.Empty);
        }
    }
}