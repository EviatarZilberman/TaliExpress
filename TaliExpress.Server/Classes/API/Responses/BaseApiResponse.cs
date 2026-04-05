namespace TaliExpress.Server.Classes.API.Responses
{
    public class BaseApiResponse
    {
        public int Code { get; set; } = 0;
        public string Message { get; set; } = "OK";
    }
}
