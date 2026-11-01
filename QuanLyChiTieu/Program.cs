using QuanLyChiTieu.Forms;

namespace QuanLyChiTieu;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new frmQuanLyThuNhap());
    }
}
