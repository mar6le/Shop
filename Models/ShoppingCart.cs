﻿using Magazine.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Magazine.Models
{
    public class ShoppingCart
    {
        private readonly MagazineContext _context;

        public ShoppingCart(MagazineContext context)
        {
            _context = context;
        }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ListCartItems { get; set; }


        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            var context = services.GetService<MagazineContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };


        }
        public void AddToCart(Product product, int amount)
        {
            var shoppingCartItem =
                _context.ShoppingCartItems.SingleOrDefault(
                    s => s.Product.ProductId == product.ProductId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();



        }
        public int RemoveFromCart(Product product)
        {
            var shoppingCartItem =
                _context.ShoppingCartItems.SingleOrDefault(
                    s => s.Product.ProductId == product.ProductId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);

                }


            }

            _context.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ListCartItems ??
              (ListCartItems =
              _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
              .Include(s => s.Product)
              .ToList());


        }
        public void ClearCart()
        {
            var cartItems = _context
                .ShoppingCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId);

            _context.ShoppingCartItems.RemoveRange(cartItems);
            _context.SaveChanges();




        }
        public decimal GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Product.Price * c.Amount).Sum();
            return total;


        }
    }
}