using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTWIN_N05_QLCT.Forms.QuanTri
{
    public partial class frmSaoLuu : Form
    {
        public frmSaoLuu()
        {
            InitializeComponent();
            btnPhucHoi.Click += btnPhucHoi_Click;
        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            using (var form = new frmXacNhanPhucHoi())
            {
                form.ShowDialog(TopLevelControl);
            }
        }
    }
}
