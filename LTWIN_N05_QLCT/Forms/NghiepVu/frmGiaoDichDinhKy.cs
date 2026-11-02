using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MoHinh;
using NghiepVu;
using NghiepVu.TienIch;

namespace LTWIN_N05_QLCT.Forms.NghiepVu
{
    /// <summary>
    /// Bố cục: trái = form nhập lịch định kỳ (Thêm / Sửa / Tạm dừng-Tiếp tục / Xóa);
    /// phải = TabControl (tpDanhSach: toàn bộ lịch, tpDenHan: các khoản đến hạn chờ xác nhận).
    /// </summary>
    public partial class frmGiaoDichDinhKy : Form
    {
        private static readonly CultureInfo Vi = new CultureInfo("vi-VN");
        private static readonly Color MauXanhLa = Color.FromArgb(46, 125, 50);
        private static readonly Color MauDo = Color.FromArgb(198, 40, 40);
        private static readonly Color MauXam = Color.FromArgb(148, 163, 184);
        private static readonly Color MauDong = Color.FromArgb(219, 234, 254); // hàng được tick ở tab Đến hạn

        private List<GiaoDichDinhKyMH> _dsGiaoDich = new List<GiaoDichDinhKyMH>();
        private List<GiaoDichDinhKyMH> _dsDenHan = new List<GiaoDichDinhKyMH>();
        private GiaoDichDinhKyMH _dangChon = null;   // null = chưa chọn bản ghi nào
        private bool _dangNap = false;               // chặn sự kiện khi nạp dữ liệu
        private bool _dangDinhDang = false;          // chặn đệ quy khi định dạng ô số tiền

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
            Load += frmGiaoDichDinhKy_Load;

            // Form nhập
            btnThem.Click += (s, e) => XuLyThem();
            btnSua.Click += (s, e) => XuLySua();
            btnTamDungTiepTuc.Click += (s, e) => XuLyTamDungTiepTuc();
            btnXoa.Click += (s, e) => XuLyXoa();
            btnLamMoi.Click += (s, e) => LamMoiTatCa();

            cboLoai.SelectedIndexChanged += cboLoai_SelectedIndexChanged;
            txtSoTien.KeyPress += txtSoTien_KeyPress;
            txtSoTien.TextChanged += txtSoTien_TextChanged;
            txtSoTien.MaxLength = 19;                  // 15 chữ số + 4 dấu chấm ngăn cách
            dtpNgayBatDau.Format = DateTimePickerFormat.Short;
            dtpNgayKetThuc.Format = DateTimePickerFormat.Short;
            dtpNgayKetThuc.ShowCheckBox = true;        // bỏ tick = không giới hạn ngày kết thúc

            foreach (Control c in new Control[] { txtSoTien, cboLoai, cboDanhMuc, cboVi, cboTanSuat, dtpNgayBatDau, dtpNgayKetThuc })
                c.KeyDown += Enter_KeyDown;

            // Tab Danh sách
            dgvDanhSach.CellClick += dgvDanhSach_CellClick;
            dgvDanhSach.CellFormatting += dgvDanhSach_CellFormatting;

            // Tab Đến hạn
            dgvDenHan.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (dgvDenHan.IsCurrentCellDirty) dgvDenHan.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
            dgvDenHan.CellValueChanged += (s, e) =>
            {
                if (e.RowIndex >= 0 && dgvDenHan.Columns[e.ColumnIndex].Name == "Chon")
                {
                    CapNhatTongChon();
                    dgvDenHan.InvalidateRow(e.RowIndex);
                }
            };
            dgvDenHan.CellClick += dgvDenHan_CellClick;
            dgvDenHan.CellFormatting += dgvDenHan_CellFormatting;

            btnXacNhanDaChon.Click += (s, e) => XuLyXacNhan(false);
            btnXacNhanTatCa.Click += (s, e) => XuLyXacNhan(true);
            btnBoQua.Click += (s, e) => XuLyBoQua();
        }

