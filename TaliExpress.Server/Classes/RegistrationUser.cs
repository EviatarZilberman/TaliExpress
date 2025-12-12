
using Eviatar.Zilberman.Validators.Classes;

namespace TaliExpress.Server.Classes
{
    public sealed class RegistrationUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string TempPassword { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public static bool Validate(RegistrationUser user)
        {
            if (user == null) return false;
            if (!new StringEmptyOrNullValidator().Validate(user.Email) || !new StringLengthValidator(3, 25).Validate(user.Email)) return false;
            if (!new StringEmptyOrNullValidator().Validate(user.FirstName) || !new StringLengthValidator(3, 25).Validate(user.FirstName)) return false;
            if (!new StringEmptyOrNullValidator().Validate(user.LastName) || !new StringLengthValidator(3, 25).Validate(user.LastName)) return false;
            if (!new StringEmptyOrNullValidator().Validate(user.Password) || !new StringLengthValidator(8, 12).Validate(user.Password)) return false;
            return true;
        }
    }
}
