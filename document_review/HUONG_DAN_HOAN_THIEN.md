# Hướng dẫn hoàn thiện tiểu luận

## Phạm vi bản đã sửa
- File gốc trên Desktop được giữ nguyên. Bản sửa nằm cùng thư mục với hướng dẫn này.
- Đã sửa các lỗi chữ rõ ràng như “ÚNG DỤNG”, “Dăng Ký”, “Chuyẻn Tiền”, “Luồn điều hướng”, “Kến trúc”, “SQL sever”, “cơ sở dũ liệu”, “Desigenr”, “26 fom”, “Mức độc”, “ưu tiêu”, “cá form”, “đống vai trò”, “gập”; thêm khoảng trắng ở “hơn.Chúng em”.
- Đã đánh lại 26 chú thích hình theo thứ tự Hình 3.1 đến Hình 3.26 và đồng bộ 26 mục trong danh mục hình. Không đổi số các mục 3.5–3.30.
- Chỉ sửa phần chữ trong document.xml; các thành phần khác trong gói DOCX giữ nguyên từng byte, bao gồm ảnh, styles, header/footer và cấu hình trang. Không thêm đoạn nội dung mới hay sửa luận điểm.
- Đã kiểm tra cấu trúc ZIP/XML và số lượng hình. Chưa kiểm tra trực quan từng trang vì môi trường thiếu công cụ kết xuất LibreOffice. Cần mở bản sao bằng Word để kiểm tra trước khi nộp.

## Những nhận xét trong ảnh cần đối chiếu lại
- File hiện có đủ 26 mục trong danh mục hình, gồm Giới thiệu, Mục tiêu tiết kiệm và Giao dịch định kỳ; không cần thêm lại ba mục này.
- Bìa là Trường Đại học Văn Hiến. Không áp mẫu HUTECH chỉ vì ảnh nhận xét nhắc mẫu đó; kiểm tra hướng dẫn chính thức của môn học.
- Các mục 3.5–3.30 có 26 đề mục màn hình. Tuy nhiên danh sách nhóm ở 3.2 và bảng phân công vẫn cần đối chiếu với form thực tế trước khi khẳng định thống nhất.

## 1. Lời nói đầu và số mục Chương 1
Hiện “Lý do chọn đề tài” và “Mục tiêu đề tài” đều mang số 1.2. Chưa tự sửa vì phải quyết định cấu trúc cùng phần Lời nói đầu còn thiếu.
Nếu hướng dẫn môn yêu cầu Lời nói đầu trong Chương 1, có thể bố trí: 1.1 Lời nói đầu; 1.2 Lý do chọn đề tài; 1.3 Mục tiêu đề tài; 1.4 Đối tượng và phạm vi. Nếu giảng viên quy định cấu trúc khác, dùng đúng cấu trúc đó.
Tự viết Lời nói đầu ngắn theo quá trình làm thật: bối cảnh, lý do thực hiện, phạm vi sản phẩm và cách nhóm triển khai. Không chép kết quả chưa thực hiện. Sau đó cập nhật mục lục.

## 2. Chương 2 và sơ đồ
- Xác nhận vị trí 2.4: nếu không có mục nào bị thiếu nội dung, đổi 2.5→2.4, 2.6→2.5, 2.7→2.6 và 2.8→2.7. Nếu có mục bị bỏ sót thì bổ sung mục đó, giữ số hiện tại. Mục Bảo mật đang dùng Normal; đặt Heading 2 để vào mục lục.
- Mục Yêu cầu chức năng đang trống: lập danh sách chức năng dựa trên app đã chạy, mỗi chức năng nêu tác nhân, đầu vào, kết quả và điều kiện kiểm tra. Ví dụ cấu trúc một dòng: “Ghi nhận chi tiêu — Người dùng — ví, loại chi, ngày, số tiền — lưu giao dịch hợp lệ và cập nhật số dư hiển thị”. Đây là mẫu cách viết, cần kiểm tra với app.
- Vẽ sơ đồ phân rã chức năng bằng Shapes/SmartArt của Word hoặc công cụ vẽ: gốc Quản lý chi tiêu cá nhân; các nhánh theo nhóm chức năng thực tế trong 3.2. Không đưa chức năng chưa làm vào phần kết quả đã đạt được.
- ERD: lấy từ cơ sở dữ liệu thật. Trong SSMS, mở database → Database Diagrams → New Database Diagram → chọn các bảng (nếu phiên bản/quyền hỗ trợ). Kiểm tra PK/FK trước khi xuất hình. Hoặc vẽ thủ công theo lược đồ SQL, ghi rõ khóa chính, khóa ngoại và quan hệ 1–n. Không suy quan hệ chỉ theo tên cột.
- Chèn hình vào phần phân tích/thiết kế tương ứng và tạo caption Hình 2.1, Hình 2.2; thêm các hình mới vào danh mục hình, không đổi lại hình Chương 3.

