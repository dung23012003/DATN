using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DongY.Models
{
    public class AccountModel
    {
        [Key]
        public int AccountId { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }

        public RoleModel Role { get; set; }
        public CustomerModel Customer { get; set; } // Thuộc tính điều hướng gây lỗi
        public ICollection<BlogModel> Blogs { get; set; }
    }
}