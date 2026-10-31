using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NghiepVu;
using NghiepVu.TienIch;

namespace LTWIN_N05_QLCT.Forms.HeThong
{
    public partial class frmDangKy : Form
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
        private bool _loiHoTen;
        private bool _loiTenDangNhap;
        private bool _loiEmail;
        private bool _loiMatKhau;
        private bool _loiNhapLaiMatKhau;

        private int _doManh = 0; // 0..4

        public frmDangKy()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            AcceptButton = btnDangKy;
            CancelButton = btnHuy;
            DatIconForm();

            // Dòng thông báo lỗi / hướng dẫn, đặt dưới ô Nhập lại mật khẩu
            lblThongBao = new Label
            {
                AutoSize = false,
                Font = new Font("Segoe UI", 9F),
                ForeColor = MauDo,
                Location = new Point(0, 380),
                Size = new Size(424, 26),
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlThongTinDangKy.Controls.Add(lblThongBao);

            // Giao diện nút Hủy
            btnHuy.FlatAppearance.BorderSize = 1;
            btnHuy.FlatAppearance.BorderColor = MauVien;

            // Ẩn progress bar mặc định để vẽ thanh phẳng sắc nét theo Figma
            prgDoManhMatKhau.Visible = false;
            pnlDoManhMatKhau.Paint += PnlDoManhMatKhau_Paint;

            // Viền nhẹ cho thẻ đăng ký
            pnlDangKy.Paint += PnlDangKy_Paint;

            // Gắn sự kiện
            Load += frmDangKy_Load;
            btnDangKy.Click += (s, e) => ThucHienDangKy();
            btnHuy.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            btnHienMatKhau.Click += btnHienMatKhau_Click;
            btnHienNhapLaiMatKhau.Click += btnHienNhapLaiMatKhau_Click;
            btnThuNho.Click += (s, e) => WindowState = FormWindowState.Minimized;
            btnPhongTo.Click += btnPhongTo_Click;
            btnDong.Click += (s, e) => { DialogResult = DialogResult.Cancel; Close(); };
            pnlBieuMau.Resize += (s, e) => CanGiuaThe();

            // Vẽ viền các ô nhập: xám, xanh khi có focus, đỏ khi có lỗi
            pnlBorderHoTen.Paint += VeVien;
            pnlBorderTenDangNhap.Paint += VeVien;
            pnlBorderEmail.Paint += VeVien;
            pnlBorderMatKhau.Paint += VeVien;
            pnlBorderNhapLaiMatKhau.Paint += VeVien;

            GanVien(txtHoTen, pnlBorderHoTen);
            GanVien(txtTenDangNhap, pnlBorderTenDangNhap);
            GanVien(txtEmail, pnlBorderEmail);
            GanVien(txtMatKhau, pnlBorderMatKhau);
            GanVien(btnHienMatKhau, pnlBorderMatKhau);
            GanVien(txtNhapLaiMatKhau, pnlBorderNhapLaiMatKhau);
            GanVien(btnHienNhapLaiMatKhau, pnlBorderNhapLaiMatKhau);

            txtHoTen.TextChanged += (s, e) => XoaLoi();
            txtTenDangNhap.TextChanged += (s, e) => XoaLoi();
            txtEmail.TextChanged += (s, e) => XoaLoi();
            txtMatKhau.TextChanged += (s, e) =>
            {
                XoaLoi();
                CapNhatDoManhMatKhau();
            };
            txtNhapLaiMatKhau.TextChanged += (s, e) => XoaLoi();

            // Kéo thả cửa sổ
            foreach (Control c in new Control[] { pnlThanhTieuDe, lblTieuDeCuaSo, picTieuDeIcon, pnlGioiThieu, lblTenUngDung, lblKhauHieu, picLogo })
            {
                c.MouseDown += KeoCuaSo;
            }
        }

        private void frmDangKy_Load(object sender, EventArgs e)
        {
            // Bỏ giá trị mẫu trong thiết kế
            txtHoTen.Text = string.Empty;
            txtTenDangNhap.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
            txtNhapLaiMatKhau.Text = string.Empty;

            CapNhatDoManhMatKhau();
            txtHoTen.Focus();
            CanGiuaThe();
        }

