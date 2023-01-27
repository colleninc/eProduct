using api.eProduct.Data.Dto;
using api.eProduct.Model;
using eProduct.Data;
using eProduct.Data.Service;
using eProduct.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace api.eProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IProductsService _productsService;

        public OrdersController(IProductsService productsService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _productsService = productsService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

        [HttpGet]
        [Route("GetShoppingCartItems")]
        public async Task<ShoppingCartVM> GetShoppingCartItems(string CartId)
        {
            return await ReturnWhatsIntheBasket(CartId);
        }

        private async Task<ShoppingCartVM> ReturnWhatsIntheBasket(string CartId)
        {
            var items =  _shoppingCart.GetShoppingCartItems(CartId);
            _shoppingCart.ShoppingCartItems = items;

            var basket = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(CartId)
            };

            return basket;
        }

        [HttpPost]
        [Route("AddItemToShoppingCart")]
        public async Task<ShoppingCartVM> AddItemToShoppingCart(Guid id, string CartId)
        {
            var item = await _productsService.GetByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item, CartId);
            }
            return await ReturnWhatsIntheBasket(CartId);
        }

        [HttpDelete]
        [Route("RemoveItemFromShoppingCart")]
        public async Task<ShoppingCartVM> RemoveItemFromShoppingCart(Guid id, string CartId)
        {
            var item = await _productsService.GetByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item, CartId);
            }
            return await ReturnWhatsIntheBasket(CartId);
        }

        [HttpDelete]
        [Route("CompleteOrder")]
        public async Task<IActionResult> CompleteOrder(string CartId)
        {
            var items = _shoppingCart.GetShoppingCartItems(CartId);
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync(CartId);

            return Ok("OrderCompleted");
        }

        [HttpGet]
        [Route("GetOrders")]
        public async Task<List<Order>> GetOrders(string userId, string userRole)
        {
            
            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return orders;
        }
    }

    
}
