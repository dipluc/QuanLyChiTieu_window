using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LTWIN_N05_QLCT.Forms.Chinh;
using NghiepVu;
using NghiepVu.TienIch;

namespace LTWIN_N05_QLCT.Forms.HeThong
{
    public partial class frmThongTinCaNhan : Form
    {
        private static readonly Color MauXanh = Color.FromArgb(21, 101, 192);
        private static readonly Color MauDo = Color.FromArgb(198, 40, 40);
        private static readonly Color MauVien = Color.FromArgb(203, 213, 225);
        private static readonly Color MauVienCard = Color.FromArgb(226, 232, 240);
        private static readonly Color MauXanhLa = Color.FromArgb(46, 125, 50);

        private string _tenDangNhapGoc = "minhanh";
        private string _hoTenGoc = "Nguyễn Minh Anh";
        private string _emailGoc = "";

        public string HoTenMoi { get; private set; }
        public string EmailMoi { get; private set; }

        public event Action<string> OnThongTinDaCapNhat;
        public event Action<string, string> OnThongTinChiTietDaCapNhat;

        public frmThongTinCaNhan()
        {
            InitializeComponent();
            KhoiTao();
            TaiDuLieuTuHeThong();
        }

        public frmThongTinCaNhan(string tenDangNhap, string hoTen, string email = "") : this()
        {
            if (!string.IsNullOrEmpty(tenDangNhap)) _tenDangNhapGoc = tenDangNhap;
            if (!string.IsNullOrEmpty(hoTen)) _hoTenGoc = hoTen;
            if (!string.IsNullOrEmpty(email)) _emailGoc = email;

            txtTenDangNhap.Text = _tenDangNhapGoc;
            txtHoTen.Text = _hoTenGoc;
            txtEmail.Text = _emailGoc;
            HoTenMoi = _hoTenGoc;
            EmailMoi = _emailGoc;

            // Nếu chưa có email, nạp trực tiếp từ CSDL / Phiên đăng nhập
            if (string.IsNullOrEmpty(email))
            {
                TaiDuLieuTuHeThong();
            }
        }

        public void TaiDuLieuTuHeThong()
        {
            try
            {
                string tenDN = !string.IsNullOrWhiteSpace(_tenDangNhapGoc) ? _tenDangNhapGoc : PhienDangNhap.TenDangNhap;
                if (!string.IsNullOrWhiteSpace(tenDN))
                {
                    var user = TaiKhoanNV.LayThongTin(tenDN);
                    if (user != null && user.ThanhCong)
                    {
                        _tenDangNhapGoc = user.TenDangNhap;
                        _hoTenGoc = user.HoTen ?? "";
                        _emailGoc = user.Email ?? "";

                        txtTenDangNhap.Text = _tenDangNhapGoc;
                        txtHoTen.Text = _hoTenGoc;
                        txtEmail.Text = _emailGoc;
                        HoTenMoi = _hoTenGoc;
                        EmailMoi = _emailGoc;
                        return;
                    }
                }

                if (PhienDangNhap.DaDangNhap)
                {
                    if (!string.IsNullOrEmpty(PhienDangNhap.TenDangNhap)) _tenDangNhapGoc = PhienDangNhap.TenDangNhap;
                    if (!string.IsNullOrEmpty(PhienDangNhap.HoTen)) _hoTenGoc = PhienDangNhap.HoTen;
                    _emailGoc = PhienDangNhap.Email ?? "";

                    txtTenDangNhap.Text = _tenDangNhapGoc;
                    txtHoTen.Text = _hoTenGoc;
                    txtEmail.Text = _emailGoc;
                    HoTenMoi = _hoTenGoc;
                    EmailMoi = _emailGoc;
                }
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi nạp dữ liệu tại frmThongTinCaNhan.TaiDuLieuTuHeThong", ex);
            }
        }

