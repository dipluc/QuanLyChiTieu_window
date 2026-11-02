using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MoHinh;
using NghiepVu;

namespace LTWIN_N05_QLCT.Forms.DanhMuc
{
    public partial class frmLoaiChiTieu : Form
    {
        private static readonly Color MauXanh = Color.FromArgb(21, 101, 192);
        private static readonly Color MauChu = Color.FromArgb(30, 41, 59);
        private static readonly Color MauNenXen = Color.FromArgb(248, 250, 252);
        private static readonly Color MauDo = Color.FromArgb(198, 40, 40);
        private static readonly Color MauXanhLa = Color.FromArgb(46, 125, 50);

        private DataTable tblNhomChi;
        private DataTable tblLoaiChi;
        private bool _dangNapDuLieu;
        private int _maNhomDangChon;
        private int _maLoaiDangChon;

        public frmLoaiChiTieu()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            CauHinhLuoi(dgvNhomChi);
            CauHinhLuoi(dgvLoaiChi);

            dgvNhomChi.SelectionChanged += dgvNhomChi_SelectionChanged;
            dgvLoaiChi.SelectionChanged += dgvLoaiChi_SelectionChanged;

            btnThemNhom.Click += btnThemNhom_Click;
            btnSuaNhom.Click += btnSuaNhom_Click;
            btnNgungSuDungNhom.Click += btnNgungSuDungNhom_Click;

            btnThemLoai.Click += btnThemLoai_Click;
            btnSuaLoai.Click += btnSuaLoai_Click;
            btnNgungSuDungLoai.Click += btnNgungSuDungLoai_Click;

            dgvNhomChi.DataError += (s, e) => { e.ThrowException = false; };
            dgvLoaiChi.DataError += (s, e) => { e.ThrowException = false; };
        }

        private void CauHinhLuoi(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.FromArgb(226, 232, 240);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersHeight = 34;
            dgv.RowTemplate.Height = 30;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = MauXanh;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = MauXanh;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgv.DefaultCellStyle.ForeColor = MauChu;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgv.DefaultCellStyle.SelectionForeColor = MauChu;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = MauNenXen;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
        }

        private void frmLoaiChiTieu_Load(object sender, EventArgs e)
        {
            LoadDanhSachNhomChi();
        }

        // ==========================================
        // QUẢN LÝ NHÓM CHI (BÊN TRÁI)
        // ==========================================
        private void LoadDanhSachNhomChi()
        {
            _dangNapDuLieu = true;
            try
            {
                var kq = LoaiChiNV.LayDanhSachNhomChi();
                if (!kq.ThanhCong)
                {
                    HienThongBao(kq.ThongBao, true);
                    return;
                }

                tblNhomChi = kq.DuLieu;
                dgvNhomChi.DataSource = tblNhomChi;

                if (dgvNhomChi.Columns["MaNhom"] != null) dgvNhomChi.Columns["MaNhom"].Visible = false;
                if (dgvNhomChi.Columns["GhiChu"] != null) dgvNhomChi.Columns["GhiChu"].Visible = false;
                if (dgvNhomChi.Columns["TenNhom"] != null) dgvNhomChi.Columns["TenNhom"].HeaderText = "Tên nhóm chi";
                if (dgvNhomChi.Columns["TrangThai"] != null)
                {
                    dgvNhomChi.Columns["TrangThai"].HeaderText = "Trạng thái";
                    dgvNhomChi.Columns["TrangThai"].FillWeight = 40;
                }

                dgvNhomChi.ClearSelection();
                if (tblNhomChi.Rows.Count > 0)
                {
                    dgvNhomChi.Rows[0].Selected = true;
                }
            }
            finally
            {
                _dangNapDuLieu = false;
                if (dgvNhomChi.SelectedRows.Count > 0)
                {
                    dgvNhomChi_SelectionChanged(null, null);
                }
            }
        }

