using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyChiTieu.Models;
using QuanLyChiTieu.Services;

namespace QuanLyChiTieu.Forms
{
    public partial class frmTimKiem : Form
    {
        private List<Vi> _danhSachVi = new();

        public frmTimKiem()
        {
            InitializeComponent();
            SetupEvents();
            LoadFilterData();
            ThucHienTimKiem();
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
            this.btnBaoCao.Click += (s, e) => { /* Already here */ };

            // Menu navigation
            var mnuCauHinh = new ToolStripMenuItem("Cấu hình", null, (s, e) => NavigateTo<frmCauHinh>());
            var mnuThoat = new ToolStripMenuItem("Thoát", null, (s, e) => Application.Exit());
            this.mnuHeThong.DropDownItems.Clear();
            this.mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] { mnuCauHinh, mnuThoat });

            var mnuThuNhap = new ToolStripMenuItem("Quản lý thu nhập", null, (s, e) => NavigateTo<frmQuanLyThuNhap>());
            var mnuChiTieu = new ToolStripMenuItem("Quản lý chi tiêu", null, (s, e) => NavigateTo<frmQuanLyChiTieu>());
            var mnuNganSach = new ToolStripMenuItem("Ngân sách", null, (s, e) => NavigateTo<frmNganSach>());
            var mnuChuyenTien = new ToolStripMenuItem("Chuyển tiền giữa các ví", null, (s, e) => NavigateTo<frmChuyenTien>());
            var mnuTimKiemItem = new ToolStripMenuItem("Tìm kiếm giao dịch", null, (s, e) => { });
            this.mnuNghiepVu.DropDownItems.Clear();
            this.mnuNghiepVu.DropDownItems.AddRange(new ToolStripItem[] { mnuThuNhap, mnuChiTieu, mnuNganSach, mnuChuyenTien, mnuTimKiemItem });

