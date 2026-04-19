using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBService.Classes;
using TaliExpress.Server.Classes.AngularObjects;
using TaliExpress.Server.Classes.API.Requests;
using TaliExpress.Server.Classes.API.Responses;
using TaliExpress.Server.Interfaces;
using TaliExpress.Server.Managers;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchProductsController : Controller
    {
        private readonly ISearch SearchWorker;
        public SearchProductsController(ISearch searchWorker)
        {
            this.SearchWorker = searchWorker;
        }

        [HttpGet("searchProducts")]
        public async Task<SearchResponse> SearchProducts([FromQuery] string name)
        {
            return await this.SearchWorker.SearchProducts(name);
        }

        ///*  [HttpGet]
        //  [Route("searchProductByParameters")]*/
        //[HttpGet("searchProductByParameters")]
        //public IActionResult SearchByParameters([FromQuery] string searchWords/*, List<string> categories = null, string listOrder = null*/)
        ////public IActionResult SearchByParameters([FromBody] string searchWords/*, List<string> categories = null, string listOrder = null*/)
        //{
        //    string[] words = searchWords.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        //    List<FilterDefinition<ProductDbModel>> filters = new List<FilterDefinition<ProductDbModel>>();
        //    //if (categories != null && categories.Count > 0)
        //    //{
        //    //    foreach (string category in categories)
        //    //    {
        //    //        filters.Add(FilterCreator<Product>.CreateEqualFilter(CategoryAttribute, category));
        //    //    }
        //    //}
        //    foreach (string word in words)
        //    {
        //        if (CommonLowerWords.Contains(word) || CommonCapitalWords.Contains(word))
        //        {
        //            continue;
        //        }
        //        filters.Add(FilterCreator<ProductDbModel>.CreateEqualFilter(NameAttribute, word));
        //    }
        //    FilterDefinition<ProductDbModel> finalFilter = FilterCreator<ProductDbModel>.CreateMultiOrConditionsFilter(filters.ToArray());
        //    ProductsManager productManager = new ProductsManager();
        //    if (productManager.GetFiltered(finalFilter, out List<ProductDbModel>? products) != Enums.ReturnCode.Success)
        //    {
        //        return StatusCode(500, "An error occurred while searching for products.");
        //    }

        //    return Ok(products);
        //    //return Ok(ListOrder(listOrder, products));
        //}

        //private List<ProductDbModel>? ListOrder(string listOrder, List<ProductDbModel>? products)
        //{
        //    if (!string.IsNullOrEmpty(listOrder))
        //    {
        //        if (products != null || products?.Count != 0)
        //        {
        //            if (listOrder == "PriceAsc")
        //            {
        //                products = products?.OrderBy(p => p.Price).ToList();
        //            }
        //            else if (listOrder == "PriceDesc")
        //            {
        //                products = products?.OrderByDescending(p => p.Price).ToList();
        //            }
        //            else if (listOrder == "NameAsc")
        //            {
        //                products = products?.OrderBy(p => p.Name).ToList();
        //            }
        //            else if (listOrder == "NameDesc")
        //            {
        //                products = products?.OrderByDescending(p => p.Name).ToList();
        //            }
        //        }
        //    }
        //    return products;
        //}
    }
}