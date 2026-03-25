namespace TaliExpress.Server.SecuritySettings.Classes
{
    public sealed class JwtRequest
    {
        public Dictionary<string, string> JwtPairs { get; set; } = new Dictionary<string, string>();
        public int ExpireInSeconds { get; set; } = 0;
    }
}