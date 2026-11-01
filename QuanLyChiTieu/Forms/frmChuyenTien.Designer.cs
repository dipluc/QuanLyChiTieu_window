namespace QuanLyChiTieu.Forms
{
    partial class frmChuyenTien
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
            this.components = new System.ComponentModel.Container();

            // === Menu Strip ===
            this.mnuChinh = new MenuStrip();
            this.mnuHeThong = new ToolStripMenuItem();
            this.mnuDanhMuc = new ToolStripMenuItem();
            this.mnuNghiepVu = new ToolStripMenuItem();
            this.mnuBaoCao = new ToolStripMenuItem();
            this.mnuQuanTri = new ToolStripMenuItem();
            this.mnuTroGiup = new ToolStripMenuItem();

            // === Toolbar ===
            this.pnlToolbar = new Panel();
            this.btnThuNhap = new Button();
            this.btnChiTieu = new Button();
            this.btnNganSach = new Button();
            this.btnBaoCao = new Button();
            this.btnTimKiem = new Button();
            this.dtpThang = new DateTimePicker();
            this.btnLamMoi = new Button();

            // === Main content ===
            this.pnlMain = new Panel();

            // Left/Top section
            this.lblChuyenTienGiuaCacVi = new Label();
            this.lblThongTinChuyenTien = new Label();

            this.pnlChuyenTien = new Panel();
            this.lblViNguon = new Label();
            this.cboViNguon = new ComboBox();
            this.lblViDich = new Label();
            this.cboViDich = new ComboBox();
            this.lblNgay = new Label();
            this.dtpNgay = new DateTimePicker();
            this.lblSoTien = new Label();
            this.txtSoTien = new TextBox();
            this.lblGhiChu = new Label();
            this.txtGhiChu = new TextBox();
            this.btnChuyenTien = new Button();
            this.btnMoi = new Button();

            this.pnlChuyenTien2 = new Panel();
            this.lblSauKhiChuyenDuKienVietcombank = new Label();
            this.lblChuyenNoiBoKhongTinhVao = new Label();

            // Bottom section
            this.lblLichSuChuyenTien = new Label();
            this.dgvLichSuChuyenTien = new DataGridView();
            this.lblSoGiaoDich = new Label();

            // Status strip
            this.stsTrangThai = new StatusStrip();
            this.tslTrangThai = new ToolStripStatusLabel();

            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuChuyenTien)).BeginInit();
            this.SuspendLayout();

            // =============================================
            // mnuChinh
            // =============================================
            this.mnuChinh.Items.AddRange(new ToolStripItem[] {
                this.mnuHeThong, this.mnuDanhMuc, this.mnuNghiepVu,
                this.mnuBaoCao, this.mnuQuanTri, this.mnuTroGiup
            });
            this.mnuChinh.Location = new System.Drawing.Point(0, 0);
            this.mnuChinh.Name = "mnuChinh";
            this.mnuChinh.Size = new System.Drawing.Size(1050, 24);
            this.mnuChinh.TabIndex = 0;
            this.mnuChinh.BackColor = System.Drawing.Color.White;

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

            // =============================================
            // pnlToolbar
            // =============================================
            this.pnlToolbar.BackColor = System.Drawing.Color.White;
            this.pnlToolbar.BorderStyle = BorderStyle.FixedSingle;
            this.pnlToolbar.Dock = DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 24);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1050, 48);
            this.pnlToolbar.TabIndex = 1;
            this.pnlToolbar.Controls.Add(this.btnThuNhap);
            this.pnlToolbar.Controls.Add(this.btnChiTieu);
            this.pnlToolbar.Controls.Add(this.btnNganSach);
            this.pnlToolbar.Controls.Add(this.btnBaoCao);
            this.pnlToolbar.Controls.Add(this.btnTimKiem);
            this.pnlToolbar.Controls.Add(this.dtpThang);
            this.pnlToolbar.Controls.Add(this.btnLamMoi);

            // btnThuNhap
            this.btnThuNhap.FlatStyle = FlatStyle.Flat;
            this.btnThuNhap.FlatAppearance.BorderSize = 1;
            this.btnThuNhap.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnThuNhap.BackColor = System.Drawing.Color.White;
            this.btnThuNhap.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.btnThuNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThuNhap.Location = new System.Drawing.Point(8, 8);
            this.btnThuNhap.Name = "btnThuNhap";
            this.btnThuNhap.Size = new System.Drawing.Size(100, 32);
            this.btnThuNhap.Text = "+ Thu nhập";
            this.btnThuNhap.TabIndex = 0;
            this.btnThuNhap.Cursor = Cursors.Hand;

            // btnChiTieu
            this.btnChiTieu.FlatStyle = FlatStyle.Flat;
            this.btnChiTieu.FlatAppearance.BorderSize = 1;
            this.btnChiTieu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnChiTieu.BackColor = System.Drawing.Color.White;
            this.btnChiTieu.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.btnChiTieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnChiTieu.Location = new System.Drawing.Point(114, 8);
            this.btnChiTieu.Name = "btnChiTieu";
            this.btnChiTieu.Size = new System.Drawing.Size(100, 32);
            this.btnChiTieu.Text = "— Chi tiêu";
            this.btnChiTieu.TabIndex = 1;
            this.btnChiTieu.Cursor = Cursors.Hand;

            // btnNganSach
            this.btnNganSach.FlatStyle = FlatStyle.Flat;
            this.btnNganSach.FlatAppearance.BorderSize = 1;
            this.btnNganSach.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnNganSach.BackColor = System.Drawing.Color.White;
            this.btnNganSach.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.btnNganSach.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNganSach.Location = new System.Drawing.Point(220, 8);
            this.btnNganSach.Name = "btnNganSach";
            this.btnNganSach.Size = new System.Drawing.Size(100, 32);
            this.btnNganSach.Text = "Ngân sách";
            this.btnNganSach.TabIndex = 2;
            this.btnNganSach.Cursor = Cursors.Hand;

            // btnBaoCao
            this.btnBaoCao.FlatStyle = FlatStyle.Flat;
            this.btnBaoCao.FlatAppearance.BorderSize = 1;
            this.btnBaoCao.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnBaoCao.BackColor = System.Drawing.Color.White;
            this.btnBaoCao.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.btnBaoCao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBaoCao.Location = new System.Drawing.Point(326, 8);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(100, 32);
            this.btnBaoCao.Text = "Báo cáo";
            this.btnBaoCao.TabIndex = 3;
            this.btnBaoCao.Cursor = Cursors.Hand;

            // btnTimKiem
            this.btnTimKiem.FlatStyle = FlatStyle.Flat;
            this.btnTimKiem.FlatAppearance.BorderSize = 1;
            this.btnTimKiem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnTimKiem.BackColor = System.Drawing.Color.White;
            this.btnTimKiem.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTimKiem.Location = new System.Drawing.Point(432, 8);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 32);
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.TabIndex = 4;
            this.btnTimKiem.Cursor = Cursors.Hand;

            // dtpThang
            this.dtpThang.Format = DateTimePickerFormat.Custom;
            this.dtpThang.CustomFormat = "MM/yyyy";
            this.dtpThang.ShowUpDown = true;
            this.dtpThang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpThang.Location = new System.Drawing.Point(790, 12);
            this.dtpThang.Name = "dtpThang";
            this.dtpThang.Size = new System.Drawing.Size(120, 23);
            this.dtpThang.TabIndex = 5;

            // btnLamMoi
            this.btnLamMoi.FlatStyle = FlatStyle.Flat;
            this.btnLamMoi.FlatAppearance.BorderSize = 1;
            this.btnLamMoi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnLamMoi.BackColor = System.Drawing.Color.White;
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLamMoi.Location = new System.Drawing.Point(920, 8);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 32);
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.TabIndex = 6;
            this.btnLamMoi.Cursor = Cursors.Hand;

            // =============================================
            // pnlMain
            // =============================================
            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 72);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new Padding(20, 10, 20, 10);
            this.pnlMain.TabIndex = 2;

            // =============================================
            // lblChuyenTienGiuaCacVi
            // =============================================
            this.lblChuyenTienGiuaCacVi.AutoSize = true;
            this.lblChuyenTienGiuaCacVi.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblChuyenTienGiuaCacVi.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblChuyenTienGiuaCacVi.Location = new System.Drawing.Point(24, 14);
            this.lblChuyenTienGiuaCacVi.Name = "lblChuyenTienGiuaCacVi";
            this.lblChuyenTienGiuaCacVi.Size = new System.Drawing.Size(320, 30);
            this.lblChuyenTienGiuaCacVi.Text = "Chuyển tiền giữa các ví";

            // =============================================
            // lblThongTinChuyenTien
            // =============================================
            this.lblThongTinChuyenTien.AutoSize = true;
            this.lblThongTinChuyenTien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblThongTinChuyenTien.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblThongTinChuyenTien.Location = new System.Drawing.Point(24, 52);
            this.lblThongTinChuyenTien.Name = "lblThongTinChuyenTien";
            this.lblThongTinChuyenTien.Size = new System.Drawing.Size(180, 20);
            this.lblThongTinChuyenTien.Text = "Thông tin chuyển tiền";

            // =============================================
            // pnlChuyenTien
            // =============================================
            this.pnlChuyenTien.BackColor = System.Drawing.Color.White;
            this.pnlChuyenTien.Location = new System.Drawing.Point(24, 78);
            this.pnlChuyenTien.Name = "pnlChuyenTien";
            this.pnlChuyenTien.Size = new System.Drawing.Size(980, 165);
            this.pnlChuyenTien.TabIndex = 3;
            this.pnlChuyenTien.BorderStyle = BorderStyle.FixedSingle;
            this.pnlChuyenTien.Padding = new Padding(16, 12, 16, 12);

            // lblViNguon
            this.lblViNguon.AutoSize = true;
            this.lblViNguon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblViNguon.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblViNguon.Location = new System.Drawing.Point(16, 16);
            this.lblViNguon.Name = "lblViNguon";
            this.lblViNguon.Text = "Ví nguồn";

            // cboViNguon
            this.cboViNguon.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboViNguon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboViNguon.Location = new System.Drawing.Point(16, 36);
            this.cboViNguon.Name = "cboViNguon";
            this.cboViNguon.Size = new System.Drawing.Size(220, 25);
            this.cboViNguon.TabIndex = 0;

            // lblViDich
            this.lblViDich.AutoSize = true;
            this.lblViDich.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblViDich.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblViDich.Location = new System.Drawing.Point(252, 16);
            this.lblViDich.Name = "lblViDich";
            this.lblViDich.Text = "Ví đích";

            // cboViDich
            this.cboViDich.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboViDich.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboViDich.Location = new System.Drawing.Point(252, 36);
            this.cboViDich.Name = "cboViDich";
            this.cboViDich.Size = new System.Drawing.Size(220, 25);
            this.cboViDich.TabIndex = 1;

            // lblNgay
            this.lblNgay.AutoSize = true;
            this.lblNgay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNgay.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblNgay.Location = new System.Drawing.Point(488, 16);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Text = "Ngày chuyển";

            // dtpNgay
            this.dtpNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpNgay.Format = DateTimePickerFormat.Short;
            this.dtpNgay.Location = new System.Drawing.Point(488, 36);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(150, 25);
            this.dtpNgay.TabIndex = 2;

            // lblSoTien
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSoTien.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblSoTien.Location = new System.Drawing.Point(654, 16);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Text = "Số tiền (đ)";

            // txtSoTien
            this.txtSoTien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSoTien.Location = new System.Drawing.Point(654, 36);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(150, 25);
            this.txtSoTien.TabIndex = 3;
            this.txtSoTien.TextAlign = HorizontalAlignment.Right;

            // lblGhiChu
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGhiChu.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblGhiChu.Location = new System.Drawing.Point(16, 72);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Text = "Ghi chú";

            // txtGhiChu
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtGhiChu.Location = new System.Drawing.Point(16, 92);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(622, 25);
            this.txtGhiChu.TabIndex = 4;

            // btnChuyenTien
            this.btnChuyenTien.BackColor = System.Drawing.Color.FromArgb(21, 101, 192);
            this.btnChuyenTien.FlatStyle = FlatStyle.Flat;
            this.btnChuyenTien.FlatAppearance.BorderSize = 0;
            this.btnChuyenTien.ForeColor = System.Drawing.Color.White;
            this.btnChuyenTien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnChuyenTien.Location = new System.Drawing.Point(654, 88);
            this.btnChuyenTien.Name = "btnChuyenTien";
            this.btnChuyenTien.Size = new System.Drawing.Size(120, 32);
            this.btnChuyenTien.TabIndex = 5;
            this.btnChuyenTien.Text = "Chuyển tiền";
            this.btnChuyenTien.Cursor = Cursors.Hand;
            this.btnChuyenTien.UseVisualStyleBackColor = false;

            // btnMoi
            this.btnMoi.FlatStyle = FlatStyle.Flat;
            this.btnMoi.FlatAppearance.BorderSize = 1;
            this.btnMoi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnMoi.BackColor = System.Drawing.Color.White;
            this.btnMoi.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.btnMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnMoi.Location = new System.Drawing.Point(784, 88);
            this.btnMoi.Name = "btnMoi";
            this.btnMoi.Size = new System.Drawing.Size(80, 32);
            this.btnMoi.TabIndex = 6;
            this.btnMoi.Text = "Mới";
            this.btnMoi.Cursor = Cursors.Hand;

            this.pnlChuyenTien.Controls.Add(this.lblViNguon);
            this.pnlChuyenTien.Controls.Add(this.cboViNguon);
            this.pnlChuyenTien.Controls.Add(this.lblViDich);
            this.pnlChuyenTien.Controls.Add(this.cboViDich);
            this.pnlChuyenTien.Controls.Add(this.lblNgay);
            this.pnlChuyenTien.Controls.Add(this.dtpNgay);
            this.pnlChuyenTien.Controls.Add(this.lblSoTien);
            this.pnlChuyenTien.Controls.Add(this.txtSoTien);
            this.pnlChuyenTien.Controls.Add(this.lblGhiChu);
            this.pnlChuyenTien.Controls.Add(this.txtGhiChu);
            this.pnlChuyenTien.Controls.Add(this.btnChuyenTien);
            this.pnlChuyenTien.Controls.Add(this.btnMoi);

            // =============================================
            // pnlChuyenTien2
            // =============================================
            this.pnlChuyenTien2.BackColor = System.Drawing.Color.FromArgb(232, 245, 253);
            this.pnlChuyenTien2.Location = new System.Drawing.Point(24, 248);
            this.pnlChuyenTien2.Name = "pnlChuyenTien2";
            this.pnlChuyenTien2.Size = new System.Drawing.Size(980, 50);
            this.pnlChuyenTien2.TabIndex = 4;
            this.pnlChuyenTien2.BorderStyle = BorderStyle.FixedSingle;
            this.pnlChuyenTien2.Padding = new Padding(12, 6, 12, 6);

            // lblSauKhiChuyenDuKienVietcombank
            this.lblSauKhiChuyenDuKienVietcombank.AutoSize = true;
            this.lblSauKhiChuyenDuKienVietcombank.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSauKhiChuyenDuKienVietcombank.ForeColor = System.Drawing.Color.FromArgb(21, 101, 192);
            this.lblSauKhiChuyenDuKienVietcombank.Location = new System.Drawing.Point(12, 6);
            this.lblSauKhiChuyenDuKienVietcombank.Name = "lblSauKhiChuyenDuKienVietcombank";
            this.lblSauKhiChuyenDuKienVietcombank.Text = "Sau khi chuyển dự kiến: —";

            // lblChuyenNoiBoKhongTinhVao
            this.lblChuyenNoiBoKhongTinhVao.AutoSize = true;
            this.lblChuyenNoiBoKhongTinhVao.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblChuyenNoiBoKhongTinhVao.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblChuyenNoiBoKhongTinhVao.Location = new System.Drawing.Point(12, 26);
            this.lblChuyenNoiBoKhongTinhVao.Name = "lblChuyenNoiBoKhongTinhVao";
            this.lblChuyenNoiBoKhongTinhVao.Text = "Chuyển nội bộ không tính vào thu – chi.";

            this.pnlChuyenTien2.Controls.Add(this.lblSauKhiChuyenDuKienVietcombank);
            this.pnlChuyenTien2.Controls.Add(this.lblChuyenNoiBoKhongTinhVao);

            // =============================================
            // lblLichSuChuyenTien
            // =============================================
            this.lblLichSuChuyenTien.AutoSize = true;
            this.lblLichSuChuyenTien.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLichSuChuyenTien.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblLichSuChuyenTien.Location = new System.Drawing.Point(24, 310);
            this.lblLichSuChuyenTien.Name = "lblLichSuChuyenTien";
            this.lblLichSuChuyenTien.Text = "Lịch sử chuyển tiền";

            // =============================================
            // dgvLichSuChuyenTien
            // =============================================
            this.dgvLichSuChuyenTien.AllowUserToAddRows = false;
            this.dgvLichSuChuyenTien.AllowUserToDeleteRows = false;
            this.dgvLichSuChuyenTien.ReadOnly = true;
            this.dgvLichSuChuyenTien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSuChuyenTien.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichSuChuyenTien.BorderStyle = BorderStyle.FixedSingle;
            this.dgvLichSuChuyenTien.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLichSuChuyenTien.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvLichSuChuyenTien.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(21, 101, 192),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold),
                SelectionBackColor = System.Drawing.Color.FromArgb(21, 101, 192),
                SelectionForeColor = System.Drawing.Color.White,
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Padding = new Padding(4)
            };
            this.dgvLichSuChuyenTien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLichSuChuyenTien.ColumnHeadersHeight = 36;
            this.dgvLichSuChuyenTien.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new System.Drawing.Font("Segoe UI", 9.5F),
                SelectionBackColor = System.Drawing.Color.FromArgb(232, 245, 253),
                SelectionForeColor = System.Drawing.Color.Black,
                Padding = new Padding(4)
            };
            this.dgvLichSuChuyenTien.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(248, 248, 248),
                SelectionBackColor = System.Drawing.Color.FromArgb(232, 245, 253),
                SelectionForeColor = System.Drawing.Color.Black
            };
            this.dgvLichSuChuyenTien.EnableHeadersVisualStyles = false;
            this.dgvLichSuChuyenTien.GridColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.dgvLichSuChuyenTien.Location = new System.Drawing.Point(24, 336);
            this.dgvLichSuChuyenTien.Name = "dgvLichSuChuyenTien";
            this.dgvLichSuChuyenTien.RowHeadersVisible = false;
            this.dgvLichSuChuyenTien.RowTemplate.Height = 32;
            this.dgvLichSuChuyenTien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichSuChuyenTien.Size = new System.Drawing.Size(980, 180);
            this.dgvLichSuChuyenTien.TabIndex = 5;

            // =============================================
            // lblSoGiaoDich
            // =============================================
            this.lblSoGiaoDich.AutoSize = true;
            this.lblSoGiaoDich.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSoGiaoDich.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblSoGiaoDich.Location = new System.Drawing.Point(24, 522);
            this.lblSoGiaoDich.Name = "lblSoGiaoDich";
            this.lblSoGiaoDich.Text = "Chỉ đọc • 0 giao dịch • Tổng số tiền đã chuyển: 0 đ";

            // =============================================
            // stsTrangThai
            // =============================================
            this.stsTrangThai.Items.AddRange(new ToolStripItem[] { this.tslTrangThai });
            this.stsTrangThai.Location = new System.Drawing.Point(0, 588);
            this.stsTrangThai.Name = "stsTrangThai";
            this.stsTrangThai.Size = new System.Drawing.Size(1050, 22);
            this.stsTrangThai.TabIndex = 3;
            this.tslTrangThai.Name = "tslTrangThai";
            this.tslTrangThai.Text = "Sẵn sàng";

            // Add to pnlMain
            this.pnlMain.Controls.Add(this.lblChuyenTienGiuaCacVi);
            this.pnlMain.Controls.Add(this.lblThongTinChuyenTien);
            this.pnlMain.Controls.Add(this.pnlChuyenTien);
            this.pnlMain.Controls.Add(this.pnlChuyenTien2);
            this.pnlMain.Controls.Add(this.lblLichSuChuyenTien);
            this.pnlMain.Controls.Add(this.dgvLichSuChuyenTien);
            this.pnlMain.Controls.Add(this.lblSoGiaoDich);

            // =============================================
            // frmChuyenTien
            // =============================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.ClientSize = new System.Drawing.Size(1050, 620);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.stsTrangThai);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.mnuChinh);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MainMenuStrip = this.mnuChinh;
            this.Name = "frmChuyenTien";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Chi Tiêu — Chuyển tiền giữa các ví";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuChuyenTien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private MenuStrip mnuChinh;
        private ToolStripMenuItem mnuHeThong;
        private ToolStripMenuItem mnuDanhMuc;
        private ToolStripMenuItem mnuNghiepVu;
        private ToolStripMenuItem mnuBaoCao;
        private ToolStripMenuItem mnuQuanTri;
        private ToolStripMenuItem mnuTroGiup;

        private Panel pnlToolbar;
        private Button btnThuNhap;
        private Button btnChiTieu;
        private Button btnNganSach;
        private Button btnBaoCao;
        private Button btnTimKiem;
        private DateTimePicker dtpThang;
        private Button btnLamMoi;

        private Panel pnlMain;
        private Label lblChuyenTienGiuaCacVi;
        private Label lblThongTinChuyenTien;

        private Panel pnlChuyenTien;
        private Label lblViNguon;
        private ComboBox cboViNguon;
        private Label lblViDich;
        private ComboBox cboViDich;
        private Label lblNgay;
        private DateTimePicker dtpNgay;
        private Label lblSoTien;
        private TextBox txtSoTien;
        private Label lblGhiChu;
        private TextBox txtGhiChu;
        private Button btnChuyenTien;
        private Button btnMoi;

        private Panel pnlChuyenTien2;
        private Label lblSauKhiChuyenDuKienVietcombank;
        private Label lblChuyenNoiBoKhongTinhVao;

        private Label lblLichSuChuyenTien;
        private DataGridView dgvLichSuChuyenTien;
        private Label lblSoGiaoDich;

        private StatusStrip stsTrangThai;
        private ToolStripStatusLabel tslTrangThai;
    }
}
