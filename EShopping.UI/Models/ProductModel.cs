using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EShopping_Entity;

namespace EShopping.UI.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
       /* [Required(ErrorMessage ="Lütfen Ürün İsmi Belirtiniz")]
        [StringLength(60,MinimumLength =5,ErrorMessage ="Lütfen isim belirtiniz")]*/
        public string ProductName { get; set; }
        [Required(ErrorMessage ="Lütfen Ürün Fotoğrafını Ekleyiniz")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage ="Ürün Hakkında Bilgi Veriniz")]
        public string Descriptions { get; set; }
        [Required(ErrorMessage ="Fiyat Belirtiniz")]
        [Range(5,1000000000000)]
        public decimal? Price { get; set; }
        [Required(ErrorMessage ="Lütfen Ürün Stok Adetini Belirtiniz")]
        public int Stock { get; set; }
        
        public decimal? ReducedPrice { get; set; }
      public List<Category> SelectedCategories { get; set; }




    }
}
