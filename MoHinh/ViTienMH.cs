using System;

namespace MoHinh
{
    public class ViTienMH
    {
        public int MaVi { get; set; }
        public int MaND { get; set; }
        public string TenVi { get; set; }
        public string LoaiVi { get; set; } = "TienMat"; // "TienMat", "NganHang", "ViDienTu", "TheTinDung"
        public decimal SoDuBanDau { get; set; } = 0;
        public string GhiChu { get; set; }
        public bool TrangThai { get; set; } = true;

        // Thuộc tính mở rộng từ view vw_SoDuVi
        public decimal SoDuHienTai { get; set; }

        public ViTienMH() { }
    }
}
