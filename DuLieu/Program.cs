using System;
using System.Windows.Forms;
using DuLieu; // Thêm namespace của tầng DuLieu để gọi KetNoiCSDL

namespace GUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Kiểm tra kết nối CSDL trước khi mở ứng dụng
            if (KetNoiCSDL.KiemTraKetNoi())
            {
                // 2. Nếu kết nối thành công, mở Form Đăng nhập (hoặc frmMain tạm thời)
                // Sau này khi làm frmDangNhap, bạn thay frmMain bằng frmDangNhap ở đây
                Application.Run(new frmMain());
            }
        }
    }
}