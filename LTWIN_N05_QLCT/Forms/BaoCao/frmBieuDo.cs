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
    public partial class frmBieuDo : Form
    {
        public frmBieuDo()
        {
            InitializeComponent();
            btnXuatExcel.Click += MoTrangXuatBaoCao;
            btnXuatPdf.Click += MoTrangXuatBaoCao;
        }

        private void MoTrangXuatBaoCao(object sender, EventArgs e)
        {
            bool xuatPdf = sender == btnXuatPdf;
            var main = TopLevelControl as Chinh.frmMain;
            if (main != null)
                main.MoFormXuatBaoCao(xuatPdf);
            else
            {
                using (var form = new frmXuatBaoCao(xuatPdf))
                    form.ShowDialog(this);
            }
        }
    }
}
