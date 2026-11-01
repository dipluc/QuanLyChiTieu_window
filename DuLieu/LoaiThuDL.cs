using System;
using System.Data;
using System.Data.SqlClient;
using MoHinh;

namespace DuLieu
{
    public static class LoaiThuDL
    {
        public static DataTable LayDanhSach(int maND)
        {
            string sql = @"SELECT MaLoaiThu, TenLoaiThu, GhiChu, TrangThai
                           FROM LoaiThu WHERE MaND = @MaND ORDER BY MaLoaiThu ASC";
            return KetNoiCSDL.DocDuLieu(sql, new SqlParameter("@MaND", maND));
        }

        public static LoaiThuMH LayTheoMa(int maLoaiThu, int maND)
        {
            string sql = @"SELECT MaLoaiThu, MaND, TenLoaiThu, GhiChu, TrangThai
                           FROM LoaiThu WHERE MaLoaiThu = @Ma AND MaND = @MaND";
            DataTable dt = KetNoiCSDL.DocDuLieu(sql,
                new SqlParameter("@Ma", maLoaiThu),
                new SqlParameter("@MaND", maND));
            if (dt.Rows.Count == 0) return null;
            DataRow r = dt.Rows[0];
            return new LoaiThuMH
            {
                MaLoaiThu = Convert.ToInt32(r["MaLoaiThu"]),
                MaND = Convert.ToInt32(r["MaND"]),
                TenLoaiThu = r["TenLoaiThu"].ToString(),
                GhiChu = r["GhiChu"] != DBNull.Value ? r["GhiChu"].ToString() : null,
                TrangThai = Convert.ToBoolean(r["TrangThai"])
            };
        }

        // loaiTruMa = 0 khi thêm mới
        public static bool KiemTraTonTaiTen(int maND, string ten, int loaiTruMa = 0)
        {
            string sql = "SELECT COUNT(1) FROM LoaiThu WHERE MaND = @MaND AND TenLoaiThu = @Ten AND MaLoaiThu <> @Ma";
            object res = KetNoiCSDL.LayMotGiaTri(sql,
                new SqlParameter("@MaND", maND),
                new SqlParameter("@Ten", ten),
                new SqlParameter("@Ma", loaiTruMa));
            return res != null && Convert.ToInt32(res) > 0;
        }

        public static int Them(LoaiThuMH lt)
        {
            string sql = @"INSERT INTO LoaiThu (MaND, TenLoaiThu, GhiChu, TrangThai)
                           VALUES (@MaND, @Ten, @GhiChu, @TrangThai);
                           SELECT SCOPE_IDENTITY();";
            object id = KetNoiCSDL.LayMotGiaTri(sql,
                new SqlParameter("@MaND", lt.MaND),
                new SqlParameter("@Ten", lt.TenLoaiThu),
                new SqlParameter("@GhiChu", (object)lt.GhiChu ?? DBNull.Value),
                new SqlParameter("@TrangThai", lt.TrangThai));
            return (id != null && id != DBNull.Value) ? Convert.ToInt32(id) : 0;
        }

        public static bool CapNhat(LoaiThuMH lt)
        {
            string sql = @"UPDATE LoaiThu SET TenLoaiThu = @Ten, GhiChu = @GhiChu, TrangThai = @TrangThai
                           WHERE MaLoaiThu = @Ma AND MaND = @MaND";
            int rows = KetNoiCSDL.ThucThiLenh(sql,
                new SqlParameter("@Ten", lt.TenLoaiThu),
                new SqlParameter("@GhiChu", (object)lt.GhiChu ?? DBNull.Value),
                new SqlParameter("@TrangThai", lt.TrangThai),
                new SqlParameter("@Ma", lt.MaLoaiThu),
                new SqlParameter("@MaND", lt.MaND));
            return rows > 0;
        }

        // Số bản ghi đang dùng loại thu này (thu nhập, giao dịch định kỳ)
        public static int DemBanGhiLienQuan(int maLoaiThu)
        {
            string sql = @"SELECT (SELECT COUNT(1) FROM ThuNhap WHERE MaLoaiThu = @Ma)
                                + (SELECT COUNT(1) FROM GiaoDichDinhKy WHERE MaLoaiThu = @Ma)";
            object res = KetNoiCSDL.LayMotGiaTri(sql, new SqlParameter("@Ma", maLoaiThu));
            return (res != null && res != DBNull.Value) ? Convert.ToInt32(res) : 0;
        }

        public static bool Xoa(int maLoaiThu, int maND)
        {
            string sql = "DELETE FROM LoaiThu WHERE MaLoaiThu = @Ma AND MaND = @MaND";
            int rows = KetNoiCSDL.ThucThiLenh(sql,
                new SqlParameter("@Ma", maLoaiThu),
                new SqlParameter("@MaND", maND));
            return rows > 0;
        }
    }
}
