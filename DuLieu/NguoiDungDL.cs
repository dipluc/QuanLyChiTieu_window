using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MoHinh;

namespace DuLieu
{
    public static class NguoiDungDL
    {
        public static NguoiDungMH LayTheoTenDangNhap(string tenDangNhap)
        {
            string sql = "SELECT MaND, TenDangNhap, MatKhauHash, HoTen, Email, QuyenHan, TrangThai, NgayTao FROM NguoiDung WHERE TenDangNhap = @TenDangNhap";
            DataTable dt = KetNoiCSDL.DocDuLieu(sql, new SqlParameter("@TenDangNhap", tenDangNhap));
            if (dt.Rows.Count > 0)
            {
                return ChuyenDoiDongThanhMH(dt.Rows[0]);
            }
            return null;
        }

        public static NguoiDungMH LayTheoMaND(int maND)
        {
            string sql = "SELECT MaND, TenDangNhap, MatKhauHash, HoTen, Email, QuyenHan, TrangThai, NgayTao FROM NguoiDung WHERE MaND = @MaND";
            DataTable dt = KetNoiCSDL.DocDuLieu(sql, new SqlParameter("@MaND", maND));
            if (dt.Rows.Count > 0)
            {
                return ChuyenDoiDongThanhMH(dt.Rows[0]);
            }
            return null;
        }

        public static bool KiemTraTonTaiTenDangNhap(string tenDangNhap)
        {
            string sql = "SELECT COUNT(1) FROM NguoiDung WHERE TenDangNhap = @TenDangNhap";
            object res = KetNoiCSDL.LayMotGiaTri(sql, new SqlParameter("@TenDangNhap", tenDangNhap));
            return res != null && Convert.ToInt32(res) > 0;
        }

        public static bool KiemTraTonTaiEmail(string email, int excludeMaND = 0)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            string sql = "SELECT COUNT(1) FROM NguoiDung WHERE Email = @Email AND MaND <> @MaND";
            object res = KetNoiCSDL.LayMotGiaTri(sql, new SqlParameter("@Email", email), new SqlParameter("@MaND", excludeMaND));
            return res != null && Convert.ToInt32(res) > 0;
        }

        public static int ThemNguoiDung(NguoiDungMH nd)
        {
            string sql = @"INSERT INTO NguoiDung (TenDangNhap, MatKhauHash, HoTen, Email, QuyenHan, TrangThai, NgayTao) 
                           VALUES (@TenDangNhap, @MatKhauHash, @HoTen, @Email, @QuyenHan, @TrangThai, @NgayTao);
                           SELECT SCOPE_IDENTITY();";
            object id = KetNoiCSDL.LayMotGiaTri(sql,
                new SqlParameter("@TenDangNhap", nd.TenDangNhap),
                new SqlParameter("@MatKhauHash", nd.MatKhauHash),
                new SqlParameter("@HoTen", nd.HoTen),
                new SqlParameter("@Email", (object)nd.Email ?? DBNull.Value),
                new SqlParameter("@QuyenHan", string.IsNullOrEmpty(nd.QuyenHan) ? "User" : nd.QuyenHan),
                new SqlParameter("@TrangThai", nd.TrangThai),
                new SqlParameter("@NgayTao", nd.NgayTao)
            );
            return (id != null && id != DBNull.Value) ? Convert.ToInt32(id) : 0;
        }

        public static bool CapNhatMatKhau(int maND, string matKhauHashMoi)
        {
            string sql = "UPDATE NguoiDung SET MatKhauHash = @MatKhauHash WHERE MaND = @MaND";
            int rows = KetNoiCSDL.ThucThiLenh(sql,
                new SqlParameter("@MatKhauHash", matKhauHashMoi),
                new SqlParameter("@MaND", maND));
            return rows > 0;
        }

        public static bool CapNhatThongTin(int maND, string hoTen, string email)
        {
            string sql = "UPDATE NguoiDung SET HoTen = @HoTen, Email = @Email WHERE MaND = @MaND";
            int rows = KetNoiCSDL.ThucThiLenh(sql,
                new SqlParameter("@HoTen", hoTen),
                new SqlParameter("@Email", (object)email ?? DBNull.Value),
                new SqlParameter("@MaND", maND));
            return rows > 0;
        }

        public static DataTable LayDanhSach()
        {
            string sql = "SELECT MaND, TenDangNhap, HoTen, Email, QuyenHan, TrangThai, NgayTao FROM NguoiDung ORDER BY MaND ASC";
            return KetNoiCSDL.DocDuLieu(sql);
        }

        public static bool KhoaMoKhoaTaiKhoan(int maND, bool trangThai)
        {
            string sql = "UPDATE NguoiDung SET TrangThai = @TrangThai WHERE MaND = @MaND";
            int rows = KetNoiCSDL.ThucThiLenh(sql,
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@MaND", maND));
            return rows > 0;
        }

        public static bool CapNhatQuyenHan(int maND, string quyenHan)
        {
            string sql = "UPDATE NguoiDung SET QuyenHan = @QuyenHan WHERE MaND = @MaND";
            int rows = KetNoiCSDL.ThucThiLenh(sql,
                new SqlParameter("@QuyenHan", quyenHan),
                new SqlParameter("@MaND", maND));
            return rows > 0;
        }

        // Xóa người dùng. Nếu đã có dữ liệu liên quan (ví, thu, chi...) SQL Server ném SqlException 547,
        // NguoiDungNV.Xoa bắt lỗi này để báo "đang được sử dụng".
        public static bool XoaNguoiDung(int maND)
        {
            string sql = "DELETE FROM NguoiDung WHERE MaND = @MaND";
            int rows = KetNoiCSDL.ThucThiLenh(sql, new SqlParameter("@MaND", maND));
            return rows > 0;
        }

        public static int DemAdminHoatDong()
        {
            string sql = "SELECT COUNT(1) FROM NguoiDung WHERE QuyenHan = 'Admin' AND TrangThai = 1";
            object res = KetNoiCSDL.LayMotGiaTri(sql);
            return res != null ? Convert.ToInt32(res) : 0;
        }

        private static NguoiDungMH ChuyenDoiDongThanhMH(DataRow r)
        {
            return new NguoiDungMH
            {
                MaND = Convert.ToInt32(r["MaND"]),
                TenDangNhap = r["TenDangNhap"].ToString(),
                MatKhauHash = r["MatKhauHash"].ToString(),
                HoTen = r["HoTen"].ToString(),
                Email = r["Email"] != DBNull.Value ? r["Email"].ToString() : null,
                QuyenHan = r["QuyenHan"] != DBNull.Value ? r["QuyenHan"].ToString() : "User",
                TrangThai = Convert.ToBoolean(r["TrangThai"]),
                NgayTao = Convert.ToDateTime(r["NgayTao"])
            };
        }
    }
}

