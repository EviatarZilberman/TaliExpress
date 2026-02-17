using TaliExpress.Server.Classes.API.Requests;
using TaliExpress.Server.Classes.API.Responses;

namespace TaliExpress.Server.Interfaces
{
    public interface IRegister
    {
        public Task<RegisterResponse> Register(RegisterRequest request);
    }
}