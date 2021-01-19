using System;
using EShopping_Entity;

namespace EShopping_DataAccess.Abstrack
{
    public interface IKartDal:IRepository<basket>
    {
        basket GetByUserId(string userId);

        void DeleteFromCart(int cartıd, int productId);
    }
}
