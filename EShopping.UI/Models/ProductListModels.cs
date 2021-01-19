using System;
using System.Collections.Generic;
using EShopping_Entity;

namespace EShopping.UI.Models
{ 
    
    public class ProductListModels
    {
        public List<Products>  Products { get; set; }
        public List<Category> Categories { get; set; }
       
        public string SelectedCategory { get; set; }

    }
}
