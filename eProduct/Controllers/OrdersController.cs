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
        public async Task<List<ShoppingCartItem>> ReturnWhatsIntheBasket(string CartId)
        {
            try
            {
                var items = _shoppingCart.GetShoppingCartItems(CartId);
                
                //_shoppingCart.ShoppingCartItems = items;

               /* var basket = new ShoppingCartVM()
                {
                    ShoppingCart = null, //_shoppingCart,
                    ShoppingCartTotal = 0// _shoppingCart.GetShoppingCartTotal(CartId)
                };
               */
                return items;
            }
            catch 
            {
                return null; 
            }
        }
        

        [HttpPost]
        [Route("AddItemToShoppingCart")]
        public async Task<IActionResult> AddItemToShoppingCart(Guid id, string CartId)
        {
            try 
            { 
            var item = await _productsService.GetByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item, CartId);
            }
            return Ok("Item added");
        }
            catch(Exception ex)
            {
                return BadRequest($"Error adding item - {ex.Message}");
    }
}

        [HttpDelete]
        [Route("RemoveItemFromShoppingCart")]
        public async Task<IActionResult> RemoveItemFromShoppingCart(Guid id, string CartId)
        {
            try
            {
                var item = await _productsService.GetByIdAsync(id);

                if (item != null)
                {
                    _shoppingCart.RemoveItemFromCart(item, CartId);
                }
                return Ok("Item removed"); ;
            }
            catch(Exception ex)
            {
                return BadRequest($"Error removing item - {ex.Message}");
            }
            
        }

        [HttpPost]
        [Route("CompleteOrder")]
        public async Task<IActionResult> CompleteOrder(string CartId, string userId, string userEmail)
        {
            try
            {
                var items = _shoppingCart.GetShoppingCartItems(CartId);
                
                await _ordersService.StoreOrderAsync(items, userId, userEmail);
                await _shoppingCart.ClearShoppingCartAsync(CartId);

                return Ok("OrderCompleted");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error removing item - {ex.Message}");
            }

            
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
