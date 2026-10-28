using System;
using System.Windows.Forms;
using DuLieu;

namespace GUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (KetNoiCSDL.KiemTraKetNoi())
            {
                // DuLieu la tang ket noi CSDL. Vui long chay project GUI (LTWIN_N05_QLCT) de mo frmDangNhap.
            }
        }
    }
}