using System;
using System.Collections.Generic;
using EShopping_Entity;

namespace EShopping.UI.Models
{
    public class CategoryModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<Products> Products { get; set; }
    }
}
