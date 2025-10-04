using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDBService.Classes;

namespace TaliExpress.Server.Controllers
{
    public class SearchProductsController : Controller
    {
        private readonly string[] CommonLowerWords = new[]
        {
            "the", "is", "in", "at", "of", "on", "and", "a", "to", "it", "for", "with", "as", "by", "that", "this", "an"
        };
        private readonly string[] CommonCapitalWords = new[]
        {
            "The", "Is", "In", "At", "Of", "On", "And", "A", "To", "It", "For", "With", "As", "By", "That", "This", "An"
        };

        public IActionResult SearchByParameters([FromBody] string searchWords)
        {
            string[] words = searchWords.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            List<FilterDefinition<string>> filters = new List<FilterDefinition<string>>();
            foreach (string word in words)
            {
                if (CommonLowerWords.Contains(word) || CommonCapitalWords.Contains(word))
                {
                    continue;
                }
                filters.Add(FilterCreator<string>.CreateRegexFilter(x => x, word, "i"));
            }
        }
    }
}
