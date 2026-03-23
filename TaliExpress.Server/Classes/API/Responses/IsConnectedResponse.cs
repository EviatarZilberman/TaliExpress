namespace TaliExpress.Server.Classes.API.Responses
{
    public sealed class IsConnectedResponse
    {
        public int code { get; set; } = -1;
        public bool isConnected { get; set; } = false;
    }
}