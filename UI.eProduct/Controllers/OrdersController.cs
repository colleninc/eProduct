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

        public async Task<IActionResult> CompleteOrder()
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString("UserID")))
                return RedirectToAction("Login", "Account");

            var CartItems = await _aPIHelpers.GetShoppingCartItems(_shoppingCart.GetShoppingCartId());
            var _UserId = HttpContext.Session.GetString("UserID");
            var _Email = HttpContext.Session.GetString("Email");
            var _DisplayName = HttpContext.Session.GetString("DisplayName");
            var res = await _aPIHelpers.CompleteOrder(
                new Data.VM.OrderVM 
                {  
                  CartId = _shoppingCart.GetShoppingCartId(),
                  UserId = _UserId,
                  Email = _Email
                });
            if (res != null)
            {
                _aPIHelpers.SendOrderComfirmation(CartItems, _Email, _DisplayName);
                return View("OrderCompleted");
            }
            else
            {
                TempData["Error"] = res;
                return RedirectToAction("ShoppingBasket", "Orders");
            }
        }
    }
}
