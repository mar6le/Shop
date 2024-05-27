using Magazine.Data;
using Magazine.Models;
using Microsoft.AspNetCore.Mvc;

namespace Magazine.Controllers
{
    public class OrderController : Controller
    {

        private readonly MagazineContext _context;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(MagazineContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {


            _shoppingCart.ListCartItems = _shoppingCart.GetShoppingCartItems();
            if(_shoppingCart.ListCartItems.Count == 0)
            {

                ModelState.AddModelError("", "You need to have at least one product");
            }
            if (ModelState.IsValid)
            {
                return RedirectToAction("Complete");
            }
            return View(order);
        }
        public IActionResult Complete()
        {


            ViewBag.Message = "Order succesfully done";
            return View();
        }
    }
}

