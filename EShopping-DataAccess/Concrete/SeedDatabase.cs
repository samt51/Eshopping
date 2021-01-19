using System;
using System.Linq;
using EShopping_Entity;
using Microsoft.EntityFrameworkCore;

namespace EShopping_DataAccess.Concrete
{
    public static class SeedDatabase
    {
       public static void Seed()
        {
            var db = new ShoppContext();
            if (db.Database.GetPendingMigrations().Count() == 0)
            {
                if (db.categories.Count() == 0)
                {
                    db.categories.AddRange(Category);
                }
                if (db.products.Count() == 0)
                {
                    db.products.AddRange(Products);
                    db.AddRange(ProductCategories);
                    
                    
                }
                db.SaveChanges();
            }

            

        }
        private static Category[] Category =
        {
            new Category{CategoryName="Kategori1"},
            new Category{CategoryName="Kategori2"},
            new Category{CategoryName="Kategori3"}
        };
        private static Products[] Products =
        {
            new Products{ProductName="Ürün1",ImageUrl="1.jpg",Price=200,Stock=100,Descriptions="Güzel",ReducedPrice=null},
            new Products{ProductName="Ürün2",ImageUrl="1.jpg",Price=200,Stock=100,Descriptions="Güzel",ReducedPrice=null},
            new Products{ProductName="Ürün3",ImageUrl="1.jpg",Price=200,Stock=100,Descriptions="Güzel",ReducedPrice=null},
            new Products{ProductName="Ürün4",ImageUrl="1.jpg",Price=200,Stock=100,Descriptions="Güzel",ReducedPrice=null},
            new Products{ProductName="Ürün5",ImageUrl="1.jpg",Price=200,Stock=100,Descriptions="Güzel",ReducedPrice=null},
            new Products{ProductName="Ürün6",ImageUrl="1.jpg",Price=200,Stock=100,Descriptions="Güzel",ReducedPrice=null},
            new Products{ProductName="Ürün7",ImageUrl="1.jpg",Price=200,Stock=100,Descriptions="Güzel",ReducedPrice=null},
            new Products{ProductName="Ürün8",ImageUrl="1.jpg",Price=200,Stock=100,Descriptions="Güzel",ReducedPrice=null}
        };
        private static ProductCategory[] ProductCategories =
        {
            new ProductCategory{Products=Products[0],Category=Category[0]},
            new ProductCategory{Products=Products[0],Category=Category[1]},
            new ProductCategory{Products=Products[1],Category=Category[1]},
            new ProductCategory{Products=Products[1],Category=Category[2]},
            new ProductCategory{Products=Products[2],Category=Category[3]},
            new ProductCategory{Products=Products[2],Category=Category[3]}

        };

    }
}
