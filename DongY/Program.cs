using Microsoft.EntityFrameworkCore;
using DongY.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectedDb")));

// Add services to the container
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");  // Xử lý lỗi khi không phải là môi trường phát triển
    app.UseHsts();  // HSTS giúp bảo mật bằng cách yêu cầu kết nối qua HTTPS
}

app.UseHttpsRedirection();  // Chuyển hướng tất cả yêu cầu HTTP sang HTTPS
app.UseStaticFiles();  // Phục vụ các file tĩnh (CSS, JS, hình ảnh, v.v.)

app.UseRouting();  // Định tuyến yêu cầu HTTP

app.UseAuthorization();  // Xử lý xác thực và phân quyền người dùng

// Định nghĩa routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");  // Chỉ định controller mặc định và action

app.Run();  // Chạy ứng dụng
