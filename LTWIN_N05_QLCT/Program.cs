using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LTWIN_N05_QLCT.Forms.HeThong;
using NghiepVu;
using LTWIN_N05_QLCT.TienIch;

namespace LTWIN_N05_QLCT
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Contains("--check-database"))
            {
                KiemTraCoSoDuLieu();
                return;
            }

            //Khoi phuc session dang nhap
            string tenDaNho = GhiNhoDangNhap.Doc();

            if (!string.IsNullOrEmpty(tenDaNho))
            {
                var phien = TaiKhoanNV.KhoiPhucSession(tenDaNho);

                if (phien.ThanhCong)
                {
                    Application.Run(
                        new Forms.Chinh.frmMain(phien.TenDangNhap, phien.HoTen));
                    return;
                }

                GhiNhoDangNhap.Xoa();
            }


            using (var login = new frmDangNhap())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    string ten = string.IsNullOrEmpty(login.TenDangNhapDaNhap) ? "minhanh" : login.TenDangNhapDaNhap;
                    string hoTen = !string.IsNullOrEmpty(login.HoTenDaNhap) ? login.HoTenDaNhap : ((ten.ToLower() == "minhanh") ? "Nguyễn Minh Anh" : ten);
                    Application.Run(new Forms.Chinh.frmMain(ten, hoTen));
                }
            }
        }

        private static void KiemTraCoSoDuLieu()
        {
            string report = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database-check.log");
            using (var writer = new StreamWriter(report, false))
            {
                writer.AutoFlush = true;
                writer.WriteLine("Time={0:O}; Runtime={1}; Bitness={2}; Debugger={3}",
                    DateTime.Now, Environment.Version, IntPtr.Size * 8, Debugger.IsAttached);
                writer.WriteLine("BaseDirectory=" + AppDomain.CurrentDomain.BaseDirectory);
                writer.WriteLine("WorkingDirectory=" + Directory.GetCurrentDirectory());
                try
                {
                    using (var login = new frmDangNhap())
                    {
                        login.Shown += delegate
                        {
                            try
                            {
                                writer.WriteLine("PASS " + KiemTraHeThongNV.KiemTraCoSoDuLieu());
                            }
                            catch (Exception error)
                            {
                                writer.WriteLine("FAIL " + error);
                                Environment.ExitCode = 1;
                            }
                            finally { login.Close(); }
                        };
                        Application.Run(login);
                    }
                }
                catch (Exception error)
                {
                    writer.WriteLine("FAIL " + error);
                    Environment.ExitCode = 1;
                }
            }
        }
    }
}
