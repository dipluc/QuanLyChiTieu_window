using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LTWIN_N05_QLCT.TienIch
{
    public static class GhiNhoDangNhap
    {

        //tao duong dan
        private static readonly string DuongDan = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "LTWIN_N05_QLCT",
            "session.dat");

        //luu tt dang nhap (co ma hoa)
        public static void Luu(string tenDangNhap)
        {
            //Tao thu muc neu chua co
            Directory.CreateDirectory(Path.GetDirectoryName(DuongDan));

            //string ten -> UTF8
            byte[] duLieu = Encoding.UTF8.GetBytes(tenDangNhap);
            //Mã hóa mảng byte bằng DPAPI
            byte[] daMaHoa = ProtectedData.Protect(
                duLieu, null, DataProtectionScope.CurrentUser);
            //ghi trực tiếp mảng byte đã mã hóa xuống file
            File.WriteAllBytes(DuongDan, daMaHoa);
        }

        public static string Doc()
        {
            try
            {
                if (!File.Exists(DuongDan)) return null;

                byte[] daMaHoa = File.ReadAllBytes(DuongDan);
                byte[] giaiMa = ProtectedData.Unprotect(
                    daMaHoa, null, DataProtectionScope.CurrentUser);

                return Encoding.UTF8.GetString(giaiMa);
            }
            catch
            {
                Xoa();
                return null;
            }
        }

        public static void Xoa()
        {
            if (File.Exists(DuongDan))
                File.Delete(DuongDan);
        }
    }
}