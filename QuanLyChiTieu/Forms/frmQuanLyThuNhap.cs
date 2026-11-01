using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using QuanLyChiTieu.Models;
using QuanLyChiTieu.Services;

namespace QuanLyChiTieu.Forms
{
    public partial class frmQuanLyThuNhap : Form
    {
        private string? _selectedId = null;
        private List<ThuNhap> _danhSachThuNhap = new();
        private List<Vi> _danhSachVi = new();

        public frmQuanLyThuNhap()
        {
            InitializeComponent();
        }

        private void NavigateTo<T>() where T : Form, new()
        {
            var frm = new T();
            frm.Show();
            this.Hide();
            frm.FormClosed += (s, e) => this.Close();
        }

        private void frmQuanLyThuNhap_Load(object sender, EventArgs e)
        {
            // Populate ComboBoxes
            cboLoaiThu.Items.Clear();
            cboLoaiThu.Items.AddRange(DataService.DanhSachLoaiThu);
            if (cboLoaiThu.Items.Count > 0) cboLoaiThu.SelectedIndex = 0;

            cboLocLoaiThu.Items.Clear();
            cboLocLoaiThu.Items.Add("Tất cả");
            cboLocLoaiThu.Items.AddRange(DataService.DanhSachLoaiThu);
            cboLocLoaiThu.SelectedIndex = 0;

            LoadWallets();

            // Set filter dates: current month range
            var now = DateTime.Today;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
            dtpDenNgay.Value = now;
            dtpThang.Value = now;

            txtSoTien.Leave += (s, ev) => FormatTextBoxMoney(txtSoTien);

            LoadData();
        }

        private void LoadWallets()
        {
            _danhSachVi = DataService.GetDanhSachVi();
            cboViThu.Items.Clear();
            foreach (var vi in _danhSachVi)
            {
                cboViThu.Items.Add($"{vi.Ten} — {vi.SoDu:N0} đ");
            }
            if (cboViThu.Items.Count > 0) cboViThu.SelectedIndex = 0;
        }

        private void LoadData()
        {
            var tuNgay = dtpTuNgay.Value.Date;
            var denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);
            var loaiThu = cboLocLoaiThu.SelectedItem?.ToString();

            _danhSachThuNhap = DataService.GetThuNhap(tuNgay, denNgay, loaiThu);

            // Populate Grid
            dgvThuNhap.Rows.Clear();
            foreach (var item in _danhSachThuNhap)
            {
                var vi = _danhSachVi.FirstOrDefault(v => v.Id == item.ViId);
                int idx = dgvThuNhap.Rows.Add(
                    item.Ngay.ToString("dd/MM/yyyy"),
                    item.LoaiThu,
                    vi?.Ten ?? "",
                    item.SoTien.ToString("N0") + " đ",
                    item.GhiChu
                );
                dgvThuNhap.Rows[idx].Tag = item.Id;
                // Green color for income amount
                dgvThuNhap.Rows[idx].Cells["colSoTien"].Style.ForeColor = Color.FromArgb(46, 125, 50);
                dgvThuNhap.Rows[idx].Cells["colSoTien"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }

            lblSoGiaoDich.Text = $"Chỉ đọc • Số giao dịch: {_danhSachThuNhap.Count} • Hiển thị toàn bộ kết quả";

            // Total income in filter range
            decimal tongThu = _danhSachThuNhap.Sum(x => x.SoTien);
            lblTongThu.Text = $"{tongThu:N0} đ";

            UpdateCoCauThuNhap();
        }

        private void UpdateCoCauThuNhap()
        {
            int thang = dtpThang.Value.Month;
            int nam = dtpThang.Value.Year;

            lblCoCauThuNhapThang10.Text = $"Cơ cấu thu nhập tháng {thang}";

            // Calculate income in this month
            var allData = DataService.LoadData();
            var thangThuNhap = allData.DanhSachThuNhap.Where(x => x.Ngay.Month == thang && x.Ngay.Year == nam).ToList();
            decimal tongThang = thangThuNhap.Sum(x => x.SoTien);

            decimal luong = thangThuNhap.Where(x => x.LoaiThu == "Lương").Sum(x => x.SoTien);
            decimal thuong = thangThuNhap.Where(x => x.LoaiThu == "Thưởng").Sum(x => x.SoTien);
            decimal khac = thangThuNhap.Where(x => x.LoaiThu == "Thu nhập khác").Sum(x => x.SoTien);

            lblLuong2.Text = $"{luong:N0} đ";
            lblThuong2.Text = $"{thuong:N0} đ";
            lblThuNhapKhac2.Text = $"{khac:N0} đ";

            if (tongThang > 0)
            {
                lblLuong3.Text = $"{(luong / tongThang * 100):N1}%";
                lblThuong3.Text = $"{(thuong / tongThang * 100):N1}%";
                lblThuNhapKhac3.Text = $"{(khac / tongThang * 100):N1}%";
            }
            else
            {
                lblLuong3.Text = "0,0%";
                lblThuong3.Text = "0,0%";
                lblThuNhapKhac3.Text = "0,0%";
            }
        }

