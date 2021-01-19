using System;
namespace EShopping_Entity
{
    public class ProductCategory
    {
        public int  CategoryID { get; set; }
        public Category Category { get; set; }
        public int ProductID { get; set; }
        public Products Products { get; set; }
    }
}
