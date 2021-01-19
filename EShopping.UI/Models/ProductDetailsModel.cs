using System;
using System.Collections.Generic;
using EShopping_Entity;

namespace EShopping.UI.Models
{
    public class ProductDetailsModel
    {
        public Products Products { get; set; }
        public List<Category> Categories  { get; set; }
    }
}
