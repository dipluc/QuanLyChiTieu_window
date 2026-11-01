using System;
using System.Data;
using System.Data.SqlClient;
using DuLieu;
using MoHinh;
using NghiepVu.TienIch;

namespace NghiepVu
{
    public class KetQuaNguoiDung
    {
        public bool ThanhCong { get; set; }
        public string ThongBao { get; set; }
        public int MaND { get; set; }
        public bool DangDuocSuDung { get; set; }   // true khi không xóa được vì đã phát sinh dữ liệu liên quan
        public DataTable DuLieu { get; set; }
    }

    // Nghiệp vụ quản trị người dùng (chỉ Admin). Tái sử dụng TaiKhoanNV để giữ nguyên BR08, BR10, BR11.
    public static class NguoiDungNV
    {
        private const int DoDaiToiDa = 50;

        private static KetQuaNguoiDung Loi(string thongBao)
        {
            return new KetQuaNguoiDung { ThanhCong = false, ThongBao = thongBao };
        }

        private static string KiemTraQuyenAdmin()
        {
            if (!PhienDangNhap.DaDangNhap) return "Phiên đăng nhập không hợp lệ. Vui lòng đăng nhập lại.";
            if (!PhienDangNhap.LaAdmin) return "Chỉ Quản trị viên mới có quyền quản lý người dùng.";
            return null;
        }

        private static bool QuyenHopLe(string quyenHan)
        {
            return string.Equals(quyenHan, "Admin", StringComparison.OrdinalIgnoreCase)
                || string.Equals(quyenHan, "User", StringComparison.OrdinalIgnoreCase);
        }

        // ==========================================
        // 1. TẢI DỮ LIỆU
        // ==========================================
        public static KetQuaNguoiDung LayDanhSach()
        {
            string loiQuyen = KiemTraQuyenAdmin();
            if (loiQuyen != null) return Loi(loiQuyen);
            try
            {
                return new KetQuaNguoiDung { ThanhCong = true, DuLieu = NguoiDungDL.LayDanhSach() };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại NguoiDungNV.LayDanhSach", ex);
                return Loi("Lỗi khi tải danh sách người dùng: " + ex.Message);
            }
        }

        // ==========================================
        // 2. THÊM (BR08, BR10 xử lý trong TaiKhoanNV.DangKy)
        // ==========================================
        public static KetQuaNguoiDung Them(string hoTen, string tenDangNhap, string email, string matKhau, string quyenHan, bool trangThai)
        {
            string loiQuyen = KiemTraQuyenAdmin();
            if (loiQuyen != null) return Loi(loiQuyen);
            if (!QuyenHopLe(quyenHan)) return Loi("Vui lòng chọn quyền hạn.");
            if ((hoTen ?? "").Trim().Length > DoDaiToiDa) return Loi("Họ tên tối đa " + DoDaiToiDa + " ký tự.");
            if ((tenDangNhap ?? "").Trim().Length > DoDaiToiDa) return Loi("Tên đăng nhập tối đa " + DoDaiToiDa + " ký tự.");

            try
            {
                var kq = TaiKhoanNV.DangKy(hoTen, tenDangNhap, email, matKhau);
                if (!kq.ThanhCong) return Loi(kq.ThongBao);

                // DangKy luôn tạo tài khoản "User" đang hoạt động -> chỉnh lại theo lựa chọn của Admin
                if (string.Equals(quyenHan, "Admin", StringComparison.OrdinalIgnoreCase))
                    NguoiDungDL.CapNhatQuyenHan(kq.MaND, "Admin");
                if (!trangThai)
                    NguoiDungDL.KhoaMoKhoaTaiKhoan(kq.MaND, false);

                NhatKyLoi.GhiLog($"Admin '{PhienDangNhap.TenDangNhap}' tạo người dùng '{kq.TenDangNhap}' (MaND: {kq.MaND}, quyền: {quyenHan}).");
                return new KetQuaNguoiDung { ThanhCong = true, ThongBao = "Thêm người dùng thành công!", MaND = kq.MaND };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại NguoiDungNV.Them", ex);
                return Loi("Lỗi khi lưu vào cơ sở dữ liệu: " + ex.Message);
            }
        }

