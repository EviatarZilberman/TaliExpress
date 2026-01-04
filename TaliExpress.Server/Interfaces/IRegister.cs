using TaliExpress.Server.Classes.Common;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Interfaces
{
    public interface IRegister
    {
        public Task<ReturnCode> Register(RegistrationUser user);
    }
}