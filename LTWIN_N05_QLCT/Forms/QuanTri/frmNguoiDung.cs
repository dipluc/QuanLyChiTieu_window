using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using NghiepVu;
using NghiepVu.TienIch;

namespace LTWIN_N05_QLCT.Forms.QuanTri
{
    /// <summary>
    /// Màn hình quản trị tài khoản (chỉ Admin): xem danh sách, tìm kiếm, khóa/mở khóa, đặt lại mật khẩu, đổi quyền.
    /// </summary>
    public partial class frmNguoiDung : Form
    {
        private static readonly Color MauXanh = Color.FromArgb(21, 101, 192);
        private static readonly Color MauDo = Color.FromArgb(198, 40, 40);
        private static readonly Color MauXanhLa = Color.FromArgb(46, 125, 50);
        private static readonly Color MauChu = Color.FromArgb(30, 41, 59);
        private static readonly Color MauXam = Color.FromArgb(100, 116, 139);
        private static readonly Color MauChon = Color.FromArgb(235, 245, 255);
        private static readonly Font FontThuong = new Font("Segoe UI", 9.25F);
        private static readonly Font FontDam = new Font("Segoe UI", 9.25F, FontStyle.Bold);

        private const string GoiYCheDo = "Chỉ đọc • Chọn một tài khoản để thao tác";

        // Placeholder cho TextBox (EM_SETCUEBANNER)
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

        private DataTable _bang;
        private DataView _view;
        private bool _dangNap;   // chặn SelectionChanged khi đang nạp / lọc lại lưới

        public frmNguoiDung()
        {
            InitializeComponent();
            KhoiTao();
        }

        // ==========================================
        // KHỞI TẠO
        // ==========================================
        private void KhoiTao()
        {
            CauHinhLuoi();

            Load += (s, e) => frmNguoiDung_Load();
            txtTimKiem.HandleCreated += (s, e) =>
                SendMessage(txtTimKiem.Handle, EM_SETCUEBANNER, 1, "Tên đăng nhập, họ tên hoặc email");

            btnTim.Click += (s, e) => TimKiem();
            txtTimKiem.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; TimKiem(); }
            };
            txtTimKiem.TextChanged += (s, e) =>
            {
                if (txtTimKiem.Text.Length == 0) TimKiem();   // xóa hết chữ => hiện lại toàn bộ
            };

            dgvNguoiDung.SelectionChanged += (s, e) => KhiDoiDongChon();
            dgvNguoiDung.CellFormatting += dgvNguoiDung_CellFormatting;

