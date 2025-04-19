using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DongY.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // 1. Cấu hình để đọc file appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // 2. Tạo DbContextOptionsBuilder
            var builder = new DbContextOptionsBuilder<AppDbContext>();

            // 3. Lấy connection string từ cấu hình
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // 4. Kiểm tra và xử lý nếu connection string null
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException(
                    "Không tìm thấy connection string 'DefaultConnection' trong appsettings.json");
            }

            // 5. Cấu hình và trả về DbContext
            builder.UseSqlServer(connectionString);
            return new AppDbContext(builder.Options);
        }
    }
}