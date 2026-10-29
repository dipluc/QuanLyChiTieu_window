using System;
using System.Collections.Concurrent;
using System.Data;
using System.Data.SqlClient;
using DuLieu;
using MoHinh;
using NghiepVu.TienIch;

namespace NghiepVu
{
    public class KetQuaDangNhap
    {
        public bool ThanhCong { get; set; }
        public string ThongBao { get; set; }
        public int MaND { get; set; }
        public string TenDangNhap { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string QuyenHan { get; set; }
        public NguoiDungMH NguoiDung { get; set; }
    }

    public static class TaiKhoanNV
    {
        // Bộ nhớ tạm theo dõi đăng nhập sai (BR09: Đăng nhập sai 5 lần khóa 5 phút)
        private class ThongTinDangNhapSai
        {
            public int SoLanSai { get; set; }
            public DateTime? KhoaDenKhi { get; set; }
        }

        private static readonly ConcurrentDictionary<string, ThongTinDangNhapSai> _danhSachSai =
            new ConcurrentDictionary<string, ThongTinDangNhapSai>(StringComparer.OrdinalIgnoreCase);

        // Băm mật khẩu (dùng lớp BaoMat)
        public static string BamMatKhau(string input)
        {
            return BaoMat.BamMatKhau(input);
        }

        // ==========================================
        // 1. ĐĂNG NHẬP (Tuân thủ BR08, BR09)
        // ==========================================
        public static KetQuaDangNhap DangNhap(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                return new KetQuaDangNhap { ThanhCong = false, ThongBao = "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu." };
            }

            tenDangNhap = tenDangNhap.Trim();

            // Kiểm tra BR09: Có đang bị khóa tạm thời do sai 5 lần không?
            if (_danhSachSai.TryGetValue(tenDangNhap, out var track) && track.KhoaDenKhi.HasValue)
            {
                if (DateTime.Now < track.KhoaDenKhi.Value)
                {
                    var conLai = track.KhoaDenKhi.Value - DateTime.Now;
                    return new KetQuaDangNhap
                    {
                        ThanhCong = false,
                        ThongBao = string.Format("Tài khoản tạm thời bị khóa do nhập sai quá 5 lần. Vui lòng thử lại sau {0} phút {1} giây.",
                            (int)conLai.TotalMinutes, conLai.Seconds)
                    };
                }
                else
                {
                    // Đã hết thời gian phạt 5 phút -> Reset bộ đếm
                    _danhSachSai.TryRemove(tenDangNhap, out _);
                }
            }

            try
            {
                var nd = NguoiDungDL.LayTheoTenDangNhap(tenDangNhap);
                if (nd == null)
                {
                    GhiNhanDangNhapSai(tenDangNhap);
                    return new KetQuaDangNhap
                    {
                        ThanhCong = false,
                        ThongBao = "Tên đăng nhập không tồn tại trong hệ thống."
                    };
                }

                if (!nd.TrangThai)
                {
                    return new KetQuaDangNhap
                    {
                        ThanhCong = false,
                        ThongBao = "Tài khoản của bạn đã bị khóa bởi Quản trị viên."
                    };
                }

                // So khớp mật khẩu
                if (!BaoMat.SoKhopMatKhau(matKhau, nd.MatKhauHash))
                {
                    int soLan = GhiNhanDangNhapSai(tenDangNhap);
                    if (soLan >= 5)
                    {
                        return new KetQuaDangNhap
                        {
                            ThanhCong = false,
                            ThongBao = "Bạn đã nhập sai mật khẩu 5 lần liên tiếp. Tài khoản bị tạm khóa 5 phút!"
                        };
                    }

                    return new KetQuaDangNhap
                    {
                        ThanhCong = false,
                        ThongBao = $"Mật khẩu không chính xác. Bạn còn {5 - soLan} lần thử."
                    };
                }

                // Đăng nhập thành công -> Xóa bộ đếm sai
                _danhSachSai.TryRemove(tenDangNhap, out _);

                // Khởi tạo phiên làm việc toàn hệ thống
                PhienDangNhap.ThietLapPhien(nd);

                NhatKyLoi.GhiLog($"Người dùng '{nd.TenDangNhap}' đăng nhập thành công vào hệ thống.");

                return new KetQuaDangNhap
                {
                    ThanhCong = true,
                    ThongBao = "Đăng nhập thành công!",
                    MaND = nd.MaND,
                    TenDangNhap = nd.TenDangNhap,
                    HoTen = nd.HoTen,
                    Email = nd.Email,
                    QuyenHan = nd.QuyenHan,
                    NguoiDung = nd
                };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại TaiKhoanNV.DangNhap", ex);
                return new KetQuaDangNhap
                {
                    ThanhCong = false,
                    ThongBao = "Lỗi kết nối cơ sở dữ liệu: " + ex.Message
                };
            }
        }

