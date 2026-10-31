using MoHinh;
using NghiepVu;
using NghiepVu.TienIch;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTWIN_N05_QLCT.Forms.Chinh
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            Shown += frmDashboard_Shown;
        }
        private void frmDashboard_Shown(object sender, EventArgs e)
        {
            NapDuLieuDashboard();
        }

        private void NapDuLieuDashboard()
        {
            if (!PhienDangNhap.DaDangNhap)
                return;

            try
            {
                int maND = PhienDangNhap.MaND;
                int thang = DateTime.Today.Month;
                int nam = DateTime.Today.Year;

                NapTongQuan(maND, thang, nam);
                NapGiaoDichGanDay(maND);
                ThemCanhBaoNganSach(maND, thang, nam);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tải Dashboard:\n" + ex.Message,
                    "Lỗi dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void NapTongQuan(int maND, int thang, int nam)
        {
            ThongKeMH thongKe =
                ThongKeNV.LayTongQuanThang(maND, thang, nam);

            CultureInfo viVN = CultureInfo.GetCultureInfo("vi-VN");

            lblTongThuNhap.Text =
                thongKe.TongThu.ToString("N0", viVN) + " đ";

            lblTongChiTieu.Text =
                thongKe.TongChi.ToString("N0", viVN) + " đ";

            lblTongConLai.Text =
                thongKe.ChenhLech.ToString("N0", viVN) + " đ";

            lblConLaiTietKiem2.Text =
                thongKe.TyLeTietKiem.ToString("N1", viVN)
                + "% thu nhập tháng";

            lblThang102026.Text =
                $"Tháng {thang:D2}/{nam}";
        }


        private void NapGiaoDichGanDay(int maND)
        {
            DataTable dt = ThongKeNV.LayGiaoDichGanDay(maND);

            dgvGiaoDichGanDay.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                decimal soTien = Convert.ToDecimal(row["SoTien"]);

                int viTri = dgvGiaoDichGanDay.Rows.Add(
                    Convert.ToDateTime(row["Ngay"]).ToString("dd/MM/yyyy"),
                    row["DanhMuc"].ToString(),
                    row["TenVi"].ToString(),
                    soTien.ToString("+#,##0 đ;-#,##0 đ;0 đ")
                );

                dgvGiaoDichGanDay.Rows[viTri]
                    .Cells["colSoTien"]
                    .Style.ForeColor =
                        soTien >= 0
                            ? Color.FromArgb(22, 163, 74)
                            : Color.FromArgb(220, 38, 38);
            }

            dgvGiaoDichGanDay.ClearSelection();
        }


        //Them canh bao ngan sach
        private void ThemCanhBaoNganSach(int maND, int thang, int nam)
        {
            List<NganSachMH> danhsach =
                ThongKeNV.LayCanhBaoNganSachThang(maND, thang, nam);
            flpDanhSachNganSach.Controls.Clear();

            if(danhsach.Count <= 0)
            {
                Label lblTrong = new Label
                {
                    AutoSize = true,
                    Text = "Chưa có ngân sách trong tháng này",
                    ForeColor = Color.Gray,
                    Margin = new Padding(3, 10, 3, 3)
                };

                flpDanhSachNganSach.Controls.Add(lblTrong);
                return;
            }

            foreach (NganSachMH nganSach in danhsach)
            {
                Panel dong = TaoDongNganSach(nganSach);
                flpDanhSachNganSach.Controls.Add(dong);
            }
        }
        private Panel TaoDongNganSach(NganSachMH nganSach)
        {
            CultureInfo viVN = CultureInfo.GetCultureInfo("vi-VN");

            int chieuRong =
                Math.Max(260, flpDanhSachNganSach.ClientSize.Width - 25);

            Panel dong = new Panel
            {
                Width = chieuRong,
                Height = 60,
                Margin = new Padding(0, 0, 0, 8)
            };

            Label lblTen = new Label
            {
                AutoSize = true,
                Location = new Point(0, 3),
                Text = nganSach.TenLoaiChi
            };

            Label lblSoTien = new Label
            {
                Location = new Point(80, 3),
                Size = new Size(chieuRong - 135, 20),
                TextAlign = ContentAlignment.MiddleRight,
                ForeColor = Color.FromArgb(100, 116, 139),
                Text = nganSach.DaChi.ToString("N0", viVN)
                     + " / "
                     + nganSach.HanMuc.ToString("N0", viVN)
                     + " đ"
            };

            Color mauCanhBao;

            if (nganSach.PhanTram >= 100)
                mauCanhBao = Color.FromArgb(220, 38, 38);
            else if (nganSach.PhanTram >= 80)
                mauCanhBao = Color.FromArgb(234, 88, 12);
            else
                mauCanhBao = Color.FromArgb(22, 163, 74);

            Label lblPhanTram = new Label
            {
                Location = new Point(chieuRong - 50, 3),
                Size = new Size(50, 20),
                TextAlign = ContentAlignment.MiddleRight,
                ForeColor = mauCanhBao,
                Text = nganSach.PhanTram.ToString("N0", viVN) + "%"
            };

            int giaTriTienDo = Convert.ToInt32(
                Math.Min(100m, Math.Max(0m, nganSach.PhanTram))
            );

            ProgressBar prgTienDo = new ProgressBar
            {
                Location = new Point(0, 31),
                Size = new Size(chieuRong, 8),
                Minimum = 0,
                Maximum = 100,
                Value = giaTriTienDo
            };

            dong.Controls.Add(lblTen);
            dong.Controls.Add(lblSoTien);
            dong.Controls.Add(lblPhanTram);
            dong.Controls.Add(prgTienDo);

            return dong;
        }
    }
}
