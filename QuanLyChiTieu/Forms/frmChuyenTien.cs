using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyChiTieu.Models;
using QuanLyChiTieu.Services;

namespace QuanLyChiTieu.Forms
{
    public partial class frmChuyenTien : Form
    {
        private List<Vi> _danhSachVi = new();
        private List<ChuyenTienRecord> _danhSachChuyenTien = new();

        public frmChuyenTien()
        {
            InitializeComponent();
            SetupEvents();
            SetupDataGridView();
            LoadWallets();
            LoadLichSu();
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
            this.btnLamMoi.Click += (s, e) => { LoadWallets(); LoadLichSu(); };

            // Menu
            var mnuCauHinh = new ToolStripMenuItem("Cấu hình", null, (s, e) => NavigateTo<frmCauHinh>());
            var mnuThoat = new ToolStripMenuItem("Thoát", null, (s, e) => Application.Exit());
            this.mnuHeThong.DropDownItems.Clear();
            this.mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] { mnuCauHinh, mnuThoat });

            var mnuThuNhap = new ToolStripMenuItem("Quản lý thu nhập", null, (s, e) => NavigateTo<frmQuanLyThuNhap>());
            var mnuChiTieu = new ToolStripMenuItem("Quản lý chi tiêu", null, (s, e) => NavigateTo<frmQuanLyChiTieu>());
            var mnuNganSach = new ToolStripMenuItem("Ngân sách", null, (s, e) => NavigateTo<frmNganSach>());
            var mnuChuyenTienItem = new ToolStripMenuItem("Chuyển tiền giữa các ví", null, (s, e) => { });
            var mnuTimKiem = new ToolStripMenuItem("Tìm kiếm giao dịch", null, (s, e) => NavigateTo<frmTimKiem>());
            this.mnuNghiepVu.DropDownItems.Clear();
            this.mnuNghiepVu.DropDownItems.AddRange(new ToolStripItem[] { mnuThuNhap, mnuChiTieu, mnuNganSach, mnuChuyenTienItem, mnuTimKiem });

            // Form actions
            this.btnChuyenTien.Click += BtnChuyenTien_Click;
            this.btnMoi.Click += (s, e) => ResetForm();

            this.cboViNguon.SelectedIndexChanged += (s, e) => UpdatePreview();
            this.cboViDich.SelectedIndexChanged += (s, e) => UpdatePreview();
            this.txtSoTien.TextChanged += (s, e) => UpdatePreview();
            this.txtSoTien.Leave += (s, e) => FormatMoneyInput();

            tslTrangThai.Text = $"✔ Sẵn sàng  |  Đăng nhập: {DataService.GetNguoiDung()}      Ví đang chọn: Vietcombank      Hôm nay: {DateTime.Today:dd/MM/yyyy}";
        }

        private void SetupDataGridView()
        {
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

        private void LoadWallets()
        {
            _danhSachVi = DataService.GetDanhSachVi();
            cboViNguon.Items.Clear();
            cboViDich.Items.Clear();

            foreach (var v in _danhSachVi)
            {
                string text = $"{v.Ten} — Số dư: {v.SoDu:N0} đ";
                cboViNguon.Items.Add(text);
                cboViDich.Items.Add(text);
            }

            if (cboViNguon.Items.Count > 0) cboViNguon.SelectedIndex = 0;
            if (cboViDich.Items.Count > 1) cboViDich.SelectedIndex = 1;

            UpdatePreview();
        }

        private void LoadLichSu()
        {
            _danhSachChuyenTien = DataService.GetChuyenTien();
            dgvLichSuChuyenTien.Rows.Clear();

            decimal tongChuyen = 0;
            foreach (var ct in _danhSachChuyenTien)
            {
                var viNguon = _danhSachVi.FirstOrDefault(v => v.Id == ct.ViNguonId);
                var viDich = _danhSachVi.FirstOrDefault(v => v.Id == ct.ViDichId);

                dgvLichSuChuyenTien.Rows.Add(
                    ct.Ngay.ToString("dd/MM/yyyy"),
                    viNguon?.Ten ?? ct.ViNguonId,
                    viDich?.Ten ?? ct.ViDichId,
                    ct.SoTien.ToString("N0") + " đ",
                    ct.GhiChu
                );
                tongChuyen += ct.SoTien;
            }

            lblSoGiaoDich.Text = $"Chỉ đọc • {_danhSachChuyenTien.Count} giao dịch • Tổng số tiền đã chuyển: {tongChuyen:N0} đ";
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
            if (decimal.TryParse(raw, out decimal soTien) && soTien > 0)
            {
                decimal nguonMoi = viNguon.SoDu - soTien;
                decimal dichMoi = viDich.SoDu + soTien;
                lblSauKhiChuyenDuKienVietcombank.Text = $"Sau khi chuyển dự kiến: {viNguon.Ten} {nguonMoi:N0} đ • {viDich.Ten} {dichMoi:N0} đ";
            }
            else
            {
                lblSauKhiChuyenDuKienVietcombank.Text = $"Sau khi chuyển dự kiến: {viNguon.Ten} {viNguon.SoDu:N0} đ • {viDich.Ten} {viDich.SoDu:N0} đ";
            }
        }

        private void FormatMoneyInput()
        {
            string raw = txtSoTien.Text.Replace(".", "").Replace(",", "").Trim();
            if (decimal.TryParse(raw, out decimal val))
            {
                txtSoTien.Text = val.ToString("N0");
            }
        }

        private void BtnChuyenTien_Click(object? sender, EventArgs e)
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
            if (!decimal.TryParse(raw, out decimal soTien) || soTien <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền chuyển hợp lệ (> 0)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTien.Focus();
                return;
            }

            var viNguon = _danhSachVi[idxNguon];
            if (viNguon.SoDu < soTien)
            {
                MessageBox.Show($"Số dư của ví {viNguon.Ten} ({viNguon.SoDu:N0} đ) không đủ để thực hiện chuyển {soTien:N0} đ!", "Không đủ số dư", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dtpNgay.Value = DateTime.Today;
            txtSoTien.Text = "";
            txtGhiChu.Text = "";
            if (cboViNguon.Items.Count > 0) cboViNguon.SelectedIndex = 0;
            if (cboViDich.Items.Count > 1) cboViDich.SelectedIndex = 1;
            UpdatePreview();
        }
    }
}
