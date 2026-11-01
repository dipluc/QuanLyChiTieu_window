using System;
using System.Drawing;
using System.Windows.Forms;
using NghiepVu;
using NghiepVu.TienIch;

namespace LTWIN_N05_QLCT.Forms.QuanTri
{
    public partial class frmNguoiDung : Form
    {
        private static readonly Color MauXanh = Color.FromArgb(21, 101, 192);
        private static readonly Color MauDo = Color.FromArgb(198, 40, 40);
        private static readonly Color MauXanhLa = Color.FromArgb(46, 125, 50);
        private static readonly Color MauChu = Color.FromArgb(30, 41, 59);
        private static readonly Color MauVienCard = Color.FromArgb(226, 232, 240);
        private static readonly Color MauChon = Color.FromArgb(235, 245, 255);

        private bool _dangNapDuLieu;   // chặn SelectionChanged khi đang nạp lại lưới
        private bool _cheDoThem;       // true khi đang ở chế độ thêm mới

        public frmNguoiDung()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            // Viền card nhập liệu
            pnlNhapLieu.Paint += (s, e) =>
            {
                using (var pen = new Pen(MauVienCard, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, pnlNhapLieu.Width - 1, pnlNhapLieu.Height - 1);
                }
            };

            CauHinhLuoi();

            cboQuyenHan.Items.AddRange(new object[] { "Admin", "User" });
            txtMatKhau.UseSystemPasswordChar = true;

            // Sự kiện
            Load += (s, e) => frmNguoiDung_Load();
            dgvNguoiDung.SelectionChanged += (s, e) => HienThiDongDangChon();
            dgvNguoiDung.CellClick += (s, e) => XuLyClickLuoi();
            btnThem.Click += (s, e) => XuLyThem();
            btnSua.Click += (s, e) => XuLySua();
            btnXoa.Click += (s, e) => XuLyXoa();
            btnLuu.Click += (s, e) => XuLyLuu();
            btnBoQua.Click += (s, e) => XuLyBoQua();
            btnDong.Click += (s, e) => Close();

            // Enter để chuyển sang ô kế tiếp
            txtHoTen.KeyDown += Enter_KeyDown;
            txtTenDangNhap.KeyDown += Enter_KeyDown;
            txtMatKhau.KeyDown += Enter_KeyDown;
            txtEmail.KeyDown += Enter_KeyDown;
        }

        private void frmNguoiDung_Load()
        {
            if (!PhienDangNhap.LaAdmin)
            {
                HienThongBao("Chỉ Quản trị viên mới có quyền quản lý người dùng.", true);
                DatTrangThaiNut(false, false);
                btnThem.Enabled = false;
                return;
            }

            NapLuoi();
            LamTrangForm();
            DatTrangThaiNut(false, false);
        }

        // ==========================================
        // NẠP DỮ LIỆU
        // ==========================================
        private void NapLuoi()
        {
            _dangNapDuLieu = true;
            try
            {
                var kq = NguoiDungNV.LayDanhSach();
                if (!kq.ThanhCong)
                {
                    dgvNguoiDung.DataSource = null;
                    HienThongBao(kq.ThongBao, true);
                    return;
                }

                dgvNguoiDung.DataSource = kq.DuLieu;
                DinhDangCot();
                dgvNguoiDung.ClearSelection();
                dgvNguoiDung.CurrentCell = null;
            }
            finally
            {
                _dangNapDuLieu = false;
            }
        }

