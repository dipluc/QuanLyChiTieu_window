using NghiepVu;
using NghiepVu.TienIch;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LTWIN_N05_QLCT.Forms.HeThong
{
    public partial class frmPhanQuyen : Form
    {
        private static readonly Color MauXanh = Color.FromArgb(21, 101, 192);
        private static readonly Color MauDo = Color.FromArgb(198, 40, 40);
        private static readonly Color MauXanhLa = Color.FromArgb(46, 125, 50);
        private static readonly Color MauChu = Color.FromArgb(30, 41, 59);
        private static readonly Color MauNenXen = Color.FromArgb(248, 250, 252);
        private static readonly Color MauChon = Color.FromArgb(219, 234, 254);

        private DataTable _tblPhanQuyen;
        private bool _dangNapDuLieu;
        private int _maNDDangChon;

        public frmPhanQuyen()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            CauHinhLuoi();

            cboVaiTro.Items.Add("Admin");
            cboVaiTro.Items.Add("User");

            dgvPhanQuyen.SelectionChanged += dgvPhanQuyen_SelectionChanged;
            btnLuuQuyen.Click += btnLuuQuyen_Click;
            dgvPhanQuyen.DataError += (s, e) => { e.ThrowException = false; };
        }

        private void CauHinhLuoi()
        {
            dgvPhanQuyen.BackgroundColor = Color.White;
            dgvPhanQuyen.BorderStyle = BorderStyle.None;
            dgvPhanQuyen.RowHeadersVisible = false;
            dgvPhanQuyen.EnableHeadersVisualStyles = false;
            dgvPhanQuyen.GridColor = Color.FromArgb(226, 232, 240);
            dgvPhanQuyen.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPhanQuyen.ColumnHeadersHeight = 36;
            dgvPhanQuyen.RowTemplate.Height = 30;
            dgvPhanQuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvPhanQuyen.ColumnHeadersDefaultCellStyle.BackColor = MauXanh;
            dgvPhanQuyen.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPhanQuyen.ColumnHeadersDefaultCellStyle.SelectionBackColor = MauXanh;
            dgvPhanQuyen.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvPhanQuyen.DefaultCellStyle.ForeColor = MauChu;
            dgvPhanQuyen.DefaultCellStyle.SelectionBackColor = MauChon;
            dgvPhanQuyen.DefaultCellStyle.SelectionForeColor = MauChu;
            dgvPhanQuyen.AlternatingRowsDefaultCellStyle.BackColor = MauNenXen;
            dgvPhanQuyen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhanQuyen.MultiSelect = false;
        }

        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            if (!PhienDangNhap.LaAdmin)
            {
                HienThongBao("Chỉ Quản trị viên mới có quyền phân quyền người dùng.", true);
                btnLuuQuyen.Enabled = false;
                return;
            }
            NapLuoi();
        }

        private void NapLuoi()
        {
            _dangNapDuLieu = true;
            try
            {
                var kq = PhanQuyenNV.LayDanhSach();
                if (!kq.ThanhCong)
                {
                    dgvPhanQuyen.DataSource = null;
                    HienThongBao(kq.ThongBao, true);
                    return;
                }

                _tblPhanQuyen = kq.DuLieu.Copy();
                if (!_tblPhanQuyen.Columns.Contains("TrangThaiText"))
                {
                    _tblPhanQuyen.Columns.Add("TrangThaiText", typeof(string));
                }

                foreach (DataRow r in _tblPhanQuyen.Rows)
                {
                    bool trangThai = r["TrangThai"] != DBNull.Value && Convert.ToBoolean(r["TrangThai"]);
                    r["TrangThaiText"] = trangThai ? "Hoạt động" : "Đã khóa";
                }

                dgvPhanQuyen.DataSource = _tblPhanQuyen;
                DinhDangCot();
                CapNhatThongKe();

                dgvPhanQuyen.ClearSelection();
                if (_tblPhanQuyen.Rows.Count > 0)
                {
                    dgvPhanQuyen.Rows[0].Selected = true;
                }
            }
            finally
            {
                _dangNapDuLieu = false;
                if (dgvPhanQuyen.SelectedRows.Count > 0)
                {
                    dgvPhanQuyen_SelectionChanged(null, null);
                }
            }
        }

        private void DinhDangCot()
        {
            if (dgvPhanQuyen.Columns["MaND"] != null) dgvPhanQuyen.Columns["MaND"].Visible = false;
            if (dgvPhanQuyen.Columns["TenDangNhap"] != null) dgvPhanQuyen.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
            if (dgvPhanQuyen.Columns["HoTen"] != null) dgvPhanQuyen.Columns["HoTen"].HeaderText = "Họ tên";
            if (dgvPhanQuyen.Columns["QuyenHienTai"] != null)
            {
                dgvPhanQuyen.Columns["QuyenHienTai"].HeaderText = "Vai trò";
                dgvPhanQuyen.Columns["QuyenHienTai"].FillWeight = 50;
            }
            if (dgvPhanQuyen.Columns["TrangThaiText"] != null)
            {
                dgvPhanQuyen.Columns["TrangThaiText"].HeaderText = "Trạng thái";
                dgvPhanQuyen.Columns["TrangThaiText"].FillWeight = 60;
            }
        }

        private void dgvPhanQuyen_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangNapDuLieu) return;
            if (dgvPhanQuyen.CurrentRow == null || dgvPhanQuyen.SelectedRows.Count == 0) return;

            var dong = dgvPhanQuyen.CurrentRow.DataBoundItem as DataRowView;
            if (dong == null) return;

            lblThongBao.Visible = false;
            _maNDDangChon = dong["MaND"] != DBNull.Value ? Convert.ToInt32(dong["MaND"]) : 0;
            string tenDangNhap = dong["TenDangNhap"] != DBNull.Value ? dong["TenDangNhap"].ToString() : "";
            string hoTen = dong["HoTen"] != DBNull.Value ? dong["HoTen"].ToString() : "";
            string quyenHan = dong["QuyenHan"] != DBNull.Value ? dong["QuyenHan"].ToString() : "User";
            string trangThaiText = dong["TrangThaiText"] != DBNull.Value ? dong["TrangThaiText"].ToString() : "";

            txtTaiKhoanChon.Text = tenDangNhap;
            lblThongTinTrangThai.Text = $"{hoTen} • {trangThaiText}";
            cboVaiTro.SelectedItem = quyenHan;
        }

        private void btnLuuQuyen_Click(object sender, EventArgs e)
        {
            lblThongBao.Visible = false;
            if (_maNDDangChon <= 0)
            {
                HienThongBao("Vui lòng chọn tài khoản cần phân quyền trên danh sách.", true);
                return;
            }

            string quyenMoi = cboVaiTro.SelectedItem != null ? cboVaiTro.SelectedItem.ToString() : "User";
            var thayDoi = new System.Collections.Generic.Dictionary<int, string>
            {
                { _maNDDangChon, quyenMoi }
            };

            var kq = PhanQuyenNV.LuuThayDoi(thayDoi);
            if (kq.ThanhCong)
            {
                HienThongBao("✓ Cập nhật quyền thành công!", false);
                NapLuoi();
            }
            else
            {
                string chiTiet = kq.ThongBao;
                if (kq.DanhSachLoi.Count > 0)
                {
                    chiTiet += Environment.NewLine + string.Join(Environment.NewLine, kq.DanhSachLoi);
                }
                HienThongBao(chiTiet, true);
                MessageBox.Show(chiTiet, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CapNhatThongKe()
        {
            if (_tblPhanQuyen == null) return;
            int tongTK = _tblPhanQuyen.Rows.Count;
            int hoatDong = 0;
            int daKhoa = 0;
            int adminHD = 0;

            foreach (DataRow r in _tblPhanQuyen.Rows)
            {
                bool tt = r["TrangThai"] != DBNull.Value && Convert.ToBoolean(r["TrangThai"]);
                string quyen = r["QuyenHan"] != DBNull.Value ? r["QuyenHan"].ToString() : "";

                if (tt)
                {
                    hoatDong++;
                    if (string.Equals(quyen, "Admin", StringComparison.OrdinalIgnoreCase))
                    {
                        adminHD++;
                    }
                }
                else
                {
                    daKhoa++;
                }
            }

            lblThongKe.Text = $"{tongTK} tài khoản • {hoatDong} hoạt động, {daKhoa} đã khóa • {adminHD} Admin đang hoạt động";
        }

        private void HienThongBao(string thongDiep, bool laLoi)
        {
            lblThongBao.Text = thongDiep;
            lblThongBao.ForeColor = laLoi ? MauDo : MauXanhLa;
            lblThongBao.Visible = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}