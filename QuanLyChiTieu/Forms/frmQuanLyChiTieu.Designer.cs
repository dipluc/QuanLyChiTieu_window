namespace QuanLyChiTieu.Forms
{
    partial class frmQuanLyChiTieu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // === Menu Strip ===
            this.mnuChinh = new MenuStrip();
            this.mnuHeThong = new ToolStripMenuItem();
            this.mnuDanhMuc = new ToolStripMenuItem();
            this.mnuNghiepVu = new ToolStripMenuItem();
            this.mnuBaoCao = new ToolStripMenuItem();
            this.mnuQuanTri = new ToolStripMenuItem();
            this.mnuTroGiup = new ToolStripMenuItem();

            // === Toolbar Panel ===
            this.pnlToolbar = new Panel();
            this.btnThuNhap = new Button();
            this.btnChiTieu = new Button();
            this.btnNganSach = new Button();
            this.btnBaoCao = new Button();
            this.btnTimKiem = new Button();
            this.dtpThang = new DateTimePicker();
            this.btnLamMoi = new Button();

            // === Warning Panel ===
            this.pnlCanhBao = new Panel();
            this.lblCanhBao = new Label();
            this.lblKyRieng0125104 = new Label();

            // === Left Panel ===
            this.pnlNhapChiTieu = new Panel();
            this.lblThongTinKhoanChi = new Label();
            this.lblNgay = new Label();
            this.dtpNgay = new DateTimePicker();
            this.lblLoaiChi = new Label();
            this.cboLoaiChi = new ComboBox();
            this.lblViChi = new Label();
            this.cboViChi = new ComboBox();
            this.lblViChi2 = new Label();
            this.lblSoTien = new Label();
            this.txtSoTien = new TextBox();
            this.lblGhiChu = new Label();
            this.txtGhiChu = new TextBox();
            this.btnThem = new Button();
            this.btnSua = new Button();
            this.btnXoa = new Button();
            this.btnMoi = new Button();
            this.lblChonMotDongDeSuaHoac = new Label();

            // === Right Panel ===
            this.pnlBoLoc = new Panel();
            this.lblTuNgay = new Label();
            this.dtpTuNgay = new DateTimePicker();
            this.lblDenNgay = new Label();
            this.dtpDenNgay = new DateTimePicker();
            this.lblLocLoaiChi = new Label();
            this.cboLocLoaiChi = new ComboBox();
            this.btnLoc = new Button();
            this.btnXuatExcel = new Button();

            this.dgvChiTieu = new DataGridView();
            this.lblSoGiaoDich = new Label();

            this.pnlTongChi = new Panel();
            this.lblTongChiTrongKyLoc = new Label();
            this.lblTongChi = new Label();
            this.lblKyLoc0110202625 = new Label();

            // === Status Strip ===
            this.stsTrangThai = new StatusStrip();
            this.tssNguoiDung = new ToolStripStatusLabel();
            this.tssThoiGian = new ToolStripStatusLabel();

            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTieu)).BeginInit();
            this.SuspendLayout();

            // =============================================
            // mnuChinh
            // =============================================
            this.mnuChinh.BackColor = Color.White;
            this.mnuChinh.Font = new Font("Segoe UI", 9.5F);
            this.mnuChinh.Items.AddRange(new ToolStripItem[] {
                this.mnuHeThong, this.mnuDanhMuc, this.mnuNghiepVu,
                this.mnuBaoCao, this.mnuQuanTri, this.mnuTroGiup });
            this.mnuChinh.Location = new Point(0, 0);
            this.mnuChinh.Size = new Size(1050, 28);

            this.mnuHeThong.Text = "Hệ thống";
            this.mnuDanhMuc.Text = "Danh mục";
            this.mnuNghiepVu.Text = "Nghiệp vụ";
            this.mnuBaoCao.Text = "Báo cáo";
            this.mnuQuanTri.Text = "Quản trị";
            this.mnuTroGiup.Text = "Trợ giúp";

            // =============================================
            // pnlToolbar
            // =============================================
            this.pnlToolbar.BackColor = Color.FromArgb(245, 245, 245);
            this.pnlToolbar.BorderStyle = BorderStyle.FixedSingle;
            this.pnlToolbar.Location = new Point(0, 28);
            this.pnlToolbar.Size = new Size(1050, 48);
            this.pnlToolbar.Controls.AddRange(new Control[] {
                this.btnThuNhap, this.btnChiTieu, this.btnNganSach,
                this.btnBaoCao, this.btnTimKiem, this.dtpThang, this.btnLamMoi });

            // btnThuNhap
            this.btnThuNhap.FlatStyle = FlatStyle.Flat;
            this.btnThuNhap.FlatAppearance.BorderSize = 1;
            this.btnThuNhap.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            this.btnThuNhap.BackColor = Color.White;
            this.btnThuNhap.ForeColor = Color.FromArgb(51, 51, 51);
            this.btnThuNhap.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnThuNhap.Text = "+ Thu nhập";
            this.btnThuNhap.Location = new Point(12, 8);
            this.btnThuNhap.Size = new Size(105, 32);
            this.btnThuNhap.Cursor = Cursors.Hand;

            // btnChiTieu - ACTIVE
            this.btnChiTieu.FlatStyle = FlatStyle.Flat;
            this.btnChiTieu.FlatAppearance.BorderSize = 0;
            this.btnChiTieu.BackColor = Color.FromArgb(21, 101, 192);
            this.btnChiTieu.ForeColor = Color.White;
            this.btnChiTieu.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnChiTieu.Text = "— Chi tiêu";
            this.btnChiTieu.Location = new Point(123, 8);
            this.btnChiTieu.Size = new Size(105, 32);
            this.btnChiTieu.Cursor = Cursors.Hand;

            // btnNganSach
            this.btnNganSach.FlatStyle = FlatStyle.Flat;
            this.btnNganSach.FlatAppearance.BorderSize = 1;
            this.btnNganSach.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            this.btnNganSach.BackColor = Color.White;
            this.btnNganSach.ForeColor = Color.FromArgb(51, 51, 51);
            this.btnNganSach.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnNganSach.Text = "Ngân sách";
            this.btnNganSach.Location = new Point(234, 8);
            this.btnNganSach.Size = new Size(105, 32);
            this.btnNganSach.Cursor = Cursors.Hand;

            // btnBaoCao
            this.btnBaoCao.FlatStyle = FlatStyle.Flat;
            this.btnBaoCao.FlatAppearance.BorderSize = 1;
            this.btnBaoCao.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            this.btnBaoCao.BackColor = Color.White;
            this.btnBaoCao.ForeColor = Color.FromArgb(51, 51, 51);
            this.btnBaoCao.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnBaoCao.Text = "Báo cáo";
            this.btnBaoCao.Location = new Point(345, 8);
            this.btnBaoCao.Size = new Size(105, 32);
            this.btnBaoCao.Cursor = Cursors.Hand;

            // btnTimKiem
            this.btnTimKiem.FlatStyle = FlatStyle.Flat;
            this.btnTimKiem.FlatAppearance.BorderSize = 1;
            this.btnTimKiem.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            this.btnTimKiem.BackColor = Color.White;
            this.btnTimKiem.ForeColor = Color.FromArgb(51, 51, 51);
            this.btnTimKiem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Location = new Point(456, 8);
            this.btnTimKiem.Size = new Size(105, 32);
            this.btnTimKiem.Cursor = Cursors.Hand;

            // dtpThang
            this.dtpThang.Format = DateTimePickerFormat.Custom;
            this.dtpThang.CustomFormat = "MM/yyyy";
            this.dtpThang.ShowUpDown = true;
            this.dtpThang.Font = new Font("Segoe UI", 9.5F);
            this.dtpThang.Location = new Point(800, 12);
            this.dtpThang.Size = new Size(120, 27);

            // btnLamMoi
            this.btnLamMoi.FlatStyle = FlatStyle.Flat;
            this.btnLamMoi.FlatAppearance.BorderSize = 1;
            this.btnLamMoi.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            this.btnLamMoi.BackColor = Color.White;
            this.btnLamMoi.ForeColor = Color.FromArgb(51, 51, 51);
            this.btnLamMoi.Font = new Font("Segoe UI", 9F);
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Location = new Point(930, 8);
            this.btnLamMoi.Size = new Size(90, 32);
            this.btnLamMoi.Cursor = Cursors.Hand;

            // =============================================
            // pnlCanhBao
            // =============================================
            this.pnlCanhBao.BackColor = Color.FromArgb(255, 248, 225);
            this.pnlCanhBao.BorderStyle = BorderStyle.FixedSingle;
            this.pnlCanhBao.Location = new Point(0, 76);
            this.pnlCanhBao.Size = new Size(1050, 58);
            this.pnlCanhBao.Visible = false;
            this.pnlCanhBao.Controls.AddRange(new Control[] { this.lblCanhBao, this.lblKyRieng0125104 });

            this.lblCanhBao.AutoSize = true;
            this.lblCanhBao.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblCanhBao.ForeColor = Color.FromArgb(230, 126, 34);
            this.lblCanhBao.Location = new Point(14, 6);
            this.lblCanhBao.Text = "⚠ Loại chi Ăn uống đã đạt 85% hạn mức";

            this.lblKyRieng0125104.AutoSize = true;
            this.lblKyRieng0125104.Font = new Font("Segoe UI", 8.5F);
            this.lblKyRieng0125104.ForeColor = Color.FromArgb(120, 80, 0);
            this.lblKyRieng0125104.Location = new Point(14, 30);
            this.lblKyRieng0125104.Text = "Kỳ riêng 01-25/10: 4.080.000 / 4.800.000 đ. Tháng 10: 4.200.000 / 5.000.000 đ (84%).";

            // =============================================
            // pnlNhapChiTieu (Left Panel)
            // =============================================
            this.pnlNhapChiTieu.BackColor = Color.White;
            this.pnlNhapChiTieu.BorderStyle = BorderStyle.FixedSingle;
            this.pnlNhapChiTieu.Location = new Point(8, 82);
            this.pnlNhapChiTieu.Size = new Size(320, 475);
            this.pnlNhapChiTieu.Controls.AddRange(new Control[] {
                this.lblThongTinKhoanChi,
                this.lblNgay, this.dtpNgay,
                this.lblLoaiChi, this.cboLoaiChi,
                this.lblViChi, this.cboViChi,
                this.lblViChi2,
                this.lblSoTien, this.txtSoTien,
                this.lblGhiChu, this.txtGhiChu,
                this.btnThem, this.btnSua, this.btnXoa, this.btnMoi,
                this.lblChonMotDongDeSuaHoac });

            // lblThongTinKhoanChi
            this.lblThongTinKhoanChi.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblThongTinKhoanChi.ForeColor = Color.FromArgb(21, 101, 192);
            this.lblThongTinKhoanChi.Location = new Point(12, 10);
            this.lblThongTinKhoanChi.Size = new Size(290, 25);
            this.lblThongTinKhoanChi.Text = "Thông tin khoản chi";

            // lblNgay + dtpNgay
            this.lblNgay.AutoSize = true;
            this.lblNgay.Font = new Font("Segoe UI", 9.5F);
            this.lblNgay.ForeColor = Color.FromArgb(51, 51, 51);
            this.lblNgay.Location = new Point(12, 48);
            this.lblNgay.Text = "Ngày chi";

            this.dtpNgay.Font = new Font("Segoe UI", 9.5F);
            this.dtpNgay.Format = DateTimePickerFormat.Short;
            this.dtpNgay.Location = new Point(12, 70);
            this.dtpNgay.Size = new Size(290, 27);

            // lblLoaiChi + cboLoaiChi
            this.lblLoaiChi.AutoSize = true;
            this.lblLoaiChi.Font = new Font("Segoe UI", 9.5F);
            this.lblLoaiChi.ForeColor = Color.FromArgb(51, 51, 51);
            this.lblLoaiChi.Location = new Point(12, 106);
            this.lblLoaiChi.Text = "Loại chi";

            this.cboLoaiChi.Font = new Font("Segoe UI", 9.5F);
            this.cboLoaiChi.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboLoaiChi.Location = new Point(12, 128);
            this.cboLoaiChi.Size = new Size(290, 27);

            // lblViChi + cboViChi
            this.lblViChi.AutoSize = true;
            this.lblViChi.Font = new Font("Segoe UI", 9.5F);
            this.lblViChi.ForeColor = Color.FromArgb(51, 51, 51);
            this.lblViChi.Location = new Point(12, 164);
            this.lblViChi.Text = "Ví chi";

            this.cboViChi.Font = new Font("Segoe UI", 9.5F);
            this.cboViChi.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboViChi.Location = new Point(12, 186);
            this.cboViChi.Size = new Size(290, 27);

            // lblViChi2
            this.lblViChi2.AutoSize = true;
            this.lblViChi2.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            this.lblViChi2.ForeColor = Color.FromArgb(130, 130, 130);
            this.lblViChi2.Location = new Point(12, 218);
            this.lblViChi2.Text = "Số dư khả dụng của ví đang chọn";

            // lblSoTien + txtSoTien
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Font = new Font("Segoe UI", 9.5F);
            this.lblSoTien.ForeColor = Color.FromArgb(51, 51, 51);
            this.lblSoTien.Location = new Point(12, 244);
            this.lblSoTien.Text = "Số tiền (đ)";

            this.txtSoTien.Font = new Font("Segoe UI", 10F);
            this.txtSoTien.TextAlign = HorizontalAlignment.Right;
            this.txtSoTien.Location = new Point(12, 266);
            this.txtSoTien.Size = new Size(290, 29);

            // lblGhiChu + txtGhiChu
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new Font("Segoe UI", 9.5F);
            this.lblGhiChu.ForeColor = Color.FromArgb(51, 51, 51);
            this.lblGhiChu.Location = new Point(12, 304);
            this.lblGhiChu.Text = "Ghi chú";

            this.txtGhiChu.Font = new Font("Segoe UI", 9.5F);
            this.txtGhiChu.Location = new Point(12, 326);
            this.txtGhiChu.Size = new Size(290, 27);

            // Buttons row
            this.btnThem.FlatStyle = FlatStyle.Flat;
            this.btnThem.FlatAppearance.BorderSize = 0;
            this.btnThem.BackColor = Color.FromArgb(21, 101, 192);
            this.btnThem.ForeColor = Color.White;
            this.btnThem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.btnThem.Text = "+ Thêm";
            this.btnThem.Location = new Point(12, 370);
            this.btnThem.Size = new Size(88, 34);
            this.btnThem.Cursor = Cursors.Hand;

            this.btnSua.FlatStyle = FlatStyle.Flat;
            this.btnSua.FlatAppearance.BorderSize = 1;
            this.btnSua.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            this.btnSua.BackColor = Color.White;
            this.btnSua.ForeColor = Color.FromArgb(51, 51, 51);
            this.btnSua.Font = new Font("Segoe UI", 9.5F);
            this.btnSua.Text = "Sửa";
            this.btnSua.Location = new Point(106, 370);
            this.btnSua.Size = new Size(65, 34);
            this.btnSua.Cursor = Cursors.Hand;
            this.btnSua.Enabled = false;

            this.btnXoa.FlatStyle = FlatStyle.Flat;
            this.btnXoa.FlatAppearance.BorderSize = 1;
            this.btnXoa.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            this.btnXoa.BackColor = Color.White;
            this.btnXoa.ForeColor = Color.FromArgb(51, 51, 51);
            this.btnXoa.Font = new Font("Segoe UI", 9.5F);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Location = new Point(177, 370);
            this.btnXoa.Size = new Size(60, 34);
            this.btnXoa.Cursor = Cursors.Hand;
            this.btnXoa.Enabled = false;

            this.btnMoi.FlatStyle = FlatStyle.Flat;
            this.btnMoi.FlatAppearance.BorderSize = 1;
            this.btnMoi.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            this.btnMoi.BackColor = Color.White;
            this.btnMoi.ForeColor = Color.FromArgb(51, 51, 51);
            this.btnMoi.Font = new Font("Segoe UI", 9F);
            this.btnMoi.Text = "Mới";
            this.btnMoi.Location = new Point(243, 370);
            this.btnMoi.Size = new Size(59, 34);
            this.btnMoi.Cursor = Cursors.Hand;

            // lblChonMotDongDeSuaHoac
            this.lblChonMotDongDeSuaHoac.AutoSize = true;
            this.lblChonMotDongDeSuaHoac.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            this.lblChonMotDongDeSuaHoac.ForeColor = Color.FromArgb(150, 150, 150);
            this.lblChonMotDongDeSuaHoac.Location = new Point(12, 415);
            this.lblChonMotDongDeSuaHoac.Text = "Chọn một dòng để sửa hoặc xóa khoản chi.";

            // =============================================
            // Right side - pnlBoLoc (Filter Panel)
            // =============================================
            this.pnlBoLoc.BackColor = Color.FromArgb(250, 250, 250);
            this.pnlBoLoc.BorderStyle = BorderStyle.FixedSingle;
            this.pnlBoLoc.Location = new Point(338, 82);
            this.pnlBoLoc.Size = new Size(700, 48);
            this.pnlBoLoc.Controls.AddRange(new Control[] {
                this.lblTuNgay, this.dtpTuNgay,
                this.lblDenNgay, this.dtpDenNgay,
                this.lblLocLoaiChi, this.cboLocLoaiChi,
                this.btnLoc, this.btnXuatExcel });

            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new Font("Segoe UI", 9F);
            this.lblTuNgay.ForeColor = Color.FromArgb(51, 51, 51);
            this.lblTuNgay.Location = new Point(8, 14);
            this.lblTuNgay.Text = "Từ ngày";

            this.dtpTuNgay.Font = new Font("Segoe UI", 9F);
            this.dtpTuNgay.Format = DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new Point(62, 10);
            this.dtpTuNgay.Size = new Size(110, 27);

            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new Font("Segoe UI", 9F);
            this.lblDenNgay.ForeColor = Color.FromArgb(51, 51, 51);
            this.lblDenNgay.Location = new Point(178, 14);
            this.lblDenNgay.Text = "Đến ngày";

            this.dtpDenNgay.Font = new Font("Segoe UI", 9F);
            this.dtpDenNgay.Format = DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new Point(244, 10);
            this.dtpDenNgay.Size = new Size(110, 27);

            this.lblLocLoaiChi.AutoSize = true;
            this.lblLocLoaiChi.Font = new Font("Segoe UI", 9F);
            this.lblLocLoaiChi.ForeColor = Color.FromArgb(51, 51, 51);
            this.lblLocLoaiChi.Location = new Point(362, 14);
            this.lblLocLoaiChi.Text = "Loại chi";

            this.cboLocLoaiChi.Font = new Font("Segoe UI", 9F);
            this.cboLocLoaiChi.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboLocLoaiChi.Location = new Point(414, 10);
            this.cboLocLoaiChi.Size = new Size(120, 27);

            this.btnLoc.FlatStyle = FlatStyle.Flat;
            this.btnLoc.FlatAppearance.BorderSize = 0;
            this.btnLoc.BackColor = Color.FromArgb(21, 101, 192);
            this.btnLoc.ForeColor = Color.White;
            this.btnLoc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnLoc.Text = "Lọc";
            this.btnLoc.Location = new Point(545, 8);
            this.btnLoc.Size = new Size(60, 30);
            this.btnLoc.Cursor = Cursors.Hand;

            this.btnXuatExcel.FlatStyle = FlatStyle.Flat;
            this.btnXuatExcel.FlatAppearance.BorderSize = 1;
            this.btnXuatExcel.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            this.btnXuatExcel.BackColor = Color.White;
            this.btnXuatExcel.ForeColor = Color.FromArgb(51, 51, 51);
            this.btnXuatExcel.Font = new Font("Segoe UI", 9F);
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.Location = new Point(612, 8);
            this.btnXuatExcel.Size = new Size(80, 30);
            this.btnXuatExcel.Cursor = Cursors.Hand;

            // =============================================
            // dgvChiTieu
            // =============================================
            this.dgvChiTieu.Location = new Point(338, 134);
            this.dgvChiTieu.Size = new Size(700, 330);
            this.dgvChiTieu.BackgroundColor = Color.White;
            this.dgvChiTieu.BorderStyle = BorderStyle.FixedSingle;
            this.dgvChiTieu.AllowUserToAddRows = false;
            this.dgvChiTieu.AllowUserToDeleteRows = false;
            this.dgvChiTieu.ReadOnly = true;
            this.dgvChiTieu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTieu.MultiSelect = false;
            this.dgvChiTieu.RowHeadersVisible = false;
            this.dgvChiTieu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTieu.Font = new Font("Segoe UI", 9.5F);
            this.dgvChiTieu.DefaultCellStyle.SelectionBackColor = Color.FromArgb(227, 242, 253);
            this.dgvChiTieu.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.dgvChiTieu.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(21, 101, 192);
            this.dgvChiTieu.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvChiTieu.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.dgvChiTieu.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvChiTieu.EnableHeadersVisualStyles = false;
            this.dgvChiTieu.ColumnHeadersHeight = 36;
            this.dgvChiTieu.RowTemplate.Height = 32;
            this.dgvChiTieu.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            this.dgvChiTieu.GridColor = Color.FromArgb(224, 224, 224);
            this.dgvChiTieu.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // lblSoGiaoDich
            this.lblSoGiaoDich.AutoSize = true;
            this.lblSoGiaoDich.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            this.lblSoGiaoDich.ForeColor = Color.FromArgb(100, 100, 100);
            this.lblSoGiaoDich.Location = new Point(338, 468);
            this.lblSoGiaoDich.Text = "0 giao dịch";

            // =============================================
            // pnlTongChi
            // =============================================
            this.pnlTongChi.BackColor = Color.FromArgb(255, 245, 245);
            this.pnlTongChi.BorderStyle = BorderStyle.FixedSingle;
            this.pnlTongChi.Location = new Point(338, 490);
            this.pnlTongChi.Size = new Size(700, 67);
            this.pnlTongChi.Controls.AddRange(new Control[] {
                this.lblTongChiTrongKyLoc, this.lblTongChi, this.lblKyLoc0110202625 });

            this.lblTongChiTrongKyLoc.AutoSize = true;
            this.lblTongChiTrongKyLoc.Font = new Font("Segoe UI", 9.5F);
            this.lblTongChiTrongKyLoc.ForeColor = Color.FromArgb(80, 80, 80);
            this.lblTongChiTrongKyLoc.Location = new Point(12, 8);
            this.lblTongChiTrongKyLoc.Text = "Tổng chi trong kỳ lọc";

            this.lblTongChi.AutoSize = true;
            this.lblTongChi.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTongChi.ForeColor = Color.FromArgb(211, 47, 47);
            this.lblTongChi.Location = new Point(460, 4);
            this.lblTongChi.Text = "0 đ";
            this.lblTongChi.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            this.lblKyLoc0110202625.AutoSize = true;
            this.lblKyLoc0110202625.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            this.lblKyLoc0110202625.ForeColor = Color.FromArgb(130, 130, 130);
            this.lblKyLoc0110202625.Location = new Point(12, 40);
            this.lblKyLoc0110202625.Text = "";

            // =============================================
            // stsTrangThai
            // =============================================
            this.stsTrangThai.BackColor = Color.FromArgb(245, 245, 245);
            this.stsTrangThai.Font = new Font("Segoe UI", 9F);
            this.stsTrangThai.Items.AddRange(new ToolStripItem[] { this.tssNguoiDung, this.tssThoiGian });
            this.tssNguoiDung.Text = "Người dùng: ---";
            this.tssThoiGian.Spring = true;
            this.tssThoiGian.TextAlign = ContentAlignment.MiddleRight;
            this.tssThoiGian.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            // =============================================
            // frmQuanLyChiTieu
            // =============================================
            this.AutoScaleDimensions = new SizeF(7F, 17F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(240, 242, 245);
            this.ClientSize = new Size(1050, 620);
            this.Controls.Add(this.pnlCanhBao);
            this.Controls.Add(this.pnlNhapChiTieu);
            this.Controls.Add(this.pnlBoLoc);
            this.Controls.Add(this.dgvChiTieu);
            this.Controls.Add(this.lblSoGiaoDich);
            this.Controls.Add(this.pnlTongChi);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.mnuChinh);
            this.Controls.Add(this.stsTrangThai);
            this.Font = new Font("Segoe UI", 9.5F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MainMenuStrip = this.mnuChinh;
            this.Name = "frmQuanLyChiTieu";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Chi Tiêu — Quản lý chi tiêu";

            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Menu
        private MenuStrip mnuChinh;
        private ToolStripMenuItem mnuHeThong;
        private ToolStripMenuItem mnuDanhMuc;
        private ToolStripMenuItem mnuNghiepVu;
        private ToolStripMenuItem mnuBaoCao;
        private ToolStripMenuItem mnuQuanTri;
        private ToolStripMenuItem mnuTroGiup;

        // Toolbar
        private Panel pnlToolbar;
        private Button btnThuNhap;
        private Button btnChiTieu;
        private Button btnNganSach;
        private Button btnBaoCao;
        private Button btnTimKiem;
        private DateTimePicker dtpThang;
        private Button btnLamMoi;

        // Warning panel
        private Panel pnlCanhBao;
        private Label lblCanhBao;
        private Label lblKyRieng0125104;

        // Left panel - input
        private Panel pnlNhapChiTieu;
        private Label lblThongTinKhoanChi;
        private Label lblNgay;
        private DateTimePicker dtpNgay;
        private Label lblLoaiChi;
        private ComboBox cboLoaiChi;
        private Label lblViChi;
        private ComboBox cboViChi;
        private Label lblViChi2;
        private Label lblSoTien;
        private TextBox txtSoTien;
        private Label lblGhiChu;
        private TextBox txtGhiChu;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnMoi;
        private Label lblChonMotDongDeSuaHoac;

        // Right panel - filter
        private Panel pnlBoLoc;
        private Label lblTuNgay;
        private DateTimePicker dtpTuNgay;
        private Label lblDenNgay;
        private DateTimePicker dtpDenNgay;
        private Label lblLocLoaiChi;
        private ComboBox cboLocLoaiChi;
        private Button btnLoc;
        private Button btnXuatExcel;

        // DataGridView
        private DataGridView dgvChiTieu;
        private Label lblSoGiaoDich;

        // Bottom summary
        private Panel pnlTongChi;
        private Label lblTongChiTrongKyLoc;
        private Label lblTongChi;
        private Label lblKyLoc0110202625;

        // Status
        private StatusStrip stsTrangThai;
        private ToolStripStatusLabel tssNguoiDung;
        private ToolStripStatusLabel tssThoiGian;
    }
}
