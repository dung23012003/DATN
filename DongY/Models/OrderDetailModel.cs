using System;
using System.ComponentModel.DataAnnotations;

namespace DongY.Models
{
    public class OrderDetailModel
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }

        public OrderModel Order { get; set; }
        public ProductModel Product { get; set; }
    }
}