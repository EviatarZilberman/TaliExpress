using System.Text.Json.Serialization;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Classes.AngularObjects
{
    public sealed class UserAng : BaseAngular, IAdapt<UserDbModel>
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; } = string.Empty;
        [JsonPropertyName("lastName")]
        public string LastName { get; set; } = string.Empty;
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;
        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; } = string.Empty;
        [JsonPropertyName("status")]
        public int Status { get; set; } = (int)UserStatus.Inactive;
        [JsonPropertyName("loginTries")]
        public int LoginTries { get; set; } = 0;
        [JsonPropertyName("lastLogin")]
        public DateTime LastLogin { get; set; } = DateTime.MinValue;

        public void Adapt(UserDbModel item)
        {
            this.Id = item.Id.ToString();
            this.PhoneNumber = item.PhoneNumber;
            Password = item.Password;
            this.Status = item.Status;
            this.Email = item.Email;
            this.LoginTries = item.LoginTries;
            this.CreatedAt = item.CreationDate;
            this.FirstName = item.FirstName;
            this.LastName = item.LastName;
            this.LastLogin = item.LastLogin;
        }
    }
}
