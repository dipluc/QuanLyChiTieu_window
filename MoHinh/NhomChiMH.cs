using System;

namespace MoHinh
{
    public class NhomChiMH
    {
        public int MaNhom { get; set; }
        public int MaND { get; set; }
        public string TenNhom { get; set; }
        public string MauSac { get; set; } // #RRGGBB
        public bool TrangThai { get; set; } = true;

        public NhomChiMH() { }
    }
}
