using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyChiTieu.Models;
using QuanLyChiTieu.Services;

namespace QuanLyChiTieu.Forms
{
    public partial class frmNganSach : Form
    {
        public frmNganSach()
        {
            InitializeComponent();
        }

        private void NavigateTo<T>() where T : Form, new()
        {
            var frm = new T();
            frm.Show();
            this.Hide();
            frm.FormClosed += (s, e) => this.Close();
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

            cboThang.SelectedItem = "10";
            cboNam.SelectedItem = "2026";

            // Status bar info
            lblTrangThaiBar.Text = $"✔ Sẵn sàng   |   Đăng nhập: {DataService.GetNguoiDung()}      Ví đang chọn: Vietcombank      Hôm nay: {DateTime.Today:dd/MM/yyyy}";

            // Menu setup
            var mnuCauHinh = new ToolStripMenuItem("Cấu hình", null, (s, ev) => NavigateTo<frmCauHinh>());
            var mnuThoat = new ToolStripMenuItem("Thoát", null, (s, ev) => Application.Exit());
            this.mnuHeThong.DropDownItems.Clear();
            this.mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] { mnuCauHinh, mnuThoat });

            var mnuThuNhap = new ToolStripMenuItem("Quản lý thu nhập", null, (s, ev) => NavigateTo<frmQuanLyThuNhap>());
            var mnuChiTieu = new ToolStripMenuItem("Quản lý chi tiêu", null, (s, ev) => NavigateTo<frmQuanLyChiTieu>());
            var mnuNganSachItem = new ToolStripMenuItem("Ngân sách", null, (s, ev) => { });
            var mnuChuyenTien = new ToolStripMenuItem("Chuyển tiền giữa các ví", null, (s, ev) => NavigateTo<frmChuyenTien>());
            var mnuTimKiem = new ToolStripMenuItem("Tìm kiếm giao dịch", null, (s, ev) => NavigateTo<frmTimKiem>());
            this.mnuNghiepVu.DropDownItems.Clear();
            this.mnuNghiepVu.DropDownItems.AddRange(new ToolStripItem[] { mnuThuNhap, mnuChiTieu, mnuNganSachItem, mnuChuyenTien, mnuTimKiem });

            LoadNganSachData();
        }

        private void LoadNganSachData()
        {
            if (!int.TryParse(cboThang.SelectedItem?.ToString(), out int thang)) thang = 10;
            if (!int.TryParse(cboNam.SelectedItem?.ToString(), out int nam)) nam = 2026;

            lblThang102026DuLieuDen.Text = $"Tháng {thang}/{nam} • Dữ liệu đến {DateTime.Today:dd/MM/yyyy}";
            lblNganSachThang102026.Text = $"Ngân sách tháng {thang}/{nam}";

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

            lblTongHanMuc2.Text = $"{tongHanMuc:N0} đ";
            lblSoDanhMucDaDat.Text = $"{danhSachNS.Count(x => x.HanMuc > 0)} danh mục đã đặt hạn mức";

            lblDaChi2.Text = $"{tongDaChi:N0} đ";
            double ptTong = tongHanMuc > 0 ? (double)(tongDaChi / tongHanMuc * 100) : 0;
            lblPhanTramTongHanMuc.Text = $"{ptTong:N1}% tổng hạn mức";

            decimal conLai = tongHanMuc - tongDaChi;
            lblConLai2.Text = $"{conLai:N0} đ";
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
            decimal hanMuc = item?.HanMuc ?? 0;
            decimal daChi = DataService.GetTongChiTheoLoai(categoryName, thang, nam);
            tongDaChiAccumulator += daChi;

            if (hanMuc > 0)
            {
                lblChiTiet.Text = $"{daChi:N0} đ / {hanMuc:N0} đ";
                double pt = (double)(daChi / hanMuc * 100);
                prg.Value = Math.Min(100, Math.Max(0, (int)pt));
                lblTyLe.Text = $"{pt:N0}%";

                decimal conLai = hanMuc - daChi;
                lblConLai.Text = $"{conLai:N0} đ";

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
                lblChiTiet.Text = $"{daChi:N0} đ / —";
                prg.Value = 0;
                lblTyLe.Text = "—";
                lblConLai.Text = "—";
                lblTrangThai.Text = "Chưa đặt hạn mức";
                lblTrangThai.ForeColor = Color.Gray;
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadNganSachData();
        }

        private void btnDatHanMuc_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(cboThang.SelectedItem?.ToString(), out int thang)) thang = 10;
            if (!int.TryParse(cboNam.SelectedItem?.ToString(), out int nam)) nam = 2026;

            using (var dlg = new Form())
            {
                dlg.Text = $"Đặt hạn mức - Tháng {thang}/{nam}";
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
                    if (decimal.TryParse(raw, out decimal hm) && hm >= 0)
                    {
                        var ns = new NganSachItem
                        {
                            Thang = thang,
                            Nam = nam,
                            LoaiChi = cboCat.SelectedItem?.ToString() ?? "",
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

        private void btnSaoChep_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(cboThang.SelectedItem?.ToString(), out int thang)) thang = 10;
            if (!int.TryParse(cboNam.SelectedItem?.ToString(), out int nam)) nam = 2026;

            int thangTruoc = thang == 1 ? 12 : thang - 1;
            int namTruoc = thang == 1 ? nam - 1 : nam;

            var dr = MessageBox.Show($"Bạn có muốn sao chép ngân sách từ tháng {thangTruoc}/{namTruoc} sang tháng {thang}/{nam}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                DataService.SaoChepNganSach(thangTruoc, namTruoc, thang, nam);
                MessageBox.Show("Đã sao chép ngân sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNganSachData();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadNganSachData();
        }

        // Navigation
        private void btnThuNhap_Click(object sender, EventArgs e) => NavigateTo<frmQuanLyThuNhap>();
        private void btnChiTieu_Click(object sender, EventArgs e) => NavigateTo<frmQuanLyChiTieu>();
        private void btnBaoCao_Click(object sender, EventArgs e) => NavigateTo<frmTimKiem>();
        private void btnTimKiem_Click(object sender, EventArgs e) => NavigateTo<frmTimKiem>();
    }
}
