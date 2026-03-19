using Microsoft.AspNetCore.Mvc;
using TaliExpress.Server.Classes.API.Requests;
using TaliExpress.Server.Classes.API.Responses;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Managers;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Workers
{
    public class AccountWorker : IAccount
    {
        public PersonalAreaUpdateResponse UpdateAccount(PersonalAreaUpdateRequest request)
        {
            PersonalAreaUpdateResponse reply = new PersonalAreaUpdateResponse();
            try
            {
                UsersManager usersManager = new UsersManager();
                if (!usersManager.FindByEmail(request.OriginEmail, out UserDbModel? user)) return reply;
                user!.FirstName = request.FirstName;
                user!.LastName = request.LastName;
                user!.PhoneNumber = request.PhoneNumber;
                if (!usersManager.Update(user)) return reply;
                reply.Code = (int)ReturnCode.Success;
                return reply;
            }
            catch
            {
                return reply;
            }
        }
    }
}