## 3. Chương 3
- Mục 3.4 đang trống, trong khi 3.1 có bảng nguyên tắc. Cách ít xáo trộn: chuyển bảng nguyên tắc giao diện từ 3.1 sang 3.4 nếu đó đúng là nội dung của 3.4; hoặc gộp hai mục rồi đánh lại toàn bộ số mục phía sau. Chỉ chọn sau khi đọc nội dung bảng.
- Form chính: kiểm tra Designer xem thật sự có MenuStrip, ToolStrip, StatusStrip hay không. Nếu có, ghi tên loại control và vai trò vào phần mô tả. Nếu chưa có, đây là việc cần làm trong ứng dụng trước khi chụp lại màn hình; chỉ sửa báo cáo sẽ không đáp ứng yêu cầu.
- Tài khoản đăng nhập: xác nhận quy ước YYYY/XX từ đề bài và tài khoản chạy được trong database. Ghi tài khoản demo vào mục Đăng nhập khi đã thử thành công. Không tự đặt giá trị hoặc dùng mật khẩu tài khoản cá nhân.
- Đối chiếu bảng 3.2, bảng phân công, 26 màn hình và kết luận: phân biệt form đã lập trình, mới thiết kế và dự kiến; điều chỉnh nhận định theo kết quả thật.

## 4. Chuẩn hóa hình thức trong Word
Thực hiện trên bản sao và kiểm tra lại từng trang, đặc biệt bìa, bảng và ảnh.
- Chọn phần thân văn bản (không áp mù quáng lên bìa, ảnh và bảng): Times New Roman 13; Paragraph → Line spacing Multiple 1.3; Before 6 pt; Special First line 1 cm. Đặt riêng headings, caption và nội dung bảng phù hợp hướng dẫn môn. Nếu dùng font mã cũ .VnTime và chữ bị lỗi khi đổi font, cần chuyển mã sang Unicode trước.
- Sửa các style Normal/Heading/Caption/TOC tương ứng để định dạng nhất quán; tránh chỉ Ctrl+A đổi font vì có thể làm hỏng bố cục bìa và bảng.
- Mục lục không hiện số trang: bật ký hiệu ¶, kiểm tra Section Break trước và sau phần mục lục. Nếu mục lục chung section với trang khác, tạo Section Break Next Page phù hợp. Mở header/footer của section mục lục, tắt Link to Previous ở phần chứa số trang; ở section tiếp theo cũng kiểm tra liên kết rồi chỉ xóa trường PAGE của mục lục. Giữ tên đề tài và số trang các phần khác. Kiểm tra lại chế độ tiếp tục hoặc bắt đầu số trang.
- Footer Chương 1: giữ tên chương, xóa riêng trường PAGE bị trùng nếu header đã có số trang. Không xóa toàn bộ footer.
- Danh mục viết tắt: chỉ liệt kê từ thật sự dùng, ví dụ CSDL — Cơ sở dữ liệu; ERD — Entity Relationship Diagram — Sơ đồ thực thể–liên kết; PK — Primary Key — Khóa chính; FK — Foreign Key — Khóa ngoại. Có thể bổ sung UI, SQL, BCrypt nếu cần giải thích, dùng thuật ngữ chính xác.
- Tên bảng: đặt con trỏ ở bảng → References → Insert Caption → New Label “Bảng”; đánh theo chương nếu tiêu đề chương đã được cấu hình numbering đúng. Nếu chưa thiết lập được tự động, đặt số thủ công nhất quán và kiểm tra lại. Caption cần mô tả đúng bảng, không chỉ ghi “Bảng dữ liệu”.
- Danh mục bảng: References → Insert Table of Figures → Caption label “Bảng”. Chỉ sinh được khi đã gắn caption. Tương tự cập nhật danh mục hình từ caption/style hiện có, không thêm danh mục trùng.
- Sau cùng, cập nhật riêng Mục lục và Danh mục hình bằng Update Field → Update entire table. Kiểm tra số Hình 3.1–3.26 và số trang. Với hình hiện có, chú thích là chữ thường chứ không phải chuỗi số SEQ tự động; không chọn lại mẫu tự động làm đổi số chương ngoài ý muốn.

## 5. Tài liệu tham khảo và gói nộp
- Không tự ghi ngày truy cập giả. Mở từng nguồn đã dùng, ghi ngày truy cập thật, tên tác giả/tổ chức, tên tài liệu, năm nếu có và URL. Với Figma, xác nhận tác giả/nhóm sở hữu và tên thiết kế.
- Chia theo ngôn ngữ và xếp ABC theo hướng dẫn của giảng viên. Không thêm tài liệu chưa tham khảo để tăng số lượng.
- Kiểm tra gói mã nguồn có mở được solution và chạy được; backup database là bản đúng, thử phục hồi ở môi trường kiểm tra. Ghi tên tệp và cách chạy/khôi phục vào README hoặc phụ lục theo yêu cầu nộp bài. Không ghi đã đính kèm khi tệp chưa tồn tại.
- Thống nhất tên đề tài và mã nhóm trong tên file/solution theo quy định. Không đổi tên project chỉ để giống tên báo cáo vì có thể ảnh hưởng tham chiếu.
- Xác nhận yêu cầu .doc hay .docx; không đổi đuôi file bằng Rename. Nếu bắt buộc .doc, dùng Save As định dạng Word 97–2003 và kiểm tra lại bố cục.
- Bổ sung ngành/lớp/học phần trên bìa nếu mẫu chính thức của trường yêu cầu.

## Trước khi nộp
Mở bản sửa trong Word, lưu một bản dự phòng, hoàn thiện nội dung cần thiết, cập nhật các danh mục, rồi xem Print Preview toàn bộ. Kiểm tra lỗi rớt dòng, bảng tách trang, caption tách khỏi ảnh, số trang và mục lục. Hạn nộp trong ảnh cần đối chiếu thông báo môn học; bản hướng dẫn này không xác minh lịch nộp.
