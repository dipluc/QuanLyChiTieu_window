using System;
using System.Collections.Generic;
using DuLieu;
using MoHinh;
using NghiepVu.TienIch;

namespace NghiepVu
{
    public class KetQuaMucTieu
    {
        public bool ThanhCong { get; set; }
        public string ThongBao { get; set; }
        public int MaMT { get; set; }
    }

    public static class MucTieuNV
    {
        // Mã lưu trong CSDL (Key) và nhãn hiển thị (Value)
        public static readonly KeyValuePair<string, string>[] DanhSachTrangThai =
        {
            new KeyValuePair<string, string>("DangThucHien", "Đang thực hiện"),
            new KeyValuePair<string, string>("HoanThanh", "Hoàn thành"),
            new KeyValuePair<string, string>("Huy", "Đã hủy")
        };

        public static string TenTrangThai(string ma)
        {
            foreach (var kv in DanhSachTrangThai) if (kv.Key == ma) return kv.Value;
            return ma;
        }

        private static bool TrangThaiHopLe(string ma)
        {
            foreach (var kv in DanhSachTrangThai) if (kv.Key == ma) return true;
            return false;
        }

        // Trạng thái tự cập nhật theo số tiền đã tiết kiệm (trừ khi đã hủy)
        private static string TinhTrangThai(string trangThaiChon, decimal mucTieu, decimal daTietKiem)
        {
            if (trangThaiChon == "Huy") return "Huy";
            return daTietKiem >= mucTieu ? "HoanThanh" : "DangThucHien";
        }

        // ==========================================
        // TRUY VẤN
        // ==========================================
        public static List<MucTieuMH> LayDanhSach()
        {
            try
            {
                return MucTieuDL.LayDanhSach(PhienDangNhap.MaND);
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại MucTieuNV.LayDanhSach", ex);
                return new List<MucTieuMH>();
            }
        }

        // ==========================================
        // KIỂM TRA HỢP LỆ
        // ==========================================
        private static string KiemTraHopLe(MucTieuMH mt)
        {
            if (string.IsNullOrWhiteSpace(mt.TenMucTieu))
                return "Bạn phải nhập tên mục tiêu.";
            if (mt.SoTienMucTieu <= 0)
                return "Số tiền mục tiêu phải lớn hơn 0.";
            if (mt.NgayDich.HasValue && mt.NgayDich.Value.Date <= mt.NgayBatDau.Date)
                return "Ngày đích phải sau ngày bắt đầu.";
            if (!TrangThaiHopLe(mt.TrangThai))
                return "Trạng thái không hợp lệ.";
            return null;
        }

        private static void ChuanHoa(MucTieuMH mt)
        {
            mt.MaND = PhienDangNhap.MaND;
            mt.TenMucTieu = (mt.TenMucTieu ?? string.Empty).Trim();
            mt.GhiChu = string.IsNullOrWhiteSpace(mt.GhiChu) ? null : mt.GhiChu.Trim();
        }

        // ==========================================
        // THÊM / SỬA / XÓA / NẠP TIỀN
        // ==========================================
        public static KetQuaMucTieu Them(MucTieuMH mt)
        {
            if (!PhienDangNhap.DaDangNhap)
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Bạn chưa đăng nhập." };

            ChuanHoa(mt);
            mt.SoTienDaTietKiem = 0;
            mt.TrangThai = "DangThucHien";
            string loi = KiemTraHopLe(mt);
            if (loi != null)
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = loi };

