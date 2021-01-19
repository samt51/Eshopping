using System;
using System.Collections.Generic;
using System.Linq;

namespace EShopping.UI.Models
{
    public class CartModel
    {
        public int CartId { get; set; }
        public List<KartItemModel> KartItem { get; set; }
        

        public decimal TotalPrice()
        {
           var getir=  KartItem.Sum( i => i.Price * i.Quantity);
            if (getir < 70)
            {
                return getir + 70;
            }
            return getir;
           
     



        }
        public decimal ExtractionPrice()
        {
            return KartItem.Sum(i => i.Price * i.Extraction);
        }
       
    }
    public class KartItemModel
    {
        public int CartItemId { get; set; }
        public int ProductsId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public int Extraction { get; set; }

    }
}
