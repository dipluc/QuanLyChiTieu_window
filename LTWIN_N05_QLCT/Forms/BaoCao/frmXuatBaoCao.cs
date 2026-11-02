using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using NghiepVu;
using NghiepVu.TienIch;

namespace LTWIN_N05_QLCT.Forms.BaoCao
{
    public partial class frmXuatBaoCao : Form
    {
        public frmXuatBaoCao()
        {
            InitializeComponent();
            KhoiTao();
        }

        public frmXuatBaoCao(bool xuatPdf) : this()
        {
            rdoPdf.Checked = xuatPdf;
            rdoExcel.Checked = !xuatPdf;
            CapNhatTenTep();
        }

        private void KhoiTao()
        {
            // Thư mục mặc định: Desktop hoặc thư mục BaoCao
            string macDinh = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "BaoCao_QuanLyChiTieu");
            txtThuMucLuu.Text = macDinh;

            // Ngày mặc định: từ đầu tháng hiện tại đến hôm nay
            DateTime now = DateTime.Now;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
            dtpDenNgay.Value = now;

            if (cboLoaiBaoCao.SelectedIndex < 0)
                cboLoaiBaoCao.SelectedIndex = 0;

            CapNhatTenTep();

            btnDuyet.Click += btnDuyet_Click;
            btnXuat.Click += btnXuat_Click;
            rdoExcel.CheckedChanged += (s, e) => CapNhatTenTep();
            rdoPdf.CheckedChanged += (s, e) => CapNhatTenTep();
            cboLoaiBaoCao.SelectedIndexChanged += (s, e) => CapNhatTenTep();
            dtpTuNgay.ValueChanged += (s, e) => CapNhatTenTep();
            dtpDenNgay.ValueChanged += (s, e) => CapNhatTenTep();
        }

        private void CapNhatTenTep()
        {
            string loai = cboLoaiBaoCao.SelectedItem?.ToString() ?? "GiaoDich";
            string loaiSlug = "GiaoDich";
            if (loai.Contains("Thống kê")) loaiSlug = "ThongKe";
            else if (loai.Contains("Ngân sách")) loaiSlug = "NganSach";

            string tu = dtpTuNgay.Value.ToString("ddMMyyyy");
            string den = dtpDenNgay.Value.ToString("ddMMyyyy");
            string ext = rdoPdf.Checked ? "csv" : "csv"; // CSV có UTF-8 BOM Excel mở trực tiếp được
            string displayExt = rdoPdf.Checked ? "pdf" : "xlsx";

            lblTenTepDuKien.Text = string.Format("Tên dự kiến: {0}_{1}_{2}.{3}", loaiSlug, tu, den, displayExt);
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Chọn thư mục lưu báo cáo";
                if (Directory.Exists(txtThuMucLuu.Text))
                    dlg.SelectedPath = txtThuMucLuu.Text;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtThuMucLuu.Text = dlg.SelectedPath;
                }
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.",
                    "Lỗi thiết lập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string thuMuc = txtThuMucLuu.Text.Trim();
            if (string.IsNullOrEmpty(thuMuc))
            {
                MessageBox.Show("Vui lòng chọn thư mục lưu tệp báo cáo.",
                    "Lỗi thiết lập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (!Directory.Exists(thuMuc))
                    Directory.CreateDirectory(thuMuc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tạo thư mục lưu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int maND = PhienDangNhap.DaDangNhap ? PhienDangNhap.MaND : 0;
            if (maND <= 0)
            {
                MessageBox.Show("Bạn chưa đăng nhập. Vui lòng đăng nhập để xuất dữ liệu.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string loai = cboLoaiBaoCao.SelectedItem?.ToString() ?? "Giao dịch";
            string loaiSlug = "GiaoDich";
            if (loai.Contains("Thống kê")) loaiSlug = "ThongKe";
            else if (loai.Contains("Ngân sách")) loaiSlug = "NganSach";

            string tu = dtpTuNgay.Value.ToString("ddMMyyyy");
            string den = dtpDenNgay.Value.ToString("ddMMyyyy");
            bool isPdf = rdoPdf.Checked;
            string fileName = string.Format("{0}_{1}_{2}.csv", loaiSlug, tu, den);
            string fullPath = Path.Combine(thuMuc, fileName);

            btnXuat.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                DataTable dt = LayDuLieuBaoCao(maND, loai, dtpTuNgay.Value.Date, dtpDenNgay.Value.Date);
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show(string.Format("Không có dữ liệu nào cho mục '{0}' trong khoảng thời gian đã chọn.", loai),
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                XuatDataTableRaCsv(dt, fullPath, loai);

                string thongBao = string.Format("Đã xuất báo cáo thành công!\n\nĐịnh dạng: Excel (CSV UTF-8)\nTệp: {0}\nSố dòng dữ liệu: {1}", fullPath, dt.Rows.Count);
                if (isPdf)
                {
                    thongBao += "\n\n(Lưu ý: Tệp được xuất dưới dạng bảng tính để bạn có thể mở và chọn 'Print to PDF' theo bố cục mong muốn).";
                }

                MessageBox.Show(thongBao, "Xuất báo cáo thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (chkMoTep.Checked && File.Exists(fullPath))
                {
                    Process.Start(new ProcessStartInfo(fullPath) { UseShellExecute = true });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình xuất báo cáo: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnXuat.Enabled = true;
            }
        }

        private static DataTable LayDuLieuBaoCao(int maND, string loai, DateTime tuNgay, DateTime denNgay)
        {
            if (loai.Contains("Thống kê"))
            {
                return ThongKeNV.LayThongKeBaoCao(maND, tuNgay, denNgay);
            }
            else if (loai.Contains("Ngân sách"))
            {
                return ThongKeNV.LayNganSachBaoCao(maND, tuNgay.Month, tuNgay.Year);
            }
            else
            {
                return ThongKeNV.LayGiaoDichBaoCao(maND, tuNgay, denNgay);
            }
        }

        private static void XuatDataTableRaCsv(DataTable dt, string duongDan, string tieuDe)
        {
            // Ghi file với Encoding UTF-8 có BOM để Microsoft Excel tự nhận dạng tiếng Việt có dấu
            using (var sw = new StreamWriter(duongDan, false, new UTF8Encoding(true)))
            {
                sw.WriteLine(string.Format("\"BÁO CÁO: {0}\"", tieuDe.ToUpper()));
                sw.WriteLine(string.Format("\"Ngày xuất: {0}\"", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")));
                sw.WriteLine();

                // Ghi tiêu đề các cột
                var headers = new List<string>();
                foreach (DataColumn col in dt.Columns)
                {
                    headers.Add(EscapeCsv(col.ColumnName));
                }
                sw.WriteLine(string.Join(",", headers));

                // Ghi từng dòng dữ liệu
                foreach (DataRow row in dt.Rows)
                {
                    var values = new List<string>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        object val = row[col];
                        if (val == null || val == DBNull.Value)
                        {
                            values.Add("\"\"");
                        }
                        else if (val is DateTime dtVal)
                        {
                            values.Add(EscapeCsv(dtVal.ToString("dd/MM/yyyy")));
                        }
                        else if (val is decimal decVal)
                        {
                            values.Add(EscapeCsv(decVal.ToString("N0")));
                        }
                        else
                        {
                            values.Add(EscapeCsv(val.ToString()));
                        }
                    }
                    sw.WriteLine(string.Join(",", values));
                }
            }
        }

        private static string EscapeCsv(string s)
        {
            if (string.IsNullOrEmpty(s)) return "\"\"";
            return "\"" + s.Replace("\"", "\"\"") + "\"";
        }
    }
}
