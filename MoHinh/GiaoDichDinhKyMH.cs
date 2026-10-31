using System;

namespace MoHinh
{
    public class GiaoDichDinhKyMH
    {
        public int MaGDDK { get; set; }
        public int MaND { get; set; }
        public string LoaiGiaoDich { get; set; } = "Chi"; // "Thu", "Chi"
        public int MaVi { get; set; }
        public int? MaLoaiThu { get; set; }
        public int? MaLoaiChi { get; set; }
        public decimal SoTien { get; set; }
        public string TanSuat { get; set; } = "Thang"; // "Ngay", "Tuan", "Thang", "Nam"
        public DateTime NgayBatDau { get; set; } = DateTime.Today;
        public DateTime? NgayKetThuc { get; set; }
        public DateTime NgayDenHanTiepTheo { get; set; } = DateTime.Today;
        public string GhiChu { get; set; }
        public bool TrangThai { get; set; } = true;

        // Thuộc tính hiển thị kết hợp
        public string TenVi { get; set; }
        public string TenDanhMuc { get; set; }

        public GiaoDichDinhKyMH() { }
    }
}
