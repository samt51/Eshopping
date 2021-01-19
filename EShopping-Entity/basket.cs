using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EShopping_Entity
{
    public class basket
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }

        public List<BasketItem> basketItems { get; set; }
    }
}
