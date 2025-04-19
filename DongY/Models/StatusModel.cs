using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DongY.Models
{
    public class StatusModel
    {
        [Key]
        public int StatusId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<OrderModel> Orders { get; set; }
    }
}