        private void CauHinhLuoi()
        {
            dgvNguoiDung.AllowUserToAddRows = false;
            dgvNguoiDung.AllowUserToDeleteRows = false;
            dgvNguoiDung.ReadOnly = true;
            dgvNguoiDung.MultiSelect = false;
            dgvNguoiDung.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNguoiDung.RowHeadersVisible = false;
            dgvNguoiDung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNguoiDung.BackgroundColor = Color.White;
            dgvNguoiDung.BorderStyle = BorderStyle.None;
            dgvNguoiDung.EnableHeadersVisualStyles = false;
            dgvNguoiDung.ColumnHeadersHeight = 34;
            dgvNguoiDung.ColumnHeadersDefaultCellStyle.BackColor = MauXanh;
            dgvNguoiDung.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvNguoiDung.ColumnHeadersDefaultCellStyle.SelectionBackColor = MauXanh;
            dgvNguoiDung.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.25F, FontStyle.Bold);
            dgvNguoiDung.DefaultCellStyle.SelectionBackColor = MauChon;
            dgvNguoiDung.DefaultCellStyle.SelectionForeColor = MauXanh;
            dgvNguoiDung.DefaultCellStyle.ForeColor = MauChu;
            dgvNguoiDung.RowTemplate.Height = 30;
        }

        private void DinhDangCot()
        {
            DatCot("MaND", "Mã", 40);
            DatCot("TenDangNhap", "Tên đăng nhập", 110);
            DatCot("HoTen", "Họ tên", 150);
            DatCot("Email", "Email", 170);
            DatCot("QuyenHan", "Quyền", 70);
            DatCot("TrangThai", "Hoạt động", 70);
            DatCot("NgayTao", "Ngày tạo", 110);

            if (dgvNguoiDung.Columns.Contains("NgayTao"))
            {
                dgvNguoiDung.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
        }

        private void DatCot(string tenCot, string tieuDe, float tyLe)
        {
            if (!dgvNguoiDung.Columns.Contains(tenCot)) return;

            var cot = dgvNguoiDung.Columns[tenCot];
            cot.HeaderText = tieuDe;
            cot.FillWeight = tyLe;
        }

        // ==========================================
        // TRẠNG THÁI GIAO DIỆN
        // ==========================================
        private void LamTrangForm()
        {
            txtMaND.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            txtTenDangNhap.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cboQuyenHan.SelectedIndex = -1;
            chkTrangThai.Checked = true;
            DatCheDoNhap(false);
        }

        // Tên đăng nhập chỉ được nhập khi thêm mới, không cho đổi khi sửa
        private void DatCheDoNhap(bool dangThem)
        {
            txtTenDangNhap.ReadOnly = !dangThem;
            lblGoiYMatKhau.Text = dangThem
                ? "Tối thiểu 8 ký tự, gồm chữ và số."
                : "Để trống nếu không đổi mật khẩu.";
        }

        private void DatTrangThaiNut(bool dangThem, bool coDongChon)
        {
            bool laAdmin = PhienDangNhap.LaAdmin;
            btnThem.Enabled = !dangThem && laAdmin;
            btnSua.Enabled = !dangThem && coDongChon && laAdmin;
            btnXoa.Enabled = !dangThem && coDongChon && laAdmin;
            btnLuu.Enabled = dangThem;
            btnBoQua.Enabled = dangThem || coDongChon;
        }

        private void HienThongBao(string thongDiep, bool laLoi)
        {
            lblThongBao.Text = thongDiep;
            lblThongBao.ForeColor = laLoi ? MauDo : MauXanhLa;
            lblThongBao.Visible = true;
        }

        private void HoanTatThaoTac(string thongDiep)
        {
            _cheDoThem = false;
            NapLuoi();
            LamTrangForm();
            DatTrangThaiNut(false, false);
            HienThongBao("✓ " + thongDiep, false);
        }

        // ==========================================
        // CHỌN DÒNG TRÊN LƯỚI
        // ==========================================
        private void XuLyClickLuoi()
        {
            if (_cheDoThem)
            {
                HienThongBao("Đang ở chế độ thêm mới. Hãy Lưu hoặc Bỏ qua trước khi chọn bản ghi khác.", true);
            }
        }

        private void HienThiDongDangChon()
        {
            if (_dangNapDuLieu || _cheDoThem) return;
            if (dgvNguoiDung.SelectedRows.Count == 0) return;

            DataGridViewRow dong = dgvNguoiDung.SelectedRows[0];
            lblThongBao.Visible = false;

            txtMaND.Text = Convert.ToString(dong.Cells["MaND"].Value);
            txtHoTen.Text = Convert.ToString(dong.Cells["HoTen"].Value);
            txtTenDangNhap.Text = Convert.ToString(dong.Cells["TenDangNhap"].Value);
            txtMatKhau.Text = string.Empty;   // không hiển thị mật khẩu; để trống = giữ nguyên mật khẩu cũ
            txtEmail.Text = Convert.ToString(dong.Cells["Email"].Value);
            cboQuyenHan.SelectedItem = Convert.ToString(dong.Cells["QuyenHan"].Value);
            chkTrangThai.Checked = Convert.ToBoolean(dong.Cells["TrangThai"].Value);
            DatCheDoNhap(false);

            DatTrangThaiNut(false, true);
        }

        // ==========================================
        // THÊM / LƯU
        // ==========================================
        private void XuLyThem()
        {
            _cheDoThem = true;
            lblThongBao.Visible = false;
            dgvNguoiDung.ClearSelection();
            LamTrangForm();
            DatCheDoNhap(true);
            cboQuyenHan.SelectedItem = "User";
            DatTrangThaiNut(true, false);
            txtHoTen.Focus();
        }

        private void XuLyLuu()
        {
            lblThongBao.Visible = false;
            if (!KiemTraNhap(true)) return;

            var kq = NguoiDungNV.Them(txtHoTen.Text, txtTenDangNhap.Text, txtEmail.Text,
                txtMatKhau.Text, Convert.ToString(cboQuyenHan.SelectedItem), chkTrangThai.Checked);
            if (kq.ThanhCong)
            {
                HoanTatThaoTac(kq.ThongBao);
            }
            else
            {
                HienThongBao(kq.ThongBao, true);
            }
        }

        // ==========================================
        // SỬA
        // ==========================================
        private void XuLySua()
        {
            lblThongBao.Visible = false;

            int maND = LayMaDangChon();
            if (maND <= 0)
            {
                HienThongBao("Bạn chưa chọn bản ghi nào.", true);
                return;
            }
            if (!KiemTraNhap(false)) return;

            var kq = NguoiDungNV.CapNhat(maND, txtHoTen.Text, txtEmail.Text, txtMatKhau.Text,
                Convert.ToString(cboQuyenHan.SelectedItem), chkTrangThai.Checked);
            if (kq.ThanhCong)
            {
                HoanTatThaoTac(kq.ThongBao);
            }
            else
            {
                HienThongBao(kq.ThongBao, true);
            }
        }

        // ==========================================
        // XÓA
        // ==========================================
        private void XuLyXoa()
        {
            lblThongBao.Visible = false;

            int maND = LayMaDangChon();
            if (maND <= 0)
            {
                HienThongBao("Bạn chưa chọn bản ghi nào.", true);
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa người dùng \"" + txtTenDangNhap.Text.Trim() + "\" không?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            var kq = NguoiDungNV.Xoa(maND);
            if (kq.ThanhCong)
            {
                HoanTatThaoTac(kq.ThongBao);
            }
            else if (kq.DangDuocSuDung)
            {
                // Không xóa được vì đã có dữ liệu liên quan -> đề nghị khóa tài khoản
                string hoi = kq.ThongBao + Environment.NewLine + "Bạn có muốn khóa tài khoản này không?";
                if (MessageBox.Show(hoi, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var kqKhoa = NguoiDungNV.Khoa(maND);
                    if (kqKhoa.ThanhCong)
                    {
                        HoanTatThaoTac(kqKhoa.ThongBao);
                    }
                    else
                    {
                        HienThongBao(kqKhoa.ThongBao, true);
                    }
                }
            }
            else
            {
                HienThongBao(kq.ThongBao, true);
            }
        }

        // ==========================================
        // BỎ QUA
        // ==========================================
        private void XuLyBoQua()
        {
            _cheDoThem = false;
            lblThongBao.Visible = false;
            LamTrangForm();
            dgvNguoiDung.ClearSelection();
            DatTrangThaiNut(false, false);
        }

        // ==========================================
        // HÀM HỖ TRỢ
        // ==========================================
        private bool KiemTraNhap(bool dangThem)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                HienThongBao("Vui lòng nhập họ tên.", true);
                txtHoTen.Focus();
                return false;
            }
            if (dangThem && string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                HienThongBao("Vui lòng nhập tên đăng nhập.", true);
                txtTenDangNhap.Focus();
                return false;
            }
            if (dangThem && txtMatKhau.Text.Length == 0)
            {
                HienThongBao("Vui lòng nhập mật khẩu.", true);
                txtMatKhau.Focus();
                return false;
            }
            string email = txtEmail.Text.Trim();
            if (email.Length > 0 && !System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                HienThongBao("Email không đúng định dạng. Vui lòng kiểm tra lại.", true);
                txtEmail.Focus();
                return false;
            }
            if (cboQuyenHan.SelectedIndex == -1)
            {
                HienThongBao("Vui lòng chọn quyền hạn.", true);
                cboQuyenHan.Focus();
                return false;
            }
            return true;
        }

        private int LayMaDangChon()
        {
            int ma;
            return int.TryParse(txtMaND.Text, out ma) ? ma : 0;
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
