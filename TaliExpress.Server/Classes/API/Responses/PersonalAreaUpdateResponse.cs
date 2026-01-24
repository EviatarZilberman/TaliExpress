using TaliExpress.Server.Models;

namespace TaliExpress.Server.Classes.API.Responses
{
    public class PersonalAreaUpdateResponse : BaseApiResponse
    {
        public User ReturnedUser { get; set; } = null!;
    }
}
