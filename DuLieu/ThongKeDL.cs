using MoHinh;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace DuLieu
{
    public static class ThongKeDL
    {
        // Gộp thu và chi trước khi tổng hợp để không nhân đôi giao dịch khi JOIN.
        public static DataTable LayThuChiTheoThang(int maND, DateTime tuNgay, DateTime denNgay)
        {
            const string sql = @"
                SELECT DATEFROMPARTS(YEAR(Ngay), MONTH(Ngay), 1) AS Thang,
                       SUM(Thu) AS TongThu, SUM(Chi) AS TongChi
                FROM (
                    SELECT NgayThu AS Ngay, SoTien AS Thu, CAST(0 AS decimal(18,2)) AS Chi
                    FROM ThuNhap
                    WHERE MaND = @MaND AND NgayThu >= @TuNgay AND NgayThu < @DenNgay
                    UNION ALL
                    SELECT NgayChi, CAST(0 AS decimal(18,2)), SoTien
                    FROM ChiTieu
                    WHERE MaND = @MaND AND NgayChi >= @TuNgay AND NgayChi < @DenNgay
                ) gd
                GROUP BY YEAR(Ngay), MONTH(Ngay)
                ORDER BY Thang";
            return KetNoiCSDL.DocDuLieu(sql,
                new SqlParameter("@MaND", maND),
                new SqlParameter("@TuNgay", tuNgay),
                new SqlParameter("@DenNgay", denNgay));
        }

        public static ThongKeMH LayTongQuan(int maND, DateTime tuNgay, DateTime denNgay)
        {
            string sql = @"
            SELECT
                ISNULL((
                    SELECT SUM(SoTien)
                    FROM ThuNhap
                    Where MaND = @MaND
                        AND NgayThu >= @tuNgay
                        AND NgayThu < @DenNgay
                ), 0)AS TongThu,

                ISNULL((
                        SELECT SUM(SoTien)
                        FROM ChiTieu
                        WHERE MaND = @MaND
                          AND NgayChi >= @TuNgay
                          AND NgayChi < @DenNgay
                    ), 0) AS TongChi";
                DataTable dt = KetNoiCSDL.DocDuLieu(
                sql,
                new SqlParameter("@MaND", maND),
                new SqlParameter("@TuNgay", tuNgay),
                new SqlParameter("@DenNgay", denNgay)
            );

            DataRow row = dt.Rows[0];

            return new ThongKeMH
            {
                TongThu = Convert.ToDecimal(row["TongThu"]),
                TongChi = Convert.ToDecimal(row["TongChi"])
            };
        }

        public static DataTable LayGiaoDichGanDay(int maND, int soLuong)
        {
            string sql = @"
                SELECT TOP (@SoLuong)
                    gd.Ngay,
                    gd.DanhMuc,
                    gd.TenVi,
                    gd.SoTien,
                    gd.LoaiGiaoDich
                FROM
                (
                    SELECT
                        ct.NgayChi AS Ngay,
                        lc.TenLoaiChi AS DanhMuc,
                        v.TenVi,
                        -ct.SoTien AS SoTien,
                        N'Chi' AS LoaiGiaoDich,
                        ct.NgayTao
                    FROM ChiTieu ct
                    INNER JOIN LoaiChi lc
                        ON ct.MaLoaiChi = lc.MaLoaiChi
                    INNER JOIN ViTien v
                        ON ct.MaVi = v.MaVi
                    WHERE ct.MaND = @MaND

                    UNION ALL

                    SELECT
                        tn.NgayThu AS Ngay,
                        lt.TenLoaiThu AS DanhMuc,
                        v.TenVi,
                        tn.SoTien AS SoTien,
                        N'Thu' AS LoaiGiaoDich,
                        tn.NgayTao
                    FROM ThuNhap tn
                    INNER JOIN LoaiThu lt
                        ON tn.MaLoaiThu = lt.MaLoaiThu
                    INNER JOIN ViTien v
                        ON tn.MaVi = v.MaVi
                    WHERE tn.MaND = @MaND
                ) gd
                ORDER BY gd.Ngay DESC, gd.NgayTao DESC";

            return KetNoiCSDL.DocDuLieu(
                sql,
                new SqlParameter("@MaND", maND),
                new SqlParameter("@SoLuong", soLuong)
            );
        }

        public static List<NganSachMH> LayCanhBaoNganSach(
            int maND,
            int thang,
            int nam
            )
        {
            DateTime tuNgay = new DateTime(nam, thang, 1);
            DateTime denNgay = tuNgay.AddMonths(1);

            string sql = @"
               SELECT
            ns.MaNS,
            ns.MaND,
            ns.MaLoaiChi,
            ns.Thang,
            ns.Nam,
            ns.HanMuc,
            lc.TenLoaiChi,
            ISNULL(SUM(ct.SoTien), 0) AS DaChi,
            CASE
                WHEN ns.HanMuc > 0
                THEN ISNULL(SUM(ct.SoTien), 0) * 100.0 / ns.HanMuc
                ELSE 0
            END AS PhanTram
            FROM NganSach ns
            INNER JOIN LoaiChi lc
                ON ns.MaLoaiChi = lc.MaLoaiChi
            LEFT JOIN ChiTieu ct
                ON ct.MaND = ns.MaND
                AND ct.MaLoaiChi = ns.MaLoaiChi
                AND ct.NgayChi >= @TuNgay
                AND ct.NgayChi < @DenNgay
            WHERE ns.MaND = @MaND
              AND ns.Thang = @Thang
              AND ns.Nam = @Nam
            GROUP BY
                ns.MaNS,
                ns.MaND,
                ns.MaLoaiChi,
                ns.Thang,
                ns.Nam,
                ns.HanMuc,
                lc.TenLoaiChi
            ORDER BY PhanTram DESC 
            ";

            DataTable dt = KetNoiCSDL.DocDuLieu(
                sql,
                new SqlParameter("@MaND", maND),
                new SqlParameter("@Thang", thang),
                new SqlParameter("@Nam", nam),
                new SqlParameter("@TuNgay", tuNgay),
                new SqlParameter("@DenNgay", denNgay)
             );

            List<NganSachMH> danhSach = new List<NganSachMH>();

            foreach (DataRow row in dt.Rows)
            {
                danhSach.Add(new NganSachMH
                {
                    MaNS = Convert.ToInt32(row["MaNS"]),
                    MaND = Convert.ToInt32(row["MaND"]),
                    MaLoaiChi = Convert.ToInt32(row["MaLoaiChi"]),
                    Thang = Convert.ToByte(row["Thang"]),
                    Nam = Convert.ToInt16(row["Nam"]),
                    HanMuc = Convert.ToDecimal(row["HanMuc"]),
                    TenLoaiChi = row["TenLoaiChi"].ToString(),
                    DaChi = Convert.ToDecimal(row["DaChi"]),
                    PhanTram = Convert.ToDecimal(row["PhanTram"])
                });
            }
            return danhSach;
        }


        //Tong so du vi
        public static decimal LayTongSoDuVi(int maND)
        {
            const string sql = @"
                SELECT ISNULL(SUM(SoDuHienTai), 0)
                FROM vw_SoDuVi
                Where MaND = @MaND;
            ";

            object ketQua = KetNoiCSDL.LayMotGiaTri(
                sql,
                new SqlParameter("@MaND", maND) // Chặn tan cong database bang SqlParameter
                );
            return ketQua == null || ketQua == DBNull.Value
                ? 0m //Tra ve 0
                : Convert.ToDecimal(ketQua); // Tra ve kq
        }

        // Tổng chi từng ngày; ngày kết thúc không nằm trong khoảng truy vấn.
        public static DataTable LayChiTheoNgay(int maND, DateTime tuNgay, DateTime denNgay)
        {
            const string sql = @"
                SELECT CAST(NgayChi AS date) AS Ngay,
                       SUM(SoTien) AS TongChi
                FROM ChiTieu
                WHERE MaND = @MaND
                  AND NgayChi >= @TuNgay
                  AND NgayChi < @DenNgay
                GROUP BY CAST(NgayChi AS date)
                ORDER BY Ngay";

            return KetNoiCSDL.DocDuLieu(
                sql,
                new SqlParameter("@MaND", maND),
                new SqlParameter("@TuNgay", tuNgay),
                new SqlParameter("@DenNgay", denNgay));
        }

        //Chi theo loai
        public static DataTable LayChiTheoLoai(int maND, DateTime tuNgay, DateTime denNgay) { 
            const string sql = @"
                SELECT
                    lc.MaLoaiChi,
                    lc.TenLoaiChi,
                    SUM(ct.SoTien) AS TongChi
                FROM ChiTieu ct
                INNER JOIN LoaiChi lc
                    ON ct.MaLoaiChi = lc.MaLoaiChi
                    AND ct.MaND = lc.MaND
                WHERE ct.MaND = @MaND
                    AND ct.NgayChi >= @TuNgay
                    AND ct.NgayChi < @DenNgay
                GROUP BY lc.MaLoaiChi, lc.TenLoaiChi
                HAVING SUM(ct.SoTien) > 0
                ORDER BY TongChi DESC, lc.MaLoaiChi ASC";

            return KetNoiCSDL.DocDuLieu(
                sql, 
                new SqlParameter("@MaND", maND),
                new SqlParameter("@TuNgay", tuNgay),
                new SqlParameter("@DenNgay", denNgay)
                );
        }

        // Lấy lương + khác ở mục dashboard thứ 2
        public static DataTable LayThuTheoLoai(int maND, DateTime tuNgay, DateTime denNgay)
        {
            const string sql = @"
                SELECT
                    lt.MaLoaiThu,
                    lt.TenLoaiThu,
                    SUM(tn.SoTien) AS TongThu
                FROM ThuNhap tn
                INNER JOIN LoaiThu lt
                    ON tn.MaLoaiThu = lt.MaLoaiThu
                    AND tn.MaND = lt.MaND
                WHERE tn.MaND = @MaND
                    AND tn.NgayThu >= @TuNgay
                    AND tn.NgayThu < @DenNgay
                GROUP BY lt.MaLoaiThu, lt.TenLoaiThu
                HAVING SUM(tn.SoTien) > 0
                ORDER BY TongThu DESC, lt.MaLoaiThu ASC";

            return KetNoiCSDL.DocDuLieu(
                sql,
                new SqlParameter("@MaND", maND),
                new SqlParameter("@TuNgay", tuNgay),
                new SqlParameter("@DenNgay", denNgay)
            );
        }
    
        // Lấy chi tiêu theo loại kết hợp ngân sách trong tháng
        public static DataTable LayChiTieuTheoLoai(int maND, int thang, int nam)
        {
            const string sql = @"
                SELECT 
                    lc.TenLoaiChi AS TenLoai,
                    ISNULL(ns.HanMuc, 0) AS HanMuc,
                    ISNULL(SUM(ct.SoTien), 0) AS DaChi
                FROM LoaiChi lc
                LEFT JOIN NganSach ns 
                    ON ns.MaLoaiChi = lc.MaLoaiChi 
                   AND ns.Thang = @Thang 
                   AND ns.Nam = @Nam 
                   AND ns.MaND = @MaND
                LEFT JOIN ChiTieu ct 
                    ON ct.MaLoaiChi = lc.MaLoaiChi 
                   AND MONTH(ct.NgayChi) = @Thang 
                   AND YEAR(ct.NgayChi) = @Nam 
                   AND ct.MaND = @MaND
                WHERE lc.MaND = @MaND OR lc.MaND IS NULL
                GROUP BY lc.TenLoaiChi, lc.MaLoaiChi, ns.HanMuc
                ORDER BY lc.TenLoaiChi";
            return KetNoiCSDL.DocDuLieu(sql,
                new SqlParameter("@MaND", maND),
                new SqlParameter("@Thang", thang),
                new SqlParameter("@Nam", nam));
        }

        // Lấy giao dịch thu + chi trong khoảng ngày để xuất báo cáo
        public static DataTable LayGiaoDichBaoCao(int maND, DateTime tuNgay, DateTime denNgay)
        {
            const string sql = @"
                SELECT N'Thu' AS LoaiGD, t.NgayThu AS Ngay, lt.TenLoaiThu AS DanhMuc,
                       t.SoTien, t.GhiChu, v.TenVi
                FROM ThuNhap t
                JOIN LoaiThu lt ON lt.MaLoaiThu = t.MaLoaiThu
                JOIN ViTien v   ON v.MaVi = t.MaVi
                WHERE t.MaND = @MaND AND t.NgayThu >= @TuNgay AND t.NgayThu < @DenNgay
                UNION ALL
                SELECT N'Chi', c.NgayChi, lc.TenLoaiChi,
                       c.SoTien, c.GhiChu, v.TenVi
                FROM ChiTieu c
                JOIN LoaiChi lc ON lc.MaLoaiChi = c.MaLoaiChi
                JOIN ViTien v   ON v.MaVi = c.MaVi
                WHERE c.MaND = @MaND AND c.NgayChi >= @TuNgay AND c.NgayChi < @DenNgay
                ORDER BY Ngay DESC";
            return KetNoiCSDL.DocDuLieu(sql,
                new SqlParameter("@MaND", maND),
                new SqlParameter("@TuNgay", tuNgay),
                new SqlParameter("@DenNgay", denNgay.AddDays(1)));
        }

        // Lấy thống kê tổng thu/chi theo tháng trong khoảng thời gian
        public static DataTable LayThongKeBaoCao(int maND, DateTime tuNgay, DateTime denNgay)
        {
            const string sql = @"
                SELECT FORMAT(Thang, 'MM/yyyy') AS ThangNam,
                       TongThu, TongChi, (TongThu - TongChi) AS TietKiem
                FROM (
                    SELECT DATEFROMPARTS(YEAR(NgayGD), MONTH(NgayGD), 1) AS Thang,
                           SUM(TongThu) AS TongThu, SUM(TongChi) AS TongChi
                    FROM (
                        SELECT NgayThu AS NgayGD, SoTien AS TongThu, CAST(0 AS decimal(18,2)) AS TongChi
                        FROM ThuNhap WHERE MaND = @MaND AND NgayThu >= @TuNgay AND NgayThu < @DenNgay
                        UNION ALL
                        SELECT NgayChi, CAST(0 AS decimal(18,2)), SoTien
                        FROM ChiTieu WHERE MaND = @MaND AND NgayChi >= @TuNgay AND NgayChi < @DenNgay
                    ) t
                    GROUP BY DATEFROMPARTS(YEAR(NgayGD), MONTH(NgayGD), 1)
                ) s
                ORDER BY Thang";
            return KetNoiCSDL.DocDuLieu(sql,
                new SqlParameter("@MaND", maND),
                new SqlParameter("@TuNgay", tuNgay),
                new SqlParameter("@DenNgay", denNgay.AddDays(1)));
        }
public static DataTable LayTopKhoanChi(int maND, DateTime tuNgay, DateTime denNgay, int soLuong = 5)
        {
            string sql = @"
                SELECT TOP (@SoLuong)
                    c.NgayChi AS Ngay,
                    lc.TenLoaiChi AS LoaiChi,
                    c.GhiChu,
                    c.SoTien
                FROM ChiTieu c
                JOIN LoaiChi lc ON lc.MaLoaiChi = c.MaLoaiChi
                WHERE c.MaND = @MaND AND c.NgayChi >= @TuNgay AND c.NgayChi < @DenNgay
                ORDER BY c.SoTien DESC, c.NgayChi DESC";

            return KetNoiCSDL.DocDuLieu(sql,
                new SqlParameter("@MaND", maND),
                new SqlParameter("@TuNgay", tuNgay),
                new SqlParameter("@DenNgay", denNgay),
                new SqlParameter("@SoLuong", soLuong));
        }

        public static (int SoKhoan, decimal TongTien) DemTongKhoanChi(int maND, DateTime tuNgay, DateTime denNgay)
        {
            string sql = @"
                SELECT COUNT(*) AS SoKhoan, ISNULL(SUM(SoTien), 0) AS TongTien
                FROM ChiTieu
                WHERE MaND = @MaND AND NgayChi >= @TuNgay AND NgayChi < @DenNgay";

            DataTable dt = KetNoiCSDL.DocDuLieu(sql,
                new SqlParameter("@MaND", maND),
                new SqlParameter("@TuNgay", tuNgay),
                new SqlParameter("@DenNgay", denNgay));

            if (dt != null && dt.Rows.Count > 0)
            {
                int soKhoan = Convert.ToInt32(dt.Rows[0]["SoKhoan"]);
                decimal tongTien = Convert.ToDecimal(dt.Rows[0]["TongTien"]);
                return (soKhoan, tongTien);
            }
            return (0, 0m);
        }
    }
}
