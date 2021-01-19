using System;
using System.Linq;
using EShoopping_Business.Abstrack;
using EShopping.UI.Identity;
using EShopping.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EShopping.UI.Controllers
{
    [Authorize]
    public class KartController:Controller
    {
        
        private IKartService _kartservice;
        private UserManager<ApplicationUser> _usermanager;
        public KartController(IKartService kartservice, UserManager<ApplicationUser> usermanager)
        {
            _kartservice = kartservice;
            _usermanager = usermanager;
        }


       
      public IActionResult Index()
        {
          
            var cart = _kartservice.GetCartbyUserId(_usermanager.GetUserId(User));
            return View(new CartModel()
            {

                CartId = cart.Id,
                KartItem = cart.basketItems.Select(i => new KartItemModel() {

                    CartItemId = i.Id,
                    ProductsId = i.ProductsId,
                    Name = i.Products.ProductName,
                    Price = (decimal)i.Products.Price,
                    ImageUrl = i.Products.ImageUrl,
                    Quantity = i.Quantity,
                   
                    
                    
                }).ToList()


              
        }); ;
          

        }


        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            _kartservice.AddToCart(_usermanager.GetUserId(User), productId, quantity);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteFromCart(int productsId)
        {
            _kartservice.DeleteFromCart(_usermanager.GetUserId(User), productsId);
            return RedirectToAction("Index");
        }
        public IActionResult Checkout()
        {
            var cart = _kartservice.GetCartbyUserId(_usermanager.GetUserId(User));

            var model = new OrderModel();
            model.CartModel = new CartModel()
            {

                CartId = cart.Id,
                KartItem = cart.basketItems.Select(i => new KartItemModel()
                {

                    CartItemId = i.Id,
                    ProductsId = i.ProductsId,
                    Name = i.Products.ProductName,
                    Price = (decimal)i.Products.Price,
                    ImageUrl = i.Products.ImageUrl,
                    Quantity = i.Quantity,



                }).ToList()
            };
            return View(model);  

            
        }
    }
}
