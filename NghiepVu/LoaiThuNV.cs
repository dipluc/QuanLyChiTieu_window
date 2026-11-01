using System;
using System.Data;
using DuLieu;
using MoHinh;
using NghiepVu.TienIch;

namespace NghiepVu
{
    // Lưu ý: lớp KetQuaThaoTac đã được khai báo trong ViTienNV.cs (namespace NghiepVu)
    public static class LoaiThuNV
    {
        public static DataTable LayDanhSach(out string thongBaoLoi)
        {
            thongBaoLoi = null;
            try
            {
                return LoaiThuDL.LayDanhSach(PhienDangNhap.MaND);
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại LoaiThuNV.LayDanhSach", ex);
                thongBaoLoi = "Không thể tải danh sách loại thu nhập: " + ex.Message;
                return new DataTable();
            }
        }

        public static KetQuaThaoTac Them(string tenLoaiThu, string ghiChu, bool trangThai)
        {
            if (string.IsNullOrWhiteSpace(tenLoaiThu))
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Bạn phải nhập tên loại thu nhập." };

            try
            {
                tenLoaiThu = tenLoaiThu.Trim();
                if (LoaiThuDL.KiemTraTonTaiTen(PhienDangNhap.MaND, tenLoaiThu))
                    return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Tên loại thu nhập này đã tồn tại, vui lòng nhập tên khác." };

                int ma = LoaiThuDL.Them(new LoaiThuMH
                {
                    MaND = PhienDangNhap.MaND,
                    TenLoaiThu = tenLoaiThu,
                    GhiChu = string.IsNullOrWhiteSpace(ghiChu) ? null : ghiChu.Trim(),
                    TrangThai = trangThai
                });
                if (ma > 0)
                    return new KetQuaThaoTac { ThanhCong = true, ThongBao = "Thêm loại thu nhập thành công!", Ma = ma };

                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Không thể thêm loại thu nhập." };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại LoaiThuNV.Them", ex);
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Lỗi khi lưu vào cơ sở dữ liệu: " + ex.Message };
            }
        }

        public static KetQuaThaoTac Sua(int maLoaiThu, string tenLoaiThu, string ghiChu, bool trangThai)
        {
            if (maLoaiThu <= 0)
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Bạn chưa chọn loại thu nhập nào." };
            if (string.IsNullOrWhiteSpace(tenLoaiThu))
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Bạn phải nhập tên loại thu nhập." };

            try
            {
                tenLoaiThu = tenLoaiThu.Trim();
                if (LoaiThuDL.KiemTraTonTaiTen(PhienDangNhap.MaND, tenLoaiThu, maLoaiThu))
                    return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Tên loại thu nhập này đã được dùng cho loại khác." };

                bool ok = LoaiThuDL.CapNhat(new LoaiThuMH
                {
                    MaLoaiThu = maLoaiThu,
                    MaND = PhienDangNhap.MaND,
                    TenLoaiThu = tenLoaiThu,
                    GhiChu = string.IsNullOrWhiteSpace(ghiChu) ? null : ghiChu.Trim(),
                    TrangThai = trangThai
                });
                if (ok)
                    return new KetQuaThaoTac { ThanhCong = true, ThongBao = "Cập nhật loại thu nhập thành công!", Ma = maLoaiThu };

                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Không tìm thấy loại thu nhập để cập nhật." };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại LoaiThuNV.Sua", ex);
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Lỗi cập nhật dữ liệu: " + ex.Message };
            }
        }

        public static KetQuaThaoTac Xoa(int maLoaiThu)
        {
            if (maLoaiThu <= 0)
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Bạn chưa chọn loại thu nhập nào." };

            try
            {
                if (LoaiThuDL.DemBanGhiLienQuan(maLoaiThu) > 0)
                    return new KetQuaThaoTac
                    {
                        ThanhCong = false,
                        ThongBao = "Loại thu nhập này đã được sử dụng nên không thể xóa.\nBạn có thể bỏ chọn \"Đang sử dụng\" rồi bấm Sửa để ngưng dùng."
                    };

                if (LoaiThuDL.Xoa(maLoaiThu, PhienDangNhap.MaND))
                    return new KetQuaThaoTac { ThanhCong = true, ThongBao = "Đã xóa loại thu nhập.", Ma = maLoaiThu };

                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Không tìm thấy loại thu nhập để xóa." };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại LoaiThuNV.Xoa", ex);
                return new KetQuaThaoTac { ThanhCong = false, ThongBao = "Lỗi khi xóa dữ liệu: " + ex.Message };
            }
        }
    }
}
