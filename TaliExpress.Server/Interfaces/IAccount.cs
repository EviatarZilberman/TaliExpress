using Microsoft.AspNetCore.Mvc;
using TaliExpress.Server.Classes.API.Requests;
using TaliExpress.Server.Classes.API.Responses;

namespace TaliExpress.Server.Interfaces
{
    public interface IAccount
    {
        public PersonalAreaUpdateResponse UpdateAccount(PersonalAreaUpdateRequest request);
    }
}
