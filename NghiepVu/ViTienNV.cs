using System;
using System.Collections.Generic;
using System.Data;
using DuLieu;
using MoHinh;
using NghiepVu.TienIch;

namespace NghiepVu
{
    public class KetQuaThaoTac
    {
        public bool ThanhCong { get; set; }
        public string ThongBao { get; set; }
        public int Ma { get; set; }
    }

    public static class ViTienNV
    {
        private static readonly string[] _maLoaiVi = { "TienMat", "NganHang", "ViDienTu", "TheTinDung" };
        private static readonly string[] _tenLoaiVi = { "Tiền mặt", "Ngân hàng", "Ví điện tử", "Thẻ tín dụng" };

        public static List<KeyValuePair<string, string>> LayDanhSachLoaiVi()
        {
            var ds = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < _maLoaiVi.Length; i++)
            {
                ds.Add(new KeyValuePair<string, string>(_maLoaiVi[i], _tenLoaiVi[i]));
            }
            return ds;
        }

        public static string TenLoaiVi(string maLoaiVi)
        {
            int i = Array.IndexOf(_maLoaiVi, maLoaiVi);
            return i >= 0 ? _tenLoaiVi[i] : maLoaiVi;
        }

        public static DataTable LayDanhSach(out string thongBaoLoi)
        {
            thongBaoLoi = null;
            try
            {
                return ViTienDL.LayDanhSach(PhienDangNhap.MaND);
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại ViTienNV.LayDanhSach", ex);
                thongBaoLoi = "Không thể tải danh sách ví: " + ex.Message;
                return new DataTable();
            }
        }