        private void KhoiTao()
        {
            // Thiết lập giá trị mặc định
            txtTenDangNhap.Text = _tenDangNhapGoc;
            txtHoTen.Text = _hoTenGoc;
            txtEmail.Text = _emailGoc;
            HoTenMoi = _hoTenGoc;
            EmailMoi = _emailGoc;

            // Viền card thông tin cá nhân
            pnlThongTinCaNhan.Paint += (s, e) =>
            {
                using (var pen = new Pen(MauVienCard, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, pnlThongTinCaNhan.Width - 1, pnlThongTinCaNhan.Height - 1);
                }
            };

            // Viền ô tên đăng nhập (chỉ đọc)
            pnlBorderTenDangNhap.Paint += (s, e) =>
            {
                using (var pen = new Pen(MauVienCard, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, pnlBorderTenDangNhap.Width - 1, pnlBorderTenDangNhap.Height - 1);
                }
            };

            // Hiệu ứng viền focus cho Họ tên & Email
            GanVien(pnlBorderHoTen, txtHoTen);
            GanVien(pnlBorderEmail, txtEmail);

            // Nút bấm
            btnLuu.Click += (s, e) => XuLyLuu();
            btnHuy.Click += (s, e) => XuLyHuy();
            btnDoiMatKhau.Click += (s, e) => MoFormDoiMatKhau();
        }

        private void GanVien(Panel pnl, TextBox txt)
        {
            Color mauHienTai = MauVien;
            pnl.Paint += (s, e) =>
            {
                using (var pen = new Pen(mauHienTai, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, pnl.Width - 1, pnl.Height - 1);
                }
            };

            txt.Enter += (s, e) =>
            {
                mauHienTai = MauXanh;
                pnl.Invalidate();
            };

            txt.Leave += (s, e) =>
            {
                mauHienTai = MauVien;
                pnl.Invalidate();
            };
        }

        private void DatMauVienLoi(Panel pnl, bool coLoi)
        {
            using (var g = pnl.CreateGraphics())
            {
                using (var pen = new Pen(coLoi ? MauDo : MauVien, 1))
                {
                    g.DrawRectangle(pen, 0, 0, pnl.Width - 1, pnl.Height - 1);
                }
            }
        }

        private void XuLyLuu()
        {
            lblThongBao.Visible = false;
            string hoTen = txtHoTen.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Validate họ tên
            if (string.IsNullOrWhiteSpace(hoTen))
            {
                HienThongBao("Vui lòng nhập họ tên.", true);
                DatMauVienLoi(pnlBorderHoTen, true);
                txtHoTen.Focus();
                return;
            }

            // Validate email (nếu có nhập)
            if (!string.IsNullOrEmpty(email) && !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                HienThongBao("Email không đúng định dạng. Vui lòng kiểm tra lại.", true);
                DatMauVienLoi(pnlBorderEmail, true);
                txtEmail.Focus();
                return;
            }

            // Gọi BLL cập nhật thông tin
            string tenDN = !string.IsNullOrWhiteSpace(txtTenDangNhap.Text) ? txtTenDangNhap.Text.Trim() : _tenDangNhapGoc;
            var kq = TaiKhoanNV.CapNhatThongTin(tenDN, hoTen, email);
            if (kq.ThanhCong)
            {
                _hoTenGoc = hoTen;
                _emailGoc = email;
                HoTenMoi = hoTen;
                EmailMoi = email;

                HienThongBao("✓ Cập nhật thông tin cá nhân thành công!", false);
                pnlBorderHoTen.Invalidate();
                pnlBorderEmail.Invalidate();

                // Kích hoạt sự kiện thông báo cho frmMain
                OnThongTinDaCapNhat?.Invoke(hoTen);
                OnThongTinChiTietDaCapNhat?.Invoke(hoTen, email);

                // Cập nhật trực tiếp lên frmMain cha nếu form được nhúng
                var frmCha = FindForm() as frmMain ?? ParentForm as frmMain;
                if (frmCha != null)
                {
                    frmCha.CapNhatThongTinNguoiDung(hoTen, email);
                }
            }
            else
            {
                HienThongBao(kq.ThongBao, true);
                if (kq.ThongBao != null && kq.ThongBao.ToLower().Contains("email"))
                {
                    DatMauVienLoi(pnlBorderEmail, true);
                    txtEmail.Focus();
                }
            }
        }

        private void XuLyHuy()
        {
            txtHoTen.Text = _hoTenGoc;
            txtEmail.Text = _emailGoc;
            lblThongBao.Visible = false;
            pnlBorderHoTen.Invalidate();
            pnlBorderEmail.Invalidate();
        }

        private void HienThongBao(string thongDiep, bool laLoi)
        {
            lblThongBao.Text = thongDiep;
            lblThongBao.ForeColor = laLoi ? MauDo : MauXanhLa;
            lblThongBao.Visible = true;
        }

        private void MoFormDoiMatKhau()
        {
            using (var f = new frmDoiMatKhau(txtTenDangNhap.Text, txtHoTen.Text))
            {
                f.ShowDialog(this);
            }
        }
    }
}
