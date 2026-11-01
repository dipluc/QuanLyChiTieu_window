using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MoHinh;

namespace DuLieu
{
    public static class GiaoDichDinhKyDL
    {
        private const string SqlChon =
            @"SELECT g.MaGDDK, g.MaND, g.LoaiGiaoDich, g.MaVi, g.MaLoaiThu, g.MaLoaiChi, g.SoTien, g.TanSuat,
                     g.NgayBatDau, g.NgayKetThuc, g.NgayDenHanTiepTheo, g.GhiChu, g.TrangThai,
                     v.TenVi,
                     COALESCE(lt.TenLoaiThu, lc.TenLoaiChi) AS TenDanhMuc
              FROM GiaoDichDinhKy g
              INNER JOIN ViTien v ON g.MaVi = v.MaVi
              LEFT JOIN LoaiThu lt ON g.MaLoaiThu = lt.MaLoaiThu
              LEFT JOIN LoaiChi lc ON g.MaLoaiChi = lc.MaLoaiChi ";

        public static List<GiaoDichDinhKyMH> LayDanhSach(int maND)
        {
            string sql = SqlChon + "WHERE g.MaND = @MaND ORDER BY g.NgayDenHanTiepTheo ASC, g.MaGDDK ASC";
            DataTable dt = KetNoiCSDL.DocDuLieu(sql, new SqlParameter("@MaND", maND));
            var ds = new List<GiaoDichDinhKyMH>();
            foreach (DataRow r in dt.Rows)
            {
                ds.Add(ChuyenDoiDongThanhMH(r));
            }
            return ds;
        }

        public static GiaoDichDinhKyMH LayTheoMa(int maGDDK, int maND)
        {
            string sql = SqlChon + "WHERE g.MaGDDK = @MaGDDK AND g.MaND = @MaND";
            DataTable dt = KetNoiCSDL.DocDuLieu(sql,
                new SqlParameter("@MaGDDK", maGDDK),
                new SqlParameter("@MaND", maND));
            return dt.Rows.Count > 0 ? ChuyenDoiDongThanhMH(dt.Rows[0]) : null;
        }

        // Danh sách ví đang hoạt động của người dùng (nạp ComboBox)
        public static DataTable LayDanhSachVi(int maND)
        {
            string sql = "SELECT MaVi, TenVi FROM ViTien WHERE MaND = @MaND AND TrangThai = 1 ORDER BY TenVi";
            return KetNoiCSDL.DocDuLieu(sql, new SqlParameter("@MaND", maND));
        }

        // Danh mục thu nhập đang hoạt động (cột Ma, Ten)
        public static DataTable LayDanhMucThu(int maND)
        {
            string sql = "SELECT MaLoaiThu AS Ma, TenLoaiThu AS Ten FROM LoaiThu WHERE MaND = @MaND AND TrangThai = 1 ORDER BY TenLoaiThu";
            return KetNoiCSDL.DocDuLieu(sql, new SqlParameter("@MaND", maND));
        }

        // Danh mục chi tiêu đang hoạt động (cột Ma, Ten)
        public static DataTable LayDanhMucChi(int maND)
        {
            string sql = "SELECT MaLoaiChi AS Ma, TenLoaiChi AS Ten FROM LoaiChi WHERE MaND = @MaND AND TrangThai = 1 ORDER BY TenLoaiChi";
            return KetNoiCSDL.DocDuLieu(sql, new SqlParameter("@MaND", maND));
        }

        // Kiểm tra ví có thuộc người dùng không (tránh dùng ví của người khác)
        public static bool ViThuocNguoiDung(int maVi, int maND)
        {
            string sql = "SELECT COUNT(1) FROM ViTien WHERE MaVi = @MaVi AND MaND = @MaND";
            object res = KetNoiCSDL.LayMotGiaTri(sql,
                new SqlParameter("@MaVi", maVi),
                new SqlParameter("@MaND", maND));
            return res != null && Convert.ToInt32(res) > 0;
        }

        public static int Them(GiaoDichDinhKyMH gd)
        {
            string sql = @"INSERT INTO GiaoDichDinhKy
                               (MaND, LoaiGiaoDich, MaVi, MaLoaiThu, MaLoaiChi, SoTien, TanSuat,
                                NgayBatDau, NgayKetThuc, NgayDenHanTiepTheo, GhiChu, TrangThai)
                           VALUES
                               (@MaND, @LoaiGiaoDich, @MaVi, @MaLoaiThu, @MaLoaiChi, @SoTien, @TanSuat,
                                @NgayBatDau, @NgayKetThuc, @NgayDenHanTiepTheo, @GhiChu, @TrangThai);
                           SELECT SCOPE_IDENTITY();";
            object id = KetNoiCSDL.LayMotGiaTri(sql, TaoThamSo(gd));
            return (id != null && id != DBNull.Value) ? Convert.ToInt32(id) : 0;
        }

