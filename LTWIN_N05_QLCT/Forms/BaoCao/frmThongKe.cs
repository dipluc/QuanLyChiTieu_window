using LTWIN_N05_QLCT.Forms;
using LTWIN_N05_QLCT.Services;
using NghiepVu;
using NghiepVu.TienIch;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LTWIN_N05_QLCT.Forms.BaoCao
{
    public partial class frmThongKe : Form, IDongBoThang
    {
        private enum KyThongKeEnum
        {
            Ngay,
            Tuan,
            Thang,
            Quy,
            Nam
        }

        private int _maND = 0;
        private KyThongKeEnum _kyHienTai = KyThongKeEnum.Thang;

        public frmThongKe()
        {
            InitializeComponent();
            _maND = PhienDangNhap.DaDangNhap ? PhienDangNhap.MaND : 0;
            KhoiTaoGiaoDien();
        }

        private void KhoiTaoGiaoDien()
        {
            // Thiết lập mặc định
            dtpKy.Value = DateTime.Now;

            // Đăng ký sự kiện kỳ thống kê
            btnKyNgay.Click += (s, e) => ChonKy(KyThongKeEnum.Ngay);
            btnKyTuan.Click += (s, e) => ChonKy(KyThongKeEnum.Tuan);
            btnKyThang.Click += (s, e) => ChonKy(KyThongKeEnum.Thang);
            btnKyQuy.Click += (s, e) => ChonKy(KyThongKeEnum.Quy);
            btnKyNam.Click += (s, e) => ChonKy(KyThongKeEnum.Nam);

            // Nút xem thống kê & thay đổi ngày
            btnThongKe.Click += (s, e) => TaiDuLieu();
            dtpKy.ValueChanged += (s, e) => TaiDuLieu();

            // Nút xuất Excel / PDF
            try
            {
                btnXuatExcel.Image = new Bitmap(global::LTWIN_N05_QLCT.Properties.Resources.icoXuatBaoCao_XanhDuong, new Size(18, 18));
                btnXuatPDF.Image = new Bitmap(global::LTWIN_N05_QLCT.Properties.Resources.icoXuatBaoCao_XanhDuong, new Size(18, 18));
            }
            catch { }
            btnXuatExcel.Click += BtnXuatExcel_Click;
            btnXuatPDF.Click += BtnXuatPDF_Click;

            // Định dạng DataGridView
            dgvTopChiTieu.AutoGenerateColumns = false;
            dgvTopChiTieu.CellFormatting += DgvTopChiTieu_CellFormatting;

            // Vẽ viền tinh tế cho các thẻ
            VeVienThe(pnlTheTongHop1);
            VeVienThe(pnlTheTongHop2);
            VeVienThe(pnlTheTongHop3);
            VeVienThe(pnlTheTongHop4);
            VeVienThe(pnlTheTongHop);
            VeVienThe(pnlSoSanhKyTruoc);

            // Cập nhật giao diện nút kỳ mặc định
            CapNhatGiaoDienNutKy();
        }

        private void VeVienThe(Panel pnl)
        {
            pnl.Paint += (s, e) =>
            {
                using (var pen = new Pen(Color.FromArgb(226, 232, 240), 1))
                {
                    var rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);
                    e.Graphics.DrawRectangle(pen, rect);
                }
            };
        }

        public void DongBoThang(DateTime ngay)
        {
            if (_kyHienTai == KyThongKeEnum.Thang)
            {
                dtpKy.Value = new DateTime(ngay.Year, ngay.Month, 1);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_maND <= 0 && PhienDangNhap.DaDangNhap)
                _maND = PhienDangNhap.MaND;

            TaiDuLieu();
        }

        private void ChonKy(KyThongKeEnum ky)
        {
            _kyHienTai = ky;
            CapNhatGiaoDienNutKy();

            switch (ky)
            {
                case KyThongKeEnum.Ngay:
                    lblKy.Text = "Ngày";
                    dtpKy.CustomFormat = "dd/MM/yyyy";
                    break;
                case KyThongKeEnum.Tuan:
                    lblKy.Text = "Tuần";
                    dtpKy.CustomFormat = "dd/MM/yyyy";
                    break;
                case KyThongKeEnum.Thang:
                    lblKy.Text = "Tháng / năm";
                    dtpKy.CustomFormat = "MM/yyyy";
                    break;
                case KyThongKeEnum.Quy:
                    lblKy.Text = "Quý / năm";
                    dtpKy.CustomFormat = "MM/yyyy";
                    break;
                case KyThongKeEnum.Nam:
                    lblKy.Text = "Năm";
                    dtpKy.CustomFormat = "yyyy";
                    break;
            }

            TaiDuLieu();
        }

        private void CapNhatGiaoDienNutKy()
        {
            Button[] nutKy = { btnKyNgay, btnKyTuan, btnKyThang, btnKyQuy, btnKyNam };
            KyThongKeEnum[] kyTuongUng = { KyThongKeEnum.Ngay, KyThongKeEnum.Tuan, KyThongKeEnum.Thang, KyThongKeEnum.Quy, KyThongKeEnum.Nam };

            for (int i = 0; i < nutKy.Length; i++)
            {
                bool isSelected = (kyTuongUng[i] == _kyHienTai);
                if (isSelected)
                {
                    nutKy[i].BackColor = Color.FromArgb(239, 246, 255);
                    nutKy[i].ForeColor = Color.FromArgb(0, 95, 184);
                    nutKy[i].FlatAppearance.BorderColor = Color.FromArgb(0, 95, 184);
                    nutKy[i].Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
                else
                {
                    nutKy[i].BackColor = Color.White;
                    nutKy[i].ForeColor = Color.FromArgb(51, 65, 85);
                    nutKy[i].FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
                    nutKy[i].Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                }
            }
        }

        private void TinhKhoangThoiGian(out DateTime tuNgay, out DateTime denNgay,
            out DateTime tuNgayTruoc, out DateTime denNgayTruoc,
            out string moTaDuLieuDen, out string moTaSoSanh, out string tenKyTruoc)
        {
            DateTime ngayChon = dtpKy.Value.Date;
            DateTime now = DateTime.Now;

            switch (_kyHienTai)
            {
                case KyThongKeEnum.Ngay:
                    tuNgay = ngayChon;
                    denNgay = ngayChon.AddDays(1);
                    tuNgayTruoc = ngayChon.AddDays(-1);
                    denNgayTruoc = ngayChon;
                    moTaDuLieuDen = $"Ngày {tuNgay:dd/MM/yyyy} • Dữ liệu đến ngày {now:dd/MM/yyyy}";
                    moTaSoSanh = $"Ngày {tuNgay:dd/MM/yyyy} so với ngày {tuNgayTruoc:dd/MM/yyyy} hôm trước.";
                    tenKyTruoc = "Hôm trước";
                    break;

                case KyThongKeEnum.Tuan:
                    int diff = (7 + (ngayChon.DayOfWeek - DayOfWeek.Monday)) % 7;
                    tuNgay = ngayChon.AddDays(-diff);
                    denNgay = tuNgay.AddDays(7);
                    tuNgayTruoc = tuNgay.AddDays(-7);
                    denNgayTruoc = tuNgay;
                    moTaDuLieuDen = $"Tuần {tuNgay:dd/MM}–{denNgay.AddDays(-1):dd/MM/yyyy} • Dữ liệu đến {now:dd/MM/yyyy}";
                    moTaSoSanh = $"Tuần này ({tuNgay:dd/MM}–{denNgay.AddDays(-1):dd/MM}) so với tuần trước ({tuNgayTruoc:dd/MM}–{denNgayTruoc.AddDays(-1):dd/MM}).";
                    tenKyTruoc = "Tuần trước";
                    break;

                case KyThongKeEnum.Quy:
                    int quy = (ngayChon.Month - 1) / 3 + 1;
                    tuNgay = new DateTime(ngayChon.Year, (quy - 1) * 3 + 1, 1);
                    denNgay = tuNgay.AddMonths(3);
                    tuNgayTruoc = tuNgay.AddMonths(-3);
                    denNgayTruoc = tuNgay;
                    int quyTruoc = (quy == 1) ? 4 : quy - 1;
                    int namQuyTruoc = (quy == 1) ? tuNgay.Year - 1 : tuNgay.Year;
                    moTaDuLieuDen = $"Quý {quy}/{tuNgay.Year} • Dữ liệu đến ngày {now:dd/MM/yyyy}";
                    moTaSoSanh = $"Quý {quy}/{tuNgay.Year} so với Quý {quyTruoc}/{namQuyTruoc}.";
                    tenKyTruoc = "Quý trước";
                    break;

                case KyThongKeEnum.Nam:
                    tuNgay = new DateTime(ngayChon.Year, 1, 1);
                    denNgay = tuNgay.AddYears(1);
                    tuNgayTruoc = tuNgay.AddYears(-1);
                    denNgayTruoc = tuNgay;
                    moTaDuLieuDen = $"Năm {tuNgay.Year} • Dữ liệu đến ngày {now:dd/MM/yyyy}";
                    moTaSoSanh = $"Năm {tuNgay.Year} so với năm {tuNgayTruoc.Year}.";
                    tenKyTruoc = "Năm trước";
                    break;

                case KyThongKeEnum.Thang:
                default:
                    tuNgay = new DateTime(ngayChon.Year, ngayChon.Month, 1);
                    denNgay = tuNgay.AddMonths(1);
                    tuNgayTruoc = tuNgay.AddMonths(-1);
                    denNgayTruoc = tuNgay;

                    moTaDuLieuDen = $"Tháng {tuNgay:MM/yyyy} • Dữ liệu đến ngày {now:dd/MM/yyyy}";
                    if (tuNgay.Year == now.Year && tuNgay.Month == now.Month)
                    {
                        moTaSoSanh = $"Tháng {tuNgay:MM} (01–{now:dd}/{tuNgay:MM}) so với tháng {tuNgayTruoc:MM/yyyy} (đủ tháng).";
                    }
                    else
                    {
                        moTaSoSanh = $"Tháng {tuNgay:MM/yyyy} so với tháng {tuNgayTruoc:MM/yyyy} (đủ tháng).";
                    }
                    tenKyTruoc = "Tháng trước";
                    break;
            }
        }

        private void TaiDuLieu()
        {
            if (_maND <= 0 && PhienDangNhap.DaDangNhap)
                _maND = PhienDangNhap.MaND;

            TinhKhoangThoiGian(out DateTime tuNgay, out DateTime denNgay,
                out DateTime tuNgayTruoc, out DateTime denNgayTruoc,
                out string moTaDuLieuDen, out string moTaSoSanh, out string tenKyTruoc);

            lblThangDuLieuDen.Text = moTaDuLieuDen;
            lblSoSanhVoiThangTruoc.Text = $"So sánh với {tenKyTruoc.ToLower()}";
            lblThang10012610So.Text = moTaSoSanh;

            if (_maND <= 0)
            {
                XoaTrangDuLieu();
                return;
            }

            try
            {
                // 1. Dữ liệu tổng quan kỳ hiện tại
                var tqHienTai = ThongKeNV.LayTongQuan(_maND, tuNgay, denNgay);
                decimal tongThu = tqHienTai != null ? tqHienTai.TongThu : 0m;
                decimal tongChi = tqHienTai != null ? tqHienTai.TongChi : 0m;
                decimal chenhLech = tongThu - tongChi;
                decimal tyLeTietKiem = tongThu > 0 ? (chenhLech / tongThu) * 100m : 0m;

                // Cập nhật 4 thẻ tổng hợp
                lblTongThu2.Text = tongThu.ToString("N0") + " đ";
                lblTongChi2.Text = tongChi.ToString("N0") + " đ";
                lblChenhLech2.Text = chenhLech.ToString("N0") + " đ";
                lblTyLeTietKiem2.Text = tyLeTietKiem.ToString("N1") + "%";

                // Chi tiết nguồn thu
                CapNhatPhanTichNguonThu(tuNgay, denNgay, tongThu);

                // 2. Dữ liệu 5 khoản chi lớn nhất
                var dtTop = ThongKeNV.LayTopKhoanChi(_maND, tuNgay, denNgay, 5);
                dgvTopChiTieu.DataSource = dtTop;

                var tongKhoan = ThongKeNV.DemTongKhoanChi(_maND, tuNgay, denNgay);
                decimal tong5Khoan = 0m;
                if (dtTop != null)
                {
                    foreach (DataRow row in dtTop.Rows)
                    {
                        tong5Khoan += Convert.ToDecimal(row["SoTien"]);
                    }
                }
                lblChiDoc5KhoanLonNhat.Text = $"Chỉ đọc • {(dtTop != null ? dtTop.Rows.Count : 0)} khoản lớn nhất / {tongKhoan.SoKhoan} khoản chi • Tổng {(dtTop != null ? dtTop.Rows.Count : 0)} khoản: {tong5Khoan:N0} đ";

                // 3. Dữ liệu so sánh kỳ trước
                var tqTruoc = ThongKeNV.LayTongQuan(_maND, tuNgayTruoc, denNgayTruoc);
                decimal thuTruoc = tqTruoc != null ? tqTruoc.TongThu : 0m;
                decimal chiTruoc = tqTruoc != null ? tqTruoc.TongChi : 0m;
                decimal chenhLechTruoc = thuTruoc - chiTruoc;
                decimal tyLeTietKiemTruoc = thuTruoc > 0 ? (chenhLechTruoc / thuTruoc) * 100m : 0m;

                lblThangTruoc25000000.Text = $"{tenKyTruoc}: {thuTruoc:N0} đ";
                lblThangTruoc17500000.Text = $"{tenKyTruoc}: {chiTruoc:N0} đ";
                lblThangTruoc7500000.Text = $"{tenKyTruoc}: {chenhLechTruoc:N0} đ";
                lblThangTruoc300.Text = $"{tenKyTruoc}: {tyLeTietKiemTruoc:N1}%";

                // Tính toán tỷ lệ chênh lệch
                CapNhatChiSoSoSanh(lblTongThuPhanTram, tongThu, thuTruoc, false);
                CapNhatChiSoSoSanh(lblTongChiPhanTram, tongChi, chiTruoc, true); // Chi tiêu giảm là tốt (xanh)
                CapNhatChiSoSoSanh(lblChenhLechPhanTram, chenhLech, chenhLechTruoc, false);

                decimal diffDiemPct = tyLeTietKiem - tyLeTietKiemTruoc;
                if (Math.Abs(diffDiemPct) < 0.05m)
                {
                    lblTyLeTietKiemPhanTram.Text = "↔ 0,0 điểm %";
                    lblTyLeTietKiemPhanTram.ForeColor = Color.FromArgb(71, 85, 105);
                }
                else if (diffDiemPct > 0)
                {
                    lblTyLeTietKiemPhanTram.Text = $"↑ {diffDiemPct:N1} điểm %";
                    lblTyLeTietKiemPhanTram.ForeColor = Color.FromArgb(22, 163, 74);
                }
                else
                {
                    lblTyLeTietKiemPhanTram.Text = $"↓ {Math.Abs(diffDiemPct):N1} điểm %";
                    lblTyLeTietKiemPhanTram.ForeColor = Color.FromArgb(220, 38, 38);
                }

                // Nhận định tóm tắt ở cuối
                decimal diffChi = tongChi - chiTruoc;
                decimal diffChenhLech = chenhLech - chenhLechTruoc;

                if (diffChi < 0)
                {
                    lblChiTeuGiam700000So.Text = $"Chi tiêu giảm {Math.Abs(diffChi):N0} đ; {(diffChenhLech >= 0 ? "số tiền còn lại tăng tương ứng" : "số tiền còn lại thay đổi")} so với {tenKyTruoc.ToLower()}.";
                }
                else if (diffChi > 0)
                {
                    lblChiTeuGiam700000So.Text = $"Chi tiêu tăng {diffChi:N0} đ; {(diffChenhLech <= 0 ? "số tiền còn lại giảm tương ứng" : "số tiền còn lại thay đổi")} so với {tenKyTruoc.ToLower()}.";
                }
                else
                {
                    lblChiTeuGiam700000So.Text = $"Mức chi tiêu tương đương so với {tenKyTruoc.ToLower()}.";
                }
            }
            catch (Exception ex)
            {
                lblChiTeuGiam700000So.Text = "Lỗi khi tổng hợp dữ liệu: " + ex.Message;
            }
        }

        private void CapNhatPhanTichNguonThu(DateTime tuNgay, DateTime denNgay, decimal tongThu)
        {
            try
            {
                var dtThu = ThongKeNV.LayThuTheoLoai(_maND, tuNgay, denNgay);
                if (dtThu != null && dtThu.Rows.Count > 0 && tongThu > 0)
                {
                    string phanTich = "";
                    for (int i = 0; i < Math.Min(2, dtThu.Rows.Count); i++)
                    {
                        string tenLoai = dtThu.Rows[i]["TenLoaiThu"].ToString();
                        decimal tien = Convert.ToDecimal(dtThu.Rows[i]["TongThu"]);
                        string moTaTien = DinhDangTienNgan(tien);

                        if (i > 0) phanTich += " + ";
                        phanTich += $"{tenLoai} {moTaTien}";
                    }
                    lblLuong23TrieuThuKhac2.Text = phanTich;
                }
                else
                {
                    lblLuong23TrieuThuKhac2.Text = tongThu > 0 ? "100% thu nhập trong kỳ" : "Chưa có phát sinh";
                }
            }
            catch
            {
                lblLuong23TrieuThuKhac2.Text = "Tất cả nguồn thu";
            }
        }

        private string DinhDangTienNgan(decimal tien)
        {
            if (tien >= 1000000000m)
                return (tien / 1000000000m).ToString("0.#") + " tỷ";
            if (tien >= 1000000m)
                return (tien / 1000000m).ToString("0.#") + " triệu";
            if (tien >= 1000m)
                return (tien / 1000m).ToString("0.#") + " nghìn";
            return tien.ToString("N0") + " đ";
        }

        private void CapNhatChiSoSoSanh(Label lbl, decimal hienTai, decimal truoc, bool laChiTieu)
        {
            decimal diff = hienTai - truoc;
            decimal pct = 0m;
            if (truoc != 0)
            {
                pct = (diff / Math.Abs(truoc)) * 100m;
            }
            else if (hienTai > 0)
            {
                pct = 100m;
            }

            if (Math.Abs(pct) < 0.05m || (hienTai == 0 && truoc == 0))
            {
                lbl.Text = "↔ 0,0%";
                lbl.ForeColor = Color.FromArgb(71, 85, 105);
            }
            else if (pct > 0)
            {
                lbl.Text = $"↑ {pct:N1}%";
                // Nếu là chi tiêu, tăng là Đỏ. Nếu là thu/chênh lệch, tăng là Xanh
                lbl.ForeColor = laChiTieu ? Color.FromArgb(220, 38, 38) : Color.FromArgb(22, 163, 74);
            }
            else
            {
                lbl.Text = $"↓ {Math.Abs(pct):N1}%";
                // Nếu là chi tiêu, giảm là Xanh. Nếu là thu/chênh lệch, giảm là Đỏ
                lbl.ForeColor = laChiTieu ? Color.FromArgb(22, 163, 74) : Color.FromArgb(220, 38, 38);
            }
        }

        private void DgvTopChiTieu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvTopChiTieu.Columns[e.ColumnIndex].Name;
            if (colName == "colNgay" && e.Value is DateTime dt)
            {
                e.Value = dt.ToString("dd/MM/yyyy");
                e.FormattingApplied = true;
            }
            else if (colName == "colSoTien" && e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal tien))
            {
                e.Value = tien.ToString("N0") + " đ";
                e.FormattingApplied = true;
            }
        }

        private void XoaTrangDuLieu()
        {
            lblTongThu2.Text = "0 đ";
            lblTongChi2.Text = "0 đ";
            lblChenhLech2.Text = "0 đ";
            lblTyLeTietKiem2.Text = "0,0%";
            lblLuong23TrieuThuKhac2.Text = "Chưa có dữ liệu";
            dgvTopChiTieu.DataSource = null;
            lblChiDoc5KhoanLonNhat.Text = "Chỉ đọc • 0 khoản";
            lblChiTeuGiam700000So.Text = "Vui lòng đăng nhập để xem số liệu thống kê.";
        }

        private void BtnXuatExcel_Click(object sender, EventArgs e)
        {
            if (dgvTopChiTieu.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu khoản chi để xuất Excel.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string tieuDe = $"Thống kê chi tiêu • {lblThangDuLieuDen.Text}";
            XuatExcelHelper.XuatDataGridViewRaExcel(dgvTopChiTieu, "ThongKeChiTieu", tieuDe);
        }

        private void BtnXuatPDF_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Document (*.pdf)|*.pdf";
                sfd.FileName = $"ThongKe_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var doc = new PdfSharp.Pdf.PdfDocument())
                        {
                            doc.Info.Title = "Báo cáo thống kê chi tiêu";
                            var page = doc.AddPage();
                            page.Size = PdfSharp.PageSize.A4;

                            using (var gfx = PdfSharp.Drawing.XGraphics.FromPdfPage(page))
                            {
                                var fontTieuDe = new PdfSharp.Drawing.XFont("Segoe UI", 16, PdfSharp.Drawing.XFontStyleEx.Bold);
                                var fontThuong = new PdfSharp.Drawing.XFont("Segoe UI", 10, PdfSharp.Drawing.XFontStyleEx.Regular);
                                var fontDam = new PdfSharp.Drawing.XFont("Segoe UI", 10, PdfSharp.Drawing.XFontStyleEx.Bold);

                                double y = 40;
                                gfx.DrawString("BÁO CÁO THỐNG KÊ CHI TIÊU", fontTieuDe, PdfSharp.Drawing.XBrushes.Navy, new PdfSharp.Drawing.XPoint(40, y));
                                y += 25;
                                gfx.DrawString(lblThangDuLieuDen.Text, fontThuong, PdfSharp.Drawing.XBrushes.Gray, new PdfSharp.Drawing.XPoint(40, y));
                                y += 35;

                                // Tổng hợp
                                gfx.DrawString($"Tổng thu: {lblTongThu2.Text}", fontDam, PdfSharp.Drawing.XBrushes.ForestGreen, new PdfSharp.Drawing.XPoint(40, y));
                                gfx.DrawString($"Tổng chi: {lblTongChi2.Text}", fontDam, PdfSharp.Drawing.XBrushes.Crimson, new PdfSharp.Drawing.XPoint(200, y));
                                gfx.DrawString($"Chênh lệch: {lblChenhLech2.Text}", fontDam, PdfSharp.Drawing.XBrushes.RoyalBlue, new PdfSharp.Drawing.XPoint(360, y));
                                y += 20;
                                gfx.DrawString($"Tỷ lệ tiết kiệm: {lblTyLeTietKiem2.Text}", fontDam, PdfSharp.Drawing.XBrushes.DarkSlateGray, new PdfSharp.Drawing.XPoint(40, y));
                                y += 35;

                                // Bảng 5 khoản chi lớn nhất
                                gfx.DrawString("5 KHOẢN CHI LỚN NHẤT", fontDam, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XPoint(40, y));
                                y += 20;

                                // Vẽ tiêu đề cột
                                gfx.DrawRectangle(PdfSharp.Drawing.XBrushes.LightGray, 40, y, 515, 20);
                                gfx.DrawString("Ngày", fontDam, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XPoint(45, y + 14));
                                gfx.DrawString("Loại chi", fontDam, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XPoint(120, y + 14));
                                gfx.DrawString("Ghi chú", fontDam, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XPoint(240, y + 14));
                                gfx.DrawString("Số tiền", fontDam, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XPoint(450, y + 14));
                                y += 20;

                                foreach (DataGridViewRow row in dgvTopChiTieu.Rows)
                                {
                                    string ngay = row.Cells["colNgay"].FormattedValue?.ToString() ?? "";
                                    string loaiChi = row.Cells["colLoaiChi"].FormattedValue?.ToString() ?? "";
                                    string ghiChu = row.Cells["colGhiChu"].FormattedValue?.ToString() ?? "";
                                    string soTien = row.Cells["colSoTien"].FormattedValue?.ToString() ?? "";

                                    gfx.DrawString(ngay, fontThuong, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XPoint(45, y + 14));
                                    gfx.DrawString(loaiChi, fontThuong, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XPoint(120, y + 14));
                                    gfx.DrawString(ghiChu.Length > 30 ? ghiChu.Substring(0, 27) + "..." : ghiChu, fontThuong, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XPoint(240, y + 14));
                                    gfx.DrawString(soTien, fontDam, PdfSharp.Drawing.XBrushes.Crimson, new PdfSharp.Drawing.XPoint(450, y + 14));

                                    y += 20;
                                }

                                y += 25;
                                gfx.DrawString(lblChiDoc5KhoanLonNhat.Text, fontThuong, PdfSharp.Drawing.XBrushes.Gray, new PdfSharp.Drawing.XPoint(40, y));
                                y += 30;

                                // So sánh
                                gfx.DrawString("SO SÁNH VỚI KỲ TRƯỚC", fontDam, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XPoint(40, y));
                                y += 20;
                                gfx.DrawString($"Tổng thu: {lblTongThuPhanTram.Text} ({lblThangTruoc25000000.Text})", fontThuong, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XPoint(40, y));
                                y += 18;
                                gfx.DrawString($"Tổng chi: {lblTongChiPhanTram.Text} ({lblThangTruoc17500000.Text})", fontThuong, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XPoint(40, y));
                                y += 18;
                                gfx.DrawString($"Chênh lệch: {lblChenhLechPhanTram.Text} ({lblThangTruoc7500000.Text})", fontThuong, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XPoint(40, y));
                                y += 18;
                                gfx.DrawString($"Tỷ lệ tiết kiệm: {lblTyLeTietKiemPhanTram.Text} ({lblThangTruoc300.Text})", fontThuong, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XPoint(40, y));
                                y += 25;
                                gfx.DrawString(lblChiTeuGiam700000So.Text, fontThuong, PdfSharp.Drawing.XBrushes.DarkSlateGray, new PdfSharp.Drawing.XPoint(40, y));
                            }

                            doc.Save(sfd.FileName);
                            MessageBox.Show("Xuất tệp PDF thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
