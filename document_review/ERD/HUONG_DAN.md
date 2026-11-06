# ERD Quản lý chi tiêu cá nhân

Nguồn: metadata đọc trực tiếp từ database gắn với D:\Nhom5_test2\LTWIN_N05_QLCT\Database\QLChiTieu.mdf. Có 12 bảng và 22 khóa ngoại; không chỉnh schema hay dữ liệu nghiệp vụ.

- ERD_khoa.png: bản gọn, chỉ hiện khóa PK/FK, phù hợp phần thiết kế CSDL khi các thuộc tính đã được trình bày bằng bảng.
- ERD_day_du.png: đủ các cột và kiểu dữ liệu, thích hợp phụ lục hoặc xem trên máy.
- Hai file SVG tương ứng cho phép phóng to mà không vỡ hình.
- ERD_QLChiTieu.mmd: nguồn Mermaid có thể chỉnh sửa và dựng lại.

PK là khóa chính; FK là khóa ngoại; ? là cột cho phép NULL. Các đường xanh liên kết với NguoiDung, đường xám là các liên kết còn lại. Nhãn đọc theo bảng cha → bảng con. 1 → 0..N nghĩa là mỗi bản ghi con tham chiếu đúng một cha và một cha có thể có không hoặc nhiều con. 0..1 → 0..N nghĩa là FK phía con có thể để NULL. Riêng NguoiDung–CauHinh là 1 → 0..1 vì MaND vừa là PK vừa là FK của CauHinh.

ChuyenTien có hai FK độc lập ViNguon, ViDich cùng tham chiếu ViTien.MaVi. GiaoDichDinhKy có MaLoaiThu và MaLoaiChi cho phép NULL; sơ đồ thể hiện tính tùy chọn của FK, không khẳng định hai cột được phép cùng có giá trị trong nghiệp vụ. Việc chọn loại Thu/Chi cần tuân theo kiểm tra của ứng dụng/ràng buộc liên quan.

Cách đưa vào tiểu luận: Word → Insert → Pictures → chọn ERD_khoa.png ở mục Thiết kế cơ sở dữ liệu/Quan hệ giữa các bảng. Đặt caption “Hình 2.1 Sơ đồ thực thể–liên kết cơ sở dữ liệu quản lý chi tiêu cá nhân” nếu đây là hình đầu Chương 2; nếu trước đó có sơ đồ chức năng thì dùng số hình tiếp theo. Cập nhật danh mục hình. Xem Print Preview để bảo đảm chữ đủ lớn; nếu thu nhỏ khó đọc thì dùng trang riêng hoặc đưa bản đầy đủ vào phụ lục. Chưa tự chèn vào file tiểu luận.
