

using api.eProduct.Data.Dto;
using api.eProduct.Model;
using eProduct.Data.Base;
using eProduct.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eProduct.Data.Service
{
    public interface IProductsService : IEntityBaseRepository<Product>
    {
        public Task ReducetOrderedItemInstock(List<ShoppingCartItem> items);
    }
}
