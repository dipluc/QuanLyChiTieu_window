using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using NghiepVu;
using NghiepVu.TienIch;

namespace LTWIN_N05_QLCT.Forms.DanhMuc
{
    public partial class frmViTien : Form
    {
        private static readonly Color MauXanh = Color.FromArgb(21, 101, 192);
        private static readonly Color MauVien = Color.FromArgb(203, 213, 225);
        private static readonly Color MauChu = Color.FromArgb(30, 41, 59);
        private static readonly Color MauNenXen = Color.FromArgb(248, 250, 252);

        private DataTable tblViTien;        // Dữ liệu bảng ví tiền đang hiển thị trên lưới
        private bool _dangThem;             // true khi đang ở chế độ thêm mới
        private bool _dangNapDuLieu;        // chặn SelectionChanged khi đang nạp lại lưới
        private int _maViDangChon;          // MaVi của dòng đang chọn (0 = chưa chọn)

        public frmViTien()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            // Loại ví: lưu mã (TienMat, NganHang...) nhưng hiển thị tên tiếng Việt
            cboLoaiVi.DisplayMember = "Value";
            cboLoaiVi.ValueMember = "Key";
            cboLoaiVi.DataSource = ViTienNV.LayDanhSachLoaiVi();
            cboLoaiVi.SelectedIndex = -1;

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
            dgvViTien.BackgroundColor = Color.White;
            dgvViTien.BorderStyle = BorderStyle.None;
            dgvViTien.RowHeadersVisible = false;
            dgvViTien.EnableHeadersVisualStyles = false;
            dgvViTien.GridColor = Color.FromArgb(226, 232, 240);
            dgvViTien.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvViTien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvViTien.ColumnHeadersHeight = 36;
            dgvViTien.RowTemplate.Height = 30;
            dgvViTien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvViTien.ColumnHeadersDefaultCellStyle.BackColor = MauXanh;
            dgvViTien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvViTien.ColumnHeadersDefaultCellStyle.SelectionBackColor = MauXanh;
            dgvViTien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvViTien.DefaultCellStyle.ForeColor = MauChu;
            dgvViTien.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvViTien.DefaultCellStyle.SelectionForeColor = MauChu;
            dgvViTien.AlternatingRowsDefaultCellStyle.BackColor = MauNenXen;
        }

