namespace QuanLyChiTieu.Forms
{
    partial class frmNganSach
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
            // ===== Menu Strip =====
            this.mnuChinh = new MenuStrip();
            this.mnuHeThong = new ToolStripMenuItem();
            this.mnuDanhMuc = new ToolStripMenuItem();
            this.mnuNghiepVu = new ToolStripMenuItem();
            this.mnuBaoCao = new ToolStripMenuItem();
            this.mnuQuanTri = new ToolStripMenuItem();
            this.mnuTroGiup = new ToolStripMenuItem();

            // ===== Toolbar Panel =====
            this.pnlToolbar = new Panel();
            this.btnThuNhap = new Button();
            this.btnChiTieu = new Button();
            this.btnNganSach = new Button();
            this.btnBaoCao = new Button();
            this.btnTimKiem = new Button();
            this.dtpThang = new DateTimePicker();
            this.btnLamMoi = new Button();

            // ===== Top Section =====
            this.pnlTopSection = new Panel();
            this.lblNganSach = new Label();
            this.lblThang2 = new Label();
            this.cboThang = new ComboBox();
            this.lblNam = new Label();
            this.cboNam = new ComboBox();
            this.btnXem = new Button();
            this.btnDatHanMuc = new Button();
            this.btnSaoChep = new Button();
            this.lblThang102026DuLieuDen = new Label();
            this.lblChonDanhMucDatHanMucRoiNhanDat = new Label();

            // ===== Summary Cards =====
            this.pnlTheTongHop = new Panel();
            this.lblTongHanMuc = new Label();
            this.lblTongHanMuc2 = new Label();
            this.lblSoDanhMucDaDat = new Label();

            this.pnlTheTongHop2 = new Panel();
            this.lblDaChi = new Label();
            this.lblDaChi2 = new Label();
            this.lblPhanTramTongHanMuc = new Label();

            this.pnlTheTongHop3 = new Panel();
            this.lblConLai = new Label();
            this.lblConLai2 = new Label();
            this.lblNganSachThang102026 = new Label();

            // ===== Budget By Category =====
            this.pnlNganSachDanhMuc = new Panel();
            this.lblLoaiChi = new Label();
            this.lblDaChiHanMuc = new Label();
            this.lblMucSuDung = new Label();
            this.lblConLai3 = new Label();
            this.lblTrangThai = new Label();

            // Category rows
            this.lblNhaO = new Label();
            this.lblNhaO2 = new Label();
            this.prgNhaO = new ProgressBar();
            this.lblTyLe = new Label();
            this.lblNhaO3 = new Label();
            this.lblDaChamHanMuc = new Label();

            this.lblAnUong = new Label();
            this.lblAnUong2 = new Label();
            this.prgAnUong = new ProgressBar();
            this.lblTyLe2 = new Label();
            this.lblAnUong3 = new Label();
            this.lblSapDatHanMuc = new Label();

            this.lblDiChuyen = new Label();
            this.lblDiChuyen2 = new Label();
            this.prgDiChuyen = new ProgressBar();
            this.lblTyLe3 = new Label();
            this.lblDiChuyen3 = new Label();
            this.lblVuotHanMuc = new Label();

            this.lblMuaSam = new Label();
            this.lblMuaSam2 = new Label();
            this.prgMuaSam = new ProgressBar();
            this.lblTyLe4 = new Label();
            this.lblMuaSam3 = new Label();
            this.lblTrongHanMuc = new Label();

            this.lblKhac = new Label();
            this.lblKhac2 = new Label();
            this.prgKhac = new ProgressBar();
            this.lblTyLe5 = new Label();
            this.lblKhac3 = new Label();
            this.lblChuaDatHanMuc = new Label();

            this.lblYTe = new Label();
            this.lblYTe2 = new Label();
            this.prgYTe = new ProgressBar();
            this.lblTyLe6 = new Label();
            this.lblYTe3 = new Label();
            this.lblTrangThaiYTe = new Label();

            // ===== Legend =====
            this.pnlLegend = new Panel();
            this.pnlGreenSquare = new Panel();
            this.lblDuoi80 = new Label();
            this.pnlOrangeSquare = new Panel();
            this.lblTu80DenDuoi100 = new Label();
            this.pnlRedSquare = new Panel();
            this.lblTu100TroLen = new Label();

            // ===== Status Strip =====
            this.stsTrangThai = new StatusStrip();
            this.lblTrangThaiBar = new ToolStripStatusLabel();

            this.SuspendLayout();

