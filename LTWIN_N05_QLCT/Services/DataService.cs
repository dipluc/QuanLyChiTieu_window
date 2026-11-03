using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DuLieu;
using NghiepVu.TienIch;
using LTWIN_N05_QLCT.Models;

namespace LTWIN_N05_QLCT.Services
{
    // Mọi dữ liệu được đọc/ghi trực tiếp trên cùng LocalDB với báo cáo.
    public static class DataService
    {
        private static int MaND
        {
            get
            {
                if (!PhienDangNhap.DaDangNhap || PhienDangNhap.MaND <= 0)
                    throw new InvalidOperationException("Vui lòng đăng nhập trước khi truy cập dữ liệu.");
                return PhienDangNhap.MaND;
            }
        }

        private static SqlParameter P(string name, object value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }

        private static DataTable Doc(string sql, params SqlParameter[] parameters)
        {
            var args = new List<SqlParameter>(parameters) { P("@MaND", MaND) };
            return KetNoiCSDL.DocDuLieu(sql, args.ToArray());
        }

        private static T GiaoDich<T>(Func<SqlConnection, SqlTransaction, int, T> action)
        {
            int maND = MaND;
            if (maND <= 0) throw new InvalidOperationException("Vui lòng đăng nhập trước khi thực hiện giao dịch.");
            using (var conn = KetNoiCSDL.LayKetNoi())
            using (var tx = conn.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    T result = action(conn, tx, maND);
                    tx.Commit();
                    return result;
                }
                catch { tx.Rollback(); throw; }
            }
        }

        private static SqlCommand Lenh(SqlConnection conn, SqlTransaction tx, string sql, int maND, params SqlParameter[] args)
        {
            var cmd = new SqlCommand(sql, conn, tx);
            cmd.Parameters.Add(P("@MaND", maND));
            cmd.Parameters.AddRange(args);
            return cmd;
        }

        private static int MaSo(string id)
        {
            int result;
            if (!int.TryParse(id, out result) || result <= 0)
                throw new ArgumentException("Mã dữ liệu không hợp lệ.");
            return result;
        }

        private static int LayMaLoai(SqlConnection conn, SqlTransaction tx, int maND, string ten, bool thu)
        {
            string table = thu ? "LoaiThu" : "LoaiChi";
            string key = thu ? "MaLoaiThu" : "MaLoaiChi";
            string name = thu ? "TenLoaiThu" : "TenLoaiChi";
            using (var cmd = Lenh(conn, tx, "SELECT " + key + " FROM " + table +
                " WHERE MaND=@MaND AND " + name + "=@Ten AND TrangThai=1", maND, P("@Ten", ten)))
            {
                object id = cmd.ExecuteScalar();
                if (id == null) throw new InvalidOperationException("Danh mục không tồn tại hoặc đã ngừng sử dụng.");
                return Convert.ToInt32(id);
            }
        }

        private static void KiemTraVi(SqlConnection conn, SqlTransaction tx, int maND, int maVi)
        {
            using (var cmd = Lenh(conn, tx,
                "SELECT COUNT(*) FROM ViTien WHERE MaND=@MaND AND MaVi=@Vi AND TrangThai=1", maND, P("@Vi", maVi)))
            {
                if (Convert.ToInt32(cmd.ExecuteScalar()) != 1)
                    throw new InvalidOperationException("Ví không tồn tại, đã ngừng sử dụng hoặc không thuộc tài khoản này.");
            }
        }

        public static string[] DanhSachLoaiChi
        {
            get { return Doc("SELECT TenLoaiChi FROM LoaiChi WHERE MaND=@MaND AND TrangThai=1 ORDER BY TenLoaiChi")
                .AsEnumerable().Select(r => r.Field<string>("TenLoaiChi")).ToArray(); }
        }
        public static string[] DanhSachLoaiThu
        {
            get { return Doc("SELECT TenLoaiThu FROM LoaiThu WHERE MaND=@MaND AND TrangThai=1 ORDER BY TenLoaiThu")
                .AsEnumerable().Select(r => r.Field<string>("TenLoaiThu")).ToArray(); }
        }

