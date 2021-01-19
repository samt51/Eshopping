using System;
using System.Linq;
using EShopping_DataAccess.Abstrack;
using EShopping_Entity;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace EShopping_DataAccess.Concrete.EfCoreRepository
{
    public class EfCoreKartDal : EfCoreRepository<basket, ShoppContext>, IKartDal
    {
        public override void Update(basket entity)
        {
            using(var db=new ShoppContext())
            {
                db.baskets.Update(entity);
                db.SaveChanges();
            }
        }
        public basket GetByUserId(string userId)
        {
           using(var db=new ShoppContext())
            {
                return db.baskets.Include(x => x.basketItems)
                    .ThenInclude(x => x.Products)
                    .FirstOrDefault(x => x.UserId == userId);
            }
        }

        public void DeleteFromCart(int cartıd, int productId)
        {
            using(var db=new ShoppContext())
            {
                var cmd = @"delete from BasketItem where basketId=@p0 And ProductsId=@p1";
                db.Database.ExecuteSqlRaw(cmd, cartıd, productId);
            }
        }
    }
}
