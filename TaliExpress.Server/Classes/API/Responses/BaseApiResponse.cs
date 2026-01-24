namespace TaliExpress.Server.Classes.API.Responses
{
    public abstract class BaseApiResponse
    {
        public int Code { get; set; } = 200;
        public string Message { get; set; } = "OK";
    }
}
