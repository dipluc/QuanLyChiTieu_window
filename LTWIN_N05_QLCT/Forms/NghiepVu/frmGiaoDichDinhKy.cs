using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using MoHinh;
using NghiepVu;
using NghiepVu.TienIch;

namespace LTWIN_N05_QLCT.Forms.NghiepVu
{
    public partial class frmGiaoDichDinhKy : Form
    {
        private static readonly Color MauXanhLa = Color.FromArgb(46, 125, 50);
        private static readonly Color MauDo = Color.FromArgb(198, 40, 40);

        private List<GiaoDichDinhKyMH> _dsGiaoDich = new List<GiaoDichDinhKyMH>();
        private int _maDangChon = 0;       // 0 = chưa chọn bản ghi nào
        private bool _cheDoThem = false;   // true khi đang thêm mới
        private bool _dangNap = false;     // chặn sự kiện khi nạp dữ liệu cho ComboBox

        public frmGiaoDichDinhKy()
        {
            InitializeComponent();
            KhoiTao();
        }

        // ==========================================
        // KHỞI TẠO
        // ==========================================
        private void KhoiTao()
        {
            // Gắn sự kiện bằng code (giống các form khác trong dự án)
            Load += frmGiaoDichDinhKy_Load;
            btnThem.Click += (s, e) => XuLyThem();
            btnSua.Click += (s, e) => XuLySua();
            btnXoa.Click += (s, e) => XuLyXoa();
            btnLuu.Click += (s, e) => XuLyLuu();
            btnBoQua.Click += (s, e) => XuLyBoQua();
            btnDong.Click += (s, e) => Close();

            dgvGiaoDich.CellClick += dgvGiaoDich_CellClick;
            dgvGiaoDich.CellFormatting += dgvGiaoDich_CellFormatting;
            cboLoaiGD.SelectedIndexChanged += cboLoaiGD_SelectedIndexChanged;
            dtpNgayBatDau.ValueChanged += dtpNgayBatDau_ValueChanged;
            txtSoTien.KeyPress += txtSoTien_KeyPress;

            txtSoTien.KeyDown += Enter_KeyDown;
            txtGhiChu.KeyDown += Enter_KeyDown;
            cboLoaiGD.KeyDown += Enter_KeyDown;
            cboDanhMuc.KeyDown += Enter_KeyDown;
            cboMaVi.KeyDown += Enter_KeyDown;
            cboTanSuat.KeyDown += Enter_KeyDown;
            dtpNgayBatDau.KeyDown += Enter_KeyDown;
            dtpNgayKetThuc.KeyDown += Enter_KeyDown;
            dtpNgayKeTiep.KeyDown += Enter_KeyDown;
        }

        private void frmGiaoDichDinhKy_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            CauHinhLuoi();
            NapComboCoDinh();
            NapDanhSachVi();
            NapLuoi();
            ResetValues();
            DatCheDo(false);
        }

