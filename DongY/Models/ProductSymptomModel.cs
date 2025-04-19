using System.ComponentModel.DataAnnotations;

namespace DongY.Models
{
    public class ProductSymptomModel
    {
        [Key]
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }

        public int SymptomId { get; set; }
        public SymptomModel Symptom { get; set; }
    }

}
