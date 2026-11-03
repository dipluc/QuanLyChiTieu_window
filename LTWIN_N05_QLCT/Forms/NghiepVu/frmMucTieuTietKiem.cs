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
        private static readonly Color MauVienThuong = Color.FromArgb(226, 232, 240);
        private const string GoiYMacDinh = "Chọn mục tiêu bên trái để xem và cập nhật thông tin.";

        private List<MucTieuMH> _dsMucTieu = new List<MucTieuMH>();
        private MucTieuMH _mucTieuDangChon = null;
        private Panel _panelDangChon = null;
        private bool _dangDinhDang = false;

        public frmMucTieuTietKiem()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            KhoiTaoAlias();
            Load += frmMucTieuTietKiem_Load;
            SizeChanged += frmMucTieuTietKiem_SizeChanged;

            btnThem.Click += (s, e) => XuLyThem();
            btnSua.Click += (s, e) => XuLySua();
            btnHuyMucTieu.Click += (s, e) => XuLyHuy();
            btnMoi.Click += (s, e) => XuLyMoi();
            btnNapTien.Click += (s, e) => XuLyNapRut(true);
            btnRutBot.Click += (s, e) => XuLyNapRut(false);

            // Gán sự kiện click và vẽ viền cho các thẻ thiết kế
            GanClick(pnlTheMucTieu, (s, e) => ChonTheTheoThuTu(0));
            GanClick(pnlTheMucTieu2, (s, e) => ChonTheTheoThuTu(1));
            GanClick(pnlTheMucTieu3, (s, e) => ChonTheTheoThuTu(2));

            pnlTheMucTieu.Paint += (s, e) => VeVienThe(pnlTheMucTieu, e);
            pnlTheMucTieu2.Paint += (s, e) => VeVienThe(pnlTheMucTieu2, e);
            pnlTheMucTieu3.Paint += (s, e) => VeVienThe(pnlTheMucTieu3, e);

            // Mặc định thẻ 1 được chọn
            _panelDangChon = pnlTheMucTieu;

            foreach (TextBox t in new[] { txtSoTienMucTieu, txtSoTienNapRut })
            {
                t.KeyPress += SoTien_KeyPress;
                t.TextChanged += SoTien_TextChanged;
                t.MaxLength = 19;
            }

            dtpNgayBatDau.Format = DateTimePickerFormat.Short;
            dtpNgayDich.Format = DateTimePickerFormat.Short;

            foreach (Control c in new Control[] { txtTenMucTieu, txtSoTienMucTieu, dtpNgayBatDau, dtpNgayDich, txtSoTienNapRut })
                c.KeyDown += Enter_KeyDown;
        }

        private void KhoiTaoAlias()
        {
            this.pnlMucTieu = this.pnlQuanLyMucTieu;
            this.pnlNapRutMucTieu = this.pnlNapRut;
            this.lblCon6Thang11202604 = this.lblCon6Thang;
            this.lblQuyDuPhongDangThucHien = this.lblTenVaTrangThai;
            this.lblDaTietKiem12000000 = this.lblDaTietKiem;
            this.lblConCanTichLuy18000 = this.lblConCanTichLuy;
            this.lblChonMucTieuDenTraiDe = this.lblChonMucTieuBenTraiDe;
        }

        private void frmMucTieuTietKiem_Load(object sender, EventArgs e)
        {
            if (DesignMode || !PhienDangNhap.DaDangNhap) return;
            NapDanhSach(0);
        }

        private void frmMucTieuTietKiem_SizeChanged(object sender, EventArgs e)
        {
            if (flpMucTieu != null)
            {
                int rong = Math.Max(300, flpMucTieu.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 4);
                pnlTheMucTieu.Width = rong;
                pnlNapRut.Width = rong;
                pnlTheMucTieu2.Width = rong;
                pnlTheMucTieu3.Width = rong;
                foreach (Control c in flpMucTieu.Controls)
                {
                    if (c is Panel) c.Width = rong;
                }
            }
        }

        private static void GanClick(Control goc, EventHandler h)
        {
            goc.Click += h;
            foreach (Control con in goc.Controls)
            {
                if (con is TextBox || con is Button || con is DateTimePicker) continue;
                con.Click += h;
            }
        }

        private void VeVienThe(Panel pnl, PaintEventArgs e)
        {
            bool daChon = (_panelDangChon == pnl);
            Color mauVien = daChon ? MauXanhDuong : MauVienThuong;
            int doDay = daChon ? 2 : 1;
            using (var pen = new Pen(mauVien, doDay))
            {
                float d = pen.Width / 2f;
                e.Graphics.DrawRectangle(pen, d, d, pnl.Width - pen.Width, pnl.Height - pen.Width);
            }
        }

        private void NapDanhSach(int maChon)
        {
            _dsMucTieu = MucTieuNV.LayDanhSach();

            CapNhatTomTat();

            // Nếu không có mục tiêu nào trong CSDL
            if (_dsMucTieu.Count == 0)
            {
                pnlTheMucTieu.Visible = false;
                pnlTheMucTieu2.Visible = false;
                pnlTheMucTieu3.Visible = false;
                pnlNapRut.Visible = false;
                ResetForm();
                CapNhatKhungTomTat(null);
                CapNhatNut();
                return;
            }

            // Gán dữ liệu cho Thẻ 1
            if (_dsMucTieu.Count > 0)
            {
                pnlTheMucTieu.Visible = true;
                pnlTheMucTieu.Tag = _dsMucTieu[0];
                DienDuLieuThe(pnlTheMucTieu, _dsMucTieu[0], lblQuyDuPhong, lblDangThucHien, lblDaTietKiemVaMucTieu, lblTyLe, prgMucTieuDaHuyDaHoan, lblHan30042027, lblConThieu18000000);
            }

            // Gán dữ liệu cho Thẻ 2
            if (_dsMucTieu.Count > 1)
            {
                pnlTheMucTieu2.Visible = true;
                pnlTheMucTieu2.Tag = _dsMucTieu[1];
                DienDuLieuThe(pnlTheMucTieu2, _dsMucTieu[1], lblMuaMayTinh, lblHoanThanh, lblDaTietKiemVaMucTieu2, lblTyLe2, prgMucTieuDaHuyDaHoan2, lblHan30092026, lblConThieu0);
            }
            else
            {
                pnlTheMucTieu2.Visible = false;
            }

            // Gán dữ liệu cho Thẻ 3
            if (_dsMucTieu.Count > 2)
            {
                pnlTheMucTieu3.Visible = true;
                pnlTheMucTieu3.Tag = _dsMucTieu[2];
                DienDuLieuThe(pnlTheMucTieu3, _dsMucTieu[2], lblDuLichDaLat, lblDaHuy, lblDaTietKiemVaMucTieu3, lblTyLe3, prgMucTieuDaHuyDaHoan3, lblHan31122026, lblConThieu8000000);
            }
            else
            {
                pnlTheMucTieu3.Visible = false;
            }

            // Xóa các thẻ động từ vị trí thứ 4 trở đi (nếu có từ lần nạp trước)
            var cacTheDong = flpMucTieu.Controls.Cast<Control>()
                .Where(c => c != pnlTheMucTieu && c != pnlNapRut && c != pnlTheMucTieu2 && c != pnlTheMucTieu3)
                .ToList();
            foreach (var td in cacTheDong)
            {
                flpMucTieu.Controls.Remove(td);
                td.Dispose();
            }

            // Nếu có nhiều hơn 3 mục tiêu, tạo thêm các thẻ động
            for (int i = 3; i < _dsMucTieu.Count; i++)
            {
                var mt = _dsMucTieu[i];
                var pnlMoi = TaoTheDong(mt, i);
                flpMucTieu.Controls.Add(pnlMoi);
            }

            // Chọn mục tiêu phù hợp
            int viTriChon = 0;
            if (maChon > 0)
            {
                int index = _dsMucTieu.FindIndex(x => x.MaMT == maChon);
                if (index >= 0) viTriChon = index;
            }

            ChonTheTheoThuTu(viTriChon);
        }

        private void DienDuLieuThe(Panel pnl, MucTieuMH mt, Label lblTen, Label lblTrangThai, Label lblTien, Label lblTyLe, ProgressBar prg, Label lblHan, Label lblConThieu)
        {
            lblTen.Text = mt.TenMucTieu;
            lblTrangThai.Text = MucTieuNV.TenTrangThai(mt.TrangThai);
            lblTien.Text = Tien(mt.SoTienDaTietKiem) + " / " + Tien(mt.SoTienMucTieu);

            int tyLe = mt.SoTienMucTieu > 0
                ? (int)Math.Min(100, Math.Floor(mt.SoTienDaTietKiem * 100m / mt.SoTienMucTieu))
                : 0;
            lblTyLe.Text = tyLe + "%";
            prg.Value = Math.Min(100, Math.Max(0, tyLe));

            lblHan.Text = mt.NgayDich.HasValue ? "Hạn: " + mt.NgayDich.Value.ToString("dd/MM/yyyy") : "Không đặt hạn";
            lblConThieu.Text = "Còn thiếu: " + Tien(Math.Max(0, mt.SoTienMucTieu - mt.SoTienDaTietKiem));

            Color mauChinh = mt.TrangThai == "HoanThanh" ? MauXanhLa : (mt.TrangThai == "Huy" ? MauXam : MauXanhDuong);
            lblTrangThai.ForeColor = mauChinh;
            lblTien.ForeColor = mauChinh;
            lblTyLe.ForeColor = mauChinh;
        }

        private Panel TaoTheDong(MucTieuMH mt, int index)
        {
            var pnl = new Panel
            {
                Size = pnlTheMucTieu.Size,
                Margin = pnlTheMucTieu.Margin,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand,
                Tag = mt
            };

            var lblTen = new Label { Location = lblQuyDuPhong.Location, Size = lblQuyDuPhong.Size, Font = lblQuyDuPhong.Font, ForeColor = lblQuyDuPhong.ForeColor };
            var lblTT = new Label { Location = lblDangThucHien.Location, Size = lblDangThucHien.Size, Font = lblDangThucHien.Font, TextAlign = ContentAlignment.MiddleRight, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            var lblT = new Label { Location = lblDaTietKiemVaMucTieu.Location, Size = lblDaTietKiemVaMucTieu.Size, Font = lblDaTietKiemVaMucTieu.Font };
            var lblTL = new Label { Location = lblTyLe.Location, Size = lblTyLe.Size, Font = lblTyLe.Font, TextAlign = ContentAlignment.MiddleRight, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            var prg = new ProgressBar { Location = prgMucTieuDaHuyDaHoan.Location, Size = prgMucTieuDaHuyDaHoan.Size, Style = ProgressBarStyle.Continuous, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            var lblH = new Label { Location = lblHan30042027.Location, Size = lblHan30042027.Size, Font = lblHan30042027.Font, ForeColor = MauXam };
            var lblCT = new Label { Location = lblConThieu18000000.Location, Size = lblConThieu18000000.Size, Font = lblConThieu18000000.Font, ForeColor = MauXam, TextAlign = ContentAlignment.MiddleRight, Anchor = AnchorStyles.Top | AnchorStyles.Right };

            pnl.Controls.AddRange(new Control[] { lblTen, lblTT, lblT, lblTL, prg, lblH, lblCT });
            DienDuLieuThe(pnl, mt, lblTen, lblTT, lblT, lblTL, prg, lblH, lblCT);

            GanClick(pnl, (s, e) => ChonTheTheoThuTu(index));
            pnl.Paint += (s, e) => VeVienThe(pnl, e);
            return pnl;
        }

        private void ChonTheTheoThuTu(int index)
        {
            if (_dsMucTieu.Count == 0)
            {
                // Khi ở chế độ xem mẫu hoặc trước đăng nhập
                if (index == 0) ChonTheGiaoDien(pnlTheMucTieu, "Quỹ dự phòng", 30000000, 12000000, "DangThucHien", new DateTime(2026, 10, 1), new DateTime(2027, 4, 30), "Dự phòng chi phí sinh hoạt và các tình huống khẩn cấp.");
                else if (index == 1) ChonTheGiaoDien(pnlTheMucTieu2, "Mua máy tính", 20000000, 20000000, "HoanThanh", new DateTime(2026, 1, 1), new DateTime(2026, 9, 30), "Mua laptop phục vụ công việc.");
                else if (index == 2) ChonTheGiaoDien(pnlTheMucTieu3, "Du lịch Đà Lạt", 8000000, 0, "Huy", new DateTime(2026, 6, 1), new DateTime(2026, 12, 31), "Kế hoạch du lịch cuối năm.");
                return;
            }

            if (index < 0 || index >= _dsMucTieu.Count) return;
            var mt = _dsMucTieu[index];

            Panel cardPanel;
            if (index == 0) cardPanel = pnlTheMucTieu;
            else if (index == 1) cardPanel = pnlTheMucTieu2;
            else if (index == 2) cardPanel = pnlTheMucTieu3;
            else
            {
                cardPanel = flpMucTieu.Controls.OfType<Panel>().FirstOrDefault(p => p.Tag == mt) ?? pnlTheMucTieu;
            }

            ChonThe(cardPanel, mt);
        }

        private void ChonTheGiaoDien(Panel cardPanel, string ten, decimal mucTieu, decimal daTietKiem, string trangThai, DateTime batDau, DateTime? dich, string ghiChu)
        {
            var mt = new MucTieuMH
            {
                MaMT = 0,
                TenMucTieu = ten,
                SoTienMucTieu = mucTieu,
                SoTienDaTietKiem = daTietKiem,
                TrangThai = trangThai,
                NgayBatDau = batDau,
                NgayDich = dich,
                GhiChu = ghiChu
            };
            ChonThe(cardPanel, mt);
        }

        private void ChonThe(Panel cardPanel, MucTieuMH mt)
        {
            var panelCu = _panelDangChon;
            _panelDangChon = cardPanel;
            _mucTieuDangChon = mt;

            if (panelCu != null) panelCu.Invalidate();
            if (cardPanel != null) cardPanel.Invalidate();

            HienLenForm(mt);

            // Chuyển panel Nạp/Rút ngay bên dưới thẻ đang chọn
            flpMucTieu.SuspendLayout();
            flpMucTieu.Controls.Remove(pnlNapRut);
            flpMucTieu.Controls.Add(pnlNapRut);
            flpMucTieu.Controls.SetChildIndex(pnlNapRut, flpMucTieu.Controls.GetChildIndex(cardPanel) + 1);
            pnlNapRut.Width = cardPanel.Width;
            pnlNapRut.Visible = true;
            flpMucTieu.ResumeLayout();

            txtSoTienNapRut.Text = "";
            CapNhatNapRut(mt);
            CapNhatKhungTomTat(mt);
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
            return ((long)v).ToString("N0", Vi) + " đ";
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
                decimal moiThang = Math.Ceiling(conThieu / thang);
                lblGoiY.Text = $"Mỗi tháng cần để dành {Tien(moiThang)}";
                lblCon6Thang.Text = $"Còn {thang} tháng ({homNay:MM/yyyy}–{dich:MM/yyyy}) để tích lũy {Tien(conThieu)}.";
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
            bool coChon = _mucTieuDangChon != null && _mucTieuDangChon.MaMT > 0;
            bool huy = _mucTieuDangChon != null && _mucTieuDangChon.TrangThai == "Huy";
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
            txtGhiChu.Text = "";
        }

        private void HienLenForm(MucTieuMH mt)
        {
            txtTenMucTieu.Text = mt.TenMucTieu;
            txtSoTienMucTieu.Text = ((long)mt.SoTienMucTieu).ToString("N0", Vi);
            dtpNgayBatDau.Value = mt.NgayBatDau;
            if (mt.NgayDich.HasValue)
            {
                dtpNgayDich.Value = mt.NgayDich.Value;
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
            _mucTieuDangChon = null;
            if (_panelDangChon != null)
            {
                var p = _panelDangChon;
                _panelDangChon = null;
                p.Invalidate();
            }
            flpMucTieu.Controls.Remove(pnlNapRut);
            pnlNapRut.Visible = false;
            CapNhatKhungTomTat(null);
            CapNhatNut();
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
            if (_mucTieuDangChon == null || _mucTieuDangChon.MaMT <= 0) { BaoLoi("Bạn chưa chọn mục tiêu nào."); return; }
            if (!KiemTraNhap()) return;

            var mt = LayDuLieuTuForm();
            mt.MaMT = _mucTieuDangChon.MaMT;
            mt.TrangThai = _mucTieuDangChon.TrangThai;
            var kq = MucTieuNV.Sua(mt);
            if (!kq.ThanhCong) { BaoLoi(kq.ThongBao); return; }

            NapDanhSach(mt.MaMT);
            BaoThanhCong(kq.ThongBao);
        }

        private void XuLyHuy()
        {
            if (_mucTieuDangChon == null || _mucTieuDangChon.MaMT <= 0) { BaoLoi("Bạn chưa chọn mục tiêu nào."); return; }

            var mt = _mucTieuDangChon;
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
            if (_mucTieuDangChon == null || _mucTieuDangChon.MaMT <= 0) { BaoLoi("Bạn hãy chọn một mục tiêu trước."); return; }

            decimal tien = DocSo(txtSoTienNapRut.Text);
            if (tien <= 0)
            {
                BaoLoi(nap ? "Số tiền nạp phải lớn hơn 0." : "Số tiền rút phải lớn hơn 0.");
                txtSoTienNapRut.Focus();
                return;
            }

            int ma = _mucTieuDangChon.MaMT;
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
            if (dtpNgayDich.Value.Date <= dtpNgayBatDau.Value.Date)
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
                TenMucTieu = txtTenMucTieu.Text.Trim(),
                SoTienMucTieu = DocSo(txtSoTienMucTieu.Text),
                NgayBatDau = dtpNgayBatDau.Value.Date,
                NgayDich = dtpNgayDich.Value.Date,
                TrangThai = "DangThucHien",
                GhiChu = txtGhiChu.Text
            };
        }
    }
}