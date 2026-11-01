using NghiepVu;
using NghiepVu.TienIch;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;

namespace LTWIN_N05_QLCT.Forms.HeThong
{
    public partial class frmPhanQuyen : Form
    {
        private static readonly Color MauXanh = Color.FromArgb(21, 101, 192);
        private static readonly Color MauDo = Color.FromArgb(198, 40, 40);
        private static readonly Color MauXanhLa = Color.FromArgb(46, 125, 50);
        private static readonly Color MauChu = Color.FromArgb(30, 41, 59);
        private static readonly Color MauVienCard = Color.FromArgb(226, 232, 240);
        private static readonly Color MauChon = Color.FromArgb(235, 245, 255);
        private static readonly Color MauDaDoi = Color.FromArgb(255, 248, 225);

        private DataTable _tblPhanQuyen;   // danh sách người dùng + quyền hiện tại + quyền mới đang chọn

        public frmPhanQuyen()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            // Viền card mô tả
            pnlMoTa.Paint += (s, e) =>
            {
                using (var pen = new Pen(MauVienCard, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, pnlMoTa.Width - 1, pnlMoTa.Height - 1);
                }
            };

            CauHinhLuoi();

            // Sự kiện
            Load += (s, e) => frmPhanQuyen_Load();
            dgvPhanQuyen.CurrentCellDirtyStateChanged += (s, e) =>
            {
                // Ghi nhận ngay khi chọn quyền trong ComboBox của lưới
                if (dgvPhanQuyen.IsCurrentCellDirty)
                    dgvPhanQuyen.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
            dgvPhanQuyen.CellValueChanged += (s, e) => TroMauDongDaDoi(e.RowIndex);
            dgvPhanQuyen.DataError += (s, e) => e.ThrowException = false;
            btnLuu.Click += (s, e) => XuLyLuu();
            btnBoQua.Click += (s, e) => XuLyBoQua();
            btnDong.Click += (s, e) => Close();
        }

        private void frmPhanQuyen_Load()
        {
            if (!PhienDangNhap.LaAdmin)
            {
                HienThongBao("Chỉ Quản trị viên mới có quyền phân quyền người dùng.", true);
                btnLuu.Enabled = false;
                btnBoQua.Enabled = false;
                return;
            }
            NapLuoi();
        }

        // ==========================================
        // NẠP DỮ LIỆU
        // ==========================================
        private void CauHinhLuoi()
        {
            dgvPhanQuyen.AutoGenerateColumns = false;
            dgvPhanQuyen.AllowUserToAddRows = false;
            dgvPhanQuyen.AllowUserToDeleteRows = false;
            dgvPhanQuyen.MultiSelect = false;
            dgvPhanQuyen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhanQuyen.RowHeadersVisible = false;
            dgvPhanQuyen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhanQuyen.BackgroundColor = Color.White;
            dgvPhanQuyen.BorderStyle = BorderStyle.None;
            dgvPhanQuyen.EnableHeadersVisualStyles = false;
            dgvPhanQuyen.ColumnHeadersHeight = 34;
            dgvPhanQuyen.ColumnHeadersDefaultCellStyle.BackColor = MauXanh;
            dgvPhanQuyen.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPhanQuyen.ColumnHeadersDefaultCellStyle.SelectionBackColor = MauXanh;
            dgvPhanQuyen.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.25F, FontStyle.Bold);
            dgvPhanQuyen.DefaultCellStyle.SelectionBackColor = MauChon;
            dgvPhanQuyen.DefaultCellStyle.SelectionForeColor = MauXanh;
            dgvPhanQuyen.DefaultCellStyle.ForeColor = MauChu;
            dgvPhanQuyen.RowTemplate.Height = 30;

            // Chỉ cột "Quyền mới" được sửa
            colMaND.ReadOnly = true;
            colTenDangNhap.ReadOnly = true;
            colHoTen.ReadOnly = true;
            colQuyenHienTai.ReadOnly = true;
            colTrangThai.ReadOnly = true;
            colQuyenMoi.Items.AddRange("Admin", "User");
            colQuyenMoi.FlatStyle = FlatStyle.Flat;
        }

