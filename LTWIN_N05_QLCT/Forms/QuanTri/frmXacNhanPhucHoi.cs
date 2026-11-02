using System;
using System.IO;
using System.Windows.Forms;
using DuLieu;

namespace LTWIN_N05_QLCT.Forms.QuanTri
{
    public partial class frmXacNhanPhucHoi : Form
    {
        private readonly string _duongDan;

        public frmXacNhanPhucHoi()
        {
            InitializeComponent();
            btnPhucHoi.Click += btnPhucHoi_Click;
        }

        public frmXacNhanPhucHoi(string tenTep, string ngayTao, string dungLuong, string duongDan) : this()
        {
            _duongDan = duongDan;
            if (!string.IsNullOrEmpty(tenTep))
            {
                lblTenTep.Text = tenTep;
            }
            if (!string.IsNullOrEmpty(ngayTao) || !string.IsNullOrEmpty(dungLuong))
            {
                lblThongTin.Text = string.Format("Ngày tạo: {0} • Dung lượng: {1}", ngayTao, dungLuong);
            }
        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_duongDan) || !File.Exists(_duongDan))
            {
                MessageBox.Show("Không tìm thấy tệp bản sao lưu đã chọn.", "Lỗi phục hồi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tìm file MDF đích của dự án
            string[] cacDuongDanMdf = new string[]
            {
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Database\QLChiTieu.mdf")),
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\LTWIN_N05_QLCT\Database\QLChiTieu.mdf")),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "QLChiTieu.mdf"),
            };

            string mdfDich = null;
            foreach (var p in cacDuongDanMdf)
            {
                if (File.Exists(p))
                {
                    mdfDich = p;
                    break;
                }
            }

            if (mdfDich == null)
            {
                MessageBox.Show("Không tìm thấy đường dẫn tệp cơ sở dữ liệu hiện tại để phục hồi.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnPhucHoi.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                // Ngắt kết nối để copy
                string thuMucMdf = Path.GetDirectoryName(mdfDich);
                string ldfDich = Path.Combine(thuMucMdf, "QLChiTieu_log.ldf");

                File.Copy(_duongDan, mdfDich, true);

                // Nếu có file log tương ứng
                string ldfNguon = _duongDan.Replace(".bak", "_log.bak");
                if (File.Exists(ldfNguon) && File.Exists(ldfDich))
                {
                    File.Copy(ldfNguon, ldfDich, true);
                }

                // Đồng bộ luôn sang thư mục bin\Debug nếu khác
                string mdfBin = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "QLChiTieu.mdf");
                string ldfBin = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "QLChiTieu_log.ldf");
                if (File.Exists(mdfBin) && !mdfBin.Equals(mdfDich, StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        File.Copy(mdfDich, mdfBin, true);
                        if (File.Exists(ldfDich)) File.Copy(ldfDich, ldfBin, true);
                    }
                    catch { }
                }

                MessageBox.Show("Phục hồi cơ sở dữ liệu thành công!\n\nToàn bộ dữ liệu đã được khôi phục từ bản sao lưu.",
                    "Phục hồi thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình phục hồi: " + ex.Message + "\n\n(Nếu tệp đang bị khóa, hãy khởi động lại ứng dụng và thử lại).",
                    "Lỗi phục hồi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnPhucHoi.Enabled = true;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
