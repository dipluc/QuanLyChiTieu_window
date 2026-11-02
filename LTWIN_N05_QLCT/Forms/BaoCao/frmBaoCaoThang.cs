using LTWIN_N05_QLCT.Forms;
using NghiepVu;
using NghiepVu.TienIch;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LTWIN_N05_QLCT.Forms.BaoCao
{
    public partial class frmBaoCaoThang : Form, IDongBoThang
    {
        private int _maND = 0;

        public frmBaoCaoThang()
        {
            InitializeComponent();
            _maND = PhienDangNhap.DaDangNhap ? PhienDangNhap.MaND : 0;
            KhoiTao();
        }

        private void KhoiTao()
        {
            dtpThangBaoCao.ValueChanged += (s, e) => TaiDuLieu();
            btnIn.Click += (s, e) => InBaoCao();
            btnXuat.Click += btnXuat_Click;
        }

        public void DongBoThang(DateTime ngay)
        {
            dtpThangBaoCao.Value = new DateTime(ngay.Year, ngay.Month, 1);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_maND <= 0 && PhienDangNhap.DaDangNhap)
                _maND = PhienDangNhap.MaND;
            TaiDuLieu();
        }

        private void TaiDuLieu()
        {
            if (_maND <= 0 && PhienDangNhap.DaDangNhap)
                _maND = PhienDangNhap.MaND;

            if (_maND <= 0)
            {
                HienThiTrong();
                return;
            }

            try
            {
                int thang = dtpThangBaoCao.Value.Month;
                int nam = dtpThangBaoCao.Value.Year;

                var tq = ThongKeNV.LayTongQuanThang(_maND, thang, nam);
                decimal tongThu = tq != null ? tq.TongThu : 0m;
                decimal tongChi = tq != null ? tq.TongChi : 0m;
                decimal tietKiem = tongThu - tongChi;

                lblTongThu.Text = FormatTien(tongThu);
                lblTongChi.Text = FormatTien(tongChi);
                lblTongTietKiem.Text = FormatTien(tietKiem);
                lblTongTietKiem.ForeColor = tietKiem >= 0
                    ? Color.FromArgb(21, 101, 192)
                    : Color.FromArgb(211, 47, 47);

                double phanTram = tongThu > 0 ? (double)(tongChi / tongThu) * 100.0 : 0.0;
                lblMoTaChi.Text = string.Format("{0:0.0}% tổng thu nhập", phanTram);
                double phanTramTietKiem = tongThu > 0 ? (double)(tietKiem / tongThu) * 100.0 : 0.0;
                lblMoTaTietKiem.Text = string.Format("Tổng thu − Tổng chi • {0:0.0}% thu nhập", phanTramTietKiem);

                lblPhamVi.Text = string.Format("Tất cả các ví • Dữ liệu tháng {0:MM/yyyy}", dtpThangBaoCao.Value);
                lblHuongDan.Text = "% = Đã chi / Hạn mức";

                TaiChiTietNganSach(thang, nam);
            }
            catch
            {
                HienThiTrong();
            }
        }

        private void TaiChiTietNganSach(int thang, int nam)
        {
            lvChiTiet.Items.Clear();
            try
            {
                var dt = ThongKeNV.LayChiTieuTheoLoai(_maND, thang, nam);
                decimal tongChi = 0m;
                decimal tongHanMuc = 0m;

                if (dt != null && dt.Rows.Count > 0)
                {
                    int i = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        decimal hanMuc = row["HanMuc"] != DBNull.Value ? Convert.ToDecimal(row["HanMuc"]) : 0m;
                        decimal daChi = row["DaChi"] != DBNull.Value ? Convert.ToDecimal(row["DaChi"]) : 0m;
                        decimal conLai = hanMuc - daChi;
                        double pct = hanMuc > 0 ? (double)(daChi / hanMuc) * 100.0 : 0.0;

                        var item = new ListViewItem(new string[]
                        {
                            row["TenLoai"]?.ToString() ?? "",
                            FormatTien(hanMuc),
                            FormatTien(daChi),
                            FormatTien(conLai),
                            hanMuc > 0 ? string.Format("{0:0.0}%", pct) : "-"
                        });

                        if (i % 2 == 0)
                        {
                            item.BackColor = Color.FromArgb(246, 249, 253);
                        }

                        if (daChi > hanMuc && hanMuc > 0)
                        {
                            item.ForeColor = Color.FromArgb(211, 47, 47);
                        }

                        tongChi += daChi;
                        tongHanMuc += hanMuc;
                        lvChiTiet.Items.Add(item);
                        i++;
                    }
                }

                // Dòng tổng cộng
                decimal conLaiTong = tongHanMuc - tongChi;
                double pctTong = tongHanMuc > 0 ? (double)(tongChi / tongHanMuc) * 100.0 : 0.0;
                var tong = new ListViewItem(new string[]
                {
                    "Tổng cộng",
                    FormatTien(tongHanMuc),
                    FormatTien(tongChi),
                    FormatTien(conLaiTong),
                    tongHanMuc > 0 ? string.Format("{0:0.0}%", pctTong) : "-"
                });
                tong.Font = new Font(lvChiTiet.Font, FontStyle.Bold);
                lvChiTiet.Items.Add(tong);

                lblGhiChu.Text = string.Format("Còn lại ngân sách: {0} (Hạn mức − Đã chi), không phải khoản tiết kiệm.", FormatTien(conLaiTong));

                // Cảnh báo vượt hạn mức
                var vuot = new System.Text.StringBuilder();
                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        decimal hanMuc = row["HanMuc"] != DBNull.Value ? Convert.ToDecimal(row["HanMuc"]) : 0m;
                        decimal daChi = row["DaChi"] != DBNull.Value ? Convert.ToDecimal(row["DaChi"]) : 0m;
                        if (hanMuc > 0 && daChi > hanMuc)
                        {
                            if (vuot.Length > 0) vuot.Append(", ");
                            vuot.AppendFormat("{0} vượt {1}", row["TenLoai"], FormatTien(daChi - hanMuc));
                        }
                    }
                }
                lblCanhBao.Text = vuot.Length > 0 ? vuot.ToString() + "." : string.Empty;
            }
            catch { }
        }

        private void HienThiTrong()
        {
            lblTongThu.Text = "0 đ";
            lblTongChi.Text = "0 đ";
            lblTongTietKiem.Text = "0 đ";
            lblMoTaChi.Text = "Chưa có dữ liệu";
            lblMoTaTietKiem.Text = "Tổng thu − Tổng chi";
            lblGhiChu.Text = "";
            lblCanhBao.Text = "";
            lvChiTiet.Items.Clear();
        }

        private static string FormatTien(decimal so)
        {
            return string.Format("{0:N0} đ", so);
        }

        private void InBaoCao()
        {
            MessageBox.Show("Chức năng In trực tiếp đang chuẩn bị tài liệu máy in. Bạn có thể sử dụng nút 'Xuất' để lưu báo cáo Excel hoặc PDF ngay bây giờ.",
                "In báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
