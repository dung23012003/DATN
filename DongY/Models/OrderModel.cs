using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DongY.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int StatusId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CreatedAt { get; set; }

        public CustomerModel Customer { get; set; }
        public StatusModel Status { get; set; }
        public PaymentModel Payment { get; set; }
        public ICollection<OrderDetailModel> OrderDetails { get; set; }
    }
}