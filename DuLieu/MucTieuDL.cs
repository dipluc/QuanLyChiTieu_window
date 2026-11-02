using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MoHinh;

namespace DuLieu
{
    public static class MucTieuDL
    {
        private const string SqlChon =
            @"SELECT MaMT, MaND, TenMucTieu, SoTienMucTieu, SoTienDaTietKiem,
                     NgayBatDau, NgayDich, TrangThai, GhiChu
              FROM MucTieu ";

        public static List<MucTieuMH> LayDanhSach(int maND)
        {
            string sql = SqlChon + @"WHERE MaND = @MaND
                ORDER BY CASE TrangThai WHEN 'DangThucHien' THEN 0 WHEN 'HoanThanh' THEN 1 ELSE 2 END,
                         NgayDich ASC, MaMT ASC";
            DataTable dt = KetNoiCSDL.DocDuLieu(sql, new SqlParameter("@MaND", maND));
            var ds = new List<MucTieuMH>();
            foreach (DataRow r in dt.Rows)
            {
                ds.Add(ChuyenDoiDongThanhMH(r));
            }
            return ds;
        }

        public static MucTieuMH LayTheoMa(int maMT, int maND)
        {
            string sql = SqlChon + "WHERE MaMT = @MaMT AND MaND = @MaND";
            DataTable dt = KetNoiCSDL.DocDuLieu(sql,
                new SqlParameter("@MaMT", maMT),
                new SqlParameter("@MaND", maND));
            return dt.Rows.Count > 0 ? ChuyenDoiDongThanhMH(dt.Rows[0]) : null;
        }

        // Tên mục tiêu không được trùng trong cùng một người dùng (ràng buộc UQ_MucTieu_MaND_Ten)
        public static bool KiemTraTrungTen(int maND, string tenMucTieu, int boQuaMaMT = 0)
        {
            string sql = "SELECT COUNT(1) FROM MucTieu WHERE MaND = @MaND AND TenMucTieu = @Ten AND MaMT <> @MaMT";
            object res = KetNoiCSDL.LayMotGiaTri(sql,
                new SqlParameter("@MaND", maND),
                new SqlParameter("@Ten", tenMucTieu),
                new SqlParameter("@MaMT", boQuaMaMT));
            return res != null && Convert.ToInt32(res) > 0;
        }

        public static int Them(MucTieuMH mt)
        {
            string sql = @"INSERT INTO MucTieu
                               (MaND, TenMucTieu, SoTienMucTieu, SoTienDaTietKiem, NgayBatDau, NgayDich, TrangThai, GhiChu)
                           VALUES
                               (@MaND, @TenMucTieu, @SoTienMucTieu, @SoTienDaTietKiem, @NgayBatDau, @NgayDich, @TrangThai, @GhiChu);
                           SELECT SCOPE_IDENTITY();";
            object id = KetNoiCSDL.LayMotGiaTri(sql, TaoThamSo(mt));
            return (id != null && id != DBNull.Value) ? Convert.ToInt32(id) : 0;
        }

        // Không cập nhật SoTienDaTietKiem (chỉ thay đổi qua chức năng nạp tiền)
        public static bool Sua(MucTieuMH mt)
        {
            string sql = @"UPDATE MucTieu
                           SET TenMucTieu = @TenMucTieu, SoTienMucTieu = @SoTienMucTieu,
                               NgayBatDau = @NgayBatDau, NgayDich = @NgayDich,
                               TrangThai = @TrangThai, GhiChu = @GhiChu
                           WHERE MaMT = @MaMT AND MaND = @MaND";
            return KetNoiCSDL.ThucThiLenh(sql,
                new SqlParameter("@MaMT", mt.MaMT),
                new SqlParameter("@MaND", mt.MaND),
                new SqlParameter("@TenMucTieu", mt.TenMucTieu),
                new SqlParameter("@SoTienMucTieu", mt.SoTienMucTieu),
                new SqlParameter("@NgayBatDau", mt.NgayBatDau),
                new SqlParameter("@NgayDich", (object)mt.NgayDich ?? DBNull.Value),
                new SqlParameter("@TrangThai", mt.TrangThai),
                new SqlParameter("@GhiChu", (object)mt.GhiChu ?? DBNull.Value)) > 0;
        }

