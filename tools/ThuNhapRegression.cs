using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using LTWIN_N05_QLCT.Forms.NghiepVu;
using LTWIN_N05_QLCT.Services;
using MoHinh;
using NghiepVu.TienIch;

// Only the SQL boundary is replaced: production service, model and form are compiled unchanged.
namespace DuLieu
{
    public static class KetNoiCSDL
    {
        public static readonly DataTable Categories = new DataTable();
        public static readonly DataTable Income = new DataTable();

        static KetNoiCSDL()
        {
            Categories.Columns.Add("MaLoaiThu", typeof(int));
            Categories.Columns.Add("MaND", typeof(int));
            Categories.Columns.Add("TenLoaiThu", typeof(string));
            Categories.Columns.Add("TrangThai", typeof(bool));
            Categories.Rows.Add(1, 1, "Lương", true);
            Categories.Rows.Add(2, 1, "Kinh doanh", true);
            Categories.Rows.Add(3, 1, "Lãi tiết kiệm", true);
            Categories.Rows.Add(4, 1, "Quà tặng", true);
            Categories.Rows.Add(5, 1, "Loại cũ", false);
            Categories.Rows.Add(6, 1, "Ngừng chưa dùng", false);
            Categories.Rows.Add(9, 2, "Loại người khác", true);
            Income.Columns.Add("Id", typeof(int));
            Income.Columns.Add("MaND", typeof(int));
            Income.Columns.Add("MaLoaiThu", typeof(int));
            Income.Columns.Add("Ngay", typeof(DateTime));
            Income.Columns.Add("MaVi", typeof(int));
            Income.Columns.Add("SoTien", typeof(decimal));
            Income.Columns.Add("GhiChu", typeof(string));
            Income.Rows.Add(101, 1, 1, new DateTime(2026, 6, 1), 10, 100m, "");
            Income.Rows.Add(102, 1, 2, new DateTime(2026, 6, 2), 10, 200m, "");
            Income.Rows.Add(103, 1, 3, new DateTime(2026, 6, 3), 10, 300m, "");
            Income.Rows.Add(104, 1, 4, new DateTime(2026, 6, 4), 10, 400m, "");
            Income.Rows.Add(105, 1, 5, new DateTime(2026, 6, 30, 23, 59, 59), 10, 500m, "");
            Income.Rows.Add(106, 1, 1, new DateTime(2026, 7, 1), 10, 900m, "");
            Income.Rows.Add(109, 2, 9, new DateTime(2026, 6, 1), 20, 9999m, "");
        }

        public static SqlConnection LayKetNoi()
        {
            throw new InvalidOperationException("Regression tests must never open a database connection.");
        }

        private static object Param(SqlParameter[] args, string name)
        {
            return args.Single(p => p.ParameterName == name).Value;
        }

