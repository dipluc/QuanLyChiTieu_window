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

        private DataTable tblLoaiThu;        // Dữ liệu bảng ví tiền đang hiển thị trên lưới
        private bool _dangThem;             // true khi đang ở chế độ thêm mới
        private bool _dangNapDuLieu;        // chặn SelectionChanged khi đang nạp lại lưới
        private int _maDangChon;          // Ma của dòng đang chọn (0 = chưa chọn)

        public frmLoaiThuNhap()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            // Viền khung nhập liệu
            pnlThongTin.Paint += (s, e) =>
            {
                using (var pen = new Pen(MauVien, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, pnlThongTin.Width - 1, pnlThongTin.Height - 1);
                }
            };

            CauHinhLuoi();
        }

        // Giao diện lưới theo phong cách chung của ứng dụng
        private void CauHinhLuoi()
        {
            dgvLoaiThu.BackgroundColor = Color.White;
            dgvLoaiThu.BorderStyle = BorderStyle.None;
            dgvLoaiThu.RowHeadersVisible = false;
            dgvLoaiThu.EnableHeadersVisualStyles = false;
            dgvLoaiThu.GridColor = Color.FromArgb(226, 232, 240);
            dgvLoaiThu.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLoaiThu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
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
        }

        private void frmLoaiThuNhap_Load(object sender, EventArgs e)
        {
            _dangThem = false;
            if (!PhienDangNhap.DaDangNhap)
            {
                MessageBox.Show("Bạn cần đăng nhập để quản lý loại thu nhập.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                return;
            }
            LoadDataGridView();
            ResetValues();
            DatTrangThaiNut(false);
        }

        // ==========================================
        // LƯỚI DỮ LIỆU
        // ==========================================
        private void LoadDataGridView()
        {
            _dangNapDuLieu = true;
            try
            {
                string loi;
                tblLoaiThu = LoaiThuNV.LayDanhSach(out loi);
                if (!string.IsNullOrEmpty(loi))
                {
                    MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dgvLoaiThu.DataSource = tblLoaiThu;
                DinhDangCot();
                dgvLoaiThu.CurrentCell = null;
                dgvLoaiThu.ClearSelection();
            }
            finally
            {
                _dangNapDuLieu = false;
            }
        }

        private void DinhDangCot()
        {
            DatCot("MaLoaiThu", "Mã loại thu", 14);
            DatCot("TenLoaiThu", "Tên loại thu", 34);
            DatCot("GhiChu", "Ghi chú", 40);
            DatCot("TrangThai", "Đang sử dụng", 12);
        }

        private void DatCot(string ten, string tieuDe, float tyLe)
        {
            DataGridViewColumn cot = dgvLoaiThu.Columns[ten];
            if (cot == null) return;
            cot.HeaderText = tieuDe;
            cot.FillWeight = tyLe;
        }

        // Chọn dòng trên lưới => hiển thị lên các ô nhập
        private void dgvLoaiThu_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangNapDuLieu || _dangThem) return;
            if (dgvLoaiThu.CurrentRow == null || dgvLoaiThu.SelectedRows.Count == 0) return;

            var dong = dgvLoaiThu.CurrentRow.DataBoundItem as DataRowView;
            if (dong == null) return;

            _maDangChon = Convert.ToInt32(dong["MaLoaiThu"]);
            txtMaLoaiThu.Text = _maDangChon.ToString();
            txtTenLoaiThu.Text = dong["TenLoaiThu"].ToString();
            txtGhiChu.Text = dong["GhiChu"] == DBNull.Value ? "" : dong["GhiChu"].ToString();
            chkTrangThai.Checked = Convert.ToBoolean(dong["TrangThai"]);

            DatTrangThaiNut(true);
        }

        // ==========================================
        // TRẠNG THÁI GIAO DIỆN
        // ==========================================
        private void ResetValues()
        {
            _maDangChon = 0;
            txtMaLoaiThu.Text = "(tự sinh)";
            txtTenLoaiThu.Text = "";
            txtGhiChu.Text = "";
            chkTrangThai.Checked = true;
        }

        private void DatTrangThaiNut(bool coChon)
        {
            btnThem.Enabled = !_dangThem;
            btnSua.Enabled = !_dangThem && coChon;
            btnXoa.Enabled = !_dangThem && coChon;
            btnLuu.Enabled = _dangThem;
            btnBoQua.Enabled = _dangThem || coChon;
        }

        private void KetThucCheDoThem()
        {
            _dangThem = false;
            dgvLoaiThu.Enabled = true;
            LoadDataGridView();
            ResetValues();
            DatTrangThaiNut(false);
        }

        // ==========================================
        // THÊM / SỬA / XÓA / LƯU / BỎ QUA
        // ==========================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            _dangThem = true;
            dgvLoaiThu.Enabled = false;
            ResetValues();
            DatTrangThaiNut(false);
            txtTenLoaiThu.Focus();
        }

        // Kiểm tra ô nhập (dùng chung cho Lưu và Sửa)
        private bool KiemTraNhap()
        {
            if (txtTenLoaiThu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại thu nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoaiThu.Focus();
                return false;
            }
            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!KiemTraNhap()) return;

            KetQuaThaoTac kq = LoaiThuNV.Them(txtTenLoaiThu.Text, txtGhiChu.Text, chkTrangThai.Checked);
            if (!kq.ThanhCong)
            {
                MessageBox.Show(kq.ThongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(kq.ThongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            KetThucCheDoThem();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (tblLoaiThu == null || tblLoaiThu.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_maDangChon <= 0)
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!KiemTraNhap()) return;

            KetQuaThaoTac kq = LoaiThuNV.Sua(_maDangChon, txtTenLoaiThu.Text, txtGhiChu.Text, chkTrangThai.Checked);
            if (!kq.ThanhCong)
            {
                MessageBox.Show(kq.ThongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(kq.ThongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDataGridView();
            ResetValues();
            DatTrangThaiNut(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (tblLoaiThu == null || tblLoaiThu.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_maDangChon <= 0)
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult hoi = MessageBox.Show(
                "Bạn có muốn xóa loại thu nhập \"" + txtTenLoaiThu.Text.Trim() + "\" không?",
                "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi != DialogResult.Yes) return;

            KetQuaThaoTac kq = LoaiThuNV.Xoa(_maDangChon);
            if (!kq.ThanhCong)
            {
                MessageBox.Show(kq.ThongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadDataGridView();
            ResetValues();
            DatTrangThaiNut(false);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            if (_dangThem)
            {
                KetThucCheDoThem();
                return;
            }
            ResetValues();
            dgvLoaiThu.CurrentCell = null;
            dgvLoaiThu.ClearSelection();
            DatTrangThaiNut(false);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ==========================================
        // NHẬP LIỆU
        // ==========================================
        // Nhấn Enter để chuyển sang ô kế tiếp
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
