using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MoHinh;
using NghiepVu;
using NghiepVu.TienIch;

namespace LTWIN_N05_QLCT.Forms.NghiepVu
{
    public partial class frmMucTieuTietKiem : Form
    {
        private static readonly CultureInfo Vi = new CultureInfo("vi-VN");
        private static readonly Color MauXanhDuong = Color.FromArgb(21, 101, 192);
        private static readonly Color MauXanhLa = Color.FromArgb(46, 125, 50);
        private static readonly Color MauXam = Color.FromArgb(100, 116, 139);
        private static readonly Color MauDo = Color.FromArgb(198, 40, 40);
        private const string GoiYMacDinh = "Chọn mục tiêu bên trái để xem và cập nhật thông tin.";

        private List<MucTieuMH> _dsMucTieu = new List<MucTieuMH>();
        private TheMucTieu _theDangChon = null;
        private bool _dangDinhDang = false;

        public frmMucTieuTietKiem()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            Load += frmMucTieuTietKiem_Load;
            SizeChanged += frmMucTieuTietKiem_SizeChanged;

            btnThem.Click += (s, e) => XuLyThem();
            btnSua.Click += (s, e) => XuLySua();
            btnHuyMucTieu.Click += (s, e) => XuLyHuy();
            btnMoi.Click += (s, e) => XuLyMoi();
            btnNapTien.Click += (s, e) => XuLyNapRut(true);
            btnRutBot.Click += (s, e) => XuLyNapRut(false);

            flpMucTieu.SizeChanged += (s, e) => CanChinhRong();

            foreach (TextBox t in new[] { txtSoTienMucTieu, txtSoTienNapRut })
            {
                t.KeyPress += SoTien_KeyPress;
                t.TextChanged += SoTien_TextChanged;
                t.MaxLength = 19;
            }

            dtpNgayBatDau.Format = DateTimePickerFormat.Short;
            dtpNgayDich.Format = DateTimePickerFormat.Short;
            dtpNgayDich.ShowCheckBox = true;

            foreach (Control c in new Control[] { txtTenMucTieu, txtSoTienMucTieu, dtpNgayBatDau, dtpNgayDich, txtSoTienNapRut })
                c.KeyDown += Enter_KeyDown;
        }