        public static KetQuaThaoTac Them(string tenVi, string loaiVi, decimal soDuBanDau, string ghiChu, bool trangThai)
        {
            // Ví mới: số dư ban đầu không được âm
            var kt = KiemTraDuLieu(tenVi, loaiVi, soDuBanDau, false);
            if (kt != null) return kt;

            try
            {
                tenVi = tenVi.Trim();
                if (ViTienDL.KiemTraTonTaiTenVi(PhienDangNhap.MaND, tenVi))
                    return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Tên ví này đã tồn tại, vui lòng nhập tên khác." };

                var vi = new ViTienMH
                {
                    MaND = PhienDangNhap.MaND,
                    TenVi = tenVi,
                    LoaiVi = loaiVi,
                    SoDuBanDau = soDuBanDau,
                    GhiChu = string.IsNullOrWhiteSpace(ghiChu) ? null : ghiChu.Trim(),
                    TrangThai = trangThai
                };
                int maVi = ViTienDL.ThemViTien(vi);
                if (maVi > 0)
                    return new KetQuaThaoTac { ThanhCong = true, ThongBao = "Thêm ví tiền thành công!", Ma = maVi };

                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Không thể thêm ví tiền." };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại ViTienNV.Them", ex);
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Lỗi khi lưu vào cơ sở dữ liệu: " + ex.Message };
            }
        }

        // Sửa ví theo SỐ DƯ BAN ĐẦU do người dùng nhập
        public static KetQuaThaoTac Sua(int maVi, string tenVi, string loaiVi, decimal soDuBanDau, string ghiChu, bool trangThai)
        {
            return LuuCapNhat(maVi, tenVi, loaiVi, soDuBanDau, ghiChu, trangThai, string.Empty);
        }

        // Sửa ví theo SỐ DƯ HIỆN TẠI người dùng muốn có.
        // Số dư hiện tại = số dư ban đầu + biến động giao dịch (thu - chi + chuyển đến - chuyển đi),
        // nên số dư ban đầu mới = số dư hiện tại muốn có - biến động giao dịch.
        public static KetQuaThaoTac SuaTheoSoDuHienTai(int maVi, string tenVi, string loaiVi, decimal soDuHienTaiMoi, string ghiChu, bool trangThai)
        {
            if (maVi <= 0)
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Bạn chưa chọn ví nào." };

            try
            {
                ViTienMH hienCo = ViTienDL.LayTheoMaVi(maVi, PhienDangNhap.MaND);
                if (hienCo == null)
                    return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Không tìm thấy ví để cập nhật." };

                decimal bienDong = hienCo.SoDuHienTai - hienCo.SoDuBanDau;
                decimal soDuBanDauMoi = soDuHienTaiMoi - bienDong;
                string ghiThem = " Số dư ban đầu được điều chỉnh thành " + soDuBanDauMoi.ToString("N0") + ".";

                return LuuCapNhat(maVi, tenVi, loaiVi, soDuBanDauMoi, ghiChu, trangThai, ghiThem);
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại ViTienNV.SuaTheoSoDuHienTai", ex);
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Lỗi cập nhật dữ liệu: " + ex.Message };
            }
        }

        // Chỉ đổi trạng thái sử dụng, giữ nguyên mọi thông tin khác của ví
        public static KetQuaThaoTac DatTrangThai(int maVi, bool trangThai)
        {
            if (maVi <= 0)
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Bạn chưa chọn ví nào." };

            try
            {
                ViTienMH hienCo = ViTienDL.LayTheoMaVi(maVi, PhienDangNhap.MaND);
                if (hienCo == null)
                    return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Không tìm thấy ví để cập nhật." };

                var kq = LuuCapNhat(maVi, hienCo.TenVi, hienCo.LoaiVi, hienCo.SoDuBanDau, hienCo.GhiChu, trangThai, string.Empty);
                if (kq.ThanhCong)
                {
                    kq.ThongBao = trangThai
                        ? "Đã chuyển ví sang trạng thái đang sử dụng."
                        : "Đã chuyển ví sang trạng thái ngừng sử dụng.";
                }
                return kq;
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại ViTienNV.DatTrangThai", ex);
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Lỗi cập nhật dữ liệu: " + ex.Message };
            }
        }

        // Lõi cập nhật ví (ghi đầy đủ các cột, gồm cả TrangThai).
        // Số dư ban đầu của ví đang sửa được phép âm: đó là mức điều chỉnh để số dư hiện tại khớp thực tế.
        private static KetQuaThaoTac LuuCapNhat(int maVi, string tenVi, string loaiVi, decimal soDuBanDau,
            string ghiChu, bool trangThai, string ghiThem)
        {
            if (maVi <= 0)
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Bạn chưa chọn ví nào." };

            var kt = KiemTraDuLieu(tenVi, loaiVi, soDuBanDau, true);
            if (kt != null) return kt;

            try
            {
                tenVi = tenVi.Trim();
                if (ViTienDL.KiemTraTonTaiTenVi(PhienDangNhap.MaND, tenVi, maVi))
                    return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Tên ví này đã được dùng cho ví khác." };

                if (!trangThai)
                {
                    ViTienMH hienTai = ViTienDL.LayTheoMaVi(maVi, PhienDangNhap.MaND);
                    if (hienTai != null && hienTai.TrangThai && ViTienDL.DemViDangSuDung(PhienDangNhap.MaND) <= 1)
                        return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Bạn phải giữ lại ít nhất một ví đang sử dụng." };
                }

                var vi = new ViTienMH
                {
                    MaVi = maVi,
                    MaND = PhienDangNhap.MaND,
                    TenVi = tenVi,
                    LoaiVi = loaiVi,
                    SoDuBanDau = soDuBanDau,
                    GhiChu = string.IsNullOrWhiteSpace(ghiChu) ? null : ghiChu.Trim(),
                    TrangThai = trangThai
                };
                if (ViTienDL.CapNhat(vi))
                    return new KetQuaThaoTac { ThanhCong = true, ThongBao = "Cập nhật ví tiền thành công!" + ghiThem, Ma = maVi };

                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Không tìm thấy ví để cập nhật." };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại ViTienNV.Sua", ex);
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Lỗi cập nhật dữ liệu: " + ex.Message };
            }
        }

        private static KetQuaThaoTac KiemTraDuLieu(string tenVi, string loaiVi, decimal soDuBanDau, bool choPhepSoDuAm)
        {
            if (string.IsNullOrWhiteSpace(tenVi))
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Bạn phải nhập tên ví." };
            if (Array.IndexOf(_maLoaiVi, loaiVi) < 0)
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Bạn phải chọn loại ví." };
            if (!choPhepSoDuAm && soDuBanDau < 0)
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Số dư ban đầu không được âm." };
            return null;
        }
    }
}
