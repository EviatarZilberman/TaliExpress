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
            if (usersManager.FindByEmail(request.Email, out UserDbModel? temp))
            {
                return new RegisterResponse { Code = -1 };
            }
            //if (!RegistrationUser.Validate(user)) return ReturnCode.Invalid_parameters;
            if (request.TempPassword != request.Password) return new RegisterResponse { Code = -1 };
            UserDbModel modelUser = new UserDbModel()
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber
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
