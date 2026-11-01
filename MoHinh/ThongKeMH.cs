using System;
using System.Collections.Generic;

namespace MoHinh
{
    public class ThongKeMH
    {
        public decimal TongThu { get; set; }
        public decimal TongChi { get; set; }
        public decimal ChenhLech => TongThu - TongChi;
        public decimal TyLeTietKiem => TongThu > 0 ? Math.Round((TongThu - TongChi) * 100m / TongThu, 1) : 0;
        public decimal TyLeChi => TongThu > 0 ? Math.Round((TongChi) * 100m / TongThu, 1) : 0;
        public int SoGiaoDichThu { get; set; }
        public int SoGiaoDichChi { get; set; }

        public ThongKeMH() { }
    }

    public class KhoanChiTop5MH
    {
        public string TenLoaiChi { get; set; }
        public decimal TongTien { get; set; }
        public decimal PhanTram { get; set; }
    }

    public class BieuDoThuChiThangMH
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public decimal Thu { get; set; }
        public decimal Chi { get; set; }
        public string NhanHienThi => $"T{Thang:D2}/{Nam}";
    }
}
