using Eviatar.Zilberman.Validators.Interfaces;

namespace Eviatar.Zilberman.Validators.Classes
{
    public class StringLengthValidator : IValidate
    {
        private readonly int Min = 0;
        private readonly int Max = 0;

        public StringLengthValidator(int min, int max) 
        {
            this.Min = min;
            this.Max = max;
        }

        public bool Validate(object value)
        {
            string? item = value as string;
            if (item!.Length < this.Min) return false;
            if (item.Length > this.Max) return false;
            return true;
        }
    }
}
