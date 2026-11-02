using System;
using System.Linq;
using DuLieu;
using MoHinh;
using NghiepVu;
using NghiepVu.TienIch;
using LTWIN_N05_QLCT.Services;

// Read-only check of the actual service and reporting assemblies. Does not insert or delete records.
internal static class DataServiceProbe
{
    private static void Assert(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }

    private static int Main()
    {
        try
        {
            PhienDangNhap.XoaPhien();
            bool rejected = false;
            try { DataService.GetChiTieu(); }
            catch (InvalidOperationException) { rejected = true; }
            Assert(rejected, "Unauthenticated access must be rejected.");
            Console.WriteLine("PASS unauthenticated access rejected");

            var users = KetNoiCSDL.DocDuLieu("SELECT MaND FROM NguoiDung ORDER BY MaND");
            Assert(users.Rows.Count > 0, "A database account is required.");
            foreach (System.Data.DataRow user in users.Rows)
            {
                PhienDangNhap.ThietLapPhien(new NguoiDungMH { MaND = Convert.ToInt32(user["MaND"]), QuyenHan = "User" });
                var chi = DataService.GetChiTieu();
                var thu = DataService.GetThuNhap();
                var vi = DataService.GetDanhSachVi();
                var loaiChi = DataService.DanhSachLoaiChi;
                var loaiThu = DataService.DanhSachLoaiThu;
                DataService.GetChuyenTien();
                DataService.GetCauHinh();
                DataService.TimKiemGiaoDich();
                Assert(chi.All(x => vi.Any(v => v.Id == x.ViId)), "Expense wallet mapping failed.");
                Assert(thu.All(x => vi.Any(v => v.Id == x.ViId)), "Income wallet mapping failed.");
                var months = chi.Select(x => new DateTime(x.Ngay.Year, x.Ngay.Month, 1))
                    .Concat(thu.Select(x => new DateTime(x.Ngay.Year, x.Ngay.Month, 1)))
                    .Concat(new[] { new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1) }).Distinct();
                foreach (var month in months)
                {
                    var end = month.AddMonths(1).AddDays(-1);
                    var expenses = DataService.GetChiTieu(month, end);
                    var income = DataService.GetThuNhap(month, end);
                    var summary = ThongKeNV.LayTongQuanThang(PhienDangNhap.MaND, month.Month, month.Year);
                    Assert(expenses.Sum(x => x.SoTien) == summary.TongChi, "Expense/report totals differ.");
                    Assert(income.Sum(x => x.SoTien) == summary.TongThu, "Income/report totals differ.");
                    var trend = ThongKeNV.LayXuHuongChiThang(PhienDangNhap.MaND, month.Month, month.Year);
                    Assert(trend.Rows.Count == DateTime.DaysInMonth(month.Year, month.Month), "Trend day count differs.");
                    Assert(Convert.ToDecimal(trend.Rows[trend.Rows.Count - 1]["ChiLuyKe"]) == summary.TongChi, "Trend/report totals differ.");
                    DataService.GetNganSach(month.Month, month.Year);
                }
            }
            Console.WriteLine("PASS SQL reads, wallet mapping, monthly income/expense/report/trend totals for every database account");
            return 0;
        }
        catch (Exception error) { Console.Error.WriteLine("FAIL " + error.Message); return 1; }
        finally { PhienDangNhap.XoaPhien(); }
    }
}
