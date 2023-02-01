

using api.eProduct.Data.Dto;
using api.eProduct.Model;
using eProduct.Data.Base;
using eProduct.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProduct.Data.Service
{
    public class ProductsService : EntityBaseRepository<Product>, IProductsService
    {
        private readonly AppDbContext _context;
        public ProductsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewProduct(Product data)
        {            
            _context.Products.AddAsync(data);
            _context.SaveChangesAsync();
        }

        public async Task ReducetOrderedItemInstock(List<ShoppingCartItem> items)
        {
            foreach (var item in items)
            {                
                Product product = _context.Products.FirstOrDefault(n => n.Id == item.Product.Id);
                product.Quantity -= item.Quantity;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<NewProductLookupVM> GetNewProducLookupVM()
        {
            
            var response = new NewProductLookupVM()
            {
                Categories = await _context.Categories.OrderBy(n => n.Description).ToListAsync()               
            };

            return response;
        }


    }
}
