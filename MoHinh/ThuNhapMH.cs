using System;

namespace MoHinh
{
    public class ThuNhapMH
    {
        public int MaThu { get; set; }
        public int MaND { get; set; }
        public int MaVi { get; set; }
        public int MaLoaiThu { get; set; }
        public DateTime NgayThu { get; set; } = DateTime.Today;
        public decimal SoTien { get; set; }
        public string GhiChu { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.Now;

        // Thuộc tính hiển thị kết hợp
        public string TenVi { get; set; }
        public string TenLoaiThu { get; set; }

        public ThuNhapMH() { }
    }
}
