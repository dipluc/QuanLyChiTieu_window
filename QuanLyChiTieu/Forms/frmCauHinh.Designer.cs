namespace QuanLyChiTieu.Forms
{
    partial class frmCauHinh
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
            // ── Declarations ──
            this.mnuChinh = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNghiepVu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanTri = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTroGiup = new System.Windows.Forms.ToolStripMenuItem();

            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.btnThuNhap = new System.Windows.Forms.Button();
            this.btnChiTieu = new System.Windows.Forms.Button();
            this.btnNganSach = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dtpThang = new System.Windows.Forms.DateTimePicker();
            this.btnLamMoi = new System.Windows.Forms.Button();

            this.pnlUserInfo = new System.Windows.Forms.Panel();
            this.lblNguoiDungHienTai = new System.Windows.Forms.Label();
            this.lblPhienDangNhap = new System.Windows.Forms.Label();

            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblCauHinhUngDung = new System.Windows.Forms.Label();

            this.pnlCauHinh = new System.Windows.Forms.Panel();

            // Section 1 - Sao luu du lieu
            this.lblSaoLuuDuLieu = new System.Windows.Forms.Label();
            this.pnlThuMucMacDinh = new System.Windows.Forms.Panel();
            this.lblThuMucMacDinh = new System.Windows.Forms.Label();
            this.txtThuMucSaoLuuMacDinh = new System.Windows.Forms.TextBox();
            this.pnlChonThuMuc = new System.Windows.Forms.Panel();
            this.btnDuyetThuMuc = new System.Windows.Forms.Button();
            this.lblGoiYThuMuc = new System.Windows.Forms.Label();
            this.chkTuDongSaoLuuKhiThoat = new System.Windows.Forms.CheckBox();
            this.pnlSaoLuu = new System.Windows.Forms.Panel();

            // Section 2 - Canh bao ngan sach
            this.pnlNganSach = new System.Windows.Forms.Panel();
            this.lblCanhBaoNganSach = new System.Windows.Forms.Label();
            this.pnlNguongCanhBao = new System.Windows.Forms.Panel();
            this.lblNguongCanhBao = new System.Windows.Forms.Label();
            this.txtNguongCanhBao = new System.Windows.Forms.TextBox();
            this.lblPercent = new System.Windows.Forms.Label();
            this.btnTang = new System.Windows.Forms.Button();
            this.btnGiam = new System.Windows.Forms.Button();
            this.lblNguongCanhBao2 = new System.Windows.Forms.Label();
            this.lblGiaiThichNguong = new System.Windows.Forms.Label();

            // Bottom buttons
            this.pnlBottomButtons = new System.Windows.Forms.Panel();
            this.btnLuuThayDoi = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();

            // Status strip
            this.stsTrangThai = new System.Windows.Forms.StatusStrip();
            this.tslDangNhap = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslSpring = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslHomNay = new System.Windows.Forms.ToolStripStatusLabel();

            this.SuspendLayout();
            this.pnlToolbar.SuspendLayout();
            this.pnlUserInfo.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlCauHinh.SuspendLayout();
            this.pnlThuMucMacDinh.SuspendLayout();
            this.pnlChonThuMuc.SuspendLayout();
            this.pnlSaoLuu.SuspendLayout();
            this.pnlNganSach.SuspendLayout();
            this.pnlNguongCanhBao.SuspendLayout();
            this.pnlBottomButtons.SuspendLayout();
            this.stsTrangThai.SuspendLayout();

            // ════════════════════════════════════════════════
            // mnuChinh
            // ════════════════════════════════════════════════
            this.mnuChinh.BackColor = System.Drawing.Color.White;
            this.mnuChinh.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.mnuChinh.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuHeThong, this.mnuDanhMuc, this.mnuNghiepVu,
                this.mnuBaoCao, this.mnuQuanTri, this.mnuTroGiup });
            this.mnuChinh.Location = new System.Drawing.Point(0, 0);
            this.mnuChinh.Name = "mnuChinh";
            this.mnuChinh.Size = new System.Drawing.Size(1050, 28);
            this.mnuChinh.TabIndex = 0;

            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Text = "Hệ thống";
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Text = "Danh mục";
            this.mnuNghiepVu.Name = "mnuNghiepVu";
            this.mnuNghiepVu.Text = "Nghiệp vụ";
            this.mnuBaoCao.Name = "mnuBaoCao";
            this.mnuBaoCao.Text = "Báo cáo";
            this.mnuQuanTri.Name = "mnuQuanTri";
            this.mnuQuanTri.Text = "Quản trị";
            this.mnuTroGiup.Name = "mnuTroGiup";
            this.mnuTroGiup.Text = "Trợ giúp";

            // ════════════════════════════════════════════════
            // pnlToolbar
            // ════════════════════════════════════════════════
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(245, 246, 248);
            this.pnlToolbar.Controls.Add(this.btnThuNhap);
            this.pnlToolbar.Controls.Add(this.btnChiTieu);
            this.pnlToolbar.Controls.Add(this.btnNganSach);
            this.pnlToolbar.Controls.Add(this.btnBaoCao);
            this.pnlToolbar.Controls.Add(this.btnTimKiem);
            this.pnlToolbar.Controls.Add(this.dtpThang);
            this.pnlToolbar.Controls.Add(this.btnLamMoi);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 28);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.pnlToolbar.Size = new System.Drawing.Size(1050, 48);
            this.pnlToolbar.TabIndex = 1;

            // btnThuNhap
            this.btnThuNhap.BackColor = System.Drawing.Color.White;
            this.btnThuNhap.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnThuNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThuNhap.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnThuNhap.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.btnThuNhap.Location = new System.Drawing.Point(12, 8);
            this.btnThuNhap.Name = "btnThuNhap";
            this.btnThuNhap.Size = new System.Drawing.Size(108, 32);
            this.btnThuNhap.TabIndex = 0;
            this.btnThuNhap.Text = "+ Thu nhập";
            this.btnThuNhap.UseVisualStyleBackColor = false;

            // btnChiTieu
            this.btnChiTieu.BackColor = System.Drawing.Color.White;
            this.btnChiTieu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnChiTieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChiTieu.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnChiTieu.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.btnChiTieu.Location = new System.Drawing.Point(126, 8);
            this.btnChiTieu.Name = "btnChiTieu";
            this.btnChiTieu.Size = new System.Drawing.Size(108, 32);
            this.btnChiTieu.TabIndex = 1;
            this.btnChiTieu.Text = "— Chi tiêu";
            this.btnChiTieu.UseVisualStyleBackColor = false;

            // btnNganSach
            this.btnNganSach.BackColor = System.Drawing.Color.White;
            this.btnNganSach.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnNganSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNganSach.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnNganSach.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.btnNganSach.Location = new System.Drawing.Point(240, 8);
            this.btnNganSach.Name = "btnNganSach";
            this.btnNganSach.Size = new System.Drawing.Size(108, 32);
            this.btnNganSach.TabIndex = 2;
            this.btnNganSach.Text = "Ngân sách";
            this.btnNganSach.UseVisualStyleBackColor = false;

            // btnBaoCao
            this.btnBaoCao.BackColor = System.Drawing.Color.White;
            this.btnBaoCao.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCao.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnBaoCao.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.btnBaoCao.Location = new System.Drawing.Point(354, 8);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(108, 32);
            this.btnBaoCao.TabIndex = 3;
            this.btnBaoCao.Text = "Báo cáo";
            this.btnBaoCao.UseVisualStyleBackColor = false;

            // btnTimKiem
            this.btnTimKiem.BackColor = System.Drawing.Color.White;
            this.btnTimKiem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnTimKiem.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.btnTimKiem.Location = new System.Drawing.Point(468, 8);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(108, 32);
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;

            // dtpThang
            this.dtpThang.CustomFormat = "MM/yyyy";
            this.dtpThang.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpThang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThang.Location = new System.Drawing.Point(820, 10);
            this.dtpThang.Name = "dtpThang";
            this.dtpThang.Size = new System.Drawing.Size(120, 29);
            this.dtpThang.TabIndex = 5;

            // btnLamMoi
            this.btnLamMoi.BackColor = System.Drawing.Color.White;
            this.btnLamMoi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.btnLamMoi.Location = new System.Drawing.Point(948, 8);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(88, 32);
            this.btnLamMoi.TabIndex = 6;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;

            // ════════════════════════════════════════════════
            // pnlUserInfo  (right side below toolbar)
            // ════════════════════════════════════════════════
            this.pnlUserInfo.BackColor = System.Drawing.Color.White;
            this.pnlUserInfo.Controls.Add(this.lblNguoiDungHienTai);
            this.pnlUserInfo.Controls.Add(this.lblPhienDangNhap);
            this.pnlUserInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUserInfo.Location = new System.Drawing.Point(0, 76);
            this.pnlUserInfo.Name = "pnlUserInfo";
            this.pnlUserInfo.Padding = new System.Windows.Forms.Padding(16, 4, 16, 4);
            this.pnlUserInfo.Size = new System.Drawing.Size(1050, 32);
            this.pnlUserInfo.TabIndex = 2;

            // lblNguoiDungHienTai
            this.lblNguoiDungHienTai.AutoSize = true;
            this.lblNguoiDungHienTai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNguoiDungHienTai.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblNguoiDungHienTai.Location = new System.Drawing.Point(16, 8);
            this.lblNguoiDungHienTai.Name = "lblNguoiDungHienTai";
            this.lblNguoiDungHienTai.Size = new System.Drawing.Size(180, 20);
            this.lblNguoiDungHienTai.TabIndex = 0;
            this.lblNguoiDungHienTai.Text = "Người dùng: ";

            // lblPhienDangNhap
            this.lblPhienDangNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhienDangNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPhienDangNhap.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblPhienDangNhap.Location = new System.Drawing.Point(750, 8);
            this.lblPhienDangNhap.Name = "lblPhienDangNhap";
            this.lblPhienDangNhap.Size = new System.Drawing.Size(280, 20);
            this.lblPhienDangNhap.TabIndex = 1;
            this.lblPhienDangNhap.Text = "Phiên đăng nhập: ";
            this.lblPhienDangNhap.TextAlign = System.Drawing.ContentAlignment.TopRight;

            // ════════════════════════════════════════════════
            // pnlMain  (scrollable main content area)
            // ════════════════════════════════════════════════
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(245, 246, 248);
            this.pnlMain.Controls.Add(this.lblCauHinhUngDung);
            this.pnlMain.Controls.Add(this.pnlCauHinh);
            this.pnlMain.Controls.Add(this.pnlBottomButtons);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 108);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(28, 16, 28, 16);
            this.pnlMain.Size = new System.Drawing.Size(1050, 486);
            this.pnlMain.TabIndex = 3;

            // lblCauHinhUngDung
            this.lblCauHinhUngDung.AutoSize = true;
            this.lblCauHinhUngDung.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCauHinhUngDung.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblCauHinhUngDung.Location = new System.Drawing.Point(30, 18);
            this.lblCauHinhUngDung.Name = "lblCauHinhUngDung";
            this.lblCauHinhUngDung.Size = new System.Drawing.Size(260, 37);
            this.lblCauHinhUngDung.TabIndex = 0;
            this.lblCauHinhUngDung.Text = "Cấu hình ứng dụng";

            // ════════════════════════════════════════════════
            // pnlCauHinh  (main settings panel)
            // ════════════════════════════════════════════════
            this.pnlCauHinh.BackColor = System.Drawing.Color.White;
            this.pnlCauHinh.Controls.Add(this.pnlSaoLuu);
            this.pnlCauHinh.Controls.Add(this.pnlNganSach);
            this.pnlCauHinh.Location = new System.Drawing.Point(30, 64);
            this.pnlCauHinh.Name = "pnlCauHinh";
            this.pnlCauHinh.Padding = new System.Windows.Forms.Padding(0);
            this.pnlCauHinh.Size = new System.Drawing.Size(980, 330);
            this.pnlCauHinh.TabIndex = 1;

            // ─── Section 1: pnlSaoLuu ───
            this.pnlSaoLuu.BackColor = System.Drawing.Color.White;
            this.pnlSaoLuu.Controls.Add(this.lblSaoLuuDuLieu);
            this.pnlSaoLuu.Controls.Add(this.pnlThuMucMacDinh);
            this.pnlSaoLuu.Controls.Add(this.chkTuDongSaoLuuKhiThoat);
            this.pnlSaoLuu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSaoLuu.Location = new System.Drawing.Point(0, 0);
            this.pnlSaoLuu.Name = "pnlSaoLuu";
            this.pnlSaoLuu.Padding = new System.Windows.Forms.Padding(24, 20, 24, 12);
            this.pnlSaoLuu.Size = new System.Drawing.Size(980, 175);
            this.pnlSaoLuu.TabIndex = 0;

            // lblSaoLuuDuLieu
            this.lblSaoLuuDuLieu.AutoSize = true;
            this.lblSaoLuuDuLieu.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblSaoLuuDuLieu.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblSaoLuuDuLieu.Location = new System.Drawing.Point(24, 20);
            this.lblSaoLuuDuLieu.Name = "lblSaoLuuDuLieu";
            this.lblSaoLuuDuLieu.Size = new System.Drawing.Size(140, 25);
            this.lblSaoLuuDuLieu.TabIndex = 0;
            this.lblSaoLuuDuLieu.Text = "Sao lưu dữ liệu";

            // pnlThuMucMacDinh
            this.pnlThuMucMacDinh.Controls.Add(this.lblThuMucMacDinh);
            this.pnlThuMucMacDinh.Controls.Add(this.txtThuMucSaoLuuMacDinh);
            this.pnlThuMucMacDinh.Controls.Add(this.pnlChonThuMuc);
            this.pnlThuMucMacDinh.Controls.Add(this.lblGoiYThuMuc);
            this.pnlThuMucMacDinh.Location = new System.Drawing.Point(24, 52);
            this.pnlThuMucMacDinh.Name = "pnlThuMucMacDinh";
            this.pnlThuMucMacDinh.Size = new System.Drawing.Size(920, 78);
            this.pnlThuMucMacDinh.TabIndex = 1;

            // lblThuMucMacDinh
            this.lblThuMucMacDinh.AutoSize = true;
            this.lblThuMucMacDinh.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblThuMucMacDinh.ForeColor = System.Drawing.Color.FromArgb(66, 66, 66);
            this.lblThuMucMacDinh.Location = new System.Drawing.Point(0, 5);
            this.lblThuMucMacDinh.Name = "lblThuMucMacDinh";
            this.lblThuMucMacDinh.Size = new System.Drawing.Size(210, 22);
            this.lblThuMucMacDinh.TabIndex = 0;
            this.lblThuMucMacDinh.Text = "Thư mục sao lưu mặc định";

            // txtThuMucSaoLuuMacDinh
            this.txtThuMucSaoLuuMacDinh.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            this.txtThuMucSaoLuuMacDinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThuMucSaoLuuMacDinh.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtThuMucSaoLuuMacDinh.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.txtThuMucSaoLuuMacDinh.Location = new System.Drawing.Point(0, 30);
            this.txtThuMucSaoLuuMacDinh.Name = "txtThuMucSaoLuuMacDinh";
            this.txtThuMucSaoLuuMacDinh.Size = new System.Drawing.Size(540, 29);
            this.txtThuMucSaoLuuMacDinh.TabIndex = 1;
            this.txtThuMucSaoLuuMacDinh.Text = "D:\\QuanLyChiTieu\\SaoLuu";

            // pnlChonThuMuc
            this.pnlChonThuMuc.Controls.Add(this.btnDuyetThuMuc);
            this.pnlChonThuMuc.Location = new System.Drawing.Point(548, 28);
            this.pnlChonThuMuc.Name = "pnlChonThuMuc";
            this.pnlChonThuMuc.Size = new System.Drawing.Size(100, 34);
            this.pnlChonThuMuc.TabIndex = 2;

            // btnDuyetThuMuc
            this.btnDuyetThuMuc.BackColor = System.Drawing.Color.White;
            this.btnDuyetThuMuc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.btnDuyetThuMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuyetThuMuc.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnDuyetThuMuc.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.btnDuyetThuMuc.Location = new System.Drawing.Point(0, 1);
            this.btnDuyetThuMuc.Name = "btnDuyetThuMuc";
            this.btnDuyetThuMuc.Size = new System.Drawing.Size(90, 30);
            this.btnDuyetThuMuc.TabIndex = 0;
            this.btnDuyetThuMuc.Text = "Duyệt...";
            this.btnDuyetThuMuc.UseVisualStyleBackColor = false;

            // lblGoiYThuMuc
            this.lblGoiYThuMuc.AutoSize = true;
            this.lblGoiYThuMuc.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblGoiYThuMuc.ForeColor = System.Drawing.Color.FromArgb(130, 130, 130);
            this.lblGoiYThuMuc.Location = new System.Drawing.Point(0, 62);
            this.lblGoiYThuMuc.Name = "lblGoiYThuMuc";
            this.lblGoiYThuMuc.Size = new System.Drawing.Size(430, 19);
            this.lblGoiYThuMuc.TabIndex = 3;
            this.lblGoiYThuMuc.Text = "Các bản sao lưu thủ công và tự động sẽ được lưu vào thư mục này.";

            // chkTuDongSaoLuuKhiThoat
            this.chkTuDongSaoLuuKhiThoat.AutoSize = true;
            this.chkTuDongSaoLuuKhiThoat.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chkTuDongSaoLuuKhiThoat.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.chkTuDongSaoLuuKhiThoat.Location = new System.Drawing.Point(24, 140);
            this.chkTuDongSaoLuuKhiThoat.Name = "chkTuDongSaoLuuKhiThoat";
            this.chkTuDongSaoLuuKhiThoat.Size = new System.Drawing.Size(250, 25);
            this.chkTuDongSaoLuuKhiThoat.TabIndex = 2;
            this.chkTuDongSaoLuuKhiThoat.Text = "Tự động sao lưu khi thoát";
            this.chkTuDongSaoLuuKhiThoat.UseVisualStyleBackColor = true;

            // ─── Separator line ───
            var lblSeparator = new System.Windows.Forms.Label();
            lblSeparator.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            lblSeparator.Location = new System.Drawing.Point(24, 175);
            lblSeparator.Name = "lblSeparator";
            lblSeparator.Size = new System.Drawing.Size(932, 1);
            this.pnlCauHinh.Controls.Add(lblSeparator);

            // ─── Section 2: pnlNganSach ───
            this.pnlNganSach.BackColor = System.Drawing.Color.White;
            this.pnlNganSach.Controls.Add(this.lblCanhBaoNganSach);
            this.pnlNganSach.Controls.Add(this.pnlNguongCanhBao);
            this.pnlNganSach.Controls.Add(this.lblGiaiThichNguong);
            this.pnlNganSach.Location = new System.Drawing.Point(0, 180);
            this.pnlNganSach.Name = "pnlNganSach";
            this.pnlNganSach.Padding = new System.Windows.Forms.Padding(24, 16, 24, 16);
            this.pnlNganSach.Size = new System.Drawing.Size(980, 145);
            this.pnlNganSach.TabIndex = 1;

            // lblCanhBaoNganSach
            this.lblCanhBaoNganSach.AutoSize = true;
            this.lblCanhBaoNganSach.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblCanhBaoNganSach.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblCanhBaoNganSach.Location = new System.Drawing.Point(24, 16);
            this.lblCanhBaoNganSach.Name = "lblCanhBaoNganSach";
            this.lblCanhBaoNganSach.Size = new System.Drawing.Size(185, 25);
            this.lblCanhBaoNganSach.TabIndex = 0;
            this.lblCanhBaoNganSach.Text = "Cảnh báo ngân sách";

            // pnlNguongCanhBao
            this.pnlNguongCanhBao.Controls.Add(this.lblNguongCanhBao);
            this.pnlNguongCanhBao.Controls.Add(this.txtNguongCanhBao);
            this.pnlNguongCanhBao.Controls.Add(this.lblPercent);
            this.pnlNguongCanhBao.Controls.Add(this.btnTang);
            this.pnlNguongCanhBao.Controls.Add(this.btnGiam);
            this.pnlNguongCanhBao.Controls.Add(this.lblNguongCanhBao2);
            this.pnlNguongCanhBao.Location = new System.Drawing.Point(24, 50);
            this.pnlNguongCanhBao.Name = "pnlNguongCanhBao";
            this.pnlNguongCanhBao.Size = new System.Drawing.Size(920, 40);
            this.pnlNguongCanhBao.TabIndex = 1;

            // lblNguongCanhBao
            this.lblNguongCanhBao.AutoSize = true;
            this.lblNguongCanhBao.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblNguongCanhBao.ForeColor = System.Drawing.Color.FromArgb(66, 66, 66);
            this.lblNguongCanhBao.Location = new System.Drawing.Point(0, 8);
            this.lblNguongCanhBao.Name = "lblNguongCanhBao";
            this.lblNguongCanhBao.Size = new System.Drawing.Size(210, 22);
            this.lblNguongCanhBao.TabIndex = 0;
            this.lblNguongCanhBao.Text = "Ngưỡng cảnh báo ngân sách";

            // txtNguongCanhBao
            this.txtNguongCanhBao.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            this.txtNguongCanhBao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNguongCanhBao.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtNguongCanhBao.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.txtNguongCanhBao.Location = new System.Drawing.Point(230, 4);
            this.txtNguongCanhBao.Name = "txtNguongCanhBao";
            this.txtNguongCanhBao.Size = new System.Drawing.Size(60, 31);
            this.txtNguongCanhBao.TabIndex = 1;
            this.txtNguongCanhBao.Text = "80";
            this.txtNguongCanhBao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            // lblPercent
            this.lblPercent.AutoSize = true;
            this.lblPercent.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblPercent.ForeColor = System.Drawing.Color.FromArgb(66, 66, 66);
            this.lblPercent.Location = new System.Drawing.Point(293, 8);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(23, 23);
            this.lblPercent.TabIndex = 2;
            this.lblPercent.Text = "%";

            // btnTang
            this.btnTang.BackColor = System.Drawing.Color.White;
            this.btnTang.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.btnTang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTang.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.btnTang.Location = new System.Drawing.Point(324, 4);
            this.btnTang.Name = "btnTang";
            this.btnTang.Size = new System.Drawing.Size(32, 31);
            this.btnTang.TabIndex = 3;
            this.btnTang.Text = "▲";
            this.btnTang.UseVisualStyleBackColor = false;

            // btnGiam
            this.btnGiam.BackColor = System.Drawing.Color.White;
            this.btnGiam.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.btnGiam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGiam.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.btnGiam.Location = new System.Drawing.Point(360, 4);
            this.btnGiam.Name = "btnGiam";
            this.btnGiam.Size = new System.Drawing.Size(32, 31);
            this.btnGiam.TabIndex = 4;
            this.btnGiam.Text = "▼";
            this.btnGiam.UseVisualStyleBackColor = false;

            // lblNguongCanhBao2
            this.lblNguongCanhBao2.AutoSize = true;
            this.lblNguongCanhBao2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblNguongCanhBao2.ForeColor = System.Drawing.Color.FromArgb(130, 130, 130);
            this.lblNguongCanhBao2.Location = new System.Drawing.Point(406, 10);
            this.lblNguongCanhBao2.Name = "lblNguongCanhBao2";
            this.lblNguongCanhBao2.Size = new System.Drawing.Size(110, 20);
            this.lblNguongCanhBao2.TabIndex = 5;
            this.lblNguongCanhBao2.Text = "Mặc định: 80%";

            // lblGiaiThichNguong
            this.lblGiaiThichNguong.AutoSize = true;
            this.lblGiaiThichNguong.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblGiaiThichNguong.ForeColor = System.Drawing.Color.FromArgb(130, 130, 130);
            this.lblGiaiThichNguong.Location = new System.Drawing.Point(24, 100);
            this.lblGiaiThichNguong.Name = "lblGiaiThichNguong";
            this.lblGiaiThichNguong.Size = new System.Drawing.Size(500, 19);
            this.lblGiaiThichNguong.TabIndex = 2;
            this.lblGiaiThichNguong.Text = "Hiển thị cảnh báo khi chi tiêu đạt từ 80% hạn mức ngân sách trở lên.";

            // ════════════════════════════════════════════════
            // pnlBottomButtons
            // ════════════════════════════════════════════════
            this.pnlBottomButtons.BackColor = System.Drawing.Color.FromArgb(245, 246, 248);
            this.pnlBottomButtons.Controls.Add(this.btnLuuThayDoi);
            this.pnlBottomButtons.Controls.Add(this.btnHuy);
            this.pnlBottomButtons.Location = new System.Drawing.Point(30, 406);
            this.pnlBottomButtons.Name = "pnlBottomButtons";
            this.pnlBottomButtons.Size = new System.Drawing.Size(980, 56);
            this.pnlBottomButtons.TabIndex = 2;

            // btnLuuThayDoi
            this.btnLuuThayDoi.BackColor = System.Drawing.Color.FromArgb(21, 101, 192);
            this.btnLuuThayDoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuThayDoi.FlatAppearance.BorderSize = 0;
            this.btnLuuThayDoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuThayDoi.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnLuuThayDoi.ForeColor = System.Drawing.Color.White;
            this.btnLuuThayDoi.Location = new System.Drawing.Point(360, 8);
            this.btnLuuThayDoi.Name = "btnLuuThayDoi";
            this.btnLuuThayDoi.Size = new System.Drawing.Size(150, 40);
            this.btnLuuThayDoi.TabIndex = 0;
            this.btnLuuThayDoi.Text = "Lưu thay đổi";
            this.btnLuuThayDoi.UseVisualStyleBackColor = false;

            // btnHuy
            this.btnHuy.BackColor = System.Drawing.Color.White;
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.btnHuy.Location = new System.Drawing.Point(520, 8);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 40);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;

            // ════════════════════════════════════════════════
            // stsTrangThai
            // ════════════════════════════════════════════════
            this.stsTrangThai.BackColor = System.Drawing.Color.FromArgb(245, 246, 248);
            this.stsTrangThai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.stsTrangThai.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.tslDangNhap, this.tslSpring, this.tslHomNay });
            this.stsTrangThai.Location = new System.Drawing.Point(0, 594);
            this.stsTrangThai.Name = "stsTrangThai";
            this.stsTrangThai.Size = new System.Drawing.Size(1050, 26);
            this.stsTrangThai.TabIndex = 4;

            this.tslDangNhap.Name = "tslDangNhap";
            this.tslDangNhap.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.tslDangNhap.Text = "Đăng nhập: Nguyễn Minh Anh";

            this.tslSpring.Name = "tslSpring";
            this.tslSpring.Spring = true;
            this.tslSpring.Text = "";

            this.tslHomNay.Name = "tslHomNay";
            this.tslHomNay.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.tslHomNay.Text = "Hôm nay: " + System.DateTime.Now.ToString("dd/MM/yyyy");

            // ════════════════════════════════════════════════
            // frmCauHinh
            // ════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1050, 620);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlUserInfo);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.mnuChinh);
            this.Controls.Add(this.stsTrangThai);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.MainMenuStrip = this.mnuChinh;
            this.Name = "frmCauHinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Chi Tiêu — Cấu hình";

            this.pnlToolbar.ResumeLayout(false);
            this.pnlUserInfo.ResumeLayout(false);
            this.pnlUserInfo.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlCauHinh.ResumeLayout(false);
            this.pnlThuMucMacDinh.ResumeLayout(false);
            this.pnlThuMucMacDinh.PerformLayout();
            this.pnlChonThuMuc.ResumeLayout(false);
            this.pnlSaoLuu.ResumeLayout(false);
            this.pnlSaoLuu.PerformLayout();
            this.pnlNganSach.ResumeLayout(false);
            this.pnlNganSach.PerformLayout();
            this.pnlNguongCanhBao.ResumeLayout(false);
            this.pnlNguongCanhBao.PerformLayout();
            this.pnlBottomButtons.ResumeLayout(false);
            this.stsTrangThai.ResumeLayout(false);
            this.stsTrangThai.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Menu
        private System.Windows.Forms.MenuStrip mnuChinh;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnuNghiepVu;
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
        private System.Windows.Forms.DateTimePicker dtpThang;
        private System.Windows.Forms.Button btnLamMoi;

        // User info
        private System.Windows.Forms.Panel pnlUserInfo;
        private System.Windows.Forms.Label lblNguoiDungHienTai;
        private System.Windows.Forms.Label lblPhienDangNhap;

        // Main content
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblCauHinhUngDung;
        private System.Windows.Forms.Panel pnlCauHinh;

        // Section 1 - Sao luu
        private System.Windows.Forms.Label lblSaoLuuDuLieu;
        private System.Windows.Forms.Panel pnlThuMucMacDinh;
        private System.Windows.Forms.Label lblThuMucMacDinh;
        private System.Windows.Forms.TextBox txtThuMucSaoLuuMacDinh;
        private System.Windows.Forms.Panel pnlChonThuMuc;
        private System.Windows.Forms.Button btnDuyetThuMuc;
        private System.Windows.Forms.Label lblGoiYThuMuc;
        private System.Windows.Forms.CheckBox chkTuDongSaoLuuKhiThoat;
        private System.Windows.Forms.Panel pnlSaoLuu;

        // Section 2 - Ngan sach
        private System.Windows.Forms.Panel pnlNganSach;
        private System.Windows.Forms.Label lblCanhBaoNganSach;
        private System.Windows.Forms.Panel pnlNguongCanhBao;
        private System.Windows.Forms.Label lblNguongCanhBao;
        private System.Windows.Forms.TextBox txtNguongCanhBao;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Button btnTang;
        private System.Windows.Forms.Button btnGiam;
        private System.Windows.Forms.Label lblNguongCanhBao2;
        private System.Windows.Forms.Label lblGiaiThichNguong;

        // Bottom buttons
        private System.Windows.Forms.Panel pnlBottomButtons;
        private System.Windows.Forms.Button btnLuuThayDoi;
        private System.Windows.Forms.Button btnHuy;

        // Status strip
        private System.Windows.Forms.StatusStrip stsTrangThai;
        private System.Windows.Forms.ToolStripStatusLabel tslDangNhap;
        private System.Windows.Forms.ToolStripStatusLabel tslSpring;
        private System.Windows.Forms.ToolStripStatusLabel tslHomNay;
    }
}
