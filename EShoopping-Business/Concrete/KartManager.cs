
using System;
using EShoopping_Business.Abstrack;
using EShopping_DataAccess.Abstrack;
using EShopping_Entity;

namespace EShoopping_Business.Concrete
{
    public class KartManager : IKartService
    {
        public IKartDal _kartDal;
        public KartManager(IKartDal kartDal)
        {
            _kartDal = kartDal;
        }

        public void AddToCart(string userıd, int productId, int quantity)
        {
            var cart = _kartDal.GetByUserId(userıd);
            if (cart != null)
            {
                var ındex = cart.basketItems.FindIndex(i => i.ProductsId == productId);

                if (ındex < 0)
                {
                    cart.basketItems.Add(new BasketItem()
                    {
                        ProductsId = productId,
                        Quantity = quantity,
                        basketId = cart.Id,

                    });
                   
                }
                else
                {
                    cart.basketItems[ındex].Quantity += quantity;
                }
                _kartDal.Update(cart);  
            }
        }

        public void DeleteFromCart(string userId, int productsId)
        {
            var cart = _kartDal.GetByUserId(userId);
            if (cart != null)
            {
                _kartDal.DeleteFromCart(cart.Id, productsId);
            }
        }

        public basket GetCartbyUserId(string userId)
        {
            return _kartDal.GetByUserId(userId);
        }

        public void initiliazCart(string userId)
        {
            _kartDal.Create(new basket() { UserId = userId }); 
        }
    }
}