        public static DataTable DocDuLieu(string sql, params SqlParameter[] args)
        {
            int user = (int)Param(args, "@MaND");
            if (!sql.Contains("@MaND")) throw new Exception("Missing user scope in query.");
            if (sql.Contains("FROM LoaiThu"))
            {
                var result = new DataTable();
                result.Columns.Add("TenLoaiThu", typeof(string));
                foreach (var row in Categories.AsEnumerable().Where(r => (int)r["MaND"] == user)
                    .OrderBy(r => (string)r["TenLoaiThu"]))
                {
                    bool hasIncome = Income.AsEnumerable().Any(t => (int)t["MaND"] == user &&
                        (int)t["MaLoaiThu"] == (int)row["MaLoaiThu"]);
                    if ((bool)row["TrangThai"] || (sql.Contains("EXISTS") && hasIncome))
                        result.Rows.Add(row["TenLoaiThu"]);
                }
                return result;
            }
            if (sql.Contains("FROM vw_SoDuVi"))
            {
                var result = new DataTable();
                result.Columns.Add("MaVi", typeof(int));
                result.Columns.Add("TenVi", typeof(string));
                result.Columns.Add("SoDuHienTai", typeof(decimal));
                result.Rows.Add(user == 1 ? 10 : 20, "Tiền mặt", 10000m);
                return result;
            }
            if (sql.Contains("FROM ThuNhap t JOIN LoaiThu l"))
            {
                if (!sql.Contains("t.MaND=l.MaND")) throw new Exception("Missing category ownership join.");
                var result = Income.Clone();
                result.Columns.Add("Loai", typeof(string));
                object from = Param(args, "@Tu"), to = Param(args, "@Den"), category = Param(args, "@Loai");
                foreach (var row in Income.AsEnumerable().Where(r => (int)r["MaND"] == user))
                {
                    var cat = Categories.AsEnumerable().Single(r => (int)r["MaLoaiThu"] == (int)row["MaLoaiThu"]);
                    var date = (DateTime)row["Ngay"];
                    if ((int)cat["MaND"] != user || (from != DBNull.Value && date < (DateTime)from) ||
                        (to != DBNull.Value && date >= (DateTime)to) ||
                        (category != DBNull.Value && (string)cat["TenLoaiThu"] != (string)category)) continue;
                    result.Rows.Add(row.ItemArray.Concat(new object[] { cat["TenLoaiThu"] }).ToArray());
                }
                return result;
            }
            throw new Exception("Unexpected query: " + sql);
        }
    }
}

