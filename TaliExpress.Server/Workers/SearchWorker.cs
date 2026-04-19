using TaliExpress.Server.Classes.AngularObjects;
using TaliExpress.Server.Classes.API.Responses;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Managers;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Workers
{
    public class SearchWorker : ISearch
    {
        private readonly string CategoryAttribute = "Category";
        private readonly string NameAttribute = "Name";
        private readonly string[] CommonLowerWords = new[]
        {
            "the", "is", "in", "at", "of", "on", "and", "a", "to", "it", "for", "with", "as", "by", "that", "this", "an", "what", "where", "when", "which", "who", "whom", "why", "how"
        };
        private readonly string[] CommonCapitalWords = new[]
        {
            "The", "Is", "In", "At", "Of", "On", "And", "A", "To", "It", "For", "With", "As", "By", "That", "This", "An", "What", "Where", "when", "Which", "Who", "Whom", "Why", "How"
        };

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
