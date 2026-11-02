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

        private DataTable tblViTien;
        private bool _dangNapDuLieu;
        private int _maViDangChon;

        public frmViTien()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            cboLoaiVi.DisplayMember = "Value";
            cboLoaiVi.ValueMember = "Key";
            cboLoaiVi.DataSource = ViTienNV.LayDanhSachLoaiVi();
            cboLoaiVi.SelectedIndex = -1;

            var dtTrangThai = new DataTable();
            dtTrangThai.Columns.Add("Ma", typeof(bool));
            dtTrangThai.Columns.Add("Ten", typeof(string));
            dtTrangThai.Rows.Add(true, "Đang sử dụng");
            dtTrangThai.Rows.Add(false, "Ngừng sử dụng");

            cboTrangThai.DataSource = dtTrangThai;
            cboTrangThai.DisplayMember = "Ten";
            cboTrangThai.ValueMember = "Ma";
            cboTrangThai.SelectedValue = true;

            CauHinhLuoi();
        }

        private void CauHinhLuoi()
        {
            dgvViTien.BackgroundColor = Color.White;
            dgvViTien.BorderStyle = BorderStyle.None;
            dgvViTien.RowHeadersVisible = false;
            dgvViTien.EnableHeadersVisualStyles = false;
            dgvViTien.GridColor = Color.FromArgb(226, 232, 240);
            dgvViTien.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
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
            dgvViTien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvViTien.MultiSelect = false;

            dgvViTien.CellFormatting += dgvViTien_CellFormatting;
            dgvViTien.SelectionChanged += dgvViTien_SelectionChanged;

            // Xử lý triệt để lỗi FormatException hiển thị trên DataGridView
            dgvViTien.DataError += (s, e) =>
            {
                e.ThrowException = false;
            };
        }

        private void frmViTien_Load(object sender, EventArgs e)
        {
            if (!PhienDangNhap.DaDangNhap)
            {
                MessageBox.Show("Bạn cần đăng nhập để quản lý ví tiền.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                tblViTien = ViTienNV.LayDanhSach(out loi);
                if (!string.IsNullOrEmpty(loi))
                {
                    MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dgvViTien.DataSource = tblViTien;
                DinhDangCot();
                dgvViTien.ClearSelection();
            }
            finally
            {
                _dangNapDuLieu = false;
            }
        }

        private void DinhDangCot()
        {
            if (dgvViTien.Columns["MaVi"] != null) dgvViTien.Columns["MaVi"].Visible = false;
            if (dgvViTien.Columns["GhiChu"] != null) dgvViTien.Columns["GhiChu"].Visible = false;
            if (dgvViTien.Columns["MaND"] != null) dgvViTien.Columns["MaND"].Visible = false;

            DatCot("TenVi", "Tên ví", 30);
            DatCot("LoaiVi", "Loại", 20);
            DatCot("SoDuBanDau", "Số dư ban đầu", 25, true);
            DatCot("SoDuHienTai", "Số dư hiện tại", 25, true);

            if (dgvViTien.Columns["TrangThai"] != null)
            {
                dgvViTien.Columns["TrangThai"].HeaderText = "Trạng thái";
                dgvViTien.Columns["TrangThai"].FillWeight = 20;
            }
        }

        private void DatCot(string ten, string tieuDe, float tyLe, bool laSoTien = false)
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

        private void dgvViTien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null || e.Value == DBNull.Value) return;

            string columnName = dgvViTien.Columns[e.ColumnIndex].Name;
            if (columnName == "LoaiVi")
            {
                e.Value = ViTienNV.TenLoaiVi(e.Value.ToString());
                e.FormattingApplied = true;
            }
            else if (columnName == "TrangThai")
            {
                if (bool.TryParse(e.Value.ToString(), out bool trangThai))
                {
                    e.Value = trangThai ? "Đang sử dụng" : "Ngừng sử dụng";
                    e.FormattingApplied = true;
                }
            }
        }

        private void dgvViTien_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangNapDuLieu) return;
            if (dgvViTien.CurrentRow == null || dgvViTien.SelectedRows.Count == 0) return;

            var dong = dgvViTien.CurrentRow.DataBoundItem as DataRowView;
            if (dong == null) return;

            _maViDangChon = dong["MaVi"] != DBNull.Value ? Convert.ToInt32(dong["MaVi"]) : 0;
            txtTenVi.Text = dong["TenVi"] != DBNull.Value ? dong["TenVi"].ToString() : "";
            cboLoaiVi.SelectedValue = dong["LoaiVi"] != DBNull.Value ? dong["LoaiVi"].ToString() : "";

            if (dong["SoDuBanDau"] != DBNull.Value && decimal.TryParse(dong["SoDuBanDau"].ToString(), out decimal soDu))
            {
                txtSoDuBanDau.Text = soDu.ToString("0", CultureInfo.InvariantCulture);
            }
            else
            {
                txtSoDuBanDau.Text = "0";
            }

            if (dong["TrangThai"] != DBNull.Value)
            {
                cboTrangThai.SelectedValue = Convert.ToBoolean(dong["TrangThai"]);
            }
        }

        private void ResetValues()
        {
            _maViDangChon = 0;
            txtTenVi.Text = "";
            cboLoaiVi.SelectedIndex = -1;
            txtSoDuBanDau.Text = "0";
            cboTrangThai.SelectedValue = true;
            dgvViTien.ClearSelection();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            decimal soDu;
            if (!KiemTraNhap(out soDu)) return;

            var kq = ViTienNV.Them(txtTenVi.Text, cboLoaiVi.SelectedValue.ToString(), soDu, "", (bool)cboTrangThai.SelectedValue);
            if (!kq.ThanhCong)
            {
                MessageBox.Show(kq.ThongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(kq.ThongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDataGridView();
            ResetValues();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_maViDangChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn ví cần sửa trên danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal soDu;
            if (!KiemTraNhap(out soDu)) return;

            var kq = ViTienNV.Sua(_maViDangChon, txtTenVi.Text, cboLoaiVi.SelectedValue.ToString(), soDu, "", (bool)cboTrangThai.SelectedValue);
            if (!kq.ThanhCong)
            {
                MessageBox.Show(kq.ThongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(kq.ThongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDataGridView();
            ResetValues();
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        private void btnNgungSuDung_Click(object sender, EventArgs e)
        {
            if (_maViDangChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn ví cần ngừng sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal soDu = 0;
            decimal.TryParse(txtSoDuBanDau.Text.Trim(), out soDu);

            var kq = ViTienNV.Sua(_maViDangChon, txtTenVi.Text, cboLoaiVi.SelectedValue.ToString(), soDu, "", false);
            if (kq.ThanhCong)
            {
                MessageBox.Show("Đã cập nhật trạng thái ví thành ngừng sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGridView();
                ResetValues();
            }
            else
            {
                MessageBox.Show(kq.ThongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool KiemTraNhap(out decimal soDuBanDau)
        {
            soDuBanDau = 0;
            if (string.IsNullOrWhiteSpace(txtTenVi.Text))
            {
                MessageBox.Show("Bạn phải nhập tên ví.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenVi.Focus();
                return false;
            }
            if (cboLoaiVi.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn loại ví.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiVi.Focus();
                return false;
            }
            if (!decimal.TryParse(txtSoDuBanDau.Text.Trim(), NumberStyles.None, CultureInfo.InvariantCulture, out soDuBanDau))
            {
                MessageBox.Show("Số dư ban đầu không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDuBanDau.Focus();
                return false;
            }
            return true;
        }

        private void txtSoDuBanDau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}