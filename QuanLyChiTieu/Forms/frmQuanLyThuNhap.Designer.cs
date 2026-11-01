namespace QuanLyChiTieu.Forms
{
    partial class frmQuanLyThuNhap
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
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvAltRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            
            this.mnuChinh = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCauHinh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNghiepVu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNVThuNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNVChiTieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNVNganSach = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNVChuyenTien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNVTimKiem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanTri = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTroGiup = new System.Windows.Forms.ToolStripMenuItem();

            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnThuNhap = new System.Windows.Forms.Button();
            this.btnChiTieu = new System.Windows.Forms.Button();
            this.btnNganSach = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.lblThang = new System.Windows.Forms.Label();
            this.dtpThang = new System.Windows.Forms.DateTimePicker();
            this.btnLamMoi = new System.Windows.Forms.Button();

            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblQuanLyThuNhap = new System.Windows.Forms.Label();
            this.lblThang102026DuLieuDen = new System.Windows.Forms.Label();

            this.pnlNoiDung = new System.Windows.Forms.Panel();
            this.pnlQuanLyGiaoDich = new System.Windows.Forms.Panel();
            this.lblThongTinKhoanThu = new System.Windows.Forms.Label();
            this.lblNgay = new System.Windows.Forms.Label();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.lblLoaiThu = new System.Windows.Forms.Label();
            this.cboLoaiThu = new System.Windows.Forms.ComboBox();
            this.lblLoaiThu2 = new System.Windows.Forms.Label();
            this.lblViThu = new System.Windows.Forms.Label();
            this.cboViThu = new System.Windows.Forms.ComboBox();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnMoi = new System.Windows.Forms.Button();
            this.lblChonMotDongDeSuaHoac = new System.Windows.Forms.Label();

            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlBoLoc = new System.Windows.Forms.Panel();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblLocLoaiThu = new System.Windows.Forms.Label();
            this.cboLocLoaiThu = new System.Windows.Forms.ComboBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();

            this.dgvThuNhap = new System.Windows.Forms.DataGridView();
            this.colNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.lblSoGiaoDich = new System.Windows.Forms.Label();

            this.pnlTongThu = new System.Windows.Forms.Panel();
            this.lblTongThuTrongKyLoc = new System.Windows.Forms.Label();
            this.lblTongThu = new System.Windows.Forms.Label();

            this.pnlCoCauThuNhap = new System.Windows.Forms.Panel();
            this.lblCoCauThuNhapThang10 = new System.Windows.Forms.Label();
            this.lblLuong = new System.Windows.Forms.Label();
            this.lblLuong2 = new System.Windows.Forms.Label();
            this.lblLuong3 = new System.Windows.Forms.Label();
            this.lblThuong = new System.Windows.Forms.Label();
            this.lblThuong2 = new System.Windows.Forms.Label();
            this.lblThuong3 = new System.Windows.Forms.Label();
            this.lblThuNhapKhac = new System.Windows.Forms.Label();
            this.lblThuNhapKhac2 = new System.Windows.Forms.Label();
            this.lblThuNhapKhac3 = new System.Windows.Forms.Label();

            this.stsTrangThai = new System.Windows.Forms.StatusStrip();
            this.tsslTrangThai = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslViDangChon = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslHomNay = new System.Windows.Forms.ToolStripStatusLabel();

            this.mnuChinh.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlNoiDung.SuspendLayout();
            this.pnlQuanLyGiaoDich.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlBoLoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuNhap)).BeginInit();
            this.pnlTongThu.SuspendLayout();
            this.pnlCoCauThuNhap.SuspendLayout();
            this.stsTrangThai.SuspendLayout();
            this.SuspendLayout();

            // ===== mnuChinh =====
            this.mnuChinh.BackColor = System.Drawing.Color.White;
            this.mnuChinh.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.mnuChinh.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuHeThong, this.mnuDanhMuc, this.mnuNghiepVu,
                this.mnuBaoCao, this.mnuQuanTri, this.mnuTroGiup
            });
            this.mnuChinh.Location = new System.Drawing.Point(0, 0);
            this.mnuChinh.Name = "mnuChinh";
            this.mnuChinh.Size = new System.Drawing.Size(1060, 25);
            this.mnuChinh.TabIndex = 0;

            this.mnuHeThong.Text = "Hệ thống";
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuCauHinh, this.mnuThoat });
            this.mnuCauHinh.Text = "Cấu hình";
            this.mnuCauHinh.Click += (s, e) => NavigateTo<frmCauHinh>();
            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += (s, e) => Application.Exit();

            this.mnuDanhMuc.Text = "Danh mục";
            this.mnuNghiepVu.Text = "Nghiệp vụ";
            this.mnuNghiepVu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuNVThuNhap, this.mnuNVChiTieu, this.mnuNVNganSach, this.mnuNVChuyenTien, this.mnuNVTimKiem
            });
            this.mnuNVThuNhap.Text = "Quản lý thu nhập";
            this.mnuNVChiTieu.Text = "Quản lý chi tiêu";
            this.mnuNVChiTieu.Click += (s, e) => NavigateTo<frmQuanLyChiTieu>();
            this.mnuNVNganSach.Text = "Ngân sách";
            this.mnuNVNganSach.Click += (s, e) => NavigateTo<frmNganSach>();
            this.mnuNVChuyenTien.Text = "Chuyển tiền giữa các ví";
            this.mnuNVChuyenTien.Click += (s, e) => NavigateTo<frmChuyenTien>();
            this.mnuNVTimKiem.Text = "Tìm kiếm giao dịch";
            this.mnuNVTimKiem.Click += (s, e) => NavigateTo<frmTimKiem>();

            this.mnuBaoCao.Text = "Báo cáo";
            this.mnuQuanTri.Text = "Quản trị";
            this.mnuTroGiup.Text = "Trợ giúp";

            // ===== pnlToolbar =====
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlToolbar.Controls.Add(this.btnThuNhap);
            this.pnlToolbar.Controls.Add(this.btnChiTieu);
            this.pnlToolbar.Controls.Add(this.btnNganSach);
            this.pnlToolbar.Controls.Add(this.btnBaoCao);
            this.pnlToolbar.Controls.Add(this.btnTimKiem);
            this.pnlToolbar.Controls.Add(this.lblThang);
            this.pnlToolbar.Controls.Add(this.dtpThang);
            this.pnlToolbar.Controls.Add(this.btnLamMoi);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 25);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1060, 42);
            this.pnlToolbar.TabIndex = 1;

            this.btnThuNhap.BackColor = System.Drawing.Color.FromArgb(21, 101, 192);
            this.btnThuNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThuNhap.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThuNhap.ForeColor = System.Drawing.Color.White;
            this.btnThuNhap.Location = new System.Drawing.Point(12, 6);
            this.btnThuNhap.Name = "btnThuNhap";
            this.btnThuNhap.Size = new System.Drawing.Size(95, 29);
            this.btnThuNhap.TabIndex = 0;
            this.btnThuNhap.Text = "+ Thu nhập";
            this.btnThuNhap.UseVisualStyleBackColor = false;

            this.btnChiTieu.BackColor = System.Drawing.Color.White;
            this.btnChiTieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChiTieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnChiTieu.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.btnChiTieu.Location = new System.Drawing.Point(113, 6);
            this.btnChiTieu.Name = "btnChiTieu";
            this.btnChiTieu.Size = new System.Drawing.Size(90, 29);
            this.btnChiTieu.TabIndex = 1;
            this.btnChiTieu.Text = "— Chi tiêu";
            this.btnChiTieu.UseVisualStyleBackColor = true;
            this.btnChiTieu.Click += new System.EventHandler(this.btnChiTieu_Click);

            this.btnNganSach.BackColor = System.Drawing.Color.White;
            this.btnNganSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNganSach.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNganSach.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.btnNganSach.Location = new System.Drawing.Point(209, 6);
            this.btnNganSach.Name = "btnNganSach";
            this.btnNganSach.Size = new System.Drawing.Size(95, 29);
            this.btnNganSach.TabIndex = 2;
            this.btnNganSach.Text = "📊 Ngân sách";
            this.btnNganSach.UseVisualStyleBackColor = true;
            this.btnNganSach.Click += new System.EventHandler(this.btnNganSach_Click);

            this.btnBaoCao.BackColor = System.Drawing.Color.White;
            this.btnBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBaoCao.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.btnBaoCao.Location = new System.Drawing.Point(310, 6);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(85, 29);
            this.btnBaoCao.TabIndex = 3;
            this.btnBaoCao.Text = "📈 Báo cáo";
            this.btnBaoCao.UseVisualStyleBackColor = true;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);

            this.btnTimKiem.BackColor = System.Drawing.Color.White;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTimKiem.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.btnTimKiem.Location = new System.Drawing.Point(401, 6);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(90, 29);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "🔍 Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

            this.lblThang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThang.AutoSize = true;
            this.lblThang.ForeColor = System.Drawing.Color.Gray;
            this.lblThang.Location = new System.Drawing.Point(745, 12);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(43, 15);
            this.lblThang.Text = "Tháng:";

            this.dtpThang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpThang.CustomFormat = "MM/yyyy";
            this.dtpThang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThang.Location = new System.Drawing.Point(792, 9);
            this.dtpThang.Name = "dtpThang";
            this.dtpThang.Size = new System.Drawing.Size(120, 23);
            this.dtpThang.TabIndex = 5;
            this.dtpThang.ValueChanged += new System.EventHandler(this.dtpThang_ValueChanged);

            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.btnLamMoi.Location = new System.Drawing.Point(920, 6);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(85, 29);
            this.btnLamMoi.TabIndex = 6;
            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // ===== pnlHeader =====
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.pnlHeader.Controls.Add(this.lblQuanLyThuNhap);
            this.pnlHeader.Controls.Add(this.lblThang102026DuLieuDen);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 67);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1060, 40);
            this.pnlHeader.TabIndex = 2;

            this.lblQuanLyThuNhap.AutoSize = true;
            this.lblQuanLyThuNhap.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblQuanLyThuNhap.ForeColor = System.Drawing.Color.FromArgb(26, 35, 126);
            this.lblQuanLyThuNhap.Location = new System.Drawing.Point(12, 7);
            this.lblQuanLyThuNhap.Name = "lblQuanLyThuNhap";
            this.lblQuanLyThuNhap.Size = new System.Drawing.Size(164, 25);
            this.lblQuanLyThuNhap.TabIndex = 0;
            this.lblQuanLyThuNhap.Text = "Quản lý thu nhập";

            this.lblThang102026DuLieuDen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThang102026DuLieuDen.AutoSize = true;
            this.lblThang102026DuLieuDen.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblThang102026DuLieuDen.ForeColor = System.Drawing.Color.Gray;
            this.lblThang102026DuLieuDen.Location = new System.Drawing.Point(780, 14);
            this.lblThang102026DuLieuDen.Name = "lblThang102026DuLieuDen";
            this.lblThang102026DuLieuDen.Size = new System.Drawing.Size(225, 15);
            this.lblThang102026DuLieuDen.TabIndex = 1;
            this.lblThang102026DuLieuDen.Text = "Tháng 10/2026 • Dữ liệu đến 26/10/2026";

            // ===== pnlNoiDung =====
            this.pnlNoiDung.BackColor = System.Drawing.Color.FromArgb(244, 246, 248);
            this.pnlNoiDung.Controls.Add(this.pnlQuanLyGiaoDich);
            this.pnlNoiDung.Controls.Add(this.pnlRight);
            this.pnlNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoiDung.Location = new System.Drawing.Point(0, 107);
            this.pnlNoiDung.Name = "pnlNoiDung";
            this.pnlNoiDung.Padding = new System.Windows.Forms.Padding(12);
            this.pnlNoiDung.Size = new System.Drawing.Size(1060, 480);
            this.pnlNoiDung.TabIndex = 3;

            // ===== pnlQuanLyGiaoDich (Left Panel) =====
            this.pnlQuanLyGiaoDich.BackColor = System.Drawing.Color.White;
            this.pnlQuanLyGiaoDich.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQuanLyGiaoDich.Controls.Add(this.lblThongTinKhoanThu);
            this.pnlQuanLyGiaoDich.Controls.Add(this.lblNgay);
            this.pnlQuanLyGiaoDich.Controls.Add(this.dtpNgay);
            this.pnlQuanLyGiaoDich.Controls.Add(this.lblLoaiThu);
            this.pnlQuanLyGiaoDich.Controls.Add(this.cboLoaiThu);
            this.pnlQuanLyGiaoDich.Controls.Add(this.lblLoaiThu2);
            this.pnlQuanLyGiaoDich.Controls.Add(this.lblViThu);
            this.pnlQuanLyGiaoDich.Controls.Add(this.cboViThu);
            this.pnlQuanLyGiaoDich.Controls.Add(this.lblSoTien);
            this.pnlQuanLyGiaoDich.Controls.Add(this.txtSoTien);
            this.pnlQuanLyGiaoDich.Controls.Add(this.lblGhiChu);
            this.pnlQuanLyGiaoDich.Controls.Add(this.txtGhiChu);
            this.pnlQuanLyGiaoDich.Controls.Add(this.btnThem);
            this.pnlQuanLyGiaoDich.Controls.Add(this.btnSua);
            this.pnlQuanLyGiaoDich.Controls.Add(this.btnXoa);
            this.pnlQuanLyGiaoDich.Controls.Add(this.btnMoi);
            this.pnlQuanLyGiaoDich.Controls.Add(this.lblChonMotDongDeSuaHoac);
            this.pnlQuanLyGiaoDich.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlQuanLyGiaoDich.Location = new System.Drawing.Point(12, 12);
            this.pnlQuanLyGiaoDich.Name = "pnlQuanLyGiaoDich";
            this.pnlQuanLyGiaoDich.Size = new System.Drawing.Size(250, 456);
            this.pnlQuanLyGiaoDich.TabIndex = 0;

            this.lblThongTinKhoanThu.AutoSize = true;
            this.lblThongTinKhoanThu.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblThongTinKhoanThu.ForeColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.lblThongTinKhoanThu.Location = new System.Drawing.Point(12, 10);
            this.lblThongTinKhoanThu.Name = "lblThongTinKhoanThu";
            this.lblThongTinKhoanThu.Size = new System.Drawing.Size(143, 19);
            this.lblThongTinKhoanThu.TabIndex = 0;
            this.lblThongTinKhoanThu.Text = "Thông tin khoản thu";

            this.lblNgay.AutoSize = true;
            this.lblNgay.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNgay.Location = new System.Drawing.Point(12, 36);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(56, 15);
            this.lblNgay.TabIndex = 1;
            this.lblNgay.Text = "Ngày thu";

            this.dtpNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgay.Location = new System.Drawing.Point(12, 54);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(222, 23);
            this.dtpNgay.TabIndex = 2;

            this.lblLoaiThu.AutoSize = true;
            this.lblLoaiThu.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLoaiThu.Location = new System.Drawing.Point(12, 85);
            this.lblLoaiThu.Name = "lblLoaiThu";
            this.lblLoaiThu.Size = new System.Drawing.Size(52, 15);
            this.lblLoaiThu.TabIndex = 3;
            this.lblLoaiThu.Text = "Loại thu";

            this.cboLoaiThu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiThu.FormattingEnabled = true;
            this.cboLoaiThu.Location = new System.Drawing.Point(12, 103);
            this.cboLoaiThu.Name = "cboLoaiThu";
            this.cboLoaiThu.Size = new System.Drawing.Size(222, 23);
            this.cboLoaiThu.TabIndex = 4;

            this.lblLoaiThu2.AutoSize = true;
            this.lblLoaiThu2.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblLoaiThu2.ForeColor = System.Drawing.Color.Gray;
            this.lblLoaiThu2.Location = new System.Drawing.Point(12, 129);
            this.lblLoaiThu2.Name = "lblLoaiThu2";
            this.lblLoaiThu2.Size = new System.Drawing.Size(155, 12);
            this.lblLoaiThu2.TabIndex = 5;
            this.lblLoaiThu2.Text = "Lương • Thưởng • Thu nhập khác";

            this.lblViThu.AutoSize = true;
            this.lblViThu.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblViThu.Location = new System.Drawing.Point(12, 149);
            this.lblViThu.Name = "lblViThu";
            this.lblViThu.Size = new System.Drawing.Size(49, 15);
            this.lblViThu.TabIndex = 6;
            this.lblViThu.Text = "Ví nhận";

            this.cboViThu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboViThu.FormattingEnabled = true;
            this.cboViThu.Location = new System.Drawing.Point(12, 167);
            this.cboViThu.Name = "cboViThu";
            this.cboViThu.Size = new System.Drawing.Size(222, 23);
            this.cboViThu.TabIndex = 7;

            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSoTien.Location = new System.Drawing.Point(12, 198);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(65, 15);
            this.lblSoTien.TabIndex = 8;
            this.lblSoTien.Text = "Số tiền (đ)";

            this.txtSoTien.Location = new System.Drawing.Point(12, 216);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(222, 23);
            this.txtSoTien.TabIndex = 9;
            this.txtSoTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblGhiChu.Location = new System.Drawing.Point(12, 247);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(48, 15);
            this.lblGhiChu.TabIndex = 10;
            this.lblGhiChu.Text = "Ghi chú";

            this.txtGhiChu.Location = new System.Drawing.Point(12, 265);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(222, 45);
            this.txtGhiChu.TabIndex = 11;

            this.btnThem.BackColor = System.Drawing.Color.FromArgb(21, 101, 192);
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(12, 320);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(66, 28);
            this.btnThem.TabIndex = 12;
            this.btnThem.Text = "+ Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.BackColor = System.Drawing.Color.White;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnSua.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.btnSua.Location = new System.Drawing.Point(84, 320);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(45, 28);
            this.btnSua.TabIndex = 13;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.BackColor = System.Drawing.Color.White;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnXoa.ForeColor = System.Drawing.Color.FromArgb(198, 40, 40);
            this.btnXoa.Location = new System.Drawing.Point(135, 320);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(45, 28);
            this.btnXoa.TabIndex = 14;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnMoi.BackColor = System.Drawing.Color.White;
            this.btnMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoi.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnMoi.Location = new System.Drawing.Point(186, 320);
            this.btnMoi.Name = "btnMoi";
            this.btnMoi.Size = new System.Drawing.Size(48, 28);
            this.btnMoi.TabIndex = 15;
            this.btnMoi.Text = "Mới";
            this.btnMoi.UseVisualStyleBackColor = true;
            this.btnMoi.Click += new System.EventHandler(this.btnMoi_Click);

            this.lblChonMotDongDeSuaHoac.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblChonMotDongDeSuaHoac.ForeColor = System.Drawing.Color.Gray;
            this.lblChonMotDongDeSuaHoac.Location = new System.Drawing.Point(12, 356);
            this.lblChonMotDongDeSuaHoac.Name = "lblChonMotDongDeSuaHoac";
            this.lblChonMotDongDeSuaHoac.Size = new System.Drawing.Size(222, 28);
            this.lblChonMotDongDeSuaHoac.TabIndex = 16;
            this.lblChonMotDongDeSuaHoac.Text = "Chọn một dòng để sửa hoặc xóa khoản thu.";

            // ===== pnlRight =====
            this.pnlRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlRight.Controls.Add(this.pnlCoCauThuNhap);
            this.pnlRight.Controls.Add(this.pnlTongThu);
            this.pnlRight.Controls.Add(this.lblSoGiaoDich);
            this.pnlRight.Controls.Add(this.dgvThuNhap);
            this.pnlRight.Controls.Add(this.pnlBoLoc);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(262, 12);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.pnlRight.Size = new System.Drawing.Size(786, 456);
            this.pnlRight.TabIndex = 1;

            // ===== pnlBoLoc (Filter Bar) =====
            this.pnlBoLoc.BackColor = System.Drawing.Color.White;
            this.pnlBoLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBoLoc.Controls.Add(this.lblTuNgay);
            this.pnlBoLoc.Controls.Add(this.dtpTuNgay);
            this.pnlBoLoc.Controls.Add(this.lblDenNgay);
            this.pnlBoLoc.Controls.Add(this.dtpDenNgay);
            this.pnlBoLoc.Controls.Add(this.lblLocLoaiThu);
            this.pnlBoLoc.Controls.Add(this.cboLocLoaiThu);
            this.pnlBoLoc.Controls.Add(this.btnLoc);
            this.pnlBoLoc.Controls.Add(this.btnXuatExcel);
            this.pnlBoLoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBoLoc.Location = new System.Drawing.Point(12, 0);
            this.pnlBoLoc.Name = "pnlBoLoc";
            this.pnlBoLoc.Size = new System.Drawing.Size(774, 42);
            this.pnlBoLoc.TabIndex = 0;

            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTuNgay.Location = new System.Drawing.Point(8, 12);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(52, 15);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày:";

            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(62, 9);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(105, 23);
            this.dtpTuNgay.TabIndex = 1;

            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDenNgay.Location = new System.Drawing.Point(173, 12);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(60, 15);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "Đến ngày:";

            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(235, 9);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(105, 23);
            this.dtpDenNgay.TabIndex = 3;

            this.lblLocLoaiThu.AutoSize = true;
            this.lblLocLoaiThu.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLocLoaiThu.Location = new System.Drawing.Point(348, 12);
            this.lblLocLoaiThu.Name = "lblLocLoaiThu";
            this.lblLocLoaiThu.Size = new System.Drawing.Size(52, 15);
            this.lblLocLoaiThu.TabIndex = 4;
            this.lblLocLoaiThu.Text = "Loại thu:";

            this.cboLocLoaiThu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocLoaiThu.FormattingEnabled = true;
            this.cboLocLoaiThu.Location = new System.Drawing.Point(403, 9);
            this.cboLocLoaiThu.Name = "cboLocLoaiThu";
            this.cboLocLoaiThu.Size = new System.Drawing.Size(120, 23);
            this.cboLocLoaiThu.TabIndex = 5;

            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(21, 101, 192);
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(532, 7);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(65, 27);
            this.btnLoc.TabIndex = 6;
            this.btnLoc.Text = "🔍 Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);

            this.btnXuatExcel.BackColor = System.Drawing.Color.White;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnXuatExcel.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.btnXuatExcel.Location = new System.Drawing.Point(603, 7);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(95, 27);
            this.btnXuatExcel.TabIndex = 7;
            this.btnXuatExcel.Text = "📥 Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);

            // ===== dgvThuNhap =====
            this.dgvThuNhap.AllowUserToAddRows = false;
            this.dgvThuNhap.AllowUserToDeleteRows = false;
            this.dgvThuNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThuNhap.BackgroundColor = System.Drawing.Color.White;
            this.dgvThuNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvThuNhap.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThuNhap.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(244, 246, 248);
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dgvHeaderStyle.Padding = new System.Windows.Forms.Padding(4);
            this.dgvThuNhap.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvThuNhap.ColumnHeadersHeight = 32;
            this.dgvThuNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colNgay, this.colLoaiThu, this.colVi, this.colSoTien, this.colGhiChu
            });
            dgvRowStyle.BackColor = System.Drawing.Color.White;
            dgvRowStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(227, 242, 253);
            dgvRowStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvThuNhap.DefaultCellStyle = dgvRowStyle;
            this.dgvThuNhap.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvThuNhap.EnableHeadersVisualStyles = false;
            this.dgvThuNhap.Location = new System.Drawing.Point(12, 42);
            this.dgvThuNhap.MultiSelect = false;
            this.dgvThuNhap.Name = "dgvThuNhap";
            this.dgvThuNhap.ReadOnly = true;
            this.dgvThuNhap.RowHeadersVisible = false;
            this.dgvThuNhap.RowTemplate.Height = 28;
            this.dgvThuNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThuNhap.Size = new System.Drawing.Size(774, 230);
            this.dgvThuNhap.TabIndex = 1;
            this.dgvThuNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThuNhap_CellClick);

            this.colNgay.DataPropertyName = "Ngay";
            this.colNgay.FillWeight = 85F;
            this.colNgay.HeaderText = "Ngày";
            this.colNgay.Name = "colNgay";

            this.colLoaiThu.DataPropertyName = "LoaiThu";
            this.colLoaiThu.FillWeight = 95F;
            this.colLoaiThu.HeaderText = "Loại thu";
            this.colLoaiThu.Name = "colLoaiThu";

            this.colVi.DataPropertyName = "Vi";
            this.colVi.FillWeight = 95F;
            this.colVi.HeaderText = "Ví";
            this.colVi.Name = "colVi";

            this.colSoTien.DataPropertyName = "SoTienFormatted";
            this.colSoTien.FillWeight = 100F;
            this.colSoTien.HeaderText = "Số tiền";
            this.colSoTien.Name = "colSoTien";

            this.colGhiChu.DataPropertyName = "GhiChu";
            this.colGhiChu.FillWeight = 160F;
            this.colGhiChu.HeaderText = "Ghi chú";
            this.colGhiChu.Name = "colGhiChu";

            // ===== lblSoGiaoDich =====
            this.lblSoGiaoDich.AutoSize = true;
            this.lblSoGiaoDich.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblSoGiaoDich.ForeColor = System.Drawing.Color.Gray;
            this.lblSoGiaoDich.Location = new System.Drawing.Point(14, 276);
            this.lblSoGiaoDich.Name = "lblSoGiaoDich";
            this.lblSoGiaoDich.Size = new System.Drawing.Size(205, 12);
            this.lblSoGiaoDich.TabIndex = 2;
            this.lblSoGiaoDich.Text = "Chỉ đọc • Số giao dịch: 2 • Hiển thị toàn bộ kết quả";

            // ===== pnlTongThu =====
            this.pnlTongThu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTongThu.BackColor = System.Drawing.Color.White;
            this.pnlTongThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTongThu.Controls.Add(this.lblTongThuTrongKyLoc);
            this.pnlTongThu.Controls.Add(this.lblTongThu);
            this.pnlTongThu.Location = new System.Drawing.Point(490, 276);
            this.pnlTongThu.Name = "pnlTongThu";
            this.pnlTongThu.Size = new System.Drawing.Size(296, 45);
            this.pnlTongThu.TabIndex = 3;

            this.lblTongThuTrongKyLoc.AutoSize = true;
            this.lblTongThuTrongKyLoc.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTongThuTrongKyLoc.ForeColor = System.Drawing.Color.Gray;
            this.lblTongThuTrongKyLoc.Location = new System.Drawing.Point(8, 14);
            this.lblTongThuTrongKyLoc.Name = "lblTongThuTrongKyLoc";
            this.lblTongThuTrongKyLoc.Size = new System.Drawing.Size(126, 15);
            this.lblTongThuTrongKyLoc.TabIndex = 0;
            this.lblTongThuTrongKyLoc.Text = "Tổng thu trong kỳ lọc";

            this.lblTongThu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongThu.AutoSize = true;
            this.lblTongThu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongThu.ForeColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.lblTongThu.Location = new System.Drawing.Point(145, 10);
            this.lblTongThu.Name = "lblTongThu";
            this.lblTongThu.Size = new System.Drawing.Size(142, 21);
            this.lblTongThu.TabIndex = 1;
            this.lblTongThu.Text = "25.000.000 đ";
            this.lblTongThu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // ===== pnlCoCauThuNhap =====
            this.pnlCoCauThuNhap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCoCauThuNhap.BackColor = System.Drawing.Color.White;
            this.pnlCoCauThuNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCoCauThuNhap.Controls.Add(this.lblCoCauThuNhapThang10);
            this.pnlCoCauThuNhap.Controls.Add(this.lblLuong);
            this.pnlCoCauThuNhap.Controls.Add(this.lblLuong2);
            this.pnlCoCauThuNhap.Controls.Add(this.lblLuong3);
            this.pnlCoCauThuNhap.Controls.Add(this.lblThuong);
            this.pnlCoCauThuNhap.Controls.Add(this.lblThuong2);
            this.pnlCoCauThuNhap.Controls.Add(this.lblThuong3);
            this.pnlCoCauThuNhap.Controls.Add(this.lblThuNhapKhac);
            this.pnlCoCauThuNhap.Controls.Add(this.lblThuNhapKhac2);
            this.pnlCoCauThuNhap.Controls.Add(this.lblThuNhapKhac3);
            this.pnlCoCauThuNhap.Location = new System.Drawing.Point(12, 328);
            this.pnlCoCauThuNhap.Name = "pnlCoCauThuNhap";
            this.pnlCoCauThuNhap.Size = new System.Drawing.Size(774, 115);
            this.pnlCoCauThuNhap.TabIndex = 4;

            this.lblCoCauThuNhapThang10.AutoSize = true;
            this.lblCoCauThuNhapThang10.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCoCauThuNhapThang10.Location = new System.Drawing.Point(10, 8);
            this.lblCoCauThuNhapThang10.Name = "lblCoCauThuNhapThang10";
            this.lblCoCauThuNhapThang10.Size = new System.Drawing.Size(155, 17);
            this.lblCoCauThuNhapThang10.TabIndex = 0;
            this.lblCoCauThuNhapThang10.Text = "Cơ cấu thu nhập tháng 10";

            // Row 1: Lương
            this.lblLuong.AutoSize = true;
            this.lblLuong.Location = new System.Drawing.Point(12, 35);
            this.lblLuong.Name = "lblLuong";
            this.lblLuong.Size = new System.Drawing.Size(41, 15);
            this.lblLuong.TabIndex = 1;
            this.lblLuong.Text = "Lương";

            this.lblLuong2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLuong2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLuong2.ForeColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.lblLuong2.Location = new System.Drawing.Point(520, 35);
            this.lblLuong2.Name = "lblLuong2";
            this.lblLuong2.Size = new System.Drawing.Size(160, 15);
            this.lblLuong2.TabIndex = 2;
            this.lblLuong2.Text = "23.000.000 đ";
            this.lblLuong2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblLuong3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLuong3.ForeColor = System.Drawing.Color.Gray;
            this.lblLuong3.Location = new System.Drawing.Point(690, 35);
            this.lblLuong3.Name = "lblLuong3";
            this.lblLuong3.Size = new System.Drawing.Size(65, 15);
            this.lblLuong3.TabIndex = 3;
            this.lblLuong3.Text = "92,0%";
            this.lblLuong3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // Row 2: Thưởng
            this.lblThuong.AutoSize = true;
            this.lblThuong.Location = new System.Drawing.Point(12, 60);
            this.lblThuong.Name = "lblThuong";
            this.lblThuong.Size = new System.Drawing.Size(49, 15);
            this.lblThuong.TabIndex = 4;
            this.lblThuong.Text = "Thưởng";

            this.lblThuong2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThuong2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblThuong2.ForeColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.lblThuong2.Location = new System.Drawing.Point(520, 60);
            this.lblThuong2.Name = "lblThuong2";
            this.lblThuong2.Size = new System.Drawing.Size(160, 15);
            this.lblThuong2.TabIndex = 5;
            this.lblThuong2.Text = "0 đ";
            this.lblThuong2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblThuong3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThuong3.ForeColor = System.Drawing.Color.Gray;
            this.lblThuong3.Location = new System.Drawing.Point(690, 60);
            this.lblThuong3.Name = "lblThuong3";
            this.lblThuong3.Size = new System.Drawing.Size(65, 15);
            this.lblThuong3.TabIndex = 6;
            this.lblThuong3.Text = "0,0%";
            this.lblThuong3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // Row 3: Thu nhập khác
            this.lblThuNhapKhac.AutoSize = true;
            this.lblThuNhapKhac.Location = new System.Drawing.Point(12, 85);
            this.lblThuNhapKhac.Name = "lblThuNhapKhac";
            this.lblThuNhapKhac.Size = new System.Drawing.Size(86, 15);
            this.lblThuNhapKhac.TabIndex = 7;
            this.lblThuNhapKhac.Text = "Thu nhập khác";

            this.lblThuNhapKhac2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThuNhapKhac2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblThuNhapKhac2.ForeColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.lblThuNhapKhac2.Location = new System.Drawing.Point(520, 85);
            this.lblThuNhapKhac2.Name = "lblThuNhapKhac2";
            this.lblThuNhapKhac2.Size = new System.Drawing.Size(160, 15);
            this.lblThuNhapKhac2.TabIndex = 8;
            this.lblThuNhapKhac2.Text = "2.000.000 đ";
            this.lblThuNhapKhac2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblThuNhapKhac3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThuNhapKhac3.ForeColor = System.Drawing.Color.Gray;
            this.lblThuNhapKhac3.Location = new System.Drawing.Point(690, 85);
            this.lblThuNhapKhac3.Name = "lblThuNhapKhac3";
            this.lblThuNhapKhac3.Size = new System.Drawing.Size(65, 15);
            this.lblThuNhapKhac3.TabIndex = 9;
            this.lblThuNhapKhac3.Text = "8,0%";
            this.lblThuNhapKhac3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // ===== stsTrangThai =====
            this.stsTrangThai.BackColor = System.Drawing.Color.White;
            this.stsTrangThai.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.tsslTrangThai, this.tsslSpring, this.tsslViDangChon, this.tsslHomNay
            });
            this.stsTrangThai.Location = new System.Drawing.Point(0, 587);
            this.stsTrangThai.Name = "stsTrangThai";
            this.stsTrangThai.Size = new System.Drawing.Size(1060, 22);
            this.stsTrangThai.TabIndex = 4;

            this.tsslTrangThai.ForeColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.tsslTrangThai.Name = "tsslTrangThai";
            this.tsslTrangThai.Size = new System.Drawing.Size(205, 17);
            this.tsslTrangThai.Text = "✔ Sẵn sàng   |   Đăng nhập: Nguyễn Minh Anh";

            this.tsslSpring.Name = "tsslSpring";
            this.tsslSpring.Size = new System.Drawing.Size(536, 17);
            this.tsslSpring.Spring = true;

            this.tsslViDangChon.ForeColor = System.Drawing.Color.Gray;
            this.tsslViDangChon.Name = "tsslViDangChon";
            this.tsslViDangChon.Size = new System.Drawing.Size(155, 17);
            this.tsslViDangChon.Text = "Ví đang chọn: Vietcombank";

            this.tsslHomNay.ForeColor = System.Drawing.Color.Gray;
            this.tsslHomNay.Name = "tsslHomNay";
            this.tsslHomNay.Size = new System.Drawing.Size(149, 17);
            this.tsslHomNay.Text = "Hôm nay: " + System.DateTime.Today.ToString("dd/MM/yyyy");

            // ===== Form Setup =====
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 609);
            this.Controls.Add(this.pnlNoiDung);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.mnuChinh);
            this.Controls.Add(this.stsTrangThai);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmQuanLyThuNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Chi Tiêu — Quản lý thu nhập";
            this.Load += new System.EventHandler(this.frmQuanLyThuNhap_Load);

            this.mnuChinh.ResumeLayout(false);
            this.mnuChinh.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlNoiDung.ResumeLayout(false);
            this.pnlQuanLyGiaoDich.ResumeLayout(false);
            this.pnlQuanLyGiaoDich.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlBoLoc.ResumeLayout(false);
            this.pnlBoLoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThuNhap)).EndInit();
            this.pnlTongThu.ResumeLayout(false);
            this.pnlTongThu.PerformLayout();
            this.pnlCoCauThuNhap.ResumeLayout(false);
            this.pnlCoCauThuNhap.PerformLayout();
            this.stsTrangThai.ResumeLayout(false);
            this.stsTrangThai.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Menu
        private System.Windows.Forms.MenuStrip mnuChinh;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuCauHinh;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnuNghiepVu;
        private System.Windows.Forms.ToolStripMenuItem mnuNVThuNhap;
        private System.Windows.Forms.ToolStripMenuItem mnuNVChiTieu;
        private System.Windows.Forms.ToolStripMenuItem mnuNVNganSach;
        private System.Windows.Forms.ToolStripMenuItem mnuNVChuyenTien;
        private System.Windows.Forms.ToolStripMenuItem mnuNVTimKiem;
        private System.Windows.Forms.ToolStripMenuItem mnuBaoCao;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanTri;
        private System.Windows.Forms.ToolStripMenuItem mnuTroGiup;

        // Toolbar
        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.Button btnThuNhap;
        private System.Windows.Forms.Button btnChiTieu;
        private System.Windows.Forms.Button btnNganSach;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.DateTimePicker dtpThang;
        private System.Windows.Forms.Button btnLamMoi;

        // Header
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblQuanLyThuNhap;
        private System.Windows.Forms.Label lblThang102026DuLieuDen;

        // Content
        private System.Windows.Forms.Panel pnlNoiDung;
        private System.Windows.Forms.Panel pnlQuanLyGiaoDich;
        private System.Windows.Forms.Label lblThongTinKhoanThu;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Label lblLoaiThu;
        private System.Windows.Forms.ComboBox cboLoaiThu;
        private System.Windows.Forms.Label lblLoaiThu2;
        private System.Windows.Forms.Label lblViThu;
        private System.Windows.Forms.ComboBox cboViThu;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnMoi;
        private System.Windows.Forms.Label lblChonMotDongDeSuaHoac;

        // Right
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlBoLoc;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label lblLocLoaiThu;
        private System.Windows.Forms.ComboBox cboLocLoaiThu;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnXuatExcel;

        // Grid
        private System.Windows.Forms.DataGridView dgvThuNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
        private System.Windows.Forms.Label lblSoGiaoDich;

        // Bottom
        private System.Windows.Forms.Panel pnlTongThu;
        private System.Windows.Forms.Label lblTongThuTrongKyLoc;
        private System.Windows.Forms.Label lblTongThu;
        private System.Windows.Forms.Panel pnlCoCauThuNhap;
        private System.Windows.Forms.Label lblCoCauThuNhapThang10;
        private System.Windows.Forms.Label lblLuong;
        private System.Windows.Forms.Label lblLuong2;
        private System.Windows.Forms.Label lblLuong3;
        private System.Windows.Forms.Label lblThuong;
        private System.Windows.Forms.Label lblThuong2;
        private System.Windows.Forms.Label lblThuong3;
        private System.Windows.Forms.Label lblThuNhapKhac;
        private System.Windows.Forms.Label lblThuNhapKhac2;
        private System.Windows.Forms.Label lblThuNhapKhac3;

        // Status
        private System.Windows.Forms.StatusStrip stsTrangThai;
        private System.Windows.Forms.ToolStripStatusLabel tsslTrangThai;
        private System.Windows.Forms.ToolStripStatusLabel tsslSpring;
        private System.Windows.Forms.ToolStripStatusLabel tsslViDangChon;
        private System.Windows.Forms.ToolStripStatusLabel tsslHomNay;
    }
}