        // ==========================================
        // NẠP DỮ LIỆU
        // ==========================================
        private void CauHinhLuoi()
        {
            dgvGiaoDich.AutoGenerateColumns = false;
            dgvGiaoDich.Columns.Clear();

            ThemCot("MaGDDK", "Mã", 60);
            ThemCot("LoaiGiaoDich", "Loại", 80);
            ThemCot("TenDanhMuc", "Danh mục", 130);
            ThemCot("TenVi", "Ví", 120);
            ThemCot("SoTien", "Số tiền", 100, "N0", DataGridViewContentAlignment.MiddleRight);
            ThemCot("TanSuat", "Tần suất", 90);
            ThemCot("NgayBatDau", "Ngày bắt đầu", 100, "dd/MM/yyyy");
            ThemCot("NgayKetThuc", "Ngày kết thúc", 110, "dd/MM/yyyy");
            ThemCot("NgayDenHanTiepTheo", "Đến hạn tiếp theo", 120, "dd/MM/yyyy");
            ThemCot("TrangThai", "Trạng thái", 90);
            ThemCot("GhiChu", "Ghi chú", 150);

            dgvGiaoDich.Columns["NgayKetThuc"].DefaultCellStyle.NullValue = "Không giới hạn";
            dgvGiaoDich.Columns["GhiChu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void ThemCot(string tenThuocTinh, string tieuDe, int rong, string dinhDang = null,
                             DataGridViewContentAlignment canLe = DataGridViewContentAlignment.MiddleLeft)
        {
            var cot = new DataGridViewTextBoxColumn
            {
                Name = tenThuocTinh,
                DataPropertyName = tenThuocTinh,
                HeaderText = tieuDe,
                Width = rong,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            if (!string.IsNullOrEmpty(dinhDang)) cot.DefaultCellStyle.Format = dinhDang;
            cot.DefaultCellStyle.Alignment = canLe;
            dgvGiaoDich.Columns.Add(cot);
        }

        private void NapComboCoDinh()
        {
            _dangNap = true;

            cboLoaiGD.DisplayMember = "Value";
            cboLoaiGD.ValueMember = "Key";
            cboLoaiGD.DataSource = new List<KeyValuePair<string, string>>(GiaoDichDinhKyNV.DanhSachLoai);

            cboTanSuat.DisplayMember = "Value";
            cboTanSuat.ValueMember = "Key";
            cboTanSuat.DataSource = new List<KeyValuePair<string, string>>(GiaoDichDinhKyNV.DanhSachTanSuat);

            cboLoaiGD.SelectedIndex = -1;
            cboTanSuat.SelectedIndex = -1;

            _dangNap = false;
        }

        private void NapDanhSachVi()
        {
            _dangNap = true;
            cboMaVi.DisplayMember = "TenVi";
            cboMaVi.ValueMember = "MaVi";
            cboMaVi.DataSource = GiaoDichDinhKyNV.LayDanhSachVi();
            cboMaVi.SelectedIndex = -1;
            _dangNap = false;
        }

        // Danh mục phụ thuộc loại giao dịch: Thu => LoaiThu, Chi => LoaiChi
        private void NapDanhMuc()
        {
            _dangNap = true;
            string loai = cboLoaiGD.SelectedValue as string;
            cboDanhMuc.DisplayMember = "Ten";
            cboDanhMuc.ValueMember = "Ma";
            cboDanhMuc.DataSource = string.IsNullOrEmpty(loai) ? null : GiaoDichDinhKyNV.LayDanhMuc(loai);
            cboDanhMuc.SelectedIndex = -1;
            _dangNap = false;
        }

        private void NapLuoi()
        {
            _dsGiaoDich = GiaoDichDinhKyNV.LayDanhSach();
            dgvGiaoDich.DataSource = null;
            dgvGiaoDich.DataSource = _dsGiaoDich;
            dgvGiaoDich.ClearSelection();
        }

        // ==========================================
        // TRẠNG THÁI GIAO DIỆN
        // ==========================================
        private void DatCheDo(bool dangThem)
        {
            _cheDoThem = dangThem;
            bool coChon = _maDangChon > 0;

            btnThem.Enabled = !dangThem;
            btnSua.Enabled = !dangThem && coChon;
            btnXoa.Enabled = !dangThem && coChon;
            btnLuu.Enabled = dangThem;
            btnBoQua.Enabled = dangThem || coChon;
        }

        private void ResetValues()
        {
            _dangNap = true;
            _maDangChon = 0;
            txtMaGD.Text = "(Tự động)";
            cboLoaiGD.SelectedIndex = -1;
            cboDanhMuc.DataSource = null;
            cboMaVi.SelectedIndex = -1;
            txtSoTien.Text = "0";
            cboTanSuat.SelectedIndex = -1;
            dtpNgayBatDau.Value = DateTime.Today;
            dtpNgayKetThuc.Value = DateTime.Today;
            dtpNgayKetThuc.Checked = false;
            dtpNgayKeTiep.Value = DateTime.Today;
            txtGhiChu.Text = "";
            chkTrangThai.Checked = true;
            _dangNap = false;
        }

        private void HienThongBao(string thongDiep, bool laLoi)
        {
            lblThongBao.Text = thongDiep;
            lblThongBao.ForeColor = laLoi ? MauDo : MauXanhLa;
            lblThongBao.Visible = true;
        }

        // ==========================================
        // SỰ KIỆN LƯỚI & ĐIỀU KHIỂN
        // ==========================================
        private void dgvGiaoDich_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            lblThongBao.Visible = false;

            if (_cheDoThem)
            {
                HienThongBao("Đang ở chế độ thêm mới. Hãy bấm Lưu hoặc Bỏ qua.", true);
                return;
            }

            var gd = dgvGiaoDich.Rows[e.RowIndex].DataBoundItem as GiaoDichDinhKyMH;
            if (gd == null) return;

            HienLenForm(gd);
            DatCheDo(false);
        }

        private void HienLenForm(GiaoDichDinhKyMH gd)
        {
            _maDangChon = gd.MaGDDK;
            txtMaGD.Text = gd.MaGDDK.ToString();

            _dangNap = true;
            cboLoaiGD.SelectedValue = gd.LoaiGiaoDich;
            _dangNap = false;
            NapDanhMuc();   // nạp danh mục theo loại rồi mới chọn giá trị

            int? maDM = gd.LoaiGiaoDich == "Thu" ? gd.MaLoaiThu : gd.MaLoaiChi;
            if (maDM.HasValue) cboDanhMuc.SelectedValue = maDM.Value;
            else cboDanhMuc.SelectedIndex = -1;

            cboMaVi.SelectedValue = gd.MaVi;
            txtSoTien.Text = ((long)gd.SoTien).ToString(CultureInfo.InvariantCulture);
            cboTanSuat.SelectedValue = gd.TanSuat;
            dtpNgayBatDau.Value = gd.NgayBatDau;
            if (gd.NgayKetThuc.HasValue)
            {
                dtpNgayKetThuc.Value = gd.NgayKetThuc.Value;
                dtpNgayKetThuc.Checked = true;
            }
            else
            {
                dtpNgayKetThuc.Checked = false;
            }
            dtpNgayKeTiep.Value = gd.NgayDenHanTiepTheo;
            txtGhiChu.Text = gd.GhiChu ?? "";
            chkTrangThai.Checked = gd.TrangThai;
        }

        private void dgvGiaoDich_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;
            string tenCot = dgvGiaoDich.Columns[e.ColumnIndex].Name;

            if (tenCot == "LoaiGiaoDich")
            {
                string ma = e.Value.ToString();
                e.Value = GiaoDichDinhKyNV.TenLoai(ma);
                e.CellStyle.ForeColor = ma == "Thu" ? MauXanhLa : MauDo;
                e.FormattingApplied = true;
            }
            else if (tenCot == "TanSuat")
            {
                e.Value = GiaoDichDinhKyNV.TenTanSuat(e.Value.ToString());
                e.FormattingApplied = true;
            }
            else if (tenCot == "TrangThai")
            {
                e.Value = Convert.ToBoolean(e.Value) ? "Hoạt động" : "Tạm dừng";
                e.FormattingApplied = true;
            }
        }