        // ---------------- Đăng ký ----------------
        private void ThucHienDangKy()
        {
            XoaLoi();

            string hoTen = txtHoTen.Text.Trim();
            string ten = txtTenDangNhap.Text.Trim();
            string email = txtEmail.Text.Trim();
            string matKhau = txtMatKhau.Text;
            string nhapLai = txtNhapLaiMatKhau.Text;

            if (hoTen.Length == 0)
            {
                DatLoi("Vui lòng nhập họ và tên.", true, false, false, false, false);
                txtHoTen.Focus();
                return;
            }

            if (ten.Length == 0)
            {
                DatLoi("Vui lòng nhập tên đăng nhập.", false, true, false, false, false);
                txtTenDangNhap.Focus();
                return;
            }

            if (ten.Length < 3)
            {
                DatLoi("Tên đăng nhập phải có ít nhất 3 ký tự.", false, true, false, false, false);
                txtTenDangNhap.Focus();
                return;
            }

            if (!Regex.IsMatch(ten, @"^[a-zA-Z0-9_.]+$"))
            {
                DatLoi("Tên đăng nhập chỉ gồm chữ cái không dấu, số, dấu gạch dưới hoặc chấm.", false, true, false, false, false);
                txtTenDangNhap.Focus();
                return;
            }

            if (email.Length > 0 && !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                DatLoi("Định dạng email không hợp lệ.", false, false, true, false, false);
                txtEmail.Focus();
                return;
            }

            if (matKhau.Length == 0)
            {
                DatLoi("Vui lòng nhập mật khẩu.", false, false, false, true, false);
                txtMatKhau.Focus();
                return;
            }

            // Kiểm tra quy tắc nghiệp vụ BR08: tối thiểu 8 ký tự, cả chữ và số
            if (!BaoMat.KiemTraDoManhMatKhau(matKhau, out string loiMatKhau))
            {
                DatLoi(loiMatKhau, false, false, false, true, false);
                txtMatKhau.Focus();
                return;
            }

            if (nhapLai.Length == 0)
            {
                DatLoi("Vui lòng nhập lại mật khẩu xác nhận.", false, false, false, false, true);
                txtNhapLaiMatKhau.Focus();
                return;
            }

            if (matKhau != nhapLai)
            {
                DatLoi("Mật khẩu xác nhận không khớp.", false, false, false, false, true);
                txtNhapLaiMatKhau.Focus();
                return;
            }

            btnDangKy.Enabled = false;
            btnHuy.Enabled = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                string thongBao;
                if (!GoiDangKy(hoTen, ten, email, matKhau, out thongBao))
                {
                    // Phân loại đúng ô cần bôi đỏ theo thông điệp lỗi thực tế
                    bool loiTen = thongBao != null && (thongBao.IndexOf("tên đăng nhập", StringComparison.OrdinalIgnoreCase) >= 0);
                    bool loiMK = thongBao != null && (thongBao.IndexOf("mật khẩu", StringComparison.OrdinalIgnoreCase) >= 0);
                    bool loiMail = thongBao != null && (thongBao.IndexOf("email", StringComparison.OrdinalIgnoreCase) >= 0);

                    if (!loiTen && !loiMK && !loiMail) loiTen = true; // Mặc định nếu không rõ

                    DatLoi(thongBao, false, loiTen, loiMail, loiMK, false);

                    if (loiTen) txtTenDangNhap.Focus();
                    else if (loiMK) txtMatKhau.Focus();
                    else if (loiMail) txtEmail.Focus();
                    return;
                }

                MessageBox.Show(string.IsNullOrEmpty(thongBao) ? "Đăng ký tài khoản thành công!" : thongBao,
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            finally
            {
                Cursor = Cursors.Default;
                btnDangKy.Enabled = true;
                btnHuy.Enabled = true;
            }
        }

        // Chỗ DUY NHẤT gọi lớp nghiệp vụ. Nếu TaiKhoanNV của bạn khác, chỉ sửa hàm này.
        private static bool GoiDangKy(string hoTen, string ten, string email, string matKhau, out string thongBao)
        {
            var kq = TaiKhoanNV.DangKy(hoTen, ten, email, matKhau);
            thongBao = kq.ThongBao;
            return kq.ThanhCong;
        }

        // ---------------- Đánh giá độ mạnh mật khẩu theo BR08 ----------------
        private void CapNhatDoManhMatKhau()
        {
            string pass = txtMatKhau.Text;
            if (string.IsNullOrEmpty(pass))
            {
                _doManh = 0;
                lblDoManhMatKhau.Text = "Độ mạnh: Tối thiểu 8 ký tự, gồm cả chữ và số (BR08).";
                lblDoManhMatKhau.ForeColor = Color.FromArgb(100, 116, 139);
            }
            else
            {
                int diem = 0;
                if (pass.Length >= 8) diem++;
                if (Regex.IsMatch(pass, @"[a-zA-Z]") && Regex.IsMatch(pass, @"[0-9]")) diem++;
                if (pass.Length >= 10 && Regex.IsMatch(pass, @"[A-Z]") && Regex.IsMatch(pass, @"[a-z]")) diem++;
                if (Regex.IsMatch(pass, @"[^a-zA-Z0-9]")) diem++;

                if (diem < 1) diem = 1;
                _doManh = diem;

                switch (_doManh)
                {
                    case 1:
                        lblDoManhMatKhau.Text = "Yếu — cần tối thiểu 8 ký tự gồm cả chữ và số.";
                        lblDoManhMatKhau.ForeColor = MauDo;
                        break;
                    case 2:
                        lblDoManhMatKhau.Text = "Trung bình — nên kết hợp thêm chữ hoa.";
                        lblDoManhMatKhau.ForeColor = Color.FromArgb(217, 119, 6);
                        break;
                    case 3:
                        lblDoManhMatKhau.Text = "Khá mạnh — thêm ký tự đặc biệt để an toàn hơn.";
                        lblDoManhMatKhau.ForeColor = Color.FromArgb(100, 116, 139);
                        break;
                    case 4:
                        lblDoManhMatKhau.Text = "Rất mạnh — mật khẩu bảo mật tối ưu.";
                        lblDoManhMatKhau.ForeColor = Color.FromArgb(16, 185, 129);
                        break;
                }
            }

            pnlDoManhMatKhau.Invalidate();
        }

        private void PnlDoManhMatKhau_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int totalWidth = pnlDoManhMatKhau.Width;
            int barHeight = 4;
            int gap = 6;
            const int segmentCount = 4;
            int segmentWidth = (totalWidth - (gap * (segmentCount - 1))) / segmentCount;

            Color inactiveColor = Color.FromArgb(226, 232, 240);
            Color activeColor = MauXanh;
            if (_doManh == 1) activeColor = MauDo;
            else if (_doManh == 2) activeColor = Color.FromArgb(245, 158, 11);
            else if (_doManh == 4) activeColor = Color.FromArgb(16, 185, 129);

            for (int i = 0; i < segmentCount; i++)
            {
                int x = i * (segmentWidth + gap);
                Rectangle segRect = new Rectangle(x, 2, segmentWidth, barHeight);
                Color segColor = (i < _doManh) ? activeColor : inactiveColor;

                using (var brush = new SolidBrush(segColor))
                {
                    g.FillRectangle(brush, segRect);
                }
            }
        }

