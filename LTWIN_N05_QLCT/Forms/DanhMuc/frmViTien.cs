using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using NghiepVu;
using NghiepVu.TienIch;

namespace LTWIN_N05_QLCT.Forms.DanhMuc
{
    public partial class frmViTien : Form
    {
        private static readonly Color MauXanh = Color.FromArgb(21, 101, 192);
        private static readonly Color MauChu = Color.FromArgb(30, 41, 59);
        private static readonly Color MauNenXen = Color.FromArgb(248, 250, 252);
        private static readonly Color MauDo = Color.FromArgb(198, 40, 40);
        private static readonly Color MauXanhLa = Color.FromArgb(46, 125, 50);
        private static readonly Color MauXam = Color.FromArgb(148, 163, 184);

        private DataTable tblViTien;
        private bool _dangNapDuLieu;       // chặn SelectionChanged khi đang nạp lại lưới
        private bool _dangDoDuLieu;        // chặn các sự kiện khi đang đổ dữ liệu lên ô nhập
        private int _maViDangChon;         // MaVi của ví đang chọn (0 = chưa chọn, đang ở chế độ nhập ví mới)

        // Thông tin của ví đang chọn lúc vừa hiển thị
        private string _ghiChuDangChon = "";
        private bool _trangThaiDangChon = true;
        private decimal _soDuBanDauCu;       // số dư ban đầu / hiện tại của ví đang chọn lúc vừa hiển thị
        private decimal _soDuHienTaiCu;
        private bool _dangDongBo;            // đang tự cập nhật ô số dư còn lại
        private int _oVuaSua;                // 0: chưa sửa, 1: vừa sửa số dư ban đầu, 2: vừa sửa số dư hiện tại

        public frmViTien()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            cboLoaiVi.DisplayMember = "Value";
            cboLoaiVi.ValueMember = "Key";
            cboLoaiVi.DataSource = ViTienNV.LayDanhSachLoaiVi();
            cboLoaiVi.SelectedIndex = -1;

            var dtTrangThai = new DataTable();
            dtTrangThai.Columns.Add("Ma", typeof(bool));
            dtTrangThai.Columns.Add("Ten", typeof(string));
            dtTrangThai.Rows.Add(true, "Đang sử dụng");
            dtTrangThai.Rows.Add(false, "Ngừng sử dụng");

            cboTrangThai.DisplayMember = "Ten";
            cboTrangThai.ValueMember = "Ma";
            cboTrangThai.DataSource = dtTrangThai;
            cboTrangThai.SelectedValue = true;

            CauHinhLuoi();

            // Các dòng chữ mẫu trong thiết kế -> nội dung thật
            lblSoDuHienTaiDuocTinh.Text = "Sửa ô số dư nào, ô còn lại tự cập nhật theo.";
            lblSoDuBanDauNgay01.Text = "Chọn một dòng để xem hoặc sửa";

            // Số dư: chỉ nhập chữ số (và dấu trừ ở đầu)
            txtSoDuHienTai.KeyPress += txtSoDuBanDau_KeyPress;

            // Hai ô số dư liên kết với nhau: sửa ô này thì ô kia tự cập nhật theo
            txtSoDuBanDau.TextChanged += (s, e) => DongBoSoDu(true);
            txtSoDuHienTai.TextChanged += (s, e) => DongBoSoDu(false);

            // Đổi trạng thái trên ô chọn => lưu ngay (không cần bấm Sửa)
            cboTrangThai.SelectionChangeCommitted += (s, e) => DoiTrangThai(TrangThaiDangChon());

            DatTrangThaiNut();
        }

