using System.ComponentModel.DataAnnotations;

namespace DongY.Models
{
    public class ProductIngredientModel
    {
        [Key]
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }

        public int IngredientId { get; set; }
        public IngredientModel Ingredient { get; set; }

        public string? Amount { get; set; }
    }

}
