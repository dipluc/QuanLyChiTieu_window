using LTWIN_N05_QLCT.TienIch;
using NghiepVu;
using NghiepVu.TienIch;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LTWIN_N05_QLCT.Forms.HeThong
{
    public partial class frmDangNhap : Form
    {
        // Kéo cửa sổ bằng thanh tiêu đề tự vẽ (form không viền)
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        private static readonly Color MauXanh = Color.FromArgb(21, 101, 192);
        private static readonly Color MauDo = Color.FromArgb(198, 40, 40);
        private static readonly Color MauVien = Color.FromArgb(203, 213, 225);

        // Chỉ nhớ TÊN đăng nhập, không bao giờ lưu mật khẩu
        private static readonly string TepGhiNho = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "LTWIN_N05_QLCT", "tendangnhap.txt");

        private Label lblThongBao;
        private bool _loiTen;
        private bool _loiMatKhau;

        public string TenDangNhapDaNhap => txtTenDangNhap.Text.Trim();
        public string HoTenDaNhap { get; private set; }

        public frmDangNhap()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            AcceptButton = btnDangNhap;
            DatIconForm();

            // Dòng báo lỗi (thiết kế chưa có), đặt dưới ô mật khẩu
            lblThongBao = new Label
            {
                AutoSize = false,
                Font = new Font("Segoe UI", 9F),
                ForeColor = MauDo,
                Location = new Point(0, 224),
                Size = new Size(424, 22),
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlThongTinTaiKhoan.Controls.Add(lblThongBao);

            // Nút Đăng ký: viền xanh như thiết kế Figma
            btnDangKy.FlatAppearance.BorderSize = 1;
            btnDangKy.FlatAppearance.BorderColor = MauXanh;

            // Gắn sự kiện
            Load += frmDangNhap_Load;
            btnDangNhap.Click += (s, e) => ThucHienDangNhap();
            btnDangKy.Click += btnDangKy_Click;
            btnHienMatKhau.Click += btnHienMatKhau_Click;
            lnkQuenMatKhau.LinkClicked += lnkQuenMatKhau_LinkClicked;
            btnThuNho.Click += (s, e) => WindowState = FormWindowState.Minimized;
            btnPhongTo.Click += btnPhongTo_Click;
            btnDong.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            pnlKhuVucPhai.Resize += (s, e) => CanGiuaThe();

            // Vẽ viền 2 ô nhập: xám, xanh khi có focus, đỏ khi có lỗi
            pnlBorderTenDangNhap.Paint += VeVien;
            pnlBorderMatKhau.Paint += VeVien;
            GanVien(txtTenDangNhap, pnlBorderTenDangNhap);
            GanVien(txtMatKhau, pnlBorderMatKhau);
            GanVien(btnHienMatKhau, pnlBorderMatKhau);
            txtTenDangNhap.TextChanged += (s, e) => DatLoi(null, false, false);
            txtMatKhau.TextChanged += (s, e) => DatLoi(null, false, false);

            // Kéo thả cửa sổ
            foreach (Control c in new Control[] { pnlThanhTieuDe, lblQuanLyChiTieuDangNhap, picTieuDeIcon, pnlGioiThieuUngDung })
            {
                c.MouseDown += KeoCuaSo;
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            // Bỏ giá trị mẫu trong thiết kế
            txtTenDangNhap.Text = string.Empty;
            txtMatKhau.Text = string.Empty;

            string ten = DocTenGhiNho();
            if (!string.IsNullOrEmpty(ten))
            {
                txtTenDangNhap.Text = ten;
                txtMatKhau.Focus();
            }
            else
            {
                txtTenDangNhap.Focus();
            }
            CanGiuaThe();
        }

        // ---------------- Đăng nhập ----------------
        private void ThucHienDangNhap()
        {
            DatLoi(null, false, false);

            string ten = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;

            if (ten.Length == 0)
            {
                DatLoi("Vui lòng nhập tên đăng nhập.", true, false);
                txtTenDangNhap.Focus();
                return;
            }
            if (matKhau.Length == 0)
            {
                DatLoi("Vui lòng nhập mật khẩu.", false, true);
                txtMatKhau.Focus();
                return;
            }

            btnDangNhap.Enabled = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                var kq = TaiKhoanNV.DangNhap(ten, matKhau);
                if (!kq.ThanhCong)
                {
                    txtMatKhau.Clear();
                    DatLoi(kq.ThongBao, false, true);
                    txtMatKhau.Focus();
                    return;
                }

                HoTenDaNhap = !string.IsNullOrEmpty(kq.HoTen) ? kq.HoTen : ten;
                if (chkGhiNho.Checked)
                    GhiNhoDangNhap.Luu(ten);
                else
                    GhiNhoDangNhap.Xoa();
                DialogResult = DialogResult.OK; // Program.cs sẽ mở frmMain
                Close();
            }
            finally
            {
                Cursor = Cursors.Default;
                btnDangNhap.Enabled = true;
            }
        }

        // Chỗ DUY NHẤT gọi lớp nghiệp vụ. Nếu TaiKhoanNV của bạn khác, chỉ sửa hàm này.
        private static bool GoiDangNhap(string ten, string matKhau, out string thongBao)
        {
            var kq = TaiKhoanNV.DangNhap(ten, matKhau);
            thongBao = kq.ThongBao;
            return kq.ThanhCong;
        }

        // ---------------- Các nút khác ----------------
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            using (var f = new frmDangKy()) // form này phải tồn tại (rỗng cũng được)
            {
                f.ShowDialog(this);
            }
        }

        private void btnHienMatKhau_Click(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !txtMatKhau.UseSystemPasswordChar;
            txtMatKhau.Focus();
        }

        private void lnkQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ quản trị viên để được đặt lại mật khẩu.",
                "Quên mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPhongTo_Click(object sender, EventArgs e)
        {
            MaximizedBounds = Screen.FromControl(this).WorkingArea; // không che thanh taskbar
            WindowState = WindowState == FormWindowState.Maximized
                ? FormWindowState.Normal
                : FormWindowState.Maximized;
        }

        private void KeoCuaSo(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || WindowState == FormWindowState.Maximized) return;
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        // ---------------- Giao diện ----------------
        private void CanGiuaThe()
        {
            int w = pnlKhuVucPhai.ClientSize.Width;
            int h = pnlKhuVucPhai.ClientSize.Height;
            pnlTheDangNhap.Left = Math.Max(0, (w - pnlTheDangNhap.Width) / 2);
            pnlTheDangNhap.Top = Math.Max(10, (h - pnlTheDangNhap.Height - 40) / 2);
            lblQuanLyChiTieuPhienBan.Left = Math.Max(0, (w - lblQuanLyChiTieuPhienBan.Width) / 2);
            lblQuanLyChiTieuPhienBan.Top = h - 64;
        }

        private void DatLoi(string thongBao, bool loiTen, bool loiMatKhau)
        {
            lblThongBao.Text = thongBao ?? string.Empty;
            _loiTen = loiTen;
            _loiMatKhau = loiMatKhau;
            pnlBorderTenDangNhap.Invalidate();
            pnlBorderMatKhau.Invalidate();
        }

        private void GanVien(Control o, Panel pnl)
        {
            o.Enter += (s, e) => pnl.Invalidate();
            o.Leave += (s, e) => pnl.Invalidate();
        }

        private void VeVien(object sender, PaintEventArgs e)
        {
            var pnl = (Panel)sender;
            bool laTen = pnl == pnlBorderTenDangNhap;
            bool coLoi = laTen ? _loiTen : _loiMatKhau;
            bool coFocus = laTen ? txtTenDangNhap.Focused
                                 : (txtMatKhau.Focused || btnHienMatKhau.Focused);
            Color mau = coLoi ? MauDo : (coFocus ? MauXanh : MauVien);
            using (var pen = new Pen(mau, 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, pnl.Width - 1, pnl.Height - 1);
            }
        }

        // Icon cho form (giảng viên yêu cầu mọi form có icon)
        private void DatIconForm()
        {
            try
            {
                using (var bmp = new Bitmap(
                    global::LTWIN_N05_QLCT.Properties.Resources.icoChiTieu_XanhDuong, new Size(32, 32)))
                {
                    Icon = Icon.FromHandle(bmp.GetHicon());
                }
            }
            catch
            {
                // thiếu icon không được làm hỏng đăng nhập
            }
        }

        // ---------------- Ghi nhớ tên đăng nhập ----------------
        private static string DocTenGhiNho()
        {
            try
            {
                return File.Exists(TepGhiNho) ? File.ReadAllText(TepGhiNho).Trim() : null;
            }
            catch
            {
                return null;
            }
        }

        private static void GhiTenGhiNho(string ten)
        {
            try
            {
                if (string.IsNullOrEmpty(ten))
                {
                    if (File.Exists(TepGhiNho)) File.Delete(TepGhiNho);
                    return;
                }
                Directory.CreateDirectory(Path.GetDirectoryName(TepGhiNho));
                File.WriteAllText(TepGhiNho, ten);
            }
            catch
            {
                // ghi nhớ chỉ là tiện ích, bỏ qua lỗi
            }
        }
}

}