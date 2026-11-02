using System;
using System.Collections.Generic;

namespace LTWIN_N05_QLCT.Models
{
    public class ThuNhap
    {
        public string Id { get; set; }
        public DateTime Ngay { get; set; }
        public string LoaiThu { get; set; }
        public string ViId { get; set; }
        public decimal SoTien { get; set; }
        public string GhiChu { get; set; }

        public ThuNhap()
        {
            Id = null;
            Ngay = DateTime.Today;
            LoaiThu = "Lương";
            ViId = "";
            GhiChu = "";
        }
    }

    public class ChiTieu
    {
        public string Id { get; set; }
        public DateTime Ngay { get; set; }
        public string LoaiChi { get; set; }
        public string ViId { get; set; }
        public decimal SoTien { get; set; }
        public string GhiChu { get; set; }

        public ChiTieu()
        {
            Id = null;
            Ngay = DateTime.Today;
            LoaiChi = "Ăn uống";
            ViId = "";
            GhiChu = "";
        }
    }

    public class NganSachItem
    {
        public string Id { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string LoaiChi { get; set; }
        public decimal HanMuc { get; set; }

        public NganSachItem()
        {
            Id = null;
            LoaiChi = "";
        }
    }

    public class ChuyenTienRecord
    {
        public string Id { get; set; }
        public DateTime Ngay { get; set; }
        public string ViNguonId { get; set; }
        public string ViDichId { get; set; }
        public decimal SoTien { get; set; }
        public string GhiChu { get; set; }

        public ChuyenTienRecord()
        {
            Id = null;
            Ngay = DateTime.Today;
            ViNguonId = "";
            ViDichId = "";
            GhiChu = "";
        }
    }

    public class Vi
    {
        public string Id { get; set; }
        public string Ten { get; set; }
        public decimal SoDu { get; set; }
        public string TenVi { get { return Ten; } set { Ten = value; } }

        public Vi()
        {
            Id = null;
            Ten = "";
        }
    }

    public class CauHinhApp
    {
        public string ThuMucSaoLuu { get; set; }
        public bool TuDongSaoLuuKhiThoat { get; set; }
        public int NguongCanhBao { get; set; }
        public int NgưongCanhBao { get { return NguongCanhBao; } set { NguongCanhBao = value; } }

        public CauHinhApp()
        {
            ThuMucSaoLuu = @"D:\QuanLyChiTieu\SaoLuu";
            TuDongSaoLuuKhiThoat = true;
            NguongCanhBao = 80;
        }
    }

}
