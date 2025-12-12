using TaliExpress.Server.Enums;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Managers;
using TaliExpress.Server.Models;
using Eviatar.Zilberman.Validators.Classes;

namespace TaliExpress.Server.Classes
{
    public class LoginWorker : ILogin
    {
        public (ReturnCode result, User? user) Login(string email, string password)
        {
            if (!new StringEmptyOrNullValidator().Validate(email) || !new StringEmptyOrNullValidator().Validate(password)) return (ReturnCode.No_parameters_entered, null);

            UsersManager usersManager = new UsersManager();
            if (usersManager.FindByEmail(email, out User user) != ReturnCode.Success) return (ReturnCode.No_user_found, null);
            if (user.Password != password) return (ReturnCode.Invalid_parameters, null);
            return (ReturnCode.Success, user);
        }
    }
}