        private static DataTable DocThuChi(bool thu, DateTime? tuNgay, DateTime? denNgay, string loai)
        {
            string table = thu ? "ThuNhap" : "ChiTieu";
            string key = thu ? "MaThu" : "MaChi";
            string date = thu ? "NgayThu" : "NgayChi";
            string category = thu ? "LoaiThu" : "LoaiChi";
            string catKey = thu ? "MaLoaiThu" : "MaLoaiChi";
            string catName = thu ? "TenLoaiThu" : "TenLoaiChi";
            return Doc("SELECT t." + key + " AS Id,t." + date + " AS Ngay,t.MaVi,t.SoTien,t.GhiChu,l." + catName +
                " AS Loai FROM " + table + " t JOIN " + category + " l ON t." + catKey + "=l." + catKey +
                " AND t.MaND=l.MaND WHERE t.MaND=@MaND AND (@Tu IS NULL OR t." + date + ">=@Tu)" +
                " AND (@Den IS NULL OR t." + date + "<@Den) AND (@Loai IS NULL OR l." + catName + "=@Loai) ORDER BY t." + date + " DESC,t." + key + " DESC",
                new SqlParameter("@Tu", SqlDbType.DateTime2) { Value = (object)tuNgay ?? DBNull.Value },
                new SqlParameter("@Den", SqlDbType.DateTime2) { Value = denNgay.HasValue ? (object)denNgay.Value.Date.AddDays(1) : DBNull.Value },
                new SqlParameter("@Loai", SqlDbType.NVarChar, 100) { Value = string.IsNullOrEmpty(loai) || loai == "Tất cả" ? (object)DBNull.Value : loai });
        }

        public static List<ThuNhap> GetThuNhap(DateTime? tuNgay = null, DateTime? denNgay = null, string loaiThu = null)
        {
            return DocThuChi(true, tuNgay, denNgay, loaiThu).AsEnumerable().Select(r => new ThuNhap {
                Id=r["Id"].ToString(), Ngay=Convert.ToDateTime(r["Ngay"]), LoaiThu=r["Loai"].ToString(),
                ViId=r["MaVi"].ToString(), SoTien=Convert.ToDecimal(r["SoTien"]), GhiChu=r["GhiChu"].ToString()
            }).ToList();
        }
        public static List<ChiTieu> GetChiTieu(DateTime? tuNgay = null, DateTime? denNgay = null, string loaiChi = null)
        {
            return DocThuChi(false, tuNgay, denNgay, loaiChi).AsEnumerable().Select(r => new ChiTieu {
                Id=r["Id"].ToString(), Ngay=Convert.ToDateTime(r["Ngay"]), LoaiChi=r["Loai"].ToString(),
                ViId=r["MaVi"].ToString(), SoTien=Convert.ToDecimal(r["SoTien"]), GhiChu=r["GhiChu"].ToString()
            }).ToList();
        }