        // ==========================================
        // 3. SỬA (BR11 xử lý trong TaiKhoanNV.DoiQuyenHan / KhoaMoKhoa)
        //    matKhauMoi để trống = giữ nguyên mật khẩu cũ
        // ==========================================
        public static KetQuaNguoiDung CapNhat(int maND, string hoTen, string email, string matKhauMoi, string quyenHan, bool trangThai)
        {
            string loiQuyen = KiemTraQuyenAdmin();
            if (loiQuyen != null) return Loi(loiQuyen);
            if (maND <= 0) return Loi("Bạn chưa chọn bản ghi nào.");
            if (string.IsNullOrWhiteSpace(hoTen)) return Loi("Họ tên không được để trống.");
            if (hoTen.Trim().Length > DoDaiToiDa) return Loi("Họ tên tối đa " + DoDaiToiDa + " ký tự.");
            if (!QuyenHopLe(quyenHan)) return Loi("Vui lòng chọn quyền hạn.");

            hoTen = hoTen.Trim();
            email = string.IsNullOrWhiteSpace(email) ? null : email.Trim();
            if (email != null && email.Length > DoDaiToiDa) return Loi("Email tối đa " + DoDaiToiDa + " ký tự.");

            string loiMatKhau = string.Empty;
            bool doiMatKhau = !string.IsNullOrEmpty(matKhauMoi);
            if (doiMatKhau && !BaoMat.KiemTraDoManhMatKhau(matKhauMoi, out loiMatKhau)) return Loi(loiMatKhau);

            try
            {
                NguoiDungMH nd = NguoiDungDL.LayTheoMaND(maND);
                if (nd == null) return Loi("Không tìm thấy người dùng.");

                if (email != null && NguoiDungDL.KiemTraTonTaiEmail(email, maND))
                    return Loi("Email này đã được sử dụng bởi một tài khoản khác.");

                string thongBao;
                if (!string.Equals(nd.QuyenHan, quyenHan, StringComparison.OrdinalIgnoreCase)
                    && !TaiKhoanNV.DoiQuyenHan(maND, quyenHan, out thongBao))
                    return Loi(thongBao);

                if (nd.TrangThai != trangThai && !TaiKhoanNV.KhoaMoKhoa(maND, trangThai, out thongBao))
                    return Loi(thongBao);

                if (!NguoiDungDL.CapNhatThongTin(maND, hoTen, email))
                    return Loi("Không thể cập nhật thông tin người dùng.");

                if (doiMatKhau)
                    NguoiDungDL.CapNhatMatKhau(maND, BaoMat.BamMatKhau(matKhauMoi));

                if (PhienDangNhap.MaND == maND)
                    PhienDangNhap.CapNhatThongTin(hoTen, email);

                NhatKyLoi.GhiLog($"Admin '{PhienDangNhap.TenDangNhap}' cập nhật người dùng '{nd.TenDangNhap}' (MaND: {maND}).");
                return new KetQuaNguoiDung { ThanhCong = true, ThongBao = "Cập nhật người dùng thành công!", MaND = maND };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại NguoiDungNV.CapNhat", ex);
                return Loi("Lỗi khi cập nhật dữ liệu: " + ex.Message);
            }
        }

        // ==========================================
        // 4. XÓA / KHÓA (BR11)
        // ==========================================
        public static KetQuaNguoiDung Xoa(int maND)
        {
            string loiQuyen = KiemTraQuyenAdmin();
            if (loiQuyen != null) return Loi(loiQuyen);
            if (maND <= 0) return Loi("Bạn chưa chọn bản ghi nào.");
            if (PhienDangNhap.MaND == maND) return Loi("Bạn không thể xóa chính tài khoản đang đăng nhập.");

            try
            {
                NguoiDungMH nd = NguoiDungDL.LayTheoMaND(maND);
                if (nd == null) return Loi("Không tìm thấy người dùng.");

                if (string.Equals(nd.QuyenHan, "Admin", StringComparison.OrdinalIgnoreCase)
                    && nd.TrangThai && NguoiDungDL.DemAdminHoatDong() <= 1)
                    return Loi("Hệ thống phải có ít nhất một Quản trị viên hoạt động. Không thể xóa tài khoản này.");

                if (!NguoiDungDL.XoaNguoiDung(maND))
                    return Loi("Không tìm thấy người dùng cần xóa.");

                NhatKyLoi.GhiLog($"Admin '{PhienDangNhap.TenDangNhap}' xóa người dùng '{nd.TenDangNhap}' (MaND: {maND}).");
                return new KetQuaNguoiDung { ThanhCong = true, ThongBao = "Xóa người dùng thành công!", MaND = maND };
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                // Vi phạm khóa ngoại: người dùng đã có ví, khoản thu/chi... -> chỉ nên khóa tài khoản
                return new KetQuaNguoiDung
                {
                    ThanhCong = false,
                    DangDuocSuDung = true,
                    ThongBao = "Người dùng này đã có dữ liệu (ví, khoản thu chi...) nên không thể xóa."
                };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại NguoiDungNV.Xoa", ex);
                return Loi("Lỗi khi xóa dữ liệu: " + ex.Message);
            }
        }

        public static KetQuaNguoiDung Khoa(int maND)
        {
            string loiQuyen = KiemTraQuyenAdmin();
            if (loiQuyen != null) return Loi(loiQuyen);

            string thongBao;
            bool ok = TaiKhoanNV.KhoaMoKhoa(maND, false, out thongBao);
            return new KetQuaNguoiDung { ThanhCong = ok, ThongBao = thongBao, MaND = maND };
        }
    }
}
