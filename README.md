# ỨNG DỤNG QUẢN LÝ CHI TIÊU CÁ NHÂN (QUANLYCHITIEU)

Dự án đồ án / ứng dụng Windows Forms phát triển trên nền tảng **C# .NET Framework 4.8** kết hợp hệ quản trị cơ sở dữ liệu **Microsoft SQL Server (LocalDB)**. Ứng dụng hỗ trợ theo dõi thu chi, chuyển tiền nội bộ giữa các ví, lập ngân sách cảnh báo, quản lý mục tiêu tiết kiệm, giao dịch định kỳ, báo cáo thống kê trực quan và xuất dữ liệu Excel/PDF.

---

## 👥 DANH SÁCH TÀI KHOẢN ĐĂNG NHẬP (PUBLIC)

Hệ thống đã tích hợp sẵn các tài khoản thử nghiệm với đầy đủ phân quyền và dữ liệu thực tế:

| Tên đăng nhập | Mật khẩu | Quyền hạn | Họ và tên | Trạng thái | Ghi chú |
| :--- | :--- | :--- | :--- | :--- | :--- |
| **`diepnguyen`** | **`diepthanh01@`** | **Admin** | Nguyễn Văn Thanh Diệp | Hoạt động | Có đầy đủ dữ liệu thu chi, giao dịch, ngân sách |
| **`minhanh`** | **`12345678`** | **Admin** | Nguyễn Minh Anh | Hoạt động | Tài khoản quản trị hệ thống |
| **`tuananh`** | **`12345678`** | **Admin** | Đặng Tuấn Anh | Hoạt động | Quản trị viên |
| **`ngoclinh`** | **`12345678`** | **User** | Trần Ngọc Linh | Hoạt động | Người dùng tiêu chuẩn |
| **`quanghuy`** | **`12345678`** | **User** | Lê Quang Huy | Hoạt động | Người dùng tiêu chuẩn |
| **`hoangnam`** | **`12345678`** | **User** | Phạm Hoàng Nam | Hoạt động | Người dùng tiêu chuẩn |
| **`ducminh`** | **`12345678`** | **User** | Bùi Đức Minh | Hoạt động | Người dùng tiêu chuẩn |

> **Lưu ý:**
> - Các tài khoản mẫu ban đầu (`minhanh`, `ngoclinh`, v.v.) cũng có thể sử dụng các mật khẩu phụ trợ: `123456`, `admin` hoặc `minhanh123`.

---

## 🚀 CÁCH CÀI ĐẶT & KHỞI CHẠY DỰ ÁN

### 1. Yêu cầu hệ thống
- **Hệ điều hành:** Windows 10 / Windows 11.
- **Môi trường phát triển:** Visual Studio 2019 / 2022 (hoặc VS Community) với workload *.NET Desktop Development*.
- **Target Framework:** .NET Framework 4.8.
- **Cơ sở dữ liệu:** SQL Server Express LocalDB (`(LocalDB)\MSSQLLocalDB`).

### 2. Khởi chạy dự án
1. Clone hoặc tải mã nguồn về máy:
   ```bash
   git clone https://github.com/dipluc/QuanLyChiTieu_window.git
   ```
2. Mở file giải pháp `QuanLyChiTieu.sln` bằng Visual Studio.
3. Cơ sở dữ liệu `QLChiTieu.mdf` đã được đặt sẵn trong thư mục `LTWIN_N05_QLCT/Database/`. Lớp kết nối `DuLieu.KetNoiCSDL` sẽ tự động phát hiện đường dẫn tệp database theo thư mục chạy hoặc chuỗi cấu hình trong `App.config`.
4. Nhấn **F5** hoặc chọn **Debug > Start Debugging** để biên dịch và chạy phần mềm.

---

## 🛠️ CÁC TÍNH NĂNG CHÍNH CỦA HỆ THỐNG

1. **Bảng điều khiển (Dashboard):** Thống kê nhanh tổng thu nhập, chi tiêu, số dư các ví theo tháng, biểu đồ tỉ lệ trực quan.
2. **Quản lý thu nhập & chi tiêu:** Ghi nhận các giao dịch theo từng ví (Tiền mặt, Vietcombank, Momo, Techcombank,...), phân loại theo danh mục chi tiết.
3. **Chuyển tiền giữa các ví:** Giao dịch điều chuyển vốn nội bộ, tự động cập nhật số dư giữa ví nguồn và ví đích, không làm biến động tổng tài sản.
4. **Quản lý ngân sách:** Đặt hạn mức chi tiêu theo tháng và danh mục, tự động tính toán tiến độ sử dụng và cảnh báo khi sắp hoặc đã vượt hạn mức.
5. **Mục tiêu tiết kiệm:** Thiết lập mục tiêu tài chính, quản lý nạp / rút tiền vào quỹ tiết kiệm, theo dõi tiến độ hoàn thành theo từng mốc thời gian.
6. **Giao dịch định kỳ:** Thiết lập các khoản thu/chi lặp lại tự động theo chu kỳ (hàng ngày, hàng tuần, hàng tháng).
7. **Báo cáo & Thống kê:**
   - Báo cáo biến động thu chi theo tháng và theo danh mục.
   - Biểu đồ trực quan hóa dữ liệu dòng tiền.
   - Xuất dữ liệu ra file Excel và tài liệu PDF.
8. **Quản trị & Hệ thống:**
   - Phân quyền tài khoản (Admin / User), quản lý danh sách người dùng.
   - Quản lý danh mục thu, danh mục chi, nhóm chi và danh sách các ví tiền.
   - Sao lưu dữ liệu (.bak) và phục hồi cơ sở dữ liệu an toàn.
