using System.Text.Json;
using QuanLyChiTieu.Models;

namespace QuanLyChiTieu.Services;

public static class DataService
{
    private static readonly string DataFolder = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "QuanLyChiTieu", "Data");

    private static readonly string DataFile = Path.Combine(DataFolder, "appdata.json");

    private static AppData? _cache;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    public static AppData LoadData()
    {
        if (_cache != null) return _cache;

        if (!Directory.Exists(DataFolder))
            Directory.CreateDirectory(DataFolder);

        if (File.Exists(DataFile))
        {
            try
            {
                var json = File.ReadAllText(DataFile);
                _cache = JsonSerializer.Deserialize<AppData>(json, JsonOptions) ?? CreateDefaultData();
            }
            catch
            {
                _cache = CreateDefaultData();
            }
        }
        else
        {
            _cache = CreateDefaultData();
            SaveData();
        }

        return _cache;
    }

    public static void SaveData()
    {
        if (_cache == null) return;

        if (!Directory.Exists(DataFolder))
            Directory.CreateDirectory(DataFolder);

        var json = JsonSerializer.Serialize(_cache, JsonOptions);
        File.WriteAllText(DataFile, json);
    }

    public static void ReloadData()
    {
        _cache = null;
        LoadData();
    }

    private static AppData CreateDefaultData()
    {
        var data = new AppData();

        // Tạo ví mặc định
        data.DanhSachVi.Add(new Vi { Id = "vietcombank", Ten = "Vietcombank", SoDu = 42000000 });
        data.DanhSachVi.Add(new Vi { Id = "tienmat", Ten = "Tiền mặt", SoDu = 5000000 });
        data.DanhSachVi.Add(new Vi { Id = "momo", Ten = "MoMo", SoDu = 1250000 });

        // Tạo thu nhập mẫu
        data.DanhSachThuNhap.Add(new ThuNhap
        {
            Ngay = new DateTime(2026, 10, 5),
            LoaiThu = "Lương",
            ViId = "vietcombank",
            SoTien = 23000000,
            GhiChu = "Lương tháng 10/2026"
        });
        data.DanhSachThuNhap.Add(new ThuNhap
        {
            Ngay = new DateTime(2026, 10, 24),
            LoaiThu = "Thu nhập khác",
            ViId = "vietcombank",
            SoTien = 2000000,
            GhiChu = "Thanh toán dự án công tác"
        });

        // Tạo chi tiêu mẫu
        data.DanhSachChiTieu.AddRange(new[]
        {
            new ChiTieu { Ngay = new DateTime(2026, 10, 1), LoaiChi = "Nhà ở", ViId = "vietcombank", SoTien = 7000000, GhiChu = "Tiền thuê nhà tháng 10" },
            new ChiTieu { Ngay = new DateTime(2026, 10, 7), LoaiChi = "Khác", ViId = "vietcombank", SoTien = 1000000, GhiChu = "Học phí khóa học trực tuyến" },
            new ChiTieu { Ngay = new DateTime(2026, 10, 10), LoaiChi = "Ăn uống", ViId = "tienmat", SoTien = 2000000, GhiChu = "Thực phẩm và ăn uống đầu tháng" },
            new ChiTieu { Ngay = new DateTime(2026, 10, 12), LoaiChi = "Mua sắm", ViId = "vietcombank", SoTien = 1750000, GhiChu = "Mua quần áo, đồ cá nhân" },
            new ChiTieu { Ngay = new DateTime(2026, 10, 15), LoaiChi = "Di chuyển", ViId = "vietcombank", SoTien = 1520000, GhiChu = "Xăng xe và bảo dưỡng" },
            new ChiTieu { Ngay = new DateTime(2026, 10, 18), LoaiChi = "Ăn uống", ViId = "tienmat", SoTien = 1895000, GhiChu = "Thực phẩm và ăn uống tuần 3" },
            new ChiTieu { Ngay = new DateTime(2026, 10, 20), LoaiChi = "Khác", ViId = "vietcombank", SoTien = 600000, GhiChu = "Quà tặng người thân" },
            new ChiTieu { Ngay = new DateTime(2026, 10, 22), LoaiChi = "Ăn uống", ViId = "momo", SoTien = 185000, GhiChu = "Ăn tối cùng gia đình" },
            new ChiTieu { Ngay = new DateTime(2026, 10, 23), LoaiChi = "Mua sắm", ViId = "vietcombank", SoTien = 650000, GhiChu = "Đồ dùng gia đình" },
            new ChiTieu { Ngay = new DateTime(2026, 10, 25), LoaiChi = "Di chuyển", ViId = "momo", SoTien = 80000, GhiChu = "Đi làm bằng xe công nghệ" },
        });

        // Tạo ngân sách mẫu
        data.DanhSachNganSach.AddRange(new[]
        {
            new NganSachItem { Thang = 10, Nam = 2026, LoaiChi = "Nhà ở", HanMuc = 7000000 },
            new NganSachItem { Thang = 10, Nam = 2026, LoaiChi = "Ăn uống", HanMuc = 5000000 },
            new NganSachItem { Thang = 10, Nam = 2026, LoaiChi = "Di chuyển", HanMuc = 2000000 },
            new NganSachItem { Thang = 10, Nam = 2026, LoaiChi = "Mua sắm", HanMuc = 2000000 },
            new NganSachItem { Thang = 10, Nam = 2026, LoaiChi = "Khác", HanMuc = 3000000 },
        });

        // Tạo chuyển tiền mẫu
        data.DanhSachChuyenTien.AddRange(new[]
        {
            new ChuyenTienRecord { Ngay = new DateTime(2026, 10, 10), ViNguonId = "vietcombank", ViDichId = "tienmat", SoTien = 1000000, GhiChu = "Bổ sung tiền mặt" },
            new ChuyenTienRecord { Ngay = new DateTime(2026, 10, 20), ViNguonId = "vietcombank", ViDichId = "momo", SoTien = 500000, GhiChu = "Nạp ví thanh toán" },
            new ChuyenTienRecord { Ngay = new DateTime(2026, 10, 24), ViNguonId = "vietcombank", ViDichId = "tienmat", SoTien = 2000000, GhiChu = "Rút tiền mặt cuối tháng" },
        });

        return data;
    }

    // ===== THU NHẬP =====
    public static List<ThuNhap> GetThuNhap(DateTime? tuNgay = null, DateTime? denNgay = null, string? loaiThu = null)
    {
        var data = LoadData();
        var query = data.DanhSachThuNhap.AsEnumerable();

        if (tuNgay.HasValue) query = query.Where(x => x.Ngay >= tuNgay.Value);
        if (denNgay.HasValue) query = query.Where(x => x.Ngay <= denNgay.Value);
        if (!string.IsNullOrEmpty(loaiThu) && loaiThu != "Tất cả")
            query = query.Where(x => x.LoaiThu == loaiThu);

        return query.OrderByDescending(x => x.Ngay).ToList();
    }

    public static void ThemThuNhap(ThuNhap thuNhap)
    {
        var data = LoadData();
        data.DanhSachThuNhap.Add(thuNhap);

        // Cập nhật số dư ví
        var vi = data.DanhSachVi.FirstOrDefault(v => v.Id == thuNhap.ViId);
        if (vi != null) vi.SoDu += thuNhap.SoTien;

        SaveData();
    }

    public static void SuaThuNhap(ThuNhap thuNhap)
    {
        var data = LoadData();
        var existing = data.DanhSachThuNhap.FirstOrDefault(x => x.Id == thuNhap.Id);
        if (existing != null)
        {
            // Hoàn lại số dư cũ
            var viCu = data.DanhSachVi.FirstOrDefault(v => v.Id == existing.ViId);
            if (viCu != null) viCu.SoDu -= existing.SoTien;

            // Cập nhật
            existing.Ngay = thuNhap.Ngay;
            existing.LoaiThu = thuNhap.LoaiThu;
            existing.ViId = thuNhap.ViId;
            existing.SoTien = thuNhap.SoTien;
            existing.GhiChu = thuNhap.GhiChu;

            // Cập nhật số dư mới
            var viMoi = data.DanhSachVi.FirstOrDefault(v => v.Id == thuNhap.ViId);
            if (viMoi != null) viMoi.SoDu += thuNhap.SoTien;

            SaveData();
        }
    }

    public static void XoaThuNhap(string id)
    {
        var data = LoadData();
        var thuNhap = data.DanhSachThuNhap.FirstOrDefault(x => x.Id == id);
        if (thuNhap != null)
        {
            var vi = data.DanhSachVi.FirstOrDefault(v => v.Id == thuNhap.ViId);
            if (vi != null) vi.SoDu -= thuNhap.SoTien;

            data.DanhSachThuNhap.Remove(thuNhap);
            SaveData();
        }
    }

    // ===== CHI TIÊU =====
    public static List<ChiTieu> GetChiTieu(DateTime? tuNgay = null, DateTime? denNgay = null, string? loaiChi = null)
    {
        var data = LoadData();
        var query = data.DanhSachChiTieu.AsEnumerable();

        if (tuNgay.HasValue) query = query.Where(x => x.Ngay >= tuNgay.Value);
        if (denNgay.HasValue) query = query.Where(x => x.Ngay <= denNgay.Value);
        if (!string.IsNullOrEmpty(loaiChi) && loaiChi != "Tất cả")
            query = query.Where(x => x.LoaiChi == loaiChi);

        return query.OrderByDescending(x => x.Ngay).ToList();
    }

    public static void ThemChiTieu(ChiTieu chiTieu)
    {
        var data = LoadData();
        data.DanhSachChiTieu.Add(chiTieu);

        var vi = data.DanhSachVi.FirstOrDefault(v => v.Id == chiTieu.ViId);
        if (vi != null) vi.SoDu -= chiTieu.SoTien;

        SaveData();
    }

    public static void SuaChiTieu(ChiTieu chiTieu)
    {
        var data = LoadData();
        var existing = data.DanhSachChiTieu.FirstOrDefault(x => x.Id == chiTieu.Id);
        if (existing != null)
        {
            var viCu = data.DanhSachVi.FirstOrDefault(v => v.Id == existing.ViId);
            if (viCu != null) viCu.SoDu += existing.SoTien;

            existing.Ngay = chiTieu.Ngay;
            existing.LoaiChi = chiTieu.LoaiChi;
            existing.ViId = chiTieu.ViId;
            existing.SoTien = chiTieu.SoTien;
            existing.GhiChu = chiTieu.GhiChu;

            var viMoi = data.DanhSachVi.FirstOrDefault(v => v.Id == chiTieu.ViId);
            if (viMoi != null) viMoi.SoDu -= chiTieu.SoTien;

            SaveData();
        }
    }

    public static void XoaChiTieu(string id)
    {
        var data = LoadData();
        var chiTieu = data.DanhSachChiTieu.FirstOrDefault(x => x.Id == id);
        if (chiTieu != null)
        {
            var vi = data.DanhSachVi.FirstOrDefault(v => v.Id == chiTieu.ViId);
            if (vi != null) vi.SoDu += chiTieu.SoTien;

            data.DanhSachChiTieu.Remove(chiTieu);
            SaveData();
        }
    }

    // ===== NGÂN SÁCH =====
    public static List<NganSachItem> GetNganSach(int thang, int nam)
    {
        var data = LoadData();
        return data.DanhSachNganSach
            .Where(x => x.Thang == thang && x.Nam == nam)
            .ToList();
    }

    public static void LuuNganSach(NganSachItem item)
    {
        var data = LoadData();
        var existing = data.DanhSachNganSach.FirstOrDefault(x =>
            x.Thang == item.Thang && x.Nam == item.Nam && x.LoaiChi == item.LoaiChi);

        if (existing != null)
        {
            existing.HanMuc = item.HanMuc;
        }
        else
        {
            data.DanhSachNganSach.Add(item);
        }
        SaveData();
    }

    public static void SaoChepNganSach(int thangNguon, int namNguon, int thangDich, int namDich)
    {
        var data = LoadData();
        var nguon = data.DanhSachNganSach.Where(x => x.Thang == thangNguon && x.Nam == namNguon).ToList();

        // Xóa ngân sách đích cũ
        data.DanhSachNganSach.RemoveAll(x => x.Thang == thangDich && x.Nam == namDich);

        foreach (var item in nguon)
        {
            data.DanhSachNganSach.Add(new NganSachItem
            {
                Thang = thangDich,
                Nam = namDich,
                LoaiChi = item.LoaiChi,
                HanMuc = item.HanMuc
            });
        }
        SaveData();
    }

    public static decimal GetTongChiTheoLoai(string loaiChi, int thang, int nam)
    {
        var data = LoadData();
        return data.DanhSachChiTieu
            .Where(x => x.LoaiChi == loaiChi && x.Ngay.Month == thang && x.Ngay.Year == nam)
            .Sum(x => x.SoTien);
    }

    // ===== CHUYỂN TIỀN =====
    public static List<ChuyenTienRecord> GetChuyenTien(DateTime? tuNgay = null, DateTime? denNgay = null)
    {
        var data = LoadData();
        var query = data.DanhSachChuyenTien.AsEnumerable();

        if (tuNgay.HasValue) query = query.Where(x => x.Ngay >= tuNgay.Value);
        if (denNgay.HasValue) query = query.Where(x => x.Ngay <= denNgay.Value);

        return query.OrderByDescending(x => x.Ngay).ToList();
    }

    public static bool ChuyenTien(ChuyenTienRecord record)
    {
        var data = LoadData();
        var viNguon = data.DanhSachVi.FirstOrDefault(v => v.Id == record.ViNguonId);
        var viDich = data.DanhSachVi.FirstOrDefault(v => v.Id == record.ViDichId);

        if (viNguon == null || viDich == null) return false;
        if (viNguon.SoDu < record.SoTien) return false;

        viNguon.SoDu -= record.SoTien;
        viDich.SoDu += record.SoTien;
        data.DanhSachChuyenTien.Add(record);

        SaveData();
        return true;
    }

    // ===== VÍ =====
    public static List<Vi> GetDanhSachVi()
    {
        return LoadData().DanhSachVi;
    }

    public static Vi? GetVi(string id)
    {
        return LoadData().DanhSachVi.FirstOrDefault(v => v.Id == id);
    }

    // ===== CẤU HÌNH =====
    public static CauHinhApp GetCauHinh()
    {
        return LoadData().CauHinh;
    }

    public static void LuuCauHinh(CauHinhApp cauHinh)
    {
        var data = LoadData();
        data.CauHinh = cauHinh;
        SaveData();
    }

    // ===== TÌM KIẾM =====
    public static List<object[]> TimKiemGiaoDich(
        string? tuKhoa = null,
        string? loaiGiaoDich = null, // Tất cả, Thu, Chi
        DateTime? tuNgay = null,
        DateTime? denNgay = null,
        decimal? tienTu = null,
        decimal? tienDen = null,
        string? loaiThuChi = null, // Tất cả, or specific type
        string? viId = null)
    {
        var data = LoadData();
        var results = new List<object[]>();

        // Tìm trong thu nhập
        if (loaiGiaoDich == null || loaiGiaoDich == "Tất cả" || loaiGiaoDich == "Thu")
        {
            foreach (var tn in data.DanhSachThuNhap)
            {
                if (tuNgay.HasValue && tn.Ngay < tuNgay.Value) continue;
                if (denNgay.HasValue && tn.Ngay > denNgay.Value) continue;
                if (tienTu.HasValue && tn.SoTien < tienTu.Value) continue;
                if (tienDen.HasValue && tn.SoTien > tienDen.Value) continue;
                if (!string.IsNullOrEmpty(viId) && viId != "Tất cả" && tn.ViId != viId) continue;
                if (!string.IsNullOrEmpty(loaiThuChi) && loaiThuChi != "Tất cả" && tn.LoaiThu != loaiThuChi) continue;
                if (!string.IsNullOrEmpty(tuKhoa) && !tn.GhiChu.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase)) continue;

                var vi = data.DanhSachVi.FirstOrDefault(v => v.Id == tn.ViId);
                results.Add(new object[] { tn.Ngay, "Thu", tn.LoaiThu, vi?.Ten ?? "", tn.SoTien, tn.GhiChu });
            }
        }

        // Tìm trong chi tiêu
        if (loaiGiaoDich == null || loaiGiaoDich == "Tất cả" || loaiGiaoDich == "Chi")
        {
            foreach (var ct in data.DanhSachChiTieu)
            {
                if (tuNgay.HasValue && ct.Ngay < tuNgay.Value) continue;
                if (denNgay.HasValue && ct.Ngay > denNgay.Value) continue;
                if (tienTu.HasValue && ct.SoTien < tienTu.Value) continue;
                if (tienDen.HasValue && ct.SoTien > tienDen.Value) continue;
                if (!string.IsNullOrEmpty(viId) && viId != "Tất cả" && ct.ViId != viId) continue;
                if (!string.IsNullOrEmpty(loaiThuChi) && loaiThuChi != "Tất cả" && ct.LoaiChi != loaiThuChi) continue;
                if (!string.IsNullOrEmpty(tuKhoa) && !ct.GhiChu.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase)) continue;

                var vi = data.DanhSachVi.FirstOrDefault(v => v.Id == ct.ViId);
                results.Add(new object[] { ct.Ngay, "Chi", ct.LoaiChi, vi?.Ten ?? "", ct.SoTien, ct.GhiChu });
            }
        }

        return results.OrderByDescending(r => (DateTime)r[0]).ToList();
    }

    public static string GetNguoiDung()
    {
        return LoadData().NguoiDung;
    }

    // ===== LOẠI CHI =====
    public static readonly string[] DanhSachLoaiChi = { "Ăn uống", "Di chuyển", "Mua sắm", "Nhà ở", "Khác", "Sức khỏe", "Y tế" };
    public static readonly string[] DanhSachLoaiThu = { "Lương", "Thưởng", "Thu nhập khác" };
}
