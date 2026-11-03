using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LTWIN_N05_QLCT.Models;
using LTWIN_N05_QLCT.Services;

namespace LTWIN_N05_QLCT.Forms.NghiepVu
{
    public partial class frmTimKiem : Form, IDongBoThang
    {
        private List<Vi> _danhSachVi = new List<Vi>();

        private bool _isDataLoaded = false;
        private void NapDuLieuAnToan()
        {
            if (_isDataLoaded || !global::NghiepVu.TienIch.PhienDangNhap.DaDangNhap) return;
            _isDataLoaded = true;
            LoadFilterData();
            ThucHienTimKiem();
        }

        public frmTimKiem()
        {
            InitializeComponent();
            SetupEvents();
            this.Load += (s, e) => NapDuLieuAnToan();
        }

        public void DongBoThang(DateTime thang)
        {
            dtpTuNgay.Value = new DateTime(thang.Year, thang.Month, 1);
            dtpDenNgay.Value = new DateTime(thang.Year, thang.Month, DateTime.DaysInMonth(thang.Year, thang.Month));
            ThucHienTimKiem();
        }

        private void SetupEvents()
        {
            this.btnTim.Click += (s, e) => ThucHienTimKiem();
            this.btnXoaLoc.Click += (s, e) => XoaLoc();
            this.btnXuatExcel.Click += (s, e) =>
            {
                XuatExcelHelper.XuatDataGridViewRaExcel(this.dgvKetQua, "KetQuaTimKiem", "Báo cáo kết quả tìm kiếm giao dịch");
            };

            this.txtTienTu.Leave += (s, e) => FormatMoneyInput(txtTienTu);
            this.txtTienDen.Leave += (s, e) => FormatMoneyInput(txtTienDen);
        }

        private void LoadFilterData()
        {
            cboLoaiGiaoDich.SelectedIndex = 0; // Tất cả

            var now = DateTime.Today;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
            dtpDenNgay.Value = now;

            try { _danhSachVi = DataService.GetDanhSachVi(); } catch { _danhSachVi = new List<Vi>(); }
            cboVi.Items.Clear();
            cboVi.Items.Add("Tất cả");
            foreach (var v in _danhSachVi)
            {
                cboVi.Items.Add(v.Ten);
            }
            cboVi.SelectedIndex = 0;

            cboLoai.Items.Clear();
            cboLoai.Items.Add("Tất cả");
            foreach (var lt in DataService.DanhSachLoaiThu) cboLoai.Items.Add(lt);
            foreach (var lc in DataService.DanhSachLoaiChi) cboLoai.Items.Add(lc);
            cboLoai.SelectedIndex = 0;

            txtTienTu.Text = "";
            txtTienDen.Text = "";
        }

        private void FormatMoneyInput(TextBox tb)
        {
            string raw = tb.Text.Replace(".", "").Replace(",", "").Trim();
            decimal val;
            if (decimal.TryParse(raw, out val))
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

        public void ThucHienTimKiem()
        {
            string tuKhoa = string.IsNullOrWhiteSpace(txtTuKhoa.Text) ? null : txtTuKhoa.Text.Trim();
            string loaiGD = cboLoaiGiaoDich.SelectedItem != null ? cboLoaiGiaoDich.SelectedItem.ToString() : null;
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);

            decimal? tienTu = null;
            string rawTu = txtTienTu.Text.Replace(".", "").Replace(",", "").Trim();
            decimal valTu;
            if (decimal.TryParse(rawTu, out valTu)) tienTu = valTu;

            decimal? tienDen = null;
            string rawDen = txtTienDen.Text.Replace(".", "").Replace(",", "").Trim();
            decimal valDen;
            if (decimal.TryParse(rawDen, out valDen)) tienDen = valDen;

            string loai = cboLoai.SelectedItem != null ? cboLoai.SelectedItem.ToString() : null;
            string selectedViTen = cboVi.SelectedItem != null ? cboVi.SelectedItem.ToString() : null;
            string viId = null;
            if (selectedViTen != null && selectedViTen != "Tất cả")
            {
                var vi = _danhSachVi.FirstOrDefault(v => v.Ten == selectedViTen);
                if (vi != null) viId = vi.Id;
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

            lblKetQuaTimKiem5Giao.Text = string.Format("Kết quả tìm kiếm — {0} giao dịch", results.Count);
            lblHienThi155Chi.Text = string.Format("Hiển thị 1-{0} / {0} • Chỉ đọc", results.Count);

            lblTongThu25000000.Text = string.Format("Tổng thu: {0:N0} đ", tongThu);
            lblTongChi8100000.Text = string.Format("Tổng chi: {0:N0} đ", tongChi);
            decimal chenhLech = tongThu - tongChi;
            lblChenhLechThuChi16900.Text = string.Format("Chênh lệch thu – chi: {0:N0} đ", chenhLech);
            lblChenhLechThuChi16900.ForeColor = chenhLech >= 0 ? Color.FromArgb(21, 101, 192) : Color.FromArgb(211, 47, 47);
        }
    }
}