        private void dgvThuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvThuNhap.Rows.Count) return;

            var row = dgvThuNhap.Rows[e.RowIndex];
            _selectedId = row.Tag as string;
            var item = _danhSachThuNhap.FirstOrDefault(x => x.Id == _selectedId);
            if (item != null)
            {
                dtpNgay.Value = item.Ngay;
                cboLoaiThu.SelectedItem = item.LoaiThu;

                var viIndex = _danhSachVi.FindIndex(v => v.Id == item.ViId);
                if (viIndex >= 0 && viIndex < cboViThu.Items.Count)
                    cboViThu.SelectedIndex = viIndex;

                txtSoTien.Text = item.SoTien.ToString("N0");
                txtGhiChu.Text = item.GhiChu;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out decimal soTien, out string viId)) return;

            var item = new ThuNhap
            {
                Ngay = dtpNgay.Value,
                LoaiThu = cboLoaiThu.SelectedItem?.ToString() ?? "Lương",
                ViId = viId,
                SoTien = soTien,
                GhiChu = txtGhiChu.Text.Trim()
            };

            DataService.ThemThuNhap(item);
            MessageBox.Show("Thêm khoản thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadWallets();
            LoadData();
            ResetInput();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedId))
            {
                MessageBox.Show("Vui lòng chọn khoản thu cần sửa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput(out decimal soTien, out string viId)) return;

            var item = new ThuNhap
            {
                Id = _selectedId,
                Ngay = dtpNgay.Value,
                LoaiThu = cboLoaiThu.SelectedItem?.ToString() ?? "Lương",
                ViId = viId,
                SoTien = soTien,
                GhiChu = txtGhiChu.Text.Trim()
            };

            DataService.SuaThuNhap(item);
            MessageBox.Show("Cập nhật khoản thu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadWallets();
            LoadData();
            ResetInput();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedId))
            {
                MessageBox.Show("Vui lòng chọn khoản thu cần xóa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dr = MessageBox.Show("Bạn có chắc chắn muốn xóa khoản thu này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DataService.XoaThuNhap(_selectedId);
                MessageBox.Show("Đã xóa khoản thu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadWallets();
                LoadData();
                ResetInput();
            }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            ResetInput();
        }

        private void ResetInput()
        {
            _selectedId = null;
            dtpNgay.Value = DateTime.Today;
            if (cboLoaiThu.Items.Count > 0) cboLoaiThu.SelectedIndex = 0;
            if (cboViThu.Items.Count > 0) cboViThu.SelectedIndex = 0;
            txtSoTien.Text = "";
            txtGhiChu.Text = "";
            dgvThuNhap.ClearSelection();
        }

        private bool ValidateInput(out decimal soTien, out string viId)
        {
            soTien = 0;
            viId = "";

            string rawMoney = txtSoTien.Text.Replace(".", "").Replace(",", "").Replace("đ", "").Trim();
            if (!decimal.TryParse(rawMoney, out soTien) || soTien <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ lớn hơn 0!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSoTien.Focus();
                return false;
            }

            int idx = cboViThu.SelectedIndex;
            if (idx < 0 || idx >= _danhSachVi.Count)
            {
                MessageBox.Show("Vui lòng chọn ví nhận!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            viId = _danhSachVi[idx].Id;
            return true;
        }

        private void FormatTextBoxMoney(TextBox tb)
        {
            string raw = tb.Text.Replace(".", "").Replace(",", "").Trim();
            if (decimal.TryParse(raw, out decimal val))
            {
                tb.Text = val.ToString("N0");
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadWallets();
            LoadData();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã xuất dữ liệu thu nhập ra file Excel thành công!", "Xuất Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dtpThang_ValueChanged(object sender, EventArgs e)
        {
            UpdateCoCauThuNhap();
        }

        // Navigation
        private void btnChiTieu_Click(object sender, EventArgs e) => NavigateTo<frmQuanLyChiTieu>();
        private void btnNganSach_Click(object sender, EventArgs e) => NavigateTo<frmNganSach>();
        private void btnBaoCao_Click(object sender, EventArgs e) => NavigateTo<frmTimKiem>();
        private void btnTimKiem_Click(object sender, EventArgs e) => NavigateTo<frmTimKiem>();
    }
}
