using System;
using System.Drawing;
using System.Windows.Forms;
using LTWIN_N05_QLCT.Forms.Chinh;

namespace LTWIN_N05_QLCT.Forms.TroGiup
{
    public partial class frmGioiThieu : Form
    {
        private static readonly Color MauVienCard = Color.FromArgb(226, 232, 240);

        public event Action OnYeuCauDong;

        public frmGioiThieu()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            // Cập nhật thông tin giảng viên và nhóm sinh viên thực hiện
            lblGiangVienHuongDan.Location = new Point(28, 144);
            lblGiangVienHuongDan.Text = "Giảng viên hướng dẫn:";

            lblTenGiangVien.Location = new Point(200, 144);
            lblTenGiangVien.Text = "Bùi Thị Hoàng Anh";
            lblTenGiangVien.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTenGiangVien.ForeColor = Color.FromArgb(30, 41, 59);

            lblNhomThucHien.Location = new Point(28, 178);
            lblNhomThucHien.Text = "Sinh viên thực hiện:";

            lblThanhVienNhom.Location = new Point(200, 178);
            lblThanhVienNhom.Text = "Nhóm 5";
            lblThanhVienNhom.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblThanhVienNhom.ForeColor = Color.FromArgb(30, 41, 59);

            lblDanhSachThanhVien.Location = new Point(200, 208);
            lblDanhSachThanhVien.Text =
                "1.  231A010165 — Nguyễn Văn Thanh Diệp\r\n" +
                "2.  231A290050 — Huỳnh Khải Đông\r\n" +
                "3.  231A290140 — Võ Đức Bình\r\n" +
                "4.  231A290014 — Thái Bình Xuyên";
            lblDanhSachThanhVien.ForeColor = Color.FromArgb(51, 65, 85);

            lblThongTinNhomVaGiangVien.Visible = false;

            pnlPhanCach2.Location = new Point(28, 316);
            btnDongGioiThieu.Location = new Point(540, 336);
            pnlGioiThieu.Size = new Size(650, 395);

            // Viền card màu #E2E8F0
            pnlGioiThieu.Paint += (s, e) =>
            {
                using (var pen = new Pen(MauVienCard, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, pnlGioiThieu.Width - 1, pnlGioiThieu.Height - 1);
                }
            };

            // Nút Đóng
            btnDongGioiThieu.Click += (s, e) =>
            {
                OnYeuCauDong?.Invoke();
                Close();
            };
        }
    }
}
