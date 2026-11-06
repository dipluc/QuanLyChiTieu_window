using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MoHinh;
using NghiepVu;
using NghiepVu.TienIch;

namespace LTWIN_N05_QLCT.Forms.DanhMuc
{
    public partial class frmLoaiChiTieu : Form
    {
        private static readonly Color MauXanh = Color.FromArgb(21, 101, 192);
        private static readonly Color MauChu = Color.FromArgb(30, 41, 59);
        private static readonly Color MauNenXen = Color.FromArgb(248, 250, 252);
        private static readonly Color MauDo = Color.FromArgb(198, 40, 40);
        private static readonly Color MauXanhLa = Color.FromArgb(46, 125, 50);

        private bool _dangNapDuLieu;
        private int _maNhomDangChon;
        private int _maLoaiDangChon;
        private bool _nhomDangDung;
        private bool _loaiDangDung;

        public frmLoaiChiTieu()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            CauHinhLuoi(dgvNhomChi);
            CauHinhLuoi(dgvLoaiChi);
            dgvNhomChi.SelectionChanged += dgvNhomChi_SelectionChanged;
            dgvLoaiChi.SelectionChanged += dgvLoaiChi_SelectionChanged;
            dgvNhomChi.CellFormatting += DinhDangTrangThai;
            dgvLoaiChi.CellFormatting += DinhDangTrangThai;

            btnMoiNhom.Click += (s, e) => TaoNhomMoi();
            btnThemNhom.Click += btnThemNhom_Click;
            btnSuaNhom.Click += btnSuaNhom_Click;
            btnNgungSuDungNhom.Click += btnNgungSuDungNhom_Click;
            btnMoiLoai.Click += (s, e) => TaoLoaiMoi();
            btnThemLoai.Click += btnThemLoai_Click;
            btnSuaLoai.Click += btnSuaLoai_Click;
            btnNgungSuDungLoai.Click += btnNgungSuDungLoai_Click;
            CapNhatNut();
        }

        private void CauHinhLuoi(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.FromArgb(226, 232, 240);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersHeight = 34;
            dgv.RowTemplate.Height = 30;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = MauXanh;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = MauXanh;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgv.DefaultCellStyle.ForeColor = MauChu;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgv.DefaultCellStyle.SelectionForeColor = MauChu;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = MauNenXen;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
        }

        private void frmLoaiChiTieu_Load(object sender, EventArgs e)
        {
            LoadDanhSachNhomChi();
        }

        private static DataRowView DongDangChon(DataGridView dgv)
        {
            return dgv.SelectedRows.Count > 0 ? dgv.SelectedRows[0].DataBoundItem as DataRowView : null;
        }

        private static void ChonDong(DataGridView dgv, string cotMa, int ma)
        {
            dgv.ClearSelection();
            dgv.CurrentCell = null;
            if (dgv.Rows.Count == 0) return;

            DataGridViewRow dongChon = dgv.Rows[0];
            foreach (DataGridViewRow dong in dgv.Rows)
            {
                var duLieu = dong.DataBoundItem as DataRowView;
                if (duLieu != null && Convert.ToInt32(duLieu[cotMa]) == ma)
                {
                    dongChon = dong;
                    break;
                }
            }
            foreach (DataGridViewColumn cot in dgv.Columns)
            {
                if (cot.Visible)
                {
                    dgv.CurrentCell = dongChon.Cells[cot.Index];
                    break;
                }
            }
            dongChon.Selected = true;
        }

