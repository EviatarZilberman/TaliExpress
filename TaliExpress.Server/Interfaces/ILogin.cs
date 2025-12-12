using TaliExpress.Server.Enums;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Interfaces
{
    public interface ILogin
    {
        public (ReturnCode result, User? user) Login(string email, string password);
    }
}
