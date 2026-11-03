using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LTWIN_N05_QLCT.Models;
using LTWIN_N05_QLCT.Services;

namespace LTWIN_N05_QLCT.Forms.NghiepVu
{
    public partial class frmQuanLyChiTieu : Form, IDongBoThang
    {
        private string _selectedId = null;
        private List<ChiTieu> _danhSachChiTieu = new List<ChiTieu>();
        private List<Vi> _danhSachVi = new List<Vi>();

        public void DongBoThang(DateTime thang)
        {
            dtpTuNgay.Value = new DateTime(thang.Year, thang.Month, 1);
            dtpDenNgay.Value = new DateTime(thang.Year, thang.Month, DateTime.DaysInMonth(thang.Year, thang.Month));
            if (thang.Month == DateTime.Today.Month && thang.Year == DateTime.Today.Year)
                dtpNgay.Value = DateTime.Today;
            else
                dtpNgay.Value = dtpTuNgay.Value;

            LoadData();
            KiemTraNganSach();
        }

        private bool _isDataLoaded = false;
        private void NapDuLieuAnToan()
        {
            if (_isDataLoaded || !global::NghiepVu.TienIch.PhienDangNhap.DaDangNhap) return;
            _isDataLoaded = true;
            LoadComboBoxes();
            LoadData();
            KiemTraNganSach();
        }

        public frmQuanLyChiTieu()
        {
            InitializeComponent();
            SetupEvents();
            SetupDataGridViewColumns();
            SetDefaultDates();
            this.Load += (s, e) => NapDuLieuAnToan();
        }

        #region Setup

        private void SetupEvents()
        {
            // CRUD
            this.btnThem.Click += BtnThem_Click;
            this.btnSua.Click += BtnSua_Click;
            this.btnXoa.Click += BtnXoa_Click;
            this.btnMoi.Click += BtnMoi_Click;

            // Filter & export
            this.btnLoc.Click += BtnLoc_Click;
            this.btnXuatExcel.Click += BtnXuatExcel_Click;

            // Grid selection
            this.dgvChiTieu.CellClick += DgvChiTieu_CellClick;

            // Wallet selection change
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
            cboLoaiChi.Items.Clear();
            cboLoaiChi.Items.AddRange(DataService.DanhSachLoaiChi);
            if (cboLoaiChi.Items.Count > 0)
                cboLoaiChi.SelectedIndex = 0;

            cboLocLoaiChi.Items.Clear();
            cboLocLoaiChi.Items.Add("Tất cả");
            cboLocLoaiChi.Items.AddRange(DataService.DanhSachLoaiChi);
            cboLocLoaiChi.SelectedIndex = 0;

            LoadWallets();
        }

        private void LoadWallets()
        {
            try { _danhSachVi = DataService.GetDanhSachVi(); } catch { _danhSachVi = new List<Vi>(); }
            cboViChi.Items.Clear();
            foreach (var vi in _danhSachVi)
            {
                cboViChi.Items.Add(string.Format("{0} — {1}", vi.Ten, FormatTien(vi.SoDu)));
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
            dtpNgay.Value = now;
        }

        #endregion

        #region Data Loading

        public void LoadData()
        {
            try
            {
                string locLoaiChi = cboLocLoaiChi.SelectedItem != null ? cboLocLoaiChi.SelectedItem.ToString() : null;
                string filterLoaiChi = (locLoaiChi == "Tất cả") ? null : locLoaiChi;

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
                lblSoGiaoDich.Text = string.Format("Chỉ đọc • Số giao dịch: {0} • Hiển thị toàn bộ kết quả", _danhSachChiTieu.Count);
                UpdateKyLocLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Lỗi khi tải dữ liệu: {0}", ex.Message), "Lỗi",
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
            lblKyLoc0110202625.Text = string.Format("Kỳ lọc: {0:dd/MM/yyyy} - {1:dd/MM/yyyy} • Tất cả các ví", dtpTuNgay.Value, dtpDenNgay.Value);
        }

        #endregion

        #region Budget Warning Check

        public void KiemTraNganSach()
        {
            try
            {
                var cauHinh = DataService.GetCauHinh();
                int thang = dtpNgay.Value.Month;
                int nam = dtpNgay.Value.Year;
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
                    lblCanhBao.Text = string.Format("⚠ Loại chi {0} đã đạt {1:N0}% hạn mức", canhBaoLoai, phanTram);
                    lblKyRieng0125104.Text = string.Format("Kỳ lọc: {0} / {1}. Tháng {2}: {0} / {1} ({3:N0}%).",
                        FormatTien(tongChiLoai), FormatTien(hanMuc), thang, phanTram);
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

        private void BtnThem_Click(object sender, EventArgs e)
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
                    LoaiChi = cboLoaiChi.SelectedItem != null ? cboLoaiChi.SelectedItem.ToString() : "",
                    ViId = viId,
                    SoTien = decimal.Parse(txtSoTien.Text.Replace(".", "").Replace(",", "")),
                    GhiChu = txtGhiChu.Text.Trim()
                };

                // Check wallet balance
                var vi = DataService.GetVi(viId);
                if (vi != null && vi.SoDu < chiTieu.SoTien)
                {
                    var result = MessageBox.Show(
                        string.Format("Số dư ví ({0}) không đủ cho khoản chi này ({1}).\nBạn có muốn tiếp tục không?",
                            FormatTien(vi.SoDu), FormatTien(chiTieu.SoTien)),
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
                MessageBox.Show(string.Format("Lỗi khi thêm: {0}", ex.Message), "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
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
                    LoaiChi = cboLoaiChi.SelectedItem != null ? cboLoaiChi.SelectedItem.ToString() : "",
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
                MessageBox.Show(string.Format("Lỗi khi sửa: {0}", ex.Message), "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
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
                    MessageBox.Show(string.Format("Lỗi khi xóa: {0}", ex.Message), "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnMoi_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        #endregion

        #region Filter & Search

        private void BtnLoc_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnXuatExcel_Click(object sender, EventArgs e)
        {
            XuatExcelHelper.XuatDataGridViewRaExcel(this.dgvChiTieu, "DanhSachChiTieu", "Báo cáo danh sách chi tiêu");
        }

        #endregion

        #region DataGridView Events

        private void DgvChiTieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvChiTieu.Rows.Count) return;

            var row = dgvChiTieu.Rows[e.RowIndex];
            _selectedId = row.Cells["colId"].Value != null ? row.Cells["colId"].Value.ToString() : null;

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
                    lblChonMotDongDeSuaHoac.Text = string.Format("Đang chọn: {0} - {1}", ct.LoaiChi, FormatTien(ct.SoTien));
                }
            }
        }

        #endregion

        #region Input Formatting & Validation

        private void CboViChi_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSelectedWalletBalance();
        }

        private void UpdateSelectedWalletBalance()
        {
            int idx = cboViChi.SelectedIndex;
            if (idx >= 0 && idx < _danhSachVi.Count)
            {
                var vi = _danhSachVi[idx];
                lblViChi2.Text = string.Format("Số dư khả dụng: {0}", FormatTien(vi.SoDu));
            }
        }

        private void TxtSoTien_Leave(object sender, EventArgs e)
        {
            string raw = txtSoTien.Text.Replace(".", "").Replace(",", "").Trim();
            decimal val;
            if (decimal.TryParse(raw, out val))
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
            decimal st;
            if (string.IsNullOrEmpty(rawTien) || !decimal.TryParse(rawTien, out st) || st <= 0)
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