        private static string LuuThuChi(bool thu, string id, DateTime ngay, string loai, string viId, decimal soTien, string ghiChu)
        {
            if (soTien <= 0) throw new ArgumentException("Số tiền phải lớn hơn 0.");
            return GiaoDich((conn, tx, maND) => {
                int maVi = MaSo(viId);
                KiemTraVi(conn, tx, maND, maVi);
                int maLoai = LayMaLoai(conn, tx, maND, loai, thu);
                string table = thu ? "ThuNhap" : "ChiTieu";
                string key = thu ? "MaThu" : "MaChi";
                string date = thu ? "NgayThu" : "NgayChi";
                string cat = thu ? "MaLoaiThu" : "MaLoaiChi";
                string sql = id == null
                    ? "INSERT INTO " + table + " (MaND,MaVi," + cat + "," + date + ",SoTien,GhiChu) OUTPUT INSERTED." + key + " VALUES (@MaND,@Vi,@Loai,@Ngay,@Tien,@GhiChu)"
                    : "UPDATE " + table + " SET MaVi=@Vi," + cat + "=@Loai," + date + "=@Ngay,SoTien=@Tien,GhiChu=@GhiChu OUTPUT INSERTED." + key + " WHERE " + key + "=@Id AND MaND=@MaND";
                using (var cmd = Lenh(conn, tx, sql, maND, P("@Vi",maVi), P("@Loai",maLoai), P("@Ngay",ngay), P("@Tien",soTien), P("@GhiChu",ghiChu), P("@Id",id == null ? 0 : MaSo(id))))
                {
                    object result = cmd.ExecuteScalar();
                    if (result == null) throw new InvalidOperationException("Không tìm thấy giao dịch để cập nhật.");
                    return result.ToString();
                }
            });
        }
        public static void ThemThuNhap(ThuNhap x) { x.Id=LuuThuChi(true,null,x.Ngay,x.LoaiThu,x.ViId,x.SoTien,x.GhiChu); }
        public static void SuaThuNhap(ThuNhap x) { LuuThuChi(true,x.Id,x.Ngay,x.LoaiThu,x.ViId,x.SoTien,x.GhiChu); }
        public static void ThemChiTieu(ChiTieu x) { x.Id=LuuThuChi(false,null,x.Ngay,x.LoaiChi,x.ViId,x.SoTien,x.GhiChu); }
        public static void SuaChiTieu(ChiTieu x) { LuuThuChi(false,x.Id,x.Ngay,x.LoaiChi,x.ViId,x.SoTien,x.GhiChu); }
        private static void XoaThuChi(bool thu, string id)
        {
            GiaoDich((conn,tx,maND) => {
                using (var cmd=Lenh(conn,tx,"DELETE FROM " + (thu ? "ThuNhap WHERE MaThu" : "ChiTieu WHERE MaChi") + "=@Id AND MaND=@MaND",maND,P("@Id",MaSo(id))))
                {
                    if (cmd.ExecuteNonQuery()!=1) throw new InvalidOperationException("Không tìm thấy giao dịch để xóa.");
                }
                return true;
            });
        }
        public static void XoaThuNhap(string id) { XoaThuChi(true,id); }
        public static void XoaChiTieu(string id) { XoaThuChi(false,id); }

        public static List<Vi> GetDanhSachVi()
        {
            return Doc("SELECT MaVi,TenVi,SoDuHienTai FROM vw_SoDuVi WHERE MaND=@MaND ORDER BY MaVi")
                .AsEnumerable().Select(r => new Vi { Id=r["MaVi"].ToString(),Ten=r["TenVi"].ToString(),SoDu=Convert.ToDecimal(r["SoDuHienTai"]) }).ToList();
        }
        public static Vi GetVi(string id) { return GetDanhSachVi().FirstOrDefault(v => v.Id==id); }

