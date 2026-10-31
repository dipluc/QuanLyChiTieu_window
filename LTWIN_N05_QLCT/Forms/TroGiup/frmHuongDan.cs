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
            // Viền 1px cho 2 panel trắng
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

            // Tạo các mục danh mục hướng dẫn
            NapDanhMucHuongDan();

            // Xử lý chọn mục trong TreeView
            tvwTinhNang.AfterSelect += (s, e) =>
            {
                if (e.Node != null)
                {
                    CapNhatNoiDungHuongDan(e.Node.Text, e.Node.Parent != null ? e.Node.Parent.Text : "");
                }
            };

            // Custom draw cho TreeView để có màu nền chọn đẹp như Figma
            tvwTinhNang.DrawMode = TreeViewDrawMode.OwnerDrawText;
            tvwTinhNang.DrawNode += (s, e) =>
            {
                bool isSelected = (e.State & TreeNodeStates.Selected) != 0;
                if (isSelected)
                {
                    using (var b = new SolidBrush(MauChon))
                    {
                        var r = new Rectangle(0, e.Bounds.Y, tvwTinhNang.Width, e.Bounds.Height);
                        e.Graphics.FillRectangle(b, r);
                    }
                    TextRenderer.DrawText(e.Graphics, e.Node.Text, tvwTinhNang.Font,
                        new Point(e.Bounds.X, e.Bounds.Y + 6), MauChuChon);
                }
                else
                {
                    Color textCol = e.Node.Nodes.Count > 0 ? Color.FromArgb(30, 41, 59) : Color.FromArgb(71, 85, 105);
                    TextRenderer.DrawText(e.Graphics, e.Node.Text, tvwTinhNang.Font,
                        new Point(e.Bounds.X, e.Bounds.Y + 6), textCol);
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

            // Mở rộng mục Thu chi và chọn mục Ghi nhận khoản chi như thiết kế
            nThuChi.Expand();
            tvwTinhNang.SelectedNode = nKhoanChi;
        }

        private void CapNhatNoiDungHuongDan(string tieuDe, string nhomCha)
        {
            if (tieuDe == "Ghi nhận khoản chi")
            {
                lblThuChiChiNhanKhoanChi.Text = "Thu chi  /  Ghi nhận khoản chi";
                lblGhiNhanKhoanChi.Text = "Ghi nhận khoản chi";
                lblTheoDoiKhoanTienDaChi.Text = "Theo dõi khoản tiền đã chi và cập nhật số dư ví, ngân sách tương ứng.";

                lblBuoc1TieuDe.Text = "1. Mở màn hình Chi tiêu";
                lblBuoc1NoiDung.Text = "Chọn Nghiệp vụ → Chi tiêu, hoặc nhấn Chi tiêu trên thanh công cụ.";

                lblBuoc2TieuDe.Text = "2. Nhập thông tin giao dịch";
                lblBuoc2NoiDung.Text = "Chọn ngày chi, ví thanh toán, nhóm và loại chi. Nhập số tiền lớn hơn 0 và ghi chú nếu cần.";

                lblBuoc3TieuDe.Text = "3. Kiểm tra và lưu";
                lblBuoc3NoiDung.Text = "Kiểm tra số tiền, ví và danh mục, sau đó nhấn Thêm. Giao dịch được đưa vào danh sách và số dư ví được cập nhật.";

                lblBuoc4TieuDe.Text = "4. Tra cứu hoặc chỉnh sửa";
                lblBuoc4NoiDung.Text = "Chọn giao dịch trong danh sách để xem chi tiết. Nhấn Sửa để điều chỉnh thông tin khi có sai sót.";

                lblMeoSuDung.Text = "Mẹo sử dụng";
                lblGhiChuRoMucDichChi.Text = "Ghi chú rõ mục đích chi, ví dụ \"Ăn trưa tại công ty\", để tìm lại nhanh. Chuyển tiền giữa hai ví nên dùng chức năng Chuyển tiền, không ghi thành khoản chi.";
            }
            else if (tieuDe == "Ghi nhận khoản thu")
            {
                lblThuChiChiNhanKhoanChi.Text = "Thu chi  /  Ghi nhận khoản thu";
                lblGhiNhanKhoanChi.Text = "Ghi nhận khoản thu";
                lblTheoDoiKhoanTienDaChi.Text = "Ghi chép các nguồn thu nhập như lương, thưởng, tiền lãi vào ví.";

                lblBuoc1TieuDe.Text = "1. Mở màn hình Thu nhập";
                lblBuoc1NoiDung.Text = "Chọn Nghiệp vụ → Thu nhập, hoặc nhấn + Thu nhập trên thanh công cụ.";

                lblBuoc2TieuDe.Text = "2. Nhập thông tin khoản thu";
                lblBuoc2NoiDung.Text = "Chọn ngày nhận tiền, ví nhận và loại nguồn thu. Nhập số tiền thu nhập và nội dung chi tiết.";

                lblBuoc3TieuDe.Text = "3. Lưu thông tin";
                lblBuoc3NoiDung.Text = "Nhấn Thêm để ghi nhận giao dịch. Số dư của ví tiền tương ứng sẽ tự động tăng lên.";

                lblBuoc4TieuDe.Text = "4. Quản lý danh sách thu";
                lblBuoc4NoiDung.Text = "Xem lại danh sách các khoản thu trong tháng, lọc theo nguồn thu hoặc ví nhận.";

                lblMeoSuDung.Text = "Mẹo sử dụng";
                lblGhiChuRoMucDichChi.Text = "Phân loại nguồn thu rõ ràng (Lương cố định vs Thưởng/Làm thêm) để tiện theo dõi biểu đồ cơ cấu thu nhập trong phần Báo cáo.";
            }
            else if (tieuDe == "Tìm kiếm giao dịch")
            {
                lblThuChiChiNhanKhoanChi.Text = "Thu chi  /  Tìm kiếm giao dịch";
                lblGhiNhanKhoanChi.Text = "Tìm kiếm giao dịch";
                lblTheoDoiKhoanTienDaChi.Text = "Tra cứu nhanh chóng các khoản thu - chi theo từ khóa, thời gian, số tiền và loại ví.";

                lblBuoc1TieuDe.Text = "1. Mở màn hình Tìm kiếm";
                lblBuoc1NoiDung.Text = "Nhấn nút Tìm kiếm trên thanh công cụ nhanh.";

                lblBuoc2TieuDe.Text = "2. Thiết lập điều kiện lọc";
                lblBuoc2NoiDung.Text = "Nhập từ khóa cần tìm, chọn khoảng thời gian (từ ngày - đến ngày), hoặc lọc theo khoảng tiền.";

                lblBuoc3TieuDe.Text = "3. Xem kết quả";
                lblBuoc3NoiDung.Text = "Danh sách kết quả hiển thị chi tiết các giao dịch khớp điều kiện kèm tổng tiền thu/chi.";

                lblBuoc4TieuDe.Text = "4. Xuất dữ liệu";
                lblBuoc4NoiDung.Text = "Bạn có thể xem chi tiết hoặc xuất kết quả tìm kiếm ra bảng tính Excel khi cần.";

                lblMeoSuDung.Text = "Mẹo sử dụng";
                lblGhiChuRoMucDichChi.Text = "Để tìm kiếm chính xác nhất, bạn có thể gõ nội dung ghi chú hoặc lọc theo khoảng ngày cụ thể.";
            }
            else
            {
                string duongDan = string.IsNullOrEmpty(nhomCha) ? tieuDe : nhomCha + "  /  " + tieuDe;
                lblThuChiChiNhanKhoanChi.Text = duongDan;
                lblGhiNhanKhoanChi.Text = tieuDe;
                lblTheoDoiKhoanTienDaChi.Text = "Hướng dẫn chi tiết cách sử dụng chức năng " + tieuDe + " trong hệ thống.";

                lblBuoc1TieuDe.Text = "1. Mở chức năng";
                lblBuoc1NoiDung.Text = "Truy cập vào menu hoặc thanh công cụ nhanh để mở giao diện " + tieuDe + ".";

                lblBuoc2TieuDe.Text = "2. Thao tác dữ liệu";
                lblBuoc2NoiDung.Text = "Nhập hoặc chọn các thông tin cần thiết theo hướng dẫn trên màn hình.";

                lblBuoc3TieuDe.Text = "3. Lưu thông tin";
                lblBuoc3NoiDung.Text = "Nhấn Lưu hoặc Thêm để hoàn tất thao tác.";

                lblBuoc4TieuDe.Text = "4. Kiểm tra kết quả";
                lblBuoc4NoiDung.Text = "Dữ liệu sẽ được cập nhật đồng bộ vào hệ thống cơ sở dữ liệu.";

                lblMeoSuDung.Text = "Ghi chú";
                lblGhiChuRoMucDichChi.Text = "Nếu cần thêm trợ giúp, bạn có thể xem thêm mục Giới thiệu hoặc liên hệ quản trị viên.";
            }
        }
    }
}
