using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using MoHinh;
using NghiepVu;
using NghiepVu.TienIch;

namespace LTWIN_N05_QLCT.Forms.NghiepVu
{
    public partial class frmMucTieuTietKiem : Form
    {
        private static readonly Color MauXanhLa = Color.FromArgb(46, 125, 50);
        private static readonly Color MauDo = Color.FromArgb(198, 40, 40);
        private static readonly Color MauXam = Color.FromArgb(100, 116, 139);

        private List<MucTieuMH> _dsMucTieu = new List<MucTieuMH>();
        private int _maDangChon = 0;       // 0 = chưa chọn bản ghi nào
        private bool _cheDoThem = false;   // true khi đang thêm mới
        private bool _dangNap = false;     // chặn sự kiện khi nạp dữ liệu

        public frmMucTieuTietKiem()
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
            Load += frmMucTieuTietKiem_Load;
            btnThem.Click += (s, e) => XuLyThem();
            btnSua.Click += (s, e) => XuLySua();
            btnXoa.Click += (s, e) => XuLyXoa();
            btnLuu.Click += (s, e) => XuLyLuu();
            btnBoQua.Click += (s, e) => XuLyBoQua();
            btnNapTien.Click += (s, e) => XuLyNapTien();
            btnDong.Click += (s, e) => Close();

            dgvMucTieu.CellClick += dgvMucTieu_CellClick;
            dgvMucTieu.CellFormatting += dgvMucTieu_CellFormatting;
            txtSoTienMucTieu.TextChanged += (s, e) => TinhTienDo();
            txtSoTienMucTieu.KeyPress += SoTien_KeyPress;
            txtSoTienNap.KeyPress += SoTien_KeyPress;

            txtTenMucTieu.KeyDown += Enter_KeyDown;
            txtSoTienMucTieu.KeyDown += Enter_KeyDown;
            dtpNgayBatDau.KeyDown += Enter_KeyDown;
            dtpNgayDich.KeyDown += Enter_KeyDown;
            cboTrangThai.KeyDown += Enter_KeyDown;
            txtGhiChu.KeyDown += Enter_KeyDown;
            txtSoTienNap.KeyDown += Enter_KeyDown;
        }

