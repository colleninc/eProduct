using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.eProduct.Models;

namespace UI.eProduct.Data
{
    public class ShoppingBasket
    {
        public string ShoppingCartId { get; set; }
        public List<ShoppingBasketItems> Shoppingtems { get; set; }
        public static ShoppingBasket GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingBasket() { ShoppingCartId = cartId };
            
        }

        public string GetShoppingCartId() { return ShoppingCartId; }


        /* public void AddItemToCart(Product product)
         {
             var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

             if (HttpContext.Session.GetString(ShoppingCartId) == null)
             {

             }
             if (shoppingCartItem == null)
             {
                 shoppingCartItem = new ShoppingCartItem()
                 {
                     ShoppingCartId = ShoppingCartId,
                     Movie = product,
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

         public void RemoveItemFromCart(Product product)
         {
             var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

             if (shoppingCartItem != null)
             {
                 if (shoppingCartItem.Amount > 1)
                 {
                     shoppingCartItem.Amount--;
                 }
                 else
                 {
                     _context.ShoppingCartItems.Remove(shoppingCartItem);
                 }
             }
             _context.SaveChanges();
         }

         public List<ShoppingCartItem> GetShoppingCartItems()
         {
             return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Movie).ToList());
         }

         public double GetShoppingCartTotal() => _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Movie.Price * n.Amount).Sum();

         public async Task ClearShoppingCartAsync()
         {
             var items = await _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
             _context.ShoppingCartItems.RemoveRange(items);
             await _context.SaveChangesAsync();
         }

        */
    }
}
