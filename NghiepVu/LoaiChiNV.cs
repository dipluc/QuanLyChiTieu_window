using System;
using System.Data;
using System.Data.SqlClient;
using DuLieu;
using MoHinh;
using NghiepVu.TienIch;

namespace NghiepVu
{
    public class KetQuaLoaiChi
    {
        public bool ThanhCong { get; set; }
        public string ThongBao { get; set; }
        public int MaLoaiChi { get; set; }
        public bool DangDuocSuDung { get; set; }   // true khi không xóa được vì đã phát sinh dữ liệu liên quan
        public DataTable DuLieu { get; set; }
    }

    public static class LoaiChiNV
    {
        private const int DoDaiToiDaTen = 50;
        private const int DoDaiToiDaGhiChu = 200;
        private const string LoiPhien = "Phiên đăng nhập không hợp lệ. Vui lòng đăng nhập lại.";

        private static KetQuaLoaiChi Loi(string thongBao)
        {
            return new KetQuaLoaiChi { ThanhCong = false, ThongBao = thongBao };
        }

        // Trả về thông báo lỗi nếu dữ liệu không hợp lệ, null nếu hợp lệ
        private static string KiemTraDuLieu(LoaiChiMH lc)
        {
            if (lc == null) return "Dữ liệu loại chi không hợp lệ.";
            if (lc.MaNhom <= 0) return "Vui lòng chọn nhóm chi.";
            if (string.IsNullOrWhiteSpace(lc.TenLoaiChi)) return "Tên loại chi không được để trống.";
            if (lc.TenLoaiChi.Trim().Length > DoDaiToiDaTen) return "Tên loại chi tối đa " + DoDaiToiDaTen + " ký tự.";
            if (!string.IsNullOrEmpty(lc.GhiChu) && lc.GhiChu.Trim().Length > DoDaiToiDaGhiChu)
                return "Ghi chú tối đa " + DoDaiToiDaGhiChu + " ký tự.";
            return null;
        }

        private static void ChuanHoa(LoaiChiMH lc)
        {
            lc.TenLoaiChi = lc.TenLoaiChi.Trim();
            lc.GhiChu = string.IsNullOrWhiteSpace(lc.GhiChu) ? null : lc.GhiChu.Trim();
            lc.MaND = PhienDangNhap.MaND;
        }

        // ==========================================
        // 1. TẢI DỮ LIỆU
        // ==========================================
        public static KetQuaLoaiChi LayDanhSach()
        {
            if (!PhienDangNhap.DaDangNhap) return Loi(LoiPhien);
            try
            {
                return new KetQuaLoaiChi { ThanhCong = true, DuLieu = LoaiChiDL.LayDanhSach(PhienDangNhap.MaND) };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại LoaiChiNV.LayDanhSach", ex);
                return Loi("Lỗi khi tải danh sách loại chi: " + ex.Message);
            }
        }

        public static KetQuaLoaiChi LayDanhSachNhomChi()
        {
            if (!PhienDangNhap.DaDangNhap) return Loi(LoiPhien);
            try
            {
                return new KetQuaLoaiChi { ThanhCong = true, DuLieu = LoaiChiDL.LayDanhSachNhomChi(PhienDangNhap.MaND) };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại LoaiChiNV.LayDanhSachNhomChi", ex);
                return Loi("Lỗi khi tải danh sách nhóm chi: " + ex.Message);
            }
        }

        // ==========================================
        // 2. THÊM
        // ==========================================
        public static KetQuaLoaiChi Them(LoaiChiMH lc)
        {
            if (!PhienDangNhap.DaDangNhap) return Loi(LoiPhien);

            string loi = KiemTraDuLieu(lc);
            if (loi != null) return Loi(loi);
            ChuanHoa(lc);

            try
            {
                if (LoaiChiDL.KiemTraTonTaiTen(lc.MaND, lc.TenLoaiChi))
                    return Loi("Tên loại chi này đã tồn tại. Vui lòng nhập tên khác.");

                int maMoi = LoaiChiDL.ThemLoaiChi(lc);
                if (maMoi <= 0) return Loi("Không thể thêm loại chi vào cơ sở dữ liệu.");

                NhatKyLoi.GhiLog($"Người dùng '{PhienDangNhap.TenDangNhap}' thêm loại chi '{lc.TenLoaiChi}' (MaLoaiChi: {maMoi}).");
                return new KetQuaLoaiChi { ThanhCong = true, ThongBao = "Thêm loại chi thành công!", MaLoaiChi = maMoi };
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                return Loi("Tên loại chi này đã tồn tại. Vui lòng nhập tên khác.");
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại LoaiChiNV.Them", ex);
                return Loi("Lỗi khi lưu vào cơ sở dữ liệu: " + ex.Message);
            }
        }

