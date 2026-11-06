using DuLieu;
using LTWIN_N05_QLCT.Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using LTWIN_N05_QLCT.Services;

namespace LTWIN_N05_QLCT.Forms.QuanTri
{
    public partial class frmSaoLuu : Form
    {
        private static readonly string[] _duongDanMDF = new string[]
        {
            Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Database\QLChiTieu.mdf")),
            Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\LTWIN_N05_QLCT\Database\QLChiTieu.mdf")),
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "QLChiTieu.mdf")
        };

        private static readonly string[] _duongDanLDF = new string[]
        {
            Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Database\QLChiTieu_log.ldf")),
            Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\LTWIN_N05_QLCT\Database\QLChiTieu_log.ldf")),
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "QLChiTieu_log.ldf")
        };

        public frmSaoLuu()
        {
            InitializeComponent();
            KhoiTao();

            // Có sẵn đường dẫn dự phòng nếu đọc cấu hình thất bại.
            txtThuMucSaoLuu.Text = SaoLuuServices.LayThuMuc(null);

            try
            {
                var cfg = DataService.GetCauHinh();

                txtThuMucSaoLuu.Text = SaoLuuServices.LayThuMuc(
                    cfg == null ? null : cfg.ThuMucSaoLuu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không đọc được cấu hình thư mục sao lưu.\n" +
                    "Ứng dụng sẽ dùng thư mục Documents.\n\n" + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void KhoiTao()
        {
            btnDuyet.Click += btnDuyet_Click;
            btnSaoLuu.Click += btnSaoLuu_Click;
            btnPhucHoi.Click += btnPhucHoi_Click;
            lvSaoLuu.SelectedIndexChanged += (s, e) => CapNhatDaChon();
            Load += (s, e) => TaiDanhSachSaoLuu();
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Chọn thư mục lưu trữ các bản sao lưu";
                if (Directory.Exists(txtThuMucSaoLuu.Text))
                    dlg.SelectedPath = txtThuMucSaoLuu.Text;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtThuMucSaoLuu.Text = dlg.SelectedPath;
                    TaiDanhSachSaoLuu();
                }
            }
        }

        private async void btnSaoLuu_Click(object sender, EventArgs e)
        {
            string thuMuc = txtThuMucSaoLuu.Text.Trim();

            if (string.IsNullOrWhiteSpace(thuMuc))
            {
                MessageBox.Show("Vui lòng chọn thư mục sao lưu.");
                return;
            }

            btnSaoLuu.Enabled = false;
            btnPhucHoi.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                string duongDan = await Task.Run(
                    () => SaoLuuServices.TaoBanSaoLuu(thuMuc));

                MessageBox.Show(
                    "Sao lưu thành công!\n\nTệp: " + duongDan,
                    "Sao lưu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                TaiDanhSachSaoLuu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể sao lưu: " + ex.Message,
                    "Lỗi sao lưu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnSaoLuu.Enabled = true;
                btnPhucHoi.Enabled = true;
            }
        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            if (lvSaoLuu.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một bản sao lưu từ danh sách để phục hồi.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = lvSaoLuu.SelectedItems[0];
            string tenTep = item.Text;
            string ngayTao = item.SubItems.Count > 1 ? item.SubItems[1].Text : "";
            string dungLuong = item.SubItems.Count > 2 ? item.SubItems[2].Text : "";
            string duongDan = item.Tag as string;

            using (var form = new frmXacNhanPhucHoi(tenTep, ngayTao, dungLuong, duongDan))
            {
                if (form.ShowDialog(TopLevelControl) == DialogResult.OK)
                {
                    TaiDanhSachSaoLuu();
                }
            }
        }

        private void TaiDanhSachSaoLuu()
        {
            lvSaoLuu.Items.Clear();
            string thuMuc = txtThuMucSaoLuu.Text.Trim();

            if (!Directory.Exists(thuMuc))
            {
                lblSoLuong.Text = "0 bản sao lưu";
                lblDaChon.Text = "Chưa chọn bản sao lưu nào";
                return;
            }

            var files = Directory.GetFiles(thuMuc, "*.bak");
            Array.Sort(files, (a, b) => File.GetCreationTime(b).CompareTo(File.GetCreationTime(a)));

            int count = 0;
            foreach (string f in files)
            {
                // Bỏ qua file log phụ
                if (f.EndsWith("_log.bak", StringComparison.OrdinalIgnoreCase)) continue;

                var fi = new FileInfo(f);
                string dungLuong = fi.Length < 1024 * 1024
                    ? string.Format("{0:0.0} KB", fi.Length / 1024.0)
                    : string.Format("{0:0.0} MB", fi.Length / (1024.0 * 1024.0));

                var item = new ListViewItem(fi.Name);
                item.SubItems.Add(fi.CreationTime.ToString("dd/MM/yyyy HH:mm"));
                item.SubItems.Add(dungLuong);
                item.SubItems.Add("Thủ công");
                item.Tag = f;

                if (count % 2 == 0)
                {
                    item.BackColor = System.Drawing.Color.FromArgb(246, 249, 253);
                }

                lvSaoLuu.Items.Add(item);
                count++;
            }

            lblSoLuong.Text = string.Format("{0} bản sao lưu", count);
            lblDaChon.Text = count > 0 ? "Chưa chọn bản sao lưu nào" : "Không có bản sao lưu";
        }

        private void CapNhatDaChon()
        {
            if (lvSaoLuu.SelectedItems.Count > 0)
            {
                lblDaChon.Text = "Đã chọn: " + lvSaoLuu.SelectedItems[0].Text;
            }
            else
            {
                lblDaChon.Text = "Chưa chọn bản sao lưu nào";
            }
        }

        private static string TimFileMDF()
        {
            foreach (var p in _duongDanMDF)
            {
                if (File.Exists(p)) return p;
            }
            return null;
        }

        private static string TimFileLDF()
        {
            foreach (var p in _duongDanLDF)
            {
                if (File.Exists(p)) return p;
            }
            return null;
        }
    }
}