            // ───────────────────────────────────────────────
            // mnuChinh
            // ───────────────────────────────────────────────
            this.mnuChinh.Items.AddRange(new ToolStripItem[] {
                this.mnuHeThong, this.mnuDanhMuc, this.mnuNghiepVu,
                this.mnuBaoCao, this.mnuQuanTri, this.mnuTroGiup
            });
            this.mnuChinh.Location = new System.Drawing.Point(0, 0);
            this.mnuChinh.Name = "mnuChinh";
            this.mnuChinh.Size = new System.Drawing.Size(1050, 24);
            this.mnuChinh.BackColor = System.Drawing.Color.White;
            this.mnuChinh.Font = new System.Drawing.Font("Segoe UI", 9F);

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

            // ───────────────────────────────────────────────
            // pnlToolbar
            // ───────────────────────────────────────────────
            this.pnlToolbar.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.pnlToolbar.Dock = DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 24);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1050, 45);
            this.pnlToolbar.Controls.Add(this.btnLamMoi);
            this.pnlToolbar.Controls.Add(this.dtpThang);
            this.pnlToolbar.Controls.Add(this.btnTimKiem);
            this.pnlToolbar.Controls.Add(this.btnBaoCao);
            this.pnlToolbar.Controls.Add(this.btnNganSach);
            this.pnlToolbar.Controls.Add(this.btnChiTieu);
            this.pnlToolbar.Controls.Add(this.btnThuNhap);

            // btnThuNhap
            this.btnThuNhap.FlatStyle = FlatStyle.Flat;
            this.btnThuNhap.FlatAppearance.BorderSize = 1;
            this.btnThuNhap.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnThuNhap.BackColor = System.Drawing.Color.White;
            this.btnThuNhap.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.btnThuNhap.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThuNhap.Location = new System.Drawing.Point(10, 8);
            this.btnThuNhap.Name = "btnThuNhap";
            this.btnThuNhap.Size = new System.Drawing.Size(100, 30);
            this.btnThuNhap.Text = "+ Thu nhập";
            this.btnThuNhap.Cursor = Cursors.Hand;
            this.btnThuNhap.Click += new System.EventHandler(this.btnThuNhap_Click);

            // btnChiTieu
            this.btnChiTieu.FlatStyle = FlatStyle.Flat;
            this.btnChiTieu.FlatAppearance.BorderSize = 1;
            this.btnChiTieu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnChiTieu.BackColor = System.Drawing.Color.White;
            this.btnChiTieu.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.btnChiTieu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnChiTieu.Location = new System.Drawing.Point(116, 8);
            this.btnChiTieu.Name = "btnChiTieu";
            this.btnChiTieu.Size = new System.Drawing.Size(100, 30);
            this.btnChiTieu.Text = "— Chi tiêu";
            this.btnChiTieu.Cursor = Cursors.Hand;
            this.btnChiTieu.Click += new System.EventHandler(this.btnChiTieu_Click);

            // btnNganSach (ACTIVE - highlighted blue)
            this.btnNganSach.FlatStyle = FlatStyle.Flat;
            this.btnNganSach.FlatAppearance.BorderSize = 0;
            this.btnNganSach.BackColor = System.Drawing.Color.FromArgb(21, 101, 192);
            this.btnNganSach.ForeColor = System.Drawing.Color.White;
            this.btnNganSach.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNganSach.Location = new System.Drawing.Point(222, 8);
            this.btnNganSach.Name = "btnNganSach";
            this.btnNganSach.Size = new System.Drawing.Size(100, 30);
            this.btnNganSach.Text = "Ngân sách";
            this.btnNganSach.Cursor = Cursors.Hand;

            // btnBaoCao
            this.btnBaoCao.FlatStyle = FlatStyle.Flat;
            this.btnBaoCao.FlatAppearance.BorderSize = 1;
            this.btnBaoCao.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnBaoCao.BackColor = System.Drawing.Color.White;
            this.btnBaoCao.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.btnBaoCao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBaoCao.Location = new System.Drawing.Point(328, 8);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(100, 30);
            this.btnBaoCao.Text = "Báo cáo";
            this.btnBaoCao.Cursor = Cursors.Hand;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);

            // btnTimKiem
            this.btnTimKiem.FlatStyle = FlatStyle.Flat;
            this.btnTimKiem.FlatAppearance.BorderSize = 1;
            this.btnTimKiem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnTimKiem.BackColor = System.Drawing.Color.White;
            this.btnTimKiem.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTimKiem.Location = new System.Drawing.Point(434, 8);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 30);
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Cursor = Cursors.Hand;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

            // dtpThang
            this.dtpThang.Format = DateTimePickerFormat.Custom;
            this.dtpThang.CustomFormat = "MM/yyyy";
            this.dtpThang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpThang.Location = new System.Drawing.Point(830, 10);
            this.dtpThang.Name = "dtpThang";
            this.dtpThang.Size = new System.Drawing.Size(120, 23);
            this.dtpThang.ShowUpDown = true;

            // btnLamMoi
            this.btnLamMoi.FlatStyle = FlatStyle.Flat;
            this.btnLamMoi.FlatAppearance.BorderSize = 1;
            this.btnLamMoi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnLamMoi.BackColor = System.Drawing.Color.White;
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLamMoi.Location = new System.Drawing.Point(958, 8);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(80, 30);
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Cursor = Cursors.Hand;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // ───────────────────────────────────────────────
            // pnlTopSection
            // ───────────────────────────────────────────────
            this.pnlTopSection.Location = new System.Drawing.Point(0, 69);
            this.pnlTopSection.Name = "pnlTopSection";
            this.pnlTopSection.Size = new System.Drawing.Size(1050, 65);
            this.pnlTopSection.BackColor = System.Drawing.Color.White;
            this.pnlTopSection.Controls.Add(this.lblNganSach);
            this.pnlTopSection.Controls.Add(this.lblThang2);
            this.pnlTopSection.Controls.Add(this.cboThang);
            this.pnlTopSection.Controls.Add(this.lblNam);
            this.pnlTopSection.Controls.Add(this.cboNam);
            this.pnlTopSection.Controls.Add(this.btnXem);
            this.pnlTopSection.Controls.Add(this.btnDatHanMuc);
            this.pnlTopSection.Controls.Add(this.btnSaoChep);
            this.pnlTopSection.Controls.Add(this.lblThang102026DuLieuDen);
            this.pnlTopSection.Controls.Add(this.lblChonDanhMucDatHanMucRoiNhanDat);

            // lblNganSach
            this.lblNganSach.AutoSize = true;
            this.lblNganSach.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblNganSach.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            this.lblNganSach.Location = new System.Drawing.Point(15, 5);
            this.lblNganSach.Name = "lblNganSach";
            this.lblNganSach.Text = "Ngân sách";

            // lblThang2
            this.lblThang2.AutoSize = true;
            this.lblThang2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblThang2.Location = new System.Drawing.Point(15, 40);
            this.lblThang2.Name = "lblThang2";
            this.lblThang2.Text = "Tháng:";

            // cboThang
            this.cboThang.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboThang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboThang.Location = new System.Drawing.Point(60, 37);
            this.cboThang.Name = "cboThang";
            this.cboThang.Size = new System.Drawing.Size(55, 23);

            // lblNam
            this.lblNam.AutoSize = true;
            this.lblNam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNam.Location = new System.Drawing.Point(125, 40);
            this.lblNam.Name = "lblNam";
            this.lblNam.Text = "Năm:";

            // cboNam
            this.cboNam.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboNam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboNam.Location = new System.Drawing.Point(163, 37);
            this.cboNam.Name = "cboNam";
            this.cboNam.Size = new System.Drawing.Size(70, 23);

            // btnXem
            this.btnXem.FlatStyle = FlatStyle.Flat;
            this.btnXem.FlatAppearance.BorderSize = 0;
            this.btnXem.BackColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.btnXem.ForeColor = System.Drawing.Color.White;
            this.btnXem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXem.Location = new System.Drawing.Point(245, 35);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(110, 27);
            this.btnXem.Text = "Xem ngân sách";
            this.btnXem.Cursor = Cursors.Hand;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);

            // btnDatHanMuc
            this.btnDatHanMuc.FlatStyle = FlatStyle.Flat;
            this.btnDatHanMuc.FlatAppearance.BorderSize = 0;
            this.btnDatHanMuc.BackColor = System.Drawing.Color.FromArgb(21, 101, 192);
            this.btnDatHanMuc.ForeColor = System.Drawing.Color.White;
            this.btnDatHanMuc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDatHanMuc.Location = new System.Drawing.Point(365, 35);
            this.btnDatHanMuc.Name = "btnDatHanMuc";
            this.btnDatHanMuc.Size = new System.Drawing.Size(130, 27);
            this.btnDatHanMuc.Text = "+ Đặt hạn mức";
            this.btnDatHanMuc.Cursor = Cursors.Hand;
            this.btnDatHanMuc.Click += new System.EventHandler(this.btnDatHanMuc_Click);

            // btnSaoChep
            this.btnSaoChep.FlatStyle = FlatStyle.Flat;
            this.btnSaoChep.FlatAppearance.BorderSize = 1;
            this.btnSaoChep.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.btnSaoChep.BackColor = System.Drawing.Color.White;
            this.btnSaoChep.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            this.btnSaoChep.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSaoChep.Location = new System.Drawing.Point(505, 35);
            this.btnSaoChep.Name = "btnSaoChep";
            this.btnSaoChep.Size = new System.Drawing.Size(155, 27);
            this.btnSaoChep.Text = "Sao chép tháng trước";
            this.btnSaoChep.Cursor = Cursors.Hand;
            this.btnSaoChep.Click += new System.EventHandler(this.btnSaoChep_Click);

            // lblThang102026DuLieuDen
            this.lblThang102026DuLieuDen.AutoSize = true;
            this.lblThang102026DuLieuDen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblThang102026DuLieuDen.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblThang102026DuLieuDen.Location = new System.Drawing.Point(750, 8);
            this.lblThang102026DuLieuDen.Name = "lblThang102026DuLieuDen";
            this.lblThang102026DuLieuDen.Text = "Tháng 10/2026 • Dữ liệu đến ngày 26/10/2026";
            this.lblThang102026DuLieuDen.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // lblChonDanhMucDatHanMucRoiNhanDat
            this.lblChonDanhMucDatHanMucRoiNhanDat.AutoSize = true;
            this.lblChonDanhMucDatHanMucRoiNhanDat.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblChonDanhMucDatHanMucRoiNhanDat.ForeColor = System.Drawing.Color.FromArgb(120, 120, 120);
            this.lblChonDanhMucDatHanMucRoiNhanDat.Location = new System.Drawing.Point(750, 40);
            this.lblChonDanhMucDatHanMucRoiNhanDat.Name = "lblChonDanhMucDatHanMucRoiNhanDat";
            this.lblChonDanhMucDatHanMucRoiNhanDat.Text = "Chọn danh mục rồi nhấn Đặt hạn mức để cập nhật.";
            this.lblChonDanhMucDatHanMucRoiNhanDat.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // ───────────────────────────────────────────────
            // Summary Cards - pnlTheTongHop
            // ───────────────────────────────────────────────
            int cardTop = 140;
            int cardHeight = 85;
            int cardWidth = 320;
            int cardGap = 15;
            int cardLeft1 = 20;
            int cardLeft2 = cardLeft1 + cardWidth + cardGap;
            int cardLeft3 = cardLeft2 + cardWidth + cardGap;

            // pnlTheTongHop
            this.pnlTheTongHop.BackColor = System.Drawing.Color.White;
            this.pnlTheTongHop.BorderStyle = BorderStyle.FixedSingle;
            this.pnlTheTongHop.Location = new System.Drawing.Point(cardLeft1, cardTop);
            this.pnlTheTongHop.Name = "pnlTheTongHop";
            this.pnlTheTongHop.Size = new System.Drawing.Size(cardWidth, cardHeight);
            this.pnlTheTongHop.Controls.Add(this.lblTongHanMuc);
            this.pnlTheTongHop.Controls.Add(this.lblTongHanMuc2);
            this.pnlTheTongHop.Controls.Add(this.lblSoDanhMucDaDat);

            this.lblTongHanMuc.AutoSize = true;
            this.lblTongHanMuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTongHanMuc.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblTongHanMuc.Location = new System.Drawing.Point(12, 8);
            this.lblTongHanMuc.Name = "lblTongHanMuc";
            this.lblTongHanMuc.Text = "Tổng hạn mức";

            this.lblTongHanMuc2.AutoSize = true;
            this.lblTongHanMuc2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongHanMuc2.ForeColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.lblTongHanMuc2.Location = new System.Drawing.Point(10, 28);
            this.lblTongHanMuc2.Name = "lblTongHanMuc2";
            this.lblTongHanMuc2.Text = "0 đ";

            this.lblSoDanhMucDaDat.AutoSize = true;
            this.lblSoDanhMucDaDat.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSoDanhMucDaDat.ForeColor = System.Drawing.Color.FromArgb(130, 130, 130);
            this.lblSoDanhMucDaDat.Location = new System.Drawing.Point(12, 62);
            this.lblSoDanhMucDaDat.Name = "lblSoDanhMucDaDat";
            this.lblSoDanhMucDaDat.Text = "0 danh mục đã đặt hạn mức";

            // pnlTheTongHop2
            this.pnlTheTongHop2.BackColor = System.Drawing.Color.White;
            this.pnlTheTongHop2.BorderStyle = BorderStyle.FixedSingle;
            this.pnlTheTongHop2.Location = new System.Drawing.Point(cardLeft2, cardTop);
            this.pnlTheTongHop2.Name = "pnlTheTongHop2";
            this.pnlTheTongHop2.Size = new System.Drawing.Size(cardWidth, cardHeight);
            this.pnlTheTongHop2.Controls.Add(this.lblDaChi);
            this.pnlTheTongHop2.Controls.Add(this.lblDaChi2);
            this.pnlTheTongHop2.Controls.Add(this.lblPhanTramTongHanMuc);

            this.lblDaChi.AutoSize = true;
            this.lblDaChi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDaChi.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblDaChi.Location = new System.Drawing.Point(12, 8);
            this.lblDaChi.Name = "lblDaChi";
            this.lblDaChi.Text = "Đã chi";

            this.lblDaChi2.AutoSize = true;
            this.lblDaChi2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDaChi2.ForeColor = System.Drawing.Color.FromArgb(230, 74, 25);
            this.lblDaChi2.Location = new System.Drawing.Point(10, 28);
            this.lblDaChi2.Name = "lblDaChi2";
            this.lblDaChi2.Text = "0 đ";

            this.lblPhanTramTongHanMuc.AutoSize = true;
            this.lblPhanTramTongHanMuc.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPhanTramTongHanMuc.ForeColor = System.Drawing.Color.FromArgb(130, 130, 130);
            this.lblPhanTramTongHanMuc.Location = new System.Drawing.Point(12, 62);
            this.lblPhanTramTongHanMuc.Name = "lblPhanTramTongHanMuc";
            this.lblPhanTramTongHanMuc.Text = "0% tổng hạn mức";

            // pnlTheTongHop3
            this.pnlTheTongHop3.BackColor = System.Drawing.Color.White;
            this.pnlTheTongHop3.BorderStyle = BorderStyle.FixedSingle;
            this.pnlTheTongHop3.Location = new System.Drawing.Point(cardLeft3, cardTop);
            this.pnlTheTongHop3.Name = "pnlTheTongHop3";
            this.pnlTheTongHop3.Size = new System.Drawing.Size(cardWidth, cardHeight);
            this.pnlTheTongHop3.Controls.Add(this.lblConLai);
            this.pnlTheTongHop3.Controls.Add(this.lblConLai2);
            this.pnlTheTongHop3.Controls.Add(this.lblNganSachThang102026);

            this.lblConLai.AutoSize = true;
            this.lblConLai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblConLai.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblConLai.Location = new System.Drawing.Point(12, 8);
            this.lblConLai.Name = "lblConLai";
            this.lblConLai.Text = "Còn lại";

            this.lblConLai2.AutoSize = true;
            this.lblConLai2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblConLai2.ForeColor = System.Drawing.Color.FromArgb(25, 118, 210);
            this.lblConLai2.Location = new System.Drawing.Point(10, 28);
            this.lblConLai2.Name = "lblConLai2";
            this.lblConLai2.Text = "0 đ";

            this.lblNganSachThang102026.AutoSize = true;
            this.lblNganSachThang102026.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNganSachThang102026.ForeColor = System.Drawing.Color.FromArgb(130, 130, 130);
            this.lblNganSachThang102026.Location = new System.Drawing.Point(12, 62);
            this.lblNganSachThang102026.Name = "lblNganSachThang102026";
            this.lblNganSachThang102026.Text = "Ngân sách tháng ...";

            // ───────────────────────────────────────────────
            // pnlNganSachDanhMuc
            // ───────────────────────────────────────────────
            int dmTop = 235;
            this.pnlNganSachDanhMuc.BackColor = System.Drawing.Color.White;
            this.pnlNganSachDanhMuc.BorderStyle = BorderStyle.FixedSingle;
            this.pnlNganSachDanhMuc.Location = new System.Drawing.Point(20, dmTop);
            this.pnlNganSachDanhMuc.Name = "pnlNganSachDanhMuc";
            this.pnlNganSachDanhMuc.Size = new System.Drawing.Size(1005, 290);
            this.pnlNganSachDanhMuc.AutoScroll = true;

            // Header row
            int hdrY = 8;
            System.Drawing.Font hdrFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            System.Drawing.Color hdrColor = System.Drawing.Color.FromArgb(80, 80, 80);

            this.lblLoaiChi.AutoSize = true;
            this.lblLoaiChi.Font = hdrFont;
            this.lblLoaiChi.ForeColor = hdrColor;
            this.lblLoaiChi.Location = new System.Drawing.Point(15, hdrY);
            this.lblLoaiChi.Name = "lblLoaiChi";
            this.lblLoaiChi.Text = "Loại chi";

            this.lblDaChiHanMuc.AutoSize = true;
            this.lblDaChiHanMuc.Font = hdrFont;
            this.lblDaChiHanMuc.ForeColor = hdrColor;
            this.lblDaChiHanMuc.Location = new System.Drawing.Point(160, hdrY);
            this.lblDaChiHanMuc.Name = "lblDaChiHanMuc";
            this.lblDaChiHanMuc.Text = "Đã chi / Hạn mức";

            this.lblMucSuDung.AutoSize = true;
            this.lblMucSuDung.Font = hdrFont;
            this.lblMucSuDung.ForeColor = hdrColor;
            this.lblMucSuDung.Location = new System.Drawing.Point(400, hdrY);
            this.lblMucSuDung.Name = "lblMucSuDung";
            this.lblMucSuDung.Text = "Mức sử dụng";

            this.lblConLai3.AutoSize = true;
            this.lblConLai3.Font = hdrFont;
            this.lblConLai3.ForeColor = hdrColor;
            this.lblConLai3.Location = new System.Drawing.Point(700, hdrY);
            this.lblConLai3.Name = "lblConLai3";
            this.lblConLai3.Text = "Còn lại";

            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = hdrFont;
            this.lblTrangThai.ForeColor = hdrColor;
            this.lblTrangThai.Location = new System.Drawing.Point(840, hdrY);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Text = "Trạng thái";

            this.pnlNganSachDanhMuc.Controls.Add(this.lblLoaiChi);
            this.pnlNganSachDanhMuc.Controls.Add(this.lblDaChiHanMuc);
            this.pnlNganSachDanhMuc.Controls.Add(this.lblMucSuDung);
            this.pnlNganSachDanhMuc.Controls.Add(this.lblConLai3);
            this.pnlNganSachDanhMuc.Controls.Add(this.lblTrangThai);

            // ── Category rows ──
            System.Drawing.Font rowFont = new System.Drawing.Font("Segoe UI", 9F);
            System.Drawing.Font rowBoldFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            int rowH = 40;
            int baseY = 35;

            // Row 0: Nhà ở
            int r0 = baseY;
            SetupCategoryRowControls(this.lblNhaO, "Nhà ở", this.lblNhaO2, this.prgNhaO, this.lblTyLe, this.lblNhaO3, this.lblDaChamHanMuc, "Đã chạm hạn mức", r0, rowFont, rowBoldFont);

            // Row 1: Ăn uống
            int r1 = baseY + rowH;
            SetupCategoryRowControls(this.lblAnUong, "Ăn uống", this.lblAnUong2, this.prgAnUong, this.lblTyLe2, this.lblAnUong3, this.lblSapDatHanMuc, "Sắp đạt hạn mức", r1, rowFont, rowBoldFont);

            // Row 2: Di chuyển
            int r2 = baseY + rowH * 2;
            SetupCategoryRowControls(this.lblDiChuyen, "Di chuyển", this.lblDiChuyen2, this.prgDiChuyen, this.lblTyLe3, this.lblDiChuyen3, this.lblVuotHanMuc, "Vượt hạn mức", r2, rowFont, rowBoldFont);

            // Row 3: Mua sắm
            int r3 = baseY + rowH * 3;
            SetupCategoryRowControls(this.lblMuaSam, "Mua sắm", this.lblMuaSam2, this.prgMuaSam, this.lblTyLe4, this.lblMuaSam3, this.lblTrongHanMuc, "Trong hạn mức", r3, rowFont, rowBoldFont);

            // Row 4: Khác
            int r4 = baseY + rowH * 4;
            SetupCategoryRowControls(this.lblKhac, "Khác", this.lblKhac2, this.prgKhac, this.lblTyLe5, this.lblKhac3, this.lblChuaDatHanMuc, "Chưa đặt hạn mức", r4, rowFont, rowBoldFont);

            // Row 5: Y tế
            int r5 = baseY + rowH * 5;
            SetupCategoryRowControls(this.lblYTe, "Y tế", this.lblYTe2, this.prgYTe, this.lblTyLe6, this.lblYTe3, this.lblTrangThaiYTe, "", r5, rowFont, rowBoldFont);

            // ───────────────────────────────────────────────
            // Legend Panel
            // ───────────────────────────────────────────────
            int legendTop = 535;
            this.pnlLegend.BackColor = System.Drawing.Color.White;
            this.pnlLegend.Location = new System.Drawing.Point(20, legendTop);
            this.pnlLegend.Name = "pnlLegend";
            this.pnlLegend.Size = new System.Drawing.Size(1005, 28);

            this.pnlGreenSquare.BackColor = System.Drawing.Color.FromArgb(46, 125, 50);
            this.pnlGreenSquare.Location = new System.Drawing.Point(10, 6);
            this.pnlGreenSquare.Name = "pnlGreenSquare";
            this.pnlGreenSquare.Size = new System.Drawing.Size(16, 16);

            this.lblDuoi80.AutoSize = true;
            this.lblDuoi80.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDuoi80.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblDuoi80.Location = new System.Drawing.Point(30, 7);
            this.lblDuoi80.Name = "lblDuoi80";
            this.lblDuoi80.Text = "Dưới 80%";

            this.pnlOrangeSquare.BackColor = System.Drawing.Color.FromArgb(245, 124, 0);
            this.pnlOrangeSquare.Location = new System.Drawing.Point(130, 6);
            this.pnlOrangeSquare.Name = "pnlOrangeSquare";
            this.pnlOrangeSquare.Size = new System.Drawing.Size(16, 16);

            this.lblTu80DenDuoi100.AutoSize = true;
            this.lblTu80DenDuoi100.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTu80DenDuoi100.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblTu80DenDuoi100.Location = new System.Drawing.Point(150, 7);
            this.lblTu80DenDuoi100.Name = "lblTu80DenDuoi100";
            this.lblTu80DenDuoi100.Text = "Từ 80% đến dưới 100%";

            this.pnlRedSquare.BackColor = System.Drawing.Color.FromArgb(198, 40, 40);
            this.pnlRedSquare.Location = new System.Drawing.Point(330, 6);
            this.pnlRedSquare.Name = "pnlRedSquare";
            this.pnlRedSquare.Size = new System.Drawing.Size(16, 16);

            this.lblTu100TroLen.AutoSize = true;
            this.lblTu100TroLen.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTu100TroLen.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            this.lblTu100TroLen.Location = new System.Drawing.Point(350, 7);
            this.lblTu100TroLen.Name = "lblTu100TroLen";
            this.lblTu100TroLen.Text = "Từ 100% trở lên";

            this.pnlLegend.Controls.Add(this.pnlGreenSquare);
            this.pnlLegend.Controls.Add(this.lblDuoi80);
            this.pnlLegend.Controls.Add(this.pnlOrangeSquare);
            this.pnlLegend.Controls.Add(this.lblTu80DenDuoi100);
            this.pnlLegend.Controls.Add(this.pnlRedSquare);
            this.pnlLegend.Controls.Add(this.lblTu100TroLen);

            // ───────────────────────────────────────────────
            // stsTrangThai
            // ───────────────────────────────────────────────
            this.stsTrangThai.Items.Add(this.lblTrangThaiBar);
            this.stsTrangThai.Location = new System.Drawing.Point(0, 575);
            this.stsTrangThai.Name = "stsTrangThai";
            this.stsTrangThai.Size = new System.Drawing.Size(1050, 22);
            this.stsTrangThai.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            this.lblTrangThaiBar.Name = "lblTrangThaiBar";
            this.lblTrangThaiBar.Text = "Sẵn sàng";

            // ───────────────────────────────────────────────
            // frmNganSach
            // ───────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(1050, 620);
            this.Controls.Add(this.pnlLegend);
            this.Controls.Add(this.pnlNganSachDanhMuc);
            this.Controls.Add(this.pnlTheTongHop3);
            this.Controls.Add(this.pnlTheTongHop2);
            this.Controls.Add(this.pnlTheTongHop);
            this.Controls.Add(this.pnlTopSection);
            this.Controls.Add(this.stsTrangThai);
            this.Controls.Add(this.pnlToolbar);
            this.Controls.Add(this.mnuChinh);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnuChinh;
            this.MaximizeBox = false;
            this.Name = "frmNganSach";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Chi Tiêu — Ngân sách";
            this.Load += new System.EventHandler(this.frmNganSach_Load);

            this.pnlToolbar.ResumeLayout(false);
            this.pnlTopSection.ResumeLayout(false);
            this.pnlTopSection.PerformLayout();
            this.pnlTheTongHop.ResumeLayout(false);
            this.pnlTheTongHop.PerformLayout();
            this.pnlTheTongHop2.ResumeLayout(false);
            this.pnlTheTongHop2.PerformLayout();
            this.pnlTheTongHop3.ResumeLayout(false);
            this.pnlTheTongHop3.PerformLayout();
            this.pnlNganSachDanhMuc.ResumeLayout(false);
            this.pnlNganSachDanhMuc.PerformLayout();
            this.pnlLegend.ResumeLayout(false);
            this.pnlLegend.PerformLayout();
            this.stsTrangThai.ResumeLayout(false);
            this.stsTrangThai.PerformLayout();
            this.mnuChinh.ResumeLayout(false);
            this.mnuChinh.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void SetupCategoryRowControls(Label lblName, string name, Label lblSpent, ProgressBar prg, Label lblPct, Label lblRemain, Label lblStatus, string statusText, int y, System.Drawing.Font rowFont, System.Drawing.Font boldFont)
        {
            int midY = y + 8;

            lblName.AutoSize = true;
            lblName.Font = boldFont;
            lblName.ForeColor = System.Drawing.Color.FromArgb(33, 33, 33);
            lblName.Location = new System.Drawing.Point(15, midY);
            lblName.Name = lblName.Name ?? ("lbl" + name);
            lblName.Text = name;
            lblName.Cursor = Cursors.Hand;

            lblSpent.AutoSize = true;
            lblSpent.Font = rowFont;
            lblSpent.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            lblSpent.Location = new System.Drawing.Point(160, midY);
            lblSpent.Name = lblSpent.Name ?? ("lbl" + name + "2");
            lblSpent.Text = "0 đ / 0 đ";

            prg.Location = new System.Drawing.Point(400, midY - 2);
            prg.Name = prg.Name ?? ("prg" + name);
            prg.Size = new System.Drawing.Size(200, 20);
            prg.Minimum = 0;
            prg.Maximum = 100;
            prg.Value = 0;
            prg.Style = ProgressBarStyle.Continuous;

            lblPct.AutoSize = true;
            lblPct.Font = rowFont;
            lblPct.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            lblPct.Location = new System.Drawing.Point(610, midY);
            lblPct.Name = lblPct.Name ?? ("lblTyLe");
            lblPct.Text = "0%";

            lblRemain.AutoSize = true;
            lblRemain.Font = rowFont;
            lblRemain.ForeColor = System.Drawing.Color.FromArgb(80, 80, 80);
            lblRemain.Location = new System.Drawing.Point(700, midY);
            lblRemain.Name = lblRemain.Name ?? ("lbl" + name + "3");
            lblRemain.Text = "0 đ";

            lblStatus.AutoSize = true;
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblStatus.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            lblStatus.Location = new System.Drawing.Point(840, midY);
            lblStatus.Name = lblStatus.Name ?? ("lblTT");
            lblStatus.Text = statusText;

            // Separator line
            Panel sep = new Panel();
            sep.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            sep.Location = new System.Drawing.Point(10, y + 36);
            sep.Size = new System.Drawing.Size(980, 1);

            this.pnlNganSachDanhMuc.Controls.Add(lblName);
            this.pnlNganSachDanhMuc.Controls.Add(lblSpent);
            this.pnlNganSachDanhMuc.Controls.Add(prg);
            this.pnlNganSachDanhMuc.Controls.Add(lblPct);
            this.pnlNganSachDanhMuc.Controls.Add(lblRemain);
            this.pnlNganSachDanhMuc.Controls.Add(lblStatus);
            this.pnlNganSachDanhMuc.Controls.Add(sep);
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

        // Top Section
        private Panel pnlTopSection;
        private Label lblNganSach;
        private Label lblThang2;
        private ComboBox cboThang;
        private Label lblNam;
        private ComboBox cboNam;
        private Button btnXem;
        private Button btnDatHanMuc;
        private Button btnSaoChep;
        private Label lblThang102026DuLieuDen;
        private Label lblChonDanhMucDatHanMucRoiNhanDat;

        // Summary Cards
        private Panel pnlTheTongHop;
        private Label lblTongHanMuc;
        private Label lblTongHanMuc2;
        private Label lblSoDanhMucDaDat;

        private Panel pnlTheTongHop2;
        private Label lblDaChi;
        private Label lblDaChi2;
        private Label lblPhanTramTongHanMuc;

        private Panel pnlTheTongHop3;
        private Label lblConLai;
        private Label lblConLai2;
        private Label lblNganSachThang102026;

        // Budget by category panel
        private Panel pnlNganSachDanhMuc;
        private Label lblLoaiChi;
        private Label lblDaChiHanMuc;
        private Label lblMucSuDung;
        private Label lblConLai3;
        private Label lblTrangThai;

        // Category rows
        private Label lblNhaO;
        private Label lblNhaO2;
        private ProgressBar prgNhaO;
        private Label lblTyLe;
        private Label lblNhaO3;
        private Label lblDaChamHanMuc;

        private Label lblAnUong;
        private Label lblAnUong2;
        private ProgressBar prgAnUong;
        private Label lblTyLe2;
        private Label lblAnUong3;
        private Label lblSapDatHanMuc;

        private Label lblDiChuyen;
        private Label lblDiChuyen2;
        private ProgressBar prgDiChuyen;
        private Label lblTyLe3;
        private Label lblDiChuyen3;
        private Label lblVuotHanMuc;

        private Label lblMuaSam;
        private Label lblMuaSam2;
        private ProgressBar prgMuaSam;
        private Label lblTyLe4;
        private Label lblMuaSam3;
        private Label lblTrongHanMuc;

        private Label lblKhac;
        private Label lblKhac2;
        private ProgressBar prgKhac;
        private Label lblTyLe5;
        private Label lblKhac3;
        private Label lblChuaDatHanMuc;

        private Label lblYTe;
        private Label lblYTe2;
        private ProgressBar prgYTe;
        private Label lblTyLe6;
        private Label lblYTe3;
        private Label lblTrangThaiYTe;

        // Legend
        private Panel pnlLegend;
        private Panel pnlGreenSquare;
        private Label lblDuoi80;
        private Panel pnlOrangeSquare;
        private Label lblTu80DenDuoi100;
        private Panel pnlRedSquare;
        private Label lblTu100TroLen;

        // Status Strip
        private StatusStrip stsTrangThai;
        private ToolStripStatusLabel lblTrangThaiBar;
    }
}