        // ---------------- Các nút khác ----------------
        private void btnHienMatKhau_Click(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = !txtMatKhau.UseSystemPasswordChar;
            txtMatKhau.Focus();
        }

        private void btnHienNhapLaiMatKhau_Click(object sender, EventArgs e)
        {
            txtNhapLaiMatKhau.UseSystemPasswordChar = !txtNhapLaiMatKhau.UseSystemPasswordChar;
            txtNhapLaiMatKhau.Focus();
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
            if (pnlDangKy == null || pnlBieuMau == null) return;
            int w = pnlBieuMau.ClientSize.Width;
            int h = pnlBieuMau.ClientSize.Height;

            pnlDangKy.Left = Math.Max(0, (w - pnlDangKy.Width) / 2);
            pnlDangKy.Top = Math.Max(10, (h - pnlDangKy.Height - 40) / 2);

            if (lblPhienBan != null)
            {
                lblPhienBan.Left = Math.Max(0, (w - lblPhienBan.Width) / 2);
                lblPhienBan.Top = h - 45;
            }
        }

        private void XoaLoi()
        {
            DatLoi(null, false, false, false, false, false);
        }

        private void DatLoi(string thongBao, bool loiHoTen, bool loiTen, bool loiEmail, bool loiMatKhau, bool loiNhapLai)
        {
            lblThongBao.Text = thongBao ?? string.Empty;
            _loiHoTen = loiHoTen;
            _loiTenDangNhap = loiTen;
            _loiEmail = loiEmail;
            _loiMatKhau = loiMatKhau;
            _loiNhapLaiMatKhau = loiNhapLai;

            pnlBorderHoTen.Invalidate();
            pnlBorderTenDangNhap.Invalidate();
            pnlBorderEmail.Invalidate();
            pnlBorderMatKhau.Invalidate();
            pnlBorderNhapLaiMatKhau.Invalidate();
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

            if (pnl == pnlBorderHoTen)
            {
                coLoi = _loiHoTen;
                coFocus = txtHoTen.Focused;
            }
            else if (pnl == pnlBorderTenDangNhap)
            {
                coLoi = _loiTenDangNhap;
                coFocus = txtTenDangNhap.Focused;
            }
            else if (pnl == pnlBorderEmail)
            {
                coLoi = _loiEmail;
                coFocus = txtEmail.Focused;
            }
            else if (pnl == pnlBorderMatKhau)
            {
                coLoi = _loiMatKhau;
                coFocus = txtMatKhau.Focused || btnHienMatKhau.Focused;
            }
            else if (pnl == pnlBorderNhapLaiMatKhau)
            {
                coLoi = _loiNhapLaiMatKhau;
                coFocus = txtNhapLaiMatKhau.Focused || btnHienNhapLaiMatKhau.Focused;
            }

            Color mau = coLoi ? MauDo : (coFocus ? MauXanh : MauVien);
            using (var pen = new Pen(mau, 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, pnl.Width - 1, pnl.Height - 1);
            }
        }

        private void PnlDangKy_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, pnlDangKy.Width - 1, pnlDangKy.Height - 1);
            }
        }

        // Icon cho form (đồng nhất với frmDangNhap)
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
                // thiếu icon không được làm hỏng đăng ký
            }
        }
    }
}
