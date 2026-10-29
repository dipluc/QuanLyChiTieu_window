using System;

namespace MoHinh
{
    public class LoaiThuMH
    {
        public int MaLoaiThu { get; set; }
        public int MaND { get; set; }
        public string TenLoaiThu { get; set; }
        public string GhiChu { get; set; }
        public bool TrangThai { get; set; } = true;

        public LoaiThuMH() { }
    }
}