        private void NapLuoi()
        {
            var kq = PhanQuyenNV.LayDanhSach();
            if (!kq.ThanhCong)
            {
                dgvPhanQuyen.DataSource = null;
                HienThongBao(kq.ThongBao, true);
                return;
            }

            _tblPhanQuyen = new DataTable();
            _tblPhanQuyen.Columns.Add("MaND", typeof(int));
            _tblPhanQuyen.Columns.Add("TenDangNhap", typeof(string));
            _tblPhanQuyen.Columns.Add("HoTen", typeof(string));
            _tblPhanQuyen.Columns.Add("QuyenHienTai", typeof(string));
            _tblPhanQuyen.Columns.Add("QuyenMoi", typeof(string));
            _tblPhanQuyen.Columns.Add("TrangThai", typeof(bool));

            foreach (DataRow r in kq.DuLieu.Rows)
            {
                string quyen = Convert.ToString(r["QuyenHan"]);
                _tblPhanQuyen.Rows.Add(r["MaND"], r["TenDangNhap"], r["HoTen"], quyen, quyen, r["TrangThai"]);
            }

            dgvPhanQuyen.DataSource = _tblPhanQuyen;
            dgvPhanQuyen.ClearSelection();
            dgvPhanQuyen.CurrentCell = null;
            foreach (DataGridViewRow dong in dgvPhanQuyen.Rows)
            {
                dong.DefaultCellStyle.BackColor = Color.White;
            }
        }

        // ==========================================
        // XỬ LÝ
        // ==========================================
        private void TroMauDongDaDoi(int chiSoDong)
        {
            if (chiSoDong < 0 || chiSoDong >= dgvPhanQuyen.Rows.Count) return;

            DataGridViewRow dong = dgvPhanQuyen.Rows[chiSoDong];
            bool daDoi = !string.Equals(Convert.ToString(dong.Cells["colQuyenHienTai"].Value),
                                        Convert.ToString(dong.Cells["colQuyenMoi"].Value),
                                        StringComparison.OrdinalIgnoreCase);
            dong.DefaultCellStyle.BackColor = daDoi ? MauDaDoi : Color.White;
        }

        private Dictionary<int, string> LayDanhSachThayDoi()
        {
            var ds = new Dictionary<int, string>();
            if (_tblPhanQuyen == null) return ds;

            foreach (DataRow r in _tblPhanQuyen.Rows)
            {
                string cu = Convert.ToString(r["QuyenHienTai"]);
                string moi = Convert.ToString(r["QuyenMoi"]);
                if (!string.IsNullOrEmpty(moi) && !string.Equals(cu, moi, StringComparison.OrdinalIgnoreCase))
                {
                    ds[Convert.ToInt32(r["MaND"])] = moi;
                }
            }
            return ds;
        }

        private void XuLyLuu()
        {
            lblThongBao.Visible = false;
            dgvPhanQuyen.EndEdit();

            var thayDoi = LayDanhSachThayDoi();
            if (thayDoi.Count == 0)
            {
                HienThongBao("Chưa có thay đổi nào để lưu.", true);
                return;
            }

            if (MessageBox.Show("Bạn có muốn lưu thay đổi quyền cho " + thayDoi.Count + " người dùng không?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            var kq = PhanQuyenNV.LuuThayDoi(thayDoi);
            NapLuoi();   // nạp lại để hiển thị đúng quyền đang lưu trong CSDL

            if (kq.ThanhCong)
            {
                HienThongBao("✓ " + kq.ThongBao, false);
            }
            else
            {
                string chiTiet = kq.ThongBao;
                if (kq.DanhSachLoi.Count > 0)
                {
                    chiTiet += Environment.NewLine + string.Join(Environment.NewLine, kq.DanhSachLoi);
                }
                HienThongBao(kq.ThongBao, true);
                MessageBox.Show(chiTiet, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Bỏ qua: nạp lại quyền đang lưu trong CSDL
        private void XuLyBoQua()
        {
            lblThongBao.Visible = false;
            NapLuoi();
        }

        private void HienThongBao(string thongDiep, bool laLoi)
        {
            lblThongBao.Text = thongDiep;
            lblThongBao.ForeColor = laLoi ? MauDo : MauXanhLa;
            lblThongBao.Visible = true;
        }
    }
}
