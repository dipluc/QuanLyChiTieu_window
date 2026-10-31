using System;

namespace MoHinh
{
    public class ChuyenTienMH
    {
        public int MaCT { get; set; }
        public int MaND { get; set; }
        public int ViNguon { get; set; }
        public int ViDich { get; set; }
        public DateTime NgayChuyen { get; set; } = DateTime.Today;
        public decimal SoTien { get; set; }
        public string GhiChu { get; set; }

        // Thuộc tính hiển thị kết hợp
        public string TenViNguon { get; set; }
        public string TenViDich { get; set; }

        public ChuyenTienMH() { }
    }
}
