using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ClosedXML.Excel;
using PdfSharp.Pdf.IO;
using DuLieu;
using NghiepVu;
using NghiepVu.TienIch;
using MoHinh;
using LTWIN_N05_QLCT.Forms.BaoCao;
using LTWIN_N05_QLCT.Services;

internal static class BieuDoProbe
{
    private static void Check(bool ok, string message)
    {
        if (!ok) throw new Exception(message);
    }

    private static T Field<T>(object form, string name)
    {
        return (T)form.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic).GetValue(form);
    }

    [STAThread]
    private static int Main()
    {
        try
        {
            var users = KetNoiCSDL.DocDuLieu("SELECT MaND FROM NguoiDung ORDER BY MaND");
            Check(users.Rows.Count > 0, "No account to test.");
            foreach (DataRow user in users.Rows)
            {
                int maND = Convert.ToInt32(user["MaND"]);
                foreach (DateTime ky in new[] { new DateTime(2026, 1, 23), new DateTime(2026, 11, 2) })
                {
                    DataTable table = ThongKeNV.LayThuChi12Thang(maND, ky);
                    Check(table.Rows.Count == 12, "Must have 12 months.");
                    for (int i = 0; i < 12; i++)
                    {
                        DateTime thang = new DateTime(ky.Year, ky.Month, 1).AddMonths(i - 11);
                        DataRow row = table.Rows[i];
                        var summary = ThongKeNV.LayTongQuanThang(maND, thang.Month, thang.Year);
                        Check((DateTime)row["Thang"] == thang, "Wrong order/year boundary.");
                        Check((decimal)row["TongThu"] == summary.TongThu, "Income total differs.");
                        Check((decimal)row["TongChi"] == summary.TongChi, "Expense total differs.");
                    }
                }
            }
            Console.WriteLine("PASS 12 months, year boundary, per-user totals vs monthly SQL");

            PhienDangNhap.ThietLapPhien(new NguoiDungMH {
                MaND = Convert.ToInt32(users.Rows[0]["MaND"]), QuyenHan = "User" });
            using (var form = new frmBieuDo())
            {
                // Tạo handle để Chart render đúng, cửa sổ nằm ngoài màn hình.
                form.StartPosition = FormStartPosition.Manual;
                form.Location = new System.Drawing.Point(-20000, -20000);
                form.ShowInTaskbar = false;
                form.Show();
                var picker = Field<DateTimePicker>(form, "dtpKyXem");
                var nap = typeof(frmBieuDo).GetMethod("TaiBieuDo", BindingFlags.Instance | BindingFlags.NonPublic);
                foreach (DateTime ky in new[] { new DateTime(2026, 6, 1), new DateTime(2090, 1, 1) })
                {
                    picker.Value = ky;
                    Check((bool)nap.Invoke(form, null), "Form load failed.");
                    var loai = Field<DataTable>(form, "_chiTheoLoai");
                    var luyKe = Field<DataTable>(form, "_chiLuyKe");
                    var thuChi = Field<DataTable>(form, "_thuChi12Thang");
                    var chartLoai = Field<Chart>(form, "chartChiTheoLoai");
                    var chartLuyKe = Field<Chart>(form, "chartXuHuong");
                    var chartThuChi = Field<Chart>(form, "chartThuChi");
                    Check(chartThuChi.Series["Thu"].Points.Count == 12, "Chart must have 12 points.");
                    string stem = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BieuDoProbe_" + ky.ToString("yyyyMM"));
                    XuatBieuDoService.XuatExcel(stem + ".xlsx", ky, loai, luyKe, thuChi, chartLoai, chartLuyKe, chartThuChi);
                    XuatBieuDoService.XuatPdf(stem + ".pdf", ky, loai, luyKe, thuChi, chartLoai, chartLuyKe, chartThuChi);
                    using (var book = new XLWorkbook(stem + ".xlsx"))
                    {
                        Check(book.Worksheets.Count == 3, "Workbook needs three sheets.");
                        Check(book.Worksheets.Sum(s => s.Pictures.Count) == 3, "Three chart images missing.");
                        var sheet = book.Worksheet("Thu chi 12 tháng");
                        for (int i = 0; i < 12; i++)
                        {
                            Check(sheet.Cell(i + 5, 1).GetDateTime() == (DateTime)thuChi.Rows[i]["Thang"], "Excel date differs.");
                            Check(sheet.Cell(i + 5, 2).GetValue<decimal>() == (decimal)thuChi.Rows[i]["TongThu"], "Excel income differs.");
                            Check(sheet.Cell(i + 5, 3).GetValue<decimal>() == (decimal)thuChi.Rows[i]["TongChi"], "Excel expense differs.");
                        }
                    }
                    using (var pdf = PdfReader.Open(stem + ".pdf", PdfDocumentOpenMode.Import))
                        Check(pdf.PageCount >= 3, "PDF needs all charts.");
                }
                form.Close();
            }
            Console.WriteLine("PASS real form renders and exports valid XLSX/PDF for populated and empty periods");
            return 0;
        }
        catch (Exception ex) { Console.Error.WriteLine(ex); return 1; }
        finally { PhienDangNhap.XoaPhien(); }
    }
}
