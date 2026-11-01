using System;
using System.Collections.Generic;
using System.Data;
using DuLieu;
using MoHinh;
using NghiepVu.TienIch;

namespace NghiepVu
{
    public class KetQuaGiaoDichDinhKy
    {
        public bool ThanhCong { get; set; }
        public string ThongBao { get; set; }
        public int MaGDDK { get; set; }
    }

    public static class GiaoDichDinhKyNV
    {
        // Mã lưu trong CSDL (Key) và nhãn hiển thị (Value)
        public static readonly KeyValuePair<string, string>[] DanhSachLoai =
        {
            new KeyValuePair<string, string>("Thu", "Thu nhập"),
            new KeyValuePair<string, string>("Chi", "Chi tiêu")
        };

        public static readonly KeyValuePair<string, string>[] DanhSachTanSuat =
        {
            new KeyValuePair<string, string>("Ngay", "Hằng ngày"),
            new KeyValuePair<string, string>("Tuan", "Hằng tuần"),
            new KeyValuePair<string, string>("Thang", "Hằng tháng"),
            new KeyValuePair<string, string>("Nam", "Hằng năm")
        };

        public static string TenLoai(string ma)
        {
            foreach (var kv in DanhSachLoai) if (kv.Key == ma) return kv.Value;
            return ma;
        }

        public static string TenTanSuat(string ma)
        {
            foreach (var kv in DanhSachTanSuat) if (kv.Key == ma) return kv.Value;
            return ma;
        }

        // Tính ngày đến hạn kế tiếp từ một mốc ngày theo tần suất
        public static DateTime TinhNgayKeTiep(DateTime moc, string tanSuat)
        {
            switch (tanSuat)
            {
                case "Ngay": return moc.AddDays(1);
                case "Tuan": return moc.AddDays(7);
                case "Nam": return moc.AddYears(1);
                default: return moc.AddMonths(1);
            }
        }

        // ==========================================
        // TRUY VẤN
        // ==========================================
        public static List<GiaoDichDinhKyMH> LayDanhSach()
        {
            try
            {
                return GiaoDichDinhKyDL.LayDanhSach(PhienDangNhap.MaND);
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại GiaoDichDinhKyNV.LayDanhSach", ex);
                return new List<GiaoDichDinhKyMH>();
            }
        }

        public static DataTable LayDanhSachVi()
        {
            try { return GiaoDichDinhKyDL.LayDanhSachVi(PhienDangNhap.MaND); }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại GiaoDichDinhKyNV.LayDanhSachVi", ex);
                return new DataTable();
            }
        }

        // loai = "Thu" hoặc "Chi"
        public static DataTable LayDanhMuc(string loai)
        {
            try
            {
                if (loai == "Thu") return GiaoDichDinhKyDL.LayDanhMucThu(PhienDangNhap.MaND);
                if (loai == "Chi") return GiaoDichDinhKyDL.LayDanhMucChi(PhienDangNhap.MaND);
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại GiaoDichDinhKyNV.LayDanhMuc", ex);
            }
            return new DataTable();
        }

        // ==========================================
        // KIỂM TRA HỢP LỆ
        // ==========================================
        private static string KiemTraHopLe(GiaoDichDinhKyMH gd)
        {
            if (gd.LoaiGiaoDich != "Thu" && gd.LoaiGiaoDich != "Chi")
                return "Bạn phải chọn loại giao dịch (Thu nhập/Chi tiêu).";
            if (gd.LoaiGiaoDich == "Thu" && !gd.MaLoaiThu.HasValue)
                return "Bạn phải chọn danh mục thu nhập.";
            if (gd.LoaiGiaoDich == "Chi" && !gd.MaLoaiChi.HasValue)
                return "Bạn phải chọn danh mục chi tiêu.";
            if (gd.MaVi <= 0)
                return "Bạn phải chọn ví.";
            if (gd.SoTien <= 0)
                return "Số tiền phải lớn hơn 0.";
            if (string.IsNullOrEmpty(TenTanSuatHopLe(gd.TanSuat)))
                return "Bạn phải chọn tần suất.";
            if (gd.NgayKetThuc.HasValue && gd.NgayKetThuc.Value.Date < gd.NgayBatDau.Date)
                return "Ngày kết thúc phải sau hoặc bằng ngày bắt đầu.";
            if (gd.NgayDenHanTiepTheo.Date < gd.NgayBatDau.Date)
                return "Ngày đến hạn tiếp theo không được trước ngày bắt đầu.";
            return null;
        }

        private static string TenTanSuatHopLe(string ma)
        {
            foreach (var kv in DanhSachTanSuat) if (kv.Key == ma) return kv.Value;
            return null;
        }

