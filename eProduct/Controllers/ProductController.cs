﻿using eProduct.Data.Dto;
using eProduct.Data.Service;
using eProduct.Model;
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
        public async Task<IActionResult> Create(ProductDto data)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid product details");
            var NewProduct = new Product()
            {
                ProductCategoryId = data.ProductCategoryID,
                Description = data.Description
            };

            await _service.AddAsync(NewProduct);
            return RedirectToAction(nameof(Index));
        }
    }
}
