using System;
using System.Data;
using System.Windows.Forms;
using NghiepVu;
using NghiepVu.TienIch;
using LTWIN_N05_QLCT.Services;

namespace LTWIN_N05_QLCT.Forms.BaoCao
{
    public partial class frmBieuDo : Form
    {
        private DataTable _chiTheoLoai;
        private DataTable _chiLuyKe;
        private DataTable _thuChi12Thang;

        public frmBieuDo()
        {
            InitializeComponent();
            // Dữ liệu Designer chỉ phục vụ xem bố cục, không hiển thị như dữ liệu thật.
            foreach (var chart in new[] { chartChiTheoLoai, chartXuHuong, chartThuChi })
                foreach (var series in chart.Series)
                    series.Points.Clear();
            lblGhiChu.Text = "Tất cả ví • Chuyển tiền nội bộ không tính vào thu – chi.";

            Load += (s, e) =>
            {
                dtpKyXem.Value = DateTime.Today;
                TaiBieuDo();
            };

            btnXemBieuDo.Click += (s, e) => TaiBieuDo();
            btnXuatExcel.Click += XuatBieuDo;
            btnXuatPdf.Click += XuatBieuDo;
        }

        private void XuatBieuDo(object sender, EventArgs e)
        {
            // Nạp lại kỳ đang chọn để bảng xuất và ảnh biểu đồ khớp nhau.
            if (!TaiBieuDo()) return;
            bool xuatPdf = sender == btnXuatPdf;
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = xuatPdf ? "PDF (*.pdf)|*.pdf" : "Excel (*.xlsx)|*.xlsx";
                dialog.DefaultExt = xuatPdf ? "pdf" : "xlsx";
                dialog.FileName = "BieuDo_" + dtpKyXem.Value.ToString("yyyyMM") +
                    (xuatPdf ? ".pdf" : ".xlsx");
                if (dialog.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    if (xuatPdf)
                        XuatBieuDoService.XuatPdf(dialog.FileName, dtpKyXem.Value,
                            _chiTheoLoai, _chiLuyKe, _thuChi12Thang,
                            chartChiTheoLoai, chartXuHuong, chartThuChi);
                    else
                        XuatBieuDoService.XuatExcel(dialog.FileName, dtpKyXem.Value,
                            _chiTheoLoai, _chiLuyKe, _thuChi12Thang,
                            chartChiTheoLoai, chartXuHuong, chartThuChi);
                    MessageBox.Show(this, "Đã xuất báo cáo:\n" + dialog.FileName,
                        "Xuất báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Không thể xuất báo cáo: " + ex.Message,
                        "Lỗi xuất báo cáo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool TaiBieuDo()
        {
            if (!PhienDangNhap.DaDangNhap)
                return false;
            try
            {
                int maND = PhienDangNhap.MaND;
                DateTime ky = dtpKyXem.Value;

                TaiXuHuongChiTieu(maND, ky);

                DataTable dt = ThongKeNV.LayChiTheoLoaiThang(maND, ky.Month, ky.Year);
                _chiTheoLoai = dt;
                TaiThuChi12Thang(maND, ky);

                var series = chartChiTheoLoai.Series["Chi theo loại"];
                series.Points.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    series.Points.AddXY(
                    row["TenLoaiChi"].ToString(),
                    Convert.ToDecimal(row["TongChi"]));
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải biểu đồ: " + ex.Message);
                return false;
            }
        }

        private void TaiThuChi12Thang(int maND, DateTime ky)
        {
            _thuChi12Thang = ThongKeNV.LayThuChi12Thang(maND, ky);
            var thu = chartThuChi.Series["Thu"];
            var chi = chartThuChi.Series["Chi"];
            thu.Points.Clear();
            chi.Points.Clear();
            thu.ToolTip = "Thu tháng #AXISLABEL: #VALY{N0} đ";
            chi.ToolTip = "Chi tháng #AXISLABEL: #VALY{N0} đ";
            thu.IsValueShownAsLabel = false;
            chi.IsValueShownAsLabel = false;
            foreach (DataRow row in _thuChi12Thang.Rows)
            {
                string nhan = Convert.ToDateTime(row["Thang"]).ToString("MM/yyyy");
                thu.Points.AddXY(nhan, Convert.ToDecimal(row["TongThu"]));
                chi.Points.AddXY(nhan, Convert.ToDecimal(row["TongChi"]));
            }
            var area = chartThuChi.ChartAreas["VungVe"];
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = -45;
            area.AxisY.Minimum = 0;
            area.AxisY.Title = "Đồng";
            area.AxisY.LabelStyle.Format = "N0";
            area.RecalculateAxesScale();
            lblpnlThuChi.Text = "Thu – Chi 12 tháng gần nhất";
            lblGhiChu.Text = string.Format("Từ {0:MM/yyyy} đến {1:MM/yyyy} • Tất cả ví • Chuyển tiền nội bộ không tính vào thu – chi.",
                ky.AddMonths(-11), ky);
        }

        private void TaiXuHuongChiTieu(int maND, DateTime ky)
        {
            var series = chartXuHuong.Series["Chi lũy kế"];
            series.Points.Clear();

            DataTable dt = ThongKeNV.LayXuHuongChiThang(maND, ky.Month, ky.Year);
            _chiLuyKe = dt;
            series.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series.ToolTip = "Ngày #VALX{dd/MM/yyyy}: #VALY{N0} đ";

            var area = chartXuHuong.ChartAreas["VungVe"];
            area.AxisX.LabelStyle.Format = "dd/MM";
            area.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            area.AxisX.Interval = 5;
            area.AxisX.Minimum = new DateTime(ky.Year, ky.Month, 1).ToOADate();
            area.AxisX.Maximum = new DateTime(ky.Year, ky.Month,
                DateTime.DaysInMonth(ky.Year, ky.Month)).ToOADate();
            area.AxisY.Title = "Đồng";
            area.AxisY.LabelStyle.Format = "N0";
            area.AxisY.Minimum = 0;

            foreach (DataRow row in dt.Rows)
            {
                series.Points.AddXY(
                    Convert.ToDateTime(row["Ngay"]),
                    Convert.ToDecimal(row["ChiLuyKe"]));
            }

            bool coChiTieu = dt.Rows.Count > 0 &&
                Convert.ToDecimal(dt.Rows[dt.Rows.Count - 1]["ChiLuyKe"]) > 0;
            lblpnlXuHuong.Text = coChiTieu
                ? $"Xu hướng chi tiêu lũy kế • {ky:MM/yyyy} • Tất cả ví"
                : $"Chưa có chi tiêu • {ky:MM/yyyy} • Tất cả ví";
            chartXuHuong.ChartAreas["VungVe"].RecalculateAxesScale();
        }
    }
}
