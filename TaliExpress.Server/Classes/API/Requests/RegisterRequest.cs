namespace TaliExpress.Server.Classes.API.Requests
{
    public sealed class RegisterRequest : BaseApiRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string TempPassword { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}