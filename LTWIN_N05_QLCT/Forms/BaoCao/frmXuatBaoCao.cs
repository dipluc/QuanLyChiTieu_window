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
    public partial class frmXuatBaoCao : Form
    {
        public frmXuatBaoCao()
        {
            InitializeComponent();
        }

        public frmXuatBaoCao(bool xuatPdf) : this()
        {
            rdoPdf.Checked = xuatPdf;
            rdoExcel.Checked = !xuatPdf;
            if (xuatPdf)
                lblTenTepDuKien.Text = "Tên dự kiến: GiaoDich_01102026_26102026.pdf";
        }
    }
}
