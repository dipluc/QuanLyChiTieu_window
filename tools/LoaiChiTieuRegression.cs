using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using LTWIN_N05_QLCT.Forms.DanhMuc;
using MoHinh;
using NghiepVu.TienIch;

// Compile the production form, business layer and LoaiChiDL with this adapter.
// Its group schema deliberately has no GhiChu column, matching NhomChi in the project.
namespace DuLieu
{
    public static class KetNoiCSDL
    {
        public static readonly DataTable Groups = new DataTable();
        public static readonly DataTable Categories = new DataTable();
        public static bool FailCategories;
        public static int Writes;

        static KetNoiCSDL()
        {
            Groups.Columns.Add("MaNhom", typeof(int));
            Groups.Columns.Add("MaND", typeof(int));
            Groups.Columns.Add("TenNhom", typeof(string));
            Groups.Columns.Add("TrangThai", typeof(bool));
            Groups.Rows.Add(10, 1, "Ăn uống", true);
            Groups.Rows.Add(20, 1, "Đi lại", true);
            Groups.Rows.Add(30, 1, "Y tế", true);
            Groups.Rows.Add(40, 1, "Nhóm ngừng", false);
            Groups.Rows.Add(99, 2, "Nhóm người khác", true);
            Categories.Columns.Add("MaLoaiChi", typeof(int));
            Categories.Columns.Add("MaNhom", typeof(int));
            Categories.Columns.Add("MaND", typeof(int));
            Categories.Columns.Add("TenLoaiChi", typeof(string));
            Categories.Columns.Add("GhiChu", typeof(string));
            Categories.Columns.Add("TrangThai", typeof(bool));
            Categories.Rows.Add(101, 10, 1, "Ăn sáng", DBNull.Value, true);
            Categories.Rows.Add(102, 10, 1, "Cà phê", "Đã ngừng", false);
            Categories.Rows.Add(201, 20, 1, "Xăng xe", "", true);
            Categories.Rows.Add(901, 99, 2, "Loại người khác", "", true);
        }

        private static object Param(SqlParameter[] parameters, string name)
        {
            return parameters.Single(p => p.ParameterName == name).Value;
        }

        private static bool Owned(DataRow row, SqlParameter[] parameters)
        {
            return (int)row["MaND"] == (int)Param(parameters, "@MaND");
        }

        private static void ValidateGroupSql(string sql)
        {
            if (sql.Contains("GhiChu")) throw new InvalidOperationException("Invalid column name 'GhiChu'.");
        }

        public static DataTable DocDuLieu(string sql, params SqlParameter[] parameters)
        {
            if (!sql.Contains("FROM LoaiChi lc"))
            {
                ValidateGroupSql(sql);
                var result = Groups.Clone();
                foreach (var row in Groups.AsEnumerable().Where(r => Owned(r, parameters))) result.ImportRow(row);
                result.Columns.Remove("MaND");
                return result.DefaultView.ToTable();
            }
            if (FailCategories) throw new InvalidOperationException("Simulated category query failure");
            var categories = Categories.Clone();
            categories.Columns.Add("TenNhom", typeof(string));
            foreach (var row in Categories.AsEnumerable().Where(r => Owned(r, parameters)))
            {
                var values = row.ItemArray.Concat(new object[] {
                    Groups.AsEnumerable().Single(g => (int)g["MaNhom"] == (int)row["MaNhom"])["TenNhom"]
                }).ToArray();
                categories.Rows.Add(values);
            }
            categories.Columns.Remove("MaND");
            return categories;
        }

        public static object LayMotGiaTri(string sql, params SqlParameter[] parameters)
        {
            if (sql.StartsWith("SELECT COUNT"))
                return Categories.AsEnumerable().Count(r => Owned(r, parameters) &&
                    (string)r["TenLoaiChi"] == (string)Param(parameters, "@TenLoaiChi") &&
                    (int)r["MaLoaiChi"] != (int)Param(parameters, "@MaLoaiChi"));
            Writes++;
            if (sql.Contains("INSERT INTO NhomChi"))
            {
                ValidateGroupSql(sql);
                int id = Groups.AsEnumerable().Max(r => (int)r["MaNhom"]) + 1;
                Groups.Rows.Add(id, Param(parameters, "@MaND"), Param(parameters, "@TenNhom"), Param(parameters, "@TrangThai"));
                return id;
            }
            int categoryId = Categories.AsEnumerable().Max(r => (int)r["MaLoaiChi"]) + 1;
            Categories.Rows.Add(categoryId, Param(parameters, "@MaNhom"), Param(parameters, "@MaND"),
                Param(parameters, "@TenLoaiChi"), Param(parameters, "@GhiChu"), Param(parameters, "@TrangThai"));
            return categoryId;
        }