        private static int GhiNhanDangNhapSai(string tenDangNhap)
        {
            var track = _danhSachSai.GetOrAdd(tenDangNhap, k => new ThongTinDangNhapSai());
            track.SoLanSai++;
            if (track.SoLanSai >= 5)
            {
                track.KhoaDenKhi = DateTime.Now.AddMinutes(5);
            }
            return track.SoLanSai;
        }

        // ==========================================
        // 2. ĐĂNG KÝ TÀI KHOẢN (Tuân thủ BR08, BR10)
        // ==========================================
        public static KetQuaDangNhap DangKy(string hoTen, string tenDangNhap, string email, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(hoTen))
                return new KetQuaDangNhap { ThanhCong = false, ThongBao = "Họ tên không được để trống." };

            if (string.IsNullOrWhiteSpace(tenDangNhap))
                return new KetQuaDangNhap { ThanhCong = false, ThongBao = "Tên đăng nhập không được để trống." };

            tenDangNhap = tenDangNhap.Trim();
            hoTen = hoTen.Trim();
            email = string.IsNullOrWhiteSpace(email) ? null : email.Trim();

            // Kiểm tra BR08
            if (!BaoMat.KiemTraDoManhMatKhau(matKhau, out string loiMatKhau))
            {
                return new KetQuaDangNhap { ThanhCong = false, ThongBao = loiMatKhau };
            }

            try
            {
                // Kiểm tra trùng tên đăng nhập
                if (NguoiDungDL.KiemTraTonTaiTenDangNhap(tenDangNhap))
                {
                    return new KetQuaDangNhap
                    {
                        ThanhCong = false,
                        ThongBao = "Tên đăng nhập đã tồn tại. Vui lòng chọn tên đăng nhập khác."
                    };
                }

                // Kiểm tra trùng email nếu có nhập
                if (!string.IsNullOrEmpty(email) && NguoiDungDL.KiemTraTonTaiEmail(email))
                {
                    return new KetQuaDangNhap
                    {
                        ThanhCong = false,
                        ThongBao = "Email này đã được sử dụng bởi một tài khoản khác."
                    };
                }

                // Băm mật khẩu
                string hash = BaoMat.BamMatKhau(matKhau);
                var nd = new NguoiDungMH
                {
                    TenDangNhap = tenDangNhap,
                    MatKhauHash = hash,
                    HoTen = hoTen,
                    Email = email,
                    QuyenHan = "User",
                    TrangThai = true,
                    NgayTao = DateTime.Now
                };

                int maNDMoi = NguoiDungDL.ThemNguoiDung(nd);
                if (maNDMoi <= 0)
                {
                    return new KetQuaDangNhap { ThanhCong = false, ThongBao = "Không thể thêm tài khoản vào cơ sở dữ liệu." };
                }

                nd.MaND = maNDMoi;

                // BR10: Khởi tạo dữ liệu mặc định cho tài khoản mới
                KhoiTaoDuLieuMacDinh(maNDMoi);

                NhatKyLoi.GhiLog($"Tạo tài khoản mới thành công: '{tenDangNhap}' (MaND: {maNDMoi})");

                return new KetQuaDangNhap
                {
                    ThanhCong = true,
                    ThongBao = "Đăng ký tài khoản thành công!",
                    MaND = maNDMoi,
                    TenDangNhap = tenDangNhap,
                    HoTen = hoTen,
                    Email = email,
                    QuyenHan = "User",
                    NguoiDung = nd
                };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại TaiKhoanNV.DangKy", ex);
                return new KetQuaDangNhap
                {
                    ThanhCong = false,
                    ThongBao = "Lỗi khi lưu vào cơ sở dữ liệu: " + ex.Message
                };
            }
        }