        // ==========================================
        // LƯỚI DỮ LIỆU
        // ==========================================
        private void CauHinhLuoi()
        {
            dgvViTien.AutoGenerateColumns = false;
            dgvViTien.Columns.Clear();
            ThemCot("colTenVi", "TenVi", "Tên ví", 28, false);
            ThemCot("colLoaiVi", "LoaiVi", "Loại", 17, false);
            ThemCot("colSoDuBanDau", "SoDuBanDau", "Số dư ban đầu", 22, true);
            ThemCot("colSoDuHienTai", "SoDuHienTai", "Số dư hiện tại", 22, true);
            ThemCot("colTrangThai", "TrangThai", "Trạng thái", 16, false);

            dgvViTien.BackgroundColor = Color.White;
            dgvViTien.BorderStyle = BorderStyle.None;
            dgvViTien.RowHeadersVisible = false;
            dgvViTien.EnableHeadersVisualStyles = false;
            dgvViTien.GridColor = Color.FromArgb(226, 232, 240);
            dgvViTien.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvViTien.ColumnHeadersHeight = 36;
            dgvViTien.RowTemplate.Height = 30;
            dgvViTien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Lưới chỉ để xem/chọn: không cho sửa trực tiếp trên lưới
            dgvViTien.ReadOnly = true;
            dgvViTien.AllowUserToAddRows = false;
            dgvViTien.AllowUserToDeleteRows = false;
            dgvViTien.AllowUserToResizeRows = false;

            dgvViTien.ColumnHeadersDefaultCellStyle.BackColor = MauXanh;
            dgvViTien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvViTien.ColumnHeadersDefaultCellStyle.SelectionBackColor = MauXanh;
            dgvViTien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvViTien.DefaultCellStyle.ForeColor = MauChu;
            dgvViTien.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgvViTien.DefaultCellStyle.SelectionForeColor = MauChu;
            dgvViTien.AlternatingRowsDefaultCellStyle.BackColor = MauNenXen;
            dgvViTien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvViTien.MultiSelect = false;

            dgvViTien.CellFormatting += dgvViTien_CellFormatting;
            dgvViTien.SelectionChanged += dgvViTien_SelectionChanged;
            dgvViTien.DataError += (s, e) => { e.ThrowException = false; };
        }

