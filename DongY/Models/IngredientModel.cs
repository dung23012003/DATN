using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DongY.Models
{
    public class IngredientModel
    {
        [Key]  // Đánh dấu IngredientId là khóa chính
        public int IngredientId { get; set; }

        public string Name { get; set; }
        public string? Effect { get; set; }
        public string? Note { get; set; }

        public ICollection<ProductIngredientModel> ProductIngredients { get; set; }
    }
}
