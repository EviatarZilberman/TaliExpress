using TaliExpress.Server.Classes.AngularObjects;
using TaliExpress.Server.Classes.API.Responses;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Managers;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Workers
{
    public class SearchWorker : ISearch
    {
        public async Task<SearchResponse> SearchProducts(string name)
        {
            ProductsManager productsManager = new ProductsManager();
            productsManager.GetAllByFilter("Name", name, out List<ProductDbModel> products);
            List<ProductAng> result = new List<ProductAng>();
            foreach (ProductDbModel product in products)
            {
                ProductAng productAng = new ProductAng();
                productAng.Adapt(product);
                result.Add(productAng);
            }

            return new SearchResponse()
            {
                Code = 0,
                Products = result
            };
        }
    }
}
