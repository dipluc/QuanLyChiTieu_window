using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LTWIN_N05_QLCT.Services
{
    public static class XuatExcelHelper
    {
        public static void XuatDataGridViewRaExcel(DataGridView dgv, string tenMacDinh, string tieuDe)
        {
            if (dgv == null || dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu trong bảng để xuất.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Tệp bảng tính Excel (*.csv)|*.csv|Tất cả tệp (*.*)|*.*";
                sfd.FileName = string.Format("{0}_{1}.csv", tenMacDinh, DateTime.Now.ToString("ddMMyyyy_HHmm"));
                sfd.Title = "Lưu tệp xuất Excel";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (var sw = new StreamWriter(sfd.FileName, false, new UTF8Encoding(true)))
                    {
                        sw.WriteLine(string.Format("\"{0}\"", tieuDe.ToUpper()));
                        sw.WriteLine(string.Format("\"Ngày xuất: {0}\"", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")));
                        sw.WriteLine();

                        // Header
                        var headers = new List<string>();
                        foreach (DataGridViewColumn col in dgv.Columns)
                        {
                            if (col.Visible)
                                headers.Add("\"" + col.HeaderText.Replace("\"", "\"\"") + "\"");
                        }
                        sw.WriteLine(string.Join(",", headers));

                        // Rows
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (row.IsNewRow) continue;
                            var cells = new List<string>();
                            foreach (DataGridViewColumn col in dgv.Columns)
                            {
                                if (!col.Visible) continue;
                                object val = row.Cells[col.Index].Value;
                                string str = val != null ? val.ToString().Replace("\"", "\"\"") : "";
                                cells.Add("\"" + str + "\"");
                            }
                            sw.WriteLine(string.Join(",", cells));
                        }
                    }

                    var dr = MessageBox.Show(string.Format("Đã xuất dữ liệu ra tệp Excel thành công!\n\nĐường dẫn: {0}\n\nBạn có muốn mở tệp ngay không?", sfd.FileName),
                        "Xuất thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dr == DialogResult.Yes && File.Exists(sfd.FileName))
                    {
                        Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi ghi tệp: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

