using System;

namespace MoHinh
{
    public class NganSachMH
    {
        public int MaNS { get; set; }
        public int MaND { get; set; }
        public int MaLoaiChi { get; set; }
        public byte Thang { get; set; }
        public short Nam { get; set; }
        public decimal HanMuc { get; set; }

        // Thuộc tính mở rộng từ vw_NganSachDaChi
        public string TenLoaiChi { get; set; }
        public decimal DaChi { get; set; }
        public decimal PhanTram { get; set; } // DaChi * 100 / HanMuc
        public decimal ConLai => HanMuc - DaChi;

        public NganSachMH() { }
    }
}
