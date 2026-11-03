using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LTWIN_N05_QLCT.Forms.TroGiup
{
    public partial class frmGioiThieu : Form
    {
        private static readonly Color MauVienCard = Color.FromArgb(226, 232, 240);
        private static readonly Color MauVienBadge = Color.FromArgb(219, 234, 254);
        private static readonly Color MauVienItem = Color.FromArgb(241, 245, 249);
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
            // Viền 1px mỏng nhẹ cho 2 card chính
            pnlThongTinUngDung.Paint += (s, e) => VeVienPanel(e.Graphics, pnlThongTinUngDung, MauVienCard);
            pnlNhomThucHien.Paint += (s, e) => VeVienPanel(e.Graphics, pnlNhomThucHien, MauVienCard);

            // Viền card giảng viên
            pnlCardGiangVien.Paint += (s, e) => VeVienPanel(e.Graphics, pnlCardGiangVien, MauVienBadge);

            // Viền và bo góc cho các profile item thành viên
            pnlThanhVien1.Paint += (s, e) => VeVienPanel(e.Graphics, pnlThanhVien1, MauVienCard);
            pnlThanhVien2.Paint += (s, e) => VeVienPanel(e.Graphics, pnlThanhVien2, MauVienCard);
            pnlThanhVien3.Paint += (s, e) => VeVienPanel(e.Graphics, pnlThanhVien3, MauVienCard);
            pnlThanhVien4.Paint += (s, e) => VeVienPanel(e.Graphics, pnlThanhVien4, MauVienCard);

            // Bo tròn nhẹ cho logo app
            pnlLogoApp.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var path = TaoDuongDanBoGoc(new Rectangle(0, 0, pnlLogoApp.Width - 1, pnlLogoApp.Height - 1), 12))
                using (var brush = new SolidBrush(Color.FromArgb(21, 101, 192)))
                {
                    e.Graphics.FillPath(brush, path);
                }
            };

            // Viền badge phiên bản
            lblPhienBanBadge.Paint += (s, e) =>
            {
                using (var pen = new Pen(MauVienBadge, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, lblPhienBanBadge.Width - 1, lblPhienBanBadge.Height - 1);
                }
            };

            // Hover effect cho nút Đóng
            btnDongGioiThieu.MouseEnter += (s, e) => btnDongGioiThieu.BackColor = MauHoverDong;
            btnDongGioiThieu.MouseLeave += (s, e) => btnDongGioiThieu.BackColor = MauBinhThuongDong;

            // Xử lý sự kiện đóng form
            btnDongGioiThieu.Click += (s, e) =>
            {
                OnYeuCauDong?.Invoke();
                Close();
            };
        }

        private static void VeVienPanel(Graphics g, Panel p, Color mauVien)
        {
            using (var pen = new Pen(mauVien, 1))
            {
                g.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
            }
        }

        private static GraphicsPath TaoDuongDanBoGoc(Rectangle r, int banKinh)
        {
            int d = banKinh * 2;
            var path = new GraphicsPath();
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