            btnKhoaMoKhoa.Click += (s, e) => XuLyKhoaMoKhoa();
            btnDatLaiMatKhau.Click += (s, e) => XuLyDatLaiMatKhau();
            btnDoiQuyen.Click += (s, e) => XuLyDoiQuyen();
        }

        private void frmNguoiDung_Load()
        {
            if (!PhienDangNhap.LaAdmin)
            {
                lblCheDo.Text = "Chỉ Quản trị viên mới có quyền quản lý người dùng.";
                lblCheDo.ForeColor = MauDo;
                txtTimKiem.Enabled = false;
                btnTim.Enabled = false;
                CapNhatChanTrang();
                return;
            }

            NapLuoi(0);
        }

        private void CauHinhLuoi()
        {
            var g = dgvNguoiDung;
            g.AutoGenerateColumns = false;
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.ReadOnly = true;
            g.MultiSelect = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.RowHeadersVisible = false;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.DefaultCellStyle.Font = FontThuong;
            g.DefaultCellStyle.ForeColor = MauChu;
            g.DefaultCellStyle.SelectionBackColor = MauChon;
            g.DefaultCellStyle.SelectionForeColor = MauChu;
            g.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            g.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            g.RowTemplate.Height = 36;

            g.Columns.Clear();
            var maND = ThemCot("MaND", "Mã", 10);
            maND.Visible = false;
            ThemCot("TenDangNhap", "Tên đăng nhập", 22);
            ThemCot("HoTen", "Họ tên", 24);
            ThemCot("Email", "Email", 28);
            ThemCot("QuyenHan", "Vai trò", 14);
            ThemCot("TrangThai", "Trạng thái", 12);
        }

        private DataGridViewTextBoxColumn ThemCot(string ten, string tieuDe, float tyLe)
        {
            var cot = new DataGridViewTextBoxColumn
            {
                Name = ten,
                DataPropertyName = ten,
                HeaderText = tieuDe,
                FillWeight = tyLe,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            dgvNguoiDung.Columns.Add(cot);
            return cot;
        }

        // ==========================================
        // NẠP DỮ LIỆU / TÌM KIẾM
        // ==========================================
        // Nạp lại từ CSDL; maChon > 0 thì chọn lại tài khoản đó
        private void NapLuoi(int maChon)
        {
            var kq = NguoiDungNV.LayDanhSach();
            if (!kq.ThanhCong)
            {
                MessageBox.Show(kq.ThongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _dangNap = true;
            try
            {
                _bang = kq.DuLieu;
                _view = new DataView(_bang);
                ApDungLoc();
                dgvNguoiDung.DataSource = _view;
                ChonTheoMa(maChon);
            }
            finally
            {
                _dangNap = false;
            }

            CapNhatSoLuong();
            CapNhatChanTrang();
        }

        private void TimKiem()
        {
            if (_view == null) return;

            int ma = LayMaDangChon();
            _dangNap = true;
            try
            {
                ApDungLoc();
                ChonTheoMa(ma);
            }
            finally
            {
                _dangNap = false;
            }
            CapNhatSoLuong();
            CapNhatChanTrang();
        }

        private void ApDungLoc()
        {
            string tu = txtTimKiem.Text.Trim();
            if (tu.Length == 0)
            {
                _view.RowFilter = "";
                return;
            }
            string e = ThoatKyTuLoc(tu);
            _view.RowFilter = $"TenDangNhap LIKE '%{e}%' OR HoTen LIKE '%{e}%' OR Email LIKE '%{e}%'";
        }

        // Thoát các ký tự đặc biệt của biểu thức RowFilter / LIKE
        private static string ThoatKyTuLoc(string s)
        {
            var sb = new StringBuilder();
            foreach (char c in s)
            {
                if (c == '\'') sb.Append("''");
                else if (c == '[' || c == ']' || c == '*' || c == '%') sb.Append('[').Append(c).Append(']');
                else sb.Append(c);
            }
            return sb.ToString();
        }

        private void ChonTheoMa(int ma)
        {
            dgvNguoiDung.ClearSelection();
            dgvNguoiDung.CurrentCell = null;
            if (ma <= 0) return;

            foreach (DataGridViewRow dong in dgvNguoiDung.Rows)
            {
                var d = dong.DataBoundItem as DataRowView;
                if (d != null && Convert.ToInt32(d["MaND"]) == ma)
                {
                    dgvNguoiDung.CurrentCell = dong.Cells["TenDangNhap"];
                    dong.Selected = true;
                    return;
                }
            }
        }

        // ==========================================
        // HIỂN THỊ
        // ==========================================
        private void CapNhatSoLuong()
        {
            int tong = 0, hoatDong = 0, khoa = 0;
            if (_bang != null)
            {
                foreach (DataRow r in _bang.Rows)
                {
                    tong++;
                    if (Convert.ToBoolean(r["TrangThai"])) hoatDong++; else khoa++;
                }
            }
            string text = $"{tong} tài khoản • {hoatDong} hoạt động • {khoa} đã khóa";
            if (_view != null && txtTimKiem.Text.Trim().Length > 0)
                text += $" • Tìm thấy {_view.Count}";
            lblSoLuong.Text = text;
        }

        private void dgvNguoiDung_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string cot = dgvNguoiDung.Columns[e.ColumnIndex].Name;

            if (cot == "TenDangNhap")
            {
                // Dòng đang chọn: tên đăng nhập in đậm
                if (dgvNguoiDung.Rows[e.RowIndex].Selected) e.CellStyle.Font = FontDam;
            }
            else if (cot == "Email")
            {
                if (string.IsNullOrWhiteSpace(Convert.ToString(e.Value)))
                {
                    e.Value = "Chưa cung cấp";
                    e.CellStyle.ForeColor = MauXam;
                    e.FormattingApplied = true;
                }
            }
            else if (cot == "QuyenHan")
            {
                e.Value = TenQuyen(Convert.ToString(e.Value));
                e.FormattingApplied = true;
            }
            else if (cot == "TrangThai")
            {
                bool hoatDong = e.Value != null && e.Value != DBNull.Value && Convert.ToBoolean(e.Value);
                e.Value = hoatDong ? "Hoạt động" : "Đã khóa";
                if (!hoatDong) e.CellStyle.ForeColor = MauDo;
                e.FormattingApplied = true;
            }
        }

        private static string TenQuyen(string quyen)
        {
            return string.Equals(quyen, "Admin", StringComparison.OrdinalIgnoreCase) ? "Quản trị viên" : "Người dùng";
        }

        private void KhiDoiDongChon()
        {
            if (_dangNap) return;
            CapNhatChanTrang();
            dgvNguoiDung.Invalidate();   // vẽ lại để cập nhật chữ đậm
        }

        // Cập nhật dòng "Đang chọn..." và trạng thái 3 nút
        private void CapNhatChanTrang()
        {
            var d = LayDongChon();
            bool coChon = d != null;
            bool laAdmin = PhienDangNhap.LaAdmin;

            if (laAdmin)
            {
                lblCheDo.Text = GoiYCheDo;
                lblCheDo.ForeColor = MauXam;
            }

            if (!coChon)
            {
                lblTaiKhoanDaChon.Text = "Chưa chọn tài khoản";
                btnKhoaMoKhoa.Text = "Khóa";
            }
            else
            {
                bool hoatDong = Convert.ToBoolean(d["TrangThai"]);
                lblTaiKhoanDaChon.Text = $"Đang chọn: {d["TenDangNhap"]} • {(hoatDong ? "Hoạt động" : "Đã khóa")}";
                btnKhoaMoKhoa.Text = hoatDong ? "Khóa" : "Mở khóa";
            }

            btnKhoaMoKhoa.Enabled = coChon && laAdmin;
            btnDatLaiMatKhau.Enabled = coChon && laAdmin;
            btnDoiQuyen.Enabled = coChon && laAdmin;
        }

        private DataRowView LayDongChon()
        {
            if (dgvNguoiDung.SelectedRows.Count == 0) return null;
            return dgvNguoiDung.SelectedRows[0].DataBoundItem as DataRowView;
        }

        private int LayMaDangChon()
        {
            var d = LayDongChon();
            return d == null ? 0 : Convert.ToInt32(d["MaND"]);
        }

        // Thành công: hiện ngay ở góc phải dòng thông tin (không bật popup); lỗi: MessageBox
        private void BaoThanhCong(string thongDiep)
        {
            lblCheDo.Text = "✓ " + thongDiep;
            lblCheDo.ForeColor = MauXanhLa;
        }

        private static void BaoLoi(string thongDiep)
        {
            MessageBox.Show(thongDiep, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ==========================================
        // HÀNH ĐỘNG
        // ==========================================
        private void XuLyKhoaMoKhoa()
        {
            var d = LayDongChon();
            if (d == null) { BaoLoi("Bạn chưa chọn tài khoản nào."); return; }

            int ma = Convert.ToInt32(d["MaND"]);
            string ten = Convert.ToString(d["TenDangNhap"]);
            bool hoatDong = Convert.ToBoolean(d["TrangThai"]);

            string hoi = hoatDong
                ? $"Khóa tài khoản \"{ten}\"?\nNgười dùng sẽ không đăng nhập được cho đến khi được mở khóa."
                : $"Mở khóa tài khoản \"{ten}\"?";
            if (MessageBox.Show(hoi, hoatDong ? "Khóa tài khoản" : "Mở khóa tài khoản",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var kq = NguoiDungNV.KhoaMoKhoa(ma, !hoatDong);
            if (!kq.ThanhCong) { BaoLoi(kq.ThongBao); return; }

            NapLuoi(ma);
            BaoThanhCong(kq.ThongBao);
        }

        private void XuLyDoiQuyen()
        {
            var d = LayDongChon();
            if (d == null) { BaoLoi("Bạn chưa chọn tài khoản nào."); return; }

            int ma = Convert.ToInt32(d["MaND"]);
            string ten = Convert.ToString(d["TenDangNhap"]);
            string hienTai = Convert.ToString(d["QuyenHan"]);
            string moi = string.Equals(hienTai, "Admin", StringComparison.OrdinalIgnoreCase) ? "User" : "Admin";

            string hoi = $"Đổi quyền của \"{ten}\" từ {TenQuyen(hienTai)} sang {TenQuyen(moi)}?";
            if (MessageBox.Show(hoi, "Đổi quyền", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var kq = NguoiDungNV.DoiQuyen(ma, moi);
            if (!kq.ThanhCong) { BaoLoi(kq.ThongBao); return; }

            NapLuoi(ma);
            BaoThanhCong(kq.ThongBao);
        }

        private void XuLyDatLaiMatKhau()
        {
            var d = LayDongChon();
            if (d == null) { BaoLoi("Bạn chưa chọn tài khoản nào."); return; }

            int ma = Convert.ToInt32(d["MaND"]);
            string ten = Convert.ToString(d["TenDangNhap"]);

            string matKhau = HoiMatKhauMoi(ten);
            if (matKhau == null) return;   // người dùng bấm Hủy

            var kq = NguoiDungNV.DatLaiMatKhau(ma, matKhau);
            if (!kq.ThanhCong) { BaoLoi(kq.ThongBao); return; }

            BaoThanhCong(kq.ThongBao);
        }

        // Hộp thoại nhập mật khẩu mới; trả về null nếu hủy
        private string HoiMatKhauMoi(string tenDangNhap)
        {
            using (var f = new Form())
            {
                f.Text = "Đặt lại mật khẩu";
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.StartPosition = FormStartPosition.CenterParent;
                f.MaximizeBox = false;
                f.MinimizeBox = false;
                f.ShowInTaskbar = false;
                f.ClientSize = new Size(360, 148);
                f.Font = Font;

                var lbl = new Label { Text = $"Mật khẩu mới cho \"{tenDangNhap}\":", AutoSize = true, Location = new Point(16, 16) };
                var txt = new TextBox { Location = new Point(16, 40), Width = 328, UseSystemPasswordChar = true };
                var goiY = new Label { Text = "Tối thiểu 8 ký tự, gồm chữ và số.", AutoSize = true, ForeColor = MauXam, Location = new Point(16, 70) };
                var ok = new Button { Text = "Đặt lại", DialogResult = DialogResult.OK, Location = new Point(188, 104), Size = new Size(75, 28) };
                var huy = new Button { Text = "Hủy", DialogResult = DialogResult.Cancel, Location = new Point(269, 104), Size = new Size(75, 28) };

                f.Controls.AddRange(new Control[] { lbl, txt, goiY, ok, huy });
                f.AcceptButton = ok;
                f.CancelButton = huy;

                return f.ShowDialog(this) == DialogResult.OK ? txt.Text : null;
            }
        }
    }
}
