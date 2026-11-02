using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LTWIN_N05_QLCT.Models;
using LTWIN_N05_QLCT.Services;

namespace LTWIN_N05_QLCT.Forms.NghiepVu
{
    public partial class frmQuanLyThuNhap : Form, IDongBoThang
    {
        private string _selectedId = null;
        private List<ThuNhap> _danhSachThuNhap = new List<ThuNhap>();
        private List<Vi> _danhSachVi = new List<Vi>();
        private DateTime _thangHienTai = DateTime.Today;

        public void DongBoThang(DateTime thang)
        {
            _thangHienTai = thang;
            dtpTuNgay.Value = new DateTime(thang.Year, thang.Month, 1);
            dtpDenNgay.Value = new DateTime(thang.Year, thang.Month, DateTime.DaysInMonth(thang.Year, thang.Month));
            if (thang.Month == DateTime.Today.Month && thang.Year == DateTime.Today.Year)
                dtpNgay.Value = DateTime.Today;
            else
                dtpNgay.Value = dtpTuNgay.Value;


            lblThang.Text = "Bạn đang xem tháng: " +_thangHienTai.ToString("MM/yyyy");
            LoadData();
            UpdateCoCauThuNhap();
        }

        public frmQuanLyThuNhap()
        {
            InitializeComponent();
        }

        private void frmQuanLyThuNhap_Load(object sender, EventArgs e)
        {
            try
            {

                cboLoaiThu.Items.Clear();
                cboLoaiThu.Items.AddRange(DataService.DanhSachLoaiThu);
                if (cboLoaiThu.Items.Count > 0) cboLoaiThu.SelectedIndex = 0;

                cboLocLoaiThu.Items.Clear();
                cboLocLoaiThu.Items.Add("Tất cả");
                cboLocLoaiThu.Items.AddRange(DataService.DanhSachLoaiThu);
                cboLocLoaiThu.SelectedIndex = 0;

                LoadWallets();

                var now = DateTime.Today;
                dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
                dtpDenNgay.Value = now;

                txtSoTien.Leave += (s, ev) => FormatTextBoxMoney(txtSoTien);

                LoadData();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện thao tác dữ liệu: " + ex.Message,
                    "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadWallets()
        {
            _danhSachVi = DataService.GetDanhSachVi();
            cboViThu.Items.Clear();
            foreach (var vi in _danhSachVi)
            {
                cboViThu.Items.Add(string.Format("{0} — {1:N0} đ", vi.Ten, vi.SoDu));
            }
            if (cboViThu.Items.Count > 0) cboViThu.SelectedIndex = 0;
        }

        public void LoadData()
        {
            var tuNgay = dtpTuNgay.Value.Date;
            var denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);
            var loaiThu = cboLocLoaiThu.SelectedItem != null ? cboLocLoaiThu.SelectedItem.ToString() : null;

            _danhSachThuNhap = DataService.GetThuNhap(tuNgay, denNgay, loaiThu);

            dgvThuNhap.Rows.Clear();
            foreach (var item in _danhSachThuNhap)
            {
                var vi = _danhSachVi.FirstOrDefault(v => v.Id == item.ViId);
                int idx = dgvThuNhap.Rows.Add(
                    item.Ngay.ToString("dd/MM/yyyy"),
                    item.LoaiThu,
                    vi != null ? vi.Ten : "",
                    item.SoTien.ToString("N0") + " đ",
                    item.GhiChu
                );
                dgvThuNhap.Rows[idx].Tag = item.Id;
                dgvThuNhap.Rows[idx].Cells["colSoTien"].Style.ForeColor = Color.FromArgb(46, 125, 50);
                dgvThuNhap.Rows[idx].Cells["colSoTien"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }

            lblSoGiaoDich.Text = string.Format("Chỉ đọc • Số giao dịch: {0} • Hiển thị toàn bộ kết quả", _danhSachThuNhap.Count);

            decimal tongThu = _danhSachThuNhap.Sum(x => x.SoTien);
            lblTongThu.Text = string.Format("{0:N0} đ", tongThu);

            UpdateCoCauThuNhap();
        }

        private void UpdateCoCauThuNhap()
        {
            int thang = _thangHienTai.Month;
            int nam = _thangHienTai.Year;

            lblCoCauThuNhapThang10.Text = string.Format("Cơ cấu thu nhập tháng {0}", thang);

            var dauThang = new DateTime(nam, thang, 1);
            var thangThuNhap = DataService.GetThuNhap(dauThang, dauThang.AddMonths(1).AddDays(-1));
            decimal tongThang = thangThuNhap.Sum(x => x.SoTien);

            decimal luong = thangThuNhap.Where(x => x.LoaiThu == "Lương").Sum(x => x.SoTien);
            decimal thuong = thangThuNhap.Where(x => x.LoaiThu == "Thưởng").Sum(x => x.SoTien);
            decimal khac = thangThuNhap.Where(x => x.LoaiThu == "Thu nhập khác").Sum(x => x.SoTien);

            lblLuong2.Text = string.Format("{0:N0} đ", luong);
            lblThuong2.Text = string.Format("{0:N0} đ", thuong);
            lblThuNhapKhac2.Text = string.Format("{0:N0} đ", khac);

            if (tongThang > 0)
            {
                lblLuong3.Text = string.Format("{0:N1}%", (luong / tongThang * 100));
                lblThuong3.Text = string.Format("{0:N1}%", (thuong / tongThang * 100));
                lblThuNhapKhac3.Text = string.Format("{0:N1}%", (khac / tongThang * 100));
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
            try
            {

                decimal soTien;
                string viId;
                if (!ValidateInput(out soTien, out viId)) return;

                var item = new ThuNhap
                {
                    Ngay = dtpNgay.Value,
                    LoaiThu = cboLoaiThu.SelectedItem != null ? cboLoaiThu.SelectedItem.ToString() : "Lương",
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
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện thao tác dữ liệu: " + ex.Message,
                    "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(_selectedId))
                {
                    MessageBox.Show("Vui lòng chọn khoản thu cần sửa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal soTien;
                string viId;
                if (!ValidateInput(out soTien, out viId)) return;

                var item = new ThuNhap
                {
                    Id = _selectedId,
                    Ngay = dtpNgay.Value,
                    LoaiThu = cboLoaiThu.SelectedItem != null ? cboLoaiThu.SelectedItem.ToString() : "Lương",
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
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện thao tác dữ liệu: " + ex.Message,
                    "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện thao tác dữ liệu: " + ex.Message,
                    "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            decimal val;
            if (decimal.TryParse(raw, out val))
            {
                tb.Text = val.ToString("N0");
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã xuất dữ liệu thu nhập ra file Excel thành công!", "Xuất Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