        private void frmViTien_Load(object sender, EventArgs e)
        {
            _dangThem = false;
            if (!PhienDangNhap.DaDangNhap)
            {
                MessageBox.Show("Bạn cần đăng nhập để quản lý ví tiền.", "Thông báo",
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
                tblViTien = ViTienNV.LayDanhSach(out loi);
                if (!string.IsNullOrEmpty(loi))
                {
                    MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dgvViTien.DataSource = tblViTien;
                DinhDangCot();
                dgvViTien.CurrentCell = null;
                dgvViTien.ClearSelection();
            }
            finally
            {
                _dangNapDuLieu = false;
            }
        }

        private void DinhDangCot()
        {
            DatCot("MaVi", "Mã ví", 8, false);
            DatCot("TenVi", "Tên ví", 22, false);
            DatCot("LoaiVi", "Loại ví", 14, false);
            DatCot("SoDuBanDau", "Số dư ban đầu", 16, true);
            DatCot("SoDuHienTai", "Số dư hiện tại", 16, true);
            DatCot("GhiChu", "Ghi chú", 24, false);
            DatCot("TrangThai", "Đang sử dụng", 10, false);
        }

        private void DatCot(string ten, string tieuDe, float tyLe, bool laSoTien)
        {
            DataGridViewColumn cot = dgvViTien.Columns[ten];
            if (cot == null) return;
            cot.HeaderText = tieuDe;
            cot.FillWeight = tyLe;
            if (laSoTien)
            {
                cot.DefaultCellStyle.Format = "N0";
                cot.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        // Hiển thị tên loại ví tiếng Việt thay cho mã lưu trong CSDL
        private void dgvViTien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;
            if (dgvViTien.Columns[e.ColumnIndex].Name == "LoaiVi")
            {
                e.Value = ViTienNV.TenLoaiVi(e.Value.ToString());
                e.FormattingApplied = true;
            }
        }

        // Chọn dòng trên lưới => hiển thị lên các ô nhập
        private void dgvViTien_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangNapDuLieu || _dangThem) return;
            if (dgvViTien.CurrentRow == null || dgvViTien.SelectedRows.Count == 0) return;

            var dong = dgvViTien.CurrentRow.DataBoundItem as DataRowView;
            if (dong == null) return;

            _maViDangChon = Convert.ToInt32(dong["MaVi"]);
            txtMaVi.Text = _maViDangChon.ToString();
            txtTenVi.Text = dong["TenVi"].ToString();
            cboLoaiVi.SelectedValue = dong["LoaiVi"].ToString();
            txtSoDuBanDau.Text = Convert.ToDecimal(dong["SoDuBanDau"]).ToString("0", CultureInfo.InvariantCulture);
            txtSoDuHienTai.Text = Convert.ToDecimal(dong["SoDuHienTai"]).ToString("N0");
            txtGhiChu.Text = dong["GhiChu"] == DBNull.Value ? "" : dong["GhiChu"].ToString();
            chkTrangThai.Checked = Convert.ToBoolean(dong["TrangThai"]);

            DatTrangThaiNut(true);
        }

        // ==========================================
        // TRẠNG THÁI GIAO DIỆN
        // ==========================================
        private void ResetValues()
        {
            _maViDangChon = 0;
            txtMaVi.Text = "(tự sinh)";
            txtTenVi.Text = "";
            cboLoaiVi.SelectedIndex = -1;
            txtSoDuBanDau.Text = "0";
            txtSoDuHienTai.Text = "0";
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
            dgvViTien.Enabled = true;
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
            dgvViTien.Enabled = false;
            ResetValues();
            DatTrangThaiNut(false);
            txtTenVi.Focus();
        }

        // Kiểm tra các ô nhập (dùng chung cho Lưu và Sửa); trả về false nếu có lỗi
        private bool KiemTraNhap(out decimal soDuBanDau)
        {
            soDuBanDau = 0;
            if (txtTenVi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên ví", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenVi.Focus();
                return false;
            }
            if (LoaiViDangChon() == null)
            {
                MessageBox.Show("Bạn phải chọn loại ví", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiVi.Focus();
                return false;
            }
            string s = txtSoDuBanDau.Text.Trim();
            if (s.Length > 0 && !decimal.TryParse(s, NumberStyles.None, CultureInfo.InvariantCulture, out soDuBanDau))
            {
                MessageBox.Show("Số dư ban đầu không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDuBanDau.Focus();
                return false;
            }
            return true;
        }

        private string LoaiViDangChon()
        {
            return cboLoaiVi.SelectedValue as string;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            decimal soDu;
            if (!KiemTraNhap(out soDu)) return;

            KetQuaThaoTac kq = ViTienNV.Them(txtTenVi.Text, LoaiViDangChon(), soDu, txtGhiChu.Text, chkTrangThai.Checked);
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
            if (tblViTien == null || tblViTien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_maViDangChon <= 0)
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal soDu;
            if (!KiemTraNhap(out soDu)) return;

            KetQuaThaoTac kq = ViTienNV.Sua(_maViDangChon, txtTenVi.Text, LoaiViDangChon(), soDu, txtGhiChu.Text, chkTrangThai.Checked);
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
            if (tblViTien == null || tblViTien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_maViDangChon <= 0)
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult hoi = MessageBox.Show(
                "Bạn có muốn xóa ví \"" + txtTenVi.Text.Trim() + "\" không?",
                "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi != DialogResult.Yes) return;

            KetQuaThaoTac kq = ViTienNV.Xoa(_maViDangChon);
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
            dgvViTien.CurrentCell = null;
            dgvViTien.ClearSelection();
            DatTrangThaiNut(false);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ==========================================
        // NHẬP LIỆU
        // ==========================================
        // Số dư ban đầu: chỉ cho nhập chữ số
        private void txtSoDuBanDau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

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
