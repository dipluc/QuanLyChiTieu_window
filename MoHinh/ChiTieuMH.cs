using System;

namespace MoHinh
{
    public class ChiTieuMH
    {
        public int MaChi { get; set; }
        public int MaND { get; set; }
        public int MaVi { get; set; }
        public int MaLoaiChi { get; set; }
        public DateTime NgayChi { get; set; } = DateTime.Today;
        public decimal SoTien { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.Now;

        // Thuộc tính hiển thị kết hợp
        public string TenVi { get; set; }
        public string TenLoaiChi { get; set; }
        public string TenNhom { get; set; }

        public ChiTieuMH() { }
    }
}