        private void ThemCot(string ten, string thuocTinh, string tieuDe, float tyLe, bool laSoTien)
        {
            var cot = new DataGridViewTextBoxColumn
            {
                Name = ten,
                DataPropertyName = thuocTinh,
                HeaderText = tieuDe,
                FillWeight = tyLe,
                ReadOnly = true
            };
            if (laSoTien)
            {
                cot.DefaultCellStyle.Format = "N0";
                cot.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                cot.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            dgvViTien.Columns.Add(cot);
        }

        private void frmViTien_Load(object sender, EventArgs e)
        {
            if (!PhienDangNhap.DaDangNhap)
            {
                MessageBox.Show("Bạn cần đăng nhập để quản lý ví tiền.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnNgungSuDung.Enabled = false;
                btnMoi.Enabled = false;
                return;
            }
            LoadDataGridView();
            ResetValues();
        }

        private void LoadDataGridView()
        {
            _dangNapDuLieu = true;
            try
            {
                string loi;
                tblViTien = ViTienNV.LayDanhSach(out loi);
                if (!string.IsNullOrEmpty(loi))
                {
                    MessageBox.Show(loi, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dgvViTien.DataSource = tblViTien;
                dgvViTien.ClearSelection();
                CapNhatTongQuan();
            }
            finally
            {
                _dangNapDuLieu = false;
            }
        }

        // Hiển thị tên loại ví / trạng thái bằng tiếng Việt; ví ngừng sử dụng mờ đi; số âm màu đỏ
        private void dgvViTien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null || e.Value == DBNull.Value) return;

            string tenCot = dgvViTien.Columns[e.ColumnIndex].Name;
            var dong = dgvViTien.Rows[e.RowIndex].DataBoundItem as DataRowView;
            bool dangDung = dong == null || dong["TrangThai"] == DBNull.Value || Convert.ToBoolean(dong["TrangThai"]);

            if (tenCot == "colLoaiVi")
            {
                e.Value = ViTienNV.TenLoaiVi(e.Value.ToString());
                e.FormattingApplied = true;
            }
            else if (tenCot == "colTrangThai")
            {
                bool trangThai;
                if (bool.TryParse(e.Value.ToString(), out trangThai))
                {
                    e.Value = trangThai ? "Đang sử dụng" : "Ngừng sử dụng";
                    e.CellStyle.ForeColor = trangThai ? MauXanhLa : MauXam;
                    e.FormattingApplied = true;
                }
                return;
            }

            if (!dangDung)
            {
                e.CellStyle.ForeColor = MauXam;
            }
            else if ((tenCot == "colSoDuHienTai" || tenCot == "colSoDuBanDau") && e.Value is decimal && (decimal)e.Value < 0)
            {
                e.CellStyle.ForeColor = MauDo;
            }
        }

        // ==========================================
        // THẺ TỔNG QUAN (thay cho số liệu mẫu trong thiết kế)
        // ==========================================
        private void CapNhatTongQuan()
        {
            var vn = new CultureInfo("vi-VN");
            decimal tong = 0;
            int soDung = 0, soNgung = 0;
            var tenViDung = new List<string>();

            if (tblViTien != null)
            {
                foreach (DataRow r in tblViTien.Rows)
                {
                    if (r["SoDuHienTai"] != DBNull.Value) tong += Convert.ToDecimal(r["SoDuHienTai"]);

                    bool dangDung = r["TrangThai"] != DBNull.Value && Convert.ToBoolean(r["TrangThai"]);
                    if (dangDung)
                    {
                        soDung++;
                        tenViDung.Add(Convert.ToString(r["TenVi"]));
                    }
                    else
                    {
                        soNgung++;
                    }
                }
            }

            lblSoDuTien.Text = tong.ToString("N0", vn) + " ₫";
            lblViDangSuDung.Text = soDung + " ví";
            lblChiTietViDSD.Text = RutGonDanhSachTen(tenViDung);
            lblViNgungSuDung.Text = soNgung + " ví";
            lblNgayThongKe.Text = "Tất cả các ví • Số dư hiện tại ngày " + DateTime.Today.ToString("dd/MM/yyyy");
        }

        private static string RutGonDanhSachTen(List<string> ten)
        {
            if (ten.Count == 0) return "Chưa có ví nào";

            string kq = "";
            int daHien = 0;
            foreach (string t in ten)
            {
                string them = (kq.Length == 0 ? "" : " • ") + t;
                if (kq.Length + them.Length > 28 && daHien > 0) break;
                kq += them;
                daHien++;
            }
            if (daHien < ten.Count) kq += " +" + (ten.Count - daHien);
            return kq;
        }

        // ==========================================
        // CHỌN DÒNG / ĐỔ DỮ LIỆU LÊN Ô NHẬP
        // ==========================================
        private void dgvViTien_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangNapDuLieu || _dangDoDuLieu) return;
            if (dgvViTien.CurrentRow == null || dgvViTien.SelectedRows.Count == 0) return;

            var dong = dgvViTien.CurrentRow.DataBoundItem as DataRowView;
            if (dong == null) return;

            _dangDoDuLieu = true;
            try
            {
                _maViDangChon = dong["MaVi"] != DBNull.Value ? Convert.ToInt32(dong["MaVi"]) : 0;
                txtTenVi.Text = dong["TenVi"] != DBNull.Value ? dong["TenVi"].ToString() : "";
                cboLoaiVi.SelectedValue = dong["LoaiVi"] != DBNull.Value ? dong["LoaiVi"].ToString() : "";

                decimal soDuBanDau = dong["SoDuBanDau"] != DBNull.Value ? Convert.ToDecimal(dong["SoDuBanDau"]) : 0;
                decimal soDuHienTai = dong["SoDuHienTai"] != DBNull.Value ? Convert.ToDecimal(dong["SoDuHienTai"]) : 0;
                _soDuBanDauCu = soDuBanDau;
                _soDuHienTaiCu = soDuHienTai;
                _oVuaSua = 0;
                txtSoDuBanDau.Text = soDuBanDau.ToString("0", CultureInfo.InvariantCulture);
                txtSoDuHienTai.Text = soDuHienTai.ToString("0", CultureInfo.InvariantCulture);

                _ghiChuDangChon = dong["GhiChu"] != DBNull.Value ? dong["GhiChu"].ToString() : "";
                _trangThaiDangChon = dong["TrangThai"] != DBNull.Value && Convert.ToBoolean(dong["TrangThai"]);
                cboTrangThai.SelectedValue = _trangThaiDangChon;
            }
            finally
            {
                _dangDoDuLieu = false;
            }

            DatTrangThaiNut();
        }

