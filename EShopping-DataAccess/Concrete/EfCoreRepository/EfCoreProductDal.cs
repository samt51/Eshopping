using System;
using System.Collections.Generic;
using System.Linq;
using EShopping_DataAccess.Abstrack;
using EShopping_Entity;
using Microsoft.EntityFrameworkCore;

namespace EShopping_DataAccess.Concrete.EfCoreRepository
{
    public class EfCoreProductDal : EfCoreRepository<Products, ShoppContext>, IProductDal
    {
      

        public Products GetByIdWithCategory(int id)
        {
            using(var db=new ShoppContext())
            {
                return db.products
                    .Where(x=>x.ProductID==id)
                    .Include(x => x.ProductCategories)
                    .ThenInclude(x => x.Category)
                    .FirstOrDefault();
            }
        }

        public int GetCountByCategory(string categoryname)
        {
            using(var db=new ShoppContext())
            {
                var product = db.products.AsQueryable();
                if (!string.IsNullOrEmpty(categoryname))
                {
                    product = product
                        .Include(x => x.ProductCategories)
                        .ThenInclude(x => x.Category)
                        .Where(x => x.ProductCategories.Any(a => a.Category.CategoryName.ToLower()==categoryname.ToLower()));
                }
                return product.Count();
            }
        }


        public Products GetProductDetails(int id)
        {
            using(var db=new ShoppContext())
            {
                return db.products.Where(x => x.ProductID == id)
                    .Include(x => x.ProductCategories)
                    .ThenInclude(x => x.Category)
                    .FirstOrDefault();
            }
        }

        public List<Products> GetProductsByCategory(string categoryname)
        {
            using(var db=new ShoppContext())
            {
                var products = db.products.AsQueryable();
                if (!string.IsNullOrEmpty(categoryname))

                {
                    products = products
                        .Include(x => x.ProductCategories)
                        .ThenInclude(x => x.Category)
                        .Where(x => x.ProductCategories.Any(a => a.Category.CategoryName.ToLower() == categoryname.ToLower()));
                    
                }
                return products.ToList();
            }
        }

        public void Update(Products entity, int[] categoryıds)
        {
            using(var dB=new ShoppContext())
            {
                var product = dB.products.
                    Include(x => x.ProductCategories)
                    .FirstOrDefault(x => x.ProductID == entity.ProductID);
                if (entity != null)
                {
                    product.ProductName = entity.ProductName;
                    product.ImageUrl = entity.ImageUrl;
                    product.Price = entity.Price;
                    product.Stock = entity.Stock;
                    product.ReducedPrice = entity.ReducedPrice;
                    product.ProductCategories = categoryıds.Select(i => new ProductCategory()
                    {

                        CategoryID = i,
                        ProductID = entity.ProductID
                    }).ToList();
                    dB.SaveChanges();
                }
            }
        }


        /* public void Update(Products entity, int[] categoryıds)
         {
             using(var db=new ShoppContext())
             {
                 var product = db.products
                     .Include(x=>x.ProductCategories)
                     .FirstOrDefault(x => x.ProductID == entity.ProductID);

                 if (product! == null)
                 {
                     product.ProductName = entity.ProductName;
                     product.ImageUrl = entity.ImageUrl;
                     product.Price = entity.Price;
                     product.Stock = entity.Stock;
                     product.ReducedPrice = entity.ReducedPrice;

                     product.ProductCategories = categoryıds.Select(i => new ProductCategory()
                     {
                         CategoryID = i,
                         ProductID = entity.ProductID

                     }).ToList();
                     db.SaveChanges();
                 }

             }
         }*/
    }
}
