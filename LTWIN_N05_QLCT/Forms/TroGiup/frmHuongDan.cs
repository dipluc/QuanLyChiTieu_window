using System;
using System.Drawing;
using System.Windows.Forms;

namespace LTWIN_N05_QLCT.Forms.TroGiup
{
    public partial class frmHuongDan : Form
    {
        private static readonly Color MauVienCard = Color.FromArgb(226, 232, 240);
        private static readonly Color MauChon = Color.FromArgb(235, 245, 255);
        private static readonly Color MauChuChon = Color.FromArgb(21, 101, 192);

        public frmHuongDan()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            // Viền 1px mỏng nhẹ cho 2 card panel
            pnlHuongDan.Paint += (s, e) =>
            {
                using (var pen = new Pen(MauVienCard, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, pnlHuongDan.Width - 1, pnlHuongDan.Height - 1);
                }
            };

            pnlNoiDungHuongDan.Paint += (s, e) =>
            {
                using (var pen = new Pen(MauVienCard, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, pnlNoiDungHuongDan.Width - 1, pnlNoiDungHuongDan.Height - 1);
                }
            };

            // Viền panel mẹo sử dụng
            pnlMeoSuDung.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.FromArgb(219, 234, 254), 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, pnlMeoSuDung.Width - 1, pnlMeoSuDung.Height - 1);
                }
            };

            // Nạp danh mục hướng dẫn
            NapDanhMucHuongDan();

            // Xử lý chọn mục trong TreeView
            tvwTinhNang.AfterSelect += (s, e) =>
            {
                if (e.Node != null)
                {
                    CapNhatNoiDungHuongDan(e.Node.Text, e.Node.Parent != null ? e.Node.Parent.Text : "");
                }
            };

            // Custom draw cho TreeView để có màu nền chọn đẹp chuẩn hiện đại
            tvwTinhNang.DrawMode = TreeViewDrawMode.OwnerDrawText;
            tvwTinhNang.DrawNode += (s, e) =>
            {
                bool isSelected = (e.State & TreeNodeStates.Selected) != 0;
                int textY = e.Bounds.Y + 6;

                if (isSelected)
                {
                    using (var b = new SolidBrush(MauChon))
                    {
                        var r = new Rectangle(0, e.Bounds.Y, tvwTinhNang.Width, e.Bounds.Height);
                        e.Graphics.FillRectangle(b, r);
                    }
                    using (var font = new Font(tvwTinhNang.Font, FontStyle.Bold))
                    {
                        TextRenderer.DrawText(e.Graphics, e.Node.Text, font,
                            new Point(e.Bounds.X, textY), MauChuChon);
                    }
                }
                else
                {
                    bool isParent = e.Node.Nodes.Count > 0;
                    Color textCol = isParent ? Color.FromArgb(30, 41, 59) : Color.FromArgb(71, 85, 105);
                    using (var font = isParent ? new Font(tvwTinhNang.Font, FontStyle.Bold) : tvwTinhNang.Font)
                    {
                        TextRenderer.DrawText(e.Graphics, e.Node.Text, font,
                            new Point(e.Bounds.X, textY), textCol);
                    }
                }
            };
        }

        private void NapDanhMucHuongDan()
        {
            tvwTinhNang.Nodes.Clear();

            // 1. Tài khoản
            var nTaiKhoan = tvwTinhNang.Nodes.Add("Tài khoản");
            nTaiKhoan.Nodes.Add("Đăng nhập và thông tin cá nhân");

            // 2. Danh mục
            var nDanhMuc = tvwTinhNang.Nodes.Add("Danh mục");
            nDanhMuc.Nodes.Add("Loại thu, nhóm và loại chi");

            // 3. Thu chi
            var nThuChi = tvwTinhNang.Nodes.Add("Thu chi");
            nThuChi.Nodes.Add("Ghi nhận khoản thu");
            var nKhoanChi = nThuChi.Nodes.Add("Ghi nhận khoản chi");
            nThuChi.Nodes.Add("Tìm kiếm giao dịch");

            // 4. Các mục khác
            tvwTinhNang.Nodes.Add("Ví và chuyển tiền");
            tvwTinhNang.Nodes.Add("Ngân sách");
            tvwTinhNang.Nodes.Add("Báo cáo");
            tvwTinhNang.Nodes.Add("Sao lưu");

            // Mở rộng mục Thu chi và chọn mặc định Ghi nhận khoản chi
            nThuChi.Expand();
            tvwTinhNang.SelectedNode = nKhoanChi;
        }

        private void CapNhatNoiDungHuongDan(string tieuDe, string nhomCha)
        {
            switch (tieuDe)
            {
                case "Ghi nhận khoản chi":
                    lblThuChiChiNhanKhoanChi.Text = "Thu chi  /  Ghi nhận khoản chi";
                    lblGhiNhanKhoanChi.Text = "Ghi nhận khoản chi";
                    lblTheoDoiKhoanTienDaChi.Text = "Theo dõi khoản tiền đã chi và cập nhật số dư ví, ngân sách tương ứng.";

                    lblBuoc1TieuDe.Text = "1. Mở màn hình Chi tiêu";
                    lblBuoc1NoiDung.Text = "Chọn Nghiệp vụ → Chi tiêu, hoặc nhấn \"Chi tiêu\" trên thanh công cụ nhanh.";

                    lblBuoc2TieuDe.Text = "2. Nhập thông tin giao dịch";
                    lblBuoc2NoiDung.Text = "Chọn ngày chi, ví thanh toán, nhóm và loại chi. Nhập số tiền lớn hơn 0 và ghi chú chi tiết nếu cần.";

                    lblBuoc3TieuDe.Text = "3. Kiểm tra và lưu";
                    lblBuoc3NoiDung.Text = "Kiểm tra số tiền, ví và danh mục, sau đó nhấn Thêm. Giao dịch được lưu và số dư ví được tự động trừ tương ứng.";

                    lblBuoc4TieuDe.Text = "4. Tra cứu hoặc chỉnh sửa";
                    lblBuoc4NoiDung.Text = "Chọn giao dịch trong danh sách để xem chi tiết. Nhấn Sửa hoặc Xóa để điều chỉnh thông tin khi có sai sót.";

                    lblMeoSuDung.Text = "Mẹo sử dụng";
                    lblGhiChuRoMucDichChi.Text = "Ghi chú rõ mục đích chi, ví dụ \"Ăn trưa công ty\", để tìm lại nhanh. Chuyển tiền giữa hai ví nên dùng chức năng Chuyển tiền, không ghi thành khoản chi.";
                    break;

                case "Ghi nhận khoản thu":
                    lblThuChiChiNhanKhoanChi.Text = "Thu chi  /  Ghi nhận khoản thu";
                    lblGhiNhanKhoanChi.Text = "Ghi nhận khoản thu";
                    lblTheoDoiKhoanTienDaChi.Text = "Ghi chép các nguồn thu nhập như lương, thưởng, kinh doanh, lãi tiết kiệm vào ví.";

                    lblBuoc1TieuDe.Text = "1. Mở màn hình Thu nhập";
                    lblBuoc1NoiDung.Text = "Chọn Nghiệp vụ → Thu nhập, hoặc nhấn nút \"+ Thu nhập\" trên thanh công cụ.";

                    lblBuoc2TieuDe.Text = "2. Nhập thông tin khoản thu";
                    lblBuoc2NoiDung.Text = "Chọn ngày nhận tiền, ví tiền nhận và loại nguồn thu. Nhập số tiền thu nhập và nội dung mô tả chi tiết.";

                    lblBuoc3TieuDe.Text = "3. Lưu thông tin";
                    lblBuoc3NoiDung.Text = "Nhấn Thêm để ghi nhận giao dịch. Số dư của ví tiền tương ứng sẽ tự động tăng lên ngay lập tức.";

                    lblBuoc4TieuDe.Text = "4. Quản lý danh sách thu";
                    lblBuoc4NoiDung.Text = "Xem lại danh sách các khoản thu trong tháng, lọc theo nguồn thu hoặc ví nhận để quản lý dòng tiền.";

                    lblMeoSuDung.Text = "Mẹo sử dụng";
                    lblGhiChuRoMucDichChi.Text = "Phân loại nguồn thu rõ ràng (Lương cố định vs Thưởng/Làm thêm) để tiện theo dõi biểu đồ cơ cấu thu nhập trong phần Báo cáo.";
                    break;

                case "Tìm kiếm giao dịch":
                    lblThuChiChiNhanKhoanChi.Text = "Thu chi  /  Tìm kiếm giao dịch";
                    lblGhiNhanKhoanChi.Text = "Tìm kiếm giao dịch";
                    lblTheoDoiKhoanTienDaChi.Text = "Tra cứu nhanh chóng các khoản thu - chi theo từ khóa, thời gian, số tiền và loại ví.";

                    lblBuoc1TieuDe.Text = "1. Mở màn hình Tìm kiếm";
                    lblBuoc1NoiDung.Text = "Chọn Nghiệp vụ → Tìm kiếm, hoặc nhấn nút \"Tìm kiếm\" trên thanh công cụ nhanh.";

                    lblBuoc2TieuDe.Text = "2. Thiết lập điều kiện lọc";
                    lblBuoc2NoiDung.Text = "Nhập từ khóa cần tìm, chọn khoảng thời gian (từ ngày - đến ngày), hoặc lọc theo khoảng tiền và danh mục.";

                    lblBuoc3TieuDe.Text = "3. Xem kết quả";
                    lblBuoc3NoiDung.Text = "Danh sách kết quả hiển thị chi tiết các giao dịch khớp điều kiện kèm tổng tiền thu và tổng tiền chi.";

                    lblBuoc4TieuDe.Text = "4. Xuất dữ liệu";
                    lblBuoc4NoiDung.Text = "Bạn có thể xem chi tiết từng giao dịch hoặc xuất kết quả tìm kiếm ra bảng tính Excel khi cần đối soát.";

                    lblMeoSuDung.Text = "Mẹo sử dụng";
                    lblGhiChuRoMucDichChi.Text = "Để tìm kiếm chính xác nhất, bạn có thể gõ nội dung ghi chú hoặc lọc theo khoảng ngày cụ thể để đối soát ngân hàng nhanh.";
                    break;

                case "Đăng nhập và thông tin cá nhân":
                case "Tài khoản":
                    lblThuChiChiNhanKhoanChi.Text = "Tài khoản  /  Đăng nhập và thông tin cá nhân";
                    lblGhiNhanKhoanChi.Text = "Đăng nhập và thông tin cá nhân";
                    lblTheoDoiKhoanTienDaChi.Text = "Quản lý thông tin tài khoản đăng nhập, đổi mật khẩu và bảo mật dữ liệu cá nhân.";

                    lblBuoc1TieuDe.Text = "1. Đăng nhập hệ thống";
                    lblBuoc1NoiDung.Text = "Khởi chạy ứng dụng và nhập tên tài khoản cùng mật khẩu chính xác để truy cập cơ sở dữ liệu chi tiêu.";

                    lblBuoc2TieuDe.Text = "2. Cập nhật thông tin cá nhân";
                    lblBuoc2NoiDung.Text = "Vào menu Hệ thống → Thông tin cá nhân để kiểm tra và điều chỉnh họ tên, số điện thoại, email liên hệ.";

                    lblBuoc3TieuDe.Text = "3. Đổi mật khẩu an toàn";
                    lblBuoc3NoiDung.Text = "Chọn Hệ thống → Đổi mật khẩu, nhập mật khẩu hiện tại và thiết lập mật khẩu mới có độ bảo mật cao.";

                    lblBuoc4TieuDe.Text = "4. Đăng xuất an toàn";
                    lblBuoc4NoiDung.Text = "Nhấn Hệ thống → Đăng xuất khi kết thúc phiên làm việc để đảm bảo tính riêng tư của dữ liệu tài chính.";

                    lblMeoSuDung.Text = "Mẹo sử dụng";
                    lblGhiChuRoMucDichChi.Text = "Nên đổi mật khẩu định kỳ 3 tháng một lần và không chia sẻ tài khoản đăng nhập để đảm bảo an toàn cho dữ liệu tài chính của bạn.";
                    break;

                case "Loại thu, nhóm và loại chi":
                case "Danh mục":
                    lblThuChiChiNhanKhoanChi.Text = "Danh mục  /  Loại thu, nhóm và loại chi";
                    lblGhiNhanKhoanChi.Text = "Quản lý danh mục thu chi";
                    lblTheoDoiKhoanTienDaChi.Text = "Tổ chức và chuẩn hóa các danh mục thu nhập, nhóm chi và loại chi tiêu cá nhân.";

                    lblBuoc1TieuDe.Text = "1. Truy cập danh mục";
                    lblBuoc1NoiDung.Text = "Mở menu Danh mục → chọn \"Loại thu\" hoặc \"Loại chi\" tùy theo nhu cầu cấu hình.";

                    lblBuoc2TieuDe.Text = "2. Xem danh mục mặc định";
                    lblBuoc2NoiDung.Text = "Hệ thống đã chuẩn hóa sẵn các nhóm phổ biến như Ăn uống, Nhà ở, Đi lại, Mua sắm, Lương, Thưởng...";

                    lblBuoc3TieuDe.Text = "3. Thêm mới danh mục";
                    lblBuoc3NoiDung.Text = "Nhập tên danh mục mới, chọn nhóm chi trực thuộc và bấm Thêm để sử dụng ngay trong các giao dịch.";

                    lblBuoc4TieuDe.Text = "4. Điều chỉnh hoặc ngừng sử dụng";
                    lblBuoc4NoiDung.Text = "Có thể sửa đổi tên danh mục hoặc xóa bớt các mục không dùng tới để giao diện nhập liệu gọn gàng hơn.";

                    lblMeoSuDung.Text = "Mẹo sử dụng";
                    lblGhiChuRoMucDichChi.Text = "Nên phân loại nhóm chi rõ ràng giữa \"Thiết yếu\" (ăn uống, hóa đơn) và \"Linh hoạt\" (giải trí, mua sắm) để dễ lập ngân sách.";
                    break;

                case "Ví và chuyển tiền":
                    lblThuChiChiNhanKhoanChi.Text = "Nghiệp vụ  /  Ví và chuyển tiền";
                    lblGhiNhanKhoanChi.Text = "Quản lý ví và chuyển tiền";
                    lblTheoDoiKhoanTienDaChi.Text = "Quản lý các tài khoản thanh toán và luân chuyển dòng tiền giữa các ví an toàn.";

                    lblBuoc1TieuDe.Text = "1. Quản lý danh sách ví";
                    lblBuoc1NoiDung.Text = "Vào Danh mục → Ví tiền để quản lý các ví: Tiền mặt, Thẻ ngân hàng (Vietcombank, MB...), Ví điện tử (MoMo, ZaloPay).";

                    lblBuoc2TieuDe.Text = "2. Thiết lập ví mặc định";
                    lblBuoc2NoiDung.Text = "Đặt ví bạn thường xuyên sử dụng nhất làm ví mặc định để tự động chọn khi thêm giao dịch thu - chi.";

                    lblBuoc3TieuDe.Text = "3. Chuyển tiền giữa các ví";
                    lblBuoc3NoiDung.Text = "Chọn Nghiệp vụ → Chuyển tiền khi rút tiền mặt từ ATM hoặc chuyển tiền nạp vào ví điện tử.";

                    lblBuoc4TieuDe.Text = "4. Ghi nhận phí chuyển (nếu có)";
                    lblBuoc4NoiDung.Text = "Hệ thống tự động trừ tiền ở ví nguồn, cộng tiền vào ví đích và hạch toán phí giao dịch chuẩn xác.";

                    lblMeoSuDung.Text = "Mẹo sử dụng";
                    lblGhiChuRoMucDichChi.Text = "Sử dụng tính năng Chuyển tiền giúp bảo toàn tổng tài sản thực tế và không làm sai lệch báo cáo thu chi trong tháng.";
                    break;

                case "Ngân sách":
                    lblThuChiChiNhanKhoanChi.Text = "Nghiệp vụ  /  Ngân sách";
                    lblGhiNhanKhoanChi.Text = "Quản lý hạn mức ngân sách";
                    lblTheoDoiKhoanTienDaChi.Text = "Đặt định mức chi tiêu cho từng hạng mục trong tháng để tránh vung tay quá trán.";

                    lblBuoc1TieuDe.Text = "1. Mở màn hình Ngân sách";
                    lblBuoc1NoiDung.Text = "Nhấn nút \"Ngân sách\" trên thanh công cụ hoặc chọn menu Nghiệp vụ → Ngân sách.";

                    lblBuoc2TieuDe.Text = "2. Thiết lập hạn mức tháng";
                    lblBuoc2NoiDung.Text = "Chọn tháng và nhóm chi cần kiểm soát (ví dụ Ăn uống: 3.500.000 đ), nhập số tiền và nhấn Lưu.";

                    lblBuoc3TieuDe.Text = "3. Theo dõi tiến độ chi tiêu";
                    lblBuoc3NoiDung.Text = "Hệ thống hiển thị thanh tiến độ phần trăm chi tiêu thực tế so với định mức cùng số tiền còn lại.";

                    lblBuoc4TieuDe.Text = "4. Cảnh báo vượt ngưỡng";
                    lblBuoc4NoiDung.Text = "Thanh tiến độ chuyển sang màu vàng cảnh báo khi chi > 80% và màu đỏ báo động khi chi vượt 100% định mức.";

                    lblMeoSuDung.Text = "Mẹo sử dụng";
                    lblGhiChuRoMucDichChi.Text = "Nên áp dụng quy tắc 50/30/20: 50% thu nhập cho nhu cầu thiết yếu, 30% cho sở thích và 20% cho tiết kiệm / đầu tư.";
                    break;

                case "Báo cáo":
                    lblThuChiChiNhanKhoanChi.Text = "Báo cáo  /  Báo cáo & Thống kê";
                    lblGhiNhanKhoanChi.Text = "Xem báo cáo và phân tích tài chính";
                    lblTheoDoiKhoanTienDaChi.Text = "Cung cấp cái nhìn trực quan và toàn diện về bức tranh tài chính cá nhân của bạn.";

                    lblBuoc1TieuDe.Text = "1. Chọn loại báo cáo";
                    lblBuoc1NoiDung.Text = "Chọn menu Báo cáo: Báo cáo tháng, Báo cáo thu - chi, Báo cáo ngân sách hoặc Biểu đồ trực quan.";

                    lblBuoc2TieuDe.Text = "2. Chọn kỳ phân tích";
                    lblBuoc2NoiDung.Text = "Lựa chọn tháng, quý, năm cần đánh giá và lọc theo từng ví cụ thể hoặc tổng hợp tất cả ví.";

                    lblBuoc3TieuDe.Text = "3. Phân tích biểu đồ";
                    lblBuoc3NoiDung.Text = "Theo dõi biểu đồ cột biến động thu - chi 12 tháng và biểu đồ tròn tỷ trọng các loại chi tiêu.";

                    lblBuoc4TieuDe.Text = "4. Xuất báo cáo";
                    lblBuoc4NoiDung.Text = "Nhấn nút \"Xuất báo cáo\" để in tài liệu hoặc lưu trữ bảng tính Excel, PDF phục vụ theo dõi lâu dài.";

                    lblMeoSuDung.Text = "Mẹo sử dụng";
                    lblGhiChuRoMucDichChi.Text = "Định kỳ vào ngày cuối tháng, hãy mở Báo cáo tháng để xem lại các khoản chi lớn nhất và tìm giải pháp tối ưu cho tháng sau.";
                    break;

                case "Sao lưu":
                    lblThuChiChiNhanKhoanChi.Text = "Quản trị  /  Sao lưu & Phục hồi";
                    lblGhiNhanKhoanChi.Text = "Sao lưu và phục hồi dữ liệu";
                    lblTheoDoiKhoanTienDaChi.Text = "Đảm bảo toàn vẹn dữ liệu sổ sách thu chi, tránh rủi ro mất mát dữ liệu do sự cố máy tính.";

                    lblBuoc1TieuDe.Text = "1. Mở tính năng Sao lưu";
                    lblBuoc1NoiDung.Text = "Truy cập menu Quản trị → Sao lưu dữ liệu để mở giao diện quản lý sao lưu an toàn.";

                    lblBuoc2TieuDe.Text = "2. Tạo bản sao lưu";
                    lblBuoc2NoiDung.Text = "Chọn thư mục lưu trữ (ổ đĩa an toàn, USB hoặc thư mục đồng bộ Google Drive/OneDrive) và nhấn \"Sao lưu\".";

                    lblBuoc3TieuDe.Text = "3. Phục hồi khi cần";
                    lblBuoc3NoiDung.Text = "Khi cài lại máy hoặc chuyển dữ liệu sang máy mới, chọn tệp tin sao lưu (.bak) và nhấn \"Phục hồi\".";

                    lblBuoc4TieuDe.Text = "4. Cấu hình tự động";
                    lblBuoc4NoiDung.Text = "Trong phần Quản trị → Cấu hình, bạn có thể bật tính năng tự động sao lưu dữ liệu mỗi khi đóng ứng dụng.";

                    lblMeoSuDung.Text = "Mẹo sử dụng";
                    lblGhiChuRoMucDichChi.Text = "Nên sao lưu file ra ổ đĩa đám mây (Google Drive, OneDrive) ít nhất một lần mỗi tuần để bảo vệ tối đa dữ liệu tài chính của bạn.";
                    break;

                default:
                    string duongDan = string.IsNullOrEmpty(nhomCha) ? tieuDe : nhomCha + "  /  " + tieuDe;
                    lblThuChiChiNhanKhoanChi.Text = duongDan;
                    lblGhiNhanKhoanChi.Text = tieuDe;
                    lblTheoDoiKhoanTienDaChi.Text = "Hướng dẫn chi tiết cách sử dụng chức năng " + tieuDe + " trong hệ thống.";

                    lblBuoc1TieuDe.Text = "1. Mở chức năng";
                    lblBuoc1NoiDung.Text = "Truy cập vào thanh menu hoặc thanh công cụ nhanh để mở giao diện " + tieuDe + ".";

                    lblBuoc2TieuDe.Text = "2. Thao tác dữ liệu";
                    lblBuoc2NoiDung.Text = "Nhập hoặc chọn các thông tin cần thiết theo các trường dữ liệu trên màn hình.";

                    lblBuoc3TieuDe.Text = "3. Lưu thông tin";
                    lblBuoc3NoiDung.Text = "Nhấn Lưu hoặc Thêm để hoàn tất thao tác ghi nhận dữ liệu vào hệ thống.";

                    lblBuoc4TieuDe.Text = "4. Kiểm tra kết quả";
                    lblBuoc4NoiDung.Text = "Dữ liệu được cập nhật đồng bộ và hiển thị ngay trên bảng danh sách liên quan.";

                    lblMeoSuDung.Text = "Ghi chú";
                    lblGhiChuRoMucDichChi.Text = "Nếu cần thêm thông tin hoặc trợ giúp kỹ thuật, bạn có thể tham khảo mục Giới thiệu hoặc liên hệ quản trị viên.";
                    break;
            }
        }
    }
}
