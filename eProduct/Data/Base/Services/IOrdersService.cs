
using api.eProduct.Model;
using eProduct.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProduct.Data.Service
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
    }
}
