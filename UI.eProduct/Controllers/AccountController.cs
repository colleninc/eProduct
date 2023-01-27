using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI.eProduct.APIHelpers;
using UI.eProduct.Data.VM;
using Microsoft.AspNetCore.Http;
using System;

namespace UI.eProduct.Controllers
{
    public class AccountController : Controller
    {
        private APIHelper _aPIHelper;
        public AccountController()
        {
            _aPIHelper = new APIHelper();
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            try
            {
                if (!ModelState.IsValid) return View(loginVM);
                var user = _aPIHelper.Login(loginVM);
                //if (user.Status == TaskStatus.)
                //if (user.Status ==  )
                HttpContext.Session.SetString("UserRole", user.Result.UserRole);
                HttpContext.Session.SetString("DisplayName", user.Result.DisplayName);
                HttpContext.Session.SetString("UserID", user.Result.UserId.ToString());
                HttpContext.Session.SetString("Email", user.Result.Email);
                //HttpContext.Session["AuthUser"] = user;
                return RedirectToAction("Index", "Products");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(loginVM);
            }
            
        }

        public IActionResult Register() => View(new RegisterVM());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View(register);
            try
            {
                var user = await _aPIHelper.RegisterUser(register);
                return RedirectToAction("Index", "Products");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View(register);
            }
            
        }
        public async Task<IActionResult> Logout()
        {

            HttpContext.Session.SetString("UserRole", "");
            return RedirectToAction("Index", "Products");
        }
    }
}
