using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBService.Classes;
using TaliExpress.Server.Managers;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchProductsController : Controller
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

        /*  [HttpGet]
          [Route("searchProductByParameters")]*/
        [HttpGet("searchProductByParameters")]
        public IActionResult SearchByParameters([FromQuery] string searchWords/*, List<string> categories = null, string listOrder = null*/)
        //public IActionResult SearchByParameters([FromBody] string searchWords/*, List<string> categories = null, string listOrder = null*/)
        {
            string[] words = searchWords.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            List<FilterDefinition<ProductDbModel>> filters = new List<FilterDefinition<ProductDbModel>>();
            //if (categories != null && categories.Count > 0)
            //{
            //    foreach (string category in categories)
            //    {
            //        filters.Add(FilterCreator<Product>.CreateEqualFilter(CategoryAttribute, category));
            //    }
            //}
            foreach (string word in words)
            {
                if (CommonLowerWords.Contains(word) || CommonCapitalWords.Contains(word))
                {
                    continue;
                }
                filters.Add(FilterCreator<ProductDbModel>.CreateEqualFilter(NameAttribute, word));
            }
            FilterDefinition<ProductDbModel> finalFilter = FilterCreator<ProductDbModel>.CreateMultiOrConditionsFilter(filters.ToArray());
            ProductsManager productManager = new ProductsManager();
            if (productManager.GetFiltered(finalFilter, out List<ProductDbModel>? products) != Enums.ReturnCode.Success)
            {
                return StatusCode(500, "An error occurred while searching for products.");
            }

            return Ok(products);
            //return Ok(ListOrder(listOrder, products));
        }

        private List<ProductDbModel>? ListOrder(string listOrder, List<ProductDbModel>? products)
        {
            if (!string.IsNullOrEmpty(listOrder))
            {
                if (products != null || products?.Count != 0)
                {
                    if (listOrder == "PriceAsc")
                    {
                        products = products?.OrderBy(p => p.Price).ToList();
                    }
                    else if (listOrder == "PriceDesc")
                    {
                        products = products?.OrderByDescending(p => p.Price).ToList();
                    }
                    else if (listOrder == "NameAsc")
                    {
                        products = products?.OrderBy(p => p.Name).ToList();
                    }
                    else if (listOrder == "NameDesc")
                    {
                        products = products?.OrderByDescending(p => p.Name).ToList();
                    }
                }
            }
            return products;
        }
    }
}