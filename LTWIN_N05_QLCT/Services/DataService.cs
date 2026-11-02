using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using LTWIN_N05_QLCT.Models;

namespace LTWIN_N05_QLCT.Services
{
    public static class DataService
    {
        private static readonly string DataFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "QuanLyChiTieu", "Data");

        private static readonly string DataFile = Path.Combine(DataFolder, "appdata.xml");

        private static AppData _cache;

        public static AppData LoadData()
        {
            if (_cache != null) return _cache;

            if (!Directory.Exists(DataFolder))
                Directory.CreateDirectory(DataFolder);

            if (File.Exists(DataFile))
            {
                try
                {
                    var serializer = new XmlSerializer(typeof(AppData));
                    using (var reader = new StreamReader(DataFile))
                    {
                        _cache = (AppData)serializer.Deserialize(reader);
                    }
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

            if (_cache == null) _cache = CreateDefaultData();
            return _cache;
        }

        public static void SaveData()
        {
            if (_cache == null) return;

            try
            {
                if (!Directory.Exists(DataFolder))
                    Directory.CreateDirectory(DataFolder);

                var serializer = new XmlSerializer(typeof(AppData));
                using (var writer = new StreamWriter(DataFile))
                {
                    serializer.Serialize(writer, _cache);
                }
            }
            catch { }
        }

        public static void ReloadData()
        {
            _cache = null;
            LoadData();
        }

        private static AppData CreateDefaultData()
        {
            var data = new AppData();

            data.DanhSachVi.Add(new Vi { Id = "vietcombank", Ten = "Vietcombank", SoDu = 42000000 });
            data.DanhSachVi.Add(new Vi { Id = "tienmat", Ten = "Tiền mặt", SoDu = 5000000 });
            data.DanhSachVi.Add(new Vi { Id = "momo", Ten = "MoMo", SoDu = 1250000 });

            int currentMonth = DateTime.Today.Month;
            int currentYear = DateTime.Today.Year;

            data.DanhSachNganSach.Add(new NganSachItem { Thang = currentMonth, Nam = currentYear, LoaiChi = "Nhà ở", HanMuc = 7000000 });
            data.DanhSachNganSach.Add(new NganSachItem { Thang = currentMonth, Nam = currentYear, LoaiChi = "Ăn uống", HanMuc = 5000000 });
            data.DanhSachNganSach.Add(new NganSachItem { Thang = currentMonth, Nam = currentYear, LoaiChi = "Di chuyển", HanMuc = 2000000 });
            data.DanhSachNganSach.Add(new NganSachItem { Thang = currentMonth, Nam = currentYear, LoaiChi = "Mua sắm", HanMuc = 2000000 });
            data.DanhSachNganSach.Add(new NganSachItem { Thang = currentMonth, Nam = currentYear, LoaiChi = "Khác", HanMuc = 3000000 });

            return data;
        }

        // ===== THU NHẬP =====
        public static List<ThuNhap> GetThuNhap(DateTime? tuNgay = null, DateTime? denNgay = null, string loaiThu = null)
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
                var viCu = data.DanhSachVi.FirstOrDefault(v => v.Id == existing.ViId);
                if (viCu != null) viCu.SoDu -= existing.SoTien;

                existing.Ngay = thuNhap.Ngay;
                existing.LoaiThu = thuNhap.LoaiThu;
                existing.ViId = thuNhap.ViId;
                existing.SoTien = thuNhap.SoTien;
                existing.GhiChu = thuNhap.GhiChu;

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
        public static List<ChiTieu> GetChiTieu(DateTime? tuNgay = null, DateTime? denNgay = null, string loaiChi = null)
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

        public static Vi GetVi(string id)
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
            string tuKhoa = null,
            string loaiGiaoDich = null,
            DateTime? tuNgay = null,
            DateTime? denNgay = null,
            decimal? tienTu = null,
            decimal? tienDen = null,
            string loaiThuChi = null,
            string viId = null)
        {
            var data = LoadData();
            var results = new List<object[]>();

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
                    if (!string.IsNullOrEmpty(tuKhoa) && tn.GhiChu.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) < 0) continue;

                    var vi = data.DanhSachVi.FirstOrDefault(v => v.Id == tn.ViId);
                    results.Add(new object[] { tn.Ngay, "Thu", tn.LoaiThu, vi != null ? vi.Ten : "", tn.SoTien, tn.GhiChu });
                }
            }

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
                    if (!string.IsNullOrEmpty(tuKhoa) && ct.GhiChu.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) < 0) continue;

                    var vi = data.DanhSachVi.FirstOrDefault(v => v.Id == ct.ViId);
                    results.Add(new object[] { ct.Ngay, "Chi", ct.LoaiChi, vi != null ? vi.Ten : "", ct.SoTien, ct.GhiChu });
                }
            }

            return results.OrderByDescending(r => (DateTime)r[0]).ToList();
        }

        public static string GetNguoiDung()
        {
            return LoadData().NguoiDung;
        }

        public static readonly string[] DanhSachLoaiChi = new string[] { "Ăn uống", "Di chuyển", "Mua sắm", "Nhà ở", "Khác", "Sức khỏe", "Y tế" };
        public static readonly string[] DanhSachLoaiThu = new string[] { "Lương", "Thưởng", "Thu nhập khác" };
    }
}
