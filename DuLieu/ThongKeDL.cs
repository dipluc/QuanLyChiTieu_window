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
        public static ThongKeMH LayTongQuan(
            int maND,
            DateTime tuNgay,
            DateTime denNgay)
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
    }
}
