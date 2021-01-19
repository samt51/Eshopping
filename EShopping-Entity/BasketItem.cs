using System;
using System.ComponentModel.DataAnnotations;

namespace EShopping_Entity
{
    public class BasketItem
    {
        [Key]
        public int Id { get; set; }
        public Products Products { get; set; }
        public int ProductsId { get; set; }

        public basket basket { get; set; }
        public int  basketId { get; set; }

        public int Quantity { get; set; }

    }
}
