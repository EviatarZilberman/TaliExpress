using EmailSender;
using TaliExpress.Server.Classes.Common;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Managers;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Workers
{
    public class RegistrationWorker : IRegister
    {
        public async Task<ReturnCode> Register(RegistrationUser user)
        {
            if (user == null) return ReturnCode.User_is_null;
            UsersManager usersManager = new UsersManager();
            if (usersManager.FindByEmail(user.Email, out User? temp) == ReturnCode.Success)
            {
                return ReturnCode.User_exist;
            }
            if (!RegistrationUser.Validate(user)) return ReturnCode.Invalid_parameters;
            if (user.TempPassword != user.Password) return ReturnCode.Unmatched_passwords; User modelUser = new User()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
            };
            ReturnCode result = await usersManager.Insert(modelUser);
            if (result == ReturnCode.Success)
            {
                EmailModel email = new EmailModel(modelUser.Email, "Seccussfully Registration", "Thank you for registering to TaliExpress!");
                await EmailManager.Instance().SendEmailModelAsync(email);
                return result;
            }
            return ReturnCode.Cannot_insert_to_DB;
        }
    }
}