        // Cộng thêm tiền đã tiết kiệm, tự chuyển trạng thái Hoàn thành khi đạt mục tiêu
        public static bool CongTienDaTietKiem(int maMT, int maND, decimal soTien)
        {
            string sql = @"UPDATE MucTieu
                           SET SoTienDaTietKiem = SoTienDaTietKiem + @SoTien,
                               TrangThai = CASE
                                   WHEN TrangThai = 'Huy' THEN TrangThai
                                   WHEN SoTienDaTietKiem + @SoTien >= SoTienMucTieu THEN 'HoanThanh'
                                   ELSE 'DangThucHien' END
                           WHERE MaMT = @MaMT AND MaND = @MaND";
            return KetNoiCSDL.ThucThiLenh(sql,
                new SqlParameter("@SoTien", soTien),
                new SqlParameter("@MaMT", maMT),
                new SqlParameter("@MaND", maND)) > 0;
        }

        // Rút bớt tiền đã tiết kiệm (không cho âm). Đang HoanThanh mà tụt dưới mục tiêu => quay lại DangThucHien
        public static bool TruTienDaTietKiem(int maMT, int maND, decimal soTien)
        {
            string sql = @"UPDATE MucTieu
                           SET SoTienDaTietKiem = SoTienDaTietKiem - @SoTien,
                               TrangThai = CASE
                                   WHEN TrangThai = 'Huy' THEN TrangThai
                                   WHEN SoTienDaTietKiem - @SoTien >= SoTienMucTieu THEN 'HoanThanh'
                                   ELSE 'DangThucHien' END
                           WHERE MaMT = @MaMT AND MaND = @MaND
                             AND TrangThai <> 'Huy' AND SoTienDaTietKiem >= @SoTien";
            return KetNoiCSDL.ThucThiLenh(sql,
                new SqlParameter("@SoTien", soTien),
                new SqlParameter("@MaMT", maMT),
                new SqlParameter("@MaND", maND)) > 0;
        }

        // Hủy mục tiêu: chuyển sang 'Huy' và đưa số đã tiết kiệm về 0 (tiền được hoàn lại cho người dùng)
        public static bool Huy(int maMT, int maND)
        {
            string sql = @"UPDATE MucTieu SET TrangThai = 'Huy', SoTienDaTietKiem = 0
                           WHERE MaMT = @MaMT AND MaND = @MaND AND TrangThai <> 'Huy'";
            return KetNoiCSDL.ThucThiLenh(sql,
                new SqlParameter("@MaMT", maMT),
                new SqlParameter("@MaND", maND)) > 0;
        }

        public static bool Xoa(int maMT, int maND)
        {
            string sql = "DELETE FROM MucTieu WHERE MaMT = @MaMT AND MaND = @MaND";
            return KetNoiCSDL.ThucThiLenh(sql,
                new SqlParameter("@MaMT", maMT),
                new SqlParameter("@MaND", maND)) > 0;
        }

        private static SqlParameter[] TaoThamSo(MucTieuMH mt)
        {
            return new[]
            {
                new SqlParameter("@MaND", mt.MaND),
                new SqlParameter("@TenMucTieu", mt.TenMucTieu),
                new SqlParameter("@SoTienMucTieu", mt.SoTienMucTieu),
                new SqlParameter("@SoTienDaTietKiem", mt.SoTienDaTietKiem),
                new SqlParameter("@NgayBatDau", mt.NgayBatDau),
                new SqlParameter("@NgayDich", (object)mt.NgayDich ?? DBNull.Value),
                new SqlParameter("@TrangThai", mt.TrangThai),
                new SqlParameter("@GhiChu", (object)mt.GhiChu ?? DBNull.Value)
            };
        }

        private static MucTieuMH ChuyenDoiDongThanhMH(DataRow r)
        {
            return new MucTieuMH
            {
                MaMT = Convert.ToInt32(r["MaMT"]),
                MaND = Convert.ToInt32(r["MaND"]),
                TenMucTieu = r["TenMucTieu"].ToString(),
                SoTienMucTieu = Convert.ToDecimal(r["SoTienMucTieu"]),
                SoTienDaTietKiem = Convert.ToDecimal(r["SoTienDaTietKiem"]),
                NgayBatDau = Convert.ToDateTime(r["NgayBatDau"]),
                NgayDich = r["NgayDich"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(r["NgayDich"]) : null,
                TrangThai = r["TrangThai"].ToString(),
                GhiChu = r["GhiChu"] != DBNull.Value ? r["GhiChu"].ToString() : null
            };
        }
    }
}
