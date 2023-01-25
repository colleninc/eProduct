using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using UI.eProduct.APIHelpers;
using UI.eProduct.Models;

namespace UI.eProduct.Controllers
{
    public class CategoriesController : Controller
    {
        readonly APIHelper _aPIHelpers;
        public CategoriesController()
        {
            _aPIHelpers = new APIHelper();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _aPIHelpers.GetCategoryList());
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Create([Bind("Description")] ProductCategory category)
        {
            if (!ModelState.IsValid) return View(category);

            await _aPIHelpers.CreateCategory(category);
            return RedirectToAction(nameof(Index));
        }
    }
}
