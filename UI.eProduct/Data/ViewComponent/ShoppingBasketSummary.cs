using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.eProduct.APIHelpers;

namespace UI.eProduct.Data.ViewComponent
{
    public class ShoppingBasketSummary : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly APIHelper _apiHelper;
        private readonly Data.ShoppingBasket _shoppingCart;
        public ShoppingBasketSummary(Data.ShoppingBasket shoppingCart)
        {
            _apiHelper = new APIHelper();
            _shoppingCart = shoppingCart;
        }      

        

        public IViewComponentResult Invoke()
        {

            var CartID = _shoppingCart.GetShoppingCartId();
            var items = _apiHelper.GetShoppingCartItems(CartID);

            return View(items.Result.Count);
        }
    }
}
