using Microsoft.AspNetCore.Mvc;
using TaliExpress.Server.Classes.Common;
using TaliExpress.Server.Enums;
using TaliExpress.Server.Managers;
using TaliExpress.Server.Models;

namespace TaliExpress.Server.Controllers
{
    public class CartController : Controller
    {
        [HttpPost]
        public IActionResult AddProductToCart(string cartId, string productId, int amount = 1)
        {
            if (string.IsNullOrEmpty(cartId) || string.IsNullOrEmpty(productId)) return BadRequest(EnumMessagesConverter.Convert(ReturnCode.Parameter_is_null_or_empty)); 
            ProductManager productManager = new ProductManager();
            productManager.Get(productId, out Product? product);
            if (product == null) return BadRequest(EnumMessagesConverter.Convert(ReturnCode.No_product_found));
            CartManager cartManager = new CartManager();
            ReturnCode result = cartManager.AddProduct(cartId, product, amount);
            if (result == ReturnCode.Success) return Ok(EnumMessagesConverter.Convert(ReturnCode.Item_successfully_added_to_the_cart));
            return BadRequest(EnumMessagesConverter.Convert(result));
        }

        [HttpPost]
        public IActionResult RemoveProductFromCart(string cartId, string productId, int amount = 1)
        {
            if (string.IsNullOrEmpty(cartId) || string.IsNullOrEmpty(productId)) return BadRequest(EnumMessagesConverter.Convert(ReturnCode.Parameter_is_null_or_empty));
            ProductManager productManager = new ProductManager();
            productManager.Get(productId, out Product? product);
            if (product == null) return BadRequest(EnumMessagesConverter.Convert(ReturnCode.No_product_found));
            CartManager cartManager = new CartManager();
            ReturnCode result = cartManager.RemoveProduct(cartId, product, amount);
            if (result == ReturnCode.Success) return Ok(EnumMessagesConverter.Convert(ReturnCode.Item_successfully_removed_from_the_cart));
            return BadRequest(EnumMessagesConverter.Convert(result));
        }
    }
}