        private void dgvNhomChi_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangNapDuLieu) return;
            if (dgvNhomChi.CurrentRow == null || dgvNhomChi.SelectedRows.Count == 0) return;

            var dong = dgvNhomChi.CurrentRow.DataBoundItem as DataRowView;
            if (dong == null) return;

            _maNhomDangChon = dong["MaNhom"] != DBNull.Value ? Convert.ToInt32(dong["MaNhom"]) : 0;
            string tenNhom = dong["TenNhom"] != DBNull.Value ? dong["TenNhom"].ToString() : "";

            txtTenNhomChi.Text = tenNhom;
            txtGhiChuNhom.Text = dong["GhiChu"] != DBNull.Value ? dong["GhiChu"].ToString() : "";

            // Cập nhật tiêu đề bên phải
            lblLoaiChiTieuTieuDe.Text = "Loại chi thuộc nhóm " + tenNhom;
            cboNhomChiKhoa.DataSource = tblNhomChi;
            cboNhomChiKhoa.DisplayMember = "TenNhom";
            cboNhomChiKhoa.ValueMember = "MaNhom";
            cboNhomChiKhoa.SelectedValue = _maNhomDangChon;

            LoadDanhSachLoaiChiTheoNhom(_maNhomDangChon, tenNhom);
        }

        private void btnThemNhom_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNhomChi.Text))
            {
                HienThongBao("Bạn phải nhập tên nhóm chi.", true);
                txtTenNhomChi.Focus();
                return;
            }

            var kq = LoaiChiNV.ThemNhomChi(txtTenNhomChi.Text.Trim(), txtGhiChuNhom.Text.Trim(), true);
            if (!kq.ThanhCong)
            {
                HienThongBao(kq.ThongBao, true);
                return;
            }

            HienThongBao("✓ Thêm nhóm chi thành công!", false);
            LoadDanhSachNhomChi();
        }

        private void btnSuaNhom_Click(object sender, EventArgs e)
        {
            if (_maNhomDangChon <= 0)
            {
                HienThongBao("Vui lòng chọn nhóm chi cần sửa.", true);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenNhomChi.Text))
            {
                HienThongBao("Bạn phải nhập tên nhóm chi.", true);
                txtTenNhomChi.Focus();
                return;
            }

            var kq = LoaiChiNV.SuaNhomChi(_maNhomDangChon, txtTenNhomChi.Text.Trim(), txtGhiChuNhom.Text.Trim(), true);
            if (!kq.ThanhCong)
            {
                HienThongBao(kq.ThongBao, true);
                return;
            }

            HienThongBao("✓ Cập nhật nhóm chi thành công!", false);
            LoadDanhSachNhomChi();
        }

        private void btnNgungSuDungNhom_Click(object sender, EventArgs e)
        {
            if (_maNhomDangChon <= 0)
            {
                HienThongBao("Vui lòng chọn nhóm chi cần ngừng sử dụng.", true);
                return;
            }

            var kq = LoaiChiNV.SuaNhomChi(_maNhomDangChon, txtTenNhomChi.Text.Trim(), txtGhiChuNhom.Text.Trim(), false);
            if (kq.ThanhCong)
            {
                HienThongBao("✓ Đã chuyển nhóm chi sang ngừng sử dụng.", false);
                LoadDanhSachNhomChi();
            }
            else
            {
                HienThongBao(kq.ThongBao, true);
            }
        }

        // ==========================================
        // QUẢN LÝ LOẠI CHI (BÊN PHẢI)
        // ==========================================
        private void LoadDanhSachLoaiChiTheoNhom(int maNhom, string tenNhom)
        {
            var kq = LoaiChiNV.LayDanhSachTheoNhom(maNhom);
            if (!kq.ThanhCong)
            {
                dgvLoaiChi.DataSource = null;
                return;
            }

            tblLoaiChi = kq.DuLieu;
            dgvLoaiChi.DataSource = tblLoaiChi;

            if (dgvLoaiChi.Columns["MaLoaiChi"] != null) dgvLoaiChi.Columns["MaLoaiChi"].Visible = false;
            if (dgvLoaiChi.Columns["MaNhom"] != null) dgvLoaiChi.Columns["MaNhom"].Visible = false;
            if (dgvLoaiChi.Columns["TenLoaiChi"] != null) dgvLoaiChi.Columns["TenLoaiChi"].HeaderText = "Tên loại chi";
            if (dgvLoaiChi.Columns["GhiChu"] != null) dgvLoaiChi.Columns["GhiChu"].HeaderText = "Ghi chú";
            if (dgvLoaiChi.Columns["TrangThai"] != null) dgvLoaiChi.Columns["TrangThai"].HeaderText = "Trạng thái";

            int soLuong = tblLoaiChi.Rows.Count;
            lblNhomDangChon.Text = $"Nhóm đang chọn: {tenNhom} • {soLuong} loại chi";

            dgvLoaiChi.ClearSelection();
            if (soLuong > 0)
            {
                dgvLoaiChi.Rows[0].Selected = true;
            }
            else
            {
                txtTenLoaiChi.Text = "";
                txtGhiChuLoai.Text = "";
            }
        }

        private void dgvLoaiChi_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangNapDuLieu) return;
            if (dgvLoaiChi.CurrentRow == null || dgvLoaiChi.SelectedRows.Count == 0) return;

            var dong = dgvLoaiChi.CurrentRow.DataBoundItem as DataRowView;
            if (dong == null) return;

            _maLoaiDangChon = dong["MaLoaiChi"] != DBNull.Value ? Convert.ToInt32(dong["MaLoaiChi"]) : 0;
            txtTenLoaiChi.Text = dong["TenLoaiChi"] != DBNull.Value ? dong["TenLoaiChi"].ToString() : "";
            txtGhiChuLoai.Text = dong["GhiChu"] != DBNull.Value ? dong["GhiChu"].ToString() : "";
        }

        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            if (_maNhomDangChon <= 0)
            {
                HienThongBao("Vui lòng chọn nhóm chi bên trái trước khi thêm loại chi.", true);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenLoaiChi.Text))
            {
                HienThongBao("Bạn phải nhập tên loại chi.", true);
                txtTenLoaiChi.Focus();
                return;
            }

            var model = new LoaiChiMH
            {
                MaNhom = _maNhomDangChon,
                TenLoaiChi = txtTenLoaiChi.Text.Trim(),
                GhiChu = txtGhiChuLoai.Text.Trim(),
                TrangThai = true
            };

            var kq = LoaiChiNV.Them(model);
            if (!kq.ThanhCong)
            {
                HienThongBao(kq.ThongBao, true);
                return;
            }

            HienThongBao("✓ Thêm loại chi thành công!", false);
            LoadDanhSachNhomChi();
        }

        private void btnSuaLoai_Click(object sender, EventArgs e)
        {
            if (_maLoaiDangChon <= 0)
            {
                HienThongBao("Vui lòng chọn loại chi cần sửa trên lưới.", true);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenLoaiChi.Text))
            {
                HienThongBao("Bạn phải nhập tên loại chi.", true);
                txtTenLoaiChi.Focus();
                return;
            }

            var model = new LoaiChiMH
            {
                MaLoaiChi = _maLoaiDangChon,
                MaNhom = _maNhomDangChon,
                TenLoaiChi = txtTenLoaiChi.Text.Trim(),
                GhiChu = txtGhiChuLoai.Text.Trim(),
                TrangThai = true
            };

            var kq = LoaiChiNV.CapNhat(model);
            if (!kq.ThanhCong)
            {
                HienThongBao(kq.ThongBao, true);
                return;
            }

            HienThongBao("✓ Cập nhật loại chi thành công!", false);
            LoadDanhSachNhomChi();
        }

        private void btnNgungSuDungLoai_Click(object sender, EventArgs e)
        {
            if (_maLoaiDangChon <= 0)
            {
                HienThongBao("Vui lòng chọn loại chi cần ngừng sử dụng trên lưới.", true);
                return;
            }

            var kq = LoaiChiNV.DatTrangThai(_maLoaiDangChon, false);
            if (kq.ThanhCong)
            {
                HienThongBao("✓ Đã chuyển loại chi sang ngừng sử dụng.", false);
                LoadDanhSachNhomChi();
            }
            else
            {
                HienThongBao(kq.ThongBao, true);
            }
        }

        private void HienThongBao(string thongDiep, bool laLoi)
        {
            lblThongBao.Text = thongDiep;
            lblThongBao.ForeColor = laLoi ? MauDo : MauXanhLa;
            lblThongBao.Visible = true;
        }
    }
}