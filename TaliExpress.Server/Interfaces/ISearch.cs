using TaliExpress.Server.Classes.API.Responses;

namespace TaliExpress.Server.Interfaces
{
    public interface ISearch
    {
        public Task<SearchResponse> SearchProducts(string name);
    }
}