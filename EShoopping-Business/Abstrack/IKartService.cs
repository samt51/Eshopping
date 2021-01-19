using System;
using EShopping_Entity;

namespace EShoopping_Business.Abstrack
{
    public interface IKartService
    {
        void initiliazCart(string userId);
        basket GetCartbyUserId(string userId);
        void AddToCart(string userıd, int productId, int quantity);
        void DeleteFromCart(string userId, int productsId);
    }
}
