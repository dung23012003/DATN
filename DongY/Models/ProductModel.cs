using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DongY.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }

        public CategoryModel Category { get; set; }
        public ICollection<ProductIngredientModel> ProductIngredients { get; set; }
        public ICollection<ProductSymptomModel> ProductSymptoms { get; set; }
        public ICollection<ReviewModel> Reviews { get; set; }
        public ICollection<WishlistModel> Wishlists { get; set; }
        public ICollection<OrderDetailModel> OrderDetails { get; set; }
    }
}