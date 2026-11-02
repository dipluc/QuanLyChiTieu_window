using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LTWIN_N05_QLCT.Models;
using LTWIN_N05_QLCT.Services;

namespace LTWIN_N05_QLCT.Forms.NghiepVu
{
    public partial class frmNganSach : Form, IDongBoThang
    {
        public frmNganSach()
        {
            InitializeComponent();

            this.btnXem.Click += (s, e) => LoadNganSachData();
            this.btnDatHanMuc.Click += (s, e) => BtnDatHanMuc_Click();
            this.btnSaoChep.Click += (s, e) => BtnSaoChep_Click();
        }

        public void DongBoThang(DateTime thang)
        {
            if (cboThang.Items.Count == 0)
            {
                for (int i = 1; i <= 12; i++) cboThang.Items.Add(i.ToString());
            }
            if (cboNam.Items.Count == 0)
            {
                int currentYear = DateTime.Today.Year;
                for (int y = currentYear - 2; y <= currentYear + 3; y++) cboNam.Items.Add(y.ToString());
            }

            cboThang.SelectedItem = thang.Month.ToString();
            cboNam.SelectedItem = thang.Year.ToString();
            LoadNganSachData();
        }

        private void frmNganSach_Load(object sender, EventArgs e)
        {
            // Populate Month ComboBox
            cboThang.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add(i.ToString());
            }

            // Populate Year ComboBox
            cboNam.Items.Clear();
            int currentYear = DateTime.Today.Year;
            for (int y = currentYear - 2; y <= currentYear + 3; y++)
            {
                cboNam.Items.Add(y.ToString());
            }

            cboThang.SelectedItem = DateTime.Today.Month.ToString();
            cboNam.SelectedItem = DateTime.Today.Year.ToString();

            LoadNganSachData();
        }

        public void LoadNganSachData()
        {
            int thang = 10;
            int nam = 2026;
            if (cboThang.SelectedItem != null) int.TryParse(cboThang.SelectedItem.ToString(), out thang);
            if (cboNam.SelectedItem != null) int.TryParse(cboNam.SelectedItem.ToString(), out nam);

            lblThang102026DuLieuDen.Text = string.Format("Tháng {0}/{1} • Dữ liệu đến {2:dd/MM/yyyy}", thang, nam, DateTime.Today);
            lblNganSachThang102026.Text = string.Format("Ngân sách tháng {0}/{1}", thang, nam);

            var danhSachNS = DataService.GetNganSach(thang, nam);

            // Summary cards
            decimal tongHanMuc = danhSachNS.Sum(x => x.HanMuc);
            decimal tongDaChi = 0;

            // Categories mapping
            UpdateCategoryRow("Nhà ở", thang, nam, danhSachNS, lblNhaO2, prgNhaO, lblTyLe, lblNhaO3, lblDaChamHanMuc, ref tongDaChi);
            UpdateCategoryRow("Ăn uống", thang, nam, danhSachNS, lblAnUong2, prgAnUong, lblTyLe2, lblAnUong3, lblSapDatHanMuc, ref tongDaChi);
            UpdateCategoryRow("Di chuyển", thang, nam, danhSachNS, lblDiChuyen2, prgDiChuyen, lblTyLe3, lblDiChuyen3, lblVuotHanMuc, ref tongDaChi);
            UpdateCategoryRow("Mua sắm", thang, nam, danhSachNS, lblMuaSam2, prgMuaSam, lblTyLe4, lblMuaSam3, lblTrongHanMuc, ref tongDaChi);
            UpdateCategoryRow("Khác", thang, nam, danhSachNS, lblKhac2, prgKhac, lblTyLe5, lblKhac3, lblChuaDatHanMuc, ref tongDaChi);
            UpdateCategoryRow("Y tế", thang, nam, danhSachNS, lblYTe2, prgYTe, lblTyLe6, lblYTe3, lblTrangThaiYTe, ref tongDaChi);

            lblTongHanMuc2.Text = string.Format("{0:N0} đ", tongHanMuc);
            lblSoDanhMucDaDat.Text = string.Format("{0} danh mục đã đặt hạn mức", danhSachNS.Count(x => x.HanMuc > 0));

            lblDaChi2.Text = string.Format("{0:N0} đ", tongDaChi);
            double ptTong = tongHanMuc > 0 ? (double)(tongDaChi / tongHanMuc * 100) : 0;
            lblPhanTramTongHanMuc.Text = string.Format("{0:N1}% tổng hạn mức", ptTong);

            decimal conLai = tongHanMuc - tongDaChi;
            lblConLai2.Text = string.Format("{0:N0} đ", conLai);
            lblConLai2.ForeColor = conLai >= 0 ? Color.FromArgb(25, 118, 210) : Color.FromArgb(211, 47, 47);
        }

