# Footwear Store - Website Bán Giày Dép Trực Tuyến

Dự án website thương mại điện tử chuyên kinh doanh giày dép, thời trang được xây dựng trên nền tảng **ASP.NET MVC 5** (.NET Framework) kết hợp với **Entity Framework 6** và **Microsoft SQL Server**.

---

## 📌 Công nghệ sử dụng

- **Backend:** C#, ASP.NET MVC 5 (.NET Framework 4.6.1)
- **ORM / Database Access:** Entity Framework 6 (Database First / Code First)
- **Database:** Microsoft SQL Server
- **Frontend Client:** Razor View Engine (`.cshtml`), HTML5, CSS3, JavaScript, jQuery, Bootstrap
- **Frontend Admin:** AdminLTE v2 Dashboard Template, CKEditor, CKFinder, DataTables, iCheck
- **Tools:** Visual Studio 2017/2019/2022, SQL Server Management Studio (SSMS)

---

## 🚀 Các tính năng chính

### 1. Phía Khách hàng (Client)
- **Trang chủ:** Banner trình chiếu (slider), danh sách sản phẩm mới nhất, sản phẩm nổi bật / bán chạy.
- **Danh mục & Thương hiệu:** Xem và lọc sản phẩm theo nhóm danh mục (Nam, Nữ, Trẻ em...) và theo thương hiệu/hãng sản xuất (Brand).
- **Chi tiết sản phẩm:** Xem hình ảnh, mô tả chi tiết, giá tiền và bộ sưu tập ảnh phụ của từng mẫu giày.
- **Giỏ hàng & Đặt hàng:**
  - Thêm sản phẩm vào giỏ hàng, cập nhật số lượng, xóa sản phẩm.
  - Tính tổng tiền và đặt hàng trực tuyến.
- **Tài khoản:** Đăng ký tài khoản thành viên mới, đăng nhập hệ thống.
- **Liên hệ:** Gửi phản hồi / thư liên hệ đến ban quản trị.

### 2. Phía Quản trị viên (Admin Dashboard)
- **Quản lý sản phẩm:** Thêm mới, chỉnh sửa thông tin, giá, số lượng, tải lên hình ảnh đại diện và ảnh phụ, xóa sản phẩm.
- **Quản lý danh mục & thương hiệu:** Tạo và cập nhật phân loại sản phẩm.
- **Quản lý đơn hàng & giao dịch:** Theo dõi các đơn đặt hàng mới, quản lý trạng thái thanh toán và giao dịch.
- **Quản lý khách hàng & người dùng:** Quản lý danh sách thành viên và phân quyền tài khoản quản trị.
- **Quản lý Banner Slider:** Cập nhật hình ảnh slider trình chiếu ở trang chủ website.
- **Quản lý Hộp thư góp ý:** Xem và xử lý các phản hồi từ khách hàng.

---

## 📂 Cấu trúc thư mục

```text
Project_.net_MVC/
├── Footwear.sql              # Script khởi tạo Cơ sở dữ liệu SQL Server
├── projec6.sln               # Solution file mở bằng Visual Studio
└── projec6/                  # Thư mục mã nguồn chính của ứng dụng Web
    ├── App_Start/            # Cấu hình Route, Bundle, Filter
    ├── Areas/
    │   └── Admin/            # Phân hệ Quản trị viên (Controllers & Views riêng)
    ├── Controllers/          # Các Controller xử lý logic phía người dùng
    ├── Models/               # Các Model dữ liệu & footwear_db DbContext
    ├── Views/                # Giao diện hiển thị Razor (.cshtml)
    ├── Content/              # Tệp tĩnh CSS, JS, thư viện giao diện Admin (AdminLTE)
    ├── images/               # Hình ảnh sản phẩm, banner, người dùng
    ├── Scripts/              # Thư viện JavaScript (jQuery, Bootstrap, AjaxCart)
    ├── packages.config       # Danh sách thư viện NuGet
    └── Web.config            # File cấu hình kết nối CSDL và thiết lập hệ thống
```

---

## 🛠 Hướng dẫn cài đặt & Khởi chạy

### Yêu cầu tiên quyết:
- Hệ điều hành: Windows (khuyên dùng để chạy đầy đủ .NET Framework 4.6.1 và IIS Express).
- IDE: Visual Studio 2017 trở lên (đã cài đặt workload **ASP.NET and web development**).
- Cơ sở dữ liệu: SQL Server (bản Express hoặc Developer) + SQL Server Management Studio (SSMS).

### Các bước cài đặt:

1. **Khởi tạo Cơ sở dữ liệu:**
   - Mở SSMS và kết nối tới SQL Server của bạn.
   - Mở file `Footwear.sql` và nhấn **Execute (F5)** để tạo CSDL `Footwear` cùng dữ liệu mẫu.

2. **Cấu hình chuỗi kết nối (Connection String):**
   - Mở file `projec6/Web.config`.
   - Tìm thẻ `<connectionStrings>` và điều chỉnh lại `data source` khớp với tên SQL Server Instance trên máy của bạn:
     ```xml
     <connectionStrings>
       <add name="footwear_db" 
            connectionString="data source=YOUR_SQL_SERVER_NAME;initial catalog=Footwear;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" 
            providerName="System.Data.SqlClient" />
     </connectionStrings>
     ```

3. **Mở dự án và khôi phục thư viện:**
   - Mở file `projec6.sln` bằng Visual Studio.
   - Nhấp chuột phải vào Solution -> Chọn **Restore NuGet Packages** để tự động tải lại các thư viện còn thiếu.

4. **Khởi chạy ứng dụng:**
   - Nhấn **F5** hoặc **Ctrl + F5** (chạy với IIS Express) để mở website trên trình duyệt.
   - Truy cập trang quản trị bằng đường dẫn: `http://localhost:<port>/Admin/Login`.

---

## 📄 License
Dự án được phục vụ cho mục đích học tập và nghiên cứu.
