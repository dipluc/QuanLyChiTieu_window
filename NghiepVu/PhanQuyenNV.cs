using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DuLieu;
using NghiepVu.TienIch;

namespace NghiepVu
{
    public class KetQuaPhanQuyen
    {
        public bool ThanhCong { get; set; }
        public string ThongBao { get; set; }
        public int SoThanhCong { get; set; }
        public List<string> DanhSachLoi { get; set; } = new List<string>();
        public DataTable DuLieu { get; set; }
    }

    // Phân quyền theo cột NguoiDung.QuyenHan ("Admin" / "User"). Chỉ Admin được thực hiện.
    // Tái sử dụng TaiKhoanNV.DoiQuyenHan để giữ nguyên BR11.
    public static class PhanQuyenNV
    {
        private static KetQuaPhanQuyen Loi(string thongBao)
        {
            return new KetQuaPhanQuyen { ThanhCong = false, ThongBao = thongBao };
        }

        private static string KiemTraQuyenAdmin()
        {
            if (!PhienDangNhap.DaDangNhap) return "Phiên đăng nhập không hợp lệ. Vui lòng đăng nhập lại.";
            if (!PhienDangNhap.LaAdmin) return "Chỉ Quản trị viên mới có quyền phân quyền người dùng.";
            return null;
        }

        public static KetQuaPhanQuyen LayDanhSach()
        {
            string loiQuyen = KiemTraQuyenAdmin();
            if (loiQuyen != null) return Loi(loiQuyen);
            try
            {
                return new KetQuaPhanQuyen { ThanhCong = true, DuLieu = NguoiDungDL.LayDanhSach() };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại PhanQuyenNV.LayDanhSach", ex);
                return Loi("Lỗi khi tải danh sách người dùng: " + ex.Message);
            }
        }

        // thayDoi: MaND -> quyền mới. Xử lý nâng lên Admin trước, hạ quyền sau
        // để việc "đổi vai" giữa hai tài khoản không vi phạm quy tắc luôn còn ít nhất một Admin.
        public static KetQuaPhanQuyen LuuThayDoi(Dictionary<int, string> thayDoi)
        {
            string loiQuyen = KiemTraQuyenAdmin();
            if (loiQuyen != null) return Loi(loiQuyen);
            if (thayDoi == null || thayDoi.Count == 0) return Loi("Không có thay đổi nào để lưu.");

            var kq = new KetQuaPhanQuyen();
            var thuTu = thayDoi
                .OrderBy(x => string.Equals(x.Value, "Admin", StringComparison.OrdinalIgnoreCase) ? 0 : 1)
                .ToList();

            foreach (var muc in thuTu)
            {
                try
                {
                    string thongBao;
                    var nd = NguoiDungDL.LayTheoMaND(muc.Key);
                    string ten = nd != null ? nd.TenDangNhap : "MaND " + muc.Key;

                    if (TaiKhoanNV.DoiQuyenHan(muc.Key, muc.Value, out thongBao))
                    {
                        kq.SoThanhCong++;
                        NhatKyLoi.GhiLog($"Admin '{PhienDangNhap.TenDangNhap}' đổi quyền '{ten}' sang {muc.Value}.");
                    }
                    else
                    {
                        kq.DanhSachLoi.Add(ten + ": " + thongBao);
                    }
                }
                catch (Exception ex)
                {
                    NhatKyLoi.GhiLog("Lỗi tại PhanQuyenNV.LuuThayDoi", ex);
                    kq.DanhSachLoi.Add("MaND " + muc.Key + ": " + ex.Message);
                }
            }

            kq.ThanhCong = kq.DanhSachLoi.Count == 0;
            kq.ThongBao = kq.ThanhCong
                ? "Đã lưu phân quyền cho " + kq.SoThanhCong + " người dùng. Người dùng cần đăng nhập lại để áp dụng."
                : "Đã lưu " + kq.SoThanhCong + ", lỗi " + kq.DanhSachLoi.Count + " người dùng.";
            return kq;
        }
    }
}
