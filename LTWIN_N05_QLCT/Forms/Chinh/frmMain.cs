using LTWIN_N05_QLCT.Forms.HeThong;
using LTWIN_N05_QLCT.Services;
using LTWIN_N05_QLCT.TienIch;
using NghiepVu.TienIch;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LTWIN_N05_QLCT.Forms.Chinh
{
    public partial class frmMain : Form
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
        private static readonly Color MauDuongKe = Color.FromArgb(226, 232, 240);

        private string _tenDangNhap = "minhanh";
        private string _hoTen = "Nguyễn Minh Anh";
        private string _email = "";
        private string _viDangChon = "Vietcombank";

        public frmMain()
        {
            InitializeComponent();
            KhoiTao();
        }

        public frmMain(string tenDangNhap, string hoTen) : this()
        {
            if (!string.IsNullOrEmpty(tenDangNhap)) _tenDangNhap = tenDangNhap;
            if (!string.IsNullOrEmpty(hoTen)) _hoTen = hoTen;
            if (PhienDangNhap.DaDangNhap && !string.IsNullOrEmpty(PhienDangNhap.Email))
            {
                _email = PhienDangNhap.Email;
            }
            lblNguoiDung.Text = "Đăng nhập: " + _hoTen;
        }

        public frmMain(string tenDangNhap, string hoTen, string email) : this(tenDangNhap, hoTen)
        {
            if (!string.IsNullOrEmpty(email)) _email = email;
        }

        private void KhoiTao()
        {
            DatIconForm();

            // Tự động đồng bộ khi thông tin phiên đăng nhập thay đổi
            PhienDangNhap.ThongTinThayDoi += () =>
            {
                if (PhienDangNhap.DaDangNhap)
                {
                    _hoTen = PhienDangNhap.HoTen;
                    _tenDangNhap = PhienDangNhap.TenDangNhap;
                    _email = PhienDangNhap.Email;
                    lblNguoiDung.Text = "Đăng nhập: " + _hoTen;
                    lblNguoiDungHienTai.Text = _hoTen;
                }
            };

            // Icon chuẩn cho các nút thanh công cụ
            try
            {
                btnThuNhap.Image = new Bitmap(global::LTWIN_N05_QLCT.Properties.Resources.icoThemThuNhap_XanhDuong, new Size(18, 18));
                btnChiTieu.Image = new Bitmap(global::LTWIN_N05_QLCT.Properties.Resources.icoChiTieu_XanhDuong, new Size(18, 18));
                btnNganSach.Image = new Bitmap(global::LTWIN_N05_QLCT.Properties.Resources.icoViTien_XanhDuong, new Size(18, 18));
                btnBaoCao.Image = new Bitmap(global::LTWIN_N05_QLCT.Properties.Resources.icoBaoCao_XanhDuong, new Size(18, 18));
                btnTimKiem.Image = new Bitmap(global::LTWIN_N05_QLCT.Properties.Resources.icoTimKiem_XanhDuong, new Size(18, 18));
                btnLamMoi.Image = new Bitmap(global::LTWIN_N05_QLCT.Properties.Resources.icoLamMoi_XanhDuong, new Size(18, 18));
                picTieuDeIcon.Image = global::LTWIN_N05_QLCT.Properties.Resources.icoViTien_XanhDuong;
            }
            catch { }

            // Hiển thị ngày tháng hiện tại trên thanh trạng thái
            lblNgayHienTai.Text = "Hôm nay: " + DateTime.Now.ToString("dd/MM/yyyy");
            lblNguoiDung.Text = "Đăng nhập: " + _hoTen;
            lblViDangChon.Text = "Ví đang chọn: " + _viDangChon;

            // Gắn sự kiện cửa sổ
            btnDong.Click += (s, e) => XacNhanThoat();
            btnThuNho.Click += (s, e) => WindowState = FormWindowState.Minimized;
            btnPhongTo.Click += btnPhongTo_Click;

            // Kéo cửa sổ
            pnlThanhTieuDe.MouseDown += KeoCuaSo;
            lblTieuDeCuaSo.MouseDown += KeoCuaSo;
            picTieuDeIcon.MouseDown += KeoCuaSo;

            // Đường kẻ ngăn cách nhẹ bên dưới thanh tiêu đề & thanh công cụ
            pnlThanhTieuDe.Paint += (s, e) =>
            {
                using (var pen = new Pen(MauDuongKe, 1))
                {
                    e.Graphics.DrawLine(pen, 0, pnlThanhTieuDe.Height - 1, pnlThanhTieuDe.Width, pnlThanhTieuDe.Height - 1);
                }
            };

            tlsCongCu.Paint += (s, e) =>
            {
                using (var pen = new Pen(MauDuongKe, 1))
                {
                    e.Graphics.DrawLine(pen, 0, tlsCongCu.Height - 1, tlsCongCu.Width, tlsCongCu.Height - 1);
                }
            };

            stsTrangThai.Paint += (s, e) =>
            {
                using (var pen = new Pen(MauDuongKe, 1))
                {
                    e.Graphics.DrawLine(pen, 0, 0, stsTrangThai.Width, 0);
                }
            };

            // Sự kiện quay về Dashboard (click vào Logo / Tiêu đề / Menu Trang chủ)
            btnTrangChu.Click += (s, e) => { DatTrangThaiNutThanhCongCu(btnTrangChu); MoDashboard(); };
            picTieuDeIcon.Cursor = Cursors.Hand;
            lblTieuDeCuaSo.Cursor = Cursors.Hand;
            picTieuDeIcon.Click += (s, e) => MoDashboard();
            lblTieuDeCuaSo.Click += (s, e) => MoDashboard();

            // Menu hệ thống
            mnuDangNhap.Click += (s, e) => MoFormDangNhap();
            mnuDangKy.Click += (s, e) => MoFormDangKy();
            mnuDoiMatKhau.Click += (s, e) => MoFormDoiMatKhau();
            mnuThongTinCaNhan.Click += (s, e) => MoFormThongTinCaNhan();
            mnuDangXuat.Click += (s, e) => DangXuat();
            mnuThoat.Click += (s, e) => XacNhanThoat();

            // Nút công cụ nhanh trên Toolbar
            btnThuNhap.Click += (s, e) => { DatTrangThaiNutThanhCongCu(btnThuNhap); MoFormCon(new Forms.NghiepVu.frmQuanLyThuNhap(), "Quản lý thu nhập"); };
            btnChiTieu.Click += (s, e) => { DatTrangThaiNutThanhCongCu(btnChiTieu); MoFormCon(new Forms.NghiepVu.frmQuanLyChiTieu(), "Quản lý chi tiêu"); };
            btnNganSach.Click += (s, e) => { DatTrangThaiNutThanhCongCu(btnNganSach); MoFormCon(new Forms.NghiepVu.frmNganSach(), "Quản lý ngân sách"); };
            btnBaoCao.Click += (s, e) => { DatTrangThaiNutThanhCongCu(btnBaoCao); MoFormCon(new Forms.BaoCao.frmBieuDo(), "Báo cáo thống kê"); };
            btnTimKiem.Click += (s, e) => { DatTrangThaiNutThanhCongCu(btnTimKiem); MoFormCon(new Forms.NghiepVu.frmTimKiem(), "Tìm kiếm giao dịch"); };
            btnLamMoi.Click += (s, e) => LamMoiDuLieu();

            // Menu danh mục
            mnuDanhMucVi.Click += (s, e) => { DatTrangThaiNutThanhCongCu(null); MoFormCon(new Forms.DanhMuc.frmViTien(), "Danh mục ví tiền"); };
            mnuDanhMucNhomChi.Click += (s, e) => { DatTrangThaiNutThanhCongCu(null); MoFormCon(new Forms.DanhMuc.frmLoaiChiTieu(), "Danh mục loại chi"); };
            mnuDanhMucNguonThu.Click += (s, e) => { DatTrangThaiNutThanhCongCu(null); MoFormCon(new Forms.DanhMuc.frmLoaiThuNhap(), "Danh mục loại thu"); };

            // Menu nghiệp vụ
            mnuThuNhap.Click += (s, e) => { DatTrangThaiNutThanhCongCu(btnThuNhap); MoFormCon(new Forms.NghiepVu.frmQuanLyThuNhap(), "Quản lý thu nhập"); };
            mnuChiTieu.Click += (s, e) => { DatTrangThaiNutThanhCongCu(btnChiTieu); MoFormCon(new Forms.NghiepVu.frmQuanLyChiTieu(), "Quản lý chi tiêu"); };
            mnuNganSach.Click += (s, e) => { DatTrangThaiNutThanhCongCu(btnNganSach); MoFormCon(new Forms.NghiepVu.frmNganSach(), "Quản lý ngân sách"); };
            mnuChuyenTien.Click += (s, e) => { DatTrangThaiNutThanhCongCu(null); MoFormCon(new Forms.NghiepVu.frmChuyenTien(), "Chuyển tiền giữa các ví"); };
            mnuTimKiem.Click += (s, e) => { DatTrangThaiNutThanhCongCu(btnTimKiem); MoFormCon(new Forms.NghiepVu.frmTimKiem(), "Tìm kiếm giao dịch"); };
            mnuMucTieuTietKiem.Click += (s, e) => { DatTrangThaiNutThanhCongCu(null); MoFormCon(new Forms.NghiepVu.frmMucTieuTietKiem(), "Mục tiêu tiết kiệm"); };
            mnuGiaoDichDinhKy.Click += (s, e) => { DatTrangThaiNutThanhCongCu(null); MoFormCon(new Forms.NghiepVu.frmGiaoDichDinhKy(), "Giao dịch định kỳ"); };

            // Menu báo cáo
            mnuBaoCaoThang.Click += (s, e) => { DatTrangThaiNutThanhCongCu(btnBaoCao); MoFormCon(new Forms.BaoCao.frmBaoCaoThang(), "Báo cáo tháng", true); };
            mnuBieuDo.Click += (s, e) => { DatTrangThaiNutThanhCongCu(btnBaoCao); MoFormCon(new Forms.BaoCao.frmBieuDo(), "Biểu đồ", true); };
            mnuXuatBaoCao.Click += (s, e) => { DatTrangThaiNutThanhCongCu(btnBaoCao); MoFormXuatBaoCao(); };
            mnuBaoCaoThuChi.Click += (s, e) => { DatTrangThaiNutThanhCongCu(btnTimKiem); MoFormCon(new Forms.NghiepVu.frmTimKiem(), "Báo cáo thu - chi"); };
            mnuBaoCaoNganSach.Click += (s, e) => { DatTrangThaiNutThanhCongCu(btnNganSach); MoFormCon(new Forms.NghiepVu.frmNganSach(), "Báo cáo theo dõi ngân sách"); };

            // Context menu cho nút Báo cáo nhanh
            mnuNhanhBaoCaoThang.Click += (s, e) => { DatTrangThaiNutThanhCongCu(btnBaoCao); MoFormCon(new Forms.BaoCao.frmBaoCaoThang(), "Báo cáo tháng", true); };
            mnuNhanhBieuDo.Click += (s, e) => { DatTrangThaiNutThanhCongCu(btnBaoCao); MoFormCon(new Forms.BaoCao.frmBieuDo(), "Biểu đồ", true); };
            mnuNhanhXuatBaoCao.Click += (s, e) => { DatTrangThaiNutThanhCongCu(btnBaoCao); MoFormXuatBaoCao(); };
            btnBaoCao.ContextMenuStrip = cmsBaoCao;

            // Menu quản trị
            mnuQuanLyNguoiDung.Click += (s, e) => { DatTrangThaiNutThanhCongCu(null); MoFormCon(new Forms.QuanTri.frmNguoiDung(), "Quản lý người dùng"); };
            mnuPhanQuyen.Click += (s, e) => { DatTrangThaiNutThanhCongCu(null); MoFormCon(new Forms.HeThong.frmPhanQuyen(), "Phân quyền người dùng"); };
            mnuSaoLuuDuLieu.Click += (s, e) => { DatTrangThaiNutThanhCongCu(null); MoFormCon(new Forms.QuanTri.frmSaoLuu(), "Sao lưu và phục hồi", true); };
            mnuCauHinh.Click += (s, e) => { DatTrangThaiNutThanhCongCu(null); MoFormCon(new Forms.QuanTri.frmCauHinh(), "Cấu hình ứng dụng"); };

            // Menu trợ giúp
            mnuHuongDan.Click += (s, e) => { DatTrangThaiNutThanhCongCu(null); MoFormHuongDan(); };
            mnuGioiThieu.Click += (s, e) => { DatTrangThaiNutThanhCongCu(null); MoFormGioiThieu(); };

            // Chọn tháng
            dtpThang.ValueChanged += (s, e) =>
            {
                lblTrangThai.Text = string.Format("Xem dữ liệu {0:MM/yyyy}", dtpThang.Value);
                DongBoThangFormConHienTai();
            };

            Shown += (s, e) => MoDashboard();
        }

        // Cập nhật thông tin người dùng trên toàn giao diện
        public void CapNhatThongTinNguoiDung(string hoTen)
        {
            CapNhatThongTinNguoiDung(hoTen, null);
        }

        public void CapNhatThongTinNguoiDung(string hoTen, string email)
        {
            if (!string.IsNullOrEmpty(hoTen))
            {
                _hoTen = hoTen;
                lblNguoiDung.Text = "Đăng nhập: " + _hoTen;
                lblNguoiDungHienTai.Text = _hoTen;
            }
            if (!string.IsNullOrEmpty(email))
            {
                _email = email;
            }
        }

        // Nhúng một form con vào vùng nội dung chính theo luồng
        public void MoFormCon(Form formCon, string tieuDe = null, bool cheDoTrangCaNhan = false)
        {
            if (formCon == null) return;

            pnlNoiDung.Controls.Clear();
            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;
            pnlNoiDung.Controls.Add(formCon);
            formCon.Show();

            if (!string.IsNullOrEmpty(tieuDe))
            {
                lblTieuDeCuaSo.Text = "Quản Lý Chi Tiêu — " + tieuDe;
            }

            // Thanh công cụ: chế độ trang cá nhân hiển thị tên người dùng góc phải, ẩn bộ lọc tháng
            lblNguoiDungHienTai.Text = _hoTen;
            lblNguoiDungHienTai.Visible = cheDoTrangCaNhan;
            lblThang.Visible = !cheDoTrangCaNhan;
            dtpThang.Visible = !cheDoTrangCaNhan;
            btnLamMoi.Visible = !cheDoTrangCaNhan;

            if (cheDoTrangCaNhan)
            {
                lblNguoiDungHienTai.Location = new Point(Math.Max(700, tlsCongCu.ClientSize.Width - lblNguoiDungHienTai.Width - 16), 14);
                lblNguoiDungHienTai.BringToFront();
            }

            // Đồng bộ ngày tháng sang form con ngay khi mở
            var dongBo = formCon as IDongBoThang;
            if (dongBo != null)
            {
                dongBo.DongBoThang(dtpThang.Value);
            }
        }

        private void ThaoTacChucNang(string tenChucNang)
        {
            lblTrangThai.Text = "Đang mở: " + tenChucNang;
        }

        private void LamMoiDuLieu()
        {
            DongBoThangFormConHienTai();
            lblTrangThai.Text = "Dữ liệu đã được làm mới lúc " + DateTime.Now.ToString("HH:mm:ss");
        }

        private void DongBoThangFormConHienTai()
        {
            if (pnlNoiDung.Controls.Count > 0)
            {
                var dongBo = pnlNoiDung.Controls[0] as IDongBoThang;
                if (dongBo != null)
                {
                    dongBo.DongBoThang(dtpThang.Value);
                }
            }
        }

        private void MoFormDangNhap()
        {
            using (var f = new frmDangNhap())
            {
                f.ShowDialog(this);
            }
        }

        private void MoFormDangKy()
        {
            using (var f = new frmDangKy())
            {
                f.ShowDialog(this);
            }
        }

        private void MoFormDoiMatKhau()
        {
            using (var f = new frmDoiMatKhau(_tenDangNhap, _hoTen))
            {
                f.ShowDialog(this);
            }
        }

        private void MoFormThongTinCaNhan()
        {
            string emailHienTai = !string.IsNullOrEmpty(_email) ? _email : (PhienDangNhap.DaDangNhap ? PhienDangNhap.Email : "");
            var f = new frmThongTinCaNhan(_tenDangNhap, _hoTen, emailHienTai);
            f.OnThongTinDaCapNhat += CapNhatThongTinNguoiDung;
            f.OnThongTinChiTietDaCapNhat += (hoTenMoi, emailMoi) => CapNhatThongTinNguoiDung(hoTenMoi, emailMoi);
            MoFormCon(f, "Thông tin cá nhân", true);
            lblTrangThai.Text = "Đang xem: Thông tin cá nhân";
        }

        public void MoFormXuatBaoCao(bool xuatPdf = false)
        {
            MoFormCon(new Forms.BaoCao.frmXuatBaoCao(xuatPdf), "Xuất báo cáo", true);
        }

        private void MoFormHuongDan()
        {
            var f = new Forms.TroGiup.frmHuongDan();
            MoFormCon(f, "Hướng dẫn sử dụng", true);
            lblTrangThai.Text = "Đang xem: Hướng dẫn sử dụng";
        }

        private void MoFormGioiThieu()
        {
            var f = new Forms.TroGiup.frmGioiThieu();
            f.OnYeuCauDong += () =>
            {
                lblTieuDeCuaSo.Text = "Quản Lý Chi Tiêu — Màn hình chính";
                lblNguoiDungHienTai.Visible = false;
                lblThang.Visible = true;
                dtpThang.Visible = true;
                btnLamMoi.Visible = true;
                pnlNoiDung.Controls.Clear();
                lblTrangThai.Text = "Sẵn sàng";
            };
            MoFormCon(f, "Giới thiệu", true);
            lblTrangThai.Text = "Đang xem: Giới thiệu ứng dụng";
        }

        private void DangXuat()
        {
            var dr = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                PhienDangNhap.XoaPhien();
                GhiNhoDangNhap.Xoa();
                Hide();
                using (var f = new frmDangNhap())
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        Show();
                    }
                    else
                    {
                        Close();
                    }
                }
            }
        }

        private void XacNhanThoat()
        {
            var dr = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnPhongTo_Click(object sender, EventArgs e)
        {
            MaximizedBounds = Screen.FromControl(this).WorkingArea; // Không che thanh taskbar
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

        // Icon cho form (đồng nhất với toàn bộ hệ thống)
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
                // Thiếu icon không làm gián đoạn ứng dụng
            }
        }

        // Đổi màu và kiểu dáng nút được chọn trên thanh công cụ nhanh
        public void DatTrangThaiNutThanhCongCu(Button nutDangChon)
        {
            Button[] cacNut = { btnTrangChu, btnThuNhap, btnChiTieu, btnNganSach, btnBaoCao, btnTimKiem };
            foreach (var b in cacNut)
            {
                bool daChon = (b == nutDangChon);
                if (daChon)
                {
                    b.BackColor = Color.FromArgb(21, 101, 192); // Màu xanh dương #1565C0
                    b.ForeColor = Color.White;
                    b.FlatAppearance.BorderSize = 0;
                    b.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    if (b == btnTrangChu) b.Image = null;
                    else if (b == btnThuNhap) b.Image = global::LTWIN_N05_QLCT.Properties.Resources.icoThemThuNhap_Trang;
                    else if (b == btnChiTieu) b.Image = global::LTWIN_N05_QLCT.Properties.Resources.icoChiTieu_Trang;
                    else if (b == btnNganSach) b.Image = global::LTWIN_N05_QLCT.Properties.Resources.icoViTien_Trang;
                    else if (b == btnBaoCao) b.Image = global::LTWIN_N05_QLCT.Properties.Resources.icoBaoCao_Trang;
                    else if (b == btnTimKiem) b.Image = global::LTWIN_N05_QLCT.Properties.Resources.icoTimKiem_Trang;
                }
                else
                {
                    b.BackColor = Color.White;
                    b.ForeColor = Color.FromArgb(30, 41, 59);
                    b.FlatAppearance.BorderSize = 1;
                    b.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
                    b.Font = new Font("Segoe UI", 9.25F, FontStyle.Regular);
                    if (b == btnTrangChu) b.Image = null;
                    else if (b == btnThuNhap) b.Image = global::LTWIN_N05_QLCT.Properties.Resources.icoThemThuNhap_XanhDuong;
                    else if (b == btnChiTieu) b.Image = global::LTWIN_N05_QLCT.Properties.Resources.icoChiTieu_XanhDuong;
                    else if (b == btnNganSach) b.Image = global::LTWIN_N05_QLCT.Properties.Resources.icoViTien_XanhDuong;
                    else if (b == btnBaoCao) b.Image = global::LTWIN_N05_QLCT.Properties.Resources.icoBaoCao_XanhDuong;
                    else if (b == btnTimKiem) b.Image = global::LTWIN_N05_QLCT.Properties.Resources.icoTimKiem_XanhDuong;
                }
            }
        }

        // Mở dashboard / màn hình chính
        private void MoDashboard()
        {
            DatTrangThaiNutThanhCongCu(btnTrangChu);
            var frm = new frmDashboard();
            MoFormCon(frm, "Màn hình chính");
            lblTrangThai.Text = "Sẵn sàng";
        }
}
}