        private void frmMucTieuTietKiem_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            CauHinhLuoi();
            NapComboTrangThai();
            NapLuoi();
            ResetValues();
            DatCheDo(false);
        }

        // ==========================================
        // NẠP DỮ LIỆU
        // ==========================================
        private void CauHinhLuoi()
        {
            dgvMucTieu.AutoGenerateColumns = false;
            dgvMucTieu.Columns.Clear();

            ThemCot("MaMT", "Mã", 55);
            ThemCot("TenMucTieu", "Tên mục tiêu", 160);
            ThemCot("SoTienMucTieu", "Số tiền mục tiêu", 120, "N0", DataGridViewContentAlignment.MiddleRight);
            ThemCot("SoTienDaTietKiem", "Đã tiết kiệm", 110, "N0", DataGridViewContentAlignment.MiddleRight);
            ThemCot("ConThieu", "Còn thiếu", 100, "N0", DataGridViewContentAlignment.MiddleRight);
            ThemCot("PhanTram", "Tiến độ", 70, null, DataGridViewContentAlignment.MiddleRight);
            ThemCot("NgayBatDau", "Ngày bắt đầu", 100, "dd/MM/yyyy");
            ThemCot("NgayDich", "Ngày đích", 100, "dd/MM/yyyy");
            ThemCot("TrangThai", "Trạng thái", 110);
            ThemCot("GhiChu", "Ghi chú", 150);

            dgvMucTieu.Columns["NgayDich"].DefaultCellStyle.NullValue = "Không đặt hạn";
            dgvMucTieu.Columns["GhiChu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
            dgvMucTieu.Columns.Add(cot);
        }

        private void NapComboTrangThai()
        {
            _dangNap = true;
            cboTrangThai.DisplayMember = "Value";
            cboTrangThai.ValueMember = "Key";
            cboTrangThai.DataSource = new List<KeyValuePair<string, string>>(MucTieuNV.DanhSachTrangThai);
            cboTrangThai.SelectedIndex = -1;
            _dangNap = false;
        }

        private void NapLuoi()
        {
            _dsMucTieu = MucTieuNV.LayDanhSach();
            dgvMucTieu.DataSource = null;
            dgvMucTieu.DataSource = _dsMucTieu;
            dgvMucTieu.ClearSelection();
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
            btnNapTien.Enabled = !dangThem && coChon;
            txtSoTienNap.Enabled = !dangThem && coChon;
            cboTrangThai.Enabled = !dangThem && coChon;   // thêm mới luôn là "Đang thực hiện"
        }

        private void ResetValues()
        {
            _dangNap = true;
            _maDangChon = 0;
            txtMaMucTieu.Text = "(Tự động)";
            txtTenMucTieu.Text = "";
            txtSoTienMucTieu.Text = "0";
            txtDaTietKiem.Text = "0";
            dtpNgayBatDau.Value = DateTime.Today;
            dtpNgayDich.Value = DateTime.Today.AddMonths(1);
            dtpNgayDich.Checked = false;
            cboTrangThai.SelectedValue = "DangThucHien";
            txtGhiChu.Text = "";
            txtSoTienNap.Text = "0";
            _dangNap = false;
            TinhTienDo();
        }

        private void HienThongBao(string thongDiep, bool laLoi)
        {
            lblThongBao.Text = thongDiep;
            lblThongBao.ForeColor = laLoi ? MauDo : MauXanhLa;
            lblThongBao.Visible = true;
        }

        // Tiến độ = đã tiết kiệm / mục tiêu (tối đa 100%)
        private void TinhTienDo()
        {
            decimal dich = DocSo(txtSoTienMucTieu.Text);
            decimal da = DocSo(txtDaTietKiem.Text);
            int pt = 0;
            if (dich > 0) pt = (int)Math.Min(100, Math.Round(da * 100m / dich));
            prgTienDo.Value = pt;
            lblPhanTram.Text = pt + "%";
        }

        // ==========================================
        // SỰ KIỆN LƯỚI & ĐIỀU KHIỂN
        // ==========================================
        private void dgvMucTieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            lblThongBao.Visible = false;

            if (_cheDoThem)
            {
                HienThongBao("Đang ở chế độ thêm mới. Hãy bấm Lưu hoặc Bỏ qua.", true);
                return;
            }

            var mt = dgvMucTieu.Rows[e.RowIndex].DataBoundItem as MucTieuMH;
            if (mt == null) return;

            HienLenForm(mt);
            DatCheDo(false);
        }

        private void HienLenForm(MucTieuMH mt)
        {
            _dangNap = true;
            _maDangChon = mt.MaMT;
            txtMaMucTieu.Text = mt.MaMT.ToString();
            txtTenMucTieu.Text = mt.TenMucTieu;
            txtSoTienMucTieu.Text = ((long)mt.SoTienMucTieu).ToString(CultureInfo.InvariantCulture);
            txtDaTietKiem.Text = ((long)mt.SoTienDaTietKiem).ToString(CultureInfo.InvariantCulture);
            dtpNgayBatDau.Value = mt.NgayBatDau;
            if (mt.NgayDich.HasValue)
            {
                dtpNgayDich.Value = mt.NgayDich.Value;
                dtpNgayDich.Checked = true;
            }
            else
            {
                dtpNgayDich.Checked = false;
            }
            cboTrangThai.SelectedValue = mt.TrangThai;
            txtGhiChu.Text = mt.GhiChu ?? "";
            txtSoTienNap.Text = "0";
            _dangNap = false;
            TinhTienDo();
        }

        private void dgvMucTieu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;
            string tenCot = dgvMucTieu.Columns[e.ColumnIndex].Name;

            if (tenCot == "TrangThai")
            {
                string ma = e.Value.ToString();
                e.Value = MucTieuNV.TenTrangThai(ma);
                e.CellStyle.ForeColor = ma == "HoanThanh" ? MauXanhLa : (ma == "Huy" ? MauXam : MauDo);
                e.FormattingApplied = true;
            }
            else if (tenCot == "PhanTram")
            {
                e.Value = Convert.ToDecimal(e.Value).ToString("0.#", CultureInfo.CurrentCulture) + "%";
                e.FormattingApplied = true;
            }
        }

        private void SoTien_KeyPress(object sender, KeyPressEventArgs e)
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
        // THÊM / LƯU / SỬA / XÓA / NẠP TIỀN / BỎ QUA
        // ==========================================
        private void XuLyThem()
        {
            lblThongBao.Visible = false;
            ResetValues();
            dgvMucTieu.ClearSelection();
            DatCheDo(true);
            txtTenMucTieu.Focus();
        }

        private void XuLyLuu()
        {
            lblThongBao.Visible = false;
            if (!KiemTraNhap()) return;

            var kq = MucTieuNV.Them(LayDuLieuTuForm());
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
            if (_dsMucTieu.Count == 0)
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

            var kq = MucTieuNV.Sua(LayDuLieuTuForm());
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
            if (_dsMucTieu.Count == 0)
            {
                HienThongBao("Không còn dữ liệu.", true);
                return;
            }
            if (_maDangChon <= 0)
            {
                HienThongBao("Bạn chưa chọn bản ghi nào.", true);
                return;
            }

            var hoi = MessageBox.Show("Bạn có muốn xóa mục tiêu tiết kiệm này không?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (hoi != DialogResult.Yes) return;

            var kq = MucTieuNV.Xoa(_maDangChon);
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

        // Nạp tiền vào mục tiêu đang chọn
        private void XuLyNapTien()
        {
            lblThongBao.Visible = false;
            if (_maDangChon <= 0)
            {
                HienThongBao("Bạn hãy chọn một mục tiêu trong lưới trước.", true);
                return;
            }
            decimal tien = DocSo(txtSoTienNap.Text);
            if (tien <= 0)
            {
                HienThongBao("Số tiền nạp phải lớn hơn 0.", true);
                txtSoTienNap.Focus();
                return;
            }

            int ma = _maDangChon;
            var kq = MucTieuNV.NapTien(ma, tien);
            if (kq.ThanhCong)
            {
                NapLuoi();
                var mt = _dsMucTieu.Find(x => x.MaMT == ma);
                if (mt != null) HienLenForm(mt);
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
            dgvMucTieu.ClearSelection();
            DatCheDo(false);
        }

        // ==========================================
        // KIỂM TRA & LẤY DỮ LIỆU
        // ==========================================
        // Kiểm tra bắt buộc nhập (để đặt focus). Các quy tắc nghiệp vụ còn lại do MucTieuNV kiểm tra.
        private bool KiemTraNhap()
        {
            if (txtTenMucTieu.Text.Trim().Length == 0)
            {
                HienThongBao("Bạn phải nhập tên mục tiêu.", true);
                txtTenMucTieu.Focus();
                return false;
            }
            if (DocSo(txtSoTienMucTieu.Text) <= 0)
            {
                HienThongBao("Số tiền mục tiêu phải lớn hơn 0.", true);
                txtSoTienMucTieu.Focus();
                return false;
            }
            if (dtpNgayDich.Checked && dtpNgayDich.Value.Date <= dtpNgayBatDau.Value.Date)
            {
                HienThongBao("Ngày đích phải sau ngày bắt đầu.", true);
                dtpNgayDich.Focus();
                return false;
            }
            return true;
        }

        private decimal DocSo(string text)
        {
            decimal v;
            if (decimal.TryParse((text ?? "").Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out v))
                return v;
            return 0;
        }

        private MucTieuMH LayDuLieuTuForm()
        {
            return new MucTieuMH
            {
                MaMT = _maDangChon,
                TenMucTieu = txtTenMucTieu.Text,
                SoTienMucTieu = DocSo(txtSoTienMucTieu.Text),
                NgayBatDau = dtpNgayBatDau.Value.Date,
                NgayDich = dtpNgayDich.Checked ? (DateTime?)dtpNgayDich.Value.Date : null,
                TrangThai = cboTrangThai.SelectedValue as string ?? "DangThucHien",
                GhiChu = txtGhiChu.Text
            };
        }
    }
}
