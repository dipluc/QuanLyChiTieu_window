using System;

namespace MoHinh
{
    public class NguoiDungMH
    {
        public int MaND { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhauHash { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string QuyenHan { get; set; } = "User"; // "Admin", "User"
        public bool TrangThai { get; set; } = true; // 1 = HoatDong, 0 = BiKhoa
        public DateTime NgayTao { get; set; } = DateTime.Now;

        public NguoiDungMH() { }

        public NguoiDungMH(string tenDangNhap, string matKhauHash, string hoTen, string email, string quyenHan = "User")
        {
            TenDangNhap = tenDangNhap;
            MatKhauHash = matKhauHash;
            HoTen = hoTen;
            Email = email;
            QuyenHan = quyenHan;
            TrangThai = true;
            NgayTao = DateTime.Now;
        }
    }
}