        // ==========================================
        // 3. SỬA
        // ==========================================
        public static KetQuaLoaiChi CapNhat(LoaiChiMH lc)
        {
            if (!PhienDangNhap.DaDangNhap) return Loi(LoiPhien);

            string loi = KiemTraDuLieu(lc);
            if (loi != null) return Loi(loi);
            if (lc.MaLoaiChi <= 0) return Loi("Bạn chưa chọn bản ghi nào.");
            ChuanHoa(lc);

            try
            {
                if (LoaiChiDL.KiemTraTonTaiTen(lc.MaND, lc.TenLoaiChi, lc.MaLoaiChi))
                    return Loi("Tên loại chi này đã tồn tại. Vui lòng nhập tên khác.");

                if (!LoaiChiDL.CapNhatLoaiChi(lc))
                    return Loi("Không tìm thấy loại chi cần cập nhật.");

                NhatKyLoi.GhiLog($"Người dùng '{PhienDangNhap.TenDangNhap}' cập nhật loại chi '{lc.TenLoaiChi}' (MaLoaiChi: {lc.MaLoaiChi}).");
                return new KetQuaLoaiChi { ThanhCong = true, ThongBao = "Cập nhật loại chi thành công!", MaLoaiChi = lc.MaLoaiChi };
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                return Loi("Tên loại chi này đã tồn tại. Vui lòng nhập tên khác.");
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại LoaiChiNV.CapNhat", ex);
                return Loi("Lỗi khi cập nhật dữ liệu: " + ex.Message);
            }
        }

        // ==========================================
        // 4. XÓA / NGỪNG SỬ DỤNG
        // ==========================================
        public static KetQuaLoaiChi Xoa(int maLoaiChi)
        {
            if (!PhienDangNhap.DaDangNhap) return Loi(LoiPhien);
            if (maLoaiChi <= 0) return Loi("Bạn chưa chọn bản ghi nào.");

            try
            {
                if (!LoaiChiDL.XoaLoaiChi(maLoaiChi, PhienDangNhap.MaND))
                    return Loi("Không tìm thấy loại chi cần xóa.");

                NhatKyLoi.GhiLog($"Người dùng '{PhienDangNhap.TenDangNhap}' xóa loại chi (MaLoaiChi: {maLoaiChi}).");
                return new KetQuaLoaiChi { ThanhCong = true, ThongBao = "Xóa loại chi thành công!", MaLoaiChi = maLoaiChi };
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                // Vi phạm khóa ngoại: loại chi đã có khoản chi, ngân sách hoặc giao dịch định kỳ
                return new KetQuaLoaiChi
                {
                    ThanhCong = false,
                    DangDuocSuDung = true,
                    ThongBao = "Loại chi này đã phát sinh dữ liệu (khoản chi, ngân sách hoặc giao dịch định kỳ) nên không thể xóa."
                };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại LoaiChiNV.Xoa", ex);
                return Loi("Lỗi khi xóa dữ liệu: " + ex.Message);
            }
        }

        public static KetQuaLoaiChi DatTrangThai(int maLoaiChi, bool trangThai)
        {
            if (!PhienDangNhap.DaDangNhap) return Loi(LoiPhien);
            if (maLoaiChi <= 0) return Loi("Bạn chưa chọn bản ghi nào.");

            try
            {
                if (!LoaiChiDL.DatTrangThai(maLoaiChi, PhienDangNhap.MaND, trangThai))
                    return Loi("Không tìm thấy loại chi cần cập nhật.");

                return new KetQuaLoaiChi
                {
                    ThanhCong = true,
                    MaLoaiChi = maLoaiChi,
                    ThongBao = trangThai ? "Đã bật sử dụng loại chi." : "Đã chuyển loại chi sang trạng thái ngừng sử dụng."
                };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại LoaiChiNV.DatTrangThai", ex);
                return Loi("Lỗi khi cập nhật trạng thái: " + ex.Message);
            }
        }
    }
}