        private static void ChuanHoa(GiaoDichDinhKyMH gd)
        {
            gd.MaND = PhienDangNhap.MaND;
            gd.GhiChu = string.IsNullOrWhiteSpace(gd.GhiChu) ? null : gd.GhiChu.Trim();
            // Chỉ giữ đúng một danh mục theo loại giao dịch
            if (gd.LoaiGiaoDich == "Thu") gd.MaLoaiChi = null;
            else gd.MaLoaiThu = null;
        }

        // ==========================================
        // THÊM / SỬA / XÓA
        // ==========================================
        public static KetQuaGiaoDichDinhKy Them(GiaoDichDinhKyMH gd)
        {
            if (!PhienDangNhap.DaDangNhap)
                return new KetQuaGiaoDichDinhKy { ThanhCong = false, ThongBao = "Bạn chưa đăng nhập." };
            ChuanHoa(gd);
            string loi = KiemTraHopLe(gd);
            if (loi != null)
                return new KetQuaGiaoDichDinhKy { ThanhCong = false, ThongBao = loi };

            try
            {
                if (!GiaoDichDinhKyDL.ViThuocNguoiDung(gd.MaVi, gd.MaND))
                    return new KetQuaGiaoDichDinhKy { ThanhCong = false, ThongBao = "Ví không hợp lệ." };

                int id = GiaoDichDinhKyDL.Them(gd);
                if (id > 0)
                {
                    NhatKyLoi.GhiLog($"Người dùng '{PhienDangNhap.TenDangNhap}' thêm giao dịch định kỳ #{id}.");
                    return new KetQuaGiaoDichDinhKy { ThanhCong = true, ThongBao = "Thêm giao dịch định kỳ thành công!", MaGDDK = id };
                }
                return new KetQuaGiaoDichDinhKy { ThanhCong = false, ThongBao = "Không thể thêm giao dịch định kỳ." };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại GiaoDichDinhKyNV.Them", ex);
                return new KetQuaGiaoDichDinhKy { ThanhCong = false, ThongBao = "Lỗi lưu dữ liệu: " + ex.Message };
            }
        }

        public static KetQuaGiaoDichDinhKy Sua(GiaoDichDinhKyMH gd)
        {
            if (!PhienDangNhap.DaDangNhap)
                return new KetQuaGiaoDichDinhKy { ThanhCong = false, ThongBao = "Bạn chưa đăng nhập." };
            if (gd.MaGDDK <= 0)
                return new KetQuaGiaoDichDinhKy { ThanhCong = false, ThongBao = "Bạn chưa chọn bản ghi nào." };
            ChuanHoa(gd);
            string loi = KiemTraHopLe(gd);
            if (loi != null)
                return new KetQuaGiaoDichDinhKy { ThanhCong = false, ThongBao = loi };

            try
            {
                if (!GiaoDichDinhKyDL.ViThuocNguoiDung(gd.MaVi, gd.MaND))
                    return new KetQuaGiaoDichDinhKy { ThanhCong = false, ThongBao = "Ví không hợp lệ." };

                if (GiaoDichDinhKyDL.Sua(gd))
                {
                    NhatKyLoi.GhiLog($"Người dùng '{PhienDangNhap.TenDangNhap}' sửa giao dịch định kỳ #{gd.MaGDDK}.");
                    return new KetQuaGiaoDichDinhKy { ThanhCong = true, ThongBao = "Cập nhật giao dịch định kỳ thành công!", MaGDDK = gd.MaGDDK };
                }
                return new KetQuaGiaoDichDinhKy { ThanhCong = false, ThongBao = "Không tìm thấy giao dịch để cập nhật." };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại GiaoDichDinhKyNV.Sua", ex);
                return new KetQuaGiaoDichDinhKy { ThanhCong = false, ThongBao = "Lỗi cập nhật dữ liệu: " + ex.Message };
            }
        }

        public static KetQuaGiaoDichDinhKy Xoa(int maGDDK)
        {
            if (!PhienDangNhap.DaDangNhap)
                return new KetQuaGiaoDichDinhKy { ThanhCong = false, ThongBao = "Bạn chưa đăng nhập." };
            if (maGDDK <= 0)
                return new KetQuaGiaoDichDinhKy { ThanhCong = false, ThongBao = "Bạn chưa chọn bản ghi nào." };

            try
            {
                if (GiaoDichDinhKyDL.Xoa(maGDDK, PhienDangNhap.MaND))
                {
                    NhatKyLoi.GhiLog($"Người dùng '{PhienDangNhap.TenDangNhap}' xóa giao dịch định kỳ #{maGDDK}.");
                    return new KetQuaGiaoDichDinhKy { ThanhCong = true, ThongBao = "Đã xóa giao dịch định kỳ.", MaGDDK = maGDDK };
                }
                return new KetQuaGiaoDichDinhKy { ThanhCong = false, ThongBao = "Không tìm thấy giao dịch để xóa." };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại GiaoDichDinhKyNV.Xoa", ex);
                return new KetQuaGiaoDichDinhKy { ThanhCong = false, ThongBao = "Không thể xóa: " + ex.Message };
            }
        }
    }
}
