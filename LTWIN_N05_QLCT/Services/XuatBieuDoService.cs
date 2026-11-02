using ClosedXML.Excel;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace LTWIN_N05_QLCT.Services
{
    public static class XuatBieuDoService
    {
        private static readonly CultureInfo ViVN = CultureInfo.GetCultureInfo("vi-VN");

        // Bảng và Chart phải thuộc cùng một lần tải dữ liệu thành công.
        public static void XuatExcel(string duongDan, DateTime ky,
            DataTable chiTheoLoai, DataTable chiLuyKe, DataTable thuChi,
            Chart chartLoai, Chart chartLuyKe, Chart chartThuChi)
        {
            using (var workbook = new XLWorkbook())
            {
                ThemSheet(workbook, "Chi theo loại", "Chi theo loại • " + ky.ToString("MM/yyyy"),
                    chiTheoLoai, new[] { "TenLoaiChi", "TongChi" },
                    new[] { "Loại chi", "Tổng chi (đồng)" }, chartLoai);
                ThemSheet(workbook, "Chi lũy kế", "Chi lũy kế • " + ky.ToString("MM/yyyy"),
                    chiLuyKe, new[] { "Ngay", "ChiLuyKe" },
                    new[] { "Ngày", "Chi lũy kế (đồng)" }, chartLuyKe);
                ThemSheet(workbook, "Thu chi 12 tháng", TieuDe12Thang(ky),
                    thuChi, new[] { "Thang", "TongThu", "TongChi" },
                    new[] { "Tháng", "Tổng thu (đồng)", "Tổng chi (đồng)" }, chartThuChi);
                workbook.SaveAs(duongDan);
            }
        }

        private static void ThemSheet(XLWorkbook workbook, string ten, string tieuDe,
            DataTable bang, string[] cot, string[] nhan, Chart chart)
        {
            var sheet = workbook.Worksheets.Add(ten);
            sheet.Cell(1, 1).Value = tieuDe;
            sheet.Cell(1, 1).Style.Font.Bold = true;
            sheet.Cell(2, 1).Value = "Tất cả ví • Không tính chuyển tiền nội bộ • Đơn vị: đồng";
            for (int c = 0; c < cot.Length; c++)
                sheet.Cell(4, c + 1).Value = nhan[c];
            sheet.Range(4, 1, 4, cot.Length).Style.Font.Bold = true;

            for (int r = 0; r < bang.Rows.Count; r++)
            {
                for (int c = 0; c < cot.Length; c++)
                {
                    object giaTri = bang.Rows[r][cot[c]];
                    var cell = sheet.Cell(r + 5, c + 1);
                    if (giaTri is DateTime)
                    {
                        cell.Value = (DateTime)giaTri;
                        cell.Style.DateFormat.Format = cot[c] == "Thang" ? "MM/yyyy" : "dd/MM/yyyy";
                    }
                    else if (giaTri is decimal)
                    {
                        cell.Value = (decimal)giaTri;
                        cell.Style.NumberFormat.Format = "#,##0";
                    }
                    else
                        cell.Value = Convert.ToString(giaTri);
                }
            }
            sheet.Columns(1, cot.Length).AdjustToContents();
            sheet.SheetView.FreezeRows(4);
            using (var anh = ChupChart(chart))
                sheet.AddPicture(anh).MoveTo(sheet.Cell(4, cot.Length + 2))
                    .WithSize(800, Math.Max(1, 800 * chart.Height / Math.Max(1, chart.Width)));
        }

        public static void XuatPdf(string duongDan, DateTime ky,
            DataTable chiTheoLoai, DataTable chiLuyKe, DataTable thuChi,
            Chart chartLoai, Chart chartLuyKe, Chart chartThuChi)
        {
            using (var document = new PdfDocument())
            {
                document.Info.Title = "Báo cáo biểu đồ " + ky.ToString("MM/yyyy");
                ThemTrang(document, "Chi theo loại • " + ky.ToString("MM/yyyy"), chiTheoLoai,
                    new[] { "TenLoaiChi", "TongChi" }, new[] { "Loại chi", "Tổng chi (đồng)" }, chartLoai);
                ThemTrang(document, "Chi lũy kế • " + ky.ToString("MM/yyyy"), chiLuyKe,
                    new[] { "Ngay", "ChiLuyKe" }, new[] { "Ngày", "Chi lũy kế (đồng)" }, chartLuyKe);
                ThemTrang(document, TieuDe12Thang(ky), thuChi,
                    new[] { "Thang", "TongThu", "TongChi" },
                    new[] { "Tháng", "Tổng thu (đồng)", "Tổng chi (đồng)" }, chartThuChi);
                document.Save(duongDan);
            }
        }

        // Tự ngắt trang khi có nhiều loại chi; tiêu đề bảng được lặp lại.
        private static void ThemTrang(PdfDocument document, string tieuDe, DataTable bang,
            string[] cot, string[] nhan, Chart chart)
        {
            var font = new XFont("Segoe UI", 10, XFontStyleEx.Regular);
            var fontDam = new XFont("Segoe UI", 12, XFontStyleEx.Bold);
            using (var anh = ChupChart(chart))
            using (var image = XImage.FromStream(anh))
            {
                int dong = 0;
                bool trangDau = true;
                do
                {
                    var page = document.AddPage();
                    page.Size = PdfSharp.PageSize.A4;
                    using (var graphics = XGraphics.FromPdfPage(page))
                    {
                        double rong = page.Width.Point - 72;
                        graphics.DrawString(tieuDe, fontDam, XBrushes.Black, 36, 36);
                        graphics.DrawString("Tất cả ví • Không tính chuyển tiền nội bộ • Đơn vị: đồng",
                            font, XBrushes.Gray, 36, 55);
                        double y = 80;
                        if (trangDau)
                        {
                            double cao = Math.Min(210, rong * image.PixelHeight / image.PixelWidth);
                            double rongAnh = cao * image.PixelWidth / image.PixelHeight;
                            graphics.DrawImage(image, 36, y, rongAnh, cao);
                            y += cao + 24;
                        }
                        double rongCot = rong / cot.Length;
                        for (int c = 0; c < nhan.Length; c++)
                            graphics.DrawString(nhan[c], font, XBrushes.DarkBlue, 36 + c * rongCot, y);
                        y += 20;
                        if (bang.Rows.Count == 0)
                            graphics.DrawString("Chưa có dữ liệu trong kỳ này.", font, XBrushes.Gray, 36, y);
                        while (dong < bang.Rows.Count && y < page.Height.Point - 45)
                        {
                            for (int c = 0; c < cot.Length; c++)
                            {
                                object giaTri = bang.Rows[dong][cot[c]];
                                string chu = giaTri is DateTime
                                    ? ((DateTime)giaTri).ToString(cot[c] == "Thang" ? "MM/yyyy" : "dd/MM/yyyy")
                                    : giaTri is decimal ? ((decimal)giaTri).ToString("N0", ViVN)
                                    : Convert.ToString(giaTri);
                                // Rút gọn chuỗi quá dài để không đè lên cột số tiền.
                                while (chu.Length > 1 && graphics.MeasureString(chu, font).Width > rongCot - 12)
                                    chu = chu.Substring(0, chu.Length - 2) + "…";
                                graphics.DrawString(chu, font, XBrushes.Black, 36 + c * rongCot, y);
                            }
                            dong++;
                            y += 16;
                        }
                    }
                    trangDau = false;
                } while (dong < bang.Rows.Count);
            }
        }

        private static MemoryStream ChupChart(Chart chart)
        {
            var stream = new MemoryStream();
            try
            {
                chart.SaveImage(stream, ChartImageFormat.Png);
                stream.Position = 0;
                return stream;
            }
            catch
            {
                stream.Dispose();
                throw;
            }
        }

        private static string TieuDe12Thang(DateTime ky)
        {
            return string.Format("Thu chi 12 tháng • {0:MM/yyyy} – {1:MM/yyyy}", ky.AddMonths(-11), ky);
        }
    }
}