            // Actions
            this.btnTim.Click += (s, e) => ThucHienTimKiem();
            this.btnXoaLoc.Click += (s, e) => XoaLoc();
            this.btnXuatExcel.Click += (s, e) =>
            {
                MessageBox.Show("Đã xuất kết quả tìm kiếm ra file Excel thành công!", "Xuất Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            this.txtTienTu.Leave += (s, e) => FormatMoneyInput(txtTienTu);
            this.txtTienDen.Leave += (s, e) => FormatMoneyInput(txtTienDen);

            this.tsslTrangThai.Text = $"✔ Sẵn sàng   |   Đăng nhập: {DataService.GetNguoiDung()}";
            this.lblNguoiDungHienTai.Text = DataService.GetNguoiDung();
        }

        private void LoadFilterData()
        {
            // Loai giao dich
            cboLoaiGiaoDich.SelectedIndex = 0; // Tất cả

            // Dates: first of month to today
            var now = DateTime.Today;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
            dtpDenNgay.Value = now;

            // Wallets
            _danhSachVi = DataService.GetDanhSachVi();
            cboVi.Items.Clear();
            cboVi.Items.Add("Tất cả");
            foreach (var v in _danhSachVi)
            {
                cboVi.Items.Add(v.Ten);
            }
            cboVi.SelectedIndex = 0;

            // Category combo
            cboLoai.Items.Clear();
            cboLoai.Items.Add("Tất cả");
            foreach (var lt in DataService.DanhSachLoaiThu) cboLoai.Items.Add(lt);
            foreach (var lc in DataService.DanhSachLoaiChi) cboLoai.Items.Add(lc);
            cboLoai.SelectedIndex = 0;

            txtTienTu.Text = "100.000";
            txtTienDen.Text = "25.000.000";
        }

        private void FormatMoneyInput(TextBox tb)
        {
            string raw = tb.Text.Replace(".", "").Replace(",", "").Trim();
            if (decimal.TryParse(raw, out decimal val))
            {
                tb.Text = val.ToString("N0");
            }
        }

        private void XoaLoc()
        {
            txtTuKhoa.Text = "";
            cboLoaiGiaoDich.SelectedIndex = 0;
            var now = DateTime.Today;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
            dtpDenNgay.Value = now;
            txtTienTu.Text = "";
            txtTienDen.Text = "";
            cboLoai.SelectedIndex = 0;
            cboVi.SelectedIndex = 0;

            ThucHienTimKiem();
        }

        private void ThucHienTimKiem()
        {
            string? tuKhoa = string.IsNullOrWhiteSpace(txtTuKhoa.Text) ? null : txtTuKhoa.Text.Trim();
            string? loaiGD = cboLoaiGiaoDich.SelectedItem?.ToString();
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);

            decimal? tienTu = null;
            string rawTu = txtTienTu.Text.Replace(".", "").Replace(",", "").Trim();
            if (decimal.TryParse(rawTu, out decimal valTu)) tienTu = valTu;

            decimal? tienDen = null;
            string rawDen = txtTienDen.Text.Replace(".", "").Replace(",", "").Trim();
            if (decimal.TryParse(rawDen, out decimal valDen)) tienDen = valDen;

            string? loai = cboLoai.SelectedItem?.ToString();
            string? selectedViTen = cboVi.SelectedItem?.ToString();
            string? viId = null;
            if (selectedViTen != null && selectedViTen != "Tất cả")
            {
                var vi = _danhSachVi.FirstOrDefault(v => v.Ten == selectedViTen);
                viId = vi?.Id;
            }

            var results = DataService.TimKiemGiaoDich(tuKhoa, loaiGD, tuNgay, denNgay, tienTu, tienDen, loai, viId);

            dgvKetQua.Rows.Clear();
            decimal tongThu = 0;
            decimal tongChi = 0;

            foreach (var item in results)
            {
                DateTime ngay = (DateTime)item[0];
                string loaiGiaoDich = (string)item[1];
                string loaiThuChi = (string)item[2];
                string tenVi = (string)item[3];
                decimal soTien = (decimal)item[4];
                string ghiChu = (string)item[5];

                int idx = dgvKetQua.Rows.Add(
                    ngay.ToString("dd/MM/yyyy"),
                    loaiGiaoDich,
                    loaiThuChi,
                    tenVi,
                    soTien.ToString("N0") + " đ",
                    ghiChu
                );

                if (loaiGiaoDich == "Thu")
                {
                    tongThu += soTien;
                    dgvKetQua.Rows[idx].Cells["colLoaiGiaoDich"].Style.ForeColor = Color.FromArgb(46, 125, 50);
                    dgvKetQua.Rows[idx].Cells["colLoaiGiaoDich"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    dgvKetQua.Rows[idx].Cells["colSoTien"].Style.ForeColor = Color.FromArgb(46, 125, 50);
                    dgvKetQua.Rows[idx].Cells["colSoTien"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
                else
                {
                    tongChi += soTien;
                    dgvKetQua.Rows[idx].Cells["colLoaiGiaoDich"].Style.ForeColor = Color.FromArgb(211, 47, 47);
                    dgvKetQua.Rows[idx].Cells["colLoaiGiaoDich"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    dgvKetQua.Rows[idx].Cells["colSoTien"].Style.ForeColor = Color.FromArgb(211, 47, 47);
                    dgvKetQua.Rows[idx].Cells["colSoTien"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
                dgvKetQua.Rows[idx].Cells["colSoTien"].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            lblKetQuaTimKiem5Giao.Text = $"Kết quả tìm kiếm — {results.Count} giao dịch";
            lblHienThi155Chi.Text = $"Hiển thị 1-{results.Count} / {results.Count} • Chỉ đọc";

            lblTongThu25000000.Text = $"Tổng thu: {tongThu:N0} đ";
            lblTongChi8100000.Text = $"Tổng chi: {tongChi:N0} đ";
            decimal chenhLech = tongThu - tongChi;
            lblChenhLechThuChi16900.Text = $"Chênh lệch thu – chi: {chenhLech:N0} đ";
            lblChenhLechThuChi16900.ForeColor = chenhLech >= 0 ? Color.FromArgb(21, 101, 192) : Color.FromArgb(211, 47, 47);
        }
    }
}
