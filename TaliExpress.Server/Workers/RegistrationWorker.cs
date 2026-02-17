using EmailSender;
using TaliExpress.Server.Classes.API.Requests;
using TaliExpress.Server.Classes.API.Responses;
using TaliExpress.Server.Classes.Common;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Managers;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Workers
{
    public class RegistrationWorker : IRegister
    {
        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            if (request == null) return new RegisterResponse { Code = -1 };
            UsersManager usersManager = new UsersManager();
            if (usersManager.FindByEmail(request.Email, out User? temp))
            {
                return new RegisterResponse { Code = -1 };
            }
            //if (!RegistrationUser.Validate(user)) return ReturnCode.Invalid_parameters;
            if (request.TempPassword != request.Password) return new RegisterResponse { Code = -1 };
            User modelUser = new User()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
            };
            if (usersManager.Insert(modelUser))
            {
                //TODO = CHECK MAIL SENDING.
                EmailModel email = new EmailModel(modelUser.Email, "Seccussfully Registration", "Thank you for registering to TaliExpress!");
                await EmailManager.Instance().SendEmailModelAsync(email);
            return new RegisterResponse();
            }
            return new RegisterResponse { Code = -1 };
        }
    }
}
