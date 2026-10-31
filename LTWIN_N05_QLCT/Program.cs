using System;
using System.Collections.Generic;
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
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


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
    }
}
