using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.eProduct.APIHelpers;
using Microsoft.AspNetCore.Http;

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

        
    }
}
