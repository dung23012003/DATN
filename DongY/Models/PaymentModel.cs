using System;
using System.ComponentModel.DataAnnotations;

namespace DongY.Models
{
    public class PaymentModel
    {
        [Key]
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime CreatedAt { get; set; }

        public OrderModel Order { get; set; }
    }
}