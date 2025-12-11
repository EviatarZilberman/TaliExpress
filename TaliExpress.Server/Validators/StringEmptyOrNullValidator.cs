using TaliExpress.Server.Interfaces;

namespace TaliExpress.Server.Validators
{
    public class StringEmptyOrNullValidator : IValidate
    {
        public bool Validate(object value)
        {
            if (string.IsNullOrEmpty(value as string)) return false;
            if (string.IsNullOrWhiteSpace(value as string)) return false;
            return true;
        }
    }
}
