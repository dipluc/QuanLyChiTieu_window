using System;
using System.Drawing;
using System.Windows.Forms;
using LTWIN_N05_QLCT.Forms.Chinh;

namespace LTWIN_N05_QLCT.Forms.TroGiup
{
    public partial class frmGioiThieu : Form
    {
        private static readonly Color MauVienCard = Color.FromArgb(226, 232, 240);

        public event Action OnYeuCauDong;

        public frmGioiThieu()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            // Viền card màu #E2E8F0
            pnlGioiThieu.Paint += (s, e) =>
            {
                using (var pen = new Pen(MauVienCard, 1))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, pnlGioiThieu.Width - 1, pnlGioiThieu.Height - 1);
                }
            };

            // Nút Đóng
            btnDongGioiThieu.Click += (s, e) =>
            {
                OnYeuCauDong?.Invoke();
                Close();
            };
        }
    }
}
