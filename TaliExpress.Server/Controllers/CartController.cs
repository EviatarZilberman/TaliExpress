using Microsoft.AspNetCore.Mvc;
using TaliExpress.Server.Classes.API.Requests;
using TaliExpress.Server.Classes.API.Responses;
using TaliExpress.Server.Interfaces;
namespace TaliExpress.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : Controller
    {
        private readonly ICart CartWorker;

        public CartController(ICart cartWorker)
        {
            this.CartWorker = cartWorker;
        }

        [HttpPost("addToCart")]
        public async Task<BaseApiResponse> AddToCart([FromBody] AddToCartRequest request)
        {
            return await this.CartWorker.AddToCart(request, this.HttpContext);
        }
        //[HttpPost]
        //public IActionResult AddProductToCart(string cartId, string ProductId, int amount = 1)
        //{
        //    if (string.IsNullOrEmpty(cartId) || string.IsNullOrEmpty(ProductId)) return BadRequest(EnumMessagesConverter.Convert(ReturnCode.Parameter_is_null_or_empty)); 
        //    ProductsManager productManager = new ProductsManager();
        //    productManager.GetById(productManager.GetCollectionName(), ProductId, out ProductDbModel? product);
        //    if (product == null) return BadRequest(EnumMessagesConverter.Convert(ReturnCode.No_product_found));
        //    CartManager cartManager = new CartManager();
        //    if (cartManager.AddProduct(cartId, product, amount)) return Ok(EnumMessagesConverter.Convert(ReturnCode.Item_successfully_added_to_the_cart));
        //    return BadRequest(ReturnCode.Item_failed_to_be_added_to_the_cart);
        //}

        //[HttpPost]
        //public IActionResult RemoveProductFromCart(string cartId, string ProductId, int amount = 1)
        //{
        //    if (string.IsNullOrEmpty(cartId) || string.IsNullOrEmpty(ProductId)) return BadRequest(EnumMessagesConverter.Convert(ReturnCode.Parameter_is_null_or_empty));
        //    ProductsManager productManager = new ProductsManager();
        //    productManager.GetById<ProductDbModel>(productManager.GetCollectionName(), ProductId, out ProductDbModel? product);
        //    if (product == null) return BadRequest(EnumMessagesConverter.Convert(ReturnCode.No_product_found));
        //    CartManager cartManager = new CartManager();
        //    if (cartManager.RemoveProduct(cartId, product, amount)) return Ok(EnumMessagesConverter.Convert(ReturnCode.Item_successfully_removed_from_the_cart));
        //    return BadRequest(ReturnCode.Item_successfully_removed_from_the_cart);
        //}
    }
}