        // BR10: Tạo ví Tiền mặt, các loại thu, nhóm chi và loại chi phổ biến, bản ghi cấu hình
        private static void KhoiTaoDuLieuMacDinh(int maND)
        {
            try
            {
                // 1. Tạo ví Tiền mặt
                string sqlVi = "INSERT INTO ViTien (MaND, TenVi, LoaiVi, SoDuBanDau, GhiChu, TrangThai) VALUES (@MaND, N'Tiền mặt', 'TienMat', 0, N'Ví tiền mặt mặc định', 1)";
                KetNoiCSDL.ThucThiLenh(sqlVi, new SqlParameter("@MaND", maND));

                // 2. Tạo Loại thu mặc định
                string sqlThu = @"INSERT INTO LoaiThu (MaND, TenLoaiThu, GhiChu, TrangThai) VALUES 
                                  (@MaND, N'Tiền lương', N'Thu nhập từ lương hằng tháng', 1),
                                  (@MaND, N'Tiền thưởng', N'Thưởng dự án, thưởng tết', 1),
                                  (@MaND, N'Thu nhập phụ', N'Làm thêm, kinh doanh nhỏ', 1)";
                KetNoiCSDL.ThucThiLenh(sqlThu, new SqlParameter("@MaND", maND));

                // 3. Tạo Nhóm chi và Loại chi mặc định
                string sqlNhom1 = "INSERT INTO NhomChi (MaND, TenNhom, MauSac, TrangThai) VALUES (@MaND, N'Ăn uống', '#FF5722', 1); SELECT SCOPE_IDENTITY();";
                object idNhom1 = KetNoiCSDL.LayMotGiaTri(sqlNhom1, new SqlParameter("@MaND", maND));
                if (idNhom1 != null && idNhom1 != DBNull.Value)
                {
                    int maNhom1 = Convert.ToInt32(idNhom1);
                    string sqlChi1 = @"INSERT INTO LoaiChi (MaNhom, MaND, TenLoaiChi, GhiChu, TrangThai) VALUES 
                                       (@MaNhom, @MaND, N'Ăn sáng/trưa/tối', N'Bữa ăn thường ngày', 1),
                                       (@MaNhom, @MaND, N'Cà phê & Gặp bạn', N'Đi chơi giải khát', 1)";
                    KetNoiCSDL.ThucThiLenh(sqlChi1, new SqlParameter("@MaNhom", maNhom1), new SqlParameter("@MaND", maND));
                }

                string sqlNhom2 = "INSERT INTO NhomChi (MaND, TenNhom, MauSac, TrangThai) VALUES (@MaND, N'Đi lại', '#2196F3', 1); SELECT SCOPE_IDENTITY();";
                object idNhom2 = KetNoiCSDL.LayMotGiaTri(sqlNhom2, new SqlParameter("@MaND", maND));
                if (idNhom2 != null && idNhom2 != DBNull.Value)
                {
                    int maNhom2 = Convert.ToInt32(idNhom2);
                    string sqlChi2 = @"INSERT INTO LoaiChi (MaNhom, MaND, TenLoaiChi, GhiChu, TrangThai) VALUES 
                                       (@MaNhom, @MaND, N'Xăng xe & Gửi xe', N'Chi phí phương tiện', 1)";
                    KetNoiCSDL.ThucThiLenh(sqlChi2, new SqlParameter("@MaNhom", maNhom2), new SqlParameter("@MaND", maND));
                }

                // 4. Tạo bản ghi Cấu hình mặc định
                string sqlCauHinh = "INSERT INTO CauHinh (MaND, ThuMucSaoLuu, NguongCanhBao, TuDongSaoLuu) VALUES (@MaND, N'', 80, 0)";
                KetNoiCSDL.ThucThiLenh(sqlCauHinh, new SqlParameter("@MaND", maND));
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi khởi tạo dữ liệu mặc định BR10 cho MaND=" + maND, ex);
            }
        }

