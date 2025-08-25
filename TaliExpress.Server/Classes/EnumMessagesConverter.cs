using TaliExpress.Server.Enums;

namespace TaliExpress.Server.Classes
{
    public static class EnumMessagesConverter
    {
        public static string? Convert(ReturnCode? code)
        {
            if (code == null) return string.Empty;
            return code.ToString()?.Replace('_', ' ');
        }
    }
}