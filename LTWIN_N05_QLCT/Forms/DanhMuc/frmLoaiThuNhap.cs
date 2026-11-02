using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using NghiepVu;
using NghiepVu.TienIch;

namespace LTWIN_N05_QLCT.Forms.DanhMuc
{
    public partial class frmLoaiThuNhap : Form
    {
        private static readonly Color MauXanh = Color.FromArgb(21, 101, 192);
        private static readonly Color MauVien = Color.FromArgb(203, 213, 225);
        private static readonly Color MauChu = Color.FromArgb(30, 41, 59);
        private static readonly Color MauNenXen = Color.FromArgb(248, 250, 252);
        private static readonly Color MauDo = Color.FromArgb(198, 40, 40);
        private static readonly Color MauXanhLa = Color.FromArgb(46, 125, 50);

        private DataTable tblLoaiThu;
        private bool _dangNapDuLieu;
        private int _maDangChon;

        public frmLoaiThuNhap()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            CauHinhLuoi();
        }

        private void CauHinhLuoi()
        {
            dgvLoaiThu.BackgroundColor = Color.White;
            dgvLoaiThu.BorderStyle = BorderStyle.None;
            dgvLoaiThu.RowHeadersVisible = false;
            dgvLoaiThu.EnableHeadersVisualStyles = false;
            dgvLoaiThu.GridColor = Color.FromArgb(226, 232, 240);
            dgvLoaiThu.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLoaiThu.ColumnHeadersHeight = 36;
            dgvLoaiThu.RowTemplate.Height = 30;
            dgvLoaiThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvLoaiThu.ColumnHeadersDefaultCellStyle.BackColor = MauXanh;
            dgvLoaiThu.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLoaiThu.ColumnHeadersDefaultCellStyle.SelectionBackColor = MauXanh;
            dgvLoaiThu.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvLoaiThu.DefaultCellStyle.ForeColor = MauChu;
            dgvLoaiThu.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvLoaiThu.DefaultCellStyle.SelectionForeColor = MauChu;
            dgvLoaiThu.AlternatingRowsDefaultCellStyle.BackColor = MauNenXen;
            dgvLoaiThu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoaiThu.MultiSelect = false;

            dgvLoaiThu.CellFormatting += dgvLoaiThu_CellFormatting;
            dgvLoaiThu.DataError += (s, e) => { e.ThrowException = false; };
        }

        private void frmLoaiThuNhap_Load(object sender, EventArgs e)
        {
            if (!PhienDangNhap.DaDangNhap)
            {
                HienThongBao("Bạn cần đăng nhập để quản lý loại thu nhập.", true);
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnNgungSuDung.Enabled = false;
                return;
            }
            LoadDataGridView();
            ResetValues();
        }

        private void LoadDataGridView()
        {
            _dangNapDuLieu = true;
            try
            {
                string loi;
                tblLoaiThu = LoaiThuNV.LayDanhSach(out loi);
                if (!string.IsNullOrEmpty(loi))
                {
                    HienThongBao(loi, true);
                }
                dgvLoaiThu.DataSource = tblLoaiThu;
                DinhDangCot();
                CapNhatThongKe();
                dgvLoaiThu.ClearSelection();
            }
            finally
            {
                _dangNapDuLieu = false;
            }
        }

        private void DinhDangCot()
        {
            if (dgvLoaiThu.Columns["MaLoaiThu"] != null) dgvLoaiThu.Columns["MaLoaiThu"].Visible = false;

            DatCot("TenLoaiThu", "Tên loại thu", 35);
            DatCot("GhiChu", "Ghi chú", 45);
            DatCot("TrangThai", "Trạng thái", 20);
        }

        private void DatCot(string ten, string tieuDe, float tyLe)
        {
            DataGridViewColumn cot = dgvLoaiThu.Columns[ten];
            if (cot == null) return;
            cot.HeaderText = tieuDe;
            cot.FillWeight = tyLe;
        }

