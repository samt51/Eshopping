using System;
using System.ComponentModel.DataAnnotations;

namespace EShopping_Entity
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }

        public Order order { get; set; }

        public int ProductId { get; set; }

        public Products  Products { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
