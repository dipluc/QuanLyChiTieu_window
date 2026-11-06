using DuLieu;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

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
                MessageBox.Show("Không tìm thấy bản sao lưu.");
                return;
            }

            if (MessageBox.Show(
                "Phục hồi sẽ thay thế toàn bộ dữ liệu hiện tại. Tiếp tục?",
                "Xác nhận phục hồi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            btnPhucHoi.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                string tenDatabase;
                SqlConnectionStringBuilder builder;

                // Xác định database thực tế mà ứng dụng đang dùng.
                using (SqlConnection conn = KetNoiCSDL.LayKetNoi())
                {
                    tenDatabase = conn.Database;
                    builder = new SqlConnectionStringBuilder(
                        conn.ConnectionString);
                }

                if (string.IsNullOrWhiteSpace(tenDatabase) ||
                    tenDatabase.Equals("master",
                        StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException(
                        "Không xác định được database cần phục hồi.");
                }

                // Kết nối tới master, không tự attach file MDF.
                builder.Remove("AttachDbFilename");
                builder.InitialCatalog = "master";
                builder.Pooling = false;

                SqlConnection.ClearAllPools();

                string tenSql = "[" + tenDatabase.Replace("]", "]]") + "]";

                using (SqlConnection conn =
                    new SqlConnection(builder.ConnectionString))
                {
                    conn.Open();

                    // Kiểm tra file trước khi ngắt kết nối database.
                    using (SqlCommand cmd = new SqlCommand(
                        "RESTORE VERIFYONLY FROM DISK = @tep;", conn))
                    {
                        cmd.CommandTimeout = 300;
                        cmd.Parameters.Add(
                            "@tep", SqlDbType.NVarChar, 4000
                        ).Value = Path.GetFullPath(_duongDan);

                        cmd.ExecuteNonQuery();
                    }

                    bool daChuyenSingleUser = false;

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            "ALTER DATABASE " + tenSql +
                            " SET SINGLE_USER WITH ROLLBACK IMMEDIATE;",
                            conn))
                        {
                            cmd.CommandTimeout = 300;
                            cmd.ExecuteNonQuery();
                            daChuyenSingleUser = true;
                        }

                        using (SqlCommand cmd = new SqlCommand(
                            "RESTORE DATABASE " + tenSql +
                            " FROM DISK = @tep WITH REPLACE, RECOVERY;",
                            conn))
                        {
                            cmd.CommandTimeout = 300;
                            cmd.Parameters.Add(
                                "@tep", SqlDbType.NVarChar, 4000
                            ).Value = Path.GetFullPath(_duongDan);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    finally
                    {
                        if (daChuyenSingleUser)
                        {
                            using (SqlCommand cmd = new SqlCommand(
                                "ALTER DATABASE " + tenSql +
                                " SET MULTI_USER WITH ROLLBACK IMMEDIATE;",
                                conn))
                            {
                                cmd.CommandTimeout = 300;
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }

                MessageBox.Show(
                    "Phục hồi thành công!\n" +
                    "Hãy đóng và mở lại ứng dụng để tải lại dữ liệu.",
                    "Phục hồi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể phục hồi: " + ex.Message,
                    "Lỗi phục hồi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                SqlConnection.ClearAllPools();
                Cursor = Cursors.Default;
                btnPhucHoi.Enabled = true;
            }
        }
    }
}
