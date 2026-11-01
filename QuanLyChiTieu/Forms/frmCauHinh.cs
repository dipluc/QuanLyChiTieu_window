using System;
using System.IO;
using System.Windows.Forms;
using QuanLyChiTieu.Models;
using QuanLyChiTieu.Services;

namespace QuanLyChiTieu.Forms
{
    public partial class frmCauHinh : Form
    {
        private int _currentNguong = 80;

        public frmCauHinh()
        {
            InitializeComponent();
            SetupEvents();
            LoadConfig();
        }

        private void NavigateTo<T>() where T : Form, new()
        {
            var frm = new T();
            frm.Show();
            this.Hide();
            frm.FormClosed += (s, e) => this.Close();
        }

        private void SetupEvents()
        {
            // Toolbar navigation
            this.btnThuNhap.Click += (s, e) => NavigateTo<frmQuanLyThuNhap>();
            this.btnChiTieu.Click += (s, e) => NavigateTo<frmQuanLyChiTieu>();
            this.btnNganSach.Click += (s, e) => NavigateTo<frmNganSach>();
            this.btnBaoCao.Click += (s, e) => NavigateTo<frmTimKiem>();
            this.btnTimKiem.Click += (s, e) => NavigateTo<frmTimKiem>();
            this.btnLamMoi.Click += (s, e) => LoadConfig();

            // Menu
            var mnuCauHinhItem = new ToolStripMenuItem("Cấu hình", null, (s, e) => { });
            var mnuThoat = new ToolStripMenuItem("Thoát", null, (s, e) => Application.Exit());
            this.mnuHeThong.DropDownItems.Clear();
            this.mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] { mnuCauHinhItem, mnuThoat });

            var mnuThuNhap = new ToolStripMenuItem("Quản lý thu nhập", null, (s, e) => NavigateTo<frmQuanLyThuNhap>());
            var mnuChiTieu = new ToolStripMenuItem("Quản lý chi tiêu", null, (s, e) => NavigateTo<frmQuanLyChiTieu>());
            var mnuNganSach = new ToolStripMenuItem("Ngân sách", null, (s, e) => NavigateTo<frmNganSach>());
            var mnuChuyenTien = new ToolStripMenuItem("Chuyển tiền giữa các ví", null, (s, e) => NavigateTo<frmChuyenTien>());
            var mnuTimKiem = new ToolStripMenuItem("Tìm kiếm giao dịch", null, (s, e) => NavigateTo<frmTimKiem>());
            this.mnuNghiepVu.DropDownItems.Clear();
            this.mnuNghiepVu.DropDownItems.AddRange(new ToolStripItem[] { mnuThuNhap, mnuChiTieu, mnuNganSach, mnuChuyenTien, mnuTimKiem });

            // Actions
            this.btnDuyetThuMuc.Click += BtnDuyetThuMuc_Click;
            this.btnTang.Click += (s, e) => AdjustThreshold(5);
            this.btnGiam.Click += (s, e) => AdjustThreshold(-5);
            this.btnLuuThayDoi.Click += BtnLuuThayDoi_Click;
            this.btnHuy.Click += (s, e) => LoadConfig();

            this.tslDangNhap.Text = $"✔ Sẵn sàng   |   Đăng nhập: {DataService.GetNguoiDung()}";
            this.tslHomNay.Text = $"Hôm nay: {DateTime.Today:dd/MM/yyyy}";
            this.lblNguoiDungHienTai.Text = DataService.GetNguoiDung();
        }

        private void LoadConfig()
        {
            var cfg = DataService.GetCauHinh();
            txtThuMucSaoLuuMacDinh.Text = cfg.ThuMucSaoLuu;
            chkTuDongSaoLuuKhiThoat.Checked = cfg.TuDongSaoLuuKhiThoat;
            _currentNguong = cfg.NguongCanhBao;
            txtNguongCanhBao.Text = $"{_currentNguong}%";
            lblGiaiThichNguong.Text = $"Hiển thị cảnh báo khi chi tiêu đạt từ {_currentNguong}% hạn mức ngân sách trở lên.";
        }

        private void AdjustThreshold(int delta)
        {
            _currentNguong = Math.Clamp(_currentNguong + delta, 10, 100);
            txtNguongCanhBao.Text = $"{_currentNguong}%";
            lblGiaiThichNguong.Text = $"Hiển thị cảnh báo khi chi tiêu đạt từ {_currentNguong}% hạn mức ngân sách trở lên.";
        }

        private void BtnDuyetThuMuc_Click(object? sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Chọn thư mục sao lưu dữ liệu";
                fbd.UseDescriptionForTitle = true;
                if (!string.IsNullOrEmpty(txtThuMucSaoLuuMacDinh.Text) && Directory.Exists(txtThuMucSaoLuuMacDinh.Text))
                {
                    fbd.SelectedPath = txtThuMucSaoLuuMacDinh.Text;
                }

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtThuMucSaoLuuMacDinh.Text = fbd.SelectedPath;
                }
            }
        }

        private void BtnLuuThayDoi_Click(object? sender, EventArgs e)
        {
            string folder = txtThuMucSaoLuuMacDinh.Text.Trim();
            if (string.IsNullOrEmpty(folder))
            {
                MessageBox.Show("Vui lòng nhập đường dẫn thư mục sao lưu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtThuMucSaoLuuMacDinh.Focus();
                return;
            }

            var cfg = new CauHinhApp
            {
                ThuMucSaoLuu = folder,
                TuDongSaoLuuKhiThoat = chkTuDongSaoLuuKhiThoat.Checked,
                NguongCanhBao = _currentNguong
            };

            DataService.LuuCauHinh(cfg);
            MessageBox.Show("Đã lưu cấu hình ứng dụng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
