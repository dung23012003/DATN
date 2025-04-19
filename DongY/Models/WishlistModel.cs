using System.ComponentModel.DataAnnotations;

namespace DongY.Models
{
    public class WishlistModel
    {
        [Key]
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public CustomerModel Customer { get; set; }
        public ProductModel Product { get; set; }
    }
}