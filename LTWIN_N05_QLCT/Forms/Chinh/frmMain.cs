using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using LTWIN_N05_QLCT.Forms.HeThong;
using NghiepVu.TienIch;

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
            lblNguoiDung.Text = "Đăng nhập: " + _hoTen;
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
                    lblNguoiDung.Text = "Đăng nhập: " + _hoTen;
                    lblNguoiDungHienTai.Text = _hoTen;
                }
            };

            // Icon chuẩn cho các nút thanh công cụ
            try
            {
                btnNganSach.Image = new Bitmap(global::LTWIN_N05_QLCT.Properties.Resources.icoViTien_XanhDuong, new Size(20, 20));
                btnBaoCao.Image = new Bitmap(global::LTWIN_N05_QLCT.Properties.Resources.icoBaoCao_XanhDuong, new Size(20, 20));
                btnTimKiem.Image = new Bitmap(global::LTWIN_N05_QLCT.Properties.Resources.icoTimKiem_XanhDuong, new Size(20, 20));
                btnLamMoi.Image = new Bitmap(global::LTWIN_N05_QLCT.Properties.Resources.icoLamMoi_XanhDuong, new Size(20, 20));
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

            // Sự kiện hệ thống
            mnuDangNhap.Click += (s, e) => MoFormDangNhap();
            mnuDangKy.Click += (s, e) => MoFormDangKy();
            mnuDoiMatKhau.Click += (s, e) => MoFormDoiMatKhau();
            mnuThongTinCaNhan.Click += (s, e) => MoFormThongTinCaNhan();
            mnuDangXuat.Click += (s, e) => DangXuat();
            mnuThoat.Click += (s, e) => XacNhanThoat();

            // Nút công cụ nhanh
            btnThuNhap.Click += (s, e) => ThaoTacChucNang("Ghi nhận thu nhập");
            btnChiTieu.Click += (s, e) => ThaoTacChucNang("Ghi nhận chi tiêu");
            btnNganSach.Click += (s, e) => ThaoTacChucNang("Quản lý ngân sách");
            btnBaoCao.Click += (s, e) => ThaoTacChucNang("Báo cáo tài chính");
            btnTimKiem.Click += (s, e) => ThaoTacChucNang("Tìm kiếm giao dịch");
            btnLamMoi.Click += (s, e) => LamMoiDuLieu();

            // Menu nghiệp vụ & báo cáo
            mnuThuNhap.Click += (s, e) => ThaoTacChucNang("Quản lý thu nhập");
            mnuChiTieu.Click += (s, e) => ThaoTacChucNang("Quản lý chi tiêu");
            mnuNganSach.Click += (s, e) => ThaoTacChucNang("Quản lý ngân sách");
            mnuBaoCaoThuChi.Click += (s, e) => ThaoTacChucNang("Báo cáo thu - chi");
            mnuBaoCaoNganSach.Click += (s, e) => ThaoTacChucNang("Báo cáo theo dõi ngân sách");

            // Menu trợ giúp
            mnuHuongDan.Click += (s, e) => MoFormHuongDan();
            mnuGioiThieu.Click += (s, e) => MoFormGioiThieu();

            // Chọn tháng
            dtpThang.ValueChanged += (s, e) =>
            {
                lblTrangThai.Text = string.Format("Xem dữ liệu {0:MM/yyyy}", dtpThang.Value);
            };

            Shown += (s, e) => MoDashboard();
        }

        // Cập nhật thông tin người dùng trên toàn giao diện
        public void CapNhatThongTinNguoiDung(string hoTen)
        {
            if (!string.IsNullOrEmpty(hoTen))
            {
                _hoTen = hoTen;
                lblNguoiDung.Text = "Đăng nhập: " + _hoTen;
                lblNguoiDungHienTai.Text = _hoTen;
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
        }

        private void ThaoTacChucNang(string tenChucNang)
        {
            lblTrangThai.Text = "Đang mở: " + tenChucNang;
        }

        private void LamMoiDuLieu()
        {
            lblTrangThai.Text = "Dữ liệu đã được làm mới lúc " + DateTime.Now.ToString("HH:mm:ss");
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
            var f = new frmThongTinCaNhan(_tenDangNhap, _hoTen);
            f.OnThongTinDaCapNhat += CapNhatThongTinNguoiDung;
            MoFormCon(f, "Thông tin cá nhân", true);
            lblTrangThai.Text = "Đang xem: Thông tin cá nhân";
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

        //Mo dasshboard
        private void MoDashboard()
        {
            var frm = new frmDashboard();
            MoFormCon(frm, "Tổng quan");
            lblTrangThai.Text = "Đang xem: Tổng quan";
        }
    }
}