        private void frmMucTieuTietKiem_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            NapDanhSach(0);
            ResetForm();
        }

        private void frmMucTieuTietKiem_SizeChanged(object sender, EventArgs e)
        {
            if (DesignMode) return;
            // Tự động căn chỉnh chiều cao linh hoạt của danh sách thẻ theo form chính
            if (flpMucTieu != null && pnlNapRut != null)
            {
                int bottomLimit = pnlNapRut.Visible ? pnlNapRut.Top - 10 : lblMucTieuDaHuyDaHoan.Top - 10;
                flpMucTieu.Height = Math.Max(200, bottomLimit - flpMucTieu.Top);
            }
        }

        private int RongThe()
        {
            return Math.Max(260, flpMucTieu.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 6);
        }

        private void CanChinhRong()
        {
            int w = RongThe();
            foreach (Control c in flpMucTieu.Controls) c.Width = w;
        }

        private void NapDanhSach(int maChon)
        {
            _dsMucTieu = MucTieuNV.LayDanhSach();

            flpMucTieu.SuspendLayout();
            flpMucTieu.Controls.Remove(pnlNapRut);
            pnlNapRut.Visible = false;
            foreach (Control c in flpMucTieu.Controls.Cast<Control>().ToList())
            {
                flpMucTieu.Controls.Remove(c);
                c.Dispose();
            }
            _theDangChon = null;

            foreach (var mt in _dsMucTieu)
            {
                var the = new TheMucTieu(mt, RongThe());
                the.Margin = new Padding(0, 0, 0, 8);
                GanClick(the, (s, e) => ChonThe(the));
                flpMucTieu.Controls.Add(the);
            }
            flpMucTieu.ResumeLayout();

            CapNhatTomTat();
            frmMucTieuTietKiem_SizeChanged(null, null);

            var canChon = flpMucTieu.Controls.OfType<TheMucTieu>().FirstOrDefault(t => t.Du.MaMT == maChon);
            if (canChon != null) ChonThe(canChon);
            else CapNhatKhungTomTat(null);
            CapNhatNut();
        }

        private static void GanClick(Control goc, EventHandler h)
        {
            goc.Click += h;
            foreach (Control con in goc.Controls) GanClick(con, h);
        }

        private void ChonThe(TheMucTieu the)
        {
            if (_theDangChon != null) _theDangChon.DaChon = false;
            _theDangChon = the;
            the.DaChon = true;

            HienLenForm(the.Du);

            flpMucTieu.SuspendLayout();
            flpMucTieu.Controls.Remove(pnlNapRut);
            flpMucTieu.Controls.Add(pnlNapRut);
            flpMucTieu.Controls.SetChildIndex(pnlNapRut, flpMucTieu.Controls.GetChildIndex(the) + 1);
            pnlNapRut.Width = RongThe();
            pnlNapRut.Visible = true;
            flpMucTieu.ResumeLayout();

            frmMucTieuTietKiem_SizeChanged(null, null);
            flpMucTieu.ScrollControlIntoView(the);

            txtSoTienNapRut.Text = "";
            CapNhatNapRut(the.Du);
            CapNhatKhungTomTat(the.Du);
            CapNhatNut();
        }

        private void CapNhatTomTat()
        {
            int dang = _dsMucTieu.Count(x => x.TrangThai == "DangThucHien");
            int xong = _dsMucTieu.Count(x => x.TrangThai == "HoanThanh");
            int huy = _dsMucTieu.Count(x => x.TrangThai == "Huy");
            lblTomTatMucTieu.Text = $"{_dsMucTieu.Count} mục tiêu • {dang} đang thực hiện • {xong} hoàn thành • {huy} đã hủy";
        }

        private static string Tien(decimal v)
        {
            return ((long)v).ToString("N0", Vi) + " ₫";
        }

        private void CapNhatNapRut(MucTieuMH mt)
        {
            bool huy = mt.TrangThai == "Huy";
            btnNapTien.Enabled = !huy;
            btnRutBot.Enabled = !huy;
            txtSoTienNapRut.Enabled = !huy;

            decimal conThieu = Math.Max(0, mt.SoTienMucTieu - mt.SoTienDaTietKiem);
            DateTime homNay = DateTime.Today;

            if (huy)
            {
                lblGoiY.Text = "Mục tiêu đã hủy.";
                lblCon6Thang.Text = "Không thể nạp hoặc rút thêm tiền.";
            }
            else if (conThieu == 0)
            {
                lblGoiY.Text = "Bạn đã đạt mục tiêu.";
                lblCon6Thang.Text = "";
            }
            else if (!mt.NgayDich.HasValue)
            {
                lblGoiY.Text = "Chưa đặt ngày đích.";
                lblCon6Thang.Text = $"Còn thiếu {Tien(conThieu)} để đạt mục tiêu.";
            }
            else if (mt.NgayDich.Value.Date < homNay)
            {
                lblGoiY.Text = "Mục tiêu đã quá hạn.";
                lblCon6Thang.Text = $"Còn thiếu {Tien(conThieu)} để đạt mục tiêu.";
            }
            else
            {
                DateTime dich = mt.NgayDich.Value;
                int chenh = (dich.Year * 12 + dich.Month) - (homNay.Year * 12 + homNay.Month);
                int thang = Math.Max(1, chenh);
                lblGoiY.Text = $"Cần để dành {Tien(Math.Ceiling(conThieu / thang))}/tháng";
                lblCon6Thang.Text = $"Còn {thang} tháng ({dich:MM/yyyy}) để tích lũy {Tien(conThieu)}.";
            }
        }

        private void CapNhatKhungTomTat(MucTieuMH mt)
        {
            lblChonMucTieuBenTraiDe.Text = GoiYMacDinh;
            lblChonMucTieuBenTraiDe.ForeColor = MauXam;
            if (mt == null)
            {
                lblTenVaTrangThai.Text = "Chưa chọn mục tiêu";
                lblDaTietKiem.Text = "";
                lblConCanTichLuy.Text = "";
                return;
            }
            lblTenVaTrangThai.Text = $"{mt.TenMucTieu} • {MucTieuNV.TenTrangThai(mt.TrangThai)}";
            lblDaTietKiem.Text = "Đã tiết kiệm: " + Tien(mt.SoTienDaTietKiem);
            lblConCanTichLuy.Text = "Còn cần tích lũy: " + Tien(Math.Max(0, mt.SoTienMucTieu - mt.SoTienDaTietKiem));
        }

        private void CapNhatNut()
        {
            bool coChon = _theDangChon != null;
            bool huy = coChon && _theDangChon.Du.TrangThai == "Huy";
            btnSua.Enabled = coChon;
            btnHuyMucTieu.Enabled = coChon && !huy;
        }

        private void BaoThanhCong(string thongDiep)
        {
            lblChonMucTieuBenTraiDe.Text = "✓ " + thongDiep;
            lblChonMucTieuBenTraiDe.ForeColor = MauXanhLa;
        }

        private static void BaoLoi(string thongDiep)
        {
            MessageBox.Show(thongDiep, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ResetForm()
        {
            txtTenMucTieu.Text = "";
            txtSoTienMucTieu.Text = "";
            dtpNgayBatDau.Value = DateTime.Today;
            dtpNgayDich.Value = DateTime.Today.AddMonths(6);
            dtpNgayDich.Checked = true;
            txtGhiChu.Text = "";
        }

        private void HienLenForm(MucTieuMH mt)
        {
            txtTenMucTieu.Text = mt.TenMucTieu;
            txtSoTienMucTieu.Text = ((long)mt.SoTienMucTieu).ToString(CultureInfo.InvariantCulture);
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
            txtGhiChu.Text = mt.GhiChu ?? "";
        }

        private void SoTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void SoTien_TextChanged(object sender, EventArgs e)
        {
            if (_dangDinhDang) return;
            var t = (TextBox)sender;
            _dangDinhDang = true;
            decimal v;
            string so = new string(t.Text.Where(char.IsDigit).ToArray());
            t.Text = decimal.TryParse(so, NumberStyles.None, CultureInfo.InvariantCulture, out v)
                ? v.ToString("N0", Vi) : "";
            t.SelectionStart = t.Text.Length;
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

        private void XuLyMoi()
        {
            ResetForm();
            if (_theDangChon != null)
            {
                _theDangChon.DaChon = false;
                _theDangChon = null;
            }
            flpMucTieu.Controls.Remove(pnlNapRut);
            pnlNapRut.Visible = false;
            CapNhatKhungTomTat(null);
            CapNhatNut();
            frmMucTieuTietKiem_SizeChanged(null, null);
            txtTenMucTieu.Focus();
        }

        private void XuLyThem()
        {
            if (!KiemTraNhap()) return;

            var mt = LayDuLieuTuForm();
            mt.MaMT = 0;
            var kq = MucTieuNV.Them(mt);
            if (!kq.ThanhCong) { BaoLoi(kq.ThongBao); return; }

            NapDanhSach(kq.MaMT);
            BaoThanhCong(kq.ThongBao);
        }

        private void XuLySua()
        {
            if (_theDangChon == null) { BaoLoi("Bạn chưa chọn mục tiêu nào."); return; }
            if (!KiemTraNhap()) return;

            var mt = LayDuLieuTuForm();
            mt.MaMT = _theDangChon.Du.MaMT;
            mt.TrangThai = _theDangChon.Du.TrangThai;
            var kq = MucTieuNV.Sua(mt);
            if (!kq.ThanhCong) { BaoLoi(kq.ThongBao); return; }

            NapDanhSach(mt.MaMT);
            BaoThanhCong(kq.ThongBao);
        }

        private void XuLyHuy()
        {
            if (_theDangChon == null) { BaoLoi("Bạn chưa chọn mục tiêu nào."); return; }

            var mt = _theDangChon.Du;
            string hoi = $"Hủy mục tiêu \"{mt.TenMucTieu}\"?\nSố đã tiết kiệm ({Tien(mt.SoTienDaTietKiem)}) sẽ được hoàn về ví.";
            if (MessageBox.Show(hoi, "Hủy mục tiêu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var kq = MucTieuNV.HuyMucTieu(mt.MaMT);
            if (!kq.ThanhCong) { BaoLoi(kq.ThongBao); return; }

            NapDanhSach(mt.MaMT);
            BaoThanhCong(kq.ThongBao);
        }

        private void XuLyNapRut(bool nap)
        {
            if (_theDangChon == null) { BaoLoi("Bạn hãy chọn một mục tiêu trước."); return; }

            decimal tien = DocSo(txtSoTienNapRut.Text);
            if (tien <= 0)
            {
                BaoLoi(nap ? "Số tiền nạp phải lớn hơn 0." : "Số tiền rút phải lớn hơn 0.");
                txtSoTienNapRut.Focus();
                return;
            }

            int ma = _theDangChon.Du.MaMT;
            var kq = nap ? MucTieuNV.NapTien(ma, tien) : MucTieuNV.RutTien(ma, tien);
            if (!kq.ThanhCong) { BaoLoi(kq.ThongBao); return; }

            NapDanhSach(ma);
            BaoThanhCong(kq.ThongBao);
        }

        private bool KiemTraNhap()
        {
            if (txtTenMucTieu.Text.Trim().Length == 0)
            {
                BaoLoi("Bạn phải nhập tên mục tiêu.");
                txtTenMucTieu.Focus();
                return false;
            }
            if (DocSo(txtSoTienMucTieu.Text) <= 0)
            {
                BaoLoi("Số tiền mục tiêu phải lớn hơn 0.");
                txtSoTienMucTieu.Focus();
                return false;
            }
            if (dtpNgayDich.Checked && dtpNgayDich.Value.Date <= dtpNgayBatDau.Value.Date)
            {
                BaoLoi("Ngày đích phải sau ngày bắt đầu.");
                dtpNgayDich.Focus();
                return false;
            }
            return true;
        }

        private static decimal DocSo(string text)
        {
            string so = new string((text ?? "").Where(char.IsDigit).ToArray());
            decimal v;
            return decimal.TryParse(so, NumberStyles.None, CultureInfo.InvariantCulture, out v) ? v : 0;
        }

        private MucTieuMH LayDuLieuTuForm()
        {
            return new MucTieuMH
            {
                TenMucTieu = txtTenMucTieu.Text,
                SoTienMucTieu = DocSo(txtSoTienMucTieu.Text),
                NgayBatDau = dtpNgayBatDau.Value.Date,
                NgayDich = dtpNgayDich.Checked ? (DateTime?)dtpNgayDich.Value.Date : null,
                TrangThai = "DangThucHien",
                GhiChu = txtGhiChu.Text
            };
        }

        private class TheMucTieu : Panel
        {
            private static readonly Color MauVienThuong = Color.FromArgb(226, 232, 240);
            private static readonly Color MauNenThanh = Color.FromArgb(226, 232, 240);

            public MucTieuMH Du { get; private set; }

            private bool _daChon;
            public bool DaChon
            {
                get { return _daChon; }
                set { _daChon = value; Invalidate(); }
            }

            private readonly Label _lblTen = new Label();
            private readonly Label _lblTrangThai = new Label();
            private readonly Label _lblTien = new Label();
            private readonly Label _lblTyLe = new Label();
            private readonly Label _lblHan = new Label();
            private readonly Label _lblConThieu = new Label();
            private readonly Panel _thanh = new Panel();
            private readonly Panel _tien = new Panel();
            private int _phanTram;

            public TheMucTieu(MucTieuMH mt, int rong)
            {
                Du = mt;
                DoubleBuffered = true;
                BackColor = Color.White;
                Size = new Size(rong, 88);
                Cursor = Cursors.Hand;

                Color chinh = mt.TrangThai == "HoanThanh" ? MauXanhLa : (mt.TrangThai == "Huy" ? MauXam : MauXanhDuong);

                Cau(_lblTen, 12, 8, 280, 20, new Font("Segoe UI", 9.5F, FontStyle.Bold), Color.FromArgb(30, 41, 59), ContentAlignment.MiddleLeft);
                _lblTen.Anchor = AnchorStyles.Top | AnchorStyles.Left;

                Cau(_lblTrangThai, rong - 12 - 120, 8, 120, 20, new Font("Segoe UI", 8.25F, FontStyle.Bold), chinh, ContentAlignment.MiddleRight);
                _lblTrangThai.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                Cau(_lblTien, 12, 30, 320, 20, new Font("Segoe UI", 9.5F, FontStyle.Bold), chinh, ContentAlignment.MiddleLeft);
                Cau(_lblTyLe, rong - 12 - 60, 30, 60, 20, new Font("Segoe UI", 9.5F, FontStyle.Bold), chinh, ContentAlignment.MiddleRight);
                _lblTyLe.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                _thanh.BackColor = MauNenThanh;
                _thanh.Location = new Point(12, 56);
                _thanh.Size = new Size(rong - 24, 6);
                _thanh.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                _tien.BackColor = chinh;
                _tien.Location = new Point(0, 0);
                _tien.Height = 6;
                _thanh.Controls.Add(_tien);
                _thanh.Resize += (s, e) => CapNhatThanh();

                Cau(_lblHan, 12, 66, 200, 18, new Font("Segoe UI", 8F), MauXam, ContentAlignment.MiddleLeft);
                Cau(_lblConThieu, rong - 12 - 200, 66, 200, 18, new Font("Segoe UI", 8F), MauXam, ContentAlignment.MiddleRight);
                _lblConThieu.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                Controls.AddRange(new Control[] { _lblTen, _lblTrangThai, _lblTien, _lblTyLe, _thanh, _lblHan, _lblConThieu });

                _lblTen.Text = mt.TenMucTieu;
                _lblTrangThai.Text = MucTieuNV.TenTrangThai(mt.TrangThai);
                _lblTien.Text = Tien(mt.SoTienDaTietKiem) + " / " + Tien(mt.SoTienMucTieu);

                _phanTram = mt.SoTienMucTieu > 0
                    ? (int)Math.Min(100, Math.Floor(mt.SoTienDaTietKiem * 100m / mt.SoTienMucTieu))
                    : 0;
                _lblTyLe.Text = _phanTram + "%";
                _lblHan.Text = mt.NgayDich.HasValue ? "Hạn: " + mt.NgayDich.Value.ToString("dd/MM/yyyy") : "Không đặt hạn";
                _lblConThieu.Text = "Còn thiếu: " + Tien(Math.Max(0, mt.SoTienMucTieu - mt.SoTienDaTietKiem));
                CapNhatThanh();
            }

            private static void Cau(Label l, int x, int y, int w, int h, Font f, Color mau, ContentAlignment canLe)
            {
                l.AutoSize = false;
                l.Location = new Point(x, y);
                l.Size = new Size(w, h);
                l.Font = f;
                l.ForeColor = mau;
                l.TextAlign = canLe;
                l.BackColor = Color.Transparent;
            }

            private void CapNhatThanh()
            {
                _tien.Width = _thanh.Width * _phanTram / 100;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                using (var but = new Pen(_daChon ? MauXanhDuong : MauVienThuong, _daChon ? 2 : 1))
                {
                    float d = but.Width / 2f;
                    e.Graphics.DrawRectangle(but, d, d, Width - but.Width, Height - but.Width);
                }
            }
        }
    }
}