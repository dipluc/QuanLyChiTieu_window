namespace QuanLyChiTieu.Models;

public class ThuNhap
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime Ngay { get; set; } = DateTime.Today;
    public string LoaiThu { get; set; } = "Lương"; // Lương, Thưởng, Thu nhập khác
    public string ViId { get; set; } = "";
    public decimal SoTien { get; set; }
    public string GhiChu { get; set; } = "";
}

public class ChiTieu
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime Ngay { get; set; } = DateTime.Today;
    public string LoaiChi { get; set; } = "Ăn uống"; // Ăn uống, Di chuyển, Mua sắm, Nhà ở, Khác, Sức khỏe, Y tế
    public string ViId { get; set; } = "";
    public decimal SoTien { get; set; }
    public string GhiChu { get; set; } = "";
}

public class NganSachItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public int Thang { get; set; }
    public int Nam { get; set; }
    public string LoaiChi { get; set; } = "";
    public decimal HanMuc { get; set; }
}

public class ChuyenTienRecord
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime Ngay { get; set; } = DateTime.Today;
    public string ViNguonId { get; set; } = "";
    public string ViDichId { get; set; } = "";
    public decimal SoTien { get; set; }
    public string GhiChu { get; set; } = "";
}

public class Vi
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Ten { get; set; } = "";
    public decimal SoDu { get; set; }
    public string TenVi { get => Ten; set => Ten = value; }
}

public class CauHinhApp
{
    public string ThuMucSaoLuu { get; set; } = @"D:\QuanLyChiTieu\SaoLuu";
    public bool TuDongSaoLuuKhiThoat { get; set; } = true;
    public int NguongCanhBao { get; set; } = 80; // phần trăm
    public int NgưongCanhBao { get => NguongCanhBao; set => NguongCanhBao = value; }
}

public class AppData
{
    public List<ThuNhap> DanhSachThuNhap { get; set; } = new();
    public List<ChiTieu> DanhSachChiTieu { get; set; } = new();
    public List<NganSachItem> DanhSachNganSach { get; set; } = new();
    public List<ChuyenTienRecord> DanhSachChuyenTien { get; set; } = new();
    public List<Vi> DanhSachVi { get; set; } = new();
    public CauHinhApp CauHinh { get; set; } = new();
    public string NguoiDung { get; set; } = "Nguyễn Minh Anh";
}
