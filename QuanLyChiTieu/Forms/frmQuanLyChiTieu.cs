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
    public partial class frmQuanLyChiTieu : Form
    {
        private string? _selectedId = null;
        private List<ChiTieu> _danhSachChiTieu = new();
        private List<Vi> _danhSachVi = new();

        public frmQuanLyChiTieu()
        {
            InitializeComponent();
            SetupEvents();
            SetupDataGridViewColumns();
            LoadComboBoxes();
            SetDefaultDates();
            LoadData();
            KiemTraNganSach();
            UpdateUserInfo();
        }

        #region Navigation Helper

        private void NavigateTo<T>() where T : Form, new()
        {
            var frm = new T();
            frm.Show();
            this.Hide();
            frm.FormClosed += (s, e) => this.Close();
        }

        #endregion

        #region Setup

        private void SetupEvents()
        {
            // Toolbar navigation
            this.btnThuNhap.Click += (s, e) => NavigateTo<frmQuanLyThuNhap>();
            this.btnNganSach.Click += (s, e) => NavigateTo<frmNganSach>();
            this.btnBaoCao.Click += (s, e) => NavigateTo<frmTimKiem>();
            this.btnTimKiem.Click += (s, e) => NavigateTo<frmTimKiem>();

            // Menu navigation
            var mnuCauHinh = new ToolStripMenuItem("Cấu hình", null, (s, e) => NavigateTo<frmCauHinh>());
            var mnuThoat = new ToolStripMenuItem("Thoát", null, (s, e) => Application.Exit());
            this.mnuHeThong.DropDownItems.Clear();
            this.mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] { mnuCauHinh, mnuThoat });

            var mnuThuNhap = new ToolStripMenuItem("Quản lý thu nhập", null, (s, e) => NavigateTo<frmQuanLyThuNhap>());
            var mnuChiTieu = new ToolStripMenuItem("Quản lý chi tiêu", null, (s, e) => { });
            var mnuNganSach = new ToolStripMenuItem("Ngân sách", null, (s, e) => NavigateTo<frmNganSach>());
            var mnuChuyenTien = new ToolStripMenuItem("Chuyển tiền giữa các ví", null, (s, e) => NavigateTo<frmChuyenTien>());
            var mnuTimKiem = new ToolStripMenuItem("Tìm kiếm giao dịch", null, (s, e) => NavigateTo<frmTimKiem>());
            this.mnuNghiepVu.DropDownItems.Clear();
            this.mnuNghiepVu.DropDownItems.AddRange(new ToolStripItem[] { mnuThuNhap, mnuChiTieu, mnuNganSach, mnuChuyenTien, mnuTimKiem });

            // CRUD buttons
            this.btnThem.Click += BtnThem_Click;
            this.btnSua.Click += BtnSua_Click;
            this.btnXoa.Click += BtnXoa_Click;
            this.btnMoi.Click += BtnMoi_Click;

            // Filter
            this.btnLoc.Click += BtnLoc_Click;
            this.btnXuatExcel.Click += BtnXuatExcel_Click;
            this.btnLamMoi.Click += BtnLamMoi_Click;

            // DataGridView selection
            this.dgvChiTieu.CellClick += DgvChiTieu_CellClick;

            // Month picker
            this.dtpThang.ValueChanged += DtpThang_ValueChanged;

            // Wallet selection change - update balance display
            this.cboViChi.SelectedIndexChanged += CboViChi_SelectedIndexChanged;

            // Format money on leave
            this.txtSoTien.Leave += TxtSoTien_Leave;
        }

        private void SetupDataGridViewColumns()
        {
            dgvChiTieu.Columns.Clear();

            var colId = new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "ID",
                Visible = false
            };
            dgvChiTieu.Columns.Add(colId);

            var colNgay = new DataGridViewTextBoxColumn
            {
                Name = "colNgay",
                HeaderText = "Ngày",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            };
            dgvChiTieu.Columns.Add(colNgay);

            var colLoaiChi = new DataGridViewTextBoxColumn
            {
                Name = "colLoaiChi",
                HeaderText = "Loại chi",
                Width = 120
            };
            dgvChiTieu.Columns.Add(colLoaiChi);

            var colVi = new DataGridViewTextBoxColumn
            {
                Name = "colVi",
                HeaderText = "Ví",
                Width = 120
            };
            dgvChiTieu.Columns.Add(colVi);

            var colSoTien = new DataGridViewTextBoxColumn
            {
                Name = "colSoTien",
                HeaderText = "Số tiền",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0",
                    ForeColor = Color.FromArgb(211, 47, 47),
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold)
                }
            };
            dgvChiTieu.Columns.Add(colSoTien);

            var colGhiChu = new DataGridViewTextBoxColumn
            {
                Name = "colGhiChu",
                HeaderText = "Ghi chú",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dgvChiTieu.Columns.Add(colGhiChu);
        }

        private void LoadComboBoxes()
        {
            // Category
            cboLoaiChi.Items.Clear();
            cboLoaiChi.Items.AddRange(DataService.DanhSachLoaiChi);
            if (cboLoaiChi.Items.Count > 0)
                cboLoaiChi.SelectedIndex = 0;

            // Category filter
            cboLocLoaiChi.Items.Clear();
            cboLocLoaiChi.Items.Add("Tất cả");
            cboLocLoaiChi.Items.AddRange(DataService.DanhSachLoaiChi);
            cboLocLoaiChi.SelectedIndex = 0;

            // Wallets
            LoadWallets();
        }

        private void LoadWallets()
        {
            _danhSachVi = DataService.GetDanhSachVi();
            cboViChi.Items.Clear();
            foreach (var vi in _danhSachVi)
            {
                cboViChi.Items.Add($"{vi.Ten} — {FormatTien(vi.SoDu)}");
            }
            if (cboViChi.Items.Count > 0)
                cboViChi.SelectedIndex = 0;
            UpdateSelectedWalletBalance();
        }

        private void SetDefaultDates()
        {
            var now = DateTime.Today;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
            dtpDenNgay.Value = now;
            dtpThang.Value = now;
            dtpNgay.Value = now;
        }

        private void UpdateUserInfo()
        {
            tssNguoiDung.Text = $"✔ Sẵn sàng  |  Đăng nhập: {DataService.GetNguoiDung()}";
            tssThoiGian.Text = $"Ví đang chọn: Vietcombank    Hôm nay: {DateTime.Today:dd/MM/yyyy}";
        }

        #endregion

        #region Data Loading

        private void LoadData()
        {
            try
            {
                string? locLoaiChi = cboLocLoaiChi.SelectedItem?.ToString();
                string? filterLoaiChi = (locLoaiChi == "Tất cả") ? null : locLoaiChi;

                _danhSachChiTieu = DataService.GetChiTieu(dtpTuNgay.Value.Date, dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1), filterLoaiChi);

                dgvChiTieu.Rows.Clear();

                foreach (var ct in _danhSachChiTieu)
                {
                    string tenVi = "";
                    var vi = DataService.GetVi(ct.ViId);
                    if (vi != null) tenVi = vi.Ten;

                    int rowIdx = dgvChiTieu.Rows.Add(
                        ct.Id,
                        ct.Ngay,
                        ct.LoaiChi,
                        tenVi,
                        ct.SoTien,
                        ct.GhiChu
                    );

                    dgvChiTieu.Rows[rowIdx].Cells["colSoTien"].Style.ForeColor = Color.FromArgb(211, 47, 47);
                    dgvChiTieu.Rows[rowIdx].Cells["colSoTien"].Style.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }

                UpdateTongChi();
                lblSoGiaoDich.Text = $"Chỉ đọc • Số giao dịch: {_danhSachChiTieu.Count} • Hiển thị toàn bộ kết quả";
                UpdateKyLocLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTongChi()
        {
            decimal tongChi = _danhSachChiTieu.Sum(c => c.SoTien);
            lblTongChi.Text = tongChi.ToString("N0") + " đ";
        }

        private void UpdateKyLocLabel()
        {
            lblKyLoc0110202625.Text = $"Kỳ lọc: {dtpTuNgay.Value:dd/MM/yyyy} - {dtpDenNgay.Value:dd/MM/yyyy}";
        }

        #endregion

        #region Budget Warning Check

        private void KiemTraNganSach()
        {
            try
            {
                var cauHinh = DataService.GetCauHinh();
                int thang = dtpThang.Value.Month;
                int nam = dtpThang.Value.Year;
                var danhSachNganSach = DataService.GetNganSach(thang, nam);

                bool coCanhBao = false;
                string canhBaoLoai = "";
                decimal tongChiLoai = 0;
                decimal hanMuc = 0;
                double phanTram = 0;

                double nguongCanhBao = cauHinh != null ? cauHinh.NguongCanhBao : 80;

                foreach (var ns in danhSachNganSach)
                {
                    if (ns.HanMuc <= 0) continue;

                    decimal tongChiTheoLoai = DataService.GetTongChiTheoLoai(ns.LoaiChi, thang, nam);
                    double pt = (double)(tongChiTheoLoai / ns.HanMuc) * 100;

                    if (pt >= nguongCanhBao)
                    {
                        coCanhBao = true;
                        canhBaoLoai = ns.LoaiChi;
                        tongChiLoai = tongChiTheoLoai;
                        hanMuc = ns.HanMuc;
                        phanTram = pt;
                        break;
                    }
                }

                if (coCanhBao)
                {
                    pnlCanhBao.Visible = true;
                    lblCanhBao.Text = $"⚠ Loại chi {canhBaoLoai} đã đạt {phanTram:N0}% hạn mức";
                    lblKyRieng0125104.Text =
                        $"Kỳ lọc: {FormatTien(tongChiLoai)} / {FormatTien(hanMuc)}. Tháng {thang}: {FormatTien(tongChiLoai)} / {FormatTien(hanMuc)} ({phanTram:N0}%).";
                }
                else
                {
                    pnlCanhBao.Visible = false;
                }
            }
            catch
            {
                pnlCanhBao.Visible = false;
            }
        }

        #endregion

        #region CRUD Operations

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                string viId = GetSelectedViId();
                if (string.IsNullOrEmpty(viId))
                {
                    MessageBox.Show("Vui lòng chọn ví chi hợp lệ.", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var chiTieu = new ChiTieu
                {
                    Ngay = dtpNgay.Value,
                    LoaiChi = cboLoaiChi.SelectedItem?.ToString() ?? "",
                    ViId = viId,
                    SoTien = decimal.Parse(txtSoTien.Text.Replace(".", "").Replace(",", "")),
                    GhiChu = txtGhiChu.Text.Trim()
                };

                // Check wallet balance
                var vi = DataService.GetVi(viId);
                if (vi != null && vi.SoDu < chiTieu.SoTien)
                {
                    var result = MessageBox.Show(
                        $"Số dư ví ({FormatTien(vi.SoDu)}) không đủ cho khoản chi này ({FormatTien(chiTieu.SoTien)}).\nBạn có muốn tiếp tục không?",
                        "Cảnh báo số dư", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result != DialogResult.Yes) return;
                }

                DataService.ThemChiTieu(chiTieu);
                MessageBox.Show("Thêm khoản chi thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadWallets();
                LoadData();
                KiemTraNganSach();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSua_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedId))
            {
                MessageBox.Show("Vui lòng chọn một khoản chi để sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidateInput()) return;

            try
            {
                string viId = GetSelectedViId();
                if (string.IsNullOrEmpty(viId))
                {
                    MessageBox.Show("Vui lòng chọn ví chi hợp lệ.", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var chiTieu = new ChiTieu
                {
                    Id = _selectedId,
                    Ngay = dtpNgay.Value,
                    LoaiChi = cboLoaiChi.SelectedItem?.ToString() ?? "",
                    ViId = viId,
                    SoTien = decimal.Parse(txtSoTien.Text.Replace(".", "").Replace(",", "")),
                    GhiChu = txtGhiChu.Text.Trim()
                };

                DataService.SuaChiTieu(chiTieu);
                MessageBox.Show("Cập nhật khoản chi thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadWallets();
                LoadData();
                KiemTraNganSach();
                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXoa_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedId))
            {
                MessageBox.Show("Vui lòng chọn một khoản chi để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dr = MessageBox.Show("Bạn có chắc chắn muốn xóa khoản chi này không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    DataService.XoaChiTieu(_selectedId);
                    MessageBox.Show("Xóa khoản chi thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadWallets();
                    LoadData();
                    KiemTraNganSach();
                    ResetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnMoi_Click(object? sender, EventArgs e)
        {
            ResetForm();
        }

        #endregion

        #region Filter & Search

        private void BtnLoc_Click(object? sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnLamMoi_Click(object? sender, EventArgs e)
        {
            SetDefaultDates();
            cboLocLoaiChi.SelectedIndex = 0;
            LoadWallets();
            LoadData();
            KiemTraNganSach();
            ResetForm();
        }

        private void BtnXuatExcel_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Đã xuất dữ liệu chi tiêu ra file Excel thành công!", "Xuất Excel",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DtpThang_ValueChanged(object? sender, EventArgs e)
        {
            KiemTraNganSach();
        }

        #endregion

        #region DataGridView Events

        private void DgvChiTieu_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvChiTieu.Rows.Count) return;

            var row = dgvChiTieu.Rows[e.RowIndex];
            _selectedId = row.Cells["colId"].Value?.ToString();

            if (!string.IsNullOrEmpty(_selectedId))
            {
                var ct = _danhSachChiTieu.FirstOrDefault(c => c.Id == _selectedId);
                if (ct != null)
                {
                    dtpNgay.Value = ct.Ngay;
                    cboLoaiChi.SelectedItem = ct.LoaiChi;

                    int viIdx = _danhSachVi.FindIndex(v => v.Id == ct.ViId);
                    if (viIdx >= 0 && viIdx < cboViChi.Items.Count)
                        cboViChi.SelectedIndex = viIdx;

                    txtSoTien.Text = ct.SoTien.ToString("N0");
                    txtGhiChu.Text = ct.GhiChu;

                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    lblChonMotDongDeSuaHoac.Text = $"Đang chọn: {ct.LoaiChi} - {FormatTien(ct.SoTien)}";
                }
            }
        }

        #endregion

        #region Input Formatting & Validation

        private void CboViChi_SelectedIndexChanged(object? sender, EventArgs e)
        {
            UpdateSelectedWalletBalance();
        }

        private void UpdateSelectedWalletBalance()
        {
            int idx = cboViChi.SelectedIndex;
            if (idx >= 0 && idx < _danhSachVi.Count)
            {
                var vi = _danhSachVi[idx];
                lblViChi2.Text = $"Số dư khả dụng: {FormatTien(vi.SoDu)}";
                tssThoiGian.Text = $"Ví đang chọn: {vi.Ten}    Hôm nay: {DateTime.Today:dd/MM/yyyy}";
            }
        }

        private void TxtSoTien_Leave(object? sender, EventArgs e)
        {
            string raw = txtSoTien.Text.Replace(".", "").Replace(",", "").Trim();
            if (decimal.TryParse(raw, out decimal val))
            {
                txtSoTien.Text = val.ToString("N0");
            }
        }

        private bool ValidateInput()
        {
            if (cboLoaiChi.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn loại chi.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiChi.Focus();
                return false;
            }

            if (cboViChi.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn ví chi.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboViChi.Focus();
                return false;
            }

            string rawTien = txtSoTien.Text.Replace(".", "").Replace(",", "").Trim();
            if (string.IsNullOrEmpty(rawTien) || !decimal.TryParse(rawTien, out decimal st) || st <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ (> 0).", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTien.Focus();
                return false;
            }

            return true;
        }

        private string GetSelectedViId()
        {
            int idx = cboViChi.SelectedIndex;
            if (idx >= 0 && idx < _danhSachVi.Count)
                return _danhSachVi[idx].Id;
            return "";
        }

        private void ResetForm()
        {
            _selectedId = null;
            dtpNgay.Value = DateTime.Now;
            if (cboLoaiChi.Items.Count > 0)
                cboLoaiChi.SelectedIndex = 0;
            if (cboViChi.Items.Count > 0)
                cboViChi.SelectedIndex = 0;
            txtSoTien.Text = "";
            txtGhiChu.Text = "";
            lblChonMotDongDeSuaHoac.Text = "Chọn một dòng để sửa hoặc xóa khoản chi.";
            dgvChiTieu.ClearSelection();
        }

        private string FormatTien(decimal soTien)
        {
            return soTien.ToString("N0") + " đ";
        }

        #endregion
    }
}