        private void ResetValues()
        {
            _dangDoDuLieu = true;
            try
            {
                _maViDangChon = 0;
                _ghiChuDangChon = "";
                _trangThaiDangChon = true;
                txtTenVi.Text = "";
                cboLoaiVi.SelectedIndex = -1;
                txtSoDuBanDau.Text = "0";
                txtSoDuHienTai.Text = "0";
                cboTrangThai.SelectedValue = true;
                dgvViTien.ClearSelection();
            }
            finally
            {
                _dangDoDuLieu = false;
            }
            _soDuBanDauCu = 0;
            _soDuHienTaiCu = 0;
            _oVuaSua = 0;
            DatTrangThaiNut();
        }

        // Sửa ô này thì ô kia tự cập nhật.
        // Ví đã có: số dư hiện tại = số dư ban đầu + biến động giao dịch => hai ô lệch nhau một khoảng cố định.
        // Ví mới (chưa có giao dịch): hai ô luôn bằng nhau.
        private void DongBoSoDu(bool vuaSuaBanDau)
        {
            if (_dangDoDuLieu || _dangDongBo) return;

            TextBox nguon = vuaSuaBanDau ? txtSoDuBanDau : txtSoDuHienTai;
            TextBox dich = vuaSuaBanDau ? txtSoDuHienTai : txtSoDuBanDau;

            string chuoi = nguon.Text.Trim();
            decimal giaTri = 0;
            if (chuoi.Length > 0 && !decimal.TryParse(chuoi, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out giaTri))
                return;   // đang gõ dở (ví dụ mới có dấu trừ)

            decimal giaTriDich;
            if (_maViDangChon <= 0)
            {
                giaTriDich = giaTri;
            }
            else
            {
                _oVuaSua = vuaSuaBanDau ? 1 : 2;
                giaTriDich = vuaSuaBanDau
                    ? _soDuHienTaiCu + (giaTri - _soDuBanDauCu)
                    : _soDuBanDauCu + (giaTri - _soDuHienTaiCu);
            }

            _dangDongBo = true;
            try
            {
                dich.Text = giaTriDich.ToString("0", CultureInfo.InvariantCulture);
            }
            finally
            {
                _dangDongBo = false;
            }
        }

        private void DatTrangThaiNut()
        {
            bool coChon = _maViDangChon > 0;
            btnThem.Enabled = !coChon;
            btnSua.Enabled = coChon;
            btnNgungSuDung.Enabled = coChon;
            btnMoi.Enabled = true;
            btnNgungSuDung.Text = _trangThaiDangChon ? "Ngừng sử dụng" : "Sử dụng lại";
        }

        // Chọn lại một ví trên lưới sau khi nạp lại dữ liệu
        private void ChonLaiDong(int maVi)
        {
            foreach (DataGridViewRow dong in dgvViTien.Rows)
            {
                var d = dong.DataBoundItem as DataRowView;
                if (d != null && Convert.ToInt32(d["MaVi"]) == maVi)
                {
                    dgvViTien.CurrentCell = dong.Cells[0];
                    dong.Selected = true;
                    return;
                }
            }
        }

        // Đọc từ SelectedItem để đúng ngay cả trong sự kiện SelectionChangeCommitted
        private bool TrangThaiDangChon()
        {
            var dong = cboTrangThai.SelectedItem as DataRowView;
            return dong != null ? Convert.ToBoolean(dong["Ma"]) : true;
        }