        private void cboLoaiGD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dangNap) return;
            NapDanhMuc();
        }

        // Thêm mới: ngày đến hạn đầu tiên mặc định bằng ngày bắt đầu
        private void dtpNgayBatDau_ValueChanged(object sender, EventArgs e)
        {
            if (_dangNap || !_cheDoThem) return;
            dtpNgayKeTiep.Value = dtpNgayBatDau.Value;
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        // ==========================================
        // THÊM / LƯU / SỬA / XÓA / BỎ QUA
        // ==========================================
        private void XuLyThem()
        {
            lblThongBao.Visible = false;
            ResetValues();
            dgvGiaoDich.ClearSelection();
            DatCheDo(true);
            cboLoaiGD.Focus();
        }

        private void XuLyLuu()
        {
            lblThongBao.Visible = false;
            if (!KiemTraNhap()) return;

            var kq = GiaoDichDinhKyNV.Them(LayDuLieuTuForm());
            if (kq.ThanhCong)
            {
                NapLuoi();
                ResetValues();
                DatCheDo(false);
                HienThongBao("✓ " + kq.ThongBao, false);
            }
            else
            {
                HienThongBao(kq.ThongBao, true);
            }
        }

        private void XuLySua()
        {
            lblThongBao.Visible = false;
            if (_dsGiaoDich.Count == 0)
            {
                HienThongBao("Không còn dữ liệu.", true);
                return;
            }
            if (_maDangChon <= 0)
            {
                HienThongBao("Bạn chưa chọn bản ghi nào.", true);
                return;
            }
            if (!KiemTraNhap()) return;

            var kq = GiaoDichDinhKyNV.Sua(LayDuLieuTuForm());
            if (kq.ThanhCong)
            {
                NapLuoi();
                ResetValues();
                DatCheDo(false);
                HienThongBao("✓ " + kq.ThongBao, false);
            }
            else
            {
                HienThongBao(kq.ThongBao, true);
            }
        }

        private void XuLyXoa()
        {
            lblThongBao.Visible = false;
            if (_dsGiaoDich.Count == 0)
            {
                HienThongBao("Không còn dữ liệu.", true);
                return;
            }
            if (_maDangChon <= 0)
            {
                HienThongBao("Bạn chưa chọn bản ghi nào.", true);
                return;
            }

            var hoi = MessageBox.Show("Bạn có muốn xóa giao dịch định kỳ này không?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi != DialogResult.Yes) return;

            var kq = GiaoDichDinhKyNV.Xoa(_maDangChon);
            if (kq.ThanhCong)
            {
                NapLuoi();
                ResetValues();
                DatCheDo(false);
                HienThongBao("✓ " + kq.ThongBao, false);
            }
            else
            {
                HienThongBao(kq.ThongBao, true);
            }
        }

        private void XuLyBoQua()
        {
            lblThongBao.Visible = false;
            ResetValues();
            dgvGiaoDich.ClearSelection();
            DatCheDo(false);
        }

        // ==========================================
        // KIỂM TRA & LẤY DỮ LIỆU
        // ==========================================
        // Kiểm tra bắt buộc nhập (để đặt focus). Các quy tắc nghiệp vụ còn lại do GiaoDichDinhKyNV kiểm tra.
        private bool KiemTraNhap()
        {
            if (cboLoaiGD.SelectedIndex == -1)
            {
                HienThongBao("Bạn phải chọn loại giao dịch (Thu nhập/Chi tiêu).", true);
                cboLoaiGD.Focus();
                return false;
            }
            if (cboDanhMuc.SelectedIndex == -1)
            {
                HienThongBao("Bạn phải chọn danh mục.", true);
                cboDanhMuc.Focus();
                return false;
            }
            if (cboMaVi.SelectedIndex == -1)
            {
                HienThongBao("Bạn phải chọn ví.", true);
                cboMaVi.Focus();
                return false;
            }
            if (DocSoTien() <= 0)
            {
                HienThongBao("Số tiền phải lớn hơn 0.", true);
                txtSoTien.Focus();
                return false;
            }
            if (cboTanSuat.SelectedIndex == -1)
            {
                HienThongBao("Bạn phải chọn tần suất.", true);
                cboTanSuat.Focus();
                return false;
            }
            return true;
        }

        private decimal DocSoTien()
        {
            decimal v;
            if (decimal.TryParse(txtSoTien.Text.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out v))
                return v;
            return 0;
        }

        private GiaoDichDinhKyMH LayDuLieuTuForm()
        {
            var gd = new GiaoDichDinhKyMH
            {
                MaGDDK = _maDangChon,
                LoaiGiaoDich = cboLoaiGD.SelectedValue as string,
                MaVi = cboMaVi.SelectedIndex >= 0 ? Convert.ToInt32(cboMaVi.SelectedValue) : 0,
                SoTien = DocSoTien(),
                TanSuat = cboTanSuat.SelectedValue as string,
                NgayBatDau = dtpNgayBatDau.Value.Date,
                NgayKetThuc = dtpNgayKetThuc.Checked ? (DateTime?)dtpNgayKetThuc.Value.Date : null,
                NgayDenHanTiepTheo = dtpNgayKeTiep.Value.Date,
                GhiChu = txtGhiChu.Text,
                TrangThai = chkTrangThai.Checked
            };

            int? maDM = cboDanhMuc.SelectedIndex >= 0 ? (int?)Convert.ToInt32(cboDanhMuc.SelectedValue) : null;
            if (gd.LoaiGiaoDich == "Thu") gd.MaLoaiThu = maDM;
            else if (gd.LoaiGiaoDich == "Chi") gd.MaLoaiChi = maDM;

            return gd;
        }
    }
}
