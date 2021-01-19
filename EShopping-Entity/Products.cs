using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShopping_Entity
{
    public class Products
    {
        [Key][ DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public string Descriptions { get; set; }
        public decimal? Price { get; set; }
        public int Stock { get; set; }
        public decimal? ReducedPrice { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }

        
       

    }
    
}
