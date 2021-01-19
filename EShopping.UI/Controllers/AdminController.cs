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
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace EShopping.UI.Controllers
{
    [Authorize]
    public class AdminController:Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }
        public IActionResult List()
        {
            return View(new ProductListModels()
            {

                Products=_productService.GetAll()
            });
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductModel products)
        {
            if(ModelState.IsValid)
            {

                var entity = new Products()
                {
                    ProductName = products.ProductName,
                    ImageUrl = products.ImageUrl,
                    Price = products.Price,
                    Stock = products.Stock,
                    ReducedPrice = products.ReducedPrice,

                };
               
                 if (_productService.Create(entity))
                {
                    return RedirectToAction("List");
                }
                ViewBag.ErrorMessage = _productService.ErrorMessage;

                return View(products);


            }
            return View(products);
           
           
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _productService.GetByIdWithCategory((int)id);
            if (entity == null)
            {
                return NotFound();
            }
            var model = new ProductModel()
            {
                ProductID = entity.ProductID,
                ProductName = entity.ProductName,
                ImageUrl = entity.ImageUrl,
                Price = entity.Price,
                Stock = entity.Stock,
                ReducedPrice = entity.ReducedPrice,
                SelectedCategories = entity.ProductCategories.Select(x => x.Category).ToList()
            };
            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }
        [HttpPost]
        public async Task< IActionResult> Update(ProductModel model,int[] categoryıds,IFormFile formFile)
        {
           
            {
                var entity = _productService.GetById(model.ProductID);
                if (entity == null)
                {
                    return NotFound();
                }
                entity.ProductName = model.ProductName;
               
                entity.Price = model.Price;
                entity.Stock = model.Stock;
                entity.ReducedPrice = model.ReducedPrice;
                if (formFile != null)
                {
                    entity.ImageUrl = model.ImageUrl;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", formFile.FileName);
                    using(var stream=new FileStream(path, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
                _productService.Update(entity, categoryıds);
                return RedirectToAction("List");
            }
           

            
        }
         [HttpPost]
        public IActionResult Delete(int ProductID)
        {
            var entity = _productService.GetById(ProductID);
            if (entity != null)
            {
                _productService.Delete(entity);
            }
            return RedirectToAction("List");
        }
        public IActionResult CategoryList()
        {
            return View(new CategoryListViewModel() {

                Categories=_categoryService.GetAll()

            });
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CategoryAdd(CategoryModel model)
        {
            var entity = new Category()
            {
                CategoryName = model.CategoryName
            };
            _categoryService.Create(entity);

            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public IActionResult CategoryEdit(int id)
        {
           
            var entity = _categoryService.GetByWithCategory(id);
            if (entity == null)
            {
                return NotFound();
            }
            var model = new CategoryModel()
            {
                CategoryID = entity.CategoryID,
                CategoryName = entity.CategoryName,
                Products = entity.ProductCategories.Select(x => x.Products).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult CategoryEdit(CategoryModel model)
        {
            var entity = _categoryService.GetById(model.CategoryID);
            if (entity == null)
            {
                return NotFound();
            }
            entity.CategoryName = model.CategoryName;
            _categoryService.Update(entity);
            return RedirectToAction("CategoryList");
        }
        [HttpPost]
        public IActionResult CategoryDelete(int id)
        {
            var entity = _categoryService.GetById(id);
            if (entity != null)
            {
                _categoryService.Delete(entity);
            }
            return RedirectToAction("CategoryList");
        }
        [HttpPost]
        public IActionResult deletefromcategory(int categoryıd,int productıd)
        {
            _categoryService.DeleteFromCategory(categoryıd, productıd);
            return Redirect("/admin/categoryedit/" + categoryıd);
        }
        

    }
}