        private static void CauHinhCotTrangThai(DataGridView dgv)
        {
            var cot = dgv.Columns["TrangThai"];
            if (cot is DataGridViewCheckBoxColumn)
            {
                int viTri = cot.DisplayIndex;
                dgv.Columns.Remove(cot);
                dgv.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "TrangThai", DataPropertyName = "TrangThai", DisplayIndex = viTri
                });
            }
            if (dgv.Columns["TrangThai"] != null)
            {
                dgv.Columns["TrangThai"].HeaderText = "Trạng thái";
                dgv.Columns["TrangThai"].FillWeight = 75;
            }
        }

        private void DinhDangTrangThai(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (e.RowIndex < 0 || dgv.Columns[e.ColumnIndex].Name != "TrangThai" || !(e.Value is bool)) return;
            bool dangDung = (bool)e.Value;
            e.Value = dangDung ? "Đang dùng" : "Ngừng dùng";
            e.CellStyle.ForeColor = dangDung ? MauXanhLa : MauDo;
            e.FormattingApplied = true;
        }

        private void LoadDanhSachNhomChi(int maNhom = 0, int maLoai = 0)
        {
            _dangNapDuLieu = true;
            try
            {
                var kq = LoaiChiNV.LayDanhSachNhomChi();
                if (!kq.ThanhCong)
                {
                    dgvNhomChi.DataSource = null;
                    XoaNhomDangChon();
                    HienThongBao(kq.ThongBao, true);
                    return;
                }

                dgvNhomChi.DataSource = kq.DuLieu;
                dgvNhomChi.Columns["MaNhom"].Visible = false;
                dgvNhomChi.Columns["TenNhom"].HeaderText = "Tên nhóm chi";
                CauHinhCotTrangThai(dgvNhomChi);
                ChonDong(dgvNhomChi, "MaNhom", maNhom);
            }
            finally
            {
                _dangNapDuLieu = false;
            }

            if (DongDangChon(dgvNhomChi) == null)
                TaoNhomMoi();
            else
            {
                dgvNhomChi_SelectionChanged(null, EventArgs.Empty);
                if (maLoai > 0) LoadDanhSachLoaiChiTheoNhom(maLoai);
            }
        }

        private void dgvNhomChi_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangNapDuLieu) return;
            var dong = DongDangChon(dgvNhomChi);
            if (dong == null)
            {
                XoaNhomDangChon();
                return;
            }

            _maNhomDangChon = Convert.ToInt32(dong["MaNhom"]);
            _nhomDangDung = Convert.ToBoolean(dong["TrangThai"]);
            string tenNhom = dong["TenNhom"].ToString();
            txtTenNhomChi.Text = tenNhom;
            lblTenNhomChi.Text = "Tên nhóm chi *";
            lblLoaiChiTieuTieuDe.Text = "2. Loại chi trong nhóm";

            // Chỉ hiển thị tên nhóm, không dùng chung CurrencyManager với lưới nhóm.
            cboNhomChiKhoa.Items.Clear();
            cboNhomChiKhoa.Items.Add(tenNhom);
            cboNhomChiKhoa.SelectedIndex = 0;
            LoadDanhSachLoaiChiTheoNhom();
            CapNhatNut();
        }

        private void XoaNhomDangChon()
        {
            _maNhomDangChon = 0;
            _nhomDangDung = false;
            txtTenNhomChi.Clear();
            lblTenNhomChi.Text = "Tên nhóm mới *";
            cboNhomChiKhoa.Items.Clear();
            lblLoaiChiTieuTieuDe.Text = "2. Loại chi trong nhóm";
            lblNhomDangChon.Text = "Chọn nhóm bên trái hoặc tạo và lưu nhóm mới trước.";
            dgvLoaiChi.DataSource = null;
            XoaLoaiDangChon();
        }

        private void TaoNhomMoi()
        {
            _dangNapDuLieu = true;
            try
            {
                dgvNhomChi.ClearSelection();
                dgvNhomChi.CurrentCell = null;
                XoaNhomDangChon();
            }
            finally { _dangNapDuLieu = false; }
            txtTenNhomChi.Focus();
        }

        private void btnThemNhom_Click(object sender, EventArgs e)
        {
            if (_maNhomDangChon > 0) return;
            var kq = LoaiChiNV.ThemNhomChi(txtTenNhomChi.Text, true);
            if (!kq.ThanhCong) { HienThongBao(kq.ThongBao, true); return; }
            HienThongBao("Đã thêm nhóm chi. Bấm Tạo loại mới để thêm loại chi vào nhóm này.", false);
            LoadDanhSachNhomChi(kq.MaNhom);
        }

        private void btnSuaNhom_Click(object sender, EventArgs e)
        {
            if (_maNhomDangChon <= 0) return;
            var kq = LoaiChiNV.SuaNhomChi(_maNhomDangChon, txtTenNhomChi.Text, _nhomDangDung);
            if (!kq.ThanhCong) { HienThongBao(kq.ThongBao, true); return; }
            HienThongBao("Đã cập nhật nhóm chi.", false);
            LoadDanhSachNhomChi(_maNhomDangChon, _maLoaiDangChon);
        }

        private void btnNgungSuDungNhom_Click(object sender, EventArgs e)
        {
            var dong = DongDangChon(dgvNhomChi);
            if (_maNhomDangChon <= 0 || dong == null) return;
            bool trangThaiMoi = !_nhomDangDung;
            var kq = LoaiChiNV.SuaNhomChi(_maNhomDangChon, dong["TenNhom"].ToString(), trangThaiMoi);
            if (!kq.ThanhCong) { HienThongBao(kq.ThongBao, true); return; }
            HienThongBao(trangThaiMoi ? "Đã bật sử dụng nhóm chi." : "Đã ngừng sử dụng nhóm chi.", false);
            LoadDanhSachNhomChi(_maNhomDangChon, _maLoaiDangChon);
        }

        private void LoadDanhSachLoaiChiTheoNhom(int maLoai = 0)
        {
            _dangNapDuLieu = true;
            try
            {
                XoaLoaiDangChon();
                var kq = LoaiChiNV.LayDanhSachTheoNhom(_maNhomDangChon);
                if (!kq.ThanhCong)
                {
                    dgvLoaiChi.DataSource = null;
                    lblNhomDangChon.Text = "Không tải được loại chi. Chọn lại nhóm để thử lại.";
                    HienThongBao(kq.ThongBao, true);
                    return;
                }

                dgvLoaiChi.DataSource = kq.DuLieu;
                dgvLoaiChi.Columns["MaLoaiChi"].Visible = false;
                dgvLoaiChi.Columns["MaNhom"].Visible = false;
                dgvLoaiChi.Columns["TenNhom"].Visible = false;
                dgvLoaiChi.Columns["TenLoaiChi"].HeaderText = "Tên loại chi";
                dgvLoaiChi.Columns["GhiChu"].HeaderText = "Ghi chú";
                CauHinhCotTrangThai(dgvLoaiChi);
                lblNhomDangChon.Text = string.Format("{0} • {1} loại chi{2}",
                    cboNhomChiKhoa.Text, kq.DuLieu.Rows.Count, _nhomDangDung ? "" : " • Nhóm đã ngừng dùng");
                ChonDong(dgvLoaiChi, "MaLoaiChi", maLoai);
            }
            finally { _dangNapDuLieu = false; }

            dgvLoaiChi_SelectionChanged(null, EventArgs.Empty);
        }

        private void dgvLoaiChi_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangNapDuLieu) return;
            var dong = DongDangChon(dgvLoaiChi);
            if (dong == null) { XoaLoaiDangChon(); return; }

            _maLoaiDangChon = Convert.ToInt32(dong["MaLoaiChi"]);
            _loaiDangDung = Convert.ToBoolean(dong["TrangThai"]);
            txtTenLoaiChi.Text = dong["TenLoaiChi"].ToString();
            txtGhiChuLoai.Text = dong["GhiChu"].ToString();
            lblTenLoaiChi.Text = "Tên loại chi *";
            CapNhatNut();
        }

        private void XoaLoaiDangChon()
        {
            _maLoaiDangChon = 0;
            _loaiDangDung = false;
            txtTenLoaiChi.Clear();
            txtGhiChuLoai.Clear();
            lblTenLoaiChi.Text = "Tên loại chi mới *";
            CapNhatNut();
        }

        private void TaoLoaiMoi()
        {
            if (_maNhomDangChon <= 0 || !_nhomDangDung) return;
            _dangNapDuLieu = true;
            try
            {
                dgvLoaiChi.ClearSelection();
                dgvLoaiChi.CurrentCell = null;
                XoaLoaiDangChon();
            }
            finally { _dangNapDuLieu = false; }
            txtTenLoaiChi.Focus();
        }

        private LoaiChiMH DocLoaiChi(bool themMoi)
        {
            return new LoaiChiMH
            {
                MaLoaiChi = _maLoaiDangChon,
                MaNhom = _maNhomDangChon,
                TenLoaiChi = txtTenLoaiChi.Text,
                GhiChu = txtGhiChuLoai.Text,
                TrangThai = themMoi || _loaiDangDung
            };
        }

        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            if (_maNhomDangChon <= 0 || !_nhomDangDung || _maLoaiDangChon > 0) return;
            var kq = LoaiChiNV.Them(DocLoaiChi(true));
            if (!kq.ThanhCong) { HienThongBao(kq.ThongBao, true); return; }
            HienThongBao("Đã thêm loại chi vào nhóm đang chọn.", false);
            LoadDanhSachLoaiChiTheoNhom(kq.MaLoaiChi);
        }

        private void btnSuaLoai_Click(object sender, EventArgs e)
        {
            if (_maLoaiDangChon <= 0 || _maNhomDangChon <= 0) return;
            var kq = LoaiChiNV.CapNhat(DocLoaiChi(false));
            if (!kq.ThanhCong) { HienThongBao(kq.ThongBao, true); return; }
            HienThongBao("Đã cập nhật loại chi.", false);
            LoadDanhSachLoaiChiTheoNhom(kq.MaLoaiChi);
        }

        private void btnNgungSuDungLoai_Click(object sender, EventArgs e)
        {
            if (_maLoaiDangChon <= 0) return;
            var kq = LoaiChiNV.DatTrangThai(_maLoaiDangChon, !_loaiDangDung);
            if (!kq.ThanhCong) { HienThongBao(kq.ThongBao, true); return; }
            HienThongBao(kq.ThongBao, false);
            LoadDanhSachLoaiChiTheoNhom(kq.MaLoaiChi);
        }

        private void CapNhatNut()
        {
            bool coPhien = PhienDangNhap.DaDangNhap;
            bool coNhom = _maNhomDangChon > 0;
            bool coLoai = coNhom && _maLoaiDangChon > 0;
            btnMoiNhom.Enabled = coPhien;
            txtTenNhomChi.Enabled = coPhien;
            btnThemNhom.Enabled = coPhien && !coNhom;
            btnSuaNhom.Enabled = coPhien && coNhom;
            btnNgungSuDungNhom.Enabled = coPhien && coNhom;
            btnNgungSuDungNhom.Text = coNhom && !_nhomDangDung ? "Dùng lại nhóm" : "Ngừng sử dụng nhóm";
            btnMoiLoai.Enabled = coPhien && coNhom && _nhomDangDung;
            txtTenLoaiChi.Enabled = coPhien && coNhom && (_nhomDangDung || coLoai);
            txtGhiChuLoai.Enabled = txtTenLoaiChi.Enabled;
            btnThemLoai.Enabled = coPhien && coNhom && _nhomDangDung && !coLoai;
            btnSuaLoai.Enabled = coPhien && coLoai;
            btnNgungSuDungLoai.Enabled = coPhien && coLoai;
            btnNgungSuDungLoai.Text = coLoai && !_loaiDangDung ? "Dùng lại loại chi" : "Ngừng sử dụng loại chi";
            btnThemNhom.BackColor = btnThemNhom.Enabled ? MauXanh : Color.FromArgb(226, 232, 240);
            btnThemLoai.BackColor = btnThemLoai.Enabled ? MauXanh : Color.FromArgb(226, 232, 240);
        }

        private void HienThongBao(string thongDiep, bool laLoi)
        {
            lblThongBao.Text = thongDiep;
            lblThongBao.ForeColor = laLoi ? MauDo : MauXanhLa;
            lblThongBao.Visible = true;
        }
    }
}