        // ==========================================
        // NÚT: THÊM / SỬA / MỚI / NGỪNG SỬ DỤNG
        // ==========================================
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (_maViDangChon > 0)
            {
                MessageBox.Show("Bạn đang chọn một ví. Bấm \"Mới\" để nhập ví mới.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal soDu;
            if (!KiemTraNhap(out soDu)) return;

            var kq = ViTienNV.Them(txtTenVi.Text, cboLoaiVi.SelectedValue.ToString(), soDu, "", TrangThaiDangChon());
            if (!kq.ThanhCong)
            {
                MessageBox.Show(kq.ThongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(kq.ThongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDataGridView();
            ResetValues();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_maViDangChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn ví cần sửa trên danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal soDuBanDau;
            if (!KiemTraNhap(out soDuBanDau)) return;
            decimal soDuHienTai;
            if (!DocSoDuHienTai(out soDuHienTai)) return;

            // Ô nào được sửa sau cùng thì ô đó là "gốc", ô còn lại đã tự tính theo
            bool doiHienTai = _oVuaSua == 2;

            int maVi = _maViDangChon;
            string loaiVi = cboLoaiVi.SelectedValue.ToString();

            // Sửa số dư hiện tại => nghiệp vụ tự tính lại số dư ban đầu cho đúng
            KetQuaThaoTac kq = doiHienTai
                ? ViTienNV.SuaTheoSoDuHienTai(maVi, txtTenVi.Text, loaiVi, soDuHienTai, _ghiChuDangChon, TrangThaiDangChon())
                : ViTienNV.Sua(maVi, txtTenVi.Text, loaiVi, soDuBanDau, _ghiChuDangChon, TrangThaiDangChon());

            if (!kq.ThanhCong)
            {
                MessageBox.Show(kq.ThongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(kq.ThongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDataGridView();
            ChonLaiDong(maVi);
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            ResetValues();
        }

        // Ngừng sử dụng / sử dụng lại ví đang chọn
        private void btnNgungSuDung_Click(object sender, EventArgs e)
        {
            if (_maViDangChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn ví cần đổi trạng thái.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DoiTrangThai(!_trangThaiDangChon);
        }

        private void DoiTrangThai(bool trangThaiMoi)
        {
            if (_dangDoDuLieu || _maViDangChon <= 0) return;
            if (trangThaiMoi == _trangThaiDangChon) return;

            int maVi = _maViDangChon;
            var kq = ViTienNV.DatTrangThai(maVi, trangThaiMoi);
            if (!kq.ThanhCong)
            {
                MessageBox.Show(kq.ThongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _dangDoDuLieu = true;
                cboTrangThai.SelectedValue = _trangThaiDangChon;   // trả ô chọn về trạng thái đang lưu
                _dangDoDuLieu = false;
                return;
            }

            MessageBox.Show(kq.ThongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDataGridView();
            ChonLaiDong(maVi);
        }

        // ==========================================
        // KIỂM TRA / NHẬP LIỆU
        // ==========================================
        private bool KiemTraNhap(out decimal soDuBanDau)
        {
            soDuBanDau = 0;
            if (string.IsNullOrWhiteSpace(txtTenVi.Text))
            {
                MessageBox.Show("Bạn phải nhập tên ví.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenVi.Focus();
                return false;
            }
            if (cboLoaiVi.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn loại ví.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiVi.Focus();
                return false;
            }
            string s = txtSoDuBanDau.Text.Trim();
            if (s.Length > 0 && !decimal.TryParse(s, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out soDuBanDau))
            {
                MessageBox.Show("Số dư ban đầu không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDuBanDau.Focus();
                return false;
            }
            return true;
        }

        // Đọc ô số dư hiện tại (cho phép số âm); ô trống được hiểu là 0
        private bool DocSoDuHienTai(out decimal giaTri)
        {
            giaTri = 0;
            string s = txtSoDuHienTai.Text.Trim();
            if (s.Length == 0) return true;
            if (!decimal.TryParse(s, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out giaTri))
            {
                MessageBox.Show("Số dư hiện tại không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDuHienTai.Focus();
                return false;
            }
            return true;
        }

        // Dùng chung cho Số dư ban đầu và Số dư hiện tại: chữ số và dấu trừ ở đầu
        private void txtSoDuBanDau_KeyPress(object sender, KeyPressEventArgs e)
        {
            var o = (TextBox)sender;
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;

            bool dauTru = e.KeyChar == '-' && o.SelectionStart == 0 && !o.Text.StartsWith("-");
            if (!dauTru) e.Handled = true;
        }
    }
}
