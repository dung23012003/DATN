using System.ComponentModel.DataAnnotations;

namespace DongY.Models
{
    public class SymptomModel
    {
        [Key]
        public int SymptomId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<ProductSymptomModel> ProductSymptoms { get; set; }
    }

}
