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
            Id = Guid.NewGuid().ToString();
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
            Id = Guid.NewGuid().ToString();
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
            Id = Guid.NewGuid().ToString();
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
            Id = Guid.NewGuid().ToString();
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
            Id = Guid.NewGuid().ToString();
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

    public class AppData
    {
        public List<ThuNhap> DanhSachThuNhap { get; set; }
        public List<ChiTieu> DanhSachChiTieu { get; set; }
        public List<NganSachItem> DanhSachNganSach { get; set; }
        public List<ChuyenTienRecord> DanhSachChuyenTien { get; set; }
        public List<Vi> DanhSachVi { get; set; }
        public CauHinhApp CauHinh { get; set; }
        public string NguoiDung { get; set; }

        public AppData()
        {
            DanhSachThuNhap = new List<ThuNhap>();
            DanhSachChiTieu = new List<ChiTieu>();
            DanhSachNganSach = new List<NganSachItem>();
            DanhSachChuyenTien = new List<ChuyenTienRecord>();
            DanhSachVi = new List<Vi>();
            CauHinh = new CauHinhApp();
            NguoiDung = "Nguyễn Minh Anh";
        }
    }
}
