using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EShopping.UI.Models;
using EShoopping_Business.Abstrack;
using EShopping_Entity;

namespace EShopping.UI.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public HomeController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        

        public IActionResult Index()
        {
            return View(_productService.GetAll()) ;
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

     
    }
}
