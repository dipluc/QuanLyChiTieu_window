using System;
using System.Drawing;
using System.Windows.Forms;
using MoHinh;
using NghiepVu;

namespace LTWIN_N05_QLCT.Forms.DanhMuc
{
    public partial class frmLoaiChiTieu : Form
    {
        private static readonly Color MauXanh = Color.FromArgb(21, 101, 192);
        private static readonly Color MauDo = Color.FromArgb(198, 40, 40);
        private static readonly Color MauXanhLa = Color.FromArgb(46, 125, 50);
        private static readonly Color MauChu = Color.FromArgb(30, 41, 59);
        private static readonly Color MauVienCard = Color.FromArgb(226, 232, 240);
        private static readonly Color MauChon = Color.FromArgb(235, 245, 255);

        private bool _dangNapDuLieu;   // chặn SelectionChanged khi đang nạp lại lưới
        private bool _cheDoThem;       // true khi đang ở chế độ thêm mới
        private bool _coNhomChi;       // có ít nhất một nhóm chi để chọn

        public frmLoaiChiTieu()
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

            // Sự kiện
            Load += (s, e) => frmLoaiChiTieu_Load();
            dgvLoaiChiTieu.SelectionChanged += (s, e) => HienThiDongDangChon();
            dgvLoaiChiTieu.CellClick += (s, e) => XuLyClickLuoi();
            btnThem.Click += (s, e) => XuLyThem();
            btnSua.Click += (s, e) => XuLySua();
            btnXoa.Click += (s, e) => XuLyXoa();
            btnLuu.Click += (s, e) => XuLyLuu();
            btnBoQua.Click += (s, e) => XuLyBoQua();
            btnDong.Click += (s, e) => Close();
        }

        private void frmLoaiChiTieu_Load()
        {
            NapNhomChi();
            NapLuoi();
            LamTrangForm();
            DatTrangThaiNut(false, false);
        }

        // ==========================================
        // NẠP DỮ LIỆU
        // ==========================================
        private void NapNhomChi()
        {
            var kq = LoaiChiNV.LayDanhSachNhomChi();
            if (!kq.ThanhCong)
            {
                _coNhomChi = false;
                HienThongBao(kq.ThongBao, true);
                return;
            }

            cboNhomChi.DisplayMember = "TenNhom";
            cboNhomChi.ValueMember = "MaNhom";
            cboNhomChi.DataSource = kq.DuLieu;
            cboNhomChi.SelectedIndex = -1;

            _coNhomChi = kq.DuLieu.Rows.Count > 0;
            if (!_coNhomChi)
            {
                HienThongBao("Chưa có nhóm chi nào. Vui lòng tạo nhóm chi trước khi thêm loại chi.", true);
            }
        }

        private void NapLuoi()
        {
            _dangNapDuLieu = true;
            try
            {
                var kq = LoaiChiNV.LayDanhSach();
                if (!kq.ThanhCong)
                {
                    dgvLoaiChiTieu.DataSource = null;
                    HienThongBao(kq.ThongBao, true);
                    return;
                }

                dgvLoaiChiTieu.DataSource = kq.DuLieu;
                DinhDangCot();
                dgvLoaiChiTieu.ClearSelection();
                dgvLoaiChiTieu.CurrentCell = null;
            }
            finally
            {
                _dangNapDuLieu = false;
            }
        }

