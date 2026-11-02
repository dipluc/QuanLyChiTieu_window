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
            return ThongKeDL.LayGiaoDichGanDay(maND, 5);
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
    }
}
