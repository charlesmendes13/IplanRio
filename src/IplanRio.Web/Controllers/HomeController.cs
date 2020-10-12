using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IplanRio.Web.Models;
using IplanRio.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IplanRio.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShoppingAppService _shoppingAppService;

        public HomeController(IShoppingAppService shoppingAppService)
        {
            _shoppingAppService = shoppingAppService;
        }

        public IActionResult Index()
        {
            ViewData["IdShopping"] = new SelectList(_shoppingAppService.Get(), "Id", "Nome");

            return View();
        }

        [HttpGet]
        public JsonResult GetShopping()
        {
            var shopping = _shoppingAppService.Get().ToList();

            return Json(shopping);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