        private void CauHinhLuoi()
        {
            dgvLoaiChiTieu.AllowUserToAddRows = false;
            dgvLoaiChiTieu.AllowUserToDeleteRows = false;
            dgvLoaiChiTieu.ReadOnly = true;
            dgvLoaiChiTieu.MultiSelect = false;
            dgvLoaiChiTieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoaiChiTieu.RowHeadersVisible = false;
            dgvLoaiChiTieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLoaiChiTieu.BackgroundColor = Color.White;
            dgvLoaiChiTieu.BorderStyle = BorderStyle.None;
            dgvLoaiChiTieu.EnableHeadersVisualStyles = false;
            dgvLoaiChiTieu.ColumnHeadersHeight = 34;
            dgvLoaiChiTieu.ColumnHeadersDefaultCellStyle.BackColor = MauXanh;
            dgvLoaiChiTieu.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLoaiChiTieu.ColumnHeadersDefaultCellStyle.SelectionBackColor = MauXanh;
            dgvLoaiChiTieu.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.25F, FontStyle.Bold);
            dgvLoaiChiTieu.DefaultCellStyle.SelectionBackColor = MauChon;
            dgvLoaiChiTieu.DefaultCellStyle.SelectionForeColor = MauXanh;
            dgvLoaiChiTieu.DefaultCellStyle.ForeColor = MauChu;
            dgvLoaiChiTieu.RowTemplate.Height = 30;
        }

        private void DinhDangCot()
        {
            DatCot("MaLoaiChi", "Mã", 40, true);
            DatCot("MaNhom", "Mã nhóm", 0, false);
            DatCot("TenNhom", "Nhóm chi", 120, true);
            DatCot("TenLoaiChi", "Tên loại chi", 160, true);
            DatCot("GhiChu", "Ghi chú", 200, true);
            DatCot("TrangThai", "Đang sử dụng", 70, true);
        }

        private void DatCot(string tenCot, string tieuDe, float tyLe, bool hienThi)
        {
            if (!dgvLoaiChiTieu.Columns.Contains(tenCot)) return;

            var cot = dgvLoaiChiTieu.Columns[tenCot];
            cot.HeaderText = tieuDe;
            cot.Visible = hienThi;
            if (hienThi) cot.FillWeight = tyLe;
        }

        // ==========================================
        // TRẠNG THÁI GIAO DIỆN
        // ==========================================
        private void LamTrangForm()
        {
            txtMaLoaiChi.Text = string.Empty;
            cboNhomChi.SelectedIndex = -1;
            txtTenLoaiChi.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            chkTrangThai.Checked = true;
        }

        private void DatTrangThaiNut(bool dangThem, bool coDongChon)
        {
            btnThem.Enabled = !dangThem && _coNhomChi;
            btnSua.Enabled = !dangThem && coDongChon;
            btnXoa.Enabled = !dangThem && coDongChon;
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
            if (dgvLoaiChiTieu.SelectedRows.Count == 0) return;

            DataGridViewRow dong = dgvLoaiChiTieu.SelectedRows[0];
            lblThongBao.Visible = false;

            txtMaLoaiChi.Text = Convert.ToString(dong.Cells["MaLoaiChi"].Value);
            cboNhomChi.SelectedValue = dong.Cells["MaNhom"].Value;
            txtTenLoaiChi.Text = Convert.ToString(dong.Cells["TenLoaiChi"].Value);
            txtGhiChu.Text = Convert.ToString(dong.Cells["GhiChu"].Value);
            chkTrangThai.Checked = Convert.ToBoolean(dong.Cells["TrangThai"].Value);

            DatTrangThaiNut(false, true);
        }

        // ==========================================
        // THÊM / LƯU
        // ==========================================
        private void XuLyThem()
        {
            _cheDoThem = true;
            lblThongBao.Visible = false;
            dgvLoaiChiTieu.ClearSelection();
            LamTrangForm();
            DatTrangThaiNut(true, false);
            txtTenLoaiChi.Focus();
        }

        private void XuLyLuu()
        {
            lblThongBao.Visible = false;
            if (!KiemTraNhap()) return;

            var kq = LoaiChiNV.Them(TaoMoHinh(0));
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

            int maLoaiChi = LayMaDangChon();
            if (maLoaiChi <= 0)
            {
                HienThongBao("Bạn chưa chọn bản ghi nào.", true);
                return;
            }
            if (!KiemTraNhap()) return;

            var kq = LoaiChiNV.CapNhat(TaoMoHinh(maLoaiChi));
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

            int maLoaiChi = LayMaDangChon();
            if (maLoaiChi <= 0)
            {
                HienThongBao("Bạn chưa chọn bản ghi nào.", true);
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa loại chi \"" + txtTenLoaiChi.Text.Trim() + "\" không?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            var kq = LoaiChiNV.Xoa(maLoaiChi);
            if (kq.ThanhCong)
            {
                HoanTatThaoTac(kq.ThongBao);
            }
            else if (kq.DangDuocSuDung)
            {
                // Không xóa được vì đã có dữ liệu liên quan -> đề nghị chuyển sang ngừng sử dụng
                string hoi = kq.ThongBao + Environment.NewLine + "Bạn có muốn chuyển loại chi này sang trạng thái ngừng sử dụng không?";
                if (MessageBox.Show(hoi, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var kqTrangThai = LoaiChiNV.DatTrangThai(maLoaiChi, false);
                    if (kqTrangThai.ThanhCong)
                    {
                        HoanTatThaoTac(kqTrangThai.ThongBao);
                    }
                    else
                    {
                        HienThongBao(kqTrangThai.ThongBao, true);
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
            dgvLoaiChiTieu.ClearSelection();
            DatTrangThaiNut(false, false);
        }

        // ==========================================
        // HÀM HỖ TRỢ
        // ==========================================
        private bool KiemTraNhap()
        {
            if (cboNhomChi.SelectedValue == null)
            {
                HienThongBao("Vui lòng chọn nhóm chi.", true);
                cboNhomChi.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenLoaiChi.Text))
            {
                HienThongBao("Vui lòng nhập tên loại chi.", true);
                txtTenLoaiChi.Focus();
                return false;
            }
            return true;
        }

        private LoaiChiMH TaoMoHinh(int maLoaiChi)
        {
            return new LoaiChiMH
            {
                MaLoaiChi = maLoaiChi,
                MaNhom = Convert.ToInt32(cboNhomChi.SelectedValue),
                TenLoaiChi = txtTenLoaiChi.Text.Trim(),
                GhiChu = txtGhiChu.Text.Trim(),
                TrangThai = chkTrangThai.Checked
            };
        }

        private int LayMaDangChon()
        {
            int ma;
            return int.TryParse(txtMaLoaiChi.Text, out ma) ? ma : 0;
        }
    }
}
