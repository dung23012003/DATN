using Microsoft.EntityFrameworkCore;
using DongY.Models;
using System.Text.Json.Serialization;

namespace DongY.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Danh sách DbSet cho các model
        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<IngredientModel> Ingredients { get; set; }
        public DbSet<ProductIngredientModel> ProductIngredients { get; set; }
        public DbSet<SymptomModel> Symptoms { get; set; }
        public DbSet<ProductSymptomModel> ProductSymptoms { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderDetailModel> OrderDetails { get; set; }
        public DbSet<PaymentModel> Payments { get; set; }
        public DbSet<ReviewModel> Reviews { get; set; }
        public DbSet<WishlistModel> Wishlists { get; set; }
        public DbSet<BlogModel> Blogs { get; set; }
        public DbSet<StatusModel> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Cấu hình các quan hệ
            ConfigureRelationships(modelBuilder);

            // 2. Cấu hình các giá trị mặc định và ràng buộc
            ConfigureDefaultsAndConstraints(modelBuilder);

            // 3. Tạo index cho các trường thường dùng
            CreateIndexes(modelBuilder);
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            // Quan hệ 1-1: Account - Customer
            modelBuilder.Entity<AccountModel>()
                .HasOne(a => a.Customer)
                .WithOne(c => c.Account)
                .HasForeignKey<CustomerModel>(c => c.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            // Quan hệ 1-n: Role - Account
            modelBuilder.Entity<AccountModel>()
                .HasOne(a => a.Role)
                .WithMany(r => r.Accounts)
                .HasForeignKey(a => a.RoleId)
                .IsRequired();

            // Quan hệ n-n: Product - Ingredient
            modelBuilder.Entity<ProductIngredientModel>()
                .HasKey(pi => new { pi.ProductId, pi.IngredientId });

            modelBuilder.Entity<ProductIngredientModel>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(pi => pi.ProductId);

            modelBuilder.Entity<ProductIngredientModel>()
                .HasOne(pi => pi.Ingredient)
                .WithMany(i => i.ProductIngredients)
                .HasForeignKey(pi => pi.IngredientId);

            // Các quan hệ khác tương tự...
        }

        private void ConfigureDefaultsAndConstraints(ModelBuilder modelBuilder)
        {
            // Giá trị mặc định cho ngày tạo
            modelBuilder.Entity<OrderModel>()
                .Property(o => o.OrderDate)
                .HasDefaultValueSql("GETDATE()");

            // Kiểu dữ liệu decimal cho giá sản phẩm
            modelBuilder.Entity<ProductModel>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            // Ràng buộc độ dài cho các trường text
            modelBuilder.Entity<CustomerModel>()
                .Property(c => c.FullName)
                .HasMaxLength(100)
                .IsRequired();
        }

        private void CreateIndexes(ModelBuilder modelBuilder)
        {
            // Index cho các trường thường dùng để tìm kiếm
            modelBuilder.Entity<ProductModel>()
                .HasIndex(p => p.Name);

            // Unique constraint cho email
            modelBuilder.Entity<CustomerModel>()
                .HasIndex(c => c.Email)
                .IsUnique();
        }
    }
}