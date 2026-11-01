# QuanLyChiTieu_window

## Chạy và kiểm tra cơ sở dữ liệu

Mở `QuanLyChiTieu.slnx` trong Visual Studio và chạy project `GUI` bằng F5.
Máy cần .NET Framework 4.8 và SQL Server Express LocalDB.

Ứng dụng dùng `Conn_QLChiTieu` trong `App.config`, lấy địa chỉ pipe hiện tại của
`MSSQLLocalDB` bằng công cụ đi kèm LocalDB và tự khởi động instance khi cần.
Không lưu pipe cố định vào cấu hình vì địa chỉ này đổi sau mỗi lần server khởi động.
MDF/LDF chỉ được chép vào thư mục output ở lần build đầu tiên; các lần build tiếp
theo giữ dữ liệu đang sử dụng. Sao lưu database trước khi xóa hoặc Clean thư mục output.

Chạy `powershell -File tools\Test-Database.ps1` để build và truy vấn bằng đúng
.NET Framework/tầng dữ liệu, sau đó kiểm tra trong form WinForms. Có thể thêm
`-RestartLocalDb` để kiểm tra kết nối lại trong cùng tiến trình sau khi LocalDB dừng.
Bài kiểm tra chỉ đọc bảng; tùy chọn restart sẽ dừng instance LocalDB đang dùng.

Chạy EXE với tham số `--check-database` để kiểm tra từ Visual Studio hoặc dòng lệnh.
Kết quả gồm trạng thái debugger, đường dẫn database thực tế và số bảng trong
`database-check.log` cạnh EXE. Chế độ này không cần tài khoản đăng nhập.