        private void frmGiaoDichDinhKy_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            CauHinhLuoiDanhSach();
            CauHinhLuoiDenHan();
            NapComboCoDinh();
            NapDanhSachVi();
            LamMoiTatCa();
        }

        // Nạp lại mọi thứ: lưới, tab đến hạn, form nhập
        private void LamMoiTatCa()
        {
            NapDanhSach();
            NapDenHan();
            ResetForm();
        }

        // ==========================================
        // CẤU HÌNH LƯỚI
        // ==========================================
        private void CauHinhLuoiDanhSach()
        {
            var g = dgvDanhSach;
            g.AutoGenerateColumns = false;
            g.AllowUserToAddRows = false;
            g.ReadOnly = true;
            g.Columns.Clear();

            ThemCot(g, "LoaiGiaoDich", "Loại", 70);
            ThemCot(g, "TenDanhMuc", "Danh mục", 110);
            ThemCot(g, "TenVi", "Ví", 100);
            ThemCot(g, "SoTien", "Số tiền", 100, null, DataGridViewContentAlignment.MiddleRight);
            ThemCot(g, "TanSuat", "Tần suất", 90);
            ThemCot(g, "NgayBatDau", "Bắt đầu", 90, "dd/MM/yyyy");
            ThemCot(g, "NgayKetThuc", "Kết thúc", 90, "dd/MM/yyyy");
            ThemCot(g, "NgayDenHanTiepTheo", "Đến hạn", 90, "dd/MM/yyyy");
            ThemCot(g, "TrangThai", "Trạng thái", 90);
            ThemCot(g, "GhiChu", "Ghi chú", 100);

            g.Columns["NgayKetThuc"].DefaultCellStyle.NullValue = "Không giới hạn";
            g.Columns["GhiChu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void CauHinhLuoiDenHan()
        {
            var g = dgvDenHan;
            g.AutoGenerateColumns = false;
            g.AllowUserToAddRows = false;
            g.ReadOnly = false;                 // cần sửa được ô checkbox; các cột còn lại ReadOnly riêng
            g.Columns.Clear();

            g.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Chon",
                HeaderText = "Chọn",
                Width = 55,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            ThemCot(g, "NgayDenHanTiepTheo", "Ngày đến hạn", 100, "dd/MM/yyyy");
            ThemCot(g, "LoaiGiaoDich", "Loại", 70);
            ThemCot(g, "TenDanhMuc", "Danh mục", 110);
            ThemCot(g, "TenVi", "Ví", 110);
            ThemCot(g, "SoTien", "Số tiền", 110, null, DataGridViewContentAlignment.MiddleRight);
            ThemCot(g, "GhiChu", "Ghi chú", 100);
            g.Columns["GhiChu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreach (DataGridViewColumn c in g.Columns)
                if (c.Name != "Chon") c.ReadOnly = true;
        }

        private static void ThemCot(DataGridView g, string tenThuocTinh, string tieuDe, int rong, string dinhDang = null,
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
            g.Columns.Add(cot);
        }

        // ==========================================
        // NẠP DỮ LIỆU
        // ==========================================
        private void NapComboCoDinh()
        {
            _dangNap = true;

            cboLoai.DisplayMember = "Value";
            cboLoai.ValueMember = "Key";
            cboLoai.DataSource = new List<KeyValuePair<string, string>>(GiaoDichDinhKyNV.DanhSachLoai);

            cboTanSuat.DisplayMember = "Value";
            cboTanSuat.ValueMember = "Key";
            cboTanSuat.DataSource = new List<KeyValuePair<string, string>>(GiaoDichDinhKyNV.DanhSachTanSuat);

            cboLoai.SelectedIndex = -1;
            cboTanSuat.SelectedIndex = -1;
            _dangNap = false;
        }

        private void NapDanhSachVi()
        {
            _dangNap = true;
            cboVi.DisplayMember = "TenVi";
            cboVi.ValueMember = "MaVi";
            cboVi.DataSource = GiaoDichDinhKyNV.LayDanhSachVi();
            cboVi.SelectedIndex = -1;
            _dangNap = false;
        }

        // Danh mục phụ thuộc loại: Thu => LoaiThu, Chi => LoaiChi
        private void NapDanhMuc()
        {
            _dangNap = true;
            string loai = cboLoai.SelectedValue as string;
            cboDanhMuc.DisplayMember = "Ten";
            cboDanhMuc.ValueMember = "Ma";
            cboDanhMuc.DataSource = string.IsNullOrEmpty(loai) ? null : GiaoDichDinhKyNV.LayDanhMuc(loai);
            cboDanhMuc.SelectedIndex = -1;
            _dangNap = false;
        }

        private void NapDanhSach()
        {
            _dsGiaoDich = GiaoDichDinhKyNV.LayDanhSach();
            dgvDanhSach.DataSource = null;
            dgvDanhSach.DataSource = _dsGiaoDich;
            dgvDanhSach.ClearSelection();
        }

        private void NapDenHan()
        {
            _dsDenHan = GiaoDichDinhKyNV.LayDenHan();
            dgvDenHan.DataSource = null;
            dgvDenHan.DataSource = _dsDenHan;
            dgvDenHan.ClearSelection();

            int n = _dsDenHan.Count;
            tpDenHan.Text = n > 0 ? $"Đến hạn ({n})" : "Đến hạn";

            string homNay = DateTime.Today.ToString("dd/MM/yyyy");
            lblTomTatDenHan.Text = n > 0
                ? $"{n} khoản đến hạn ngày {homNay} • Chờ xác nhận"
                : $"Không có khoản nào đến hạn ngày {homNay}";
            lblCo2GiaoDichDangCho.Text = n > 0
                ? $"Có {n} giao dịch đang chờ xác nhận"
                : "Không có giao dịch nào chờ xác nhận";

            decimal tong = _dsDenHan.Sum(x => x.SoTien);
            lblTongDenHan.Text = $"Chỉ đọc • {n} khoản đến hạn • Tổng số tiền: {DinhDangTien(tong)}";

            btnXacNhanTatCa.Enabled = n > 0;
            CapNhatTongChon();
        }

        // ==========================================
        // TRẠNG THÁI FORM NHẬP
        // ==========================================
        private void ResetForm()
        {
            _dangNap = true;
            _dangChon = null;
            cboLoai.SelectedIndex = -1;
            cboDanhMuc.DataSource = null;
            cboVi.SelectedIndex = -1;
            txtSoTien.Text = "";
            cboTanSuat.SelectedIndex = -1;
            dtpNgayBatDau.Value = DateTime.Today;
            dtpNgayKetThuc.Value = DateTime.Today.AddYears(1);
            dtpNgayKetThuc.Checked = false;
            txtGhiChu.Text = "";
            dgvDanhSach.ClearSelection();
            _dangNap = false;
            CapNhatNut();
        }

        private void CapNhatNut()
        {
            bool coChon = _dangChon != null;
            btnThem.Enabled = true;
            btnSua.Enabled = coChon;
            btnXoa.Enabled = coChon;
            btnTamDungTiepTuc.Enabled = coChon;
            btnTamDungTiepTuc.Text = (coChon && !_dangChon.TrangThai) ? "Tiếp tục" : "Tạm dừng";
            lblLoaiGiaoDichThuHoacChi.Text = !coChon
                ? "Loại giao dịch: Thu hoặc Chi."
                : $"Loại giao dịch: Thu hoặc Chi. Lịch hiện tại đang {(_dangChon.TrangThai ? "hoạt động" : "tạm dừng")}.";
        }

        private void HienLenForm(GiaoDichDinhKyMH gd)
        {
            _dangChon = gd;

            _dangNap = true;
            cboLoai.SelectedValue = gd.LoaiGiaoDich;
            _dangNap = false;
            NapDanhMuc();   // nạp danh mục theo loại rồi mới chọn giá trị

            int? maDM = gd.LoaiGiaoDich == "Thu" ? gd.MaLoaiThu : gd.MaLoaiChi;
            if (maDM.HasValue) cboDanhMuc.SelectedValue = maDM.Value;
            else cboDanhMuc.SelectedIndex = -1;

            cboVi.SelectedValue = gd.MaVi;
            txtSoTien.Text = ((long)gd.SoTien).ToString(CultureInfo.InvariantCulture); // TextChanged tự thêm dấu chấm
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
            txtGhiChu.Text = gd.GhiChu ?? "";
            CapNhatNut();
        }

        private static void ThongBao(string noiDung, bool laLoi)
        {
            MessageBox.Show(noiDung, laLoi ? "Lỗi" : "Thông báo", MessageBoxButtons.OK,
                laLoi ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
        }

        private static string DinhDangTien(decimal v)
        {
            return ((long)v).ToString("N0", Vi) + " ₫";
        }

        // ==========================================
        // SỰ KIỆN: TAB DANH SÁCH
        // ==========================================
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var gd = dgvDanhSach.Rows[e.RowIndex].DataBoundItem as GiaoDichDinhKyMH;
            if (gd != null) HienLenForm(gd);
        }

        private void dgvDanhSach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null) return;
            string tenCot = dgvDanhSach.Columns[e.ColumnIndex].Name;
            var gd = dgvDanhSach.Rows[e.RowIndex].DataBoundItem as GiaoDichDinhKyMH;

            // Lịch đang tạm dừng => chữ xám
            if (gd != null && !gd.TrangThai) e.CellStyle.ForeColor = MauXam;

            if (tenCot == "LoaiGiaoDich")
            {
                string ma = e.Value.ToString();
                e.Value = GiaoDichDinhKyNV.TenLoai(ma);
                if (gd == null || gd.TrangThai) e.CellStyle.ForeColor = ma == "Thu" ? MauXanhLa : MauDo;
                e.FormattingApplied = true;
            }
            else if (tenCot == "SoTien")
            {
                e.Value = DinhDangTien(Convert.ToDecimal(e.Value));
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

        // ==========================================
        // SỰ KIỆN: TAB ĐẾN HẠN
        // ==========================================
        private void dgvDenHan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bấm vào bất kỳ ô nào của hàng (trừ chính ô checkbox) cũng đổi trạng thái tick
            if (e.RowIndex < 0 || dgvDenHan.Columns[e.ColumnIndex].Name == "Chon") return;
            var cell = dgvDenHan.Rows[e.RowIndex].Cells["Chon"];
            cell.Value = !(cell.Value is bool && (bool)cell.Value);
        }

        private void dgvDenHan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvDenHan.Rows[e.RowIndex];
            bool daChon = LaDuocChon(row);
            if (daChon) e.CellStyle.BackColor = MauDong;
            if (e.Value == null) return;

            string tenCot = dgvDenHan.Columns[e.ColumnIndex].Name;
            var gd = row.DataBoundItem as GiaoDichDinhKyMH;

            if (tenCot == "LoaiGiaoDich")
            {
                string ma = e.Value.ToString();
                e.Value = GiaoDichDinhKyNV.TenLoai(ma);
                e.FormattingApplied = true;
            }
            else if (tenCot == "SoTien")
            {
                e.Value = DinhDangTien(Convert.ToDecimal(e.Value));
                e.CellStyle.ForeColor = (gd != null && gd.LoaiGiaoDich == "Thu") ? MauXanhLa : MauDo;
                e.CellStyle.Font = new Font(dgvDenHan.Font, FontStyle.Bold);
                e.FormattingApplied = true;
            }
        }

        private static bool LaDuocChon(DataGridViewRow row)
        {
            var v = row.Cells["Chon"].Value;
            return v is bool && (bool)v;
        }

        private List<GiaoDichDinhKyMH> LayCacKhoanDaChon()
        {
            var ds = new List<GiaoDichDinhKyMH>();
            foreach (DataGridViewRow row in dgvDenHan.Rows)
            {
                var gd = row.DataBoundItem as GiaoDichDinhKyMH;
                if (gd != null && LaDuocChon(row)) ds.Add(gd);
            }
            return ds;
        }

        private void CapNhatTongChon()
        {
            var ds = LayCacKhoanDaChon();
            lblSoDaChon.Text = $"Đã chọn: {ds.Count} / {_dsDenHan.Count} khoản";
            lblTienDaChon.Text = DinhDangTien(ds.Sum(x => x.SoTien));
            btnXacNhanDaChon.Enabled = ds.Count > 0;
            btnBoQua.Enabled = ds.Count > 0;
        }

        private void XuLyXacNhan(bool tatCa)
        {
            var ds = tatCa ? new List<GiaoDichDinhKyMH>(_dsDenHan) : LayCacKhoanDaChon();
            if (ds.Count == 0)
            {
                ThongBao("Bạn chưa chọn khoản nào để xác nhận.", true);
                return;
            }

            string hoi = tatCa
                ? $"Xác nhận tất cả {ds.Count} khoản đến hạn (tổng {DinhDangTien(ds.Sum(x => x.SoTien))})?"
                : $"Xác nhận {ds.Count} khoản đã chọn (tổng {DinhDangTien(ds.Sum(x => x.SoTien))})?";
            if (MessageBox.Show(hoi, "Xác nhận giao dịch", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var kq = GiaoDichDinhKyNV.XacNhan(ds);
            ThongBao(kq.ThongBao, !kq.ThanhCong);
            LamMoiTatCa();
        }

        private void XuLyBoQua()
        {
            var ds = LayCacKhoanDaChon();
            if (ds.Count == 0)
            {
                ThongBao("Bạn chưa chọn khoản nào để bỏ qua.", true);
                return;
            }

            if (MessageBox.Show($"Bỏ qua kỳ này của {ds.Count} khoản đã chọn?\nLịch định kỳ vẫn được giữ cho các kỳ sau.",
                    "Bỏ qua", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var kq = GiaoDichDinhKyNV.BoQua(ds);
            ThongBao(kq.ThongBao, !kq.ThanhCong);
            LamMoiTatCa();
        }

        // ==========================================
        // SỰ KIỆN: FORM NHẬP
        // ==========================================
        private void cboLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dangNap) return;
            NapDanhMuc();
        }

        private void txtSoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // Hiển thị "250.000" khi gõ
        private void txtSoTien_TextChanged(object sender, EventArgs e)
        {
            if (_dangDinhDang) return;
            _dangDinhDang = true;
            string so = new string(txtSoTien.Text.Where(char.IsDigit).ToArray());
            decimal v;
            txtSoTien.Text = decimal.TryParse(so, NumberStyles.None, CultureInfo.InvariantCulture, out v)
                ? v.ToString("N0", Vi) : "";
            txtSoTien.SelectionStart = txtSoTien.Text.Length;
            _dangDinhDang = false;
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
        // THÊM / SỬA / TẠM DỪNG / XÓA
        // ==========================================
        private void XuLyThem()
        {
            if (!KiemTraNhap()) return;

            var gd = LayDuLieuTuForm();
            gd.MaGDDK = 0;
            gd.TrangThai = true;
            gd.NgayDenHanTiepTheo = gd.NgayBatDau;   // kỳ đầu tiên đến hạn đúng ngày bắt đầu

            var kq = GiaoDichDinhKyNV.Them(gd);
            ThongBao(kq.ThongBao, !kq.ThanhCong);
            if (kq.ThanhCong) LamMoiTatCa();
        }

        private void XuLySua()
        {
            if (_dangChon == null)
            {
                ThongBao("Bạn chưa chọn bản ghi nào.", true);
                return;
            }
            if (!KiemTraNhap()) return;

            var gd = LayDuLieuTuForm();
            gd.MaGDDK = _dangChon.MaGDDK;
            gd.TrangThai = _dangChon.TrangThai;
            // Giữ nguyên kỳ đến hạn hiện tại; chỉ đẩy lên nếu ngày bắt đầu mới nằm sau nó
            gd.NgayDenHanTiepTheo = gd.NgayBatDau > _dangChon.NgayDenHanTiepTheo
                ? gd.NgayBatDau : _dangChon.NgayDenHanTiepTheo;

            var kq = GiaoDichDinhKyNV.Sua(gd);
            ThongBao(kq.ThongBao, !kq.ThanhCong);
            if (kq.ThanhCong) LamMoiTatCa();
        }

        private void XuLyTamDungTiepTuc()
        {
            if (_dangChon == null)
            {
                ThongBao("Bạn chưa chọn bản ghi nào.", true);
                return;
            }

            var kq = GiaoDichDinhKyNV.TamDungTiepTuc(_dangChon.MaGDDK);
            if (!kq.ThanhCong) ThongBao(kq.ThongBao, true);
            LamMoiTatCa();   // tạm dừng => khoản biến khỏi tab Đến hạn; tiếp tục => có thể xuất hiện lại
        }

        private void XuLyXoa()
        {
            if (_dangChon == null)
            {
                ThongBao("Bạn chưa chọn bản ghi nào.", true);
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa giao dịch định kỳ này không?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var kq = GiaoDichDinhKyNV.Xoa(_dangChon.MaGDDK);
            ThongBao(kq.ThongBao, !kq.ThanhCong);
            if (kq.ThanhCong) LamMoiTatCa();
        }

        // ==========================================
        // KIỂM TRA & LẤY DỮ LIỆU
        // ==========================================
        private bool KiemTraNhap()
        {
            if (cboLoai.SelectedIndex == -1)
            {
                ThongBao("Bạn phải chọn loại giao dịch (Thu nhập/Chi tiêu).", true);
                cboLoai.Focus();
                return false;
            }
            if (cboDanhMuc.SelectedIndex == -1)
            {
                ThongBao("Bạn phải chọn danh mục.", true);
                cboDanhMuc.Focus();
                return false;
            }
            if (cboVi.SelectedIndex == -1)
            {
                ThongBao("Bạn phải chọn ví.", true);
                cboVi.Focus();
                return false;
            }
            if (DocSoTien() <= 0)
            {
                ThongBao("Số tiền phải lớn hơn 0.", true);
                txtSoTien.Focus();
                return false;
            }
            if (cboTanSuat.SelectedIndex == -1)
            {
                ThongBao("Bạn phải chọn tần suất.", true);
                cboTanSuat.Focus();
                return false;
            }
            return true;
        }

        // Ô số tiền hiển thị có dấu chấm ngăn cách => chỉ lấy chữ số để parse
        private decimal DocSoTien()
        {
            string so = new string(txtSoTien.Text.Where(char.IsDigit).ToArray());
            decimal v;
            return decimal.TryParse(so, NumberStyles.None, CultureInfo.InvariantCulture, out v) ? v : 0;
        }

        private GiaoDichDinhKyMH LayDuLieuTuForm()
        {
            var gd = new GiaoDichDinhKyMH
            {
                LoaiGiaoDich = cboLoai.SelectedValue as string,
                MaVi = cboVi.SelectedIndex >= 0 ? Convert.ToInt32(cboVi.SelectedValue) : 0,
                SoTien = DocSoTien(),
                TanSuat = cboTanSuat.SelectedValue as string,
                NgayBatDau = dtpNgayBatDau.Value.Date,
                NgayKetThuc = dtpNgayKetThuc.Checked ? (DateTime?)dtpNgayKetThuc.Value.Date : null,
                GhiChu = txtGhiChu.Text
            };

            int? maDM = cboDanhMuc.SelectedIndex >= 0 ? (int?)Convert.ToInt32(cboDanhMuc.SelectedValue) : null;
            if (gd.LoaiGiaoDich == "Thu") gd.MaLoaiThu = maDM;
            else if (gd.LoaiGiaoDich == "Chi") gd.MaLoaiChi = maDM;

            return gd;
        }
    }
}
