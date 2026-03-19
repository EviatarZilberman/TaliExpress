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
            productManager.GetById(productManager.GetCollectionName(), productId, out ProductDbModel? product);
            if (product == null) return BadRequest(EnumMessagesConverter.Convert(ReturnCode.No_product_found));
            CartManager cartManager = new CartManager();
            if (cartManager.AddProduct(cartId, product, amount)) return Ok(EnumMessagesConverter.Convert(ReturnCode.Item_successfully_added_to_the_cart));
            return BadRequest(ReturnCode.Item_failed_to_be_added_to_the_cart);
        }

        [HttpPost]
        public IActionResult RemoveProductFromCart(string cartId, string productId, int amount = 1)
        {
            if (string.IsNullOrEmpty(cartId) || string.IsNullOrEmpty(productId)) return BadRequest(EnumMessagesConverter.Convert(ReturnCode.Parameter_is_null_or_empty));
            ProductManager productManager = new ProductManager();
            productManager.GetById<ProductDbModel>(productManager.GetCollectionName(), productId, out ProductDbModel? product);
            if (product == null) return BadRequest(EnumMessagesConverter.Convert(ReturnCode.No_product_found));
            CartManager cartManager = new CartManager();
            if (cartManager.RemoveProduct(cartId, product, amount)) return Ok(EnumMessagesConverter.Convert(ReturnCode.Item_successfully_removed_from_the_cart));
            return BadRequest(ReturnCode.Item_successfully_removed_from_the_cart);
        }
    }
}
