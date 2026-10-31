namespace QuanLyChiTieu.Forms
{
    partial class frmTimKiem
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
            this.lblNguoiDungHienTai = new System.Windows.Forms.Label();

            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblTimKiemGiaoDich = new System.Windows.Forms.Label();

            this.pnlBoLoc = new System.Windows.Forms.Panel();
            this.lblTuKhoa = new System.Windows.Forms.Label();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.lblLoaiGiaoDich = new System.Windows.Forms.Label();
            this.cboLoaiGiaoDich = new System.Windows.Forms.ComboBox();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();

            this.lblTienTu = new System.Windows.Forms.Label();
            this.txtTienTu = new System.Windows.Forms.TextBox();
            this.lblTienDen = new System.Windows.Forms.Label();
            this.txtTienDen = new System.Windows.Forms.TextBox();
            this.lblLoai = new System.Windows.Forms.Label();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.lblVi = new System.Windows.Forms.Label();
            this.cboVi = new System.Windows.Forms.ComboBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnXoaLoc = new System.Windows.Forms.Button();
            this.lblLoaiGiaoDichTatCaThu = new System.Windows.Forms.Label();

            this.pnlKetQua = new System.Windows.Forms.Panel();
            this.lblKetQuaTimKiem5Giao = new System.Windows.Forms.Label();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.colNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiGiaoDich = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiThuChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblHienThi155Chi = new System.Windows.Forms.Label();

            this.pnlTongKet = new System.Windows.Forms.Panel();
            this.lblTongThu25000000 = new System.Windows.Forms.Label();
            this.lblTongChi8100000 = new System.Windows.Forms.Label();
            this.lblChenhLechThuChi16900 = new System.Windows.Forms.Label();

            this.stsTrangThai = new System.Windows.Forms.StatusStrip();
            this.tsslTrangThai = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslViDangChon = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslHomNay = new System.Windows.Forms.ToolStripStatusLabel();

            this.mnuChinh.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlBoLoc.SuspendLayout();
            this.pnlKetQua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.pnlTongKet.SuspendLayout();
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
            this.mnuNVThuNhap.Click += (s, e) => NavigateTo<frmQuanLyThuNhap>();
            this.mnuNVChiTieu.Text = "Quản lý chi tiêu";
            this.mnuNVChiTieu.Click += (s, e) => NavigateTo<frmQuanLyChiTieu>();
            this.mnuNVNganSach.Text = "Ngân sách";
            this.mnuNVNganSach.Click += (s, e) => NavigateTo<frmNganSach>();
            this.mnuNVChuyenTien.Text = "Chuyển tiền giữa các ví";
            this.mnuNVChuyenTien.Click += (s, e) => NavigateTo<frmChuyenTien>();
            this.mnuNVTimKiem.Text = "Tìm kiếm giao dịch";

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
            this.pnlToolbar.Controls.Add(this.lblNguoiDungHienTai);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 25);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1060, 42);
            this.pnlToolbar.TabIndex = 1;

            this.btnThuNhap.BackColor = System.Drawing.Color.White;
            this.btnThuNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThuNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThuNhap.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.btnThuNhap.Location = new System.Drawing.Point(12, 6);
            this.btnThuNhap.Name = "btnThuNhap";
            this.btnThuNhap.Size = new System.Drawing.Size(95, 29);
            this.btnThuNhap.TabIndex = 0;
            this.btnThuNhap.Text = "+ Thu nhập";
            this.btnThuNhap.UseVisualStyleBackColor = true;
            this.btnThuNhap.Click += (s, e) => NavigateTo<frmQuanLyThuNhap>();

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
            this.btnChiTieu.Click += (s, e) => NavigateTo<frmQuanLyChiTieu>();

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
            this.btnNganSach.Click += (s, e) => NavigateTo<frmNganSach>();

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

            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(21, 101, 192);
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Location = new System.Drawing.Point(401, 6);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(90, 29);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "🔍 Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;

            this.lblNguoiDungHienTai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNguoiDungHienTai.AutoSize = true;
            this.lblNguoiDungHienTai.ForeColor = System.Drawing.Color.Gray;
            this.lblNguoiDungHienTai.Location = new System.Drawing.Point(920, 13);
            this.lblNguoiDungHienTai.Name = "lblNguoiDungHienTai";
            this.lblNguoiDungHienTai.Size = new System.Drawing.Size(107, 15);
            this.lblNguoiDungHienTai.TabIndex = 5;
            this.lblNguoiDungHienTai.Text = "Nguyễn Minh Anh";

            // ===== pnlMain =====
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(244, 246, 248);
            this.pnlMain.Controls.Add(this.pnlTongKet);
            this.pnlMain.Controls.Add(this.pnlKetQua);
            this.pnlMain.Controls.Add(this.pnlBoLoc);
            this.pnlMain.Controls.Add(this.lblTimKiemGiaoDich);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 67);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlMain.Size = new System.Drawing.Size(1060, 520);
            this.pnlMain.TabIndex = 2;

            this.lblTimKiemGiaoDich.AutoSize = true;
            this.lblTimKiemGiaoDich.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblTimKiemGiaoDich.ForeColor = System.Drawing.Color.FromArgb(26, 35, 126);
            this.lblTimKiemGiaoDich.Location = new System.Drawing.Point(16, 10);
            this.lblTimKiemGiaoDich.Name = "lblTimKiemGiaoDich";
            this.lblTimKiemGiaoDich.Size = new System.Drawing.Size(176, 25);
            this.lblTimKiemGiaoDich.TabIndex = 0;
            this.lblTimKiemGiaoDich.Text = "Tìm kiếm giao dịch";

            // ===== pnlBoLoc =====
            this.pnlBoLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBoLoc.BackColor = System.Drawing.Color.White;
            this.pnlBoLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBoLoc.Controls.Add(this.lblTuKhoa);
            this.pnlBoLoc.Controls.Add(this.txtTuKhoa);
            this.pnlBoLoc.Controls.Add(this.lblLoaiGiaoDich);
            this.pnlBoLoc.Controls.Add(this.cboLoaiGiaoDich);
            this.pnlBoLoc.Controls.Add(this.lblTuNgay);
            this.pnlBoLoc.Controls.Add(this.dtpTuNgay);
            this.pnlBoLoc.Controls.Add(this.lblDenNgay);
            this.pnlBoLoc.Controls.Add(this.dtpDenNgay);
            this.pnlBoLoc.Controls.Add(this.lblTienTu);
            this.pnlBoLoc.Controls.Add(this.txtTienTu);
            this.pnlBoLoc.Controls.Add(this.lblTienDen);
            this.pnlBoLoc.Controls.Add(this.txtTienDen);
            this.pnlBoLoc.Controls.Add(this.lblLoai);
            this.pnlBoLoc.Controls.Add(this.cboLoai);
            this.pnlBoLoc.Controls.Add(this.lblVi);
            this.pnlBoLoc.Controls.Add(this.cboVi);
            this.pnlBoLoc.Controls.Add(this.btnTim);
            this.pnlBoLoc.Controls.Add(this.btnXoaLoc);
            this.pnlBoLoc.Controls.Add(this.lblLoaiGiaoDichTatCaThu);
            this.pnlBoLoc.Location = new System.Drawing.Point(16, 42);
            this.pnlBoLoc.Name = "pnlBoLoc";
            this.pnlBoLoc.Size = new System.Drawing.Size(1028, 120);
            this.pnlBoLoc.TabIndex = 1;

            // Row 1
            this.lblTuKhoa.AutoSize = true;
            this.lblTuKhoa.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTuKhoa.Location = new System.Drawing.Point(12, 12);
            this.lblTuKhoa.Name = "lblTuKhoa";
            this.lblTuKhoa.Size = new System.Drawing.Size(95, 15);
            this.lblTuKhoa.TabIndex = 0;
            this.lblTuKhoa.Text = "Từ khóa ghi chú:";

            this.txtTuKhoa.Location = new System.Drawing.Point(115, 9);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(160, 23);
            this.txtTuKhoa.TabIndex = 1;

            this.lblLoaiGiaoDich.AutoSize = true;
            this.lblLoaiGiaoDich.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLoaiGiaoDich.Location = new System.Drawing.Point(290, 12);
            this.lblLoaiGiaoDich.Name = "lblLoaiGiaoDich";
            this.lblLoaiGiaoDich.Size = new System.Drawing.Size(86, 15);
            this.lblLoaiGiaoDich.TabIndex = 2;
            this.lblLoaiGiaoDich.Text = "Loại giao dịch:";

            this.cboLoaiGiaoDich.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiGiaoDich.FormattingEnabled = true;
            this.cboLoaiGiaoDich.Items.AddRange(new object[] { "Tất cả", "Thu", "Chi" });
            this.cboLoaiGiaoDich.Location = new System.Drawing.Point(382, 9);
            this.cboLoaiGiaoDich.Name = "cboLoaiGiaoDich";
            this.cboLoaiGiaoDich.Size = new System.Drawing.Size(100, 23);
            this.cboLoaiGiaoDich.TabIndex = 3;

            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTuNgay.Location = new System.Drawing.Point(500, 12);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(52, 15);
            this.lblTuNgay.TabIndex = 4;
            this.lblTuNgay.Text = "Từ ngày:";

            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(558, 9);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(110, 23);
            this.dtpTuNgay.TabIndex = 5;

            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDenNgay.Location = new System.Drawing.Point(680, 12);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(60, 15);
            this.lblDenNgay.TabIndex = 6;
            this.lblDenNgay.Text = "Đến ngày:";

            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(746, 9);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(110, 23);
            this.dtpDenNgay.TabIndex = 7;

            // Row 2
            this.lblTienTu.AutoSize = true;
            this.lblTienTu.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTienTu.Location = new System.Drawing.Point(12, 48);
            this.lblTienTu.Name = "lblTienTu";
            this.lblTienTu.Size = new System.Drawing.Size(65, 15);
            this.lblTienTu.TabIndex = 8;
            this.lblTienTu.Text = "Số tiền từ:";

            this.txtTienTu.Location = new System.Drawing.Point(82, 45);
            this.txtTienTu.Name = "txtTienTu";
            this.txtTienTu.Size = new System.Drawing.Size(85, 23);
            this.txtTienTu.TabIndex = 9;

            this.lblTienDen.AutoSize = true;
            this.lblTienDen.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTienDen.Location = new System.Drawing.Point(175, 48);
            this.lblTienDen.Name = "lblTienDen";
            this.lblTienDen.Size = new System.Drawing.Size(30, 15);
            this.lblTienDen.TabIndex = 10;
            this.lblTienDen.Text = "đến:";

            this.txtTienDen.Location = new System.Drawing.Point(210, 45);
            this.txtTienDen.Name = "txtTienDen";
            this.txtTienDen.Size = new System.Drawing.Size(85, 23);
            this.txtTienDen.TabIndex = 11;

            this.lblLoai.AutoSize = true;
            this.lblLoai.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLoai.Location = new System.Drawing.Point(305, 48);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(71, 15);
            this.lblLoai.TabIndex = 12;
            this.lblLoai.Text = "Loại thu/chi:";

            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.FormattingEnabled = true;
            this.cboLoai.Location = new System.Drawing.Point(382, 45);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(100, 23);
            this.cboLoai.TabIndex = 13;

            this.lblVi.AutoSize = true;
            this.lblVi.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblVi.Location = new System.Drawing.Point(500, 48);
            this.lblVi.Name = "lblVi";
            this.lblVi.Size = new System.Drawing.Size(20, 15);
            this.lblVi.TabIndex = 14;
            this.lblVi.Text = "Ví:";

            this.cboVi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVi.FormattingEnabled = true;
            this.cboVi.Location = new System.Drawing.Point(528, 45);
            this.cboVi.Name = "cboVi";
            this.cboVi.Size = new System.Drawing.Size(140, 23);
            this.cboVi.TabIndex = 15;

            this.btnTim.BackColor = System.Drawing.Color.FromArgb(21, 101, 192);
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnTim.ForeColor = System.Drawing.Color.White;
            this.btnTim.Location = new System.Drawing.Point(680, 43);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 27);
            this.btnTim.TabIndex = 16;
            this.btnTim.Text = "🔍 Tìm";
            this.btnTim.UseVisualStyleBackColor = false;

            this.btnXoaLoc.BackColor = System.Drawing.Color.White;
            this.btnXoaLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaLoc.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnXoaLoc.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.btnXoaLoc.Location = new System.Drawing.Point(761, 43);
            this.btnXoaLoc.Name = "btnXoaLoc";
            this.btnXoaLoc.Size = new System.Drawing.Size(75, 27);
            this.btnXoaLoc.TabIndex = 17;
            this.btnXoaLoc.Text = "Xóa lọc";
            this.btnXoaLoc.UseVisualStyleBackColor = true;

            this.lblLoaiGiaoDichTatCaThu.AutoSize = true;
            this.lblLoaiGiaoDichTatCaThu.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblLoaiGiaoDichTatCaThu.ForeColor = System.Drawing.Color.Gray;
            this.lblLoaiGiaoDichTatCaThu.Location = new System.Drawing.Point(12, 90);
            this.lblLoaiGiaoDichTatCaThu.Name = "lblLoaiGiaoDichTatCaThu";
            this.lblLoaiGiaoDichTatCaThu.Size = new System.Drawing.Size(465, 12);
            this.lblLoaiGiaoDichTatCaThu.TabIndex = 18;
            this.lblLoaiGiaoDichTatCaThu.Text = "Loại giao dịch: Tất cả / Thu / Chi • Từ khóa để trống: không giới hạn ghi chú • Khoảng tiền tính theo giá trị giao dịch.";

            // ===== pnlKetQua =====
            this.pnlKetQua.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlKetQua.BackColor = System.Drawing.Color.White;
            this.pnlKetQua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKetQua.Controls.Add(this.lblKetQuaTimKiem5Giao);
            this.pnlKetQua.Controls.Add(this.btnXuatExcel);
            this.pnlKetQua.Controls.Add(this.dgvKetQua);
            this.pnlKetQua.Controls.Add(this.lblHienThi155Chi);
            this.pnlKetQua.Location = new System.Drawing.Point(16, 170);
            this.pnlKetQua.Name = "pnlKetQua";
            this.pnlKetQua.Size = new System.Drawing.Size(1028, 290);
            this.pnlKetQua.TabIndex = 2;

            this.lblKetQuaTimKiem5Giao.AutoSize = true;
            this.lblKetQuaTimKiem5Giao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKetQuaTimKiem5Giao.Location = new System.Drawing.Point(12, 10);
            this.lblKetQuaTimKiem5Giao.Name = "lblKetQuaTimKiem5Giao";
            this.lblKetQuaTimKiem5Giao.Size = new System.Drawing.Size(200, 19);
            this.lblKetQuaTimKiem5Giao.TabIndex = 0;
            this.lblKetQuaTimKiem5Giao.Text = "Kết quả tìm kiếm — 5 giao dịch";

            this.btnXuatExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXuatExcel.BackColor = System.Drawing.Color.White;
            this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnXuatExcel.Location = new System.Drawing.Point(920, 6);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(95, 27);
            this.btnXuatExcel.TabIndex = 1;
            this.btnXuatExcel.Text = "📥 Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;

            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.AllowUserToDeleteRows = false;
            this.dgvKetQua.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKetQua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKetQua.BackgroundColor = System.Drawing.Color.White;
            this.dgvKetQua.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvKetQua.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvKetQua.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(244, 246, 248);
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
            dgvHeaderStyle.Padding = new System.Windows.Forms.Padding(4);
            this.dgvKetQua.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvKetQua.ColumnHeadersHeight = 32;
            this.dgvKetQua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colNgay, this.colLoaiGiaoDich, this.colLoaiThuChi, this.colVi, this.colSoTien, this.colGhiChu
            });
            dgvRowStyle.BackColor = System.Drawing.Color.White;
            dgvRowStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(227, 242, 253);
            dgvRowStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvKetQua.DefaultCellStyle = dgvRowStyle;
            this.dgvKetQua.EnableHeadersVisualStyles = false;
            this.dgvKetQua.Location = new System.Drawing.Point(0, 39);
            this.dgvKetQua.MultiSelect = false;
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.ReadOnly = true;
            this.dgvKetQua.RowHeadersVisible = false;
            this.dgvKetQua.RowTemplate.Height = 28;
            this.dgvKetQua.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKetQua.Size = new System.Drawing.Size(1026, 220);
            this.dgvKetQua.TabIndex = 2;

            this.colNgay.DataPropertyName = "Ngay";
            this.colNgay.FillWeight = 85F;
            this.colNgay.HeaderText = "Ngày";
            this.colNgay.Name = "colNgay";

            this.colLoaiGiaoDich.DataPropertyName = "LoaiGiaoDich";
            this.colLoaiGiaoDich.FillWeight = 80F;
            this.colLoaiGiaoDich.HeaderText = "Loại giao dịch";
            this.colLoaiGiaoDich.Name = "colLoaiGiaoDich";

            this.colLoaiThuChi.DataPropertyName = "LoaiThuChi";
            this.colLoaiThuChi.FillWeight = 95F;
            this.colLoaiThuChi.HeaderText = "Loại thu / chi";
            this.colLoaiThuChi.Name = "colLoaiThuChi";

            this.colVi.DataPropertyName = "Vi";
            this.colVi.FillWeight = 90F;
            this.colVi.HeaderText = "Ví";
            this.colVi.Name = "colVi";

            this.colSoTien.DataPropertyName = "SoTien";
            this.colSoTien.FillWeight = 95F;
            this.colSoTien.HeaderText = "Số tiền";
            this.colSoTien.Name = "colSoTien";

            this.colGhiChu.DataPropertyName = "GhiChu";
            this.colGhiChu.FillWeight = 160F;
            this.colGhiChu.HeaderText = "Ghi chú";
            this.colGhiChu.Name = "colGhiChu";

            this.lblHienThi155Chi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHienThi155Chi.AutoSize = true;
            this.lblHienThi155Chi.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblHienThi155Chi.ForeColor = System.Drawing.Color.Gray;
            this.lblHienThi155Chi.Location = new System.Drawing.Point(12, 268);
            this.lblHienThi155Chi.Name = "lblHienThi155Chi";
            this.lblHienThi155Chi.Size = new System.Drawing.Size(107, 12);
            this.lblHienThi155Chi.TabIndex = 3;
            this.lblHienThi155Chi.Text = "Hiển thị 1-5 / 5 • Chỉ đọc";

            // ===== pnlTongKet =====
            this.pnlTongKet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTongKet.BackColor = System.Drawing.Color.Transparent;
            this.pnlTongKet.Controls.Add(this.lblTongThu25000000);
            this.pnlTongKet.Controls.Add(this.lblTongChi8100000);
            this.pnlTongKet.Controls.Add(this.lblChenhLechThuChi16900);
            this.pnlTongKet.Location = new System.Drawing.Point(350, 465);
            this.pnlTongKet.Name = "pnlTongKet";
            this.pnlTongKet.Size = new System.Drawing.Size(694, 30);
            this.pnlTongKet.TabIndex = 3;

            this.lblTongThu25000000.AutoSize = true;
            this.lblTongThu25000000.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTongThu25000000.ForeColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.lblTongThu25000000.Location = new System.Drawing.Point(20, 7);
            this.lblTongThu25000000.Name = "lblTongThu25000000";
            this.lblTongThu25000000.Size = new System.Drawing.Size(142, 15);
            this.lblTongThu25000000.TabIndex = 0;
            this.lblTongThu25000000.Text = "Tổng thu: 25.000.000 đ";

            this.lblTongChi8100000.AutoSize = true;
            this.lblTongChi8100000.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTongChi8100000.ForeColor = System.Drawing.Color.FromArgb(211, 47, 47);
            this.lblTongChi8100000.Location = new System.Drawing.Point(200, 7);
            this.lblTongChi8100000.Name = "lblTongChi8100000";
            this.lblTongChi8100000.Size = new System.Drawing.Size(130, 15);
            this.lblTongChi8100000.TabIndex = 1;
            this.lblTongChi8100000.Text = "Tổng chi: 8.100.000 đ";

            this.lblChenhLechThuChi16900.AutoSize = true;
            this.lblChenhLechThuChi16900.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblChenhLechThuChi16900.ForeColor = System.Drawing.Color.FromArgb(21, 101, 192);
            this.lblChenhLechThuChi16900.Location = new System.Drawing.Point(370, 7);
            this.lblChenhLechThuChi16900.Name = "lblChenhLechThuChi16900";
            this.lblChenhLechThuChi16900.Size = new System.Drawing.Size(209, 15);
            this.lblChenhLechThuChi16900.TabIndex = 2;
            this.lblChenhLechThuChi16900.Text = "Chênh lệch thu – chi: 16.900.000 đ";

            // ===== stsTrangThai =====
            this.stsTrangThai.BackColor = System.Drawing.Color.White;
            this.stsTrangThai.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.tsslTrangThai, this.tsslSpring, this.tsslViDangChon, this.tsslHomNay
            });
            this.stsTrangThai.Location = new System.Drawing.Point(0, 587);
            this.stsTrangThai.Name = "stsTrangThai";
            this.stsTrangThai.Size = new System.Drawing.Size(1060, 22);
            this.stsTrangThai.TabIndex = 3;

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
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.mnuChinh);
            this.Controls.Add(this.stsTrangThai);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmTimKiem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Chi Tiêu — Tìm kiếm giao dịch";

            this.mnuChinh.ResumeLayout(false);
            this.mnuChinh.PerformLayout();
            this.pnlToolbar.ResumeLayout(false);
            this.pnlToolbar.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlBoLoc.ResumeLayout(false);
            this.pnlBoLoc.PerformLayout();
            this.pnlKetQua.ResumeLayout(false);
            this.pnlKetQua.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.pnlTongKet.ResumeLayout(false);
            this.pnlTongKet.PerformLayout();
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
        private System.Windows.Forms.Label lblNguoiDungHienTai;

        // Content
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblTimKiemGiaoDich;

        // Filter
        private System.Windows.Forms.Panel pnlBoLoc;
        private System.Windows.Forms.Label lblTuKhoa;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Label lblLoaiGiaoDich;
        private System.Windows.Forms.ComboBox cboLoaiGiaoDich;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label lblTienTu;
        private System.Windows.Forms.TextBox txtTienTu;
        private System.Windows.Forms.Label lblTienDen;
        private System.Windows.Forms.TextBox txtTienDen;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Label lblVi;
        private System.Windows.Forms.ComboBox cboVi;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnXoaLoc;
        private System.Windows.Forms.Label lblLoaiGiaoDichTatCaThu;

        // Results
        private System.Windows.Forms.Panel pnlKetQua;
        private System.Windows.Forms.Label lblKetQuaTimKiem5Giao;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiGiaoDich;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiThuChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
        private System.Windows.Forms.Label lblHienThi155Chi;

        // Summary
        private System.Windows.Forms.Panel pnlTongKet;
        private System.Windows.Forms.Label lblTongThu25000000;
        private System.Windows.Forms.Label lblTongChi8100000;
        private System.Windows.Forms.Label lblChenhLechThuChi16900;

        // Status
        private System.Windows.Forms.StatusStrip stsTrangThai;
        private System.Windows.Forms.ToolStripStatusLabel tsslTrangThai;
        private System.Windows.Forms.ToolStripStatusLabel tsslSpring;
        private System.Windows.Forms.ToolStripStatusLabel tsslViDangChon;
        private System.Windows.Forms.ToolStripStatusLabel tsslHomNay;
    }
}
