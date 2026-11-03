using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LTWIN_N05_QLCT.Models;
using LTWIN_N05_QLCT.Services;

namespace LTWIN_N05_QLCT.Forms.NghiepVu
{
    public partial class frmChuyenTien : Form, IDongBoThang
    {
        private List<Vi> _danhSachVi = new List<Vi>();
        private List<ChuyenTienRecord> _danhSachChuyenTien = new List<ChuyenTienRecord>();
        private DateTime _thangHienTai = DateTime.Today;

        public frmChuyenTien()
        {
            InitializeComponent();
            SetupEvents();
            SetupDataGridView();
            if (!IsDesignMode() && global::NghiepVu.TienIch.PhienDangNhap.DaDangNhap)
            {
                LoadWallets();
                LoadLichSu();
            }
            this.Load += (s, e) =>
            {
                if (!IsDesignMode() && global::NghiepVu.TienIch.PhienDangNhap.DaDangNhap && cboViNguon.Items.Count == 0)
                {
                    LoadWallets();
                    LoadLichSu();
                }
            };
        }

        private bool IsDesignMode()
        {
            return DesignMode || (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime);
        }

        public void DongBoThang(DateTime thang)
        {
            _thangHienTai = thang;
            if (thang.Month == DateTime.Today.Month && thang.Year == DateTime.Today.Year)
            {
                dtpNgay.Value = DateTime.Today;
            }
            else
            {
                dtpNgay.Value = new DateTime(thang.Year, thang.Month, 1);
            }
            LoadLichSu();
        }

        private void SetupEvents()
        {
            this.btnChuyenTien.Click += BtnChuyenTien_Click;
            this.btnMoi.Click += (s, e) => ResetForm();

            this.cboViNguon.SelectedIndexChanged += (s, e) => UpdatePreview();
            this.cboViDich.SelectedIndexChanged += (s, e) => UpdatePreview();
            this.txtSoTien.TextChanged += (s, e) => UpdatePreview();
            this.txtSoTien.Leave += (s, e) => FormatMoneyInput();
        }

        private void SetupDataGridView()
        {
            if (dgvLichSuChuyenTien.Columns.Count > 0)
            {
                dgvLichSuChuyenTien.AutoGenerateColumns = false;
                dgvLichSuChuyenTien.AllowUserToAddRows = false;
                dgvLichSuChuyenTien.RowHeadersVisible = false;
                dgvLichSuChuyenTien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvLichSuChuyenTien.ReadOnly = true;
                dgvLichSuChuyenTien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvLichSuChuyenTien.BackgroundColor = Color.White;
                return;
            }
            dgvLichSuChuyenTien.Columns.Clear();
            dgvLichSuChuyenTien.AutoGenerateColumns = false;
            dgvLichSuChuyenTien.AllowUserToAddRows = false;
            dgvLichSuChuyenTien.RowHeadersVisible = false;
            dgvLichSuChuyenTien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLichSuChuyenTien.ReadOnly = true;
            dgvLichSuChuyenTien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichSuChuyenTien.BackgroundColor = Color.White;

            dgvLichSuChuyenTien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNgay",
                HeaderText = "Ngày",
                FillWeight = 85
            });

