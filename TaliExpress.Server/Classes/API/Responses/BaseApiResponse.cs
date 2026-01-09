namespace TaliExpress.Server.Classes.API.Responses
{
    public abstract class BaseApiResponse<T> where T: class, new()
    {
        public T Data { get; set; } = new T();
    }
}