        public static bool Sua(GiaoDichDinhKyMH gd)
        {
            string sql = @"UPDATE GiaoDichDinhKy
                           SET LoaiGiaoDich = @LoaiGiaoDich, MaVi = @MaVi, MaLoaiThu = @MaLoaiThu, MaLoaiChi = @MaLoaiChi,
                               SoTien = @SoTien, TanSuat = @TanSuat, NgayBatDau = @NgayBatDau, NgayKetThuc = @NgayKetThuc,
                               NgayDenHanTiepTheo = @NgayDenHanTiepTheo, GhiChu = @GhiChu, TrangThai = @TrangThai
                           WHERE MaGDDK = @MaGDDK AND MaND = @MaND";
            var ps = new List<SqlParameter>(TaoThamSo(gd));
            ps.Add(new SqlParameter("@MaGDDK", gd.MaGDDK));
            return KetNoiCSDL.ThucThiLenh(sql, ps.ToArray()) > 0;
        }

        public static bool Xoa(int maGDDK, int maND)
        {
            string sql = "DELETE FROM GiaoDichDinhKy WHERE MaGDDK = @MaGDDK AND MaND = @MaND";
            return KetNoiCSDL.ThucThiLenh(sql,
                new SqlParameter("@MaGDDK", maGDDK),
                new SqlParameter("@MaND", maND)) > 0;
        }

        private static SqlParameter[] TaoThamSo(GiaoDichDinhKyMH gd)
        {
            return new[]
            {
                new SqlParameter("@MaND", gd.MaND),
                new SqlParameter("@LoaiGiaoDich", gd.LoaiGiaoDich),
                new SqlParameter("@MaVi", gd.MaVi),
                new SqlParameter("@MaLoaiThu", (object)gd.MaLoaiThu ?? DBNull.Value),
                new SqlParameter("@MaLoaiChi", (object)gd.MaLoaiChi ?? DBNull.Value),
                new SqlParameter("@SoTien", gd.SoTien),
                new SqlParameter("@TanSuat", gd.TanSuat),
                new SqlParameter("@NgayBatDau", gd.NgayBatDau),
                new SqlParameter("@NgayKetThuc", (object)gd.NgayKetThuc ?? DBNull.Value),
                new SqlParameter("@NgayDenHanTiepTheo", gd.NgayDenHanTiepTheo),
                new SqlParameter("@GhiChu", (object)gd.GhiChu ?? DBNull.Value),
                new SqlParameter("@TrangThai", gd.TrangThai)
            };
        }

        private static GiaoDichDinhKyMH ChuyenDoiDongThanhMH(DataRow r)
        {
            return new GiaoDichDinhKyMH
            {
                MaGDDK = Convert.ToInt32(r["MaGDDK"]),
                MaND = Convert.ToInt32(r["MaND"]),
                LoaiGiaoDich = r["LoaiGiaoDich"].ToString(),
                MaVi = Convert.ToInt32(r["MaVi"]),
                MaLoaiThu = r["MaLoaiThu"] != DBNull.Value ? (int?)Convert.ToInt32(r["MaLoaiThu"]) : null,
                MaLoaiChi = r["MaLoaiChi"] != DBNull.Value ? (int?)Convert.ToInt32(r["MaLoaiChi"]) : null,
                SoTien = Convert.ToDecimal(r["SoTien"]),
                TanSuat = r["TanSuat"].ToString(),
                NgayBatDau = Convert.ToDateTime(r["NgayBatDau"]),
                NgayKetThuc = r["NgayKetThuc"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(r["NgayKetThuc"]) : null,
                NgayDenHanTiepTheo = Convert.ToDateTime(r["NgayDenHanTiepTheo"]),
                GhiChu = r["GhiChu"] != DBNull.Value ? r["GhiChu"].ToString() : null,
                TrangThai = Convert.ToBoolean(r["TrangThai"]),
                TenVi = r["TenVi"].ToString(),
                TenDanhMuc = r["TenDanhMuc"] != DBNull.Value ? r["TenDanhMuc"].ToString() : string.Empty
            };
        }
    }
}
