using System;
using System.Drawing;
using System.Windows.Forms;

namespace LTWIN_N05_QLCT.Forms.TroGiup
{
    public partial class frmGioiThieu : Form
    {
        private static readonly Color MauVienCard = Color.FromArgb(226, 232, 240);
        private static readonly Color MauHoverDong = Color.FromArgb(13, 71, 161);
        private static readonly Color MauBinhThuongDong = Color.FromArgb(21, 101, 192);

        public event Action OnYeuCauDong;

        public frmGioiThieu()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            // Vẽ viền thanh lịch 1px cho các khối panel card
            pnlThongTinDeTai.Paint += (s, e) => VeVien(e.Graphics, pnlThongTinDeTai);
            pnlDanhSachNhom.Paint += (s, e) => VeVien(e.Graphics, pnlDanhSachNhom);
            pnlKhungGiangVien.Paint += (s, e) => VeVien(e.Graphics, pnlKhungGiangVien);

            pnlThanhVien1.Paint += (s, e) => VeVien(e.Graphics, pnlThanhVien1);
            pnlThanhVien2.Paint += (s, e) => VeVien(e.Graphics, pnlThanhVien2);
            pnlThanhVien3.Paint += (s, e) => VeVien(e.Graphics, pnlThanhVien3);
            pnlThanhVien4.Paint += (s, e) => VeVien(e.Graphics, pnlThanhVien4);

            // Hover nút Đóng
            btnDongGioiThieu.MouseEnter += (s, e) => btnDongGioiThieu.BackColor = MauHoverDong;
            btnDongGioiThieu.MouseLeave += (s, e) => btnDongGioiThieu.BackColor = MauBinhThuongDong;

            // Xử lý sự kiện đóng form
            btnDongGioiThieu.Click += (s, e) =>
            {
                OnYeuCauDong?.Invoke();
                Close();
            };
        }

        private static void VeVien(Graphics g, Panel p)
        {
            using (var pen = new Pen(MauVienCard, 1))
            {
                g.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
            }
        }
    }
}