        public static List<NganSachItem> GetNganSach(int thang, int nam)
        {
            return Doc(@"SELECT n.MaNS,n.Thang,n.Nam,n.HanMuc,l.TenLoaiChi FROM NganSach n
                JOIN LoaiChi l ON n.MaLoaiChi=l.MaLoaiChi AND n.MaND=l.MaND
                WHERE n.MaND=@MaND AND n.Thang=@Thang AND n.Nam=@Nam", P("@Thang",thang),P("@Nam",nam))
                .AsEnumerable().Select(r => new NganSachItem { Id=r["MaNS"].ToString(),Thang=Convert.ToInt32(r["Thang"]),Nam=Convert.ToInt32(r["Nam"]),LoaiChi=r["TenLoaiChi"].ToString(),HanMuc=Convert.ToDecimal(r["HanMuc"]) }).ToList();
        }
        public static void LuuNganSach(NganSachItem item)
        {
            new DateTime(item.Nam,item.Thang,1);
            if (item.HanMuc < 0) throw new ArgumentException("Hạn mức không được âm.");
            GiaoDich((conn,tx,maND) => {
                int loai=LayMaLoai(conn,tx,maND,item.LoaiChi,false);
                using(var cmd=Lenh(conn,tx,@"UPDATE NganSach SET HanMuc=@Tien WHERE MaND=@MaND AND MaLoaiChi=@Loai AND Thang=@Thang AND Nam=@Nam;
                    IF @@ROWCOUNT=0 INSERT INTO NganSach(MaND,MaLoaiChi,Thang,Nam,HanMuc) VALUES(@MaND,@Loai,@Thang,@Nam,@Tien);",maND,P("@Loai",loai),P("@Thang",item.Thang),P("@Nam",item.Nam),P("@Tien",item.HanMuc))) cmd.ExecuteNonQuery();
                return true;
            });
        }
        public static void SaoChepNganSach(int thangNguon,int namNguon,int thangDich,int namDich)
        {
            new DateTime(namNguon,thangNguon,1); new DateTime(namDich,thangDich,1);
            if(thangNguon==thangDich && namNguon==namDich) return;
            GiaoDich((conn,tx,maND) => {
                using(var cmd=Lenh(conn,tx,@"DELETE FROM NganSach WHERE MaND=@MaND AND Thang=@TD AND Nam=@ND;
                    INSERT INTO NganSach(MaND,MaLoaiChi,Thang,Nam,HanMuc)
                    SELECT MaND,MaLoaiChi,@TD,@ND,HanMuc FROM NganSach WHERE MaND=@MaND AND Thang=@TN AND Nam=@NN;",maND,P("@TD",thangDich),P("@ND",namDich),P("@TN",thangNguon),P("@NN",namNguon))) cmd.ExecuteNonQuery();
                return true;
            });
        }
        public static decimal GetTongChiTheoLoai(string loaiChi,int thang,int nam)
        {
            DateTime start=new DateTime(nam,thang,1);
            return GetChiTieu(start,start.AddMonths(1).AddDays(-1),loaiChi).Sum(x=>x.SoTien);
        }

        public static List<ChuyenTienRecord> GetChuyenTien(DateTime? tuNgay=null, DateTime? denNgay=null)
        {
            return Doc("SELECT MaCT,NgayChuyen,ViNguon,ViDich,SoTien,GhiChu FROM ChuyenTien WHERE MaND=@MaND ORDER BY NgayChuyen DESC,MaCT DESC")
                .AsEnumerable().Select(r=>new ChuyenTienRecord { Id=r["MaCT"].ToString(),Ngay=Convert.ToDateTime(r["NgayChuyen"]),ViNguonId=r["ViNguon"].ToString(),ViDichId=r["ViDich"].ToString(),SoTien=Convert.ToDecimal(r["SoTien"]),GhiChu=r["GhiChu"].ToString() })
                .Where(x=>(!tuNgay.HasValue || x.Ngay>=tuNgay.Value) && (!denNgay.HasValue || x.Ngay<denNgay.Value.Date.AddDays(1))).ToList();
        }
        public static bool ChuyenTien(ChuyenTienRecord record)
        {
            if(record.SoTien<=0 || record.ViNguonId==record.ViDichId) throw new ArgumentException("Ví nguồn, ví đích hoặc số tiền không hợp lệ.");
            return GiaoDich((conn,tx,maND)=> {
                int nguon=MaSo(record.ViNguonId), dich=MaSo(record.ViDichId);
                KiemTraVi(conn,tx,maND,nguon); KiemTraVi(conn,tx,maND,dich);
                using(var cmd=Lenh(conn,tx,"SELECT SoDuHienTai FROM vw_SoDuVi WHERE MaND=@MaND AND MaVi=@Vi",maND,P("@Vi",nguon)))
                    if(Convert.ToDecimal(cmd.ExecuteScalar())<record.SoTien) return false;
                using(var cmd=Lenh(conn,tx,@"INSERT INTO ChuyenTien(MaND,ViNguon,ViDich,NgayChuyen,SoTien,GhiChu)
                    OUTPUT INSERTED.MaCT VALUES(@MaND,@Nguon,@Dich,@Ngay,@Tien,@GhiChu)",maND,P("@Nguon",nguon),P("@Dich",dich),P("@Ngay",record.Ngay),P("@Tien",record.SoTien),P("@GhiChu",record.GhiChu))) record.Id=cmd.ExecuteScalar().ToString();
                return true;
            });
        }

        public static CauHinhApp GetCauHinh()
        {
            var dt=Doc("SELECT ThuMucSaoLuu,NguongCanhBao,TuDongSaoLuu FROM CauHinh WHERE MaND=@MaND");
            if(dt.Rows.Count==0) return new CauHinhApp { TuDongSaoLuuKhiThoat=false };
            var r=dt.Rows[0];
            return new CauHinhApp { ThuMucSaoLuu=r["ThuMucSaoLuu"].ToString(),NguongCanhBao=Convert.ToInt32(r["NguongCanhBao"]),TuDongSaoLuuKhiThoat=Convert.ToBoolean(r["TuDongSaoLuu"]) };
        }
        public static void LuuCauHinh(CauHinhApp cfg)
        {
            if(cfg.NguongCanhBao<0 || cfg.NguongCanhBao>100) throw new ArgumentException("Ngưỡng cảnh báo phải từ 0 đến 100.");
            GiaoDich((conn,tx,maND)=> {
                using(var cmd=Lenh(conn,tx,@"UPDATE CauHinh SET ThuMucSaoLuu=@Path,NguongCanhBao=@Nguong,TuDongSaoLuu=@Auto WHERE MaND=@MaND;
                    IF @@ROWCOUNT=0 INSERT INTO CauHinh(MaND,ThuMucSaoLuu,NguongCanhBao,TuDongSaoLuu) VALUES(@MaND,@Path,@Nguong,@Auto);",maND,P("@Path",cfg.ThuMucSaoLuu),P("@Nguong",cfg.NguongCanhBao),P("@Auto",cfg.TuDongSaoLuuKhiThoat))) cmd.ExecuteNonQuery();
                return true;
            });
        }

        public static List<object[]> TimKiemGiaoDich(
            string tuKhoa = null,
            string loaiGiaoDich = null,
            DateTime? tuNgay = null,
            DateTime? denNgay = null,
            decimal? tienTu = null,
            decimal? tienDen = null,
            string loaiThuChi = null,
            string viId = null)
        {
            var thuNhap = GetThuNhap(tuNgay, denNgay);
            var chiTieu = GetChiTieu(tuNgay, denNgay);
            var danhSachVi = GetDanhSachVi();
            var results = new List<object[]>();

            if (loaiGiaoDich == null || loaiGiaoDich == "Tất cả" || loaiGiaoDich == "Thu")
            {
                foreach (var tn in thuNhap)
                {
                    if (tuNgay.HasValue && tn.Ngay < tuNgay.Value) continue;
                    if (denNgay.HasValue && tn.Ngay > denNgay.Value) continue;
                    if (tienTu.HasValue && tn.SoTien < tienTu.Value) continue;
                    if (tienDen.HasValue && tn.SoTien > tienDen.Value) continue;
                    if (!string.IsNullOrEmpty(viId) && viId != "Tất cả" && tn.ViId != viId) continue;
                    if (!string.IsNullOrEmpty(loaiThuChi) && loaiThuChi != "Tất cả" && tn.LoaiThu != loaiThuChi) continue;
                    if (!string.IsNullOrEmpty(tuKhoa) && tn.GhiChu.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) < 0) continue;

                    var vi = danhSachVi.FirstOrDefault(v => v.Id == tn.ViId);
                    results.Add(new object[] { tn.Ngay, "Thu", tn.LoaiThu, vi != null ? vi.Ten : "", tn.SoTien, tn.GhiChu });
                }
            }

            if (loaiGiaoDich == null || loaiGiaoDich == "Tất cả" || loaiGiaoDich == "Chi")
            {
                foreach (var ct in chiTieu)
                {
                    if (tuNgay.HasValue && ct.Ngay < tuNgay.Value) continue;
                    if (denNgay.HasValue && ct.Ngay > denNgay.Value) continue;
                    if (tienTu.HasValue && ct.SoTien < tienTu.Value) continue;
                    if (tienDen.HasValue && ct.SoTien > tienDen.Value) continue;
                    if (!string.IsNullOrEmpty(viId) && viId != "Tất cả" && ct.ViId != viId) continue;
                    if (!string.IsNullOrEmpty(loaiThuChi) && loaiThuChi != "Tất cả" && ct.LoaiChi != loaiThuChi) continue;
                    if (!string.IsNullOrEmpty(tuKhoa) && ct.GhiChu.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) < 0) continue;

                    var vi = danhSachVi.FirstOrDefault(v => v.Id == ct.ViId);
                    results.Add(new object[] { ct.Ngay, "Chi", ct.LoaiChi, vi != null ? vi.Ten : "", ct.SoTien, ct.GhiChu });
                }
            }

            return results.OrderByDescending(r => (DateTime)r[0]).ToList();
        }

        public static string GetNguoiDung() { return PhienDangNhap.HoTen; }
    }
}