        private void UpdateCategoryRow(
            string categoryName,
            int thang,
            int nam,
            List<NganSachItem> danhSachNS,
            Label lblChiTiet,
            ProgressBar prg,
            Label lblTyLe,
            Label lblConLai,
            Label lblTrangThai,
            ref decimal tongDaChiAccumulator)
        {
            var item = danhSachNS.FirstOrDefault(x => x.LoaiChi == categoryName);
            decimal hanMuc = item != null ? item.HanMuc : 0;
            decimal daChi = DataService.GetTongChiTheoLoai(categoryName, thang, nam);
            tongDaChiAccumulator += daChi;

            if (hanMuc > 0)
            {
                lblChiTiet.Text = string.Format("{0:N0} đ / {1:N0} đ", daChi, hanMuc);
                double pt = (double)(daChi / hanMuc * 100);
                prg.Value = Math.Min(100, Math.Max(0, (int)pt));
                lblTyLe.Text = string.Format("{0:N0}%", pt);

                decimal cl = hanMuc - daChi;
                lblConLai.Text = string.Format("{0:N0} đ", cl);

                if (pt < 80)
                {
                    lblTrangThai.Text = "Trong hạn mức";
                    lblTrangThai.ForeColor = Color.FromArgb(46, 125, 50);
                }
                else if (pt < 100)
                {
                    lblTrangThai.Text = "Sắp đạt hạn mức";
                    lblTrangThai.ForeColor = Color.FromArgb(245, 124, 0);
                }
                else if (pt == 100)
                {
                    lblTrangThai.Text = "Đã chạm hạn mức";
                    lblTrangThai.ForeColor = Color.FromArgb(198, 40, 40);
                }
                else
                {
                    lblTrangThai.Text = "Vượt hạn mức";
                    lblTrangThai.ForeColor = Color.FromArgb(198, 40, 40);
                    lblConLai.ForeColor = Color.FromArgb(198, 40, 40);
                }
            }
            else
            {
                lblChiTiet.Text = string.Format("{0:N0} đ / —", daChi);
                prg.Value = 0;
                lblTyLe.Text = "—";
                lblConLai.Text = "—";
                lblTrangThai.Text = "Chưa đặt hạn mức";
                lblTrangThai.ForeColor = Color.Gray;
            }
        }

        private void BtnDatHanMuc_Click()
        {
            int thang = 10;
            int nam = 2026;
            if (cboThang.SelectedItem != null) int.TryParse(cboThang.SelectedItem.ToString(), out thang);
            if (cboNam.SelectedItem != null) int.TryParse(cboNam.SelectedItem.ToString(), out nam);

            using (var dlg = new Form())
            {
                dlg.Text = string.Format("Đặt hạn mức - Tháng {0}/{1}", thang, nam);
                dlg.Size = new Size(380, 220);
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.MaximizeBox = false;
                dlg.MinimizeBox = false;

                var lblDanhMuc = new Label { Text = "Loại chi:", Location = new Point(20, 20), AutoSize = true };
                var cboCat = new ComboBox { Location = new Point(120, 18), Size = new Size(220, 25), DropDownStyle = ComboBoxStyle.DropDownList };
                cboCat.Items.AddRange(DataService.DanhSachLoaiChi);
                cboCat.SelectedIndex = 0;

                var lblHanMuc = new Label { Text = "Hạn mức (đ):", Location = new Point(20, 60), AutoSize = true };
                var txtHanMuc = new TextBox { Location = new Point(120, 58), Size = new Size(220, 25) };

                var btnLuu = new Button { Text = "Lưu", DialogResult = DialogResult.OK, Location = new Point(160, 120), Size = new Size(85, 30), BackColor = Color.FromArgb(21, 101, 192), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
                var btnDong = new Button { Text = "Đóng", DialogResult = DialogResult.Cancel, Location = new Point(255, 120), Size = new Size(85, 30) };

                dlg.Controls.AddRange(new Control[] { lblDanhMuc, cboCat, lblHanMuc, txtHanMuc, btnLuu, btnDong });
                dlg.AcceptButton = btnLuu;
                dlg.CancelButton = btnDong;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string raw = txtHanMuc.Text.Replace(".", "").Replace(",", "").Trim();
                    decimal hm;
                    if (decimal.TryParse(raw, out hm) && hm >= 0)
                    {
                        var ns = new NganSachItem
                        {
                            Thang = thang,
                            Nam = nam,
                            LoaiChi = cboCat.SelectedItem != null ? cboCat.SelectedItem.ToString() : "",
                            HanMuc = hm
                        };
                        DataService.LuuNganSach(ns);
                        MessageBox.Show("Đã lưu hạn mức thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadNganSachData();
                    }
                    else
                    {
                        MessageBox.Show("Số tiền hạn mức không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnSaoChep_Click()
        {
            int thang = 10;
            int nam = 2026;
            if (cboThang.SelectedItem != null) int.TryParse(cboThang.SelectedItem.ToString(), out thang);
            if (cboNam.SelectedItem != null) int.TryParse(cboNam.SelectedItem.ToString(), out nam);

            int thangTruoc = thang == 1 ? 12 : thang - 1;
            int namTruoc = thang == 1 ? nam - 1 : nam;

            var dr = MessageBox.Show(string.Format("Bạn có muốn sao chép ngân sách từ tháng {0}/{1} sang tháng {2}/{3}?",
                thangTruoc, namTruoc, thang, nam), "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DataService.SaoChepNganSach(thangTruoc, namTruoc, thang, nam);
                MessageBox.Show("Đã sao chép ngân sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNganSachData();
            }
        }
    }
}
