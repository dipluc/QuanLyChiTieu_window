using System;
using System.Collections.Generic;
using System.Data;
using DuLieu;
using MoHinh;
using NghiepVu.TienIch;

namespace NghiepVu
{
    // Kết quả chung cho các thao tác thêm / sửa / xóa
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

        // Danh sách loại ví (giá trị lưu CSDL, tên hiển thị) - khớp ràng buộc CK_ViTien_LoaiVi
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

        // Danh sách ví của người dùng đang đăng nhập
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
            var kt = KiemTraDuLieu(tenVi, loaiVi, soDuBanDau);
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

        public static KetQuaThaoTac Sua(int maVi, string tenVi, string loaiVi, decimal soDuBanDau, string ghiChu, bool trangThai)
        {
            if (maVi <= 0)
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Bạn chưa chọn ví nào." };

            var kt = KiemTraDuLieu(tenVi, loaiVi, soDuBanDau);
            if (kt != null) return kt;

            try
            {
                tenVi = tenVi.Trim();
                if (ViTienDL.KiemTraTonTaiTenVi(PhienDangNhap.MaND, tenVi, maVi))
                    return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Tên ví này đã được dùng cho ví khác." };

                // Phải còn ít nhất một ví đang sử dụng để ghi nhận giao dịch
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
                    return new KetQuaThaoTac { ThanhCong = true, ThongBao = "Cập nhật ví tiền thành công!", Ma = maVi };

                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Không tìm thấy ví để cập nhật." };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại ViTienNV.Sua", ex);
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Lỗi cập nhật dữ liệu: " + ex.Message };
            }
        }

        public static KetQuaThaoTac Xoa(int maVi)
        {
            if (maVi <= 0)
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Bạn chưa chọn ví nào." };

            try
            {
                if (ViTienDL.DemBanGhiLienQuan(maVi) > 0)
                    return new KetQuaThaoTac
                    {
                        ThanhCong = false,
                        ThongBao = "Ví này đã phát sinh giao dịch nên không thể xóa.\nBạn có thể bỏ chọn \"Đang sử dụng\" rồi bấm Sửa để ngưng dùng ví."
                    };

                ViTienMH hienTai = ViTienDL.LayTheoMaVi(maVi, PhienDangNhap.MaND);
                if (hienTai != null && hienTai.TrangThai && ViTienDL.DemViDangSuDung(PhienDangNhap.MaND) <= 1)
                    return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Bạn phải giữ lại ít nhất một ví đang sử dụng." };

                if (ViTienDL.Xoa(maVi, PhienDangNhap.MaND))
                    return new KetQuaThaoTac { ThanhCong = true, ThongBao = "Đã xóa ví tiền.", Ma = maVi };

                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Không tìm thấy ví để xóa." };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại ViTienNV.Xoa", ex);
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Lỗi khi xóa dữ liệu: " + ex.Message };
            }
        }

        // Trả về null nếu hợp lệ, ngược lại trả về kết quả lỗi
        private static KetQuaThaoTac KiemTraDuLieu(string tenVi, string loaiVi, decimal soDuBanDau)
        {
            if (string.IsNullOrWhiteSpace(tenVi))
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Bạn phải nhập tên ví." };
            if (Array.IndexOf(_maLoaiVi, loaiVi) < 0)
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Bạn phải chọn loại ví." };
            if (soDuBanDau < 0)
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Số dư ban đầu không được âm." };
            return null;
        }
    }
}
