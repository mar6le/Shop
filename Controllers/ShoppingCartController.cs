using Magazine.Data;
using Magazine.Models;
using Magazine.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Magazine.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly MagazineContext _context;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(MagazineContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart=shoppingCart;
        }
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ListCartItems = items;

            var sCVM = new ShoppingCartViewModel
            {
                shoppingCart= _shoppingCart,


            };
            return View(sCVM);
        }

        public RedirectToActionResult AddToShoppingCart(int productId)
        {
            var selectedProduct=_context.Products.FirstOrDefault(x => x.ProductId == productId);
            if(selectedProduct != null)
            {
                _shoppingCart.AddToCart(selectedProduct, 1);
            }
            return RedirectToAction("Index");

        }

        public RedirectToActionResult RemoveFromShoppingCart(int productId)
        {
            var selectedProduct = _context.Products.FirstOrDefault(x => x.ProductId == productId);
            if (selectedProduct != null)
            {
                _shoppingCart.RemoveFromCart(selectedProduct);
            }
            return RedirectToAction("Index");

        }

    }
}
