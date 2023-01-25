using api.eProduct.Data.Dto;
using eProduct.Data.Service;
using eProduct.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.eProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategories _service;
        public ProductCategoryController(IProductCategories service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> Create(Category data)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid category details");
            var NewCategory = new ProductCategory()
            {
                Id = Guid.NewGuid(),
                Description = data.Description
            };

            await _service.AddAsync(NewCategory);
            return Ok();
        }

        [HttpGet]
        [Route("GetProductCategories")]
        public async Task<List<ProductCategory>> GetCategory()
        {
            return await _service.GetAllAsync();
        }

        [HttpDelete]
        [Route("RemoveCategory")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
