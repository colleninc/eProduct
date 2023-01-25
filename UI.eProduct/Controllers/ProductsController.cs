using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.eProduct.APIHelpers;

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
            return View(await _aPIHelpers.GetCategoryList());
        }
    }
}
