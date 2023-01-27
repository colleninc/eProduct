using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.eProduct.APIHelpers;
using UI.eProduct.Data;
using Microsoft.AspNetCore.Http;

namespace UI.eProduct.Controllers
{
    public class OrdersController : Controller
    {
        
       
        readonly APIHelper _aPIHelpers;      
        private readonly ShoppingBasket _shoppingCart;
        public OrdersController(ShoppingBasket shoppingCart)
        {            
            _aPIHelpers = new APIHelper();
            _shoppingCart = shoppingCart;
            
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ShoppingBasket()        {
            
            var response = await _aPIHelpers.GetShoppingCartItems(_shoppingCart.GetShoppingCartId());

            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(Guid id)
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString("UserID")))
                return RedirectToAction("Login", "Account");

            var item = await _aPIHelpers.GetByIdAsync(id);
            if (item.Id != Guid.Empty)
            {
               await _aPIHelpers.AddItemToBasket(item, _shoppingCart.GetShoppingCartId());
            }
            return RedirectToAction("ShoppingBasket", "Orders");
        }

        public async Task<IActionResult> RemoveItemFromBasket(Guid id)
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString("UserID")))
                return RedirectToAction("Login", "Account");
            var item = await _aPIHelpers.GetByIdAsync(id);
            if (item.Id != Guid.Empty)                
            {
              await  _aPIHelpers.RemoveItemFromBasket(item, _shoppingCart.GetShoppingCartId());
            }
            return RedirectToAction("ShoppingBasket", "Orders");
        }
    }
}
