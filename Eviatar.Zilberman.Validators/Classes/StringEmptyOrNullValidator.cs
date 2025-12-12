using Eviatar.Zilberman.Validators.Interfaces;

namespace Eviatar.Zilberman.Validators.Classes
{
    public class StringEmptyOrNullValidator : IValidate
    {
        public bool Validate(object? value)
        {
            if (string.IsNullOrEmpty(value as string)) return false;
            if (string.IsNullOrWhiteSpace(value as string)) return false;
            return true;
        }
    }
}