            try
            {
                if (MucTieuDL.KiemTraTrungTen(mt.MaND, mt.TenMucTieu))
                    return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Tên mục tiêu này đã tồn tại, bạn phải nhập tên khác." };

                int id = MucTieuDL.Them(mt);
                if (id > 0)
                {
                    NhatKyLoi.GhiLog($"Người dùng '{PhienDangNhap.TenDangNhap}' thêm mục tiêu tiết kiệm #{id}.");
                    return new KetQuaMucTieu { ThanhCong = true, ThongBao = "Thêm mục tiêu tiết kiệm thành công!", MaMT = id };
                }
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Không thể thêm mục tiêu tiết kiệm." };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại MucTieuNV.Them", ex);
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Lỗi lưu dữ liệu: " + ex.Message };
            }
        }

        public static KetQuaMucTieu Sua(MucTieuMH mt)
        {
            if (!PhienDangNhap.DaDangNhap)
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Bạn chưa đăng nhập." };
            if (mt.MaMT <= 0)
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Bạn chưa chọn bản ghi nào." };

            ChuanHoa(mt);
            string loi = KiemTraHopLe(mt);
            if (loi != null)
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = loi };

            try
            {
                var hienTai = MucTieuDL.LayTheoMa(mt.MaMT, mt.MaND);
                if (hienTai == null)
                    return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Không tìm thấy mục tiêu để cập nhật." };

                if (MucTieuDL.KiemTraTrungTen(mt.MaND, mt.TenMucTieu, mt.MaMT))
                    return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Tên mục tiêu này đã tồn tại, bạn phải nhập tên khác." };

                mt.TrangThai = TinhTrangThai(mt.TrangThai, mt.SoTienMucTieu, hienTai.SoTienDaTietKiem);

                if (MucTieuDL.Sua(mt))
                {
                    NhatKyLoi.GhiLog($"Người dùng '{PhienDangNhap.TenDangNhap}' sửa mục tiêu tiết kiệm #{mt.MaMT}.");
                    return new KetQuaMucTieu { ThanhCong = true, ThongBao = "Cập nhật mục tiêu tiết kiệm thành công!", MaMT = mt.MaMT };
                }
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Không thể cập nhật mục tiêu tiết kiệm." };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại MucTieuNV.Sua", ex);
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Lỗi cập nhật dữ liệu: " + ex.Message };
            }
        }

        public static KetQuaMucTieu Xoa(int maMT)
        {
            if (!PhienDangNhap.DaDangNhap)
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Bạn chưa đăng nhập." };
            if (maMT <= 0)
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Bạn chưa chọn bản ghi nào." };

            try
            {
                if (MucTieuDL.Xoa(maMT, PhienDangNhap.MaND))
                {
                    NhatKyLoi.GhiLog($"Người dùng '{PhienDangNhap.TenDangNhap}' xóa mục tiêu tiết kiệm #{maMT}.");
                    return new KetQuaMucTieu { ThanhCong = true, ThongBao = "Đã xóa mục tiêu tiết kiệm.", MaMT = maMT };
                }
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Không tìm thấy mục tiêu để xóa." };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại MucTieuNV.Xoa", ex);
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Không thể xóa: " + ex.Message };
            }
        }

        // Nạp thêm tiền vào mục tiêu (cộng vào SoTienDaTietKiem)
        public static KetQuaMucTieu NapTien(int maMT, decimal soTien)
        {
            if (!PhienDangNhap.DaDangNhap)
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Bạn chưa đăng nhập." };
            if (maMT <= 0)
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Bạn hãy chọn một mục tiêu trong lưới trước." };
            if (soTien <= 0)
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Số tiền nạp phải lớn hơn 0." };

            try
            {
                var mt = MucTieuDL.LayTheoMa(maMT, PhienDangNhap.MaND);
                if (mt == null)
                    return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Không tìm thấy mục tiêu." };
                if (mt.TrangThai == "Huy")
                    return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Mục tiêu đã hủy, không thể nạp thêm tiền." };

                if (MucTieuDL.CongTienDaTietKiem(maMT, PhienDangNhap.MaND, soTien))
                {
                    NhatKyLoi.GhiLog($"Người dùng '{PhienDangNhap.TenDangNhap}' nạp {soTien:N0} vào mục tiêu #{maMT}.");
                    return new KetQuaMucTieu { ThanhCong = true, ThongBao = "Đã nạp " + soTien.ToString("N0") + " vào mục tiêu.", MaMT = maMT };
                }
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Không thể nạp tiền vào mục tiêu." };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại MucTieuNV.NapTien", ex);
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Lỗi nạp tiền: " + ex.Message };
            }
        }
        // Rút bớt tiền khỏi mục tiêu
        public static KetQuaMucTieu RutTien(int maMT, decimal soTien)
        {
            if (!PhienDangNhap.DaDangNhap)
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Bạn chưa đăng nhập." };
            if (maMT <= 0)
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Bạn hãy chọn một mục tiêu trong lưới trước." };
            if (soTien <= 0)
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Số tiền rút phải lớn hơn 0." };

            try
            {
                var mt = MucTieuDL.LayTheoMa(maMT, PhienDangNhap.MaND);
                if (mt == null)
                    return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Không tìm thấy mục tiêu." };
                if (mt.TrangThai == "Huy")
                    return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Mục tiêu đã hủy, không thể rút tiền." };
                if (soTien > mt.SoTienDaTietKiem)
                    return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Số tiền rút vượt quá số đã tiết kiệm (" + mt.SoTienDaTietKiem.ToString("N0") + ")." };

                if (MucTieuDL.TruTienDaTietKiem(maMT, PhienDangNhap.MaND, soTien))
                {
                    NhatKyLoi.GhiLog($"Người dùng '{PhienDangNhap.TenDangNhap}' rút {soTien:N0} khỏi mục tiêu #{maMT}.");
                    return new KetQuaMucTieu { ThanhCong = true, ThongBao = "Đã rút " + soTien.ToString("N0") + " khỏi mục tiêu.", MaMT = maMT };
                }
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Không thể rút tiền khỏi mục tiêu." };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại MucTieuNV.RutTien", ex);
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Lỗi rút tiền: " + ex.Message };
            }
        }

        // Hủy mục tiêu: hoàn lại số đã tiết kiệm (đưa về 0) và đổi trạng thái sang Đã hủy
        public static KetQuaMucTieu HuyMucTieu(int maMT)
        {
            if (!PhienDangNhap.DaDangNhap)
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Bạn chưa đăng nhập." };
            if (maMT <= 0)
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Bạn chưa chọn mục tiêu nào." };

            try
            {
                var mt = MucTieuDL.LayTheoMa(maMT, PhienDangNhap.MaND);
                if (mt == null)
                    return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Không tìm thấy mục tiêu." };
                if (mt.TrangThai == "Huy")
                    return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Mục tiêu này đã được hủy trước đó." };

                decimal hoan = mt.SoTienDaTietKiem;
                if (MucTieuDL.Huy(maMT, PhienDangNhap.MaND))
                {
                    NhatKyLoi.GhiLog($"Người dùng '{PhienDangNhap.TenDangNhap}' hủy mục tiêu #{maMT}, hoàn {hoan:N0}.");
                    return new KetQuaMucTieu
                    {
                        ThanhCong = true,
                        MaMT = maMT,
                        ThongBao = "Đã hủy mục tiêu. Đã hoàn " + hoan.ToString("N0") + " ₫ về ví."
                    };
                }
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Không thể hủy mục tiêu." };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại MucTieuNV.HuyMucTieu", ex);
                return new KetQuaMucTieu { ThanhCong = false, ThongBao = "Lỗi hủy mục tiêu: " + ex.Message };
            }
        }
    }
}
