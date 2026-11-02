using System;
using System.Data;
using System.Data.SqlClient;
using MoHinh;

namespace DuLieu
{
    public static class LoaiChiDL
    {
        // Danh sách loại chi của người dùng (kèm tên nhóm chi để hiển thị)
        public static DataTable LayDanhSach(int maND)
        {
            string sql = @"SELECT lc.MaLoaiChi, lc.MaNhom, nc.TenNhom, lc.TenLoaiChi, lc.GhiChu, lc.TrangThai
                           FROM LoaiChi lc
                           INNER JOIN NhomChi nc ON lc.MaNhom = nc.MaNhom
                           WHERE lc.MaND = @MaND
                           ORDER BY nc.TenNhom ASC, lc.TenLoaiChi ASC";
            return KetNoiCSDL.DocDuLieu(sql, new SqlParameter("@MaND", maND));
        }

        // Danh sách nhóm chi để nạp ComboBox (nhóm đang dùng + nhóm đang được loại chi tham chiếu)
        public static DataTable LayDanhSachNhomChi(int maND)
        {
            string sql = @"SELECT MaNhom, TenNhom, GhiChu, TrangThai
                           FROM NhomChi
                           WHERE MaND = @MaND
                             AND (TrangThai = 1 OR MaNhom IN (SELECT MaNhom FROM LoaiChi WHERE MaND = @MaND))
                           ORDER BY TenNhom ASC";
            return KetNoiCSDL.DocDuLieu(sql, new SqlParameter("@MaND", maND));
        }

        // ==========================================
        // THÊM / SỬA NHÓM CHI (BỔ SUNG)
        // ==========================================
        public static int ThemNhomChi(int maND, string tenNhom, string ghiChu, bool trangThai)
        {
            string sql = @"INSERT INTO NhomChi (MaND, TenNhom, GhiChu, TrangThai)
                           VALUES (@MaND, @TenNhom, @GhiChu, @TrangThai);
                           SELECT SCOPE_IDENTITY();";
            object id = KetNoiCSDL.LayMotGiaTri(sql,
                new SqlParameter("@MaND", maND),
                new SqlParameter("@TenNhom", tenNhom),
                new SqlParameter("@GhiChu", (object)ghiChu ?? DBNull.Value),
                new SqlParameter("@TrangThai", trangThai));
            return (id != null && id != DBNull.Value) ? Convert.ToInt32(id) : 0;
        }

        public static bool SuaNhomChi(int maNhom, int maND, string tenNhom, string ghiChu, bool trangThai)
        {
            string sql = @"UPDATE NhomChi
                           SET TenNhom = @TenNhom, GhiChu = @GhiChu, TrangThai = @TrangThai
                           WHERE MaNhom = @MaNhom AND MaND = @MaND";
            int rows = KetNoiCSDL.ThucThiLenh(sql,
                new SqlParameter("@TenNhom", tenNhom),
                new SqlParameter("@GhiChu", (object)ghiChu ?? DBNull.Value),
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@MaNhom", maNhom),
                new SqlParameter("@MaND", maND));
            return rows > 0;
        }

        // Kiểm tra trùng tên loại chi trong cùng người dùng (loại trừ chính bản ghi đang sửa)
        public static bool KiemTraTonTaiTen(int maND, string tenLoaiChi, int excludeMaLoaiChi = 0)
        {
            string sql = "SELECT COUNT(1) FROM LoaiChi WHERE MaND = @MaND AND TenLoaiChi = @TenLoaiChi AND MaLoaiChi <> @MaLoaiChi";
            object res = KetNoiCSDL.LayMotGiaTri(sql,
                new SqlParameter("@MaND", maND),
                new SqlParameter("@TenLoaiChi", tenLoaiChi),
                new SqlParameter("@MaLoaiChi", excludeMaLoaiChi));
            return res != null && Convert.ToInt32(res) > 0;
        }

        public static int ThemLoaiChi(LoaiChiMH lc)
        {
            string sql = @"INSERT INTO LoaiChi (MaNhom, MaND, TenLoaiChi, GhiChu, TrangThai)
                           VALUES (@MaNhom, @MaND, @TenLoaiChi, @GhiChu, @TrangThai);
                           SELECT SCOPE_IDENTITY();";
            object id = KetNoiCSDL.LayMotGiaTri(sql,
                new SqlParameter("@MaNhom", lc.MaNhom),
                new SqlParameter("@MaND", lc.MaND),
                new SqlParameter("@TenLoaiChi", lc.TenLoaiChi),
                new SqlParameter("@GhiChu", (object)lc.GhiChu ?? DBNull.Value),
                new SqlParameter("@TrangThai", lc.TrangThai));
            return (id != null && id != DBNull.Value) ? Convert.ToInt32(id) : 0;
        }

        public static bool CapNhatLoaiChi(LoaiChiMH lc)
        {
            string sql = @"UPDATE LoaiChi
                           SET MaNhom = @MaNhom, TenLoaiChi = @TenLoaiChi, GhiChu = @GhiChu, TrangThai = @TrangThai
                           WHERE MaLoaiChi = @MaLoaiChi AND MaND = @MaND";
            int rows = KetNoiCSDL.ThucThiLenh(sql,
                new SqlParameter("@MaNhom", lc.MaNhom),
                new SqlParameter("@TenLoaiChi", lc.TenLoaiChi),
                new SqlParameter("@GhiChu", (object)lc.GhiChu ?? DBNull.Value),
                new SqlParameter("@TrangThai", lc.TrangThai),
                new SqlParameter("@MaLoaiChi", lc.MaLoaiChi),
                new SqlParameter("@MaND", lc.MaND));
            return rows > 0;
        }

        // Có thể ném SqlException (số 547) nếu loại chi đang được ChiTieu / NganSach / GiaoDichDinhKy tham chiếu
        public static bool XoaLoaiChi(int maLoaiChi, int maND)
        {
            string sql = "DELETE FROM LoaiChi WHERE MaLoaiChi = @MaLoaiChi AND MaND = @MaND";
            int rows = KetNoiCSDL.ThucThiLenh(sql,
                new SqlParameter("@MaLoaiChi", maLoaiChi),
                new SqlParameter("@MaND", maND));
            return rows > 0;
        }

        public static bool DatTrangThai(int maLoaiChi, int maND, bool trangThai)
        {
            string sql = "UPDATE LoaiChi SET TrangThai = @TrangThai WHERE MaLoaiChi = @MaLoaiChi AND MaND = @MaND";
            int rows = KetNoiCSDL.ThucThiLenh(sql,
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@MaLoaiChi", maLoaiChi),
                new SqlParameter("@MaND", maND));
            return rows > 0;
        }
    }
}