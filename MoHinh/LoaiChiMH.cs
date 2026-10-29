using System;

namespace MoHinh
{
    public class LoaiChiMH
    {
        public int MaLoaiChi { get; set; }
        public int MaNhom { get; set; }
        public int MaND { get; set; }
        public string TenLoaiChi { get; set; }
        public string GhiChu { get; set; }
        public bool TrangThai { get; set; } = true;

        // Thuộc tính hiển thị kết hợp
        public string TenNhom { get; set; }

        public LoaiChiMH() { }
    }
}
