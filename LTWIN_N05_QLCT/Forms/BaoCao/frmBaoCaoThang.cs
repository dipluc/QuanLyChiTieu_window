using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTWIN_N05_QLCT.Forms.BaoCao
{
    public partial class frmBaoCaoThang : Form
    {
        public frmBaoCaoThang()
        {
            InitializeComponent();
            btnXuat.Click += btnXuat_Click;
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            var main = TopLevelControl as Chinh.frmMain;
            if (main != null)
                main.MoFormXuatBaoCao();
            else
            {
                using (var form = new frmXuatBaoCao())
                    form.ShowDialog(this);
            }
        }
    }
}