        private void dgvLoaiThu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null || e.Value == DBNull.Value) return;
            if (dgvLoaiThu.Columns[e.ColumnIndex].Name == "TrangThai")
            {
                if (bool.TryParse(e.Value.ToString(), out bool trangThai))
                {
                    e.Value = trangThai ? "Đang sử dụng" : "Ngừng sử dụng";
                    e.FormattingApplied = true;
                }
            }
        }

        private void dgvLoaiThu_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangNapDuLieu) return;
            if (dgvLoaiThu.CurrentRow == null || dgvLoaiThu.SelectedRows.Count == 0) return;

            var dong = dgvLoaiThu.CurrentRow.DataBoundItem as DataRowView;
            if (dong == null) return;

            lblThongBao.Visible = false;
            _maDangChon = dong["MaLoaiThu"] != DBNull.Value ? Convert.ToInt32(dong["MaLoaiThu"]) : 0;
            string tenLoai = dong["TenLoaiThu"] != DBNull.Value ? dong["TenLoaiThu"].ToString() : "";

            lblDangChon.Text = "Đang chọn: " + tenLoai;
            txtTenLoaiThu.Text = tenLoai;
            txtGhiChu.Text = dong["GhiChu"] != DBNull.Value ? dong["GhiChu"].ToString() : "";

            bool trangThai = dong["TrangThai"] != DBNull.Value && Convert.ToBoolean(dong["TrangThai"]);
            lblTrangThaiGiaTri.Text = trangThai ? "Đang sử dụng" : "Ngừng sử dụng";
        }

        private void ResetValues()
        {
            _maDangChon = 0;
            lblDangChon.Text = "Đang chọn: (chưa chọn)";
            txtTenLoaiThu.Text = "";
            txtGhiChu.Text = "";
            lblTrangThaiGiaTri.Text = "Đang sử dụng";
            dgvLoaiThu.ClearSelection();
        }

        private void CapNhatThongKe()
        {
            if (tblLoaiThu == null) return;
            int tong = tblLoaiThu.Rows.Count;
            int dangSD = 0;
            int ngungSD = 0;

            foreach (DataRow r in tblLoaiThu.Rows)
            {
                if (r["TrangThai"] != DBNull.Value && Convert.ToBoolean(r["TrangThai"]))
                    dangSD++;
                else
                    ngungSD++;
            }

            lblThongKe.Text = $"{tong} loại thu nhập • {dangSD} đang sử dụng, {ngungSD} ngừng sử dụng";
        }

        private void HienThongBao(string thongDiep, bool laLoi)
        {
            lblThongBao.Text = thongDiep;
            lblThongBao.ForeColor = laLoi ? MauDo : MauXanhLa;
            lblThongBao.Visible = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            lblThongBao.Visible = false;
            if (!KiemTraNhap()) return;

            var kq = LoaiThuNV.Them(txtTenLoaiThu.Text.Trim(), txtGhiChu.Text.Trim(), true);
            if (!kq.ThanhCong)
            {
                HienThongBao(kq.ThongBao, true);
                return;
            }

            LoadDataGridView();
            ResetValues();
            HienThongBao("✓ Thêm loại thu nhập thành công!", false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            lblThongBao.Visible = false;
            if (_maDangChon <= 0)
            {
                HienThongBao("Vui lòng chọn loại thu nhập cần sửa.", true);
                return;
            }
            if (!KiemTraNhap()) return;

            bool trangThaiHienTai = lblTrangThaiGiaTri.Text == "Đang sử dụng";
            var kq = LoaiThuNV.Sua(_maDangChon, txtTenLoaiThu.Text.Trim(), txtGhiChu.Text.Trim(), trangThaiHienTai);
            if (!kq.ThanhCong)
            {
                HienThongBao(kq.ThongBao, true);
                return;
            }

            LoadDataGridView();
            ResetValues();
            HienThongBao("✓ Cập nhật loại thu nhập thành công!", false);
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            ResetValues();
            lblThongBao.Visible = false;
        }

        private void btnNgungSuDung_Click(object sender, EventArgs e)
        {
            lblThongBao.Visible = false;
            if (_maDangChon <= 0)
            {
                HienThongBao("Vui lòng chọn loại thu nhập cần ngừng sử dụng.", true);
                return;
            }

            var kq = LoaiThuNV.Sua(_maDangChon, txtTenLoaiThu.Text.Trim(), txtGhiChu.Text.Trim(), false);
            if (kq.ThanhCong)
            {
                LoadDataGridView();
                ResetValues();
                HienThongBao("✓ Đã chuyển trạng thái sang ngừng sử dụng.", false);
            }
            else
            {
                HienThongBao(kq.ThongBao, true);
            }
        }

        private bool KiemTraNhap()
        {
            if (string.IsNullOrWhiteSpace(txtTenLoaiThu.Text))
            {
                HienThongBao("Bạn phải nhập tên loại thu nhập.", true);
                txtTenLoaiThu.Focus();
                return false;
            }
            return true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }
    }
}