using eProduct.Data.Dto;
using eProduct.Data.Service;
using eProduct.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductsService _service;
        public ProductController(IProductsService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("AddProduct")]
        //[Authorize]
        public async Task<IActionResult> Create(ProductDto data)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid product details");
            var NewProduct = new Product()
            {
                Id = Guid.NewGuid(),
                ProductCategoryId = data.ProductCategoryID,
                Description = data.Description,
                ProductName = data.ProductName,
                Price = data.Price,
                Quantity = data.Quantity,
                Re_OrderLevel = data.Re_OrderLevel,
                ImageURL = data.ImageURL
            };

            await _service.AddAsync(NewProduct);
            return Ok();
        }

        [HttpPost]
        [Route("UpdateProduct")]
        //[Authorize]
        public async Task<IActionResult> Edit(Guid id, ProductDto data)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid input data");

            var updateProduct = new Product()
            {
                ProductCategoryId = data.ProductCategoryID,
                Description = data.Description,
                ProductName = data.ProductName,
                Price = data.Price,
                Quantity = data.Quantity,
                Re_OrderLevel = data.Re_OrderLevel,
                ImageURL = data.ImageURL
            };
            await _service.UpdateAsync(id, updateProduct);                
            
            return Ok();
        }

        [HttpGet]
        [Route("GetList")]        
        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            return await _service.GetAllAsync(n => n.ProductCategory);
        }

        [HttpGet]
        [Route("Details")]
        public async Task<Product> GetProductDetails(Guid id)
        {
            return await _service.GetByIdAsync(id, n => n.ProductCategory);
        }
    }
}
