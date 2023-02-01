using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.eProduct.APIHelpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using UI.eProduct.Models;
using UI.eProduct.Data.VM;

namespace UI.eProduct.Controllers
{
    public class ProductsController : Controller
    {
        readonly APIHelper _aPIHelpers;
        public ProductsController()
        {
            _aPIHelpers = new APIHelper();
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            TempData["UserRole"] = "-";
            if (!string.IsNullOrWhiteSpace(HttpContext.Session.GetString("UserRole")))
               TempData["UserRole"] = HttpContext.Session.GetString("UserRole");
            return View(await _aPIHelpers.GetProductList());
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var productDetails = await _aPIHelpers.GetByIdAsync(id);
            if (productDetails.Id == Guid.Empty) return View("NotFound");
            return View(productDetails);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await _aPIHelpers.GetCategoryList(true), "Id", "Description");
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewProductVM product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(await _aPIHelpers.GetCategoryList(true), "Id", "Description"); 
                return View(product);
            }
            await _aPIHelpers.AddNewProductAsync(product);
            return RedirectToAction("Index", "Products");
            
        }
    }
}
