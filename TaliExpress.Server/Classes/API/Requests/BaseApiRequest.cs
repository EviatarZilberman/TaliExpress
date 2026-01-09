namespace TaliExpress.Server.Classes.API.Requests
{
    public abstract class BaseApiRequest<T> where T : class, new()
    {
        public T Data { get; set; } = new T();
    }
}
