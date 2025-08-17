using Microsoft.AspNetCore.Mvc;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Interfaces
{
    public interface IUser
    {
        public Task<ReturnCode> InsertNewUser(User user);
        public ReturnCode UpdateUser([FromBody] User user);
        public ReturnCode DeleteUser([FromBody] string userId);
        public ReturnCode GetAll(ref User[] users);
        public ReturnCode Get([FromBody] string userId, ref User user);
    }
}
