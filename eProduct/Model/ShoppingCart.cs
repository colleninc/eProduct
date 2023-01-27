using eProduct.Data;
using eProduct.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.eProduct.Model
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        //public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            //ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            //string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            //session.SetString("CartId", cartId);

            return new ShoppingCart(context);// { ShoppingCartId = cartId };
        }

        public void AddItemToCart(Product product, string CartId)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Product.Id == product.Id && n.ShoppingCartId == CartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    Id = Guid.NewGuid(),
                    ShoppingCartId = CartId,
                    Product = product,
                    Quantity = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Quantity++;
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Product product, string CartId)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Product.Id == product.Id && n.ShoppingCartId == CartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _context.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems(string CartId)
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == CartId).Include(n => n.Product).ToList());
        }

        public double GetShoppingCartTotal(string CartId) => _context.ShoppingCartItems.Where(n => n.ShoppingCartId == CartId).Select(n => n.Product.Price * n.Quantity).Sum();

        public async Task ClearShoppingCartAsync(string CartId)
        {
            var items = await _context.ShoppingCartItems.Where(n => n.ShoppingCartId == CartId).ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}
