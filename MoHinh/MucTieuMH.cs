using System;

namespace MoHinh
{
    public class MucTieuMH
    {
        public int MaMT { get; set; }
        public int MaND { get; set; }
        public string TenMucTieu { get; set; }
        public decimal SoTienMucTieu { get; set; }
        public decimal SoTienDaTietKiem { get; set; } = 0;
        public DateTime NgayBatDau { get; set; } = DateTime.Today;
        public DateTime? NgayDich { get; set; }
        public string TrangThai { get; set; } = "DangThucHien"; // "DangThucHien", "HoanThanh", "Huy"
        public string GhiChu { get; set; }

        // Thuộc tính tính toán
        public decimal PhanTram => SoTienMucTieu > 0 ? Math.Min(100, Math.Round(SoTienDaTietKiem * 100m / SoTienMucTieu, 1)) : 0;
        public decimal ConThieu => Math.Max(0, SoTienMucTieu - SoTienDaTietKiem);

        public MucTieuMH() { }
    }
}
