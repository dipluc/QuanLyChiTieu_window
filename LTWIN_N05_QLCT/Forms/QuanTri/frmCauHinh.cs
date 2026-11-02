using System;
using System.IO;
using System.Windows.Forms;
using LTWIN_N05_QLCT.Models;
using LTWIN_N05_QLCT.Services;

namespace LTWIN_N05_QLCT.Forms.QuanTri
{
    public partial class frmCauHinh : Form
    {
        private int _currentNguong = 80;

        public frmCauHinh()
        {
            InitializeComponent();
            SetupEvents();
            LoadConfig();
        }

        private void SetupEvents()
        {
            this.btnDuyetThuMuc.Click += BtnDuyetThuMuc_Click;
            this.btnTang.Click += (s, e) => AdjustThreshold(5);
            this.btnGiam.Click += (s, e) => AdjustThreshold(-5);
            this.btnLuuThayDoi.Click += BtnLuuThayDoi_Click;
            this.btnHuy.Click += (s, e) => LoadConfig();
        }

        public void LoadConfig()
        {
            var cfg = DataService.GetCauHinh();
            if (cfg != null)
            {
                txtThuMucSaoLuuMacDinh.Text = cfg.ThuMucSaoLuu;
                chkTuDongSaoLuuKhiThoat.Checked = cfg.TuDongSaoLuuKhiThoat;
                _currentNguong = cfg.NguongCanhBao;
            }
            txtNguongCanhBao.Text = string.Format("{0}", _currentNguong);
            lblGiaiThichNguong.Text = string.Format("Hiển thị cảnh báo khi chi tiêu đạt từ {0}% hạn mức ngân sách trở lên.", _currentNguong);
        }

        private void AdjustThreshold(int delta)
        {
            _currentNguong += delta;
            if (_currentNguong < 10) _currentNguong = 10;
            if (_currentNguong > 100) _currentNguong = 100;

            txtNguongCanhBao.Text = string.Format("{0}", _currentNguong);
            lblGiaiThichNguong.Text = string.Format("Hiển thị cảnh báo khi chi tiêu đạt từ {0}% hạn mức ngân sách trở lên.", _currentNguong);
        }

        private void BtnDuyetThuMuc_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Chọn thư mục sao lưu dữ liệu";
                if (!string.IsNullOrEmpty(txtThuMucSaoLuuMacDinh.Text) && Directory.Exists(txtThuMucSaoLuuMacDinh.Text))
                {
                    fbd.SelectedPath = txtThuMucSaoLuuMacDinh.Text;
                }

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtThuMucSaoLuuMacDinh.Text = fbd.SelectedPath;
                }
            }
        }

        private void BtnLuuThayDoi_Click(object sender, EventArgs e)
        {
            try
            {
                string rawNguong = txtNguongCanhBao.Text.Replace("%", "").Trim();
                int nguong;
                if (!int.TryParse(rawNguong, out nguong) || nguong < 10 || nguong > 100)
                {
                    MessageBox.Show("Ngưỡng cảnh báo phải là số từ 10% đến 100%!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var cfg = new CauHinhApp
                {
                    ThuMucSaoLuu = txtThuMucSaoLuuMacDinh.Text.Trim(),
                    TuDongSaoLuuKhiThoat = chkTuDongSaoLuuKhiThoat.Checked,
                    NguongCanhBao = nguong
                };

                DataService.LuuCauHinh(cfg);
                MessageBox.Show("Lưu cấu hình thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Lỗi khi lưu cấu hình: {0}", ex.Message), "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
