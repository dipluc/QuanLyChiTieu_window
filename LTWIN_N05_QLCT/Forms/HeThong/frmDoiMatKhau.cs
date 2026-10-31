using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NghiepVu;
using NghiepVu.TienIch;

namespace LTWIN_N05_QLCT.Forms.HeThong
{
    public partial class frmDoiMatKhau : Form
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

        private Label lblThongBao;
        private bool _loiMatKhauCu;
        private bool _loiMatKhauMoi;
        private bool _loiXacNhanMatKhau;

        private string _tenDangNhap = "minhanh";
        private string _hoTen = "Nguyễn Minh Anh";

        public frmDoiMatKhau() : this("minhanh", "Nguyễn Minh Anh")
        {
        }

        public frmDoiMatKhau(string tenDangNhap, string hoTen)
        {
            InitializeComponent();
            _tenDangNhap = string.IsNullOrEmpty(tenDangNhap) ? "minhanh" : tenDangNhap;
            _hoTen = string.IsNullOrEmpty(hoTen) ? "Nguyễn Minh Anh" : hoTen;
            KhoiTao();
        }

        private void KhoiTao()
        {
            AcceptButton = btnDoiMatKhau;
            CancelButton = btnHuy;
            DatIconForm();

            // Hiển thị thông tin tài khoản đang đổi mật khẩu
            lblTaiKhoan.Text = string.Format("Tài khoản: {0} — {1}", _tenDangNhap, _hoTen);

            // Dòng báo lỗi đặt phía trên các nút
            lblThongBao = new Label
            {
                AutoSize = false,
                Font = new Font("Segoe UI", 9F),
                ForeColor = MauDo,
                Location = new Point(37, 362),
                Size = new Size(424, 30),
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlDoiMatKhau.Controls.Add(lblThongBao);

            // Nút Hủy có viền xám nhẹ
            btnHuy.FlatAppearance.BorderSize = 1;
            btnHuy.FlatAppearance.BorderColor = MauVien;

            // Viền nhẹ cho thẻ card
            pnlDoiMatKhau.Paint += PnlDoiMatKhau_Paint;

            // Gắn sự kiện
            Load += frmDoiMatKhau_Load;
            btnDoiMatKhau.Click += (s, e) => ThucHienDoiMatKhau();
            btnHuy.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            btnHienMatKhauCu.Click += btnHienMatKhauCu_Click;
            btnHienMatKhauMoi.Click += btnHienMatKhauMoi_Click;
            btnHienXacNhanMatKhau.Click += btnHienXacNhanMatKhau_Click;
            btnThuNho.Click += (s, e) => WindowState = FormWindowState.Minimized;
            btnPhongTo.Click += btnPhongTo_Click;
            btnDong.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            pnlBieuMau.Resize += (s, e) => CanGiuaThe();

            // Vẽ viền các ô nhập: xám, xanh khi có focus, đỏ khi có lỗi
            pnlBorderMatKhauCu.Paint += VeVien;
            pnlBorderMatKhauMoi.Paint += VeVien;
            pnlBorderXacNhanMatKhau.Paint += VeVien;

            GanVien(txtMatKhauCu, pnlBorderMatKhauCu);
            GanVien(btnHienMatKhauCu, pnlBorderMatKhauCu);
            GanVien(txtMatKhauMoi, pnlBorderMatKhauMoi);
            GanVien(btnHienMatKhauMoi, pnlBorderMatKhauMoi);
            GanVien(txtXacNhanMatKhau, pnlBorderXacNhanMatKhau);
            GanVien(btnHienXacNhanMatKhau, pnlBorderXacNhanMatKhau);

            txtMatKhauCu.TextChanged += (s, e) => XoaLoi();
            txtMatKhauMoi.TextChanged += (s, e) => XoaLoi();
            txtXacNhanMatKhau.TextChanged += (s, e) => XoaLoi();

            // Kéo thả cửa sổ
            foreach (Control c in new Control[] { pnlThanhTieuDe, lblTieuDeCuaSo, picTieuDeIcon, pnlGioiThieu, lblTenUngDung, lblKhauHieu, picLogo })
            {
                c.MouseDown += KeoCuaSo;
            }
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            // Bỏ giá trị mẫu trong thiết kế
            txtMatKhauCu.Text = string.Empty;
            txtMatKhauMoi.Text = string.Empty;
            txtXacNhanMatKhau.Text = string.Empty;

            txtMatKhauCu.Focus();
            CanGiuaThe();
        }

        // ---------------- Đổi mật khẩu ----------------
        private void ThucHienDoiMatKhau()
        {
            XoaLoi();

            string cu = txtMatKhauCu.Text;
            string moi = txtMatKhauMoi.Text;
            string xacNhan = txtXacNhanMatKhau.Text;

            if (cu.Length == 0)
            {
                DatLoi("Vui lòng nhập mật khẩu hiện tại.", true, false, false);
                txtMatKhauCu.Focus();
                return;
            }

            if (moi.Length == 0)
            {
                DatLoi("Vui lòng nhập mật khẩu mới.", false, true, false);
                txtMatKhauMoi.Focus();
                return;
            }

            if (moi.Length < 8)
            {
                DatLoi("Mật khẩu mới phải có ít nhất 8 ký tự.", false, true, false);
                txtMatKhauMoi.Focus();
                return;
            }

            if (!Regex.IsMatch(moi, @"[A-Z]") || !Regex.IsMatch(moi, @"[a-z]") || !Regex.IsMatch(moi, @"[0-9]"))
            {
                DatLoi("Mật khẩu mới phải gồm chữ hoa, chữ thường và số.", false, true, false);
                txtMatKhauMoi.Focus();
                return;
            }

            if (moi == cu)
            {
                DatLoi("Mật khẩu mới không được trùng với mật khẩu cũ.", false, true, false);
                txtMatKhauMoi.Focus();
                return;
            }

            if (xacNhan.Length == 0)
            {
                DatLoi("Vui lòng nhập xác nhận mật khẩu mới.", false, false, true);
                txtXacNhanMatKhau.Focus();
                return;
            }

            if (moi != xacNhan)
            {
                DatLoi("Mật khẩu xác nhận không khớp.", false, false, true);
                txtXacNhanMatKhau.Focus();
                return;
            }

            btnDoiMatKhau.Enabled = false;
            btnHuy.Enabled = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                string thongBao;
                if (!GoiDoiMatKhau(_tenDangNhap, cu, moi, out thongBao))
                {
                    DatLoi(thongBao, true, false, false);
                    txtMatKhauCu.Focus();
                    return;
                }

                MessageBox.Show(string.IsNullOrEmpty(thongBao) ? "Đổi mật khẩu thành công!" : thongBao,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            finally
            {
                Cursor = Cursors.Default;
                btnDoiMatKhau.Enabled = true;
                btnHuy.Enabled = true;
            }
        }

        // Chỗ DUY NHẤT gọi lớp nghiệp vụ. Nếu TaiKhoanNV của bạn khác, chỉ sửa hàm này.
        private static bool GoiDoiMatKhau(string tenDangNhap, string cu, string moi, out string thongBao)
        {
            var kq = TaiKhoanNV.DoiMatKhau(tenDangNhap, cu, moi);
            thongBao = kq.ThongBao;
            return kq.ThanhCong;
        }

        // ---------------- Các nút khác ----------------
        private void btnHienMatKhauCu_Click(object sender, EventArgs e)
        {
            txtMatKhauCu.UseSystemPasswordChar = !txtMatKhauCu.UseSystemPasswordChar;
            txtMatKhauCu.Focus();
        }

        private void btnHienMatKhauMoi_Click(object sender, EventArgs e)
        {
            txtMatKhauMoi.UseSystemPasswordChar = !txtMatKhauMoi.UseSystemPasswordChar;
            txtMatKhauMoi.Focus();
        }

        private void btnHienXacNhanMatKhau_Click(object sender, EventArgs e)
        {
            txtXacNhanMatKhau.UseSystemPasswordChar = !txtXacNhanMatKhau.UseSystemPasswordChar;
            txtXacNhanMatKhau.Focus();
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
            if (pnlDoiMatKhau == null || pnlBieuMau == null) return;
            int w = pnlBieuMau.ClientSize.Width;
            int h = pnlBieuMau.ClientSize.Height;

            pnlDoiMatKhau.Left = Math.Max(0, (w - pnlDoiMatKhau.Width) / 2);
            pnlDoiMatKhau.Top = Math.Max(10, (h - pnlDoiMatKhau.Height - 40) / 2);

            if (lblPhienBan != null)
            {
                lblPhienBan.Left = Math.Max(0, (w - lblPhienBan.Width) / 2);
                lblPhienBan.Top = h - 45;
            }
        }

        private void XoaLoi()
        {
            DatLoi(null, false, false, false);
        }

        private void DatLoi(string thongBao, bool loiCu, bool loiMoi, bool loiXacNhan)
        {
            lblThongBao.Text = thongBao ?? string.Empty;
            _loiMatKhauCu = loiCu;
            _loiMatKhauMoi = loiMoi;
            _loiXacNhanMatKhau = loiXacNhan;

            pnlBorderMatKhauCu.Invalidate();
            pnlBorderMatKhauMoi.Invalidate();
            pnlBorderXacNhanMatKhau.Invalidate();
        }

        private void GanVien(Control o, Panel pnl)
        {
            o.Enter += (s, e) => pnl.Invalidate();
            o.Leave += (s, e) => pnl.Invalidate();
        }

        private void VeVien(object sender, PaintEventArgs e)
        {
            var pnl = (Panel)sender;
            bool coLoi = false;
            bool coFocus = false;

            if (pnl == pnlBorderMatKhauCu)
            {
                coLoi = _loiMatKhauCu;
                coFocus = txtMatKhauCu.Focused || btnHienMatKhauCu.Focused;
            }
            else if (pnl == pnlBorderMatKhauMoi)
            {
                coLoi = _loiMatKhauMoi;
                coFocus = txtMatKhauMoi.Focused || btnHienMatKhauMoi.Focused;
            }
            else if (pnl == pnlBorderXacNhanMatKhau)
            {
                coLoi = _loiXacNhanMatKhau;
                coFocus = txtXacNhanMatKhau.Focused || btnHienXacNhanMatKhau.Focused;
            }

            Color mau = coLoi ? MauDo : (coFocus ? MauXanh : MauVien);
            using (var pen = new Pen(mau, 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, pnl.Width - 1, pnl.Height - 1);
            }
        }

        private void PnlDoiMatKhau_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, pnlDoiMatKhau.Width - 1, pnlDoiMatKhau.Height - 1);
            }
        }

        // Icon cho form (đồng nhất với frmDangNhap & frmDangKy)
        private void DatIconForm()
        {
            try
            {
                using (var bmp = new Bitmap(
                    global::LTWIN_N05_QLCT.Properties.Resources.icoChiTieu_XanhDuong, new Size(32, 32)))
                {
                    Icon = Icon.FromHandle(bmp.GetHicon());
                }
                picTieuDeIcon.Image = global::LTWIN_N05_QLCT.Properties.Resources.icoViTien_XanhDuong;
            }
            catch
            {
                // thiếu icon không được làm hỏng chức năng
            }
        }
    }
}
