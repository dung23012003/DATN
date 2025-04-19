using DongY.Models;
using System.ComponentModel.DataAnnotations;

public class BlogModel
{
    [Key]
    public int BlogId { get; set; } // Đảm bảo BlogId là khóa chính

    [Required]
    public int AuthorId { get; set; }

    [Required]
    [StringLength(255)] // Giới hạn độ dài của Title
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    [DataType(DataType.Date)] // Chỉ định kiểu dữ liệu là ngày
    public DateTime PublishedDate { get; set; }

    [Required]
    [DataType(DataType.Date)] // Chỉ định kiểu dữ liệu là ngày
    public DateTime CreatedAt { get; set; }

    public AccountModel Author { get; set; }
}
