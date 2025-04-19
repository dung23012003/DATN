using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;  // Đừng quên thêm namespace này

namespace DongY.Models
{
    public class CategoryModel
    {
        [Key]  // Đánh dấu CategoryId là khóa chính
        public int CategoryId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<ProductModel> Products { get; set; }
    }
}