        // ==========================================
        // 3. ĐỔI MẬT KHẨU
        // ==========================================
        public static KetQuaDangNhap DoiMatKhau(string tenDangNhap, string matKhauCu, string matKhauMoi)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap))
                return new KetQuaDangNhap { ThanhCong = false, ThongBao = "Tên đăng nhập không được để trống." };

            if (string.IsNullOrEmpty(matKhauCu))
                return new KetQuaDangNhap { ThanhCong = false, ThongBao = "Vui lòng nhập mật khẩu cũ." };

            if (matKhauCu == matKhauMoi)
                return new KetQuaDangNhap { ThanhCong = false, ThongBao = "Mật khẩu mới phải khác mật khẩu hiện tại." };

            // Kiểm tra BR08 cho mật khẩu mới
            if (!BaoMat.KiemTraDoManhMatKhau(matKhauMoi, out string loiMatKhau))
            {
                return new KetQuaDangNhap { ThanhCong = false, ThongBao = loiMatKhau };
            }

            try
            {
                var nd = NguoiDungDL.LayTheoTenDangNhap(tenDangNhap.Trim());
                if (nd == null)
                {
                    return new KetQuaDangNhap { ThanhCong = false, ThongBao = "Tài khoản không tồn tại." };
                }

                if (!BaoMat.SoKhopMatKhau(matKhauCu, nd.MatKhauHash))
                {
                    return new KetQuaDangNhap { ThanhCong = false, ThongBao = "Mật khẩu cũ không chính xác." };
                }

                string hashMoi = BaoMat.BamMatKhau(matKhauMoi);
                bool thanhCong = NguoiDungDL.CapNhatMatKhau(nd.MaND, hashMoi);
                if (thanhCong)
                {
                    NhatKyLoi.GhiLog($"Người dùng '{tenDangNhap}' đã đổi mật khẩu thành công.");
                    return new KetQuaDangNhap { ThanhCong = true, ThongBao = "Đổi mật khẩu thành công!" };
                }

                return new KetQuaDangNhap { ThanhCong = false, ThongBao = "Không thể cập nhật mật khẩu vào cơ sở dữ liệu." };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại TaiKhoanNV.DoiMatKhau", ex);
                return new KetQuaDangNhap { ThanhCong = false, ThongBao = "Lỗi khi cập nhật mật khẩu: " + ex.Message };
            }
        }

        // ==========================================
        // 4. CẬP NHẬT THÔNG TIN CÁ NHÂN
        // ==========================================
        public static KetQuaDangNhap CapNhatThongTin(string tenDangNhap, string hoTen, string email)
        {
            if (string.IsNullOrWhiteSpace(hoTen))
                return new KetQuaDangNhap { ThanhCong = false, ThongBao = "Họ tên không được để trống." };

            tenDangNhap = tenDangNhap.Trim();
            hoTen = hoTen.Trim();
            email = string.IsNullOrWhiteSpace(email) ? null : email.Trim();

            try
            {
                var nd = NguoiDungDL.LayTheoTenDangNhap(tenDangNhap);
                if (nd == null)
                {
                    return new KetQuaDangNhap { ThanhCong = false, ThongBao = "Không tìm thấy người dùng để cập nhật." };
                }

                if (!string.IsNullOrEmpty(email) && NguoiDungDL.KiemTraTonTaiEmail(email, nd.MaND))
                {
                    return new KetQuaDangNhap { ThanhCong = false, ThongBao = "Email này đã được sử dụng bởi một tài khoản khác." };
                }

                bool thanhCong = NguoiDungDL.CapNhatThongTin(nd.MaND, hoTen, email);
                if (thanhCong)
                {
                    // Cập nhật phiên đăng nhập hiện tại nếu đang đăng nhập đúng tài khoản này
                    if (PhienDangNhap.MaND == nd.MaND)
                    {
                        PhienDangNhap.CapNhatThongTin(hoTen, email);
                    }

                    return new KetQuaDangNhap
                    {
                        ThanhCong = true,
                        ThongBao = "Cập nhật thông tin cá nhân thành công!",
                        TenDangNhap = tenDangNhap,
                        HoTen = hoTen,
                        Email = email
                    };
                }

                return new KetQuaDangNhap { ThanhCong = false, ThongBao = "Không thể cập nhật thông tin." };
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại TaiKhoanNV.CapNhatThongTin", ex);
                return new KetQuaDangNhap { ThanhCong = false, ThongBao = "Lỗi cập nhật dữ liệu: " + ex.Message };
            }
        }

        // ==========================================
        // 5. LẤY THÔNG TIN THEO TÊN ĐĂNG NHẬP
        // ==========================================
        public static KetQuaDangNhap LayThongTin(string tenDangNhap)
        {
            try
            {
                var nd = NguoiDungDL.LayTheoTenDangNhap(tenDangNhap.Trim());
                if (nd != null)
                {
                    return new KetQuaDangNhap
                    {
                        ThanhCong = true,
                        MaND = nd.MaND,
                        TenDangNhap = nd.TenDangNhap,
                        HoTen = nd.HoTen,
                        Email = nd.Email,
                        QuyenHan = nd.QuyenHan,
                        NguoiDung = nd
                    };
                }
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại TaiKhoanNV.LayThongTin", ex);
            }

            return new KetQuaDangNhap { ThanhCong = false, ThongBao = "Không tìm thấy thông tin tài khoản." };
        }

        // ==========================================
        // 6. QUẢN TRỊ TÀI KHOẢN (Tuân thủ BR11)
        // ==========================================
        public static bool KhoaMoKhoa(int maND, bool trangThaiMoi, out string thongBao)
        {
            try
            {
                // BR11: Admin không thể tự khóa chính mình
                if (PhienDangNhap.MaND == maND && !trangThaiMoi)
                {
                    thongBao = "Bạn không thể tự khóa tài khoản của chính mình.";
                    return false;
                }

                var nd = NguoiDungDL.LayTheoMaND(maND);
                if (nd == null)
                {
                    thongBao = "Không tìm thấy người dùng.";
                    return false;
                }

                // Nếu khóa một Admin -> kiểm tra xem còn ít nhất 1 admin hoạt động không
                if (string.Equals(nd.QuyenHan, "Admin", StringComparison.OrdinalIgnoreCase) && !trangThaiMoi)
                {
                    if (NguoiDungDL.DemAdminHoatDong() <= 1)
                    {
                        thongBao = "Hệ thống phải có ít nhất một Quản trị viên hoạt động. Không thể khóa tài khoản này.";
                        return false;
                    }
                }

                bool kq = NguoiDungDL.KhoaMoKhoaTaiKhoan(maND, trangThaiMoi);
                thongBao = kq ? (trangThaiMoi ? "Mở khóa tài khoản thành công." : "Đã khóa tài khoản.") : "Thao tác thất bại.";
                return kq;
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại TaiKhoanNV.KhoaMoKhoa", ex);
                thongBao = "Lỗi hệ thống: " + ex.Message;
                return false;
            }
        }

        public static bool DoiQuyenHan(int maND, string quyenHanMoi, out string thongBao)
        {
            try
            {
                // BR11: Admin không thể tự hạ quyền chính mình
                if (PhienDangNhap.MaND == maND && !string.Equals(quyenHanMoi, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    thongBao = "Bạn không thể tự hạ quyền Quản trị của chính mình.";
                    return false;
                }

                var nd = NguoiDungDL.LayTheoMaND(maND);
                if (nd == null)
                {
                    thongBao = "Không tìm thấy người dùng.";
                    return false;
                }

                if (string.Equals(nd.QuyenHan, "Admin", StringComparison.OrdinalIgnoreCase) && !string.Equals(quyenHanMoi, "Admin", StringComparison.OrdinalIgnoreCase))
                {
                    if (NguoiDungDL.DemAdminHoatDong() <= 1)
                    {
                        thongBao = "Hệ thống phải có ít nhất một Quản trị viên hoạt động. Không thể hạ quyền tài khoản này.";
                        return false;
                    }
                }

                bool kq = NguoiDungDL.CapNhatQuyenHan(maND, quyenHanMoi);
                thongBao = kq ? $"Đã đổi quyền thành công sang {quyenHanMoi}." : "Thao tác thất bại.";
                return kq;
            }
            catch (Exception ex)
            {
                NhatKyLoi.GhiLog("Lỗi tại TaiKhoanNV.DoiQuyenHan", ex);
                thongBao = "Lỗi hệ thống: " + ex.Message;
                return false;
            }
        }
    }
}
