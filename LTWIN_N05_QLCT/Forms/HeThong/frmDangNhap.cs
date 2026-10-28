using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LTWIN_N05_QLCT.Forms.HeThong
{
    public partial class frmDangNhap : Form
    {
        // Win32 API hỗ trợ kéo di chuyển form không viền
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        private readonly Color _mauChuDao = Color.FromArgb(21, 101, 192); // #1565C0 - Royal Blue hiện đại
        private readonly Color _mauVienNhe = Color.FromArgb(226, 232, 240); // #E2E8F0
        private readonly Color _mauVienInput = Color.FromArgb(203, 213, 225); // #CBD5E1

        private bool _hienMatKhau = false;
        private bool _isTenDangNhapFocused = false;
        private bool _isMatKhauFocused = false;
        private bool _isDangNhapHovered = false;
        private bool _isDangKyHovered = false;

        public frmDangNhap()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                           ControlStyles.AllPaintingInWmPaint |
                           ControlStyles.UserPaint, true);

            KhoiTaoGiaoDien();
        }

        private void KhoiTaoGiaoDien()
        {
            // Cài đặt icon tiêu đề và icon ứng dụng từ Resources
            try
            {
                if (Properties.Resources.icoViTien_Trang != null)
                {
                    picTieuDeIcon.Image = Properties.Resources.icoViTien_Trang;
                    this.Icon = Icon.FromHandle(Properties.Resources.icoViTien_Trang.GetHicon());
                }
            }
            catch { }

            // Tự động căn giữa thẻ đăng nhập
            pnlKhuVucPhai.Resize += (s, e) => CanGiuaTheDangNhap();
            this.Load += (s, e) => CanGiuaTheDangNhap();

            // Kéo form bằng chuột trên thanh tiêu đề
            pnlThanhTieuDe.MouseDown += Form_MouseDown;
            lblQuanLyChiTieuDangNhap.MouseDown += Form_MouseDown;
            picTieuDeIcon.MouseDown += Form_MouseDown;

            // Nút điều khiển cửa sổ
            btnDong.Click += (s, e) => Application.Exit();
            btnThuNho.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            btnPhongTo.Click += (s, e) =>
            {
                this.WindowState = (this.WindowState == FormWindowState.Maximized)
                    ? FormWindowState.Normal
                    : FormWindowState.Maximized;
            };

            // Hiệu ứng hover nút cửa sổ
            btnDong.MouseEnter += (s, e) => { btnDong.BackColor = Color.FromArgb(232, 17, 35); };
            btnDong.MouseLeave += (s, e) => { btnDong.BackColor = Color.White; };

            btnThuNho.MouseEnter += (s, e) => { btnThuNho.BackColor = Color.FromArgb(241, 245, 249); };
            btnThuNho.MouseLeave += (s, e) => { btnThuNho.BackColor = Color.White; };

            btnPhongTo.MouseEnter += (s, e) => { btnPhongTo.BackColor = Color.FromArgb(241, 245, 249); };
            btnPhongTo.MouseLeave += (s, e) => { btnPhongTo.BackColor = Color.White; };

            // Focus viền input
            txtTenDangNhap.GotFocus += (s, e) => { _isTenDangNhapFocused = true; pnlBorderTenDangNhap.Invalidate(); };
            txtTenDangNhap.LostFocus += (s, e) => { _isTenDangNhapFocused = false; pnlBorderTenDangNhap.Invalidate(); };

            txtMatKhau.GotFocus += (s, e) => { _isMatKhauFocused = true; pnlBorderMatKhau.Invalidate(); };
            txtMatKhau.LostFocus += (s, e) => { _isMatKhauFocused = false; pnlBorderMatKhau.Invalidate(); };

            // Vẽ viền và card
            pnlTheDangNhap.Paint += PnlTheDangNhap_Paint;
            pnlBorderTenDangNhap.Paint += PnlBorderTenDangNhap_Paint;
            pnlBorderMatKhau.Paint += PnlBorderMatKhau_Paint;

            // Logo chiếc ví bên trái
            picLogo.Paint += PicLogo_Paint;

            // Nút ẩn/hiện mật khẩu
            btnHienMatKhau.Click += BtnHienMatKhau_Click;

            // Custom CheckBox phẳng hiện đại
            chkGhiNho.Paint += ChkGhiNho_Paint;
            chkGhiNho.CheckedChanged += (s, e) => chkGhiNho.Invalidate();

            // Nút Đăng nhập
            btnDangNhap.Paint += BtnDangNhap_Paint;
            btnDangNhap.MouseEnter += (s, e) => { _isDangNhapHovered = true; btnDangNhap.Invalidate(); };
            btnDangNhap.MouseLeave += (s, e) => { _isDangNhapHovered = false; btnDangNhap.Invalidate(); };

            // Nút Đăng ký
            btnDangKy.Paint += BtnDangKy_Paint;
            btnDangKy.MouseEnter += (s, e) => { _isDangKyHovered = true; btnDangKy.Invalidate(); };
            btnDangKy.MouseLeave += (s, e) => { _isDangKyHovered = false; btnDangKy.Invalidate(); };
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void CanGiuaTheDangNhap()
        {
            if (pnlTheDangNhap == null || pnlKhuVucPhai == null) return;

            int left = (pnlKhuVucPhai.ClientSize.Width - pnlTheDangNhap.Width) / 2;
            int top = (pnlKhuVucPhai.ClientSize.Height - pnlTheDangNhap.Height - 35) / 2;

            if (left < 20) left = 20;
            if (top < 15) top = 15;

            pnlTheDangNhap.Location = new Point(left, top);

            if (lblQuanLyChiTieuPhienBan != null)
            {
                lblQuanLyChiTieuPhienBan.Left = pnlTheDangNhap.Left + (pnlTheDangNhap.Width - lblQuanLyChiTieuPhienBan.Width) / 2;
                lblQuanLyChiTieuPhienBan.Top = pnlTheDangNhap.Bottom + 22;
            }
        }

        private void BtnHienMatKhau_Click(object sender, EventArgs e)
        {
            _hienMatKhau = !_hienMatKhau;
            txtMatKhau.UseSystemPasswordChar = !_hienMatKhau;
        }

        #region Vẽ đồ họa GDI+ chuẩn thiết kế

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        // Vẽ thẻ đăng nhập bo góc 12px viền #E2E8F0
        private void PnlTheDangNhap_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, pnlTheDangNhap.Width - 1, pnlTheDangNhap.Height - 1);
            using (GraphicsPath path = GetRoundedPath(rect, 12))
            {
                using (Pen pen = new Pen(_mauVienNhe, 1f))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        // Viền input tên đăng nhập
        private void PnlBorderTenDangNhap_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, pnlBorderTenDangNhap.Width - 1, pnlBorderTenDangNhap.Height - 1);
            Color borderColor = _isTenDangNhapFocused ? _mauChuDao : _mauVienInput;
            float borderWidth = _isTenDangNhapFocused ? 1.5f : 1f;

            using (GraphicsPath path = GetRoundedPath(rect, 7))
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        // Viền input mật khẩu
        private void PnlBorderMatKhau_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, pnlBorderMatKhau.Width - 1, pnlBorderMatKhau.Height - 1);
            Color borderColor = _isMatKhauFocused ? _mauChuDao : _mauVienInput;
            float borderWidth = _isMatKhauFocused ? 1.5f : 1f;

            using (GraphicsPath path = GetRoundedPath(rect, 7))
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }

        // Vẽ CheckBox hiện đại phẳng màu xanh có tick trắng
        private void ChkGhiNho_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Xóa nền
            using (SolidBrush bgBrush = new SolidBrush(chkGhiNho.BackColor))
            {
                g.FillRectangle(bgBrush, chkGhiNho.ClientRectangle);
            }

            Rectangle boxRect = new Rectangle(1, 2, 16, 16);
            using (GraphicsPath path = GetRoundedPath(boxRect, 3))
            {
                if (chkGhiNho.Checked)
                {
                    using (SolidBrush fillBrush = new SolidBrush(_mauChuDao))
                    {
                        g.FillPath(fillBrush, path);
                    }

                    // Dấu tick màu trắng
                    using (Pen checkPen = new Pen(Color.White, 2f))
                    {
                        checkPen.StartCap = LineCap.Round;
                        checkPen.EndCap = LineCap.Round;
                        g.DrawLine(checkPen, 4.5f, 10f, 7.5f, 13f);
                        g.DrawLine(checkPen, 7.5f, 13f, 13.5f, 6.5f);
                    }
                }
                else
                {
                    using (SolidBrush whiteBrush = new SolidBrush(Color.White))
                    {
                        g.FillPath(whiteBrush, path);
                    }
                    using (Pen borderPen = new Pen(_mauVienInput, 1.2f))
                    {
                        g.DrawPath(borderPen, path);
                    }
                }
            }

            // Vẽ chữ "Ghi nhớ đăng nhập"
            using (SolidBrush textBrush = new SolidBrush(chkGhiNho.ForeColor))
            {
                g.DrawString(chkGhiNho.Text, chkGhiNho.Font, textBrush, 24, 2);
            }
        }

        // Nút Đăng nhập
        private void BtnDangNhap_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color bgColor = _isDangNhapHovered ? Color.FromArgb(13, 71, 161) : _mauChuDao;
            Rectangle rect = new Rectangle(0, 0, btnDangNhap.Width, btnDangNhap.Height);

            using (GraphicsPath path = GetRoundedPath(rect, 6))
            {
                btnDangNhap.Region = new Region(path);
                using (SolidBrush brush = new SolidBrush(bgColor))
                {
                    g.FillPath(brush, path);
                }
            }

            // Vẽ text nút
            TextRenderer.DrawText(g, btnDangNhap.Text, btnDangNhap.Font, rect, Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        // Nút Đăng ký
        private void BtnDangKy_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color bgColor = _isDangKyHovered ? Color.FromArgb(240, 246, 255) : Color.White;
            Rectangle rect = new Rectangle(0, 0, btnDangKy.Width, btnDangKy.Height);
            Rectangle borderRect = new Rectangle(0, 0, btnDangKy.Width - 1, btnDangKy.Height - 1);

            using (GraphicsPath path = GetRoundedPath(rect, 6))
            using (GraphicsPath borderPath = GetRoundedPath(borderRect, 6))
            {
                btnDangKy.Region = new Region(path);

                using (SolidBrush brush = new SolidBrush(bgColor))
                {
                    g.FillPath(brush, path);
                }

                using (Pen pen = new Pen(_mauChuDao, 1.2f))
                {
                    g.DrawPath(pen, borderPath);
                }
            }

            // Vẽ text nút
            TextRenderer.DrawText(g, btnDangKy.Text, btnDangKy.Font, rect, _mauChuDao,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        // Vẽ logo Ví tiền lớn bên trái với hiệu ứng badge mờ
        private void PicLogo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle badgeRect = new Rectangle(0, 0, 46, 46);
            using (GraphicsPath badgePath = GetRoundedPath(badgeRect, 10))
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(40, 255, 255, 255)))
                {
                    g.FillPath(brush, badgePath);
                }
                using (Pen pen = new Pen(Color.FromArgb(80, 255, 255, 255), 1.2f))
                {
                    g.DrawPath(pen, badgePath);
                }
            }

            // Sử dụng icoViTien_Trang từ Resources
            if (Properties.Resources.icoViTien_Trang != null)
            {
                g.DrawImage(Properties.Resources.icoViTien_Trang, 11, 11, 24, 24);
            }
        }

        #endregion
    }
}
