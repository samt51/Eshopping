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
using PagedList.Core.Mvc;
using PagedList.Core;

namespace EShopping.UI.Controllers
{
    public class ProductController:Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Products products = _productService.GetProductDetails((int)id);
            if (products == null)
            {
                return NotFound();
            }
            return View(new ProductDetailsModel()
            {

                Products = products,
                Categories = products.ProductCategories.Select(x => x.Category).ToList()
            }) ;
        }


        public IActionResult List(string category)
        {
           
            
      
            return View(new ProductListModels()
            {
                 

                Products = _productService.GetProductByCategory(category),
                Categories = _categoryService.GetAll(),
                
                

            }); 
        }
       
    }
}