        public static int ThucThiLenh(string sql, params SqlParameter[] parameters)
        {
            Writes++;
            bool group = sql.Contains("UPDATE NhomChi");
            if (group) ValidateGroupSql(sql);
            string key = group ? "MaNhom" : "MaLoaiChi";
            var row = (group ? Groups : Categories).AsEnumerable().SingleOrDefault(r =>
                Owned(r, parameters) && (int)r[key] == (int)Param(parameters, "@" + key));
            if (row == null) return 0;
            row["TrangThai"] = Param(parameters, "@TrangThai");
            if (group) row["TenNhom"] = Param(parameters, "@TenNhom");
            else if (sql.Contains("SET MaNhom"))
            {
                row["MaNhom"] = Param(parameters, "@MaNhom");
                row["TenLoaiChi"] = Param(parameters, "@TenLoaiChi");
                row["GhiChu"] = Param(parameters, "@GhiChu");
            }
            return 1;
        }
    }
}

namespace NghiepVu.TienIch
{
    public static class NhatKyLoi
    {
        public static void GhiLog(string message) { }
        public static void GhiLog(string message, Exception error) { }
    }
}

internal static class LoaiChiTieuRegression
{
    private static int assertions;
    private static T Field<T>(Form form, string name)
    {
        return (T)form.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic).GetValue(form);
    }
    private static void Check(bool success, string description)
    {
        if (!success) throw new InvalidOperationException(description);
        assertions++;
        Console.WriteLine("PASS " + description);
    }
    private static void Click(Form form, string name) { Field<Button>(form, name).PerformClick(); Application.DoEvents(); }
    private static void Select(Form form, string grid, string key, int id)
    {
        var table = Field<DataGridView>(form, grid);
        var row = table.Rows.Cast<DataGridViewRow>().Single(r => (int)((DataRowView)r.DataBoundItem)[key] == id);
        table.CurrentCell = row.Cells.Cast<DataGridViewCell>().First(c => c.Visible);
        row.Selected = true;
        Application.DoEvents();
    }
    private static void SelectGroup(Form form, int id) { Select(form, "dgvNhomChi", "MaNhom", id); }
    private static int Id(Form form, string name) { return Field<int>(form, name); }

    [STAThread]
    public static int Main(string[] args)
    {
        try
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PhienDangNhap.ThietLapPhien(new NguoiDungMH { MaND = 1, TenDangNhap = "regression", HoTen = "Kiểm thử" });
            using (var form = new frmLoaiChiTieu())
            {
                form.StartPosition = FormStartPosition.Manual;
                form.Location = new Point(-2000, -2000);
                form.Show();
                Application.DoEvents();
                Check(Field<DataGridView>(form, "dgvNhomChi").Rows.Count == 4, "Load event loads only current user's groups, including inactive empty groups");
                Check(Id(form, "_maNhomDangChon") == 10 && Field<DataGridView>(form, "dgvLoaiChi").Rows.Count == 2, "Food group loads all its categories on opening");
                Check(Field<TextBox>(form, "txtTenLoaiChi").Text == "Ăn sáng", "First category fills the editor");
                SelectGroup(form, 20);
                Check(Id(form, "_maLoaiDangChon") == 201 && Field<ComboBox>(form, "cboNhomChiKhoa").Text == "Đi lại", "Changing group synchronizes list and locked group field");
                SelectGroup(form, 30);
                Check(Id(form, "_maLoaiDangChon") == 0 && Field<TextBox>(form, "txtTenLoaiChi").Text == "", "Empty group clears stale category identity and fields");
                Check(!Field<Button>(form, "btnSuaLoai").Enabled && !Field<Button>(form, "btnNgungSuDungLoai").Enabled, "Empty group cannot edit or disable a category from the previous group");

                SelectGroup(form, 40);
                Check(!Field<Button>(form, "btnMoiLoai").Enabled, "Stopped group disables category creation");
                Click(form, "btnNgungSuDungNhom");
                Check(Id(form, "_maNhomDangChon") == 40 && Field<Button>(form, "btnMoiLoai").Enabled, "Empty inactive group can be restored without losing selection");
                Click(form, "btnNgungSuDungNhom");
                Field<TextBox>(form, "txtTenNhomChi").Text = "Nhóm ngừng đã sửa";
                Click(form, "btnSuaNhom");
                Check(!(bool)DuLieu.KetNoiCSDL.Groups.Select("MaNhom = 40")[0]["TrangThai"], "Renaming inactive group preserves its inactive state");

                Click(form, "btnMoiNhom");
                Check(Id(form, "_maNhomDangChon") == 0 && Id(form, "_maLoaiDangChon") == 0 && !Field<Button>(form, "btnThemLoai").Enabled, "New group mode clears context until the group is saved");
                int writes = DuLieu.KetNoiCSDL.Writes;
                Click(form, "btnThemNhom");
                Check(DuLieu.KetNoiCSDL.Writes == writes && Field<Label>(form, "lblThongBao").Visible, "Blank group name is rejected before storage");
                Field<TextBox>(form, "txtTenNhomChi").Text = "  Du lịch  ";
                Click(form, "btnThemNhom");
                int newGroup = Id(form, "_maNhomDangChon");
                Check(newGroup == 100 && Field<TextBox>(form, "txtTenNhomChi").Text == "Du lịch", "New group saves without GhiChu and is selected after refresh");
                Click(form, "btnMoiLoai");
                Field<TextBox>(form, "txtTenLoaiChi").Text = "Vé xe";
                Click(form, "btnThemLoai");
                int newCategory = Id(form, "_maLoaiDangChon");
                Check(newCategory == 902 && Id(form, "_maNhomDangChon") == newGroup, "New category saves in the selected group and stays selected");
                Check(DuLieu.KetNoiCSDL.Categories.Select("MaLoaiChi = 902")[0].IsNull("GhiChu"), "Category notes are optional");
                Field<TextBox>(form, "txtTenLoaiChi").Text = "Vé tàu";
                Field<TextBox>(form, "txtGhiChuLoai").Text = "Đi về quê";
                Click(form, "btnSuaLoai");
                Check(Id(form, "_maNhomDangChon") == newGroup && Id(form, "_maLoaiDangChon") == newCategory &&
                    (string)DuLieu.KetNoiCSDL.Categories.Select("MaLoaiChi = 902")[0]["GhiChu"] == "Đi về quê", "Editing category preserves selection and saves notes");

                SelectGroup(form, 10);
                Select(form, "dgvLoaiChi", "MaLoaiChi", 102);
                Field<TextBox>(form, "txtGhiChuLoai").Text = "Ghi chú mới";
                Click(form, "btnSuaLoai");
                Check(!(bool)DuLieu.KetNoiCSDL.Categories.Select("MaLoaiChi = 102")[0]["TrangThai"], "Editing a stopped category does not reactivate it");
                Click(form, "btnNgungSuDungLoai");
                Check((bool)DuLieu.KetNoiCSDL.Categories.Select("MaLoaiChi = 102")[0]["TrangThai"], "Stopped category can be restored explicitly");

                DuLieu.KetNoiCSDL.FailCategories = true;
                SelectGroup(form, 20);
                Check(Id(form, "_maLoaiDangChon") == 0 && Field<DataGridView>(form, "dgvLoaiChi").DataSource == null &&
                    Field<Label>(form, "lblThongBao").Text.Contains("Simulated category query failure"), "Category query failure is visible and clears stale data");
                DuLieu.KetNoiCSDL.FailCategories = false;
                SelectGroup(form, 10);
                Check(Field<DataGridView>(form, "dgvLoaiChi").Rows.Count == 2, "Selecting another group recovers after a query failure");
                Check((string)DuLieu.KetNoiCSDL.Groups.Select("MaNhom = 99")[0]["TenNhom"] == "Nhóm người khác" &&
                    (string)DuLieu.KetNoiCSDL.Categories.Select("MaLoaiChi = 901")[0]["TenLoaiChi"] == "Loại người khác", "Other user's data remains untouched");
                form.Close();
            }
            PhienDangNhap.XoaPhien();
            using (var form = new frmLoaiChiTieu())
            {
                form.Location = new Point(-2000, -2000);
                form.Show();
                Application.DoEvents();
                Check(!Field<Button>(form, "btnMoiNhom").Enabled && !Field<Button>(form, "btnThemNhom").Enabled &&
                    Field<Label>(form, "lblThongBao").Text.Contains("Phiên đăng nhập"), "Expired session shows an error and disables writes");
                form.Close();
            }
            Console.WriteLine("PASS " + assertions + " regression checks; no LocalDB access.");
            if (args.Length == 0 || args.Contains("--preview"))
            {
                PhienDangNhap.ThietLapPhien(new NguoiDungMH { MaND = 1, TenDangNhap = "regression", HoTen = "Kiểm thử" });
                Application.Run(new frmLoaiChiTieu { StartPosition = FormStartPosition.CenterScreen });
            }
            return 0;
        }
        catch (Exception error) { Console.Error.WriteLine(error); return 1; }
    }
}
