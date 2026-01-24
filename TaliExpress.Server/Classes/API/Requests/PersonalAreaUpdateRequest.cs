namespace TaliExpress.Server.Classes.API.Requests
{
    public class PersonalAreaUpdateRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string OriginEmail { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
