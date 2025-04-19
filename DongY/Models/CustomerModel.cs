using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;  // Thêm namespace này

namespace DongY.Models
{
    public class CustomerModel
    {
        [Key]  // Đánh dấu CustomerId là khóa chính
        public int CustomerId { get; set; }

        public int AccountId { get; set; }
        public AccountModel Account { get; set; } // Thuộc tính điều hướng không gây lỗi nữa

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<OrderModel> Orders { get; set; }
        public ICollection<ReviewModel> Reviews { get; set; }
        public ICollection<WishlistModel> Wishlists { get; set; }
    }
}