            dgvLichSuChuyenTien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colViNguon",
                HeaderText = "Ví nguồn",
                FillWeight = 95
            });

            dgvLichSuChuyenTien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colViDich",
                HeaderText = "Ví đích",
                FillWeight = 95
            });

            var colSoTien = new DataGridViewTextBoxColumn
            {
                Name = "colSoTien",
                HeaderText = "Số tiền",
                FillWeight = 95,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    ForeColor = Color.FromArgb(245, 124, 0),
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                }
            };
            dgvLichSuChuyenTien.Columns.Add(colSoTien);

            dgvLichSuChuyenTien.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colGhiChu",
                HeaderText = "Ghi chú",
                FillWeight = 160
            });
        }

        public void LoadWallets()
        {
            try { _danhSachVi = DataService.GetDanhSachVi(); } catch { _danhSachVi = new List<Vi>(); }
            cboViNguon.Items.Clear();
            cboViDich.Items.Clear();

            foreach (var v in _danhSachVi)
            {
                string text = string.Format("{0} — Số dư: {1:N0} đ", v.Ten, v.SoDu);
                cboViNguon.Items.Add(text);
                cboViDich.Items.Add(text);
            }

            if (cboViNguon.Items.Count > 0) cboViNguon.SelectedIndex = 0;
            if (cboViDich.Items.Count > 1) cboViDich.SelectedIndex = 1;

            UpdatePreview();
        }

        public void LoadLichSu()
        {
            List<ChuyenTienRecord> tatCa;
            try { tatCa = DataService.GetChuyenTien(); } catch { tatCa = new List<ChuyenTienRecord>(); }
            // Lọc theo tháng đang chọn của ứng dụng (đồng bộ tháng)
            _danhSachChuyenTien = tatCa
                .Where(x => x.Ngay.Month == _thangHienTai.Month && x.Ngay.Year == _thangHienTai.Year)
                .ToList();

            dgvLichSuChuyenTien.Rows.Clear();

            decimal tongChuyen = 0;
            foreach (var ct in _danhSachChuyenTien)
            {
                var viNguon = _danhSachVi.FirstOrDefault(v => v.Id == ct.ViNguonId);
                var viDich = _danhSachVi.FirstOrDefault(v => v.Id == ct.ViDichId);

                dgvLichSuChuyenTien.Rows.Add(
                    ct.Ngay.ToString("dd/MM/yyyy"),
                    viNguon != null ? viNguon.Ten : ct.ViNguonId,
                    viDich != null ? viDich.Ten : ct.ViDichId,
                    ct.SoTien.ToString("N0") + " đ",
                    ct.GhiChu
                );
                tongChuyen += ct.SoTien;
            }

            lblSoGiaoDich.Text = string.Format("Chỉ đọc • {0} giao dịch trong tháng {1:MM/yyyy} • Tổng số tiền đã chuyển: {2:N0} đ",
                _danhSachChuyenTien.Count, _thangHienTai, tongChuyen);
        }

        private void UpdatePreview()
        {
            if (cboViNguon.SelectedIndex < 0 || cboViDich.SelectedIndex < 0 ||
                cboViNguon.SelectedIndex >= _danhSachVi.Count || cboViDich.SelectedIndex >= _danhSachVi.Count)
            {
                lblSauKhiChuyenDuKienVietcombank.Text = "Sau khi chuyển dự kiến: —";
                return;
            }

            var viNguon = _danhSachVi[cboViNguon.SelectedIndex];
            var viDich = _danhSachVi[cboViDich.SelectedIndex];

            string raw = txtSoTien.Text.Replace(".", "").Replace(",", "").Trim();
            decimal soTien;
            if (decimal.TryParse(raw, out soTien) && soTien > 0)
            {
                decimal nguonMoi = viNguon.SoDu - soTien;
                decimal dichMoi = viDich.SoDu + soTien;
                lblSauKhiChuyenDuKienVietcombank.Text = string.Format("Sau khi chuyển dự kiến: {0} {1:N0} đ • {2} {3:N0} đ",
                    viNguon.Ten, nguonMoi, viDich.Ten, dichMoi);
            }
            else
            {
                lblSauKhiChuyenDuKienVietcombank.Text = string.Format("Sau khi chuyển dự kiến: {0} {1:N0} đ • {2} {3:N0} đ",
                    viNguon.Ten, viNguon.SoDu, viDich.Ten, viDich.SoDu);
            }
        }

        private void FormatMoneyInput()
        {
            string raw = txtSoTien.Text.Replace(".", "").Replace(",", "").Trim();
            decimal val;
            if (decimal.TryParse(raw, out val))
            {
                txtSoTien.Text = val.ToString("N0");
            }
        }

        private void BtnChuyenTien_Click(object sender, EventArgs e)
        {
            int idxNguon = cboViNguon.SelectedIndex;
            int idxDich = cboViDich.SelectedIndex;

            if (idxNguon < 0 || idxDich < 0)
            {
                MessageBox.Show("Vui lòng chọn ví nguồn và ví đích!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (idxNguon == idxDich)
            {
                MessageBox.Show("Ví nguồn và ví đích không được trùng nhau!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string raw = txtSoTien.Text.Replace(".", "").Replace(",", "").Trim();
            decimal soTien;
            if (!decimal.TryParse(raw, out soTien) || soTien <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền chuyển hợp lệ (> 0)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTien.Focus();
                return;
            }

            var viNguon = _danhSachVi[idxNguon];
            if (viNguon.SoDu < soTien)
            {
                MessageBox.Show(string.Format("Số dư của ví {0} ({1:N0} đ) không đủ để thực hiện chuyển {2:N0} đ!",
                    viNguon.Ten, viNguon.SoDu, soTien), "Không đủ số dư", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var record = new ChuyenTienRecord
            {
                Ngay = dtpNgay.Value,
                ViNguonId = viNguon.Id,
                ViDichId = _danhSachVi[idxDich].Id,
                SoTien = soTien,
                GhiChu = txtGhiChu.Text.Trim()
            };

            bool success = DataService.ChuyenTien(record);
            if (success)
            {
                MessageBox.Show("Chuyển tiền thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadWallets();
                LoadLichSu();
                ResetForm();
            }
            else
            {
                MessageBox.Show("Giao dịch chuyển tiền thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            if (_thangHienTai.Month == DateTime.Today.Month && _thangHienTai.Year == DateTime.Today.Year)
            {
                dtpNgay.Value = DateTime.Today;
            }
            else
            {
                dtpNgay.Value = new DateTime(_thangHienTai.Year, _thangHienTai.Month, 1);
            }
            txtSoTien.Text = "";
            txtGhiChu.Text = "";
            if (cboViNguon.Items.Count > 0) cboViNguon.SelectedIndex = 0;
            if (cboViDich.Items.Count > 1) cboViDich.SelectedIndex = 1;
            UpdatePreview();
        }
    }
}