internal static class ThuNhapRegression
{
    private static int assertions;
    private static T Field<T>(Form form, string name)
    {
        return (T)form.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic).GetValue(form);
    }
    private static void Check(bool success, string description)
    {
        if (!success) throw new Exception(description);
        assertions++;
        Console.WriteLine("PASS " + description);
    }
    private static DataRow Category(int id)
    {
        return DuLieu.KetNoiCSDL.Categories.AsEnumerable().Single(r => (int)r["MaLoaiThu"] == id);
    }
    private static int SummaryRow(TableLayoutPanel table, string category)
    {
        return table.Controls.Cast<Control>().Where(c => table.GetColumn(c) == 0 && c.Text == category)
            .Select(c => table.GetRow(c)).DefaultIfEmpty(-1).Single();
    }

    [STAThread]
    public static int Main(string[] args)
    {
        try
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("vi-VN");
            Application.EnableVisualStyles();
            PhienDangNhap.ThietLapPhien(new NguoiDungMH { MaND = 1, HoTen = "Test" });
            using (var form = new frmQuanLyThuNhap())
            {
                form.Show();
                form.DongBoThang(new DateTime(2026, 6, 1));
                Application.DoEvents();
                var edit = Field<ComboBox>(form, "cboLoaiThu");
                var filter = Field<ComboBox>(form, "cboLocLoaiThu");
                var grid = Field<DataGridView>(form, "dgvThuNhap");
                var summary = Field<TableLayoutPanel>(form, "tableLayoutPanel1");
                Check(edit.Items.Count == 4 && edit.Items.Contains("Kinh doanh"), "Editor reads active SQL categories, including custom names");
                Check(!edit.Items.Contains("Loại cũ") && !edit.Items.Contains("Loại người khác"), "Editor excludes inactive and other-user categories");
                Check(filter.Items.Contains("Loại cũ") && !filter.Items.Contains("Ngừng chưa dùng"), "Filter retains historical categories without unused inactive ones");
                Check(grid.Rows.Count == 5 && Field<Label>(form, "lblTongThu").Text == "1.500 đ", "Monthly income includes the last day and excludes other users/months");
                Check(summary.RowCount == 5 && SummaryRow(summary, "Quà tặng") >= 0, "Summary includes every actual income category beyond three fixed names");
                int giftRow = SummaryRow(summary, "Quà tặng");
                Check(summary.GetControlFromPosition(1, giftRow).Text == "400 đ" &&
                    summary.GetControlFromPosition(2, giftRow).Text == "26,7%", "Custom category amount and percentage use monthly income");
                Check(summary.VerticalScroll.Visible, "Category summary can scroll when there are more than three rows");
                Check(!summary.HorizontalScroll.Visible, "Category summary fits its width without horizontal scrolling");

                edit.SelectedItem = "Kinh doanh";
                filter.SelectedItem = "Loại cũ";
                form.LoadData();
                Check((string)edit.SelectedItem == "Kinh doanh" && (string)filter.SelectedItem == "Loại cũ", "Refresh preserves valid editor and filter choices");
                Check(grid.Rows.Count == 1 && (string)grid.Rows[0].Tag == "105", "Historical category filter finds its original income");
                Check(summary.GetControlFromPosition(1, giftRow).Text == "400 đ", "Category filtering does not change the whole-month summary");

                int oldIndex = 0;
                form.GetType().GetMethod("dgvThuNhap_CellClick", BindingFlags.Instance | BindingFlags.NonPublic)
                    .Invoke(form, new object[] { grid, new DataGridViewCellEventArgs(0, oldIndex) });
                Check(edit.SelectedIndex == -1, "Selecting inactive income never silently chooses a different category");

                DuLieu.KetNoiCSDL.Categories.Rows.Add(7, 1, "Bán hàng", true);
                form.DongBoThang(new DateTime(2026, 6, 1));
                Check(edit.Items.Contains("Bán hàng") && filter.Items.Contains("Bán hàng"), "Toolbar refresh loads newly added categories into both lists");
                Category(2)["TenLoaiThu"] = "Kinh doanh mới";
                filter.SelectedItem = "Tất cả";
                form.LoadData();
                Check(edit.Items.Contains("Kinh doanh mới") && !edit.Items.Contains("Kinh doanh") &&
                    grid.Rows.Cast<DataGridViewRow>().Any(r => (string)r.Cells[1].Value == "Kinh doanh mới"),
                    "Renamed category is refreshed in selectors and income rows");
                edit.SelectedItem = "Kinh doanh mới";
                Category(2)["TrangThai"] = false;
                form.LoadData();
                Check(!edit.Items.Contains("Kinh doanh mới") && edit.SelectedIndex == -1 && filter.Items.Contains("Kinh doanh mới"),
                    "Deactivation removes the editing choice while keeping historical filtering");
                Category(2)["TrangThai"] = true;
                form.LoadData();
                Check(edit.Items.Contains("Kinh doanh mới"), "Reactivated category returns after refresh");

                // Capture the populated layout for visual review; no application files are changed.
                using (var bitmap = new Bitmap(form.Width, form.Height))
                {
                    form.DrawToBitmap(bitmap, new Rectangle(Point.Empty, form.Size));
                    bitmap.Save(Path.Combine(args[0], "income-categories.png"));
                }
                form.DongBoThang(new DateTime(2090, 1, 1));
                Check(grid.Rows.Count == 0 && summary.Controls.Cast<Control>().Where(c => summary.GetColumn(c) > 0)
                    .All(c => c.Text == "0 đ" || c.Text == "0,0%"), "Empty month has no stale amounts or invalid percentages");

                PhienDangNhap.ThietLapPhien(new NguoiDungMH { MaND = 2, HoTen = "Other" });
                form.DongBoThang(new DateTime(2026, 6, 1));
                Check(edit.Items.Count == 1 && edit.Items.Contains("Loại người khác") &&
                    grid.Rows.Count == 1 && summary.RowCount == 1, "Reload scopes selectors, income and summary to the current user");
                DuLieu.KetNoiCSDL.Categories.Rows.Clear();
                DuLieu.KetNoiCSDL.Income.Rows.Clear();
                form.LoadData();
                Check(edit.Items.Count == 0 && edit.SelectedIndex == -1 && filter.Items.Count == 1 &&
                    summary.Controls.Count == 1, "Empty categories show an empty editor and summary without sample values");
                form.Close();
            }
            PhienDangNhap.XoaPhien();
            bool rejected = false;
            try { var categories = DataService.DanhSachLoaiThuBoLoc; }
            catch (InvalidOperationException) { rejected = true; }
            Check(rejected, "Category filter queries require a logged-in user");
            Console.WriteLine(assertions + " income regression checks passed.");
            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
            return 1;
        }
    }
}
