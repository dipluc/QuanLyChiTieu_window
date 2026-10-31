using System;
using MoHinh;

namespace NghiepVu.TienIch
{
    public static class PhienDangNhap
    {
        public static int MaND { get; private set; }
        public static string TenDangNhap { get; private set; }
        public static string HoTen { get; private set; }
        public static string Email { get; private set; }
        public static string QuyenHan { get; private set; } // "Admin", "User"
        public static bool DaDangNhap { get; private set; } = false;
        public static DateTime ThoiDiemDangNhap { get; private set; }

        public static bool LaAdmin => string.Equals(QuyenHan, "Admin", StringComparison.OrdinalIgnoreCase);

        // Sự kiện khi thông tin phiên thay đổi (để frmMain cập nhật Header / StatusStrip)
        public static event Action ThongTinThayDoi;

        public static void ThietLapPhien(NguoiDungMH nd)
        {
            if (nd == null) return;
            MaND = nd.MaND;
            TenDangNhap = nd.TenDangNhap;
            HoTen = nd.HoTen;
            Email = nd.Email;
            QuyenHan = string.IsNullOrEmpty(nd.QuyenHan) ? "User" : nd.QuyenHan;
            DaDangNhap = true;
            ThoiDiemDangNhap = DateTime.Now;

            ThongTinThayDoi?.Invoke();
        }

        public static void CapNhatThongTin(string hoTenMoi, string emailMoi)
        {
            HoTen = hoTenMoi;
            Email = emailMoi;
            ThongTinThayDoi?.Invoke();
        }

        public static void XoaPhien()
        {
            MaND = 0;
            TenDangNhap = string.Empty;
            HoTen = string.Empty;
            Email = string.Empty;
            QuyenHan = string.Empty;
            DaDangNhap = false;
            ThoiDiemDangNhap = DateTime.MinValue;

            ThongTinThayDoi?.Invoke();
        }
    }
}

