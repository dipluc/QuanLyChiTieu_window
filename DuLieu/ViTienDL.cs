using System;
using System.Data;
using System.Data.SqlClient;
using MoHinh;

namespace DuLieu
{
    public static class ViTienDL
    {
        // Danh sách ví của một người dùng, kèm số dư hiện tại (view vw_SoDuVi)
        public static DataTable LayDanhSach(int maND)
        {
            string sql = @"SELECT MaVi, TenVi, LoaiVi, SoDuBanDau, SoDuHienTai, GhiChu, TrangThai
                           FROM vw_SoDuVi WHERE MaND = @MaND ORDER BY MaVi ASC";
            return KetNoiCSDL.DocDuLieu(sql, new SqlParameter("@MaND", maND));
        }

        public static ViTienMH LayTheoMaVi(int maVi, int maND)
        {
            string sql = @"SELECT MaVi, MaND, TenVi, LoaiVi, SoDuBanDau, SoDuHienTai, GhiChu, TrangThai
                           FROM vw_SoDuVi WHERE MaVi = @MaVi AND MaND = @MaND";
            DataTable dt = KetNoiCSDL.DocDuLieu(sql,
                new SqlParameter("@MaVi", maVi),
                new SqlParameter("@MaND", maND));
            if (dt.Rows.Count == 0) return null;
            return ChuyenDoiDongThanhMH(dt.Rows[0]);
        }

        // Kiểm tra trùng tên ví trong cùng một người dùng (loaiTruMaVi = 0 khi thêm mới)
        public static bool KiemTraTonTaiTenVi(int maND, string tenVi, int loaiTruMaVi = 0)
        {
            string sql = "SELECT COUNT(1) FROM ViTien WHERE MaND = @MaND AND TenVi = @TenVi AND MaVi <> @MaVi";
            object res = KetNoiCSDL.LayMotGiaTri(sql,
                new SqlParameter("@MaND", maND),
                new SqlParameter("@TenVi", tenVi),
                new SqlParameter("@MaVi", loaiTruMaVi));
            return res != null && Convert.ToInt32(res) > 0;
        }

        public static int ThemViTien(ViTienMH vi)
        {
            string sql = @"INSERT INTO ViTien (MaND, TenVi, LoaiVi, SoDuBanDau, GhiChu, TrangThai)
                           VALUES (@MaND, @TenVi, @LoaiVi, @SoDuBanDau, @GhiChu, @TrangThai);
                           SELECT SCOPE_IDENTITY();";
            object id = KetNoiCSDL.LayMotGiaTri(sql,
                new SqlParameter("@MaND", vi.MaND),
                new SqlParameter("@TenVi", vi.TenVi),
                new SqlParameter("@LoaiVi", vi.LoaiVi),
                new SqlParameter("@SoDuBanDau", vi.SoDuBanDau),
                new SqlParameter("@GhiChu", (object)vi.GhiChu ?? DBNull.Value),
                new SqlParameter("@TrangThai", vi.TrangThai));
            return (id != null && id != DBNull.Value) ? Convert.ToInt32(id) : 0;
        }

        public static bool CapNhat(ViTienMH vi)
        {
            string sql = @"UPDATE ViTien SET TenVi = @TenVi, LoaiVi = @LoaiVi, SoDuBanDau = @SoDuBanDau,
                                  GhiChu = @GhiChu, TrangThai = @TrangThai
                           WHERE MaVi = @MaVi AND MaND = @MaND";
            int rows = KetNoiCSDL.ThucThiLenh(sql,
                new SqlParameter("@TenVi", vi.TenVi),
                new SqlParameter("@LoaiVi", vi.LoaiVi),
                new SqlParameter("@SoDuBanDau", vi.SoDuBanDau),
                new SqlParameter("@GhiChu", (object)vi.GhiChu ?? DBNull.Value),
                new SqlParameter("@TrangThai", vi.TrangThai),
                new SqlParameter("@MaVi", vi.MaVi),
                new SqlParameter("@MaND", vi.MaND));
            return rows > 0;
        }

        // Đếm số bản ghi đang tham chiếu tới ví (thu, chi, chuyển tiền, giao dịch định kỳ)
        public static int DemBanGhiLienQuan(int maVi)
        {
            string sql = @"SELECT (SELECT COUNT(1) FROM ThuNhap WHERE MaVi = @MaVi)
                                + (SELECT COUNT(1) FROM ChiTieu WHERE MaVi = @MaVi)
                                + (SELECT COUNT(1) FROM ChuyenTien WHERE ViNguon = @MaVi OR ViDich = @MaVi)
                                + (SELECT COUNT(1) FROM GiaoDichDinhKy WHERE MaVi = @MaVi)";
            object res = KetNoiCSDL.LayMotGiaTri(sql, new SqlParameter("@MaVi", maVi));
            return (res != null && res != DBNull.Value) ? Convert.ToInt32(res) : 0;
        }

        public static int DemViDangSuDung(int maND)
        {
            string sql = "SELECT COUNT(1) FROM ViTien WHERE MaND = @MaND AND TrangThai = 1";
            object res = KetNoiCSDL.LayMotGiaTri(sql, new SqlParameter("@MaND", maND));
            return res != null ? Convert.ToInt32(res) : 0;
        }

        public static bool Xoa(int maVi, int maND)
        {
            string sql = "DELETE FROM ViTien WHERE MaVi = @MaVi AND MaND = @MaND";
            int rows = KetNoiCSDL.ThucThiLenh(sql,
                new SqlParameter("@MaVi", maVi),
                new SqlParameter("@MaND", maND));
            return rows > 0;
        }

        private static ViTienMH ChuyenDoiDongThanhMH(DataRow r)
        {
            return new ViTienMH
            {
                MaVi = Convert.ToInt32(r["MaVi"]),
                MaND = Convert.ToInt32(r["MaND"]),
                TenVi = r["TenVi"].ToString(),
                LoaiVi = r["LoaiVi"].ToString(),
                SoDuBanDau = Convert.ToDecimal(r["SoDuBanDau"]),
                SoDuHienTai = r["SoDuHienTai"] != DBNull.Value ? Convert.ToDecimal(r["SoDuHienTai"]) : 0,
                GhiChu = r["GhiChu"] != DBNull.Value ? r["GhiChu"].ToString() : null,
                TrangThai = Convert.ToBoolean(r["TrangThai"])
            };
        }
    }
}
