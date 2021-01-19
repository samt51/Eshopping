using System;
using EShopping_Entity;
using EShoopping_Business;
using EShoopping_Business.Abstrack;
using EShopping.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EShopping.UI.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
      public IViewComponentResult Invoke()
        {
            return View(new CategoryListViewModel() {

                Categories=_categoryService.GetAll()
            });
        }

       
    }
}
