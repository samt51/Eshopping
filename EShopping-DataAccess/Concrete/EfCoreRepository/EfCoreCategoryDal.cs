using System;
using System.Linq;
using EShopping_DataAccess.Abstrack;
using EShopping_Entity;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace EShopping_DataAccess.Concrete.EfCoreRepository
{
    public class EfCoreCategoryDal : EfCoreRepository<Category, ShoppContext>, ICategoryDal
    {
      

        public void DeleteFromCategory(int categoryid, int productid)
        {
          using(var db=new ShoppContext())
            {
                var cmd = @"Delete from ProductCategory where ProductId=@p0 And CategoryId=@p1";
                  db.Database.ExecuteSqlRaw(cmd, productid, categoryid);
            }
        }

        public Category GetByWithCategory(int id)
        {
           using(var db = new ShoppContext())
            {
                return db.categories
                       .Where(x => x.CategoryID == id)
                       .Include(x => x.ProductCategories)
                       .ThenInclude(x => x.Products)
                       .FirstOrDefault();
            }
        }
    }
}
