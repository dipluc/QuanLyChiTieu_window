using DuLieu;
using MoHinh;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NghiepVu
{
    public static class ThongKeNV
    {
        // Luôn trả đủ 12 tháng, kể cả tháng không phát sinh giao dịch.
        public static DataTable LayThuChi12Thang(int maND, DateTime kyCuoi)
        {
            DateTime thangCuoi = new DateTime(kyCuoi.Year, kyCuoi.Month, 1);
            DateTime thangDau = thangCuoi.AddMonths(-11);
            var ketQua = new DataTable();
            ketQua.Columns.Add("Thang", typeof(DateTime));
            ketQua.Columns.Add("TongThu", typeof(decimal));
            ketQua.Columns.Add("TongChi", typeof(decimal));

            var theoThang = new Dictionary<DateTime, DataRow>();
            if (maND > 0)
            {
                foreach (DataRow row in ThongKeDL.LayThuChiTheoThang(
                    maND, thangDau, thangCuoi.AddMonths(1)).Rows)
                    theoThang[Convert.ToDateTime(row["Thang"])] = row;
            }
            for (int i = 0; i < 12; i++)
            {
                DateTime thang = thangDau.AddMonths(i);
                DataRow row;
                bool coDuLieu = theoThang.TryGetValue(thang, out row);
                ketQua.Rows.Add(thang,
                    coDuLieu ? Convert.ToDecimal(row["TongThu"]) : 0m,
                    coDuLieu ? Convert.ToDecimal(row["TongChi"]) : 0m);
            }
            return ketQua;
        }

        public static ThongKeMH LayTongQuanThang(int maND,int thang, int nam)
        {
            DateTime tuNgay = new DateTime(nam, thang, 1);
            DateTime denNgay = tuNgay.AddMonths(1);

            return ThongKeDL.LayTongQuan(
                maND,
                tuNgay,
                denNgay
            );
        }

        public static DataTable LayGiaoDichGanDay(int maND)
        {
            return ThongKeDL.LayGiaoDichGanDay(maND, 10);
        }

        //Canh bao ngan sach
        public static List<NganSachMH> LayCanhBaoNganSachThang(
           int maND,
           int thang,
           int nam
        )
        {
            if (maND <= 0)
                return new List<NganSachMH>();
            return ThongKeDL.LayCanhBaoNganSach(
                maND,
                thang,
                nam
            );
        }

        //Tong so du vi
        public static decimal LayTongSoDuVi(int maND)
        {
            if (maND <= 0)
                return 0m;
            return ThongKeDL.LayTongSoDuVi(maND);
        }

        //Lay chi theo thang
        public static DataTable LayChiTheoLoaiThang(int maND, int thang, int nam)
        {
            DateTime tuNgay = new DateTime(nam, thang, 1);
            DateTime denNgay = tuNgay.AddMonths(1);

            return ThongKeDL.LayChiTheoLoai(
                maND, tuNgay, denNgay
            );
        }

        public static DataTable LayXuHuongChiThang(int maND, int thang, int nam)
        {
            DateTime tuNgay = new DateTime(nam, thang, 1);
            DataTable ketQua = new DataTable();
            ketQua.Columns.Add("Ngay", typeof(DateTime));
            ketQua.Columns.Add("ChiLuyKe", typeof(decimal));

            if (maND <= 0)
                return ketQua;

            DataTable chiTheoNgay = ThongKeDL.LayChiTheoNgay(
                maND, tuNgay, tuNgay.AddMonths(1));

            var soTienTheoNgay = new Dictionary<DateTime, decimal>();
            foreach (DataRow row in chiTheoNgay.Rows)
            {
                soTienTheoNgay[Convert.ToDateTime(row["Ngay"]).Date] =
                    Convert.ToDecimal(row["TongChi"]);
            }

            decimal luyKe = 0m;
            int soNgay = DateTime.DaysInMonth(nam, thang);
            for (int i = 0; i < soNgay; i++)
            {
                DateTime ngay = tuNgay.AddDays(i);
                decimal chiTrongNgay;
                if (soTienTheoNgay.TryGetValue(ngay, out chiTrongNgay))
                    luyKe += chiTrongNgay;

                ketQua.Rows.Add(ngay, luyKe);
            }

            return ketQua;
        }

        // Lấy lương + khác ở mục dashboard thứ 2
        public static DataTable LayThuTheoLoaiThang(int maND, int thang, int nam)
        {
            DateTime tuNgay = new DateTime(nam, thang, 1);
            DateTime denNgay = tuNgay.AddMonths(1);

            return ThongKeDL.LayThuTheoLoai(maND, tuNgay, denNgay);
        }
    }
}